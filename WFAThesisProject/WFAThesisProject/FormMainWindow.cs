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
using MetroFramework.Controls;

namespace WFAThesisProject
{
    public partial class FormMainWindow : MetroFramework.Forms.MetroForm
    {
        private SetOfUserRights setOfUserRights;
        private SetOfUserDetails setOfUserDetails;
        private Form parentLogInWindow;
        private UserConnDetails dbci;

        private MainController controller;

        private FormServicePersonalWindow userOwnDetailsManage;

        private FormServiceRightsWindow rightsManageWindow;
        
        /// <summary>
        /// constructor of MainFormWindow
        /// </summary>
        /// <param name="parentLogin">loginFormWindow itself</param>
        /// <param name="userRights">rights of logged in user</param>
        /// <param name="userDetails">personal details of loggen in user</param>
        /// <param name="dbci">connection informations</param>
        public FormMainWindow(Form parentLogin, SetOfUserRights userRights, SetOfUserDetails userDetails,
            UserConnDetails dbci)
        {
            InitializeComponent();
            this.parentLogInWindow = parentLogin;
            this.setOfUserDetails = userDetails;
            this.dbci = dbci;
            controller = new MainController(userDetails, userRights, this, dbci);
            mTileUserOwnDetail.Text = "Üdvözüljük " + userDetails.userLastName + " " +
                    userDetails.userFirstName + " Bejelentkezve mint " + userDetails.userAccountGroup;
        }
        /// <summary>
        /// it calls back the loginFormWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentLogInWindow.Show();
        }

        /// <summary>
        /// event of the user-Own-details managing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileUserOwnDetail_Click(object sender, EventArgs e)
        {
            //another window appears
            userOwnDetailsManage = new FormServicePersonalWindow(setOfUserDetails, dbci, this);
            userOwnDetailsManage.Show();
            this.Visible = false;
        }
    }

    /// <summary>
    /// sub-tiles are co-used by the sub-commands
    /// for deciding in the sub-command events, which controller needs to run
    /// </summary>
    public enum FormMainServiceMode { OPENING, USERSMAN, RIGHTSMAN, ACCIDENTSMAN,
        PRODUCTSMANStripAct, PRODUCTSMANStripHis, PRODUCTSMANQualiAct, PRODUCTSMANQualiHis,
        REQUESTSMAN, ORDERINGMAN, SUBCONTRACTORSMAN }
}
