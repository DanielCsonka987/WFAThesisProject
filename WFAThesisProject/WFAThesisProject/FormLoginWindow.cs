using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAThesisProject
{
    public partial class FormLoginWindow : MetroFramework.Forms.MetroForm
    {
        private LogInController loginController;

        public FormLoginWindow()
        {
            InitializeComponent();
            loginController = new LogInController(this);
        }
        /// <summary>
        /// event of the loging in by click of mTile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileLogin_Click(object sender, EventArgs e)
        {
            attepmtTheLogingIn();

        }

        /// <summary>
        /// event of the exit from the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// event of the changeing the connection datas to the database and others
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTxtBxAccName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.H)
            {
                loginController.startManageConnDetails();
            }
            if (e.KeyCode == Keys.Enter)
            {
                attepmtTheLogingIn();
            }
        }
        /// <summary>
        /// event of the password textarea, instant start to loging in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTxtBxAccPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                attepmtTheLogingIn();
            }
        }

        /// <summary>
        /// at arriving back it removes the typed in text from textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLoginWindow_VisibleChanged(object sender, EventArgs e)
        {
            mTxtBxAccName.Text = "";
            mTxtBxAccPwd.Text = "";
        }

        private void errorProviderControl(Control element, string message)
        {
            errorProviderLogin.SetError(element, message);
        }

        private void attepmtTheLogingIn()
        {
            errorProviderLogin.Clear();
            if (loginController.isThereConecctionDetails())
            {
                if (loginController.posiblyGoodUsernamePwdPair())
                    loginController.haveTryToLogingIn();
                else
                    errorProviderControl(loginController.getTheProblTxtB(), loginController.getTheProblem());
            }
        }
    }
}
