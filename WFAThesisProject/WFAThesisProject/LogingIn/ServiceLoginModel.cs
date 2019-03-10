using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace WFAThesisProject.LogingIn
{
    class ServiceLoginModel
    {
        private UserConnDetails dbci;
        private InterfaceMySQLStartDBConnect startDBconnect;
        private InterfaceMySQLDBChannel mdi;
        private List<KeyValuePair<string, string>> paramOfQuery;
        private KeyValuePair<string, string> param;
        private Form parent;
        private string userId;
        private string hashedPwd;
        private string rightFromDB;
        private string[] userDatas;
        /// <summary>
        /// constructor of the LoginModel layer, gets the DB access infos
        /// </summary>
        /// <param name="dbci"></param>
        public ServiceLoginModel(Form parent, UserConnDetails dbci)
        {
            this.parent = parent;
            this.dbci = dbci;
            startDBconnect = new InterfaceMySQLStartDBConnect();
            mdi = startDBconnect.kapcsolodas(dbci, parent);
        }
        private string queryOfUserIdentify = "SELECT user_id, jelszo FROM felhaszn WHERE user_name=@userName";
        /// <summary>
        /// start to indentify the user - must be the first query step
        /// </summary>
        /// <param name="parent">LoginWindow</param>
        /// <param name="userName">given name by user</param>
        /// <param name="userPwd">given password by user</param>
        /// <returns></returns>
        public string checkDBForThisUser(string userName)
        {
            try
            {
                param = new KeyValuePair<string, string>("@userName", userName);
            }
            catch (Exception e)
            {
                throw new ErrorServiceLoginDBAccess("A lekérdezés összeállítása sikertelen (ModLoginUserSeek) " + e.Message);
            }
            mdi.openConnection();
            List<string[]> resultIdentify = mdi.execPrepQueryInListStringArrWithKVP(queryOfUserIdentify,param);
            mdi.closeConnection();
            if (resultIdentify.Count == 1)
            {
                userId = resultIdentify[0][0];
                return hashedPwd = resultIdentify[0][1];
            }
            else if (resultIdentify.Count == 0)
            {
                throw new ErrorServiceLoginDBAccess("Nem megfelelő felhasználónév vagy jelszó");
            }
            else
            {
                throw new ErrorServiceLoginDBAccess("Az adatbázis sérült, több találat is érkezett (ModLoginUserSeek)");
            }
        }
        private string queryOfRights = "SELECT jog FROM jogosultsag WHERE jog_id = " +
            "(SELECT jog_id FROM felhasznadatok WHERE user_id=@userID);";
        private string queryOfUserPersonalDet = 
            "SELECT user_id, vez_nev, ker_nev, taj_szam, beosztas, terulet, jog_id FROM felhasznadatok" +
            " WHERE user_id=@userID";
        /// <summary>
        /// process of collect user personal details and rights of its group
        /// </summary>
        public void collectDatasOfVerifiedUser()
        {
            try
            {
                param = new KeyValuePair<string, string>("@userID", userId);
            }
            catch (Exception e)
            {
                throw new ErrorServiceLoginDBAccess("Lekérdezés összeállítási hiba (ModLoginUserDetSeek) " + e.Message);
            }
            mdi = startDBconnect.kapcsolodas(dbci, parent);
            mdi.openConnection();
            rightFromDB = mdi.execPrepScalarQueryInStringWithKVP(queryOfRights, param);
            userDatas = mdi.execPrepQueryOneRowInStringArrWithKVP(queryOfUserPersonalDet, param);
            mdi.closeConnection();
        }
        /// <summary>
        /// get the 'jog' field data from DB
        /// </summary>
        /// <returns>value in string of number from 0 to 59048 </returns>
        public string getTheRightValue()
        {
            return rightFromDB;
        }
        /// <summary>
        /// get the details of the user from 'felhasznadatok' table
        /// </summary>
        /// <returns>string array of personal details</returns>
        public string[] getUserDetails()
        {
            return userDatas;
        }

    }
}
