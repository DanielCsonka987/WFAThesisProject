using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.ServOrdering;
using WFAThesisProject.UserNamePasswordManage;

namespace WFAThesisProject
{
    public class ServiceOrdBookArriveWinController
    {
        private enum RecordType { NOTED, BOOKED }

        private Control buttonOk;
        private Control buttonRenew;
        private Control labelTitle;
        private MetroFramework.Controls.MetroGrid mgridBookArriv;

        private Form parentBookArrivWin;
        private ServiceOrdering servOrdering;
        private SetOfUserDetails soud;
        private RecordType actWorkWith;
        private DataTable table;
        private List<OrderingNoted> listNoted;
        private List<OrderingBooked> listBooked;

        public ServiceOrdBookArriveWinController(List<OrderingNoted> listNoted, Form parentOrdBookAriv, 
            ServiceOrdering servOrd, SetOfUserDetails soud)
        {
            this.parentBookArrivWin = parentOrdBookAriv;
            this.servOrdering = servOrd;
            this.soud = soud;
            actWorkWith = RecordType.NOTED;
            catchControls();
            this.listNoted = listNoted;
            labelTitle.Text = "Rendelési lista készítése";
            executeLoadInAllTheRecords();
        }

        public ServiceOrdBookArriveWinController(List<OrderingBooked> listBooked, Form parentOrdBookAriv, ServiceOrdering servOrd)
        {
            this.parentBookArrivWin = parentOrdBookAriv;
            this.servOrdering = servOrd;
            actWorkWith = RecordType.BOOKED;
            catchControls();
            this.listBooked = listBooked;
            labelTitle.Text = "Átvételi lista ellenőrzése";
            executeLoadInAllTheRecords();
        }

        private void catchControls()
        {
            buttonOk = parentBookArrivWin.Controls.Find("mTileOk", true).First();
            buttonRenew = parentBookArrivWin.Controls.Find("mTileRenew", true).First();
            labelTitle = parentBookArrivWin.Controls.Find("mLabelTitle", true).First();
            mgridBookArriv = (MetroFramework.Controls.MetroGrid)parentBookArrivWin.Controls.Find("mGrid", true).First();
        }

        #region loadIn the records to DataGrid

        public void executeLoadInAllTheRecords()
        {
            if (actWorkWith == RecordType.NOTED)
            {
                createProperBasicDataTable();
                fillAllInfosToGridWithNoted();
            }
            if (actWorkWith == RecordType.BOOKED)
            {
                createProperBasicDataTable();
                fillAllInfosToGridWithBooked();
            }
        }

        private DataTable createProperBasicDataTable()
        {
            table = new DataTable();
            if (actWorkWith == RecordType.NOTED)
            {
                table.Columns.Add("Srsz.", typeof(int));
                table.Columns.Add("Terméknév", typeof(string));
                table.Columns.Add("Kiszerlés", typeof(string));
                table.Columns.Add("Mennyiség", typeof(int));
                table.Columns.Add("Beszállító", typeof(string));
                table.Columns.Add("Termékkód", typeof(string));
                table.Columns.Add("Bejegyzés", typeof(DateTime));
            }
            if (actWorkWith == RecordType.BOOKED)
            {
                table.Columns.Add("Srsz.", typeof(int));
                table.Columns.Add("Terméknév", typeof(string));
                table.Columns.Add("Kiszerlés", typeof(string));
                table.Columns.Add("Mennyiség", typeof(int));
                table.Columns.Add("Beszállító", typeof(string));
                table.Columns.Add("Termékkód", typeof(string));
                table.Columns.Add("Bejegyzés", typeof(DateTime));
                table.Columns.Add("Megrendelve", typeof(DateTime));
            }
            return table;
        }

        private void fillAllInfosToGridWithNoted()
        {
            table = createProperBasicDataTable();
            foreach (OrderingNoted rec in listNoted)
                table.Rows.Add(rec.beszerId, rec.termekNev, rec.termekKiszer,
                    rec.beszerzMennyis, rec.termekBeszall, rec.termekKod, rec.beszerzDatum);
            mgridBookArriv.DataSource = table;
        }

        private void fillAllInfosToGridWithBooked()
        {
            DataTable table = createProperBasicDataTable();
            foreach (OrderingBooked rec in listBooked)
                table.Rows.Add(rec.beszerId, rec.termekNev, rec.termekKiszer,
                    rec.beszerzMennyis, rec.termekBeszall, rec.termekKod, rec.beszerzDatum, rec.beszerzRendeles);
            mgridBookArriv.DataSource = table;
        }
        #endregion
        /// <summary>
        /// executes the user remove instruction
        /// </summary>
        public void executeRemoveTheSelectedOne()
        {
            int rowToDeletFromHere = mgridBookArriv.SelectedRows[0].Index;
            if (rowToDeletFromHere != -1)
            {
                mgridBookArriv.Rows.RemoveAt(rowToDeletFromHere);
            }
        }

        #region executers of Booked/arrived process

        /// <summary>
        /// process of ordering, receiving strippings
        /// </summary>
        public void executeDBModify()
        {
            List<int> listOfIdThetNeedToProcess =  collectWantedRecordIDs();
            if (listOfIdThetNeedToProcess.Count > 0)
            {
                try
                {
                    if (actWorkWith == RecordType.NOTED)
                    {

                        List<OrderingNoted> listThatNeedToBePDF = collectTheSpecificRecords(listOfIdThetNeedToProcess);
                        servOrdering.setChosenRecordsToPDF(soud, listThatNeedToBePDF);
                        servOrdering.setListOfNotedRecordsAsBooked(listOfIdThetNeedToProcess);
                        succsesHandle("A rendelési művelet sikerült!");
                    }
                    if (actWorkWith == RecordType.BOOKED)
                    {
                        servOrdering.setListOfBookedAsArrived(listOfIdThetNeedToProcess);
                        succsesHandle("Az átvételi művelet sikerült!");
                        parentBookArrivWin.Close();
                    }
                }
                catch (ErrorServiceOrdering e)
                {
                    errorHandle(e.Message);
                }
                catch (Exception e)
                {
                    errorHandle("Ismeretlen hiba történt (ContrOrdBA) " + e.Message);
                }
            }
        }
        /// <summary>
        /// collects the Id-s of records, the user wants to change state
        /// </summary>
        /// <returns>list of id-s in string</returns>
        private List<int> collectWantedRecordIDs()
        {
            List<int> recIdList = new List<int>();
            foreach (DataGridViewRow row in mgridBookArriv.Rows)
            {
                recIdList.Add((int)row.Cells[0].Value);
            }
            return recIdList;
        }
        /// <summary>
        /// collects the needed record form main OrderingNoted list
        /// </summary>
        /// <param name="listIndexesWhichWriteOutToPDF">chosen indexes</param>
        /// <returns>list of OrdNotedRecords, that nedded to order</returns>
        private List<OrderingNoted> collectTheSpecificRecords(List<int> listIndexesWhichWriteOutToPDF)
        {
            List<OrderingNoted> listToPDF = new List<OrderingNoted>();
            foreach (OrderingNoted recInMainList in listNoted)
            {
                foreach(int recId in listIndexesWhichWriteOutToPDF)
                {
                    if (recInMainList.beszerId == recId)
                        listToPDF.Add(recInMainList);
                }
            }
            return listToPDF;
        }
        #endregion
        /// <summary>
        /// errorhandle of book-arriving window
        /// </summary>
        /// <param name="message">the errormessage</param>
        private void errorHandle(string message)
        {
            MetroFramework.MetroMessageBox.Show(parentBookArrivWin, message, "Figyelmezteés", MessageBoxButtons.OK,
                MessageBoxIcon.Error, 200);
        }
        /// <summary>
        /// successhandle of book-arriving window
        /// </summary>
        /// <param name="message"></param>
        private void succsesHandle(string message)
        {
            MetroFramework.MetroMessageBox.Show(parentBookArrivWin, message, "Figyelmezteés", MessageBoxButtons.OK,
                MessageBoxIcon.Information, 200);
        }
    }
}
