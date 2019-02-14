using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAThesisProject
{
    class PersonalProfileManageModel
    {
        private InterfaceMySQLStartDBConnect startDB;
        private InterfaceMySQLDBChannel mdi;

        KeyValuePair<string, string> param;
        List<KeyValuePair<string, string>> parameters;

        public PersonalProfileManageModel(UserConnDetails dbci, Form parent)
        {
            startDB = new InterfaceMySQLStartDBConnect();
            mdi = startDB.kapcsolodas(dbci, parent);
        }

        //prepared
        private string queryGettingTheUserNameofUser = "SELECT user_name FROM felhaszn WHERE user_id=@userId";
        /// <summary>
        /// gets the user_name valu from 'felhaszn' table by the specific id
        /// </summary>
        /// <param name="userId">the DB id of the user</param>
        /// <returns>user_name of the user</returns>
        public string getUserName(string userId)
        {
            string result = "";
            try
            {
               param = new KeyValuePair<string, string>("@userId", userId);
            }
            catch (Exception e)
            {
                throw new ErrorPersonalDetailsManage("Az adatbázis felé a kérés összeállítása sikertelen (ModPersUN) " 
                    + e.Message);
            }
            mdi.openConnection();
            result = mdi.execPrepScalarQueryInStringWithKVP(queryGettingTheUserNameofUser, param);
            mdi.closeConnection();
            return result;
        }


        //prepared
        private string queryChangePassword = "UPDATE felhaszn SET jelszo=@pwd WHERE user_id=@userId";
        /// <summary>
        /// sets in password change in 'felhaszn' table
        /// </summary>
        /// <param name="userId">the DB identifier of user</param>
        /// <param name="newPwd">the new password in hashed string</param>
        public void setChangeTheUserPassword(string userId, string newPwd)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> userid = new KeyValuePair<string, string>("@userId",userId);
                KeyValuePair<string, string> pwd = new KeyValuePair<string, string>("@pwd", newPwd);
                parameters.Add(userid);
                parameters.Add(pwd);
            }
            catch (Exception e)
            {
                throw new ErrorServiceUpdateRecord("Az adatbázis felé a kérés megalkotása sikertelen (ModPersonPwd) "
                     + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryChangePassword, parameters, 2);
            mdi.closeConnection();
        }



        //prepared
        private string queryChangeUserDatas = "UPDATE felhasznadatok SET vez_nev=@vezNev, ker_nev=@kerNev," +
            " taj_szam=@taj WHERE user_id=@userId";
        /// <summary>
        /// sets changes in 'felhasznadatok' table in some user connected datas
        /// </summary>
        /// <param name="userId">DB identifier of the user</param>
        /// <param name="lastName">the lastname</param>
        /// <param name="firstName">the firsname</param>
        /// <param name="taj">taj number</param>
        public void setChangesOfUserPersDatas(string userId, string lastName, string firstName, string taj)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> vezNev = new KeyValuePair<string, string>("@vezNev", lastName);
                KeyValuePair<string, string> kerNev = new KeyValuePair<string, string>("@kerNev", firstName);
                KeyValuePair<string, string> tajNum = new KeyValuePair<string, string>("@taj", taj);
                parameters.Add(vezNev);
                parameters.Add(kerNev);
                parameters.Add(tajNum);
            }
            catch(Exception e)
            {
                throw new ErrorServiceUpdateRecord("Az adatbázis felé a kérés megalotása sikertelen (ModPersonDatas"
                    + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryChangeUserDatas, parameters, 3);
            mdi.closeConnection();
        }

        //prepared = collect chemicals, accidents for pdf
        private string queryToGetChemicalThreaths = "SELECT DISTINCT termek_nev FROM raktminoseg WHERE termek_min_id=" +
            "(SELECT keresek.termek_min_id FROM keresek, felhasznadatok WHERE keresek.user_id=felhasznadatok.user_id" +
            " AND terulet=@area)";
        /// <summary>
        /// gets the list of chemicals from 'keresek' table
        /// </summary>
        /// <param name="userId">DB identifier of user</param>
        /// <param name="area">area of the user</param>
        /// <returns></returns>
        public List<string> getUserConnectedChemThreats(string area)
        {
            List<string> result = new List<string>();
            try
            {
                param = new KeyValuePair<string, string>("@area", area);
            }
            catch (Exception e)
            {
                throw new ErrorPersonalDetailsManage("Az adatbázis felé a kérés megalkotása sikertelen (ModPersonThreats) "
                    + e.Message);
            }
            mdi.openConnection();
            result = mdi.execPrepGetOneColumnToListWithKVP(queryToGetChemicalThreaths, param);
            mdi.closeConnection();
            return result;
        }


        private string queryToGetAccidentsOfUser = 
            "SELECT baleset.baleset_datum, baleset.baleset_leir FROM baleset, baleseterintett WHERE baleset.baleset_id=" +
            "baleseterintett.baleset_id AND baleseterintett.user_id=@userId";


        public List<string[]> getUserConnectedAccidents(string userId)
        {
            List<string[]> result;
            try
            {
                param = new KeyValuePair<string, string>("userId", userId);
            }
            catch (Exception e)
            {
                throw new ErrorPersonalDetailsManage("Az adatbázis felé a kérés megalkotása sikertelen (ModPersonAccid) "
                    + e.Message);
            }
            mdi.openConnection();
            result = mdi.execPrepQueryInListStringArrWithKVP(queryToGetAccidentsOfUser, param);
            mdi.closeConnection();
            return result;
        }
    }
}
