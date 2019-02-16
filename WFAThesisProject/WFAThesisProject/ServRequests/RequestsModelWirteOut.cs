using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAThesisProject
{ 
    public class RequestsModelWirteOut
    {
        private InterfaceMySQLDBChannel mdi;
        private InterfaceMySQLStartDBConnect startDB;
        private List<KeyValuePair<string, string>> parameters;

        private string queryUpdateStrippingTableAmountChangeCase =  //the pare of this is in the ReadIn class
            "UPDATE raktmennyiseg SET termek_mennyiseg=@ujabbMennyiseg WHERE termek_quant_id=@kiszerelID";

        public RequestsModelWirteOut(UserConnDetails dbci, Form parent)
        {
            startDB = new InterfaceMySQLStartDBConnect();
            mdi = startDB.kapcsolodas(dbci,parent);
        }
        //tested
        #region delets an active record -> makes it givenOut one
        private string queryGiveOutTheRequest =
            "UPDATE keresek SET keres_teljesit=CURDATE(), keres_modosit=@modUserId, keres_erveny=0" +
            " WHERE keres_datum = @reqStartDate AND termek_quant_id = @kiszerelId AND" +
            " user_id = @reqUserId AND keres_teljesit=0";
        /// <summary>
        /// process of inactivete a request and charge the inventroy pool in the specific stripping
        /// </summary>
        /// <param name="modUserId">userID who makes the process</param>
        /// <param name="reqStartDate">startDate of the target request</param>
        /// <param name="recQuantId">stripping ID of the target request</param>
        /// <param name="reqUserId">user ID, who asked and credits for</param>
        /// <param name="newAmountInStripp">teh amount that will be in the strore after the process - less</param>
        public void deleteRequestTableGiveOutARecord(string modUserId, string reqStartDate, string recQuantId, 
            string reqUserId, string newAmountInStripp)
        {
            try
            {
                KeyValuePair<string, string> modUser = new KeyValuePair<string, string>("@modUserId", modUserId);
                KeyValuePair<string, string> reqStart = new KeyValuePair<string, string>("@reqStartDate", reqStartDate);
                KeyValuePair<string, string> quantId = new KeyValuePair<string, string>("@kiszerelId", recQuantId);
                KeyValuePair<string, string> reqUser = new KeyValuePair<string, string>("@reqUserId", reqUserId);
                parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(modUser);
                parameters.Add(reqStart);
                parameters.Add(quantId);
                parameters.Add(reqUser);
            }
            catch (Exception e)
            {
                throw new ErrorServiceDeleteRecord("Termék kiadásával kapcsolatos kérés összeállítása sikertelen (ModReqGiveOut) " +
                    e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryGiveOutTheRequest, parameters, 4);  //delete
            try
            {
                KeyValuePair<string, string> newAmount = new KeyValuePair<string, string>("@ujabbMennyiseg", newAmountInStripp);
                KeyValuePair<string, string> quantId = new KeyValuePair<string, string>("@kiszerelId", recQuantId);
                parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(newAmount);
                parameters.Add(quantId);
            }
            catch (Exception e)
            {
                mdi.closeConnection();
                throw new ErrorServiceUpdateRecord("Termék kiadáshoz raktárfrissítő kérés összeállítása sikertelen (ModReqGivenOut) "
                    + e.Message);
            }
            mdi.execPrepDMQueryWithKVPList(queryUpdateStrippingTableAmountChangeCase, parameters, 2);
            mdi.closeConnection();
        }
        #endregion
        //tested
        #region renew a given out record -> makes it taken back, active request
        private string queryUndeleteGivenOutRequest =
            "UPDATE keresek SET keres_teljesit=0, keres_modosit=@modUserId, keres_erveny=1" +
            " WHERE keres_datum = @reqStartDate AND termek_quant_id = @kiszerelId AND" +
            " user_id = @reqUserId AND keres_teljesit>0";
        /// <summary>
        /// process of reverse a giving out event - it makes the credit inventroy by the specific stripping
        /// </summary>
        /// <param name="modUserId">uesrId, who mkes the process</param>
        /// <param name="reqStartDate">startDate of the request to specify</param>
        /// <param name="recQuantId">stripping ID, what is needed to modify</param>
        /// <param name="reqUserId">user ID, who give back the product</param>
        /// <param name="newAmountInStripp">the amount that will bi in the store, after the process</param>
        public void undeleteRequestTableGetBackARecord(string modUserId, string reqStartDate, string recQuantId,
                string reqUserId, string newAmountInStripp)
        {
            try
            {
                KeyValuePair<string, string> modUser = new KeyValuePair<string, string>("@modUserId", modUserId);
                KeyValuePair<string, string> reqStart = new KeyValuePair<string, string>("@reqStartDate", reqStartDate);
                KeyValuePair<string, string> quantId = new KeyValuePair<string, string>("@kiszerelId", recQuantId);
                KeyValuePair<string, string> reqUser = new KeyValuePair<string, string>("@reqUserId", reqUserId);
                parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(modUser);
                parameters.Add(reqStart);
                parameters.Add(quantId);
                parameters.Add(reqUser);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRenewRecord("Termék kiadásával kapcsolatos kérés összeállítása sikertelen (ModReqGiveOut) " +
                    e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryUndeleteGivenOutRequest, parameters, 4);    //undelet
            try
            {
                KeyValuePair<string, string> newAmount = new KeyValuePair<string, string>("@ujabbMennyiseg", newAmountInStripp);
                KeyValuePair<string, string> quantId = new KeyValuePair<string, string>("@kiszerelId", recQuantId);
                parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(newAmount);
                parameters.Add(quantId);
            }
            catch (Exception e)
            {
                mdi.closeConnection();
                throw new ErrorServiceUpdateRecord("Termék kiadáshoz raktárfrissítő kérés összeállítása sikertelen (ModReqGivenOut) "
                    + e.Message);
            }
            mdi.execPrepDMQueryWithKVPList(queryUpdateStrippingTableAmountChangeCase, parameters, 2);
            mdi.closeConnection();
        }
        #endregion
        //tested
        #region delet an active record - no effect on inventory, no need for that
        private string queryDirectDeletTheRequest =
            "UPDATE keresek SET keres_modosit=@modUserId, keres_erveny=0" +
            " WHERE keres_datum=@reqStartDate AND termek_quant_id=@kiszerelId AND user_id=@reqUserId AND" +
            " keres_teljesit=0";
        /// <summary>
        /// delet an active request by the stock-keeper - no inventroy change
        /// </summary>
        /// <param name="modUserId">userID of the authorised stockkeeper</param>
        /// <param name="reqStartDate">startDate of the target request</param>
        /// <param name="recQuantId">strippingID of the target</param>
        /// <param name="reqUserId">userID, who wanted</param>
        public void deleteRequestTableActiveRecord(string modUserId, string reqStartDate, string recQuantId,
            string reqUserId)
        {
            try
            {
                KeyValuePair<string, string> modUser = new KeyValuePair<string, string>("@modUserId", modUserId);
                KeyValuePair<string, string> reqStart = new KeyValuePair<string, string>("@reqStartDate", reqStartDate);
                KeyValuePair<string, string> quantId = new KeyValuePair<string, string>("@kiszerelId", recQuantId);
                KeyValuePair<string, string> reqUser = new KeyValuePair<string, string>("@reqUserId", reqUserId);
                parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(modUser);
                parameters.Add(reqStart);
                parameters.Add(quantId);
                parameters.Add(reqUser);
            }
            catch (Exception e)
            {
                throw new ErrorServiceDeleteRecord("Termékkel kapcsolatos kérés összeállítása sikertelen (ModReqDel/Undel) " +
                    e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryDirectDeletTheRequest, parameters, 4);
            mdi.closeConnection();
        }
        #endregion
        //tested
        #region undelet a direct deleted request record - active again
        private string queryUndeletDirectDeleteRequest =
            "UPDATE keresek SET keres_teljesit=0, keres_modosit=@modUserId, keres_erveny=1" +
            " WHERE keres_datum=@reqStartDate AND termek_quant_id=@kiszerelId AND user_id=@reqUserId AND" +
            " keres_teljesit=0";
        /// <summary>
        /// renew the deleted request record, no inventory change, active again
        /// </summary>
        /// <param name="modUserId">userID of the authorised stock-keeper</param>
        /// <param name="reqStartDate">startDate of the target reqzest</param>
        /// <param name="recQuantId">strippingID of the target</param>
        /// <param name="reqUserId">userID, who wanted that</param>
        public void undeletRequestTableDeletedRecord(string modUserId, string reqStartDate, string recQuantId,
            string reqUserId)
        {
            try
            {
                KeyValuePair<string, string> modUser = new KeyValuePair<string, string>("@modUserId", modUserId);
                KeyValuePair<string, string> reqStart = new KeyValuePair<string, string>("@reqStartDate", reqStartDate);
                KeyValuePair<string, string> quantId = new KeyValuePair<string, string>("@kiszerelId", recQuantId);
                KeyValuePair<string, string> reqUser = new KeyValuePair<string, string>("@reqUserId", reqUserId);
                parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(modUser);
                parameters.Add(reqStart);
                parameters.Add(quantId);
                parameters.Add(reqUser);
            }
            catch (Exception e)
            {
                throw new ErrorServiceDeleteRecord("Termékkel kapcsolatos kérés összeállítása sikertelen (ModReqDel/Undel) " +
                    e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryUndeletDirectDeleteRequest, parameters, 4);
            mdi.closeConnection();
        }
        #endregion
        //tested
        #region update an active request record - changes it amount and stripping ID, renew the start-date
        private string queryUpdateContentTheRequest = //the new paramteres can be the strippin-product itself and amount
                                                      // -> a new product choose area is needed => to feed those comboboxes in ReadIn class has methods
                                                      // -> it renew the requesting start date, the requesting doesn't change!
            "UPDATE keresek SET keres_datum=CURDATE(), keres_modosit=@modUserId, keres_erveny=1," +
            " termek_quant_id=@ujKiszerelId, keres_mennyiseg=@ujMennyis" +
            " WHERE keres_datum=@reqStartDate AND termek_quant_id=@regiKiszerelId AND user_id=@reqUserId";
        /// <summary>
        /// changes an active record, that may not correct
        /// -> strippingId, amount direct change, startDate changes to the present moment
        /// </summary>
        /// <param name="modUserId">userID, who changes it</param>
        /// <param name="newRecordAmount">the new amount</param>
        /// <param name="newRecordQuantId">the new stripping ID</param>
        /// <param name="oldReqStartDate">the old startData</param>
        /// <param name="oldRecQuantId">the old strippingID</param>
        /// <param name="oldReqUserId">the userID, who eanted that</param>
        public void updateRequestTableAtARecord(string modUserId, string newRecordAmount, string newRecordQuantId,
            string oldReqStartDate, string oldRecQuantId, string oldReqUserId)
        {
            try
            {
                KeyValuePair<string, string> modUser = new KeyValuePair<string, string>("@modUserId", modUserId);
                KeyValuePair<string, string> reqStart = new KeyValuePair<string, string>("@reqStartDate", oldReqStartDate);
                KeyValuePair<string, string> quantId = new KeyValuePair<string, string>("@regiKiszerelId", oldRecQuantId);
                KeyValuePair<string, string> reqUser = new KeyValuePair<string, string>("@reqUserId", oldReqUserId);

                KeyValuePair<string, string> newQuantId = new KeyValuePair<string, string>("@ujKiszerelId", newRecordQuantId);
                KeyValuePair<string, string> newAmount = new KeyValuePair<string, string>("@ujMennyis", newRecordAmount);
                parameters = new List<KeyValuePair<string, string>>();
                parameters.Add(modUser);
                parameters.Add(reqStart);
                parameters.Add(quantId);
                parameters.Add(reqUser);
                parameters.Add(newQuantId);
                parameters.Add(newAmount);
            }
            catch (Exception e)
            {
                throw new ErrorServiceUpdateRecord("Termék kiadásához rekordtörlő kérés összeállítása sikertelen (ModReqActUpdate) " +
                    e.Message);
            }
            mdi.openConnection();
            mdi.execPrepDMQueryWithKVPList(queryUpdateContentTheRequest, parameters, 6);
            mdi.closeConnection();
        }
        #endregion

        //needed an orderin method -> attatched the giving out service-method
    }
}
