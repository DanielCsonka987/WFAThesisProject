using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFAThesisProject.ServOrdering;
using WFAThesisProject.UserNamePasswordManage;

namespace WFAThesisProject
{
    public partial class ServiceOrderingWinController
    {
        #region adjust the window to create new ordering record
        /// <summary>
        /// defines the steps when new ordering record is needed
        /// </summary>
        /// <param name="soud">details of operator-user</param>
        private void adjutTheFieldsWithProperDatas(SetOfUserDetails soud)
        {
            if (windoProcessMode == OrderingWindowPurpose.NEW)
            {
                adjustFieldsAsNewRecNeeds();
                fillInTheBasicInfos(soud);
                labelInfoBar.Text = "Új rendelési tétel bejegyzése";
                adjustFieldsNewBasicModify();
                adjustFieldsToChangeProdStrip();
                buttonOk.Text = "Létrehozás";
                buttonOk.Visible = true;

                executeChooseModifyEvent();
            }
        }
        /// <summary>
        /// adjust the fields as a new record creation needs
        /// </summary>
        private void adjustFieldsAsNewRecNeeds()
        {
            labelFinalDate.Visible = false;
            textBoxFinalDate.Visible = false;
            labelModifierArea.Visible = false;
            textBoxUserModif.Visible = false;
        }
        /// <summary>
        /// fills up the fields to help the user
        /// </summary>
        /// <param name="soud">details of the operator user</param>
        private void fillInTheBasicInfos(SetOfUserDetails soud)
        {
            textBoxStartDate.Text = DateTime.Today.Year + "." + DateTime.Today.Month + "." + DateTime.Today.Day;
            //textBoxFinalDate.Text = "";
            textBoxUserOrder.Text = soud.userLastName + " " +soud.userFirstName;
            //textBoxUserModif.Text = "";

            textBoxProdcode.Text = "";
            textBoxOrdPlace.Text = "";
            textBoxOrdAmount.Text = "";
            textBoxSubcontr.Text = "";
            checkBoxNewProd.Checked = true;
        }
        #endregion

        #region adjuster of CancelledOrders
        /// <summary>
        /// adjust the field with cancelled datas and prepare the processes
        /// </summary>
        /// <param name="rec">the Cancelled container of record</param>
        private void adjutTheFieldsWithProperDatas(OrderingCancelled rec)
        {
            fillUpTheFieldsAsCancelled(rec);
            ajdustFieldsAsCancelledNeeds();
            if (windoProcessMode == OrderingWindowPurpose.DETAILS)
            {
                adjustFieldsReadOnlyStrict();
                buttonOk.Visible = false;
            }
            else if (windoProcessMode == OrderingWindowPurpose.RENEW)  //make it noted
            {
                adjustFieldsReadOnlyStrict();
                buttonOk.Visible = true;
                buttonOk.Text = "Visszaállítás";
            }
        }
        /// <summary>
        /// fills up the fields as Cancelled record needs
        /// </summary>
        /// <param name="rec">datacontainer</param>
        private void fillUpTheFieldsAsCancelled(OrderingCancelled rec)
        {
            labelInfoBar.Text = "Visszavont tétel";
            textBoxStartDate.Text = rec.beszerzDatum;
            labelFinalDate.Text += " lemondása:";
            textBoxFinalDate.Text = rec.beszerzLemond;
            textBoxUserOrder.Text = rec.redeloNev;
            textBoxUserModif.Text = rec.modositNev;

            comboBoxOrdProd.Items.Add(rec.modositNev);
            comboBoxOrdProd.SelectedIndex = 0;
            comboBoxOrdStrip.Items.Add(rec.termekKiszer);
            comboBoxOrdStrip.SelectedIndex = 0;

            textBoxOrdAmount.Text = rec.beszerzMennyis.ToString();
            textBoxSubcontr.Text = rec.termekBeszall;
            textBoxOrdPlace.Text = rec.termekKod;
            textBoxProdcode.Text = rec.termekKod;

            orderingId = rec.beszerId;
        }

        private void ajdustFieldsAsCancelledNeeds()
        {
            labelPlacing.Visible = false;
            textBoxOrdPlace.Visible = false;
            labelArrivedAmount.Visible = false;
            textBoxOrdArrivAmount.Visible = false;
            labelPlacing.Visible = false;
            textBoxOrdPlace.Visible = false;
        }
        #endregion

        #region adjusters of NotedOrders
        /// <summary>
        /// defines the steps when noted record is handled
        /// </summary>
        /// <param name="rec"></param>
        private void adjutTheFieldsWithProperDatas(OrderingNoted rec)
        {
            fillUpTheNotedRecordToFields(rec);
            labelFinalDate.Visible = false;
            textBoxFinalDate.Visible = false;
            if (windoProcessMode == OrderingWindowPurpose.DETAILS)
            {
                adjustFieldsReadOnlyStrict();
                buttonOk.Visible = false;
            }
            else if(windoProcessMode == OrderingWindowPurpose.CANCEL) //make it cancelled
            {
                adjustFieldsReadOnlyStrict();
                buttonOk.Text = "Visszavonás";
            }
            else if (windoProcessMode == OrderingWindowPurpose.MODFIY)
            {
                adjustFieldsNewBasicModify();
                buttonOk.Text = "Módosítás";
                checkBoxNewProd.Visible = true;

                oldProductName = rec.termekNev;
                oldStrippingName = rec.termekKiszer.ToString();
                oldSubcontractor = rec.termekBeszall;
                oldBarcode = rec.termekKod;
                oldPlacing = rec.termekHely;
            }
        }
        /// <summary>
        /// adjust the data fields to modify the content
        /// -> comboboxes; 1st amount areas
        ///  - Case of Modify, PartlyMissed and New
        /// </summary>
        private void adjustFieldsNewBasicModify()
        {
            textBoxUserOrder.ReadOnly = true;
            textBoxUserModif.ReadOnly = true;
            textBoxStartDate.ReadOnly = true;
            textBoxFinalDate.ReadOnly = true;

            comboBoxOrdProd.Enabled = false;
            comboBoxOrdStrip.Enabled = false;
            textBoxOrdAmount.ReadOnly = false;

            textBoxSubcontr.ReadOnly = true;
            textBoxProdcode.ReadOnly = true;
            textBoxOrdPlace.ReadOnly = true;
        }
        /// <summary>
        /// fills up the fields with proper datas as Noted needs
        /// </summary>
        /// <param name="rec">data container</param>
        private void fillUpTheNotedRecordToFields(OrderingNoted rec)
        {
            labelInfoBar.Text = "Rendelésre bejegyzett tétel";
            //labelFinalDate.Text += "";
            textBoxUserOrder.Text = rec.redeloNev;
            textBoxUserModif.Text = rec.modositNev;
            textBoxStartDate.Text = rec.beszerzDatum;

            comboBoxOrdProd.Items.Add(rec.termekNev);
            comboBoxOrdProd.SelectedIndex = 0;
            comboBoxOrdStrip.Items.Add(rec.termekKiszer);
            comboBoxOrdStrip.SelectedIndex = 0;

            textBoxSubcontr.Text = rec.termekBeszall;
            textBoxProdcode.Text = rec.termekKod;
            textBoxOrdAmount.Text = rec.beszerzMennyis.ToString();
            textBoxOrdPlace.Text = rec.termekHely;

            orderingId = rec.beszerId;
            oldStripId = rec.kiszerelId;
        }
        #endregion

        #region adjusters of BookedOrders
        /// <summary>
        /// defines the steps while Booked record is handled
        /// </summary>
        /// <param name="rec">data container</param>
        private void adjutTheFieldsWithProperDatas(OrderingBooked rec)
        {
            fillUpBookedRecordToFields(rec);
            if (windoProcessMode == OrderingWindowPurpose.DETAILS)
            {
                buttonOk.Visible = false;
                adjustFieldsReadOnlyStrict();
            }
            else if(windoProcessMode == OrderingWindowPurpose.MakeItPARTLYARRIVED)
            {
                adjustFieldsPartlyArriving();
                buttonOk.Visible = true;
                buttonOk.Text = "Részben megjött";
            }
            else if (windoProcessMode == OrderingWindowPurpose.MakeItFAILED)
            {
                adjustFieldsReadOnlyStrict();
                buttonOk.Visible = true;
                buttonOk.Text = "Lemondás";
            }
            /*      //insted of this, bunch arriving is maintained in case of Booked view
            else if (windoProcessMode == OrderingWindowPurpose.MakeItARRIVED)
            {
                adjustFieldsReadOnlyStrict();
                buttonOk.Visible = true;
                buttonOk.Text = "Megérkezett";
            }
            */
        }
        /// <summary>
        /// fills the proper datas into fields as Booked needs
        /// </summary>
        /// <param name="rec">data container</param>
        private void fillUpBookedRecordToFields(OrderingBooked rec)
        {
            labelInfoBar.Text = "Megrendelt tétel";
            labelFinalDate.Text += " elküldve:";
            textBoxFinalDate.Text = rec.beszerzRendeles;
            textBoxUserOrder.Text = rec.redeloNev;
            textBoxUserModif.Text = rec.modositNev;
            textBoxStartDate.Text = rec.beszerzDatum;

            comboBoxOrdProd.Items.Add(rec.termekNev);
            comboBoxOrdProd.SelectedIndex = 0;
            comboBoxOrdStrip.Items.Add(rec.termekKiszer);
            comboBoxOrdStrip.SelectedIndex = 0;

            textBoxSubcontr.Text = rec.termekBeszall;
            textBoxProdcode.Text = rec.termekKod;
            textBoxOrdAmount.Text = rec.beszerzMennyis.ToString();
            textBoxOrdPlace.Text = rec.termekHely;

            orderingId = rec.beszerId;
            oldOrdererUserId = rec.rendeloId;
            oldOrderingDate = rec.beszerzDatum;
            oldStripId = rec.kiszerelId;
        }
        #endregion

        #region adjusters of ArrivesOrders
        /// <summary>
        /// defines the steps when an arrived record handle is needed
        /// </summary>
        /// <param name="rec">datacontainer</param>
        private void adjutTheFieldsWithProperDatas(OrderingArrived rec)
        {
            if (windoProcessMode == OrderingWindowPurpose.DETAILS)
            {
                fillUpArrivedRecordToFields(rec);
                adjustFieldsReadOnlyStrict();
                buttonOk.Visible = false;
                labelPlacing.Visible = false;
                textBoxOrdPlace.Visible = false;
            }
        }
        /// <summary>
        /// fills up the fields as arrived record needs
        /// </summary>
        /// <param name="rec">datacontainer</param>
        private void fillUpArrivedRecordToFields(OrderingArrived rec)
        {
            labelInfoBar.Text = "Beérkezett rendelési tétel";
            labelFinalDate.Text += " átvétele";
            textBoxUserOrder.Text = rec.redeloNev;
            labelModifierArea.Text = "Átvevő:";
            textBoxUserModif.Text = rec.modositNev;
            textBoxStartDate.Text = rec.beszerzDatum;
            textBoxFinalDate.Text = rec.beszerzErkezes;

            comboBoxOrdProd.Items.Add(rec.termekNev);
            comboBoxOrdProd.SelectedIndex = 0;
            comboBoxOrdStrip.Items.Add(rec.termekKiszer);
            comboBoxOrdStrip.SelectedIndex = 0;

            textBoxSubcontr.Text = rec.termekBeszall;
            textBoxProdcode.Text = rec.termekKod;
            textBoxOrdAmount.Text = rec.beszerzMennyis.ToString();
            textBoxOrdPlace.Text = rec.termekHely;
        }
        #endregion

        #region adjusters of MissingOrders
        /// <summary>
        /// defines the steps when a missing order handle is needed
        /// </summary>
        /// <param name="rec">datacontainer</param>
        private void adjutTheFieldsWithProperDatas(OrderingMissing rec)
        {
            fillUpMissingRecodToFields(rec);
            if (windoProcessMode == OrderingWindowPurpose.DETAILS)
            {
                buttonOk.Visible = false;
                adjustFieldsReadOnlyStrict();
            }
            else if (windoProcessMode == OrderingWindowPurpose.MakeItARRIVED)
            {
                adjustFieldsReadOnlyStrict();
                buttonOk.Text = "Megérkezett";
                buttonOk.Visible = true;

            }
            else if (windoProcessMode == OrderingWindowPurpose.MakeItPARTLYARRIVED)
            {
                adjustFieldsPartlyArriving();
                buttonOk.Text = "Részben megérkezett";
                buttonOk.Visible = true;
            }
            else if (windoProcessMode == OrderingWindowPurpose.MakeItFAILED)
            {
                adjustFieldsReadOnlyStrict();
                buttonOk.Text = "Lemodás";
                buttonOk.Visible = true;
            }
        }

        /// <summary>
        /// fill up the fields with missing order datas
        /// </summary>
        /// <param name="rec">the OrderingMissing container</param>
        private void fillUpMissingRecodToFields(OrderingMissing rec)
        {
            labelInfoBar.Text = "Hiányzó rendelési tétel, még várható pótlással!";
            labelFinalDate.Text += " esedékes volt:";
            textBoxUserOrder.Text = rec.redeloNev;
            textBoxUserModif.Text = rec.modositNev;
            textBoxStartDate.Text = rec.beszerzDatum;
            textBoxFinalDate.Text = rec.beszMegujitasDatuma;

            comboBoxOrdProd.Items.Add(rec.termekNev);
            comboBoxOrdProd.SelectedIndex = 0;
            comboBoxOrdStrip.Items.Add(rec.termekKiszer);
            comboBoxOrdStrip.SelectedIndex = 0;

            textBoxSubcontr.Text = rec.termekBeszall;
            textBoxProdcode.Text = rec.termekKod;
            textBoxOrdAmount.Text = rec.beszerzMennyis.ToString();
            textBoxOrdPlace.Text = rec.termekHely;

            orderingId = rec.beszerId;
            oldStripId = rec.kiszerelId;
            oldOrderingDate = rec.beszerzDatum;
            oldOrdererUserId = rec.rendeloId;
        }

        #endregion

        #region adjusters of FailseOrders
        /// <summary>
        /// defines the steps when a failed record handle is needed
        /// </summary>
        /// <param name="rec">datacontainer</param>
        private void adjutTheFieldsWithProperDatas(OrderingFailed rec)
        {
            if (windoProcessMode == OrderingWindowPurpose.DETAILS)
            {
                fillUpFailedRecordToFields(rec);
                adjustFieldsReadOnlyStrict();
                textBoxOrdPlace.Visible = false;
                buttonOk.Visible = false;
            }
        }
        /// <summary>
        /// fills up the fields as a failed record is needed
        /// </summary>
        /// <param name="rec">datacontainer</param>
        private void fillUpFailedRecordToFields(OrderingFailed rec)
        {
            labelInfoBar.Text = "Lemondott rendelési tétel!";
            labelFinalDate.Text += " törölve:";
            textBoxUserOrder.Text = rec.redeloNev;
            textBoxUserModif.Text = rec.modositNev;
            textBoxStartDate.Text = rec.beszerzDatum;
            textBoxFinalDate.Text = rec.beszVeglTorolRend;

            comboBoxOrdProd.Items.Add(rec.termekNev);
            comboBoxOrdProd.SelectedIndex = 0;
            comboBoxOrdStrip.Items.Add(rec.termekKiszer);
            comboBoxOrdStrip.SelectedIndex = 0;

            textBoxSubcontr.Text = rec.termekBeszall;
            textBoxProdcode.Text = rec.termekKod;
            textBoxOrdAmount.Text = rec.beszerzMennyis.ToString();
            //textBoxOrdPlace.Text = "";
        }
        #endregion

        #region generalAdjusters of Field-state
        /// <summary>
        /// ajdust the basic no modify view of the window
        /// case of DETAILS, ARRIVING ect.
        /// </summary>
        private void adjustFieldsReadOnlyStrict()
        {
            textBoxUserOrder.ReadOnly = true;
            textBoxUserModif.ReadOnly = true;
            textBoxStartDate.ReadOnly = true;
            textBoxFinalDate.ReadOnly = true;

            comboBoxOrdProd.Enabled = false;
            comboBoxOrdStrip.Enabled = false;
            textBoxOrdAmount.ReadOnly = true;

            textBoxSubcontr.ReadOnly = true;
            textBoxProdcode.ReadOnly = true;
            textBoxOrdPlace.ReadOnly = true;
        }

        /// <summary>
        /// adjust the fields at partly arriving needs - booked / missing cases
        /// </summary>
        private void adjustFieldsPartlyArriving()
        {
            textBoxUserOrder.ReadOnly = true;
            textBoxUserModif.ReadOnly = true;
            textBoxStartDate.ReadOnly = true;
            textBoxFinalDate.ReadOnly = true;


            comboBoxOrdProd.Enabled = false;
            comboBoxOrdStrip.Enabled = false;
            labelArrivedAmount.Visible = true;
            textBoxOrdArrivAmount.Visible = true;
            textBoxOrdAmount.ReadOnly = true;

            textBoxSubcontr.ReadOnly = true;
            textBoxProdcode.ReadOnly = true;
            textBoxOrdPlace.ReadOnly = true;
        }
        /// <summary>
        /// sets the comboboxes free to modify
        /// </summary>
        private void adjustFieldsToChangeProdStrip()
        {
            comboBoxOrdProd.Enabled = true;
            comboBoxOrdStrip.Enabled = true;
        }
        /// <summary>
        /// sets off the comboboxes free moify state
        /// </summary>
        private void adjustFieldsNotCangableProdStrip()
        {
            comboBoxOrdProd.Enabled = false;
            comboBoxOrdStrip.Enabled = false;
        }
        #endregion

        #region general setter of Field contents
        /// <summary>
        /// occurs when user has chosen a production - case of MODFIY
        /// </summary>
        private void setTheFieldsNewProdHasChosen(string subcontrName)
        {
            textBoxSubcontr.Text = subcontrName;
        }
        /// <summary>
        /// occuser when the user changed its mind with modify
        /// get back the old details with product
        /// </summary>
        private void setTheFieldsBackTheOldProdNeeded()
        {
            comboBoxOrdProd.Items.Clear();
            comboBoxOrdProd.Items.Add(oldProductName);
            comboBoxOrdProd.SelectedIndex = 0;
            textBoxSubcontr.Text = oldSubcontractor;
        }
        /// <summary>
        /// occurs when user has chosen a stripping - case of MODFIY
        /// </summary>
        private void setTheFieldsNewStrippingHasChosen(string[] chosenStripPlaceBarcode)
        {
            textBoxOrdPlace.Text = chosenStripPlaceBarcode[1];
            textBoxProdcode.Text = chosenStripPlaceBarcode[0];
        }
        /// <summary>
        /// occuser when the user changed its mind with modify
        /// get back the old details with stripping
        /// </summary>
        private void setTheFieldsBackTheOldStrippNeeded()
        {
            comboBoxOrdStrip.Items.Clear();
            comboBoxOrdStrip.Items.Add(oldStrippingName);
            comboBoxOrdStrip.SelectedIndex = 0;
            textBoxOrdPlace.Text = oldPlacing;
            textBoxProdcode.Text = oldBarcode;
        }
        #endregion
    }
}
