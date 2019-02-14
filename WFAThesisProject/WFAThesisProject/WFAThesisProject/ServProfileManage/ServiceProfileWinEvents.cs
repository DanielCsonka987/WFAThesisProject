using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt;
using WFAThesisProject.ProfileManage;
using WFAThesisProject.UserNamePasswordManage;

namespace WFAThesisProject
{
    public partial class ServiceProfileWinController
    {
        /// <summary>
        /// process of switching back to normal view, canceling the Password changing or Details
        /// </summary>
        public void setTheNormalViewOfWindow()
        {
            modeOfProfileWindow = profileManageMode.VIEW;
            intitializeFields();
            loadAllDatasIn();
        }

        /// <summary>
        /// defines of process to create the persHealthPDF creation
        /// </summary>
        public void collectsDatasAndCreatesHealthDetailsPDF()
        {
            try
            {
                servicePersProfileManage = new ServiceProfileManage(dbci, personalWin);
                servicePersProfileManage.createHealthCarePDF(usod);
            }
            catch (ErrorServiceProfileMange e)
            {
                handleError(e.Message);
            }
        }

        #region personal-detailsEvents
        /// <summary>
        /// adjust the field activity in case of personal details changing
        /// </summary>
        public void opensFieldsToChangePersDetails()
        {
            modeOfProfileWindow = profileManageMode.ChangeDETAILS;
            intitializeFields();
        }

        private void closeFieldsAfterChangePersDetails()
        {
            modeOfProfileWindow = profileManageMode.BackChangeDETAILS;
            intitializeFields();
        }
        /// <summary>
        /// tests the validity of the taj-number
        /// </summary>
        /// <returns></returns>
        public bool needRewriteTaj()
        {
            if (txtbTaj.Text.Length != 11)
                return true;
            else if (txtbTaj.Text.Substring(3, 1) != "-" && txtbTaj.Text.Substring(7, 1) != "-")
                return true;
            else if (int.TryParse(txtbTaj.Text.Substring(0, 3), out int result1) &&     //0,1,2 - 
                    int.TryParse(txtbTaj.Text.Substring(4, 3), out int result2) &&      //4,5,6 -
                    int.TryParse(txtbTaj.Text.Substring(8, 3), out int result3))        //8,9,10
                return false;
            else
                return true;
        }
        /// <summary>
        /// process of savint into DB the changed user personal details - if it is correct
        /// </summary>
        public void savesTheNewPersDetails()
        {
            try
            {
                servicePersProfileManage = new ServiceProfileManage(dbci, personalWin);
                servicePersProfileManage.changeUserDetails(usod.userId, txtbLaName.Text, txtbFiName.Text, txtbTaj.Text);
                closeFieldsAfterChangePersDetails();
            }
            catch (ErrorServiceProfileMange e)
            {
                handleError(e.Message);
            }
        }
        #endregion

        #region passwordEvents
        /// <summary>
        /// adjust the field activity in case of password changing
        /// </summary>
        public void opensFieldsToChangePwd()
        {
            modeOfProfileWindow = profileManageMode.ChangePWD;
            intitializeFields();
        }

        private void closeFieldsAfterChangePwd()
        {
            modeOfProfileWindow = profileManageMode.BackChangePWD;
            intitializeFields();
        }

        /// <summary>
        /// tests the old written in password
        /// </summary>
        /// <returns>true = valid / false = not the goodone</returns>
        public bool theOldPassworsIsVaild()
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(    txtbOldPwd.Text, 
                    servicePersProfileManage.getTheOldPwdInHasString(usod.userId)   );
            }
            catch (ErrorServiceProfileMange e)
            {
                handleError(e.Message);
                return false;
            }
        }
        /// <summary>
        /// process of saving into DB the changed password - if it is correct hashing it
        /// </summary>
        public void saveTheNewPwd()
        {
            try
            {
                servicePersProfileManage = new ServiceProfileManage(dbci, personalWin);
                servicePersProfileManage.changeUserPwd( usod.userId, 
                   BCrypt.Net.BCrypt.HashPassword(txtbPwdNew.Text)      );
                closeFieldsAfterChangePwd();
            }
            catch (ErrorServiceProfileMange e)
            {
                handleError(e.Message);
            }
        }
        /// <summary>
        /// analyze the written password difficulty
        /// </summary>
        /// <returns>true = good / false = problematic</returns>
        public bool needRewisePasswordByUser()
        {
            try
            {
                controlAnalizePwdContent = new AnalyzePassword(txtbPwdNew.Text);
                return false;
            }
            catch (ErrorLogPassContent)
            {
                return true;
            }
            catch (Exception e)
            {
                handleError("Ismertlen hiba történt (ContrPersPwdAnaly) " + e.Message);
                return true;
            }
        }
        #endregion


        /// <summary>
        /// general errorhandle
        /// </summary>
        /// <param name="message">the message of the exception</param>
        private void handleError(string message)
        {
            MetroFramework.MetroMessageBox.Show(personalWin, message, "Figyelmeztetés",
                MessageBoxButtons.OK, MessageBoxIcon.Warning, 200);
        }
    }
}
