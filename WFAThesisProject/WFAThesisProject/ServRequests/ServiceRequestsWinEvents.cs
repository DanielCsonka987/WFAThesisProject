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
        private string startDateOfRequest;
        private int amountOfRequest;

        public void executeTheProperEvent()
        {
            try
            {
                collectImportantRecordFields();
                if (purposeOfTheWindow == RequestWindowPuropse.GetBackTheGivenOut)
                {
                    serviceRequests.getBackTheChosenProductThatWereGivenOut(oldStrippingID, amountOfRequest,
                        startDateOfRequest, userIdOfRequester);
                }
                if (purposeOfTheWindow == RequestWindowPuropse.GivingOutTheActive)
                {
                    serviceRequests.giveOutTheChosenProduct(oldStrippingID, amountOfRequest,
                        startDateOfRequest, userIdOfRequester);
                }
                if (purposeOfTheWindow == RequestWindowPuropse.MorifyTheActive)
                {
                    serviceRequests.modifyTheActiveRecord(amountOfRequest, chosenNewStrippingID_DurringModify,
                        startDateOfRequest, oldStrippingID, userIdOfRequester);
                }
                if (purposeOfTheWindow == RequestWindowPuropse.RenewTheDeleted)
                {
                    serviceRequests.undeletADeletedRequest(startDateOfRequest, oldStrippingID, userIdOfRequester);
                }
                if (purposeOfTheWindow == RequestWindowPuropse.DeleteTheActive)
                {
                    serviceRequests.deletAnActiveRequest(startDateOfRequest, oldStrippingID, userIdOfRequester);
                }
                requestWindow.Close();
            }
            catch (ErrorServiceRequests e)
            {
                errorHandleMethodRequ(e.Message);
            }

        }

        private void collectImportantRecordFields()  //startDate, strippingID, userID is needed
        {
            startDateOfRequest = textBoxStartDate.Text;
            amountOfRequest = Convert.ToInt32(textBoxAmount.Text);
        }

        public void executeSelectedProductionEvent()
        {
            if (purposeOfTheWindow == RequestWindowPuropse.MorifyTheActive)
            {
                try
                {
                    string theProduct = comboBoxProducts.SelectedItem.ToString();
                    int chosenProductionID_DurringModify = serviceRequests.identifyTheProductIdInProductList(theProduct);
                    fillUpTheStrippingsField(chosenProductionID_DurringModify);
                }
                catch (ErrorServiceRequests e)
                {
                    errorHandleMethodRequ(e.Message);
                }
            }
        }

        public void executeSelectedStrippingEvent()
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

        private void errorHandleMethodRequ(string message)
        {
            MetroFramework.MetroMessageBox.Show(requestWindow, message, "Figyelmeztetés", MessageBoxButtons.OK,
                MessageBoxIcon.Error, 200);
        }
    }
}
