using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAThesisProject
{
    public partial class MainController
    {
        private void setTheNewBtn1ProdEvents()
        {
            btn1.Click += (e, a) => {
                if (mgrid.SelectedRows[0].Index != -1)
                {
                    if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct)
                    {
                        if (mgrid.SelectedRows[0].Index != -1)
                        {
                            int index = mgrid.SelectedRows[0].Index;
                            List<ProductQualityPart> productsPartList = productService.getPartListOfProductions();
                            ProductQualityPart row = productsPartList[index];
                            row.productValidity = true;
                            productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.BRANDNEWSTRIPPING, productService, mainWindow);
                        }
                    }

                    if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)     //normal show details of quantity
                    {

                        //create new ordering record is needed - case of ProdMode StripAct
                    }
                }
            };
        }


        private void setTheNewBtn2ProdEvents()
        {
            btn2.Click += (e, a) => {
                if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)     //creates new (act) strippingRecord
                {
                    if (mgrid.SelectedRows[0].Index != -1)
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        List<ProductFullRow> productsFullList = productService.getFullListOfProductions();
                        ProductFullRow row = productsFullList[index];
                        row.productValidity = true;
                        productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.NEW, productService, mainWindow);
                    }
                }
                if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct)     //creates new (act) qualRecord
                {
                    ProductQualityPart row = new ProductQualityPart();
                    row.productValidity = true;
                    productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.NEW, productService, mainWindow);
                }
            };
        }


        private void setTheNewBtn3ProdEvents()
        {
            btn3.Click += (e, a) => {
                if (mgrid.SelectedRows[0].Index != -1)
                {
                    if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct)     //modify the active qualRec
                    { 
                        int index = mgrid.SelectedRows[0].Index;
                        List<ProductQualityPart> productsFullList = productService.getPartListOfProductions();
                        ProductQualityPart row = productsFullList[index];
                        productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.MODIFY, productService, mainWindow);
                    }
                    if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)     //modify the active quantRec
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        List<ProductFullRow> productsFullList = productService.getFullListOfProductions();
                        ProductFullRow row = productsFullList[index];
                        productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.MODIFY, productService, mainWindow);
                    }
                }
            };
        }


        private void setTheNewBtn4ProdEvents()
        {
            btn4.Click += (e, a) => {
                if (mgrid.SelectedRows[0].Index != -1)
                {
                    if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct)     //delete activeQualRec
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        List<ProductQualityPart> productsFullList = productService.getPartListOfProductions();
                        ProductQualityPart row = productsFullList[index];
                        productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.DELETE, productService, mainWindow);

                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiHis)     //react passtiveQualRec 
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        List<ProductQualityPart> productsFullList = productService.getPartListOfProductions();
                        ProductQualityPart row = productsFullList[index];
                        productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.UNDELETE, productService, mainWindow);
                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)     //delete activeQuantRec
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        List<ProductFullRow> productsFullList = productService.getFullListOfProductions();
                        ProductFullRow row = productsFullList[index];
                        productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.DELETE, productService, mainWindow);

                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripHis)     //react passiveQuantRec
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        List<ProductFullRow> productsFullList = productService.getFullListOfProductions();
                        ProductFullRow row = productsFullList[index];
                        productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.UNDELETE, productService, mainWindow);
                    }
                }
            };
        }


        private void setTheNewBtn5ProdEvents()
        {
            btn5.Click += (e, a) => {
                if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct) //it switches to qualDel
                {
                    actServiceForSubEvents = FormMainServiceMode.PRODUCTSMANQualiHis;
                    loadAppropiateProductonGridView();
                    loadAppropiateProductionCommandLineView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiHis) //it swhitches to strippAct
                {
                    actServiceForSubEvents = FormMainServiceMode.PRODUCTSMANStripAct;
                    loadAppropiateProductonGridView();
                    loadAppropiateProductionCommandLineView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct) //it switches to strippDel
                {
                    actServiceForSubEvents = FormMainServiceMode.PRODUCTSMANStripHis;
                    loadAppropiateProductonGridView();
                    loadAppropiateProductionCommandLineView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripHis) //it switches to qualtAct
                {
                    actServiceForSubEvents = FormMainServiceMode.PRODUCTSMANQualiAct;
                    loadAppropiateProductonGridView();
                    loadAppropiateProductionCommandLineView();
                }
            };
        }

        private void setTheNewBtn6ProdEvents()
        {
            btn6.Click += (e, a) => {

                if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)
                {
                    //possibly function - creating inventory analysis
                }

            };
        }
    }
}
