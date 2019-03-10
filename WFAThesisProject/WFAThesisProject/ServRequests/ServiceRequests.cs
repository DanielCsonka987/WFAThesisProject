using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using WFAThesisProject.GeneralExceptions;
using WFAThesisProject.ServRequests;

namespace WFAThesisProject
{
    public class ServiceRequests
    {

        private RequestsModelReadIn modelRequestRead;
        private RequestsModelWirteOut modelRequestWrite;
        private UserConnDetails dbci;
        private DataTable table;
        private Form parentMain;
        private string userIdOfOperator;
        private List<RequestRecordActive> requestNormal;
        private List<RequestRecordDeleted> requestDeleted;
        private List<RequestRecordCalledOff> requestCalledOff;
        private List<RequestRecordGivenOut> requestGivenOut;
        private List<ProductToChoose> productListForUserChoose;
        private List<StrippingToChoose> strippingListForUserChoose;

        public ServiceRequests(UserConnDetails dbci, Form parentMainWin, string userIdOfPoerator)
        {
            this.dbci = dbci;
            this.parentMain = parentMainWin;
            this.userIdOfOperator = userIdOfPoerator;
        }

        #region ActiveRequests - readIn
        /// <summary>
        /// reads in the active requests
        /// </summary>
        /// <returns>DataTAble of ActiveResuests</returns>
        public DataTable createDataTableNormalRequests()
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parentMain);
            table = new DataTable();
            table.Columns.Add("Srsz.", typeof(int));
            table.Columns.Add("Kérő neve", typeof(string));
            table.Columns.Add("Kérő területe", typeof(string));
            table.Columns.Add("Kérés dátuma", typeof(string));
            table.Columns.Add("Termék neve", typeof(string));
            table.Columns.Add("Kiszerelése", typeof(int));
            table.Columns.Add("Kiszerelés egysége", typeof(string));
            table.Columns.Add("Mennyiség", typeof(int));
            table.Columns.Add("Termék helye", typeof(string));
            table.Columns.Add("Beszállítója", typeof(string));

            try
            {
                requestNormal = modelRequestRead.getActiveRequests();
                foreach (RequestRecordActive r in requestNormal)
                {
                    table.Rows.Add(r.keresId, r.userKeroNev, r.userTerulet, r.keresDatum, r.termekNev, r.termekKiszerel, 
                        r.termekKiszerelEgys, r.keresMennyiseg, r.termekHely, r.termekBeszall);
                }
                return table;
            }
            catch (ErrorServiceCreateDataList e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (Exception e)
            {

                throw new ErrorServiceRequests("Ismeretlen hiba történt (ServRequ_DTAct) " + e.Message);
            }
        }
        /// <summary>
        /// gets the element form list of ActiveRequests
        /// </summary>
        /// <returns>ActiveRequest container</returns>
        public RequestRecordActive getChosenActiveRequest(int requId)
        {
            try
            {
                foreach (RequestRecordActive rec in requestNormal)
                {
                    if (rec.keresId == requId)
                        return rec;
                }
            }
            catch(Exception e)
            {
                throw new ErrorServiceRequests("A listaelem keresésnél hiba történt (ServRequ_DTAct) "+ e.Message);
            }
            throw new ErrorServiceRequests("Az aktív kérések közötti keresés eredménytelen volt (ServRequ_DTAct)");
        }
        #endregion

        #region DeletedReqiests - readIn
        /// <summary>
        /// reads in the active, but deleted requests
        /// </summary>
        /// <returns>DataTable of deleted resuest</returns>
        public DataTable createDataTableDeletedRequests()
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parentMain);
            table = new DataTable();
            table.Columns.Add("Srsz.", typeof(int));
            table.Columns.Add("Kérő neve", typeof(string));
            table.Columns.Add("Kérő területe", typeof(string));
            table.Columns.Add("Kérés dátuma", typeof(string));
            table.Columns.Add("Termék neve", typeof(string));
            table.Columns.Add("Mennyiség", typeof(int));
            table.Columns.Add("Termék kiszerelése", typeof(int));
            table.Columns.Add("Beszállító", typeof(string));
            table.Columns.Add("Törlő neve", typeof(string));

            try
            {
                requestDeleted = modelRequestRead.getDeletedRequests();
                foreach (RequestRecordDeleted r in requestDeleted)
                {
                    table.Rows.Add(r.keresId, r.userKeroNev, r.userTerulet, r.keresDatum, r.termekNev, r.keresMennyiseg,
                        r.termekKiszerel, r.termekBeszall, r.keresModosNev);
                }
            }
            catch (ErrorServiceCreateDataList e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt (ServRequ_DTDel) " + e.Message);
            }
            return table;
        }

        /// <summary>
        /// gets the list of DeletedRequests
        /// </summary>
        /// <returns>seeked DeletedRequest container</returns>
        public RequestRecordDeleted getChosenDeletedRequest(int requId)
        {
            try
            {
                foreach (RequestRecordDeleted rec in requestDeleted)
                {
                    if (rec.keresId == requId)
                        return rec;
                }
                throw new ErrorServiceRequests("A listaelem keresése sikertelen (ServRequ_DTDel)");
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("A listaelem keresése sikertelen (ServRequ_DTDel)");
            }
        }
        #endregion

        #region CalledOutRequests - readIn
        /// <summary>
        /// reads in the Called out requests - that made by the orderer - cancelled, no need for that case
        /// </summary>
        /// <returns>DataTAble of CalledOut requests</returns>
        public DataTable createDataTableCalledOffRequests()
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parentMain);
            table = new DataTable();
            table.Columns.Add("Srsz.", typeof(int));
            table.Columns.Add("Kérő neve", typeof(string));     //összevonva
            table.Columns.Add("Kérő területe", typeof(string));
            table.Columns.Add("Kérés dátuma", typeof(string));
            table.Columns.Add("Termék neve", typeof(string));
            table.Columns.Add("Mennyiség", typeof(int));
            table.Columns.Add("Beszállító", typeof(string));
            table.Columns.Add("Termék kiszerelése", typeof(int));
            try
            {
                requestCalledOff = modelRequestRead.getCalledOffRequests();
                foreach (RequestRecordCalledOff r in requestCalledOff)
                {
                    table.Rows.Add(r.keresId, r.userKeroNev, r.userTerulet, r.keresDatum, r.termekNev, r.keresMennyiseg,
                        r.termekBeszall, r.termekKiszerel);
                }
            }
            catch (ErrorServiceCreateDataList e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt (ServRequ_DTCalledOff) " + e.Message);
            }
            return table;
        }
        /// <summary>
        /// gets the element from CalledOff requests
        /// </summary>
        /// <returns>CalledOut request container</returns>
        public RequestRecordCalledOff getChosenCalledOffRequest(int requId)
        {
            try
            {
                foreach (RequestRecordCalledOff rec in requestCalledOff)
                {
                    if (rec.keresId == requId)
                        return rec;
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("A listaelem keresésnél hiba történt (ServRequ_DTCalledOf) "+ e.Message);
            }
            throw new ErrorServiceRequests("A listaelem keresése sikertelen (ServRequ_DTCalledOf)");
        }
        #endregion

        #region GivenOutRequests - readIn
        /// <summary>
        /// reads in the given out requests - those are done records that fullfiled once
        /// </summary>
        /// <returns>DataTable of GivenOut requests</returns>
        public DataTable createDataTableGivenOutRequests()
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parentMain);
            table = new DataTable();
            table.Columns.Add("Srsz.", typeof(int));
            table.Columns.Add("Kérő neve", typeof(string));     //összevonva
            table.Columns.Add("Kérő területe", typeof(string));
            table.Columns.Add("Kérés dátuma", typeof(string));
            table.Columns.Add("Teljesítés dátuma", typeof(string));
            table.Columns.Add("Átadó neve", typeof(string));
            table.Columns.Add("Termék neve", typeof(string));
            table.Columns.Add("Termék kiszerelése", typeof(int));
            table.Columns.Add("Beszállítója", typeof(string));

            try
            {
                requestGivenOut = modelRequestRead.getGivenOutRequests();
                foreach (RequestRecordGivenOut r in requestGivenOut)
                {
                    table.Rows.Add(r.keresId, r.userKeroNev, r.userTerulet, r.keresDatum, r.teljesites, r.keresModosNev,
                        r.termekNev, r.termekKiszerel, r.termekBeszall);
                }
            }
            catch (ErrorServiceCreateDataList e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt (ServRequ_DTGiveOut) " + e.Message);
            }
            return table;

        }
        /// <summary>
        /// gets the element from GivenOut requests
        /// </summary>
        /// <returns>GivenOutRequest container</returns>
        public RequestRecordGivenOut getChosenGivenOutRequest(int requId)
        {
            try
            {
                foreach (RequestRecordGivenOut rec in requestGivenOut)
                {
                    if (rec.keresId == requId)
                        return rec;
                }
                throw new ErrorServiceRequests("A listaelem keresése sikertelen (ServRequ_DTCalledOf)");
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("A listaelem keresése sikertelen (ServRequ_DTCalledOf)");
            }
        }
        #endregion
        //tested
        #region makes the changes between active-givenOut record-state
        /// <summary>
        /// books down the giving out process - charges the store by an amount
        /// </summary>
        /// <param name="quantId">strippingID, to target the request</param>
        /// <param name="amountAbout">the amount of the request, to charge the store</param>
        /// <param name="requId">DB identifier of the request</param>
        /// <param name="userIdOfRequester">userID, who wanted that</param>
        public void giveOutTheChosenProduct(int quantId, int amountAbout, int requId, int userIdOfRequester)
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parentMain);
            modelRequestWrite = new RequestsModelWirteOut(dbci, parentMain);
            string finalAmountAfterTheGivingOut;
            string strippingIdThatUnderProcess;
            try
            {
                strippingIdThatUnderProcess = Convert.ToString(quantId);
                int amountBeforeTheChange = modelRequestRead.getTheActualAmountOfTheStripping(strippingIdThatUnderProcess);
                if (amountBeforeTheChange >= amountAbout)
                {
                    finalAmountAfterTheGivingOut = Convert.ToString(amountBeforeTheChange - amountAbout);
                }
                else
                    throw new ErrorServiceRequests("Nincs megfeleő mennyiség a raktárban (ServReq_giveOutAct)");
            }
            catch (ErrorServiceGetTheAmount e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt (ServReq_giveOutActAmount) " + e.Message);
            }
            try
            {
                modelRequestWrite.deleteRequestTableGiveOutARecord(userIdOfOperator, requId.ToString(),
                    strippingIdThatUnderProcess, userIdOfRequester.ToString(), finalAmountAfterTheGivingOut);
            }
            catch (ErrorServiceDeleteRecord e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (ErrorServiceUpdateRecord e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt (ServRequ_giveOutAct) " + e.Message);
            }
        }
        /// <summary>
        /// makes the given out product being get-back, credit that amount to the store
        /// </summary>
        /// <param name="modosUserId">userID, who makes the prodess</param>
        /// <param name="quantId">strippingID, target request</param>
        /// <param name="amountAbout">the amount, that the request is about, needed to credit to the store</param>
        /// <param name="requId">DB identifier to target the request</param>
        /// <param name="userIdOfRequester">userId, who wanted that request</param>
        public void getBackTheChosenProductThatWereGivenOut(int quantId, int amountAbout,
            int requId, int userIdOfRequester)
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parentMain);
            modelRequestWrite = new RequestsModelWirteOut(dbci, parentMain);
            string finalAmountAfterTheGivingOut;
            string qualityIdThatUnderProcess;
            try
            {
                qualityIdThatUnderProcess = Convert.ToString(quantId);
                int amountBeforeTheChange = modelRequestRead.getTheActualAmountOfTheStripping(qualityIdThatUnderProcess);

                finalAmountAfterTheGivingOut = Convert.ToString(amountBeforeTheChange + amountAbout);

            }
            catch (ErrorServiceGetTheAmount e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt (ServRequ_getBackGivenOut) " + e.Message);
            }
            try
            {
                modelRequestWrite.undeleteRequestTableGetBackARecord(userIdOfOperator, requId.ToString(),
                    qualityIdThatUnderProcess, userIdOfRequester.ToString(), finalAmountAfterTheGivingOut);
            }
            catch (ErrorServiceRenewRecord e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (ErrorServiceUpdateRecord e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt (ServRequ_getBackGivenOut) " + e.Message);
            }
        }
        #endregion
        //tested
        #region delet-undelet an active request by the stock-keeper
        /// <summary>
        /// it inactivates an active record
        /// </summary>
        /// <param name="modUserId">userId, who does that</param>
        /// <param name="requId">DB identifier of the target request</param>
 
        /// <param name="reqUserId">userId, who wanted that</param>
        public void deletAnActiveRequest(int requId, int reqUserId)
        {
            modelRequestWrite = new RequestsModelWirteOut(dbci, parentMain);
            try
            {
                modelRequestWrite.deleteRequestTableActiveRecord(userIdOfOperator, requId.ToString(),
                    reqUserId.ToString());
            }
            catch(ErrorServiceDeleteRecord e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt (ServRequ_delAct) " + e.Message);
            }
        }
        /// <summary>
        /// it reactivates a direct-deleted record by the stock-keeper
        /// </summary>
        /// <param name="requId">DB identifier of the target request</param>
        /// <param name="reqUserId">userId, who wanted that</param>
        public void undeletADeletedRequest(int requId, int reqUserId)
        {
            modelRequestWrite = new RequestsModelWirteOut(dbci, parentMain);
            try
            {
                modelRequestWrite.undeletRequestTableDeletedRecord(userIdOfOperator, requId.ToString(), 
                    reqUserId.ToString());
            }
            catch (ErrorServiceRenewRecord e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt (ServRequ_undelAct) " + e.Message);
            }
        }


        #endregion
        //tested
        #region readsIn the special datas to modify/overwrite an active record - product pool, stripping pool
        /// <summary>
        /// readsIn the products - to a combobox/listview to the user
        /// </summary>
        /// <returns>list of strings with the productnames</returns>
        public List<string> getThePoolOfProducts()
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parentMain);
            List<string> productsList = new List<string>();
            try
            {
                productListForUserChoose = modelRequestRead.getThePoolOfProducts();
                foreach (ProductToChoose pc in productListForUserChoose)
                {
                    productsList.Add(pc.termekNev + "_" + pc.beszallitoId);
                }

            }
            catch(ErrorServiceGetTheProdPool e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt (ServRequ_poolProd) " + e.Message);
            }
            return productsList;
        }
        /// <summary>
        /// defines and reads out the product in the list, that the user chosen out
        /// </summary>
        /// <param name="kivTermekNevSzallito"></param>
        /// <returns></returns>
        public int identifyTheProductIdInProductList(string kivTermekNevSzallito)
        {
            try
            {
                string[] parts = kivTermekNevSzallito.Split('_');
                ProductToChoose temp = productListForUserChoose.Find(x => x.termekNev == parts[0] 
                            && x.beszallitoId == parts[1]);
                return temp.termekMinId;
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt  (ServReq_identifProd) " + e.Message);
            }

        }
        /// <summary>
        /// identify the chosen product's subcontractor durring modifing
        /// </summary>
        /// <param name="chosenProductionID_DurringModify"></param>
        /// <returns>subcintractor name in string</returns>
        public string getTheChosenProductsSubcontractor(int chosenProductionID_DurringModify)
        {
            try
            {
                ProductToChoose temp = productListForUserChoose.Find(x => x.termekMinId == chosenProductionID_DurringModify);
                return temp.beszallitoId;
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt  (ServReq_identifProd) " + e.Message);
            }
        }
        /*
        /// <summary>
        /// identify the old prodct's name that stored originally durring modify
        /// </summary>
        /// <param name="oldProductId"></param>
        /// <returns></returns>
        public string getTheChosenProductName(int oldProductId)
        {
            try
            {
                ProductToChoose temp = productListForUserChoose.Find(x => x.termekMinId == oldProductId);
                return temp.beszallitoId;
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt  (ServReq_identifProd) " + e.Message);
            }
        }*/
        /// <summary>
        /// reads in the strippings of the chosen product
        /// </summary>
        /// <param name="kivTermekId">the product identifier</param>
        /// <returns>list of string with the stripping of the produvt</returns>
        public List<string> getThePoolOfStrippings(int kivTermekId)
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parentMain);
            List<string> strippingList = new List<string>();
            try
            {
                strippingListForUserChoose = modelRequestRead.getThePoolOfStrippings(kivTermekId.ToString());
                if (strippingListForUserChoose.Count == 0)
                {
                    strippingList.Add("Nincs kiszerelés");
                    return strippingList;
                }
                foreach(StrippingToChoose sc in strippingListForUserChoose)
                {
                    strippingList.Add(sc.termekKiszerel.ToString());
                }
            }
            catch (ErrorServiceGetTheStripPool e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt  (ServReq_poolStrip) " + e.Message);
            }
            return strippingList;
        }
        /// <summary>
        /// defines and reads out the strippingID of the chosen stripping from the list
        /// </summary>
        /// <param name="kivKiszerel">stripping of the product</param>
        /// <returns>the specific strippingID of the chosen stripping of the product</returns>
        public int identifyTheStrippingIDFromList(string kivKiszerel)
        {
            try
            {
                StrippingToChoose temp = strippingListForUserChoose.Find(x => x.termekKiszerel == Convert.ToInt32(kivKiszerel));
                return temp.termekQuantId;
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt  (ServReq_identifStrip) " + e.Message);
            }
        }
        #endregion
        //tested
        #region makes change in Active Request
        /// <summary>
        /// mediate the request change at active records
        /// </summary>
        /// <param name="newAmount">the new amount from the stripping</param>
        /// <param name="newQuantId">the new stripping identifier</param>
        /// <param name="requId">DB identifier of the request</param>
        /// <param name="oldRequUserId">DB identifier of the requester</param>
        public void modifyTheActiveRecord(int newAmount, int newQuantId, int requId, int oldRequUserId)
        {
            try
            {
                modelRequestWrite = new RequestsModelWirteOut(dbci, parentMain);
                modelRequestWrite.updateRequestTableAtARecord(userIdOfOperator, newAmount.ToString(), 
                    newQuantId.ToString(), requId.ToString(),  oldRequUserId.ToString());
            }
            catch(ErrorServiceUpdateRecord e)
            {
                throw new ErrorServiceRequests(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen eredetű hiba történt (ServReq_modifAct) " + e.Message);
            }
        }

        #endregion
    }
}
