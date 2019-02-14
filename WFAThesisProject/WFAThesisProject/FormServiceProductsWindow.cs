using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAThesisProject
{
    public enum ProductWindowPurpose { DETAILS, NEW, MODIFY, DELETE, UNDELETE, BRANDNEWSTRIPPING }

    public partial class FormServiceProductsWindow : MetroFramework.Forms.MetroForm
    {
        private ServiceProductsWinController controllerProductsWindow;
        private ProductStrippingPart resultOfChangesQuantity;
        private ProductQualityPart resultOfCangesQualit;
        private ProductWindowPurpose modeTheWindow;
        private Form parentMainWindow;
        private int tryParseTemp;   //only for having a type-conversion probe
        /// <summary>
        /// constructor in case of production quantity is the matter
        /// </summary>
        /// <param name="prod">the list element of fullrecord</param>
        /// <param name="mode">mark of mode this section</param>
        /// <param name="serviceOfProd"></param>
        public FormServiceProductsWindow(ProductFullRow prod, ProductWindowPurpose mode, 
            Products serviceOfProd, Form parent)
        {
            InitializeComponent();
            this.modeTheWindow = mode;
            this.parentMainWindow = parent;
            controllerProductsWindow = new ServiceProductsWinController(serviceOfProd, mode, this);
            controllerProductsWindow.sendTheStrippingData(prod);
            parent.Hide();
            this.Show();
        }

        public FormServiceProductsWindow(ProductQualityPart prod, ProductWindowPurpose mode,
            Products serviceOfProd, Form parentMain)
        {
            InitializeComponent();
            this.modeTheWindow = mode;
            this.parentMainWindow = parentMain;
            controllerProductsWindow = new ServiceProductsWinController(serviceOfProd, mode, this);
            controllerProductsWindow.sendTheQualityData(prod);
            parentMain.Hide();
            this.Show();
        }

        private void FormServiceProductsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentMainWindow.Show();
        }

        /// <summary>
        /// when user wants the saving of the production table changes
        /// trigger the testing and correct event processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileOk_Click(object sender, EventArgs e)
        {
            if (controllerProductsWindow.getTypeOfData())
            {
                if (revisionContentStripping())
                    return;
                controllerProductsWindow.collectAllDatasOfStripping();
            }
            else
            {
                if (modeTheWindow == ProductWindowPurpose.BRANDNEWSTRIPPING)
                {
                    if (revisionContentStripping())
                        return;
                    controllerProductsWindow.collectAllDatasOfStripping();
                }
                else
                {
                    if (revisionContentQuality())
                        return;
                    controllerProductsWindow.collectAllDatasQuality();
                }
            }
            controllerProductsWindow.maintainTheECorrectEvent();
            this.Close();
        }
        
        private void mTileCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region revisioners
        /// <summary>
        /// checks out the typed in datas of Quality product inform.s
        /// </summary>
        /// <returns>result of analyzis true=revision / false=continue</returns>
        public bool revisionContentQuality()
        {
            if (mTxtBxName.Text == "")
            {
                errorProvDataProb.SetError(mTxtBxName, "Kérem, ne hagyja üresen ezt a részt!");
                return true;
            }
            if (mCmbBxSubcontr.SelectedIndex == -1)
            {
                errorProvDataProb.SetError(mCmbBxSubcontr, "Kérem, ne hagyja üresen ezt a részt!");
                return true;
            }
            if (mTxtBxDanger.Text == "")
            {
                errorProvDataProb.SetError(mTxtBxDanger, "Kérem, ne hagyja üresen ezt a részt!");
                return true;
            }
            if (!int.TryParse(mTxtBxDanger.Text, out tryParseTemp))
            {
                errorProvDataProb.SetError(mTxtBxQuantity, "Kérem, ide egy egész számértéket írjon!");
                return true;
            }
            if (mTxtBxQuantUnit.Text == "")
            {
                errorProvDataProb.SetError(mTxtBxQuantUnit, "Kérem, ne hagyja üresen ezt a részt!");
                return true;
            }
            if (mTxtBxSheet.Text == "")
            {
                errorProvDataProb.SetError(mTxtBxSheet, "Kérem, ne hagyja üresen ezt a részt!");
                return true;
            }
            return false;
        }
        /// <summary>
        /// checks out the typed in datas
        /// </summary>
        /// <returns>result of analyzis true=revision / false=continue</returns>
        public bool revisionContentStripping()
        {
            if (mTxtBxStripping.Text == "")
            {
                errorProvDataProb.SetError(mTxtBxQuantity, "Kérem, ne hagyja üresen ezt a részt!");
                return true;
            }
            if (!int.TryParse(mTxtBxStripping.Text, out tryParseTemp))
            {
                errorProvDataProb.SetError(mTxtBxStripping, "Kérem, ide egy egész számértéket írjon!");
                return true;
            }

            if (mTxtBxBarcode.Text == "")
            {
                errorProvDataProb.SetError(mTxtBxBarcode, "Kérem, ne hagyja üresen ezt a részt!");
                return true;
            }
            if (modeTheWindow == ProductWindowPurpose.NEW ||
                modeTheWindow == ProductWindowPurpose.BRANDNEWSTRIPPING)
            {
                if(controllerProductsWindow.getTheBarcodeCheckingResult(mTxtBxBarcode.Text))
                {
                    errorProvDataProb.SetError(mTxtBxBarcode, "Ez a termékkulcs már létezik az adatbázisban!");
                    return true;
                }
            }
            if (mTxtBxPlaceing.Text == "")
            {
                errorProvDataProb.SetError(mTxtBxPlaceing, "Kérem, ne hagyja üresen ezt a részt!");
                return true;
            }
            if (mTxtBxQuantity.Text == "")
            {
                errorProvDataProb.SetError(mTxtBxQuantity, "Kérem, ne hagyja üresen ezt a részt!");
                return true;
            }
            if (!int.TryParse(mTxtBxQuantity.Text, out tryParseTemp))
            {
                errorProvDataProb.SetError(mTxtBxQuantity, "Kérem, ide egy egész számértéket írjon!");
                return true;
            }
            return false;
        }

        #endregion
    }
}
