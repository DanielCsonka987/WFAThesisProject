using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAThesisProject
{
    public class PersonalProfileManageControl
    {
        private PersonalProfileManageModel modelOwnPersManage;
        private PersonalProfilePDFHealthCareModel modelPDFPersonal;
        private UserConnDetails dbci;
        private List<string> chems;
        private List<string[]> accids;
        private Form parent;
        /// <summary>
        /// constructor of personal profile manager control
        /// </summary>
        /// <param name="dbci">the details of DB connections</param>
        /// <param name="parent">the window form</param>
        public PersonalProfileManageControl(UserConnDetails dbci,Form parent)
        {
            this.dbci = dbci;
            this.parent = parent;
        }
        /// <summary>
        /// gets the login-username of the user
        /// </summary>
        /// <param name="userId">DB identifier of the user</param>
        /// <returns>the username of the user</returns>
        public string getUserName(string userId)
        {
            string result = "";
            try
            {
                modelOwnPersManage = new PersonalProfileManageModel(dbci, parent);
                result = modelOwnPersManage.getUserName(userId);
            }
            catch (ErrorPersonalDetailsManage e)
            {
                handleError(e.Message);
            }
            catch (Exception e)
            {
                handleError("Ismeretlen eredetű hiba történt (ContrPersDet-getUserName) " + e.Message);
            }
            return result;
        }
        /// <summary>
        /// sets the changes in the 'felhaszn' table whith rhe changed password
        /// </summary>
        /// <param name="userId">DB identifier of the user</param>
        /// <param name="newPwdNorm">the new chosen password</param>
        public void changeUserPwd(string userId, string newPwdNorm)
        {
            try
            {
                string newPwdHashed = BCrypt.Net.BCrypt.HashPassword(newPwdNorm);
                modelOwnPersManage = new PersonalProfileManageModel(dbci, parent);
                modelOwnPersManage.setChangeTheUserPassword(userId, newPwdHashed);
            }
            catch (ErrorServiceUpdateRecord e)
            {
                handleError(e.Message);
            }
            catch (Exception e)
            {
                handleError("Ismeretlen eredetű hiba történt (ContrPersDet-setNewPWd) " + e.Message);
            }
        }
        /// <summary>
        /// sets the changes in the 'felhasznadatok' table about the user personal details
        /// </summary>
        /// <param name="userId">DB identifier of the user</param>
        /// <param name="lastName">(pos. new) last name of the user</param>
        /// <param name="firstName">(pos. new) first name of the user</param>
        /// <param name="tajNumber">(pos. new) taj-number of the user</param>
        public void changeUserDetails(string userId, string lastName, string firstName, string tajNumber)
        {
            try
            {
                modelOwnPersManage = new PersonalProfileManageModel(dbci, parent);
                modelOwnPersManage.setChangesOfUserPersDatas(userId, lastName, firstName, tajNumber);
            }
            catch (ErrorServiceUpdateRecord e)
            {
                handleError(e.Message);
            }
            catch (Exception e)
            {
                handleError("Ismeretlen eredetű hiba történt (ContrPersDet-setDetChanges) " + e.Message);
            }
        }
        /// <summary>
        /// makes the creation of the PDF of the user about the medical threats
        /// </summary>
        /// <param name="userDet">user information, stored by the perogram</param>
        /// <param name="userId">DB identifier of the user</param>
        /// <param name="outputPath">the output path, to create the PDF</param>
        public void createHealthCarePDF(SetOfUserDetails userDet)
        {
            try
            {
                modelOwnPersManage = new PersonalProfileManageModel(dbci, parent);
                chems = modelOwnPersManage.getUserConnectedChemThreats(userDet.userArea);
                accids = modelOwnPersManage.getUserConnectedAccidents(userDet.userId);
            }
            catch(ErrorPersonalDetailsManage e)
            {
                handleError(e.Message);
            }
            try
            {
                modelPDFPersonal = new PersonalProfilePDFHealthCareModel(userDet, dbci.output, chems, accids);
            }
            catch (ErrorMigraDocFileCreation e)
            {
                handleError(e.Message);
            }
            catch (Exception e)
            {
                handleError("Ismeretlen eredetű hiba történt (ContrPersDet-PDFcreate) " + e.Message);
            }
        }


        /// <summary>
        /// general errorhandle
        /// </summary>
        /// <param name="message">the message of the exception</param>
        private void handleError(string message)
        {
            MetroFramework.MetroMessageBox.Show(parent, message, "Figyelmeztetés", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning,  200);
        }
    }
}
