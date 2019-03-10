using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.ServOrdering;

namespace WFAThesisProject
{
    public partial class ServiceOrderingWinController
    {
        private int amount;
        private int secondAmount;

        #region maintain the production change processes

        /// <summary>
        /// event of the new-product-needed checkbox
        /// </summary>
        public void executeChooseModifyEvent()
        {
            try
            {
                if (checkBoxNewProd.Checked)
                {
                    adjustFieldsToChangeProdStrip();
                    List<string> listOfProdName = servOrdering.getThePoolOfProductions_ProdSubcontrKeys();
                    comboBoxOrdProd.Items.Clear();
                    foreach (string name in listOfProdName)
                        comboBoxOrdProd.Items.Add(name);
                }
                else
                {
                    adjustFieldsNotCangableProdStrip();
                    setTheFieldsBackTheOldProdNeeded();
                    setTheFieldsBackTheOldStrippNeeded();
                }
            }
            catch (ErrorServiceOrdering e)
            {
                errorHandle(e.Message);
            }
        }
        /// <summary>
        /// event of combobox product - start to fill textBoxSubcontr and fills up the comboboxStrip
        /// </summary>
        public void executeProductChooseEvents()
        {
            string chosenProd = comboBoxOrdProd.SelectedItem.ToString();
            try
            {
                int tempProdId_durringModif = servOrdering.getTheChosenProdID(chosenProd);
                setThePoolOfStrippings(tempProdId_durringModif);
                string subcontrOfChosenProd = servOrdering.getTheSubcontrOfChosenProd(tempProdId_durringModif);
                setTheFieldsNewProdHasChosen(subcontrOfChosenProd);
            }
            catch (ErrorServiceOrdering e)
            {
                errorHandle(e.Message);
            }
        }
        /// <summary>
        /// fills up the cmbxStrippings
        /// </summary>
        /// <param name="prodId"></param>
        private void setThePoolOfStrippings(int prodId)
        {
            try
            {
                List<string> strippingList = servOrdering.getThePoolOfStrippings(prodId);
                comboBoxOrdStrip.Items.Clear();
                foreach (string name in strippingList)
                    comboBoxOrdStrip.Items.Add(name);
            }
            catch (ErrorServiceOrdering e)
            {
                errorHandle(e.Message);
            }
        }
        /// <summary>
        /// event of combobox strippings - collect stripId, set proper content of txtBCode and txtBPlace
        /// </summary>
        public void executeStrippingChooseEvents()
        {
            string chosenStrip = comboBoxOrdStrip.SelectedItem.ToString();
            try
            {
                durringNewAndModify_ChosenStrippingID = servOrdering.getTheChosenStrippingID(chosenStrip);
                string[] placeAndBarCode = servOrdering.getThePlaceBarcodeOfChosenStripping(durringNewAndModify_ChosenStrippingID);
                setTheFieldsNewStrippingHasChosen(placeAndBarCode);
            }
            catch (ErrorServiceOrdering e)
            {
                errorHandle(e.Message);
            }

        }

        #endregion

        #region maintain the will of changes of the user
        /// <summary>
        /// execute the activity of user
        /// </summary>
        public void executeTheCommand()
        {
            try
            {
                if (windoProcessMode == OrderingWindowPurpose.NEW)
                {
                    amount = Convert.ToInt32(textBoxOrdAmount.Text);
                    servOrdering.createNewNotedRecord(durringNewAndModify_ChosenStrippingID, amount);
                }
                else if (windoProcessMode == OrderingWindowPurpose.MODFIY)
                {
                    if(durringNewAndModify_ChosenStrippingID == 0)
                        durringNewAndModify_ChosenStrippingID = oldStripId;
                    amount = Convert.ToInt32(textBoxOrdAmount.Text);
                    servOrdering.makeModifyNotedRecord(orderingId, durringNewAndModify_ChosenStrippingID, amount);
                }
                else if (windoProcessMode == OrderingWindowPurpose.MakeItARRIVED)
                {
                    servOrdering.makeArrivedTheBookedOrMissingRecord(orderingId);
                }
                else if (windoProcessMode == OrderingWindowPurpose.MakeItPARTLYARRIVED)
                {
                    secondAmount = Convert.ToInt32(textBoxOrdArrivAmount.Text);
                    amount = Convert.ToInt32(textBoxOrdAmount.Text);
                    servOrdering.makeRecordPartlyArrived(orderingId, oldStripId, amount, secondAmount,
                        oldOrdererUserId, oldOrderingDate);
                }
                else if (windoProcessMode == OrderingWindowPurpose.MakeItFAILED)
                {
                    servOrdering.makeFailedTheBookedOrMissingRecord(orderingId);
                }
                else if (windoProcessMode == OrderingWindowPurpose.CANCEL)
                {
                    servOrdering.makeCancelledNotedRecord(orderingId);
                }
                else if (windoProcessMode == OrderingWindowPurpose.RENEW)
                {
                    servOrdering.makeRenewCancelledRecord(orderingId);
                }
            }
            catch (ErrorServiceOrdering e)
            {
                errorHandle(e.Message);
            }
            catch (Exception e)
            {
                errorHandle("Ismeretlen hiba történt (OrdWinContrExec) " + e.Message);
            }
        }
        #endregion

        #region testers



        #endregion

        private void errorHandle(string message)
        {
            MetroFramework.MetroMessageBox.Show(parentOrdWin, message, "Figyelmeztetés",
                MessageBoxButtons.OK, MessageBoxIcon.Error, 200);
        }

        private void successHandle(string message)
        {
            MetroFramework.MetroMessageBox.Show(parentOrdWin, message, "Figyelmeztetés",
                MessageBoxButtons.OK, MessageBoxIcon.Information, 200);
        }
    }
}
