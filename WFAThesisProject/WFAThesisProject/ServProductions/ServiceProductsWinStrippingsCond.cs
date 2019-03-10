using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public partial class ServiceProductsWinController
    {

        /// <summary>
        /// adjust the elements of this form - depending of the purpose mode of this in case Quantity managing
        /// </summary>
        /// <param name="prod">product in treat - FullRow -> need the quantity details</param>
        public void buildTheStarterStripping(ProductFullRow prod)
        {
            if (typeOfDataManaging == ProductWindowPurpose.NEW)
            {
                fillUpNewProdQuantity(prod);
                btnOk.Text = "Bejegyzés";
                btnOk.Style = MetroFramework.MetroColorStyle.Lime;
                lblMain.Text += " - Új kiszerelés";
                fieldsToQuantityNewModify();
            }
            else if (typeOfDataManaging == ProductWindowPurpose.MODIFY)
            {
                fillUpQuantityFields(prod);
                btnOk.Text = "Módosítás";
                btnOk.Style = MetroFramework.MetroColorStyle.Lime;
                lblMain.Text += " - Kiszerelés módosítása";
                fieldsToQuantityNewModify();
            }
            else if (typeOfDataManaging == ProductWindowPurpose.DELETE)
            {
                fillUpQuantityFields(prod);
                btnOk.Text = "Tőrlés";
                btnOk.Style = MetroFramework.MetroColorStyle.Red;
                lblMain.Text += " - Kiszerelés törlése";
                fieldsToQuantityDeletDetails();
            }
            else if (typeOfDataManaging == ProductWindowPurpose.UNDELETE)
            {
                fillUpQuantityFields(prod);
                btnOk.Text = "Visszaállítás";
                btnOk.Style = MetroFramework.MetroColorStyle.Purple;
                lblMain.Text += " - Kiszerelés visszaállítása";
                fieldsToQuantityDeletDetails();
            }
            else if (typeOfDataManaging == ProductWindowPurpose.DETAILS)
            {
                fillUpQuantityFields(prod);
                btnOk.Text = "Adatlap";
                btnOk.Style = MetroFramework.MetroColorStyle.Brown;
                lblMain.Text += " - Kiszerelés tulajdonságai";
                fieldsToQuantityDeletDetails();
            }
        }
        /// <summary>
        /// adjust which fields are needed to handle by user - case of NEW Quantity managing
        /// </summary>
        private void fieldsToQuantityNewModify()
        {
            txtbName.ReadOnly = true;
            txtbSaftySh.ReadOnly = true;
            txtbQuantUn.ReadOnly = true;
            txtbDanger.ReadOnly = true;
            txtbDescr.ReadOnly = true;
            cmbbSubcontr.Enabled = false;

            txtbPlace.ReadOnly = false;
            txtbBarcode.ReadOnly = false;
            txtbQuan.ReadOnly = false;
            txtbStripping.ReadOnly = false;
        }
        /// <summary>
        /// adjust which fields are needed to handle by user - case of other but not NEW Quantity managing
        /// </summary>
        private void fieldsToQuantityDeletDetails()
        {
            txtbName.ReadOnly = true;
            txtbSaftySh.ReadOnly = true;
            txtbQuantUn.ReadOnly = true;
            txtbDanger.ReadOnly = true;
            txtbDescr.ReadOnly = true;
            cmbbSubcontr.Enabled = false;

            txtbPlace.ReadOnly = true;
            txtbBarcode.ReadOnly = true;
            txtbQuan.ReadOnly = true;
            txtbStripping.ReadOnly = true;
        }
        /// <summary>
        /// part of the NEW record creations in quantity
        /// </summary>
        private void fillUpNewProdQuantity(ProductFullRow prod)
        {
            txtbName.Text = prod.productName;
            txtbSaftySh.Text = prod.productSheet;
            txtbQuantUn.Text = prod.productQantUnit;
            txtbDanger.Text = prod.productDanger.ToString();
            txtbDescr.Text = prod.productDescr;

            fillAndAdjustSubcontr(prod.productSubcontr);

            txtbPlace.Text = "";
            txtbBarcode.Text = "";
            txtbQuan.Text = "";
            txtbStripping.Text = "";

            indexProd = prod.producQualId;
        }
        /// <summary>
        /// fills up the details from record-container to show in fields in case Quantity managing
        /// </summary>
        /// <param name="prod">data carrer FullRow</param>
        private void fillUpQuantityFields(ProductFullRow prod)
        {
            txtbName.Text = prod.productName;
            txtbSaftySh.Text = prod.productSheet;
            txtbQuantUn.Text = prod.productQantUnit;
            txtbDanger.Text = Convert.ToString(prod.productDanger);
            txtbDescr.Text = prod.productDescr;

            fillAndAdjustSubcontr(prod.productSubcontr);

            txtbPlace.Text = prod.productPlace;
            txtbBarcode.Text = prod.productBarcode;
            txtbQuan.Text = Convert.ToString(prod.productQuantity);
            txtbStripping.Text = Convert.ToString(prod.productStripping);

            indexProd = prod.producQualId;
            oldStripping = prod.productStripping.ToString();
            dataActOrHis = prod.productValidity;
            sheetNameTemp = prod.productSheet;

            if (!dataActOrHis)
            {
                lblInfos.Text += "Töröve!\n";
            }
            if (prod.productModifiedThen != "0")
            {
                lblInfos.Text += "Utolsó módosítás: " + prod.productModifiedThen + "\n";
            }
            if (prod.productModifiedBy != 0)
            {
                lblInfos.Text += "Végrehajtotta: " + serviceProducts.getWhoModifiedTheRecord(prod.productModifiedBy);
            }

            if (typeOfDataManaging == ProductWindowPurpose.MODIFY)
            {
                oldStripping = prod.productStripping.ToString();
            }
        }
    }
}
