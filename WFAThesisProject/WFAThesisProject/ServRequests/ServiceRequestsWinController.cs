using System;
using System.Linq;
using System.Windows.Forms;
using WFAThesisProject.ServRequests;

namespace WFAThesisProject
{
    public enum RequestWindowPuropse { MorifyTheActive, DeleteTheActive, GivingOutTheActive, DetailsOfActive,
        DetailsOfDeleted, RenewTheDeleted,       DetailsOfCancelled,       DetailsOfGivenOut, GetBackTheGivenOut }

    public partial class ServiceRequestsWinController
    {
        private Form requestWindow;
        private RequestWindowPuropse purposeOfTheWindow;
        private int chosenNewStrippingID_DurringModify;
        private int userIdOfRequester;
        private int oldStrippingID;
        private int oldProductID;
        private string oldProductName;
        private string oldStrippingName;
        private string oldPlacing;
        private string oldSubcontr;
        private int requestID;

        private ServiceRequests serviceRequests;
        private MetroFramework.Controls.MetroTile buttonOk;
        private MetroFramework.Controls.MetroTextBox textBoxName;
        private MetroFramework.Controls.MetroTextBox textBoxArea;
        private MetroFramework.Controls.MetroTextBox textBoxAmount;
        private MetroFramework.Controls.MetroTextBox textBoxStartDate;
        private MetroFramework.Controls.MetroTextBox textBoxEndDate;
        private MetroFramework.Controls.MetroComboBox comboBoxProducts;
        private MetroFramework.Controls.MetroComboBox comboBoxStrippings;
        private MetroFramework.Controls.MetroTextBox textBoxPlacing;
        private MetroFramework.Controls.MetroTextBox textBoxSubcontr;
        private Control labelOfProduct;
        private Control infoLabel;
        private Control labelPlacing;
        private MetroFramework.Controls.MetroCheckBox checkBoxNewdProd;

        public ServiceRequestsWinController(RequestRecordActive rec, RequestWindowPuropse mode, ServiceRequests servReq,
            Form parentReq)
        {
            serviceRequests = servReq;
            this.requestWindow = parentReq;
            this.purposeOfTheWindow = mode;
            catchTheControls();
            adjustActiveRecFields(rec);
        }


        public ServiceRequestsWinController(RequestRecordGivenOut rec, RequestWindowPuropse mode, ServiceRequests servReq,
            Form parentReq)
        {
            serviceRequests = servReq;
            this.requestWindow = parentReq;
            this.purposeOfTheWindow = mode;
            catchTheControls();
            adjustGivenOutRecFields(rec);
        }

        public ServiceRequestsWinController(RequestRecordDeleted rec, RequestWindowPuropse mode, ServiceRequests servReq,
            Form parentReq)
        {
            serviceRequests = servReq;
            this.requestWindow = parentReq;
            this.purposeOfTheWindow = mode;
            catchTheControls();
            adjustDeletedRecFields(rec);
        }

        public ServiceRequestsWinController(RequestRecordCalledOff rec, RequestWindowPuropse mode, ServiceRequests servReq,
            Form parentReq)
        {
            serviceRequests = servReq;
            this.requestWindow = parentReq;
            this.purposeOfTheWindow = mode;
            catchTheControls();
            adjustCancelledRecFields(rec);
        }

        private void catchTheControls()
        {
            buttonOk = (MetroFramework.Controls.MetroTile) requestWindow.Controls.Find("mTileOk", true).First();
            textBoxName = (MetroFramework.Controls.MetroTextBox) requestWindow.Controls.Find("mTxtBxReqName", true).First();
            textBoxArea = (MetroFramework.Controls.MetroTextBox) requestWindow.Controls.Find("mTxtBxReqArea", true).First(); ;
            textBoxAmount = (MetroFramework.Controls.MetroTextBox) requestWindow.Controls.Find("mTxtBxAmount", true).First(); ;
            textBoxStartDate = (MetroFramework.Controls.MetroTextBox) requestWindow.Controls.Find("mTxtBxStartDate", true).First(); ;
            textBoxEndDate = (MetroFramework.Controls.MetroTextBox) requestWindow.Controls.Find("mTxtBxEndDate", true).First(); ;
            comboBoxProducts = (MetroFramework.Controls.MetroComboBox) requestWindow.Controls.Find("mCbBxProducts", true).First(); ;
            comboBoxStrippings = (MetroFramework.Controls.MetroComboBox) requestWindow.Controls.Find("mCbBxStrippings", true).First(); ;
            textBoxPlacing = (MetroFramework.Controls.MetroTextBox) requestWindow.Controls.Find("mTxtBxPlaceCode", true).First();
            textBoxSubcontr = (MetroFramework.Controls.MetroTextBox) requestWindow.Controls.Find("mTxtBxBeszall", true).First();
            labelPlacing = (MetroFramework.Controls.MetroLabel) requestWindow.Controls.Find("mLabelPlacing", true).First();
            infoLabel = (MetroFramework.Controls.MetroLabel) requestWindow.Controls.Find("mLblInfoTitle", true).First();
            labelOfProduct = (MetroFramework.Controls.MetroLabel)requestWindow.Controls.Find("mLabelOfProductCmb", true).First();
            checkBoxNewdProd = (MetroFramework.Controls.MetroCheckBox)requestWindow.Controls.Find("mChckBxModifyDiffProd", true).First();
        }

        public void errorproviderBuilding()
        {

        }
    }
}
