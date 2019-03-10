using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject.ServOrdering
{
    public class OrderingModellerWriteOut
    {
        private InterfaceMySQLDBChannel mdi;
        private InterfaceMySQLStartDBConnect startDB;
        private List<KeyValuePair<string, string>> parameters;

        public OrderingModellerWriteOut(UserConnDetails dbci, Form parentMain)
        {
            startDB = new InterfaceMySQLStartDBConnect();
            mdi = startDB.kapcsolodas(dbci, parentMain);
        }

        //tested
        #region change noted->booked / booked->arrived in bunch
        private string queryToSetNotedAsBooked = 
            "UPDATE beszerzes SET beszerzes_erveny=2 WHERE beszerzes_erveny = 1 AND beszerzes_id=@ordId";
        /// <summary>
        /// setTheChosen noted records at booked
        /// </summary>
        /// <param name="listToChange">list of ordId-s</param>
        public void setTheseRecordAsBookedBunch(List<string> listToChange)
        {
            List<KeyValuePair<string, string>> listOfParam;
            try
            {
                listOfParam = new List<KeyValuePair<string, string>>();
                foreach(string row in listToChange)
                {
                    KeyValuePair<string, string> param = new KeyValuePair<string, string>("@ordId",row);
                    listOfParam.Add(param);
                }
            }
            catch (Exception e)
            {
                throw new ErrorOrderingSetNotedAsBooked("A kéréshez a paraméterlista összeállítása sikertelen (ModOrdBook) " + e.Message);
            }
            try
            {
                if(listOfParam.Count > 0)
                {
                    mdi.openConnection();
                    foreach (KeyValuePair<string, string> param in listOfParam)
                    {
                        mdi.execPrepDMQueryWithKVP(queryToSetNotedAsBooked, param);
                    }

                    mdi.closeConnection();
                }
            }
            catch (Exception e)
            {
                throw new ErrorOrderingSetNotedAsBooked("A kéréssorozat végrehajtása sikertelen (ModOrdBook) " + e.Message);
            }
        }
        private string queryToSetBookedAsArrived = "UPDATE beszerzes SET beszerzes_erveny=3 WHERE beszerzes_erveny = 2 AND beszerzes_id=@ordId";
        /// <summary>
        /// sets listOfBooked records as arrived
        /// </summary>
        /// <param name="listToChange"></param>
        public void setTheseRecordsAsArrivedBunch(List<string> listToChange)
        {
            List<KeyValuePair<string, string>> listOfParam;
            try
            {
                listOfParam = new List<KeyValuePair<string, string>>();
                foreach (string row in listToChange)
                {
                    KeyValuePair<string, string> param = new KeyValuePair<string, string>("@ordId", row);
                    listOfParam.Add(param);
                }
            }
            catch (Exception e)
            {
                throw new ErrorOrderingSetBookedAsArrived("A kéréshez a paraméterlista összeállítása sikertelen (ModOrdArriv) " + e.Message);
            }
            try
            {
                if (listOfParam.Count > 0)
                {
                    mdi.openConnection();
                    foreach (KeyValuePair<string, string> param in listOfParam)
                    {
                        mdi.execPrepDMQueryWithKVP(queryToSetBookedAsArrived, param);
                    }

                    mdi.closeConnection();
                }
            }
            catch (Exception e)
            {
                throw new ErrorOrderingSetBookedAsArrived("A kéréssorozat végrehajtása sikertelen (ModOrdArriv) " + e.Message);
            }
        }

        #endregion
        //tested
        #region change booked->Failed / Missing->failed - single

        private string queryToChangeMissingToFailed = 
            "UPDATE beszerzes SET beszerzes_erveny = 5, beszerzes_modosit = @userId, beszerzes_teljesites = CURDATE()" +
            " WHERE (beszerzes_erveny = 4 OR beszerzes_erveny = 2) AND beszerzes_id = @ordId";
        /// <summary>
        /// sets failed booked missing records, no chance to get with another shipping
        /// </summary>
        /// <param name="operatUserId">who made tha change</param>
        /// <param name="ordId">DB identifier of ordering</param>
        public void setTheBookedOrMissingToFailed(string ordId, string operatUserId)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> operUserId = new KeyValuePair<string, string>("@userId", operatUserId);
                KeyValuePair<string, string> orderingId = new KeyValuePair<string, string>("@ordId", ordId);
                parameters.Add(operUserId);
                parameters.Add(orderingId);
            }
            catch (Exception e)
            {
                throw new ErrorOrderingSetFailed("A lekérdezés megalkotása sikertelen (ModOrdSetFailed) "+e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryToChangeMissingToFailed, parameters, 2);
            mdi.closeConnection();
        }

        #endregion
        //tested
        #region change booked->missing / missing->missing - single

        private string queryToFulfillPartlyArrivedOrderings =  //good for booked (1) or Missing (4) records
            "UPDATE beszerzes SET  beszerzes_mennyiseg = @newAmount, beszerzes_modosit = @operatUser, beszerzes_erveny=3," +
            " beszerzes_teljesites = CURDATE()" +
            " WHERE (beszerzes_erveny=2 OR beszerzes_erveny=4) AND beszerzes_id=@ordId";
        /// <summary>
        /// finish the arrivint, but not with the original amount
        /// </summary>
        /// <param name="newAmount">amount that really arrived with shipping</param>
        /// <param name="userIdOperator">who set the change</param>
        /// <param name="ordId">DB identifier of ordering</param>
        public void setPartlyArrivedBooked_MissingRecord(string ordId, string newAmount, string userIdOperator)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> newQuantity = new KeyValuePair<string, string>("@newAmount", newAmount);
                KeyValuePair<string, string> operUser = new KeyValuePair<string, string>("@operatUser", userIdOperator);
                KeyValuePair<string, string> orderingId = new KeyValuePair<string, string>("@ordId", ordId);
                parameters.Add(newQuantity);
                parameters.Add(operUser);
                parameters.Add(orderingId);
            }
            catch (Exception e)
            {
                throw new ErrorOrderingSetPartlyArrivedRecord("A lekérdezés összeállítása sikertelen (ModOrdSetPartArriv) " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryToFulfillPartlyArrivedOrderings, parameters, 3);
            mdi.closeConnection();
        }

        private string queryToCreateNewMissingRecord = 
            "INSERT INTO beszerzes (termek_quant_id, beszerzes_datum, beszerzes_teljesites, user_id, beszerzes_mennyiseg," +
            " beszerzes_modosit, beszerzes_erveny)" +
            " VALUES (@quantId, @oldDate, CURDATE(), @ordUserId, @remainAmount, @operatUser, 4)";
        /// <summary>
        /// sets a new record, that contains the remaining product amount
        /// </summary>
        /// <param name="stripId">stripping identifier</param>
        /// <param name="oldDate">original noted in date of ordering</param>
        /// <param name="remainAmount">the amount that missed from shipping</param>
        /// <param name="origOrdUserId">who made the original ord note</param>
        /// <param name="userIdOperator">who made creation this</param>
        public void createNewMissingRecord(string stripId, string oldDate, string remainAmount, string origOrdUserId,
            string userIdOperator)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> quantId = new KeyValuePair<string, string>("@quantId", stripId);
                KeyValuePair<string, string> oldOrdDate = new KeyValuePair<string, string>("@oldDate", oldDate);
                KeyValuePair<string, string> oldOrdUser = new KeyValuePair<string, string>("@ordUserId", origOrdUserId);
                KeyValuePair<string, string> remAmount = new KeyValuePair<string, string>("@remainAmount", remainAmount);
                KeyValuePair<string, string> operUser = new KeyValuePair<string, string>("@operatUser", userIdOperator);
                parameters.Add(quantId);
                parameters.Add(oldOrdDate);
                parameters.Add(oldOrdUser);
                parameters.Add(remAmount);
                parameters.Add(operUser);
            }
            catch (Exception e)
            {
                throw new ErrorOrderingSetMissingRecord("A lekérdezés összeállítása sikertelen (ModOrdSetMissingRec) " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryToCreateNewMissingRecord, parameters, 5);
            mdi.closeConnection();
        }

        #endregion
        //tested
        #region manage simply one record

        private string queryToModifyNotedRecord= 
            "UPDATE beszerzes SET termek_quant_id = @newQuantId, beszerzes_mennyiseg = @newAmount, beszerzes_modosit = @operatUser" +
            " WHERE beszerzes_erveny=1 AND beszerzes_id=@ordId";
        /// <summary>
        /// modifies the chosen notd record
        /// </summary>
        /// <param name="newStripId">the new prod, is need</param>
        /// <param name="newAmount">the new amount, is need</param>
        /// <param name="userIdOperator">who made the change</param>
        /// <param name="ordId">DB identifier of record</param>
        public void setModifyNotedRecord(string ordId, string newStripId, string newAmount, string userIdOperator)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> newQuantID = new KeyValuePair<string, string>("@newQuantId", newStripId);
                KeyValuePair<string, string> newQuantity = new KeyValuePair<string, string>("@newAmount", newAmount);
                KeyValuePair<string, string> operUser = new KeyValuePair<string, string>("@operatUser", userIdOperator);
                KeyValuePair<string, string> orderingId = new KeyValuePair<string, string>("@ordId", ordId);
                parameters.Add(newQuantID);
                parameters.Add(newQuantity);
                parameters.Add(operUser);
                parameters.Add(orderingId);
            }
            catch(Exception e)
            {
                throw new ErrorServiceUpdateRecord("A kérés megalkotásakor hiba lépett fel (ModOrdUpdateNoted) " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryToModifyNotedRecord, parameters, 4);
            mdi.closeConnection();
        }

        private string queryToCancellNotedRecord =
            "UPDATE beszerzes SET beszerzes_erveny = 0, beszerzes_modosit = @operatUser" +
            " WHERE beszerzes_erveny=1 AND beszerzes_id = @ordId";
        /// <summary>
        /// cancells the chosen noted record
        /// </summary>
        /// <param name="ordId">DB identifier of noted record</param>
        /// <param name="userIdOper">who made the change</param>
        public void setCancelTheChosenNotedRec(string ordId, string userIdOper)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> operUser = new KeyValuePair<string, string>("@operatUser", userIdOper);
                KeyValuePair<string, string> orderingId = new KeyValuePair<string, string>("@ordId", ordId);
                parameters.Add(operUser);
                parameters.Add(orderingId);
            }
            catch (Exception e)
            {
                throw new ErrorServiceDeleteRecord("A kérés megalkotásakor hiba lépett fel (ModOrdCancelNoted) " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryToCancellNotedRecord, parameters, 2);
            mdi.closeConnection();
        }
        private string queryToRenewACancelledRecord = 
            "UPDATE beszerzes SET beszerzes_erveny = 1, beszerzes_modosit = @operatUser" +
            " WHERE beszerzes_id = @ordId AND beszerzes_erveny=0";
        /// <summary>
        /// execute cancel a noted record
        /// </summary>
        /// <param name="ordId">DB record identiifer</param>
        /// <param name="userIdOper">who made it</param>
        public void setRenewCancelledRecordToNoted(string ordId, string userIdOper)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> operUser = new KeyValuePair<string, string>("@operatUser", userIdOper);
                KeyValuePair<string, string> orderingId = new KeyValuePair<string, string>("@ordId", ordId);
                parameters.Add(operUser);
                parameters.Add(orderingId);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRenewRecord("A kérés megalkotásakor hiba lépett fel (ModOrdRenewCancel) " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryToRenewACancelledRecord, parameters, 2);
            mdi.closeConnection();
        }

        private string queryToCreateNewOrderingAsNoted = 
            "INSERT INTO beszerzes (termek_quant_id, user_id, beszerzes_datum, beszerzes_teljesites, beszerzes_mennyiseg," +
            " beszerzes_modosit, beszerzes_erveny) VALUES " +
            "(@stripId, @operatUser, CURDATE(), CURDATE(), @amount, 0, 1)";
        /// <summary>
        /// execute new noted record creation
        /// </summary>
        /// <param name="quantId">stripping ID</param>
        /// <param name="amount">amount of prod</param>
        /// <param name="userIdOper">who made it</param>
        public void setCreateNewOrderingRecordAsNoted(string quantId, string amount, string userIdOper)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> operUser = new KeyValuePair<string, string>("@operatUser", userIdOper);
                KeyValuePair<string, string> strippingId = new KeyValuePair<string, string>("@stripId", quantId);
                KeyValuePair<string, string> wantedAmount = new KeyValuePair<string, string>("@amount", amount);
                parameters.Add(strippingId);
                parameters.Add(operUser);
                parameters.Add(wantedAmount);
            }
            catch (Exception e)
            {
                throw new ErrorServiceNewRecord("A kérés megalkotásakor hiba lépett fel (ModOrdNewNoted) " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepGetOneColumnToListWithKVPList(queryToCreateNewOrderingAsNoted, parameters, 3);
            mdi.closeConnection();
        }
        private string queryToMakeMissingAsArrived = "UPDATE beszerzes SET beszerzes_erveny=3, beszerzes_modosit = @operatUser" +
            " WHERE beszerzes_id = @ordId AND beszerzes_erveny = 4";
        /// <summary>
        /// execute the change of missing record to arrived
        /// </summary>
        /// <param name="ordId">DB identifier of record</param>
        /// <param name="userIdOper">who made the change</param>
        public void setArrivedTheMissingRecord(string ordId, string userIdOper)
        {
            try
            {
                parameters = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> operUser = new KeyValuePair<string, string>("@operatUser", userIdOper);
                KeyValuePair<string, string> orderingId = new KeyValuePair<string, string>("@ordId", ordId);
                parameters.Add(operUser);
                parameters.Add(orderingId);
            }
            catch (Exception e)
            {
                throw new ErrorOrderingSetBookedAsArrived("A kérés megalkotásakor hiba lépett fel (ModOrdRenewCancel) " + e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryToMakeMissingAsArrived, parameters, 2);
            mdi.closeConnection();
        }
        #endregion
    }
}
