using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.ServProfileManage;
using WFAThesisProject.UserNamePasswordManage;
using WFAThesisProject.UserRightsManage;

namespace WFAThesisProject
{
    public partial class ServiceProfileWinController
    {
        private enum profileManageMode { VIEW, ChangePWD, BackChangePWD, ChangeDETAILS, BackChangeDETAILS }
        private profileManageMode modeOfProfileWindow;
        private UserConnDetails dbci;
        private SetOfUserDetails usod;
        private Form personalWin;

        private ServiceProfileManage servicePersProfileManage;
        private AnalyzePassword controlAnalizePwdContent;

        private MetroFramework.Controls.MetroTextBox txtbLaName;
        private MetroFramework.Controls.MetroTextBox txtbFiName;
        private MetroFramework.Controls.MetroTextBox txtbTaj;
        private MetroFramework.Controls.MetroTextBox txtbOldPwd;
        private MetroFramework.Controls.MetroTextBox txtbPwdNew;
        private MetroFramework.Controls.MetroTextBox txtbPwdNewConf;
        private MetroFramework.Controls.MetroButton btnSaveData;
        private MetroFramework.Controls.MetroButton btnSavePwd;
        private MetroFramework.Controls.MetroButton btnCancelData;
        private MetroFramework.Controls.MetroButton btnCancelPwd;

        private Control labelInfo;

        private MetroFramework.Controls.MetroTextBox txtbUserName;
        private MetroFramework.Controls.MetroTextBox txtbArea;
        private MetroFramework.Controls.MetroTextBox txtbPosition;
        private MetroFramework.Controls.MetroTextBox txtbUserGroup;
        /// <summary>
        /// constructor of the profile manager wiondow - only, that instatntiate its servise itself!
        /// </summary>
        /// <param name="usod">personal details of the user</param>
        /// <param name="dbci">DB connection informations</param>
        /// <param name="personalWin">the address of the profile manager window</param>
        public ServiceProfileWinController(SetOfUserDetails usod, UserConnDetails dbci, Form personalWin)
        {
            this.personalWin = personalWin;
            this.usod = usod;
            this.dbci = dbci;
            catchWindowcontrols();
            setTheNormalViewOfWindow();
        }
        /// <summary>
        /// catches the controls on the profile mangment wiondow
        /// </summary>
        private void catchWindowcontrols()
        {
            txtbLaName = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxLastName", true).First();
            txtbFiName = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxFirstName", true).First();
            txtbTaj = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxTaj", true).First();
            btnSaveData = (MetroFramework.Controls.MetroButton)personalWin.Controls.Find("mBtnSaveDatas", true).First();
            btnCancelData = (MetroFramework.Controls.MetroButton) personalWin.Controls.Find("mBtnCancelDet", true).First();

            txtbOldPwd = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxPwdOld", true).First();
            txtbPwdNew = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxPwdNew", true).First();
            txtbPwdNewConf = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxPwdNewConf", true).First();
            btnSavePwd = (MetroFramework.Controls.MetroButton) personalWin.Controls.Find("mBtnSaveNewPwd", true).First();
            btnCancelPwd = (MetroFramework.Controls.MetroButton)personalWin.Controls.Find("mBtnCancelPwd", true).First();

            txtbUserName = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxUserName", true).First();
            txtbUserGroup = (MetroFramework.Controls.MetroTextBox)personalWin.Controls.Find("mTxtBxUserGroup", true).First();
            txtbPosition = (MetroFramework.Controls.MetroTextBox)personalWin.Controls.Find("mTxtBxPosition", true).First();
            txtbArea = (MetroFramework.Controls.MetroTextBox)personalWin.Controls.Find("mTxtBxWorkArea", true).First();

            labelInfo = (MetroFramework.Controls.MetroLabel) personalWin.Controls.Find("mLabelInfo", true).First();
        }

    }
}
