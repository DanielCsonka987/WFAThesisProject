using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFAThesisProject.ProfileManage;

namespace WFAThesisProject
{
    public partial class ServiceProfileWinController
    {

        /// <summary>
        /// adjust the five condition of this window
        /// </summary>
        private void intitializeFields()
        {
            if (modeOfProfileWindow == profileManageMode.VIEW)  //normal case
            {
                setAllTextAreaReadOnly();
            }
            else if (modeOfProfileWindow == profileManageMode.ChangeDETAILS)
            {
                setDetailsElementReachable();
            }
            else if (modeOfProfileWindow == profileManageMode.BackChangeDETAILS)
            {
                endsDetailElementsReachable();
            }
            else if (modeOfProfileWindow == profileManageMode.ChangePWD)
            {
                setThePwdElementsReachable();
            }
            else if (modeOfProfileWindow == profileManageMode.BackChangePWD)
            {
                endsThePwdElementsReachable();
            }
        }
        #region view of fields in details
        /// <summary>
        /// adjust all input-field not writeable
        /// </summary>
        private void setAllTextAreaReadOnly()
        {
            txtbLaName.ReadOnly = true;
            txtbFiName.ReadOnly = true;
            txtbTaj.ReadOnly = true;
            btnSaveData.Visible = false;
            btnCancelData.Visible = false;

            txtbOldPwd.Enabled = false;
            txtbPwdNew.Visible = false;
            txtbPwdNewConf.Visible = false;
            btnSavePwd.Visible = false;
            btnCancelPwd.Visible = false;

            txtbUserName.ReadOnly = true;
            txtbUserGroup.ReadOnly = true;
            txtbPosition.ReadOnly = true;
            txtbArea.ReadOnly = true;
            labelInfo.Text = "";
        }
        /// <summary>
        /// adjust the input fields to user can change its person.details
        /// </summary>
        private void setDetailsElementReachable()
        {
            //switch on the pers-details areas
            txtbLaName.ReadOnly = false;
            txtbFiName.ReadOnly = false;
            txtbTaj.ReadOnly = false;
            btnSaveData.Visible = true;
            btnCancelData.Visible = true;
            labelInfo.Text = "";
            //empty the pwd areas
            txtbOldPwd.Text = "";
            txtbPwdNew.Text = "";
            txtbPwdNewConf.Text = "";
            //disable the pwd areas
            txtbOldPwd.Enabled = false;
            txtbPwdNew.Visible = false;
            txtbPwdNewConf.Visible = false;
            btnSavePwd.Visible = false;
            btnCancelPwd.Visible = false;
        }
        /// <summary>
        /// adjust the details-change end
        /// </summary>
        private void endsDetailElementsReachable()
        {
            //loads back the informations to be updated
            loadAllDatasIn();
            //switch on the pers-details areas
            txtbLaName.ReadOnly = false;
            txtbFiName.ReadOnly = false;
            txtbTaj.ReadOnly = false;
            btnSaveData.Visible = true;
            btnCancelData.Visible = true;

            labelInfo.Text = "A változások az újraindításnál lépnek érvénybe";
        }


        /// <summary>
        /// adjust pwd-change connected areas active
        /// </summary>
        private void setThePwdElementsReachable()
        {
            //disable the details change konfiguration
            txtbLaName.ReadOnly = true;
            txtbFiName.ReadOnly = true;
            txtbTaj.ReadOnly = true;
            btnSaveData.Visible = false;
            btnCancelData.Visible = false;
            //enable the pwd change konfiguration
            txtbOldPwd.Enabled = true;
            txtbPwdNew.Visible = true;
            txtbPwdNewConf.Visible = true;
            btnSavePwd.Visible = true;
            btnCancelPwd.Visible = true;
        }
        /// <summary>
        /// adjust the pwd-change end
        /// </summary>
        private void endsThePwdElementsReachable()
        {
            //empty the pwd areas
            txtbOldPwd.Text = "";
            txtbPwdNew.Text = "";
            txtbPwdNewConf.Text = "";
            //switch off the fields
            txtbOldPwd.Enabled = false;
            txtbPwdNew.Visible = false;
            txtbPwdNewConf.Visible = false;
            btnSavePwd.Visible = false;
            btnCancelPwd.Visible = false;

            labelInfo.Text = "A változások az újraindításnál lépnek érvénybe";
        }
        #endregion
        /// <summary>
        /// adjust the personal details in textboxes to see the user all of them
        /// after the change it can recollect the possibly changed details!!
        /// </summary>
        private void loadAllDatasIn()
        {
            try
            {
                servicePersProfileManage = new ServiceProfileManage(dbci, personalWin);

                if (modeOfProfileWindow == profileManageMode.BackChangeDETAILS)
                {
                    string[] newNameTaj = servicePersProfileManage.getTheNewNameAndTaj(usod.userId);
                    txtbLaName.Text = newNameTaj[0];
                    txtbFiName.Text = newNameTaj[1];
                    txtbTaj.Text = newNameTaj[2];
                }
                else
                {
                    txtbLaName.Text = usod.userLastName;
                    txtbFiName.Text = usod.userFirstName;
                    txtbTaj.Text = usod.userTaj;
                }


                txtbUserName.Text = usod.userName;
                txtbUserGroup.Text = usod.userAccountGroup;
                txtbPosition.Text = usod.userPosition;
                txtbArea.Text = usod.userArea;
            }
            catch (ErrorServiceProfileMange e)
            {
                handleError(e.Message);
            }
        }
    }
}
