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
        private Form productWindow;
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
            this.productWindow = prodWin;
            this.typeOfDataManaging = actMode;
            this.serviceProducts = serviceProd;
            catchTheControls();
        }

        private void catchTheControls()
        {
            txtbName = (MetroFramework.Controls.MetroTextBox) productWindow.Controls.Find("mTxtBxName",true).First();
            cmbbSubcontr = (MetroFramework.Controls.MetroComboBox) productWindow.Controls.Find("mCmbBxSubcontr", true).First();
            txtbQuantUn = (MetroFramework.Controls.MetroTextBox) productWindow.Controls.Find("mTxtBxQuantUnit", true).First();
            txtbDescr = (MetroFramework.Controls.MetroTextBox) productWindow.Controls.Find("mTxtBxDescr", true).First();
            txtbSaftySh = (MetroFramework.Controls.MetroTextBox) productWindow.Controls.Find("mTxtBxSheet", true).First();
            txtbDanger = (MetroFramework.Controls.MetroTextBox) productWindow.Controls.Find("mTxtBxDanger", true).First();

            txtbStripping = (MetroFramework.Controls.MetroTextBox) productWindow.Controls.Find("mTxtBxStripping", true).First();
            txtbQuan = (MetroFramework.Controls.MetroTextBox) productWindow.Controls.Find("mTxtBxQuantity", true).First();
            txtbPlace = (MetroFramework.Controls.MetroTextBox) productWindow.Controls.Find("mTxtBxPlaceing", true).First();
            txtbBarcode = (MetroFramework.Controls.MetroTextBox) productWindow.Controls.Find("mTxtBxBarcode", true).First();

            btnOk = (MetroFramework.Controls.MetroTile) productWindow.Controls.Find("mTileOk", true).First();
            lblInfos = (MetroFramework.Controls.MetroLabel) productWindow.Controls.Find("mLabelInfos", true).First();
            lblMain = (MetroFramework.Controls.MetroLabel) productWindow.Controls.Find("mLabelMainTitle",true).First();
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
