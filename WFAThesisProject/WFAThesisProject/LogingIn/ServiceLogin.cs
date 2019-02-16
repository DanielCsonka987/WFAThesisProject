using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using WFAThesisProject.UserNamePasswordManage;
using WFAThesisProject.UserRightsManage;

namespace WFAThesisProject.LogingIn
{
    class ServiceLogin
    {
        private ServiceLoginModel modelLogin;
        private AnalyzeUsername analyzeUsName;
        private AnalyzePassword analyzeUsPassw;
        private TreeTenConverter userRightInterpreter;
        private SetOfUserRights userRights;
        private SetOfUserDetails userDetails;
        private string userName;

        public ServiceLogin(Form parent, UserConnDetails conDetails)
        {
            modelLogin = new ServiceLoginModel(parent, conDetails);
        }
        public void reviseTheAutenticityOfUserNPwd(string givenName, string givenPwd)
        {
            analyzeUsName = new AnalyzeUsername(givenName);
            analyzeUsPassw = new AnalyzePassword(givenPwd);
        }

        /// <summary>
        /// it adjusts the given login datas by the user
        /// manages the pre-revision than the process of DB revision of loging in datas
        /// </summary>
        /// <param name="parent">the logging in window</param>
        /// <param name="givenName">given name form mtextbox</param>
        /// <param name="givenPwd">given password from mtextbox</param>
        public bool authenticByDBIsGood(string givenName, string givenPwd)
        {
            string hashPwd = "";
            try
            {
                hashPwd = modelLogin.checkDBForThisUser(givenName);
            }
            catch (ErrorServiceLoginDBAccess e)
            {
                throw new ErrorServiceLoginAuthentic(e.Message);
            }
            if (hashPwd != null || hashPwd == "")
            {
                if (BCrypt.Net.BCrypt.Verify(givenPwd, hashPwd))
                {
                    modelLogin.collectDatasOfVerifiedUser();
                    userName = givenName;
                    return true;
                }
                else
                {
                    throw new ErrorServiceLoginAuthentic("Az azonosítás sikertelen (ServLoginPwd)");
                }
            }
            else
            {
                throw new ErrorServiceLoginAuthentic("Az adatbázis elérése sikertelen (ServLoginPwd)");
            }
        }
        /// <summary>
        /// adjust the rights of the loged-in-user
        /// </summary>
        /// <returns>the set of rights in the program</returns>
        public SetOfUserRights getTheUserRightsFromDB()
        {
            try
            {
                userRightInterpreter = new TreeTenConverter(modelLogin.getTheRightValue(), true);
                userRights = new SetOfUserRights(userRightInterpreter.rightsNumberInThree);
            }
            catch (ErrorUserRightLength)
            {
                throw new ErrorServiceLoginInfoCollect("Felhasználói jogok gyűjtése sikertelen (ServLoginRig)");
            }
            catch (ErrorUserRightFormat)
            {
                throw new ErrorServiceLoginInfoCollect("Felhasználói jogok gyűjtése sikertelen (ServLoginRig)");
            }
            catch (Exception e)
            {
                throw new ErrorServiceLoginInfoCollect("Ismeretlen probléma lépett fel (ServLoginRig) "
                    + e.Message);
            }
            return userRights;
        }
        /// <summary>
        /// adjust the details of the loged-in-user
        /// </summary>
        /// <returns>the set of details in the program</returns>
        public SetOfUserDetails getTheUserDetailsFromDB()
        {
            userDetails = new SetOfUserDetails();
            string[] userDatas = modelLogin.getUserDetails();
            try
            {
                userDetails.userId = userDatas[0];
                userDetails.userName = userName;
                userDetails.userLastName = userDatas[1];
                userDetails.userFirstName = userDatas[2];
                userDetails.userTaj = userDatas[3];
                userDetails.userPosition = userDatas[4];
                userDetails.userArea = userDatas[5];
                userDetails.userAccountGroup = userDatas[6];
                userDetails.completlynessSeek();
            }
            catch (ErrorUserDetailsCompletlyness)
            {
                throw new ErrorServiceLoginInfoCollect("Felhasználói adatok gyűjtése sikertelen (ServLoginData)");
            }
            catch (Exception e)
            {
                throw new ErrorServiceLoginInfoCollect("Ismeretlen probléma lépett fel (ServLoginData) "
                    +e.Message);
            }
            return userDetails;
        }
    }
}
