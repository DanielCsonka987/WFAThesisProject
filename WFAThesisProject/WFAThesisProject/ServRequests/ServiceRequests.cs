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
        private Form parent;
        private string userIdOfPoerator;
        private List<RequestRecordActive> requestNormal;
        private List<RequestRecordDeleted> requestDeleted;
        private List<RequestRecordCalledOff> requestCalledOff;
        private List<RequestRecordGivenOut> requestGivenOut;
        private List<ProductToChoose> productListForUserChoose;
        private List<StrippingToChoose> strippingListForUserChoose;

        public ServiceRequests(UserConnDetails dbci, Form parentMain, string userIdOfPoerator)
        {
            this.dbci = dbci;
            this.parent = parentMain;
            this.userIdOfPoerator = userIdOfPoerator;
        }

        #region ActiveRequests - readIn
        /// <summary>
        /// reads in the active requests
        /// </summary>
        /// <returns>DataTAble of ActiveResuests</returns>
        public DataTable createDataTableNormalRequests()
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parent);
            table = new DataTable();
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
                    table.Rows.Add(r.userKeroNev, r.userTerulet, r.keresDatum, r.termekNev, r.termekKiszerel, 
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
        /// gets the list of ActiveRequests
        /// </summary>
        /// <returns></returns>
        public RequestRecordActive getChosenActiveRequest(int index)
        {
            return requestNormal[index];
        }
        #endregion

        #region DeletedReqiests - readIn
        /// <summary>
        /// reads in the active, but deleted requests
        /// </summary>
        /// <returns>DataTable of deleted resuest</returns>
        public DataTable createDataTableDeletedRequests()
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parent);
            table = new DataTable();
            table.Columns.Add("Kérő neve", typeof(string));
            table.Columns.Add("Kérő területe", typeof(string));
            table.Columns.Add("Kérés dátuma", typeof(string));
            table.Columns.Add("Termék neve", typeof(string));
            table.Columns.Add("Mennyiség", typeof(int));
            table.Columns.Add("Termék kiszerelése", typeof(int));
            table.Columns.Add("Törlő neve", typeof(string));

            try
            {
                requestDeleted = modelRequestRead.getDeletedRequests();
                foreach (RequestRecordDeleted r in requestDeleted)
                {
                    table.Rows.Add(r.userKeroNev, r.userTerulet, r.keresDatum, r.termekNev, r.keresMennyiseg,
                        r.termekKiszerel, r.keresModosNev);
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
        /// <returns>List of DeletedRequests</returns>
        public RequestRecordDeleted getChosenDeletedRequest(int index)
        {
            return requestDeleted[index];
        }
        #endregion

        #region CalledOutRequests - readIn
        /// <summary>
        /// reads in the Called out requests - that made by the orderer - cancelled, no need for that case
        /// </summary>
        /// <returns>DataTAble of CalledOut requests</returns>
        public DataTable createDataTableCalledOffRequests()
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parent);
            table = new DataTable();
            table.Columns.Add("Kérő neve", typeof(string));     //összevonva
            table.Columns.Add("Kérő területe", typeof(string));
            table.Columns.Add("Kérés dátuma", typeof(string));
            table.Columns.Add("Termék neve", typeof(string));
            table.Columns.Add("Mennyiség", typeof(int));
            table.Columns.Add("Termék kiszerelése", typeof(int));
            try
            {
                requestCalledOff = modelRequestRead.getCalledOffRequests();
                foreach (RequestRecordCalledOff r in requestCalledOff)
                {
                    table.Rows.Add(r.userKeroNev, r.userTerulet, r.keresDatum, r.termekNev, r.keresMennyiseg,
                        r.termekKiszerel);
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
        /// gets the CalledOff requests
        /// </summary>
        /// <returns>list of CalledOut requests</returns>
        public RequestRecordCalledOff getChosenCalledOffRequest(int index)
        {
            return requestCalledOff[index];
        }
        #endregion

        #region GivenOutRequests - readIn
        /// <summary>
        /// reads in the given out requests - those are done records that fullfiled once
        /// </summary>
        /// <returns>DataTable of GivenOut requests</returns>
        public DataTable createDataTableGivenOutRequests()
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parent);
            table = new DataTable();
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
                    table.Rows.Add(r.userKeroNev, r.userTerulet, r.keresDatum, r.teljesites, r.keresModosNev,
                        r.termekNev, r.termekKiszerel);
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
        /// gets the list of GivenOut requests
        /// </summary>
        /// <returns>list of GivenOutRequests</returns>
        public RequestRecordGivenOut getChosenGivenOutRequest(int index)
        {
            return requestGivenOut[index];
        }
        #endregion
        //tested
        #region makes the changes between active-givenOut record-state
        /// <summary>
        /// books down the giving out process - charges the store by an amount
        /// </summary>
        /// <param name="quantId">strippingID, to target the request</param>
        /// <param name="amountAbout">the amount of the request, to charge the store</param>
        /// <param name="keresDatum">startDate of the request</param>
        /// <param name="keroUserId">userID, who wanted that</param>
        public void giveOutTheChosenProduct(int quantId, int amountAbout, 
            string keresDatum, int keroUserId)
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parent);
            modelRequestWrite = new RequestsModelWirteOut(dbci, parent);
            string finalAmountAfterTheGivingOut;
            string qualityIdThatUnderProcess;
            try
            {
                qualityIdThatUnderProcess = Convert.ToString(quantId);
                int amountBeforeTheChange = modelRequestRead.getTheActualAmountOfTheStripping(qualityIdThatUnderProcess);
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
                modelRequestWrite.deleteRequestTableGiveOutARecord(userIdOfPoerator, keresDatum.Replace(".","-"),
                    qualityIdThatUnderProcess, keroUserId.ToString(), finalAmountAfterTheGivingOut);
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
        /// <param name="keresDatum">stertDate, to target the request</param>
        /// <param name="keroUserId">userId, who wanted that request</param>
        public void getBackTheChosenProductThatWereGivenOut(int quantId, int amountAbout,
            string keresDatum, int keroUserId)
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parent);
            modelRequestWrite = new RequestsModelWirteOut(dbci, parent);
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
                modelRequestWrite.undeleteRequestTableGetBackARecord(userIdOfPoerator, keresDatum.Replace(".", "-"),
                    qualityIdThatUnderProcess, keroUserId.ToString(), finalAmountAfterTheGivingOut);
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
        /// <param name="reqStartDate">startDate of the target equest</param>
        /// <param name="reqQuantId">strippingId of the target equest</param>
        /// <param name="reqUserId">userId, who wanted that</param>
        public void deletAnActiveRequest(string reqStartDate, int reqQuantId, int reqUserId)
        {
            modelRequestWrite = new RequestsModelWirteOut(dbci, parent);
            try
            {
                modelRequestWrite.deleteRequestTableActiveRecord(userIdOfPoerator, reqStartDate.Replace(".", "-"),
                    reqQuantId.ToString(), reqUserId.ToString());
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
        /// <param name="modUserId">userId, who does that</param>
        /// <param name="reqStartDate">startDate of the target equest</param>
        /// <param name="reqQuantId">strippingId of the target equest</param>
        /// <param name="reqUserId">userId, who wanted that</param>
        public void undeletADeletedRequest(string reqStartDate, int reqQuantId, int reqUserId)
        {
            modelRequestWrite = new RequestsModelWirteOut(dbci, parent);
            try
            {
                modelRequestWrite.undeletRequestTableDeletedRecord(userIdOfPoerator, reqStartDate.Replace(".", "-"), 
                    reqQuantId.ToString(),
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
            modelRequestRead = new RequestsModelReadIn(dbci, parent);
            List<string> productsList = new List<string>();
            try
            {
                productListForUserChoose = modelRequestRead.getThePoolOfProducts();
                foreach (ProductToChoose pc in productListForUserChoose)
                {
                    productsList.Add(pc.termekNev);
                }

            }
            catch(ErrorServiceRequGetTheProdPool e)
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
        /// <param name="kivTermekNev"></param>
        /// <returns></returns>
        public int identifyTheProductIdInProductList(string kivTermekNev)
        {
            try
            {
                ProductToChoose temp = productListForUserChoose.Find(x => x.termekNev == kivTermekNev);
                return temp.termekMinId;
            }
            catch (Exception e)
            {
                throw new ErrorServiceRequests("Ismeretlen hiba történt  (ServReq_identifProd) " + e.Message);
            }

        }
        /// <summary>
        /// reads in the strippings of the chosen product
        /// </summary>
        /// <param name="kivTermekId">the product identifier</param>
        /// <returns>list of string with the stripping of the produvt</returns>
        public List<string> getThePoolOfStrippings(int kivTermekId)
        {
            modelRequestRead = new RequestsModelReadIn(dbci, parent);
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
            catch (ErrorServiceRequOrderGetTheStripPool e)
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
        public void modifyTheActiveRecord(int newAmount, int newQuantId, string oldStartDate, 
            int oldQuantId, int oldRequUserId)
        {
            try
            {
                modelRequestWrite = new RequestsModelWirteOut(dbci, parent);
                modelRequestWrite.updateRequestTableAtARecord(userIdOfPoerator, newAmount.ToString(), newQuantId.ToString(),
                    oldStartDate.Replace(".", "-"), oldQuantId.ToString(), oldRequUserId.ToString());
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
