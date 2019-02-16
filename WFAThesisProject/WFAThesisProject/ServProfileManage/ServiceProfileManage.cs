using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.ProfileManage;
using WFAThesisProject.UserNamePasswordManage;

namespace WFAThesisProject
{
    public class ServiceProfileManage
    {
        private PersonalProfileModelDB modelOwnPersManage;
        private PersonalProfileModelPDFhc modelPDFPersonal;
        private UserConnDetails dbci;
        private List<string> chems;
        private List<string[]> accids;
        private Form parent;
        /// <summary>
        /// constructor of personal profile manager control
        /// </summary>
        /// <param name="dbci">the details of DB connections</param>
        /// <param name="parent">the window form</param>
        public ServiceProfileManage(UserConnDetails dbci,Form parent)
        {
            this.dbci = dbci;
            this.parent = parent;
        }

        //tested
        #region changes - tests pwd of user
        /// <summary>
        /// sets the changes in the 'felhaszn' table whith rhe changed password
        /// </summary>
        /// <param name="userId">DB identifier of the user</param>
        /// <param name="newPwdNormal">the new chosen password</param>
        public void changeUserPwd(string userId, string newPwdNormal)
        {
            try
            {
                modelOwnPersManage = new PersonalProfileModelDB(dbci, parent);
                modelOwnPersManage.setChangeTheUserPassword(userId, 
                    BCrypt.Net.BCrypt.HashPassword(newPwdNormal));
            }
            catch (ErrorServiceUpdateRecord e)
            {
                throw new ErrorServiceProfileMange(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceProfileMange("Ismeretlen eredetű hiba történt (ServProfDet-setNewPWd) "
                    + e.Message);
            }
        }
        /// <summary>
        /// gets the old pwd of the user to revise the written in one - autentification
        /// </summary>
        /// <param name="userId">DB identifier of the logged in user</param>
        /// <returns></returns>
        public string getTheOldPwdInHasString(string userId)
        {
            try
            {
                modelOwnPersManage = new PersonalProfileModelDB(dbci, parent);
                return modelOwnPersManage.reviseOldPwdVailidity(userId);
            }
            catch (ErrorServiceProfileReviseOldPwd e)
            {
                throw new ErrorServiceProfileMange(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceProfileMange("Ismeretlen eredetű hiba történt (ServProfDet-revOldPWd) "
                    + e.Message);
            }
        }
        #endregion
        //tested
        #region changes the user personal details
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
                modelOwnPersManage = new PersonalProfileModelDB(dbci, parent);
                modelOwnPersManage.setChangesOfUserPersDatas(userId, lastName, firstName, tajNumber);
            }
            catch (ErrorServiceUpdateRecord e)
            {
                throw new ErrorServiceProfileMange(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceProfileMange("Ismeretlen eredetű hiba történt (ServProfDet-setDetChanges) "
                    + e.Message);
            }
        }

        /// <summary>
        /// gets the new full-name and taj after changed details
        /// </summary>
        /// <param name="userId">DB identifier of the user</param>
        /// <returns>the username of the user</returns>
        public string[] getTheNewNameAndTaj(string userId)
        {
            string[] result = null;
            try
            {
                modelOwnPersManage = new PersonalProfileModelDB(dbci, parent);
                result = modelOwnPersManage.getNameAndTajOfUser(userId);
            }
            catch (ErrorServiceProfileDetailsManage e)
            {
                throw new ErrorServiceProfileMange(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceProfileMange("Ismeretlen eredetű hiba történt (ServProfDet-getNameTaj) "
                    + e.Message);
            }
            return result;
        }


        #endregion

        #region pdf manage method
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
                modelOwnPersManage = new PersonalProfileModelDB(dbci, parent);
                chems = modelOwnPersManage.getUserConnectedChemThreats(userDet.userArea);
                accids = modelOwnPersManage.getUserConnectedAccidents(userDet.userId);
            }
            catch(ErrorServiceProfileDetailsManage e)
            {
                throw new ErrorServiceProfileMange(e.Message);
            }
            try
            {
                modelPDFPersonal = new PersonalProfileModelPDFhc(userDet, dbci.output, chems, accids);
            }
            catch (ErrorMigraDocFileCreation e)
            {
                throw new ErrorServiceProfileMange(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceProfileMange("Ismeretlen eredetű hiba történt (ServProfDet-PDFcreate) "
                    + e.Message);
            }
        }

        #endregion
    }
}
