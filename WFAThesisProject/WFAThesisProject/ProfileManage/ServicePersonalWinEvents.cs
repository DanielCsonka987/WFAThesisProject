using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public partial class ServicePersonalWinController
    {
        /// <summary>
        /// process of switching back to normal view, canceling the Password changing or Details
        /// </summary>
        public void setTheNormalViewOfWindow()
        {
            modeOfPersonalWindow = personalManageMode.VIEW;
            intitializeFields();
            loadAllDatasIn();
        }

        /// <summary>
        /// defines of process to create the persHealthPDF creation
        /// </summary>
        public void collectsDatasAndCreatesHealthDetailsPDF()
        {
            servicePersProfileManage = new PersonalProfileManageControl(dbci, personalWin);
            servicePersProfileManage.createHealthCarePDF(usod);
        }

        #region personal-detailsEvents

        /// <summary>
        /// adjust the field activity in case of personal details changing
        /// </summary>
        public void opensFieldsToChangePersDetails()
        {
            modeOfPersonalWindow = personalManageMode.CHANGEDETAILS;
            intitializeFields();
        }
        /// <summary>
        /// tests the validity of the taj-number
        /// </summary>
        /// <returns></returns>
        public bool analyzeTajInDetails()
        {
            if (txtbTaj.Text.Length != 11)
                return false;
            else if (txtbTaj.Text.Substring(3, 1) != "-" && txtbTaj.Text.Substring(7, 1) != "-")
                return false;
            else if (int.TryParse(txtbTaj.Text.Substring(0, 3), out int result1) &&     //0,1,2 - 
                    int.TryParse(txtbTaj.Text.Substring(4, 3), out int result2) &&      //4,5,6 -
                    int.TryParse(txtbTaj.Text.Substring(8, 3), out int result3))        //8,9,10
                return true;
            else
                return false;
        }
        /// <summary>
        /// process of savint into DB the changed user personal details - if it is correct
        /// </summary>
        public void savesTheNewPersDetails()
        {
            servicePersProfileManage = new PersonalProfileManageControl(dbci, personalWin);
            servicePersProfileManage.changeUserDetails(usod.userId, txtbLaName.Text, txtbFiName.Text, txtbTaj.Text);
        }
        #endregion

        #region passwordEvents
        /// <summary>
        /// adjust the field activity in case of password changing
        /// </summary>
        public void opensFieldsToChangePwd()
        {
            modeOfPersonalWindow = personalManageMode.CHANGEPWD;
            intitializeFields();
        }
        /// <summary>
        /// process of saving into DB the changed password - if it is correct
        /// </summary>
        public void saveTheNewPwd()
        {
            servicePersProfileManage = new PersonalProfileManageControl(dbci, personalWin);
            servicePersProfileManage.changeUserPwd(usod.userId, txtbPwdNew.Text);
        }
        /// <summary>
        /// analyze the written password difficulty
        /// </summary>
        /// <returns>true = good / false = problematic</returns>
        public bool analyzePassword()
        {
            try
            {
                controlAnalizePwdContent = new AnalyzePassword(txtbPwdNew.Text);
                return true;
            }
            catch (ErrorLogPassContent e)
            {
                return false;
            }
        }
        #endregion
    }
}
