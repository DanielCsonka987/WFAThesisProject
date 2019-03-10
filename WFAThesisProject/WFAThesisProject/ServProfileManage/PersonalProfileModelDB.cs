using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAThesisProject.ServProfileManage
{
    class PersonalProfileModelDB
    {
        private InterfaceMySQLStartDBConnect startDB;
        private InterfaceMySQLDBChannel mdi;

        KeyValuePair<string, string> param;
        List<KeyValuePair<string, string>> parameters;

        public PersonalProfileModelDB(UserConnDetails dbci, Form parent)
        {
            startDB = new InterfaceMySQLStartDBConnect();
            mdi = startDB.kapcsolodas(dbci, parent);
        }
        //tested
        #region readIn datas - newUserFullameTaj; oldPwdRevision
        //prepared
        private string queryGettingTheUserNameofUser = 
            "SELECT vez_nev, ker_nev, taj_szam FROM felhasznadatok WHERE user_id=@userId";
        /// <summary>
        /// gets the user_name valu from 'felhaszn' table by the specific id
        /// </summary>
        /// <param name="userId">the DB id of the user</param>
        /// <returns>user_name of the user</returns>
        public string[] getNameAndTajOfUser(string userId)
        {
            string[] result = null;
            try
            {
               param = new KeyValuePair<string, string>("@userId", userId);
            }
            catch (Exception e)
            {
                throw new ErrorServiceProfileDetailsManage("Az adatbázis felé a kérés összeállítása sikertelen (ModProfUNTaj) " 
                    + e.Message);
            }
            mdi.openConnection();
            result = mdi.execPrepQueryOneRowInStringArrWithKVP(queryGettingTheUserNameofUser, param);
            mdi.closeConnection();
            return result;
        }
        private string queryToGetTheOldHashedPwd = "SELECT jelszo FROM felhaszn WHERE user_id = @userId";
        /// <summary>
        /// revises the old password in case the user wants to change - autentification
        /// </summary>
        /// <param name="userId">DB identifier of the user</param>
        /// <returns>hashed pwd of the old pwd from DB</returns>
        public string reviseOldPwdVailidity(string userId)
        {
            string hashedPwd = "";
            try
            {
                param = new KeyValuePair<string, string>("@userId", userId);
            }
            catch (Exception e)
            {
                throw new ErrorServiceProfileReviseOldPwd("A kérés összeállítása sikertelen (ModProfOldPwd) " + e.Message);
            }
            mdi.openConnection();
            hashedPwd = mdi.execPrepScalarQueryInStringWithKVP(queryToGetTheOldHashedPwd, param);
            mdi.closeConnection();
            return hashedPwd;
        }

        #endregion
        //tested
        #region change DB at password and personal details
        //prepared
        private string queryChangePassword = "UPDATE felhaszn SET jelszo=@pwd WHERE user_id=@userId";
        /// <summary>
        /// sets in password change in 'felhaszn' table
        /// </summary>
        /// <param name="userId">the DB identifier of user</param>
        /// <param name="newPwdHashed">the new password in hashed string</param>
        public void setChangeTheUserPassword(string userId, string newPwdHashed)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> userid = new KeyValuePair<string, string>("@userId",userId);
                KeyValuePair<string, string> pwd = new KeyValuePair<string, string>("@pwd", newPwdHashed);
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
                KeyValuePair<string, string> userID = new KeyValuePair<string, string>("@userId", userId);
                parameters.Add(vezNev);
                parameters.Add(kerNev);
                parameters.Add(tajNum);
                parameters.Add(userID);
            }
            catch(Exception e)
            {
                throw new ErrorServiceUpdateRecord("Az adatbázis felé a kérés megalotása sikertelen (ModPersonDatas"
                    + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryChangeUserDatas, parameters, 4);
            mdi.closeConnection();
        }
        #endregion
        //tested
        #region read in PDF details
        //prepared = collect chemicals, accidents for pdf
        private string queryToGetChemicalThreaths =
            "SELECT DISTINCT raktminoseg.termek_nev FROM keresek, felhasznadatok, raktminoseg, raktmennyiseg" + 
            " WHERE keresek.user_id=felhasznadatok.user_id AND keresek.termek_quant_id = raktmennyiseg.termek_quant_id" +
            " AND raktminoseg.termek_min_id = raktmennyiseg.termek_min_id AND felhasznadatok.terulet = @area" +
            " ORDER BY raktminoseg.termek_nev";
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
                throw new ErrorServiceProfileDetailsManage("Az adatbázis felé a kérés megalkotása sikertelen (ModPersonThreats) "
                    + e.Message);
            }
            mdi.openConnection();
            result = mdi.execPrepGetOneColumnToListWithKVP(queryToGetChemicalThreaths, param);
            mdi.closeConnection();
            return result;
        }
        private string queryToGetAccidentsOfUser = 
            "SELECT baleset.baleset_datum, baleset.baleset_leiras FROM baleset, baleseterintett" +
            " WHERE baleset.baleset_id = baleseterintett.baleset_id AND baleseterintett.user_id=@userId";
        /// <summary>
        /// gets the accident of the specified user
        /// </summary>
        /// <param name="userId">userId in DB of the user</param>
        /// <returns></returns>
        public List<string[]> getUserConnectedAccidents(string userId)
        {
            List<string[]> result;
            try
            {
                param = new KeyValuePair<string, string>("userId", userId);
            }
            catch (Exception e)
            {
                throw new ErrorServiceProfileDetailsManage("Az adatbázis felé a kérés megalkotása sikertelen (ModPersonAccid) "
                    + e.Message);
            }
            mdi.openConnection();
            result = mdi.execPrepQueryInListStringArrWithKVP(queryToGetAccidentsOfUser, param);
            mdi.closeConnection();
            return result;
        }
        #endregion
    }
}
