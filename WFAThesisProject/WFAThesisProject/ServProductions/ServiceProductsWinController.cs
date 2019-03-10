using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAThesisProject
{
    public partial class ServiceProductsWinController
    {
        private Form parentProductWindow;
        private ServiceProducts serviceProducts;
        private int indexProd;              //at recollectiond datas this gives the value - it has no textbox to
                                            //collect from!! no case of new or actDetails but others
        private string oldStripping;        //case of modify quantity record

        private string sheetNameTemp;   //only the case of DETAILS mode, user wants to see the safety sheet

        private MetroFramework.Controls.MetroTextBox txtbName;
        private MetroFramework.Controls.MetroComboBox cmbbSubcontr;
        private MetroFramework.Controls.MetroTextBox txtbQuantUn;
        private MetroFramework.Controls.MetroTextBox txtbDescr;
        private MetroFramework.Controls.MetroTextBox txtbSaftySh;
        private MetroFramework.Controls.MetroTextBox txtbDanger;
        private MetroFramework.Controls.MetroTextBox txtbStripping;
        private MetroFramework.Controls.MetroTextBox txtbQuan;
        private MetroFramework.Controls.MetroTextBox txtbBarcode;
        private MetroFramework.Controls.MetroTextBox txtbPlace;
        private MetroFramework.Controls.MetroTile btnOk;
        private MetroFramework.Controls.MetroLabel lblInfos;
        private MetroFramework.Controls.MetroLabel lblMain;

        private bool typeOfInformationIsThreathing;
        private bool dataActOrHis;
        private ProductWindowPurpose typeOfDataManaging;

        public ServiceProductsWinController(ServiceProducts serviceProd, ProductWindowPurpose actMode, Form prodWin)
        {
            this.parentProductWindow = prodWin;
            this.typeOfDataManaging = actMode;
            this.serviceProducts = serviceProd;
            catchTheControls();
        }

        private void catchTheControls()
        {
            txtbName = (MetroFramework.Controls.MetroTextBox) parentProductWindow.Controls.Find("mTxtBxName",true).First();
            cmbbSubcontr = (MetroFramework.Controls.MetroComboBox) parentProductWindow.Controls.Find("mCmbBxSubcontr", true).First();
            txtbQuantUn = (MetroFramework.Controls.MetroTextBox) parentProductWindow.Controls.Find("mTxtBxQuantUnit", true).First();
            txtbDescr = (MetroFramework.Controls.MetroTextBox) parentProductWindow.Controls.Find("mTxtBxDescr", true).First();
            txtbSaftySh = (MetroFramework.Controls.MetroTextBox) parentProductWindow.Controls.Find("mTxtBxSheet", true).First();
            txtbDanger = (MetroFramework.Controls.MetroTextBox) parentProductWindow.Controls.Find("mTxtBxDanger", true).First();

            txtbStripping = (MetroFramework.Controls.MetroTextBox) parentProductWindow.Controls.Find("mTxtBxStripping", true).First();
            txtbQuan = (MetroFramework.Controls.MetroTextBox) parentProductWindow.Controls.Find("mTxtBxQuantity", true).First();
            txtbPlace = (MetroFramework.Controls.MetroTextBox) parentProductWindow.Controls.Find("mTxtBxPlaceing", true).First();
            txtbBarcode = (MetroFramework.Controls.MetroTextBox) parentProductWindow.Controls.Find("mTxtBxBarcode", true).First();

            btnOk = (MetroFramework.Controls.MetroTile) parentProductWindow.Controls.Find("mTileOk", true).First();
            lblInfos = (MetroFramework.Controls.MetroLabel) parentProductWindow.Controls.Find("mLabelInfos", true).First();
            lblMain = (MetroFramework.Controls.MetroLabel) parentProductWindow.Controls.Find("mLabelMainTitle",true).First();
        }


        public bool getTypeOfData()
        {
            return typeOfInformationIsThreathing;
        }

        public void sendTheQualityData(ProductQualityPart prod)
        {
            typeOfInformationIsThreathing = false;
            buildTheStarterQuality(prod);
        }

        public void sendTheStrippingData(ProductFullRow prod)
        {
            typeOfInformationIsThreathing = true;
            buildTheStarterStripping(prod);
        }

        public bool getTheBarcodeCheckingResult(string theBarcodeNeedToCheck)
        {
            return serviceProducts.checkBarcodeUniquity(theBarcodeNeedToCheck);
        }
    }
}
