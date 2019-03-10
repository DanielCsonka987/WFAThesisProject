using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using WFAThesisProject.ServOrdering;
using WFAThesisProject.UserNamePasswordManage;

namespace WFAThesisProject
{
    public enum OrderingWindowPurpose { DETAILS, NEW, MODFIY, RENEW, CANCEL, MakeItARRIVED, MakeItPARTLYARRIVED, MakeItFAILED }

    public partial class ServiceOrderingWinController
    {
        private Form parentOrdWin;
        private OrderingWindowPurpose windoProcessMode;
        private ServiceOrdering servOrdering;
        private int orderingId;
        private int durringNewAndModify_ChosenStrippingID;
        private int oldStripId;
        private string oldOrderingDate;
        private int oldOrdererUserId;

        private string oldProductName;
        private string oldStrippingName;
        private string oldSubcontractor;
        private string oldBarcode;
        private string oldPlacing;

        private Control labelInfoBar;
        private MetroFramework.Controls.MetroTile buttonOk;
        private MetroFramework.Controls.MetroTextBox textBoxStartDate;
        private MetroFramework.Controls.MetroTextBox textBoxFinalDate;
        private MetroFramework.Controls.MetroTextBox textBoxUserOrder;
        private MetroFramework.Controls.MetroTextBox textBoxUserModif;
        private Control labelFinalDate;
        private Control labelModifierArea;
        private MetroFramework.Controls.MetroTextBox textBoxOrdAmount;
        private MetroFramework.Controls.MetroTextBox textBoxOrdPlace;
        private MetroFramework.Controls.MetroTextBox textBoxSubcontr;
        private MetroFramework.Controls.MetroTextBox textBoxProdcode;
        private MetroFramework.Controls.MetroTextBox textBoxOrdArrivAmount;
        private Control labelArrivedAmount;
        private Control labelProductInfo;
        private Control labelPlacing;
        private MetroFramework.Controls.MetroComboBox comboBoxOrdProd;
        private MetroFramework.Controls.MetroComboBox comboBoxOrdStrip;
        private MetroFramework.Controls.MetroCheckBox checkBoxNewProd;

        public ServiceOrderingWinController(SetOfUserDetails userDatas, OrderingWindowPurpose windMode, ServiceOrdering serviceOrd, Form parentWinOrd)
        {
            this.parentOrdWin = parentWinOrd;
            this.servOrdering = serviceOrd;
            this.windoProcessMode = windMode;
            catchTheControls();
            adjutTheFieldsWithProperDatas(userDatas);
        }

        public ServiceOrderingWinController(OrderingCancelled rec, OrderingWindowPurpose windMode, ServiceOrdering serviceOrd, Form parentWinOrd)
        {
            this.parentOrdWin = parentWinOrd;
            this.servOrdering = serviceOrd;
            this.windoProcessMode = windMode;
            catchTheControls();
            adjutTheFieldsWithProperDatas(rec);
        }

        public ServiceOrderingWinController(OrderingNoted rec, OrderingWindowPurpose windMode, ServiceOrdering serviceOrd, Form parentWinOrd)
        {
            this.parentOrdWin = parentWinOrd;
            this.servOrdering = serviceOrd;
            this.windoProcessMode = windMode;
            catchTheControls();
            adjutTheFieldsWithProperDatas(rec);
        }


        public ServiceOrderingWinController(OrderingBooked rec, OrderingWindowPurpose windMode, ServiceOrdering serviceOrd, Form parentWinOrd)
        {
            this.parentOrdWin = parentWinOrd;
            this.servOrdering = serviceOrd;
            this.windoProcessMode = windMode;
            catchTheControls();
            adjutTheFieldsWithProperDatas(rec);
        }


        public ServiceOrderingWinController(OrderingArrived rec, OrderingWindowPurpose windMode, ServiceOrdering serviceOrd, Form parentWinOrd)
        {
            this.parentOrdWin = parentWinOrd;
            this.servOrdering = serviceOrd;
            this.windoProcessMode = windMode;
            catchTheControls();
            adjutTheFieldsWithProperDatas(rec);
        }


        public ServiceOrderingWinController(OrderingMissing rec, OrderingWindowPurpose windMode, ServiceOrdering serviceOrd, Form parentWinOrd)
        {
            this.parentOrdWin = parentWinOrd;
            this.servOrdering = serviceOrd;
            this.windoProcessMode = windMode;
            catchTheControls();
            adjutTheFieldsWithProperDatas(rec);
        }


        public ServiceOrderingWinController(OrderingFailed rec, OrderingWindowPurpose windMode, ServiceOrdering serviceOrd, Form parentWinOrd)
        {
            this.parentOrdWin = parentWinOrd;
            this.servOrdering = serviceOrd;
            this.windoProcessMode = windMode;
            catchTheControls();
            adjutTheFieldsWithProperDatas(rec);
        }

        private void catchTheControls()
        {
            buttonOk = (MetroFramework.Controls.MetroTile)parentOrdWin.Controls.Find("mTileOk", true).First();
            labelInfoBar = parentOrdWin.Controls.Find("mLblInfoTitle", true).First();
            textBoxStartDate = (MetroFramework.Controls.MetroTextBox)parentOrdWin.Controls.Find("mTxtBxOrderStart", true).First();
            textBoxFinalDate = (MetroFramework.Controls.MetroTextBox)parentOrdWin.Controls.Find("mTxtBxOrderFinal", true).First();
            textBoxUserOrder = (MetroFramework.Controls.MetroTextBox)parentOrdWin.Controls.Find("mTxtBxUserStart", true).First();
            textBoxUserModif = (MetroFramework.Controls.MetroTextBox)parentOrdWin.Controls.Find("mTxtBxModifUser", true).First();
            labelFinalDate = parentOrdWin.Controls.Find("mLblFinalDate", true).First();
            labelModifierArea = parentOrdWin.Controls.Find("mLblModifierArea", true).First();
            textBoxOrdAmount = (MetroFramework.Controls.MetroTextBox)parentOrdWin.Controls.Find("mTxtBxAmount", true).First();
            textBoxOrdArrivAmount = (MetroFramework.Controls.MetroTextBox)parentOrdWin.Controls.Find("mTxtBxAmountArriv", true).First();
            labelArrivedAmount = parentOrdWin.Controls.Find("mLblAmountArriv", true).First();
            textBoxOrdPlace = (MetroFramework.Controls.MetroTextBox)parentOrdWin.Controls.Find("mTxtBxPlacing", true).First();
            labelPlacing = parentOrdWin.Controls.Find("mLblPlacing", true).First();
            textBoxSubcontr = (MetroFramework.Controls.MetroTextBox)parentOrdWin.Controls.Find("mTxtBxSubcontr", true).First();
            textBoxProdcode = (MetroFramework.Controls.MetroTextBox)parentOrdWin.Controls.Find("mTxtBxProdCode", true).First();
            labelProductInfo = parentOrdWin.Controls.Find("mLblProductInfo",true).First();
            comboBoxOrdProd = (MetroFramework.Controls.MetroComboBox)parentOrdWin.Controls.Find("mCmbxProduct", true).First();
            comboBoxOrdStrip = (MetroFramework.Controls.MetroComboBox)parentOrdWin.Controls.Find("mCmbxStripping", true).First();
            checkBoxNewProd = (MetroFramework.Controls.MetroCheckBox)parentOrdWin.Controls.Find("mChckBoxNewProdAdj", true).First();
        }
    }
}
