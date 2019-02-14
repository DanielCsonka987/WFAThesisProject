using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAThesisProject
{
    public partial class ServicePersonalWinController
    {
        private enum personalManageMode { VIEW, CHANGEPWD, CHANGEDETAILS }
        private personalManageMode modeOfPersonalWindow;
        private UserConnDetails dbci;
        private SetOfUserDetails usod;
        private Form personalWin;

        private PersonalProfileManageControl servicePersProfileManage;
        private AnalyzePassword controlAnalizePwdContent;

        private MetroFramework.Controls.MetroTextBox txtbLaName;
        private MetroFramework.Controls.MetroTextBox txtbFiName;
        private MetroFramework.Controls.MetroTextBox txtbTaj;
        private MetroFramework.Controls.MetroTextBox txtbOldPwd;
        private MetroFramework.Controls.MetroTextBox txtbPwdNew;
        private MetroFramework.Controls.MetroTextBox txtbPwdNewConf;
        private MetroFramework.Controls.MetroButton btnSaveData;
        private MetroFramework.Controls.MetroButton btnSavePwd;

        private MetroFramework.Controls.MetroTextBox txtbUserName;
        private MetroFramework.Controls.MetroTextBox txtbArea;
        private MetroFramework.Controls.MetroTextBox txtbPosition;
        private MetroFramework.Controls.MetroTextBox txtbUserGroup;

        public ServicePersonalWinController(SetOfUserDetails usod, UserConnDetails dbci, Form personalWin)
        {
            this.personalWin = personalWin;
            this.usod = usod;
            this.dbci = dbci;
            catchWindowcontrols();
            setTheNormalViewOfWindow();
        }

        private void catchWindowcontrols()
        {
            txtbLaName = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxLastName", true).First();
            txtbFiName = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxFirstName", true).First();
            txtbTaj = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxTaj", true).First();
            btnSaveData = (MetroFramework.Controls.MetroButton)personalWin.Controls.Find("mBtnSaveDatas", true).First();

            txtbOldPwd = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxPwdOld", true).First();
            txtbPwdNew = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxPwdNew", true).First();
            txtbPwdNewConf = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxPwdNewConf", true).First();
            btnSavePwd = (MetroFramework.Controls.MetroButton) personalWin.Controls.Find("mBtnSaveNewPwd", true).First();

            txtbUserName = (MetroFramework.Controls.MetroTextBox) personalWin.Controls.Find("mTxtBxUserName", true).First();
            txtbUserGroup = (MetroFramework.Controls.MetroTextBox)personalWin.Controls.Find("mTxtBxUserGroup", true).First();
            txtbPosition = (MetroFramework.Controls.MetroTextBox)personalWin.Controls.Find("mTxtBxPosition", true).First();
            txtbArea = (MetroFramework.Controls.MetroTextBox)personalWin.Controls.Find("mTxtBxWorkArea", true).First();

        }

        /// <summary>
        /// adjust the three condition of this window
        /// </summary>
        private void intitializeFields()
        {
            if (modeOfPersonalWindow == personalManageMode.VIEW)
            {
                txtbLaName.ReadOnly = true;
                txtbFiName.ReadOnly = true;
                txtbTaj.ReadOnly = true;
                btnSaveData.Visible = false;

                txtbOldPwd.Enabled = false;
                txtbPwdNew.Enabled = false;
                txtbPwdNewConf.Enabled = false;
                btnSavePwd.Visible = false;

                txtbUserName.ReadOnly = true;
                txtbUserGroup.ReadOnly = true;
                txtbPosition.ReadOnly = true;
                txtbArea.ReadOnly = true;
            }
            else if (modeOfPersonalWindow == personalManageMode.CHANGEDETAILS)
            {
                txtbLaName.ReadOnly = false;
                txtbFiName.ReadOnly = false;
                txtbTaj.ReadOnly = false;
                btnSaveData.Visible = true;
            }
            else if (modeOfPersonalWindow == personalManageMode.CHANGEPWD)
            {
                txtbOldPwd.Enabled = true;
                txtbPwdNew.Enabled = true;
                txtbPwdNewConf.Enabled = true;
                btnSavePwd.Visible = true;
            }
        }

        /// <summary>
        /// adjust the personal details in textboxes to see the user all of them
        /// </summary>
        private void loadAllDatasIn()
        {
            servicePersProfileManage = new PersonalProfileManageControl(dbci, personalWin);

            txtbLaName.Text = usod.userLastName;
            txtbFiName.Text = usod.userFirstName;
            txtbTaj.Text = usod.userTaj;

            txtbUserName.Text = servicePersProfileManage.getUserName(usod.userId);
            txtbUserGroup.Text = usod.userAccountGroup;
            txtbPosition.Text = usod.userPosition;
            txtbArea.Text = usod.userArea;
        }

    }
}
