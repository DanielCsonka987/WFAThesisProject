using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace WFAThesisProject
{
    class FormLoginWindowModel
    {
        
        string queryOfUserIdentify = "SELECT user_id, jelszo FROM felhaszn WHERE user_name=@userName";
        string queryOfUserPersonalDet = "SELECT user_id, vez_nev, ker_nev, taj_szam, beosztas, terulet, jog_id  " +
            "FROM felhasznadatok WHERE user_id=@userID";
        string queryOfRights = "SELECT jog FROM jogosultsag WHERE jog_id = " +
            "(SELECT jog_id FROM felhasznadatok WHERE user_id=@userID);";

        private UserConnDetails dbci;
        private InterfaceMySQLStartDBConnect startDBconnect;
        private InterfaceMySQLDBChannel sqlDBInertfConnect;
        private List<KeyValuePair<string, string>> paramOfQuery;

        private Form parent;
        private string userId;
        private string hashedPwd;
        private string rightFromDB;
        private string[] userDatas;
        /// <summary>
        /// constructor of the LoginModel layer, gets the DB access infos
        /// </summary>
        /// <param name="dbci"></param>
        public FormLoginWindowModel(Form parent, UserConnDetails dbci)
        {
            this.parent = parent;
            this.dbci = dbci;
            startDBconnect = new InterfaceMySQLStartDBConnect();
        }
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
                sqlDBInertfConnect = startDBconnect.kapcsolodas(dbci, parent);
                sqlDBInertfConnect.openConnection();
                paramOfQuery = new List<KeyValuePair<string, string>>();
                paramOfQuery.Add(new KeyValuePair<string, string>("@userName", userName));
                List<string[]> resultIdentify =
                    sqlDBInertfConnect.execPrepQueryInListStringArrWithKVPList(queryOfUserIdentify, paramOfQuery, 1);
                sqlDBInertfConnect.closeConnection();
                if (resultIdentify.Count == 1)
                {
                    userId = resultIdentify[0][0];
                    return hashedPwd = resultIdentify[0][1];
                }
                else
                {
                    sqlDBInertfConnect.closeConnection();
                    return null;
                }
            }
            catch (ErrorDBMetroProblem)
            {
                return null;
            }
        }
        /// <summary>
        /// process of collect user personal details and rights of its group
        /// </summary>
        public void collectDatasOfVerifiedUser()
        {
            sqlDBInertfConnect = startDBconnect.kapcsolodas(dbci, parent);
            sqlDBInertfConnect.openConnection();
            paramOfQuery = new List<KeyValuePair<string, string>>();
            paramOfQuery.Add(new KeyValuePair<string, string>("@userID", userId));
            rightFromDB = sqlDBInertfConnect.execPrepScalarQueryInStringWithKVPList(queryOfRights, paramOfQuery,1);
            userDatas = sqlDBInertfConnect.execPrepQueryOneRowInStringArr(queryOfUserPersonalDet, paramOfQuery,1);
            sqlDBInertfConnect.closeConnection();
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
