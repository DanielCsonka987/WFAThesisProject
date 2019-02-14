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
        private FormAdjustConnection ajdustDBconn;

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
                errorMessage = euf.Message;
                elementWithProblem = txtbName;
                return false;
            }
            catch (ErrorLogPassContent epc)
            {
                errorMessage = epc.Message;
                elementWithProblem = txtbPwd;
                return false;
            }
        }

        /// <summary>
        /// process of logging in
        /// </summary>
        public void haveTryToLogingIn()
        {
            if (isThereConecctionDetails())     //again in the row - if the user wanted to avoid the filling in the form
            {
                if (serviceLogin.authenticByDBIsGood(txtbName.Text, txtbPwd.Text))
                {
                    FormMainWindow fmw = new FormMainWindow(parentLoginWindow, serviceLogin.getTheUserRightsFromDB(),
                        serviceLogin.getTheUserDetailsFromDB(), dbci);
                    fmw.Show();
                    parentLoginWindow.Visible = false;
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(parentLoginWindow, "Ilyen felhasználó nem található meg az adatbázisban",
                        "Probléma az azonosításnál", MessageBoxButtons.OK, MessageBoxIcon.Warning, 150);
                }
            }
        }

        /// <summary>
        /// process of adjusting the DB connection datas, opens a new window
        /// if if gives false - the user need to reattempt the loging in
        /// </summary>
        public bool isThereConecctionDetails()
        {
            if (dbInfosContoller.initialDBConnectInfo(dbci))
            {
                DialogResult opinion = MetroFramework.MetroMessageBox.Show(parentLoginWindow,
                        "Nincs információ az adatbázishoz kapcsolódához, " +
                    "kérem állítsa be ezeket", "Probléma az adatbázishoz kapcsolódásnál",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error, 150);
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

        public void startManageConnDetails()
        {
            ajdustDBconn = new FormAdjustConnection(dbci, parentLoginWindow);
            if (ajdustDBconn.ShowDialog() == DialogResult.OK)
            {
                dbci = dbInfosContoller.getTheConnInfos();
            }
        }

        public Control getTheProblTxtB()
        {
            return elementWithProblem;
        }

        public string getTheProblem()
        {
            return errorMessage;
        }
    }
}
