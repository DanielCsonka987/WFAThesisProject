using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.UserRightsManage
{
    public class ServiceRightsModel
    {
        private InterfaceMySQLDBChannel mdi;
        private InterfaceMySQLStartDBConnect startDB;
        private List<KeyValuePair<string, string>> parameters;

        public ServiceRightsModel(UserConnDetails dbci, Form paretnRightWin)
        {
            startDB = new InterfaceMySQLStartDBConnect();
            mdi = startDB.kapcsolodas(dbci, paretnRightWin);
        }

        private string queryOfCollectTheUserRightGroups = "SELECT jog_id, jog FROM jogosultsag";
        /// <summary>
        /// collects the usrRightGroups from DB in string[]
        /// </summary>
        /// <returns>result of collection</returns>
        public List<string[]> collectTheUserRightGroups()
        {
            mdi.openConnection();
            List<string[]> result = mdi.executeQueryGetStringArrayListOfRows(queryOfCollectTheUserRightGroups);
            mdi.closeConnection();
            if (result == null)
            {
                throw new ErrorServiceCreateDataList("Adatok gyűjtés sikertelen (ModRightRead)");
            }
            else
                return result;
        }
        //tested
        #region new creator and modifier
        private string queryOfCreateNewRightGroup = "INSERT INTO jogosultsag (jog_id, jog) VALUES (@groupname, @right)";
        private string queryOfModifyExistRightGroup = "UPDATE jogosultsag SET jog=@right WHERE jog_id=@groupname";
        /// <summary>
        /// creates a new userRightGroup
        /// </summary>
        /// <param name="newGroupName">the name of that</param>
        /// <param name="rightsIn10NS">the right paramters ot that</param>
        /// <param name="new_modify">the mode of the process - true = new / false = modify</param>
        public void setNewOrModifyRecordOfRightGroup(string newGroupName, string rightsIn10NS, bool new_modify)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> groupName = new KeyValuePair<string, string>("@groupname", newGroupName);
                KeyValuePair<string, string> rightParm = new KeyValuePair<string, string>("@right", rightsIn10NS);
                parameters.Add(groupName);
                parameters.Add(rightParm);
            }
            catch (Exception e)
            {
                if (new_modify)
                    throw new ErrorServiceNewRecord("A lekérdezéshez kérés összeállítása sikertelen (ModRightNew) " + e.Message);
                else
                    throw new ErrorServiceUpdateRecord("A lekérdezéshez kérés összeállítása sikertelen (ModRightModif) " + e.Message);
            }
            mdi.openConnection();
            if (new_modify)
                mdi.execPrepDMQueryWithKVPList(queryOfCreateNewRightGroup, parameters, 2);
            else
                mdi.execPrepDMQueryWithKVPList(queryOfModifyExistRightGroup, parameters, 2);
            mdi.closeConnection();
        }
        #endregion
        //tested
        #region real delete tester and execueter
        private string queryToCheckTheUsageOfTheRigthGroup =
            "SELECT COUNT(jog_id) FROM felhasznadatok WHERE jog_id=@groupname";
        /// <summary>
        /// revise if the userRightGroup amoung users is not in use
        /// </summary>
        /// <param name="groupName">the groupName is needed to revise</param>
        /// <returns>true = under use / false is free to delete</returns>
        public int checkTheRecordInUse(string groupName)
        {
            string result = "1";    //if exception appears more secure - no mistace upper to let deletion
            KeyValuePair<string, string> param;
            try
            {
                param = new KeyValuePair<string, string>("@groupname", groupName);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRightsGroupFreeToDelet("A lekérdezéshez kérés összeállítása sikertelen (ModRightChekcDel) "
                    + e.Message);
            }
            mdi.openConnection();
            result = mdi.execPrepScalarQueryInStringWithKVP(queryToCheckTheUsageOfTheRigthGroup, param);
            mdi.closeConnection();
            return Convert.ToInt32(result);
        }
        private string queryOfDeletUserRightGroup =
            "DELETE FROM jogosultsag WHERE (SELECT COUNT(jog_id) FROM felhasznadatok WHERE jog_id = @groupname)" +
            " = 0 AND jog_id = @groupname";
        /// <summary>
        /// execute real deletion in 'jogosultsag' but the string have additional secure condition
        /// </summary>
        /// <param name="groupName">userRightGroup thet is needed to delete</param>
        public void setDeleteOfRightGroup(string groupName)
        {
            KeyValuePair<string, string> param;
            try
            {
                param = new KeyValuePair<string, string>("@groupname", groupName);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRightsGroupFreeToDelet("A lekérdezéshez kérés összeállítása sikertelen (ModRightDel) "
                    + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVP(queryOfDeletUserRightGroup, param);
            mdi.closeConnection();
        }
        #endregion
    }
}
