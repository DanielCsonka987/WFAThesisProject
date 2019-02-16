using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.LogingIn;
using WFAThesisProject.UserNamePasswordManage;

namespace WFAThesisProject
{
    public class LogInController
    {
        private ServiceLogin serviceLogin;
        private Form parentLoginWindow;
        private ManageIOConnFileController dbInfosContoller;
        private UserConnDetails dbci;
        private FormAdjustConnectionWindow ajdustDBconn;

        private Control elementWithProblem;
        private string errorMessage;

        private MetroFramework.Controls.MetroTextBox txtbName;
        private MetroFramework.Controls.MetroTextBox txtbPwd;

        public LogInController(Form loginWin)
        {
            this.parentLoginWindow = loginWin;
            dbInfosContoller = new ManageIOConnFileController(parentLoginWindow);
            dbci = dbInfosContoller.getTheConnInfos();
            catchTheControls();
        }
        /// <summary>
        /// finds the textboxes on LoginWindow to manage their content
        /// </summary>
        private void catchTheControls()
        {
            txtbName = (MetroFramework.Controls.MetroTextBox) parentLoginWindow.Controls.Find("mTxtBxAccName", true).First();
            txtbPwd = (MetroFramework.Controls.MetroTextBox) parentLoginWindow.Controls.Find("mTxtBxAccPwd", true).First();
        }

        #region pre-revision of username and pwd
        /// <summary>
        /// pre-revison of the username and password - connected with the errorporvider
        /// </summary>
        /// <returns>true = good / false = not acceptable</returns>
        public bool posiblyGoodUsernamePwdPair()
        {
            serviceLogin = new ServiceLogin(parentLoginWindow, dbci);
            try
            {
                serviceLogin.reviseTheAutenticityOfUserNPwd(txtbName.Text, txtbPwd.Text);
                return true;
            }
            catch (ErrorLogUsernameFormat euf)
            {
                errorMessage = "Nem megfelelő felhasználónév vagy jelszó";
                elementWithProblem = txtbName;
                return false;
            }
            catch (ErrorLogPassContent epc)
            {
                errorMessage = "Nem megfelelő felhasználónév vagy jelszó";
                elementWithProblem = txtbName;
                return false;
            }
        }
        /// <summary>
        /// servs the errorpoviding - target
        /// </summary>
        /// <returns>target element on Form</returns>
        public Control getTheProblTxtB()
        {
            return elementWithProblem;
        }
        /// <summary>
        /// servs the errorpoviding - message
        /// </summary>
        /// <returns></returns>
        public string getTheProblem()
        {
            return errorMessage;
        }
        #endregion

        #region attempt the real logging in - DB authentification
        /// <summary>
        /// process of logging in
        /// </summary>
        public void haveTryToLogingIn()
        {
            if (isThereConecctionDetails())     //again in the row - if the user wanted to avoid the filling in the form
            {
                try
                {
                    if (serviceLogin.authenticByDBIsGood(txtbName.Text, txtbPwd.Text))
                    {
                        try
                        {
                            FormMainWindow fmw = new FormMainWindow(parentLoginWindow, serviceLogin.getTheUserRightsFromDB(),
                                serviceLogin.getTheUserDetailsFromDB(), dbci);
                            fmw.Show();
                            parentLoginWindow.Visible = false;
                        }
                        catch (ErrorServiceLoginInfoCollect e)
                        {
                            errorHandleError(e.Message);
                        }
                    }
                }
                catch (ErrorServiceLoginAuthentic e)
                {
                    errorHandleWarn(e.Message);
                }
                catch (Exception e)
                {
                    errorHandleError(e.Message);
                }
            }
        }
        #endregion

        /// <summary>
        /// maintain to show the errors - case of problem of details collecting
        /// </summary>
        /// <param name="message"></param>
        private void errorHandleError(string message)
        {
            MetroFramework.MetroMessageBox.Show(parentLoginWindow, message,
                "Probléma az azonosításnál", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
        }
        /// <summary>
        /// maintaion to show the warnings - case of DB access, authentific problems
        /// </summary>
        /// <param name="message"></param>
        private void errorHandleWarn(string message)
        {
            MetroFramework.MetroMessageBox.Show(parentLoginWindow, message,
                "Probléma az azonosításnál", MessageBoxButtons.OK, MessageBoxIcon.Error, 150);
        }

        #region revise the existance of DB connect information - handle the collection with user
        /// <summary>
        /// process of adjusting the DB connection datas, opens a new window
        /// if if gives false - the user need to reattempt the loging in
        /// </summary>
        /// <returns>true = there are conn infos / false = needed those, no login</returns>
        public bool isThereConecctionDetails()
        {
            if (dbInfosContoller.initialDBConnectInfo(dbci))
            {
                DialogResult opinion = MetroFramework.MetroMessageBox.Show(parentLoginWindow,
                        "Nincs információ az adatbázishoz kapcsolódához, " +
                    "kérem állítsa be ezeket", "Probléma az adatbázishoz kapcsolódásnál",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Stop, 150);
                if (opinion == DialogResult.Yes)
                {
                    startManageConnDetails();
                    return true;
                }
                else
                    return false;
            }
            return true;
        }
        /// <summary>
        /// defines the process, when the DB connection window is needed
        /// </summary>
        public void startManageConnDetails()
        {
            ajdustDBconn = new FormAdjustConnectionWindow(dbci, parentLoginWindow);
            if (ajdustDBconn.ShowDialog() == DialogResult.OK)
            {
                dbci = dbInfosContoller.getTheConnInfos();
            }
        }
        #endregion
    }
}
