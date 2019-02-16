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
        /// adjust the elements of this form - depending of the purpose mode of this in case Quality managing
        /// </summary>
        /// <param name="prod">product in treat - QualityPart type</param>
        public void buildTheStarterQuality(ProductQualityPart prod)
        {
            if (typeOfDataManaging == ProductWindowPurpose.NEW)
            {
                fillUpNewProdQuality();
                btnOk.Text = "Bejegyzés";
                btnOk.Style = MetroFramework.MetroColorStyle.Purple;
                lblMain.Text += " - Új termék";
                fieldsToQualityNewModify();
            }
            else if (typeOfDataManaging == ProductWindowPurpose.MODIFY)
            {
                fillUpQualityFieldsToModifyDeletUndelet(prod);
                btnOk.Text = "Módosítás";
                btnOk.Style = MetroFramework.MetroColorStyle.Purple;
                lblMain.Text += " - Termék módosítása";
                fieldsToQualityNewModify();
            }
            else if (typeOfDataManaging == ProductWindowPurpose.DELETE)
            {
                fillUpQualityFieldsToModifyDeletUndelet(prod);
                btnOk.Text = "Tőrlés";
                btnOk.Style = MetroFramework.MetroColorStyle.Red;
                lblMain.Text += " - Termék törlése";
                fieldsToQualityDeletUndeletDetails();
            }
            else if (typeOfDataManaging == ProductWindowPurpose.UNDELETE)
            {
                fillUpQualityFieldsToModifyDeletUndelet(prod);
                btnOk.Text = "Visszaállítás";
                btnOk.Style = MetroFramework.MetroColorStyle.Purple;
                lblMain.Text += " - Termék visszaállítása";
                fieldsToQualityDeletUndeletDetails();
            }
            else if (typeOfDataManaging == ProductWindowPurpose.DETAILS)
            {
                fillUpQualityFieldsToModifyDeletUndelet(prod);
                btnOk.Visible = false;
                lblMain.Text += " - Termék részletei";
                fieldsToQualityDeletUndeletDetails();
            }
            else if (typeOfDataManaging == ProductWindowPurpose.BRANDNEWSTRIPPING)
            {
                fillUpQualityFieldsToModifyDeletUndelet(prod);
                btnOk.Text = "Új kiszerelés";
                btnOk.Style = MetroFramework.MetroColorStyle.Brown;
                lblMain.Text += " - Új kiszerelés létrehozása";
                fieldsToBrandNewStripping();
            }
        }
        /// <summary>
        /// adjust which fields are needed to handle by user - case of NEW Quality managing
        /// </summary>
        private void fieldsToQualityNewModify()
        {
            txtbName.ReadOnly = false;
            txtbSaftySh.ReadOnly = false;
            txtbQuantUn.ReadOnly = false;
            txtbDanger.ReadOnly = false;
            txtbDescr.ReadOnly = false;
            cmbbSubcontr.Enabled = true;

            txtbPlace.ReadOnly = true;
            txtbBarcode.ReadOnly = true;
            txtbQuan.ReadOnly = true;
            txtbStripping.ReadOnly = true;
        }
        /// <summary>
        /// adjust which fields are needed to handle by user - case of other but not NEW managing
        /// </summary>
        private void fieldsToQualityDeletUndeletDetails()
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
        /// adjust which fields are needed to handle by user - case of creating brand new strippings
        /// </summary>
        private void fieldsToBrandNewStripping()
        {
            txtbName.ReadOnly = true;
            txtbSaftySh.ReadOnly = true;
            txtbQuantUn.ReadOnly = true;
            txtbDanger.ReadOnly = true;
            txtbDescr.ReadOnly = true;
            cmbbSubcontr.Enabled = true;

            txtbPlace.ReadOnly = false;
            txtbBarcode.ReadOnly = false;
            txtbQuan.ReadOnly = false;
            txtbStripping.ReadOnly = false;
        }
        /// <summary>
        /// part of the NEW record creations in quality
        /// </summary>
        private void fillUpNewProdQuality()
        {
            txtbName.Text = "";
            txtbSaftySh.Text = "";
            txtbQuantUn.Text = "";
            txtbDanger.Text = "";
            txtbDescr.Text = "";

            fillAndAdjustSubcontr();

            txtbPlace.Text = "";
            txtbBarcode.Text = "";
            txtbQuan.Text = "";
            txtbStripping.Text = "";
        }
        /// <summary>
        /// fills up the details from record-container to show in fields in case Quality managing
        /// </summary>
        /// <param name="prod">data-carrier QualityPart</param>
        private void fillUpQualityFieldsToModifyDeletUndelet(ProductQualityPart prod)
        {
            txtbName.Text = prod.productName;
            txtbSaftySh.Text = prod.productSheet;
            txtbQuantUn.Text = prod.productQantUnit;
            txtbDanger.Text = Convert.ToString(prod.productDanger);
            txtbDescr.Text = prod.productDescr;

            fillAndAdjustSubcontr(prod.productSubcontr);

            indexProd = prod.productIndex;
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
        }


    }
}
