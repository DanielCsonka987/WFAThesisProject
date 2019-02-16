using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.UserRightsManage
{
    public class ServiceRights
    {
        private List<SetOfUserRights> listOfRightGroups;
        private ServiceRightsModel modelRights;
        private UserConnDetails dbci;
        private TreeTenConverter conv;
        private Form parent;
        /// <summary>
        /// constructor of ServiceRightManagment
        /// </summary>
        /// <param name="dbci">DB conection informations</param>
        /// <param name="parent">parent window</param>
        public ServiceRights(UserConnDetails dbci, Form parent)
        {
            this.dbci = dbci;
            this.parent = parent;
            collectTheUserRightGroups();
        }
        //tested
        #region readIn userRightGroup
        /// <summary>
        /// collect the userRightGroups from DB - repostiory type - because spec. conversion is needed
        /// </summary>
        public void collectTheUserRightGroups()
        {
            List<string[]> rawRightDatasFromDB;
            try
            {
                modelRights = new ServiceRightsModel(dbci, parent);
                rawRightDatasFromDB = modelRights.collectTheUserRightGroups();
                listOfRightGroups = new List<SetOfUserRights>();
                foreach (string[] rec in rawRightDatasFromDB)
                {
                    conv = new TreeTenConverter(rec[1], true);
                    SetOfUserRights setRight = new SetOfUserRights(conv.rightsNumberInThree);
                    setRight.groupName = rec[0];
                    listOfRightGroups.Add(setRight);
                }
            }
            catch (ErrorServiceCreateDataList e)
            {
                throw new ErrorServiceRights(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRights("Hiba történt a jogok átalakításakor (ServReadRights) " + e.Message);
            }
        }

        /// <summary>
        /// get the list of userRightGroup names to show in combobox
        /// </summary>
        /// <returns>list of groupnames</returns>
        public List<string> getTheListOfUserGroups()
        {
            List<string> nameOfGroups = new List<string>();
            foreach (SetOfUserRights rec in listOfRightGroups) {
                nameOfGroups.Add(rec.groupName);
            }
            return nameOfGroups;
        }
        /// <summary>
        /// get the specific rightgroup parameters, chosen userRightGroup by user
        /// </summary>
        /// <param name="theSeekedUserGroup">name of the groupname to need show</param>
        /// <returns>userRight parameters, that chosen the user</returns>
        public SetOfUserRights getTheChosenGroupChategRights(string theSeekedUserGroup)
        {
            foreach(SetOfUserRights rec in listOfRightGroups)
            {
                if (rec.groupName == theSeekedUserGroup)
                    return rec;
            }
            return null;
        }
        #endregion
        //tested
        #region processes of set newUserRightGroup and modifyExisting one
        /// <summary>
        /// saves the new record
        /// </summary>
        /// <param name="newGroupName">name of the new userRightGroup</param>
        /// <param name="rightContent">userRights in 3NS</param>
        public void saveTheNewRightGroup(string newGroupName, string rightContent)
        {
            mediateTheProperMethodNewModify(true, newGroupName, rightContent);
        }
        /// <summary>
        /// saves the modifyed record
        /// </summary>
        /// <param name="rightContent">new rights in 3NS</param>
        public void saveTheModifiedRightGroup(string nameOfGroup, string rightContent)
        {
            mediateTheProperMethodNewModify(false, nameOfGroup, rightContent);
        }
        /// <summary>
        /// defines the process of case new and modify
        /// </summary>
        /// <param name="mode">true = new record setting / false = modify the old one</param>
        /// <param name="groupName">the groupname to define the record</param>
        /// <param name="rightContent">parameter of userRight of the group</param>
        private void mediateTheProperMethodNewModify(bool mode, string groupName, string rightContent)
        {
            int rightsIn10NS = 0;
            try
            {
                TreeTenConverter ttc = new TreeTenConverter(rightContent, false);
                rightsIn10NS = ttc.rightsNumberInTen;
                try
                {
                    modelRights = new ServiceRightsModel(dbci, parent);
                    if (mode)   //create new
                    {
                        modelRights.setNewOrModifyRecordOfRightGroup(groupName, rightsIn10NS.ToString(), mode);
                        SetOfUserRights newOne = new SetOfUserRights(rightContent);
                        newOne.groupName = groupName;
                        listOfRightGroups.Add(newOne);
                    }
                    else
                    {   //modofy
                        modelRights.setNewOrModifyRecordOfRightGroup(groupName, rightsIn10NS.ToString(), mode);
                        SetOfUserRights modifyList = new SetOfUserRights(rightContent);
                        modifyList.groupName = groupName;
                        listOfRightGroups[listOfRightGroups.FindIndex(ind => ind.groupName.Equals(groupName))] = modifyList;
                    }
                }
                catch (ErrorServiceUpdateRecord e)
                {
                    throw new ErrorServiceRights(e.Message);
                }
            }
            catch (ErrorUserRightFormat e)
            {
                throw new ErrorServiceRights(e.Message);

            }
            catch (ErrorUserRightLength e)
            {
                throw new ErrorServiceRights(e.Message);

            }
            catch (Exception e)
            {
                if (mode)
                    throw new ErrorServiceRights("Ismeretlen hiba történt (ServRights_New) " + e.Message);
                else
                    throw new ErrorServiceRights("Ismeretlen hiba történt (ServRights_Modif) " + e.Message);
            }
        }
        #endregion
        //tested
        #region processes of delete of userRightGroup
        /// <summary>
        /// revises the userRightGroup if it is in use
        /// </summary>
        /// <param name="nameOfTheGroup">the name of the specific group</param>
        /// <returns>true = in use / false = not in use</returns>
        public bool checkTheChosenGroupIsNotInUse(string nameOfTheGroup)
        {
            try
            {
                modelRights = new ServiceRightsModel(dbci, parent);
                if (modelRights.checkTheRecordInUse(nameOfTheGroup) == 0)
                    return false;
                else
                    return true;
            }
            catch (ErrorServiceRightsGroupFreeToDelet e)
            {
                throw new ErrorServiceRights(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRights("Ismeretlen hiba történt (ServRightsCheckDel) " + e.Message);
            }
        }
        /// <summary>
        /// execute the real-delet of the userRightGroup - its query is secure, not dels a used one
        /// </summary>
        /// <param name="nameOfGroup">difines the rec is needed to delete</param>
        public void deleteTheChosenRightGroup(string nameOfGroup)
        {
            try
            {
                modelRights = new ServiceRightsModel(dbci, parent);
                modelRights.setDeleteOfRightGroup(nameOfGroup);
                listOfRightGroups.RemoveAt(listOfRightGroups.FindIndex(ind => ind.groupName == nameOfGroup));
            }
            catch (ErrorServiceDeleteRecord e)
            {
                throw new ErrorServiceRights(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRights("Ismeretlen hiba történt (ServRightsExecDel) " + e.Message);
            }
        }
        #endregion
    }
}
