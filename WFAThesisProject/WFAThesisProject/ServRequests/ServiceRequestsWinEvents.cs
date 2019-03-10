using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.ServRequests;

namespace WFAThesisProject
{
    public partial class ServiceRequestsWinController
    {
        private int amountOfRequest;
        public void executeTheProperEvent()
        {
            try
            {
                amountOfRequest = Convert.ToInt32(textBoxAmount.Text);
                if (purposeOfTheWindow == RequestWindowPuropse.GetBackTheGivenOut)
                {
                    serviceRequests.getBackTheChosenProductThatWereGivenOut(oldStrippingID, amountOfRequest,
                        requestID, userIdOfRequester);
                    successShow("Sikeresen lefutot a visszavétel");
                }
                if (purposeOfTheWindow == RequestWindowPuropse.GivingOutTheActive)
                {
                    serviceRequests.giveOutTheChosenProduct(oldStrippingID, amountOfRequest,
                        requestID, userIdOfRequester);
                    successShow("Sikeresen lefutott a kiadás");
                }
                if (purposeOfTheWindow == RequestWindowPuropse.MorifyTheActive)
                {
                    serviceRequests.modifyTheActiveRecord(amountOfRequest, chosenNewStrippingID_DurringModify, 
                        requestID, userIdOfRequester);
                    successShow("Sikeresen lefutott a módosítás");
                }
                if (purposeOfTheWindow == RequestWindowPuropse.RenewTheDeleted)
                {
                    serviceRequests.undeletADeletedRequest(requestID, userIdOfRequester);
                    successShow("Sikeresen lefutott a visszaállítás");
                }
                if (purposeOfTheWindow == RequestWindowPuropse.DeleteTheActive)
                {
                    serviceRequests.deletAnActiveRequest(requestID, userIdOfRequester);
                    successShow("Sikeresen lefutott a törtlés");
                }
                requestWindow.Close();
            }
            catch (ErrorServiceRequests e)
            {
                errorHandleMethodRequ(e.Message);
            }

        }

        /// <summary>
        /// errorhandler of the Requests mini-window
        /// </summary>
        /// <param name="message"></param>
        private void errorHandleMethodRequ(string message)
        {
            MetroFramework.MetroMessageBox.Show(requestWindow, message, "Figyelmeztetés", MessageBoxButtons.OK,
                MessageBoxIcon.Error, 200);
        }

        private void successShow(string message)
        {
            MetroFramework.MetroMessageBox.Show(requestWindow, message, "Információ", MessageBoxButtons.OK,
                MessageBoxIcon.Information, 200);
        }

        #region managing when user wants to change product/stripping infos durring modify active
        /// <summary>
        /// it is rund by the user - only checkbox, the new prroduct
        /// </summary>
        public void executeModfyWithNewProductEvent()
        {
            if (checkBoxNewdProd.Checked == true)
            {
                adjustAreasToChooseNewProd();
                fillUpTheProductsField();
            }
            else
            {
                adjustBackTheOldProductParam();
            }
        }
        /// <summary>
        /// runs after the checkbox of new product param is chosen
        /// </summary>
        public void executeSelectedNewProductionEvent_StrippingSubcontrAreaFilling()
        {
            if (purposeOfTheWindow == RequestWindowPuropse.MorifyTheActive)
            {
                try
                {
                    string theProduct = comboBoxProducts.SelectedItem.ToString();
                    int chosenProductionID_DurringModify = serviceRequests.identifyTheProductIdInProductList(theProduct);
                    fillUpTheStrippingsAndSubcontrField(chosenProductionID_DurringModify);
                    fillUpTheSubcontractorField(chosenProductionID_DurringModify);
                }
                catch (ErrorServiceRequests e)
                {
                    errorHandleMethodRequ(e.Message);
                }
            }
        }

        /// <summary>
        /// runs by the combobox of product durring the modification after new-product-checkbox checked
        /// </summary>
        public void executeSelectedStrippingEvent_GetTheCorrectStrippingID()
        {
            if (purposeOfTheWindow == RequestWindowPuropse.MorifyTheActive)
            {
                try
                {
                    if (comboBoxProducts.SelectedIndex > -1)
                    {
                        string theStripping = comboBoxStrippings.SelectedItem.ToString();
                        chosenNewStrippingID_DurringModify = serviceRequests.identifyTheStrippingIDFromList(theStripping);
                    }
                }
                catch (ErrorServiceRequests e)
                {
                    errorHandleMethodRequ(e.Message);
                }
            }
        }
        /// <summary>
        /// in need, it fills up the combobox of productions - after the user has chosen the new prod checkbox
        /// </summary>
        private void fillUpTheProductsField()
        {
            try
            {
                List<string> itemnames = serviceRequests.getThePoolOfProducts();
                comboBoxProducts.Items.Clear();
                foreach (string s in itemnames)
                    comboBoxProducts.Items.Add(s);
            }
            catch (ErrorServiceRequests e)
            {
                errorHandleMethodRequ(e.Message);
            }
            catch (Exception e)
            {
                errorHandleMethodRequ(e.Message);
            }
        }
        /// <summary>
        /// fills the new subcontractor to the specific textbox
        /// </summary>
        private void fillUpTheSubcontractorField(int chosenProductionID_DurringModify)
        {
            try
            {
                textBoxSubcontr.Text = serviceRequests.getTheChosenProductsSubcontractor(chosenProductionID_DurringModify);
            }
            catch (ErrorServiceRequests e)
            {
                errorHandleMethodRequ(e.Message);
            }
            catch (Exception e)
            {
                errorHandleMethodRequ(e.Message);
            }
        }
        /// <summary>
        /// in need it fill up the combobox of stripping - after the user has chosen new product
        /// </summary>
        private void fillUpTheStrippingsAndSubcontrField(int chosenProductionID_DurringModify)
        {
            try
            {
                List<string> itemnames = serviceRequests.getThePoolOfStrippings(chosenProductionID_DurringModify);
                comboBoxStrippings.Items.Clear();
                foreach (string s in itemnames)
                    comboBoxStrippings.Items.Add(s);
            }
            catch (ErrorServiceRequests e)
            {
                errorHandleMethodRequ(e.Message);
            }
            catch (Exception e)
            {
                errorHandleMethodRequ(e.Message);
            }
        }
        #endregion
    }
}
