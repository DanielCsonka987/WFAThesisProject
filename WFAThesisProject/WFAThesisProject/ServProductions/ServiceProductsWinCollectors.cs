using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public partial class ServiceProductsWinController 
    {
        private ProductStrippingPart tempOfChangesStripping;
        private ProductQualityPart tempOfCangesQuality;

        /// <summary>
        /// collects the datas from fields of case quantity managing
        /// </summary>
        public void collectAllDatasOfStripping()
        {
            tempOfChangesStripping = new ProductStrippingPart();
            tempOfChangesStripping.productBarcode = txtbBarcode.Text;
            tempOfChangesStripping.productPlace = txtbPlace.Text;
            tempOfChangesStripping.productQuantity = Convert.ToInt32(txtbQuan.Text);
            tempOfChangesStripping.productStripping = Convert.ToInt32(txtbStripping.Text);
            tempOfChangesStripping.productIndex = indexProd;
            tempOfChangesStripping.productValidity = true;     //in case reactivate
        }
        /// <summary>
        /// collects the datas from fields of case quality managing
        /// </summary>
        public void collectAllDatasQuality()
        {
            tempOfCangesQuality = new ProductQualityPart();
            tempOfCangesQuality.productName = txtbName.Text;
            tempOfCangesQuality.productSubcontr = cmbbSubcontr.SelectedItem.ToString();
            tempOfCangesQuality.productDescr = txtbDescr.Text;
            tempOfCangesQuality.productDanger = Convert.ToInt32(txtbDanger.Text);
            tempOfCangesQuality.productSheet = txtbSaftySh.Text;
            tempOfCangesQuality.productQantUnit = txtbQuantUn.Text;

            if (typeOfDataManaging == ProductWindowPurpose.NEW)
                tempOfCangesQuality.productIndex = 0;  //validity automaticly created true
            else
            {
                tempOfCangesQuality.productIndex = indexProd;
                tempOfCangesQuality.productValidity = true;     //in case reactivate
            }
        }

        /// <summary>
        /// decides whisch saving mode is needed - defines the controller processes
        /// </summary>
        public void maintainTheECorrectEvent()
        {
            if (typeOfDataManaging == ProductWindowPurpose.NEW)
            {
                if (typeOfInformationIsThreathing)
                    serviceProducts.setNewRecProdQuantity(tempOfChangesStripping);
                else
                    serviceProducts.setNewRecProdQuality(tempOfCangesQuality);
            }
            if (typeOfDataManaging == ProductWindowPurpose.MODIFY)
            {
                if (typeOfInformationIsThreathing)
                    serviceProducts.setModifyRecProdQuantity(tempOfChangesStripping, oldStripping);
                else
                    serviceProducts.setModifyRecProdQuality(tempOfCangesQuality);
            }
            if (typeOfDataManaging == ProductWindowPurpose.DELETE)
            {
                if (typeOfInformationIsThreathing)
                    serviceProducts.setDeleteRecProdQuantity(indexProd.ToString(), oldStripping);
                else
                    serviceProducts.setDeleteRecProdQuality(indexProd.ToString());
            }
            if (typeOfDataManaging == ProductWindowPurpose.UNDELETE)
            {
                if (typeOfInformationIsThreathing)
                    serviceProducts.setUndeleteRecProdQuantity(indexProd.ToString(), oldStripping);
                else
                    serviceProducts.setUndeleteRecProdQuality(indexProd.ToString());
            }
            if (typeOfDataManaging == ProductWindowPurpose.DETAILS)  //only when quantity mode active
            {
                serviceProducts.getTheSaftyDataSheet(sheetNameTemp);
            }
            if (typeOfDataManaging == ProductWindowPurpose.BRANDNEWSTRIPPING)    //only when quality mode active
            {
                serviceProducts.setNewRecProdQuantity(tempOfChangesStripping);
            }
        }

    }
}
