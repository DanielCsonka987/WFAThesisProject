using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using WFAThesisProject.ServOrdering;
using System.Data;
using WFAThesisProject.UserNamePasswordManage;
using WFAThesisProject.GeneralExceptions;
using WFAThesisProject.Exceptions;

namespace WFAThesisProject
{
    public class ServiceOrdering
    {
        private UserConnDetails dbci;
        private Form parentMainWin;
        private string userIdOfOperator;

        private OrderingModellerReadIn modellerRead;
        private OrderingModellerWriteOut modellerWrite;
        private OrderingModellerPDF modelPDFCreate;

        private List<OrderingCancelled> cancelledList;
        private List<OrderingNoted> notedList;
        private List<OrderingBooked> bookedList;
        private List<OrderingArrived> arrivedList;
        private List<OrderingMissing> missingList;
        private List<OrderingFailed> failedList;

        private List<OrderingProdToChoose> prodList;
        private List<OrderingStrippingToChoose> stripList;

        public ServiceOrdering(UserConnDetails dbci, Form parent, string userId)
        {
            this.parentMainWin = parent;
            this.dbci = dbci;
            this.userIdOfOperator = userId;
        }
        //tested
        #region Cancelled data readIn
        /// <summary>
        /// seeks back the record from the list of cancelled chosen by user
        /// </summary>
        /// <param name="index">DB identifier of the record</param>
        /// <returns>OrderingCancelled container</returns>
        public OrderingCancelled getChosenCancelledOrdering(int index)
        {
            try
            {
                foreach (OrderingCancelled ordcan in cancelledList)
                {
                    if (ordcan.beszerId == index)
                        return ordcan;
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
            throw new ErrorServiceOrdering("A visszavont rendelések közötti keresés eredménytelen volt! (ServOrdCancSeek");
        }

        /// <summary>
        /// construct the DataTable of Cancelled orderings
        /// </summary>
        /// <returns>DataTable of CancelledOrderings</returns>
        public DataTable getCancelledOrdersDataTable()
        {

            DataTable table = new DataTable();
            table.Columns.Add("Srsz.", typeof(int));
            table.Columns.Add("Terméknév", typeof(string));
            table.Columns.Add("Kiszerelés", typeof(string));
            table.Columns.Add("Menyyiség", typeof(int));
            table.Columns.Add("Beszállító", typeof(string));
            table.Columns.Add("Bejegyzés", typeof(DateTime));
            table.Columns.Add("Törölve", typeof(string));
            for (int i = 0; i < 7; i++)
                table.Columns[i].ReadOnly = true;
            try
            {
                modellerRead = new OrderingModellerReadIn(dbci, parentMainWin);
                cancelledList = modellerRead.getListOfCancelledOrderings();
                foreach (OrderingCancelled rec in cancelledList)
                    table.Rows.Add(rec.beszerId, rec.termekNev, rec.termekKiszer, rec.beszerzMennyis, rec.termekBeszall,
                        rec.beszerzDatum, rec.beszerzLemond);
            }
            catch (ErrorServiceCreateDataList e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Adattábla alkotásánál ismeretlen hiba történt (ServOrdCanc) " + e.Message);
            }
            return table;
        }


        #endregion
        //tested
        #region Noted data readIn
        /// <summary>
        /// create the DataTable of noted orderings to show the user
        /// </summary>
        /// <returns></returns>
        public DataTable getNotedOrdersDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Srsz.", typeof(int));
            table.Columns.Add("Terméknév", typeof(string));
            table.Columns.Add("Kiszerlés", typeof(string));
            table.Columns.Add("Mennyiség", typeof(int));
            table.Columns.Add("Beszállító", typeof(string));
            table.Columns.Add("Bejegyzés", typeof(DateTime));
            table.Columns.Add("Rendelés", typeof(bool));
            for (int i = 0; i < 6; i++)
                table.Columns[i].ReadOnly = true;
            try
            {
                modellerRead = new OrderingModellerReadIn(dbci, parentMainWin);
                notedList = modellerRead.getListOfNotedOrderings();
                foreach (OrderingNoted rec in notedList)
                    table.Rows.Add(rec.beszerId, rec.termekNev, rec.termekKiszer, rec.beszerzMennyis,
                        rec.termekBeszall, rec.beszerzDatum, false);

            }
            catch (ErrorServiceCreateDataList e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Adattábla alkotásnál ismeretlen hiba történt (ServOrdNotedSeek) " + e.Message);
            }
            return table;
        }
        /// <summary>
        /// seeks back the record from the list of noted chosen by user
        /// </summary>
        /// <param name="index">index in the list</param>
        /// <returns>OrderingNoted container</returns>
        public OrderingNoted getChosenNotedOrdering(int index)
        {
            try
            {
                foreach (OrderingNoted rec in notedList)
                {
                    if (rec.beszerId == index)
                        return rec;
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("A listaelem keresésekor ismeretlen hiba (ServOrdNotedSeek) " + e.Message);
            }
            throw new ErrorServiceOrdering("A listaelem keresése sikertelen (ServOrdNodedSeek)");
        }

        #endregion
        //tested
        #region Booked data readIn
        /// <summary>
        /// creates the DataTable of Booked orderings to show the user
        /// </summary>
        /// <returns>DataTable of Bookeds</returns>
        public DataTable getBookedOrdersDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Srsz.", typeof(int));
            table.Columns.Add("Terméknév", typeof(string));
            table.Columns.Add("Kiszerelés", typeof(string));
            table.Columns.Add("Mennyiség", typeof(int));
            table.Columns.Add("Beszállító", typeof(string));
            table.Columns.Add("Bejegyezve", typeof(DateTime));
            table.Columns.Add("Megrendelve", typeof(DateTime));
            table.Columns.Add("Beérkezés", typeof(bool));
            for (int i = 0; i < 7; i++)
                table.Columns[i].ReadOnly = true;
            try
            {
                modellerRead = new OrderingModellerReadIn(dbci, parentMainWin);
                bookedList = modellerRead.getListOfBookedOrderings();
                foreach (OrderingBooked rec in bookedList)
                    table.Rows.Add(rec.beszerId, rec.termekNev, rec.termekKiszer, rec.beszerzMennyis, rec.termekBeszall,
                        rec.beszerzDatum, rec.beszerzRendeles, false);
            }
            catch (ErrorServiceCreateDataList e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Adattábla alkotásánál ismeretlen hiba történt (ServOrdBook) " + e.Message);
            }
            return table;
        }
        /// <summary>
        /// seeks back the record from the list of arrived chosen by user
        /// </summary>
        /// <param name="recId">the ordering record Id</param>
        /// <returns>OrderingBooked container</returns>
        public OrderingBooked getChosenBookedOrdering(int recId)
        {
            try
            {
                foreach (OrderingBooked rec in bookedList)
                {
                    if (rec.beszerId == recId)
                        return rec;
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("A listaelem keresésekor ismeretlen hiba (ServOrdBookSeek) " + e.Message);
            }
            throw new ErrorServiceOrdering("A listaelem keresése sikertelen! (ServOrdBookSeek)");

        }
        #endregion
        //tested
        #region Arrived data readIn
        /// <summary>
        /// creates the DataTable of ArrivedOrderings to show the user
        /// </summary>
        /// <returns>DataTable of arrived orderings</returns>
        public DataTable getArrivedOrdersDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Srsz.", typeof(int));
            table.Columns.Add("Terméknév", typeof(string));
            table.Columns.Add("Kiszerelés", typeof(string));
            table.Columns.Add("Mennyiség", typeof(int));
            table.Columns.Add("Beszállító", typeof(string));
            table.Columns.Add("Bejegyezve", typeof(DateTime));
            table.Columns.Add("Beérkezés ideje", typeof(DateTime));
            for (int i = 0; i < 7; i++)
                table.Columns[i].ReadOnly = true;
            try
            {
                modellerRead = new OrderingModellerReadIn(dbci, parentMainWin);
                arrivedList = modellerRead.getListOfArrivedOrderings();
                foreach (OrderingArrived rec in arrivedList)
                    table.Rows.Add(rec.beszerId, rec.termekNev, rec.termekKiszer, rec.beszerzMennyis, rec.termekBeszall,
                        rec.beszerzDatum, rec.beszerzErkezes);
            }
            catch (ErrorServiceCreateDataList e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Adattábla alkotásánál ismeretlen hiba történt (ServOrdBook) " + e.Message);
            }
            return table;
        }

        public OrderingArrived getChosenArrivedOrdering(int index)
        {
            try
            {
                foreach (OrderingArrived rec in arrivedList)
                {
                    if (rec.beszerId == index)
                        return rec;
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("A listaelem keresésekor ismeretlen hiba (ServOrdArrivSeek) " + e.Message);
            }
            throw new ErrorServiceOrdering("A listaelem keresése sikertelen! (ServOrdArrivSeek)");
        }

        #endregion
        //tested
        #region Missing data readIn
        /// <summary>
        /// creates the DataTable of MissingOrderings to show the user
        /// </summary>
        /// <returns>DataTable of Missings</returns>
        public DataTable getMissingOrdersDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Srsz.", typeof(int));
            table.Columns.Add("Terméknév", typeof(string));
            table.Columns.Add("Kiszerelés", typeof(string));
            table.Columns.Add("Mennyiség", typeof(int));
            table.Columns.Add("Beszállító", typeof(string));
            table.Columns.Add("Bejegyezve", typeof(DateTime));
            table.Columns.Add("Várható érkezés", typeof(DateTime));
            for (int i = 0; i < 7; i++)
                table.Columns[i].ReadOnly = true;
            try
            {
                modellerRead = new OrderingModellerReadIn(dbci, parentMainWin);
                missingList = modellerRead.getListOfMissingOrderings();
                foreach (OrderingMissing rec in missingList)
                    table.Rows.Add(rec.beszerId, rec.termekNev, rec.termekKiszer, rec.beszerzMennyis, rec.termekBeszall,
                        rec.beszerzDatum, rec.beszMegujitasDatuma);
            }
            catch (ErrorServiceCreateDataList e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Adattábla alkotásánál ismeretlen hiba történt (ServOrdBook) " + e.Message);
            }
            return table;
        }
        /// <summary>
        /// seeks back the record from the list of missing chosen by user
        /// </summary>
        /// <param name="index">record id that was chosen</param>
        /// <returns>Ordering Mission container</returns>
        public OrderingMissing getChosenMissingOrdering(int index)
        {
            try
            {
                foreach (OrderingMissing rec in missingList)
                {
                    if (rec.beszerId == index)
                        return rec;
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("A listaelem keresésekor ismeretlen hiba (ServOrdMissSeek) " + e.Message);
            }
            throw new ErrorServiceOrdering("A listaelem keresése sikertelen! (ServOrdMissSeek)");
        }

        #endregion
        //tested
        #region Failed data readIn
        /// <summary>
        /// creates DataTable of FailedOrderings to show the user
        /// </summary>
        /// <returns>DataTable of faileds</returns>
        public DataTable getFailedOrdersDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Srsz.", typeof(int));
            table.Columns.Add("Terméknév", typeof(string));
            table.Columns.Add("Kiszerelés", typeof(string));
            table.Columns.Add("Mennyiség", typeof(int));
            table.Columns.Add("Beszállító", typeof(string));
            table.Columns.Add("Bejegyezve", typeof(DateTime));
            table.Columns.Add("Törölve", typeof(DateTime));
            for (int i = 0; i < 7; i++)
                table.Columns[i].ReadOnly = true;
            try
            {
                modellerRead = new OrderingModellerReadIn(dbci, parentMainWin);
                failedList = modellerRead.getListOfFailOrderings();
                foreach (OrderingFailed rec in failedList)
                    table.Rows.Add(rec.beszerId, rec.termekNev, rec.termekKiszer, rec.beszerzMennyis, rec.termekBeszall,
                        rec.beszerzDatum, rec.beszVeglTorolRend);
            }
            catch (ErrorServiceCreateDataList e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Adattábla alkotásánál ismeretlen hiba történt (ServOrdBook) " + e.Message);
            }
            return table;
        }
        /// <summary>
        /// seeks back the record from the list of failsd chosen by user
        /// </summary>
        /// <param name="index">Id of the chosen record</param>
        /// <returns>Failed container</returns>
        public OrderingFailed getChosenFailedOrdering(int index)
        {
            try
            {
                foreach (OrderingFailed rec in failedList)
                {
                    if (rec.beszerId == index)
                        return rec;
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("A listaelem keresésekor ismeretlen hiba (ServOrdFailSeek) " + e.Message);
            }
            throw new ErrorServiceOrdering("A listaelem keresése sikertelen! (ServOrdFailSeek)");
        }

        #endregion
        //tested
        #region gives data at Modify ordering datas - products
        /// <summary>
        /// collects the pool of productions
        /// </summary>
        /// <returns>the list of product names</returns>
        public List<string> getThePoolOfProductions_ProdSubcontrKeys()
        {
            List<string> listProdName = new List<string>();
            try
            {
                modellerRead = new OrderingModellerReadIn(dbci, parentMainWin);
                prodList = modellerRead.getProdPoolOfOrderingChoose();
                foreach (OrderingProdToChoose row in prodList)
                    listProdName.Add(row.termekNev+"_"+row.beszallitoId);
            }
            catch (ErrorServiceGetTheProdPool e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Isermetlen hiba történt (ServOrdProdCollect) " + e.Message);
            }
            return listProdName;
        }
        /// <summary>
        /// finds the chosen products id
        /// </summary>
        /// <param name="chosenProd">prod name and its subcontrs</param>
        /// <returns>spec. prod id</returns>
        public int getTheChosenProdID(string prodNameAndItsSubcontr)
        {
            try
            {
                string[] parts = prodNameAndItsSubcontr.Split('_');
                foreach (OrderingProdToChoose cont in prodList)
                {
                    if (cont.termekNev == parts[0] && cont.beszallitoId == parts[1])
                        return cont.termekId;
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Hiba történt a keresésnél (ServOrdProdIdSeek) " + e.Message);
            }
            throw new ErrorServiceOrdering("A listaelem keresése eredménytelen (ServOrdPrdIdSeek)");
        }
        /// <summary>
        /// finds the subcontractor name of the chosen product
        /// </summary>
        /// <param name="prodNameAndItsSubcontr"></param>
        /// <returns></returns>
        public string getTheSubcontrOfChosenProd(int prodId)
        {
            try
            {
                foreach (OrderingProdToChoose cont in prodList)
                {
                    if (cont.termekId == prodId)
                        return cont.beszallitoId;
                }
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Hiba történt a keresésnél (ServOrdProdSubcontrSeek) " + e.Message);
            }
            throw new ErrorServiceOrdering("A listaelem keresése eredménytelen (ServOrdProdSubcontrSeek)");
        }

        #endregion
        //tested
        #region gives data at Modify ordering datas - strippings
        /// <summary>
        /// collect the stripping pool of chosen product
        /// </summary>
        /// <param name="prodId"></param>
        /// <returns></returns>
        public List<string> getThePoolOfStrippings(int prodId)
        {
            List<string> listStripName = new List<string>();
            try
            {
                modellerRead = new OrderingModellerReadIn(dbci, parentMainWin);
                stripList = modellerRead.getStripPoolOfOrderingChoose(prodId.ToString());
                if (stripList.Count == 0)
                {
                    listStripName.Add("Nincs kiszerelés");
                    return listStripName;
                }
                foreach (OrderingStrippingToChoose row in stripList)
                    listStripName.Add(row.termekkiszerel.ToString());
            }
            catch (ErrorServiceGetTheStripPool e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Ismeretlen hiba történt (ServOrdStripCollect) " + e.Message);
            }
            return listStripName;
        }
        /// <summary>
        /// finds the spec. id of chosen stripping
        /// </summary>
        /// <param name="chosenStripName">the name of the spec. srtipping</param>
        /// <returns>id of strippings</returns>
        public int getTheChosenStrippingID(string chosenStripName)
        {
            try
            {
                int tempStripName = Convert.ToInt32(chosenStripName);
                foreach (OrderingStrippingToChoose row in stripList)
                {
                    if (row.termekkiszerel == tempStripName)
                        return row.termekQuantId;
                }

            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Ismeretlen hiba történt (ServOrdStripIDSeek) " + e.Message);
            }
            throw new ErrorServiceOrdering("A listaelem keresése sikertelen (ServOrdStripIDSeek)");
        }
        /// <summary>
        /// collets the side details of chosen stripping from listOfStrippings
        /// </summary>
        /// <param name="durringModify_ChosenStrippingID">the name of stripping</param>
        /// <returns>code_subcont pair of the spec stripping</returns>
        public string[] getThePlaceBarcodeOfChosenStripping(int tempChosenStrippingID)
        {
            try
            {
                string[] codeAndPlace = new string[2];
                foreach (OrderingStrippingToChoose row in stripList)
                {
                    if (row.termekQuantId == tempChosenStrippingID)
                    {
                        codeAndPlace[0] = row.termekKod;
                        codeAndPlace[1] = row.termekHely;
                        return codeAndPlace;
                    }
                }
                    
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Ismeretlen hiba történt (ServOrdStripDataSeek) " + e.Message);
            }
            throw new ErrorServiceOrdering("A listaelem keresése sikertelen (ServOrdStripDataSeek)");
        }



        #endregion
        //tested
        #region manage to change state of bunch records - noted->booked / booked->arrived
        /// <summary>
        /// sets the marked records to change validity 2 to 3
        /// </summary>
        /// <param name="listToChangeState">list of id of records</param>
        public void setListOfBookedAsArrived(List<int> listToChangeState)
        {
            try
            {
                List<string> listToChange = new List<string>();
                foreach (int num in listToChangeState)
                    listToChange.Add(num.ToString());
                modellerWrite = new OrderingModellerWriteOut(dbci, parentMainWin);
                modellerWrite.setTheseRecordsAsArrivedBunch(listToChange);
            }
            catch (ErrorOrderingSetNotedAsBooked e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
            catch(Exception e)
            {
                throw new ErrorServiceOrdering("Ismertlen hiba történt (ServOrdChangeNoted) " + e.Message);
            }
        }
        /// <summary>
        /// sets the marked records to change validity 1 to 2
        /// </summary>
        /// <param name="listToChangeState">list of id of records</param>
        public void setListOfNotedRecordsAsBooked(List<int> listToChangeState)
        {
            try
            {
                List<string> listToChange = new List<string>();
                foreach (int num in listToChangeState)
                    listToChange.Add(num.ToString());
                modellerWrite = new OrderingModellerWriteOut(dbci, parentMainWin);
                modellerWrite.setTheseRecordAsBookedBunch(listToChange);
            }
            catch (ErrorOrderingSetBookedAsArrived e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Ismertlen hiba történt (ServOrdChangeBooked) " + e.Message);
            }
        }
        /// <summary>
        /// ordering list PDF creation process
        /// </summary>
        /// <param name="listThatNeedToBePDF">the important record content of Noted</param>
        public void setChosenRecordsToPDF(SetOfUserDetails soud, List<OrderingNoted> listThatNeedToBePDF)
        {
            try
            {
                modelPDFCreate = new OrderingModellerPDF(soud, dbci.output, listThatNeedToBePDF);
            }
            catch (ErrorMigraDocFileCreation e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
            catch (Exception e)
            {
                throw new ErrorServiceOrdering("Ismertlen hiba történt (ServOrdPDFBooking) " + e.Message);
            }
        }
        #endregion
        //tested
        #region simple DB altering
        /// <summary>
        /// maintain the noted record cancellation
        /// </summary>
        /// <param name="orderingId">DB identifier of record</param>
        public void makeCancelledNotedRecord(int orderingId)
        {
            try
            {
                modellerWrite = new OrderingModellerWriteOut(dbci, parentMainWin);
                modellerWrite.setCancelTheChosenNotedRec(orderingId.ToString(), userIdOfOperator);
            }
            catch (ErrorServiceDeleteRecord e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
        }
        /// <summary>
        /// maintain renew to noted the cancelled record
        /// </summary>
        /// <param name="orderingId">DB identifier of record</param>
        public void makeRenewCancelledRecord(int orderingId)
        {
            try
            {
                modellerWrite = new OrderingModellerWriteOut(dbci, parentMainWin);
                modellerWrite.setRenewCancelledRecordToNoted(orderingId.ToString(), userIdOfOperator);
            }
            catch (ErrorServiceRenewRecord e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
        }
        /// <summary>
        /// maintain the delet of booked or missing-booked record
        /// </summary>
        /// <param name="orderingId">DB identifier of record</param>
        public void makeFailedTheBookedOrMissingRecord(int orderingId)
        {
            try
            {
                modellerWrite = new OrderingModellerWriteOut(dbci, parentMainWin);
                modellerWrite.setTheBookedOrMissingToFailed(orderingId.ToString(), userIdOfOperator);
            }
            catch (ErrorOrderingSetFailed e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
        }
        /// <summary>
        /// maintain the partly arriving - first finish the oldone, if there is remaining create another missing record
        /// </summary>
        /// <param name="orderingId">the old record DB identifier</param>
        /// <param name="strippId">the stripping of the ordering</param>
        /// <param name="oldAmount">the original amount</param>
        /// <param name="secondAmount">the arrived amount</param>
        /// <param name="oldOrdererUserId">originally, who ordered</param>
        /// <param name="oldDate">when originally ordered</param>
        public void makeRecordPartlyArrived(int orderingId, int strippId, int oldAmount, int secondAmount,
            int oldOrdererUserId, string oldDate)
        {
            int remainedAmount = oldAmount - secondAmount;
            try
            {
                modellerWrite = new OrderingModellerWriteOut(dbci, parentMainWin);
                modellerWrite.setPartlyArrivedBooked_MissingRecord(orderingId.ToString(), secondAmount.ToString(),
                    userIdOfOperator);
            }
            catch (ErrorOrderingSetPartlyArrivedRecord e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
            if (remainedAmount > 0)
            {
                try
                {
                    modellerWrite.createNewMissingRecord(strippId.ToString(), oldDate, remainedAmount.ToString(), 
                        oldOrdererUserId.ToString(), userIdOfOperator);
                }
                catch (ErrorOrderingSetMissingRecord e)
                {
                    throw new ErrorServiceOrdering(e.Message);
                }
            }

        }

        /// <summary>
        /// maintain the change of missing record to arrived
        /// </summary>
        /// <param name="orderingId">DB identifier of record</param>
        public void makeArrivedTheBookedOrMissingRecord(int orderingId)
        {
            try
            {
                modellerWrite = new OrderingModellerWriteOut(dbci, parentMainWin);
                modellerWrite.setArrivedTheMissingRecord(orderingId.ToString(), userIdOfOperator);
            }
            catch (ErrorOrderingSetBookedAsArrived e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
        }
        /// <summary>
        /// maintaion the change nodet record in stripping and amount
        /// </summary>
        /// <param name="orderingId">DB identifier</param>
        /// <param name="stripId">stripping ID</param>
        /// <param name="newAmount">the new amount</param>
        public void makeModifyNotedRecord(int orderingId, int stripId, int newAmount)
        {
            try
            {
                modellerWrite = new OrderingModellerWriteOut(dbci, parentMainWin);
                modellerWrite.setModifyNotedRecord(orderingId.ToString(), stripId.ToString(), newAmount.ToString(), userIdOfOperator);
            }
            catch (ErrorServiceUpdateRecord e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
        }
        /// <summary>
        /// maintain the creation of new ordering record that will be noted
        /// </summary>
        /// <param name="stripIdOfWanted">DB identifier of strippong</param>
        /// <param name="newAmount">the amount of that</param>
        public  void createNewNotedRecord(int stripIdOfWanted, int newAmount)
        {
            try
            {
                modellerWrite = new OrderingModellerWriteOut(dbci, parentMainWin);
                modellerWrite.setCreateNewOrderingRecordAsNoted(stripIdOfWanted.ToString(), newAmount.ToString(), userIdOfOperator);
            }
            catch (ErrorServiceNewRecord e)
            {
                throw new ErrorServiceOrdering(e.Message);
            }
        }
        #endregion
    }
}
