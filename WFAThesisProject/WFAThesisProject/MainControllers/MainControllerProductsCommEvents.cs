using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.ServProductions;

namespace WFAThesisProject
{
    public partial class MainController
    {
        private void setTheNewBtn1ProdEvents()
        {
            removeClickEvent((Button)btn1);
            btn1.Click += (e, a) => {
                if (mgrid.SelectedRows[0].Index != -1)
                {
                    try
                    {
                        if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct)
                        {
                            int indexFromGrid = mgrid.SelectedRows[0].Index;
                            int recId = (int)mgrid.Rows[indexFromGrid].Cells[0].Value;
                            ProductQualityPart row = productService.getPartContainerOfChosenProductions(recId);
                            row.productValidity = true;
                            productsManageWindow = new FormServiceProductsWindow(row,
                                ProductWindowPurpose.BRANDNEWSTRIPPING, productService, mainWindow);
                        }
                        if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)     //normal show details of quantity
                        {

                            //create new ordering record is needed - case of ProdMode StripAct
                        }
                    }
                    catch (ErrorServiceProd k)
                    {
                        errorHandle(k.Message);
                    }
                    catch (Exception k)
                    {
                        errorHandle("Ismeretlen hiba történt (ContrMainProdBtn1) " + k.Message);
                    }
                }
            };
        }

        private void setTheNewBtn2ProdEvents()
        {
            removeClickEvent((Button)btn2);
            btn2.Click += (e, a) => {
                if (mgrid.SelectedRows[0].Index != -1)
                {
                    try
                    {
                        if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)     //creates new (act) strippingRecord
                        {
                            int indexFromGrid = mgrid.SelectedRows[0].Index;
                            int stripId = (int)mgrid.Rows[indexFromGrid].Cells[0].Value;
                             
                            ProductFullRow row = productService.getFullistContainerOfProduction(stripId);
                            row.productValidity = true;
                            productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.NEW, productService, mainWindow);
                        }
                        if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct)     //creates new (act) qualRecord
                        {
                            ProductQualityPart row = new ProductQualityPart();
                            row.productValidity = true;
                            productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.NEW, productService, mainWindow);
                        }
                    }
                    catch (ErrorServiceProd k)
                    {
                        errorHandle(k.Message);
                    }
                    catch (Exception k)
                    {
                        errorHandle("Ismeretlen hiba történt (ContrMainProdBtn2) " + k.Message);
                    }
                } 
            };
        }


        private void setTheNewBtn3ProdEvents()
        {
            removeClickEvent((Button)btn3);
            btn3.Click += (e, a) => {
                if (mgrid.SelectedRows[0].Index != -1)
                {
                    try
                    {
                        int indexFromGrid = mgrid.SelectedRows[0].Index;
                        int recIdentif = (int)mgrid.Rows[indexFromGrid].Cells[0].Value;
                        if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct)     //modify the active qualRec
                        {
                            ProductQualityPart row = productService.getPartContainerOfChosenProductions(recIdentif);
                            productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.MODIFY, productService, mainWindow);
                        }
                        if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)     //modify the active quantRec
                        {
                            ProductFullRow row = productService.getFullistContainerOfProduction(recIdentif);
                            productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.MODIFY, productService, mainWindow);
                        }
                    }
                    catch (ErrorServiceProd k)
                    {
                        errorHandle(k.Message);
                    }
                    catch (Exception k)
                    {
                        errorHandle("Ismeretlen hiba történt (ContrMainProdBtn3) " + k.Message);
                    }
                }
            };
        }


        private void setTheNewBtn4ProdEvents()
        {
            removeClickEvent((Button)btn4);
            btn4.Click += (e, a) => {
                if (mgrid.SelectedRows[0].Index != -1)
                {
                    try
                    {
                        int indexFromGrid = mgrid.SelectedRows[0].Index;
                        int recIdentif = (int)mgrid.Rows[indexFromGrid].Cells[0].Value;
                        if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct)     //delete activeQualRec
                        {
                            ProductQualityPart row = productService.getPartContainerOfChosenProductions(recIdentif);
                            productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.DELETE, productService, mainWindow);

                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiHis)     //react passtiveQualRec 
                        {
                            ProductQualityPart row = productService.getPartContainerOfChosenProductions(recIdentif);
                            productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.UNDELETE, productService, mainWindow);
                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)     //delete activeQuantRec
                        {
                            ProductFullRow row = productService.getFullistContainerOfProduction(recIdentif);
                            productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.DELETE, productService, mainWindow);

                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripHis)     //react passiveQuantRec
                        {
                            ProductFullRow row = productService.getFullistContainerOfProduction(recIdentif);
                            productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.UNDELETE, productService, mainWindow);
                        }
                    }
                    catch (ErrorServiceProd k)
                    {
                        errorHandle(k.Message);
                    }
                    catch (Exception k)
                    {
                        errorHandle("Ismeretlen hiba történt (ContrMainProdBtn4) "+k.Message);
                    }
                }
            };
        }


        private void setTheNewBtn5ProdEvents()
        {
            removeClickEvent((Button)btn5);
            btn5.Click += (e, a) => {
                if (mgrid.SelectedRows[0].Index != -1)
                {
                    try
                    {
                        int indexFromGrid = mgrid.SelectedRows[0].Index;
                        int recIdentif = (int)mgrid.Rows[indexFromGrid].Cells[0].Value;
                        if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct ||
                            actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripHis)
                        {
                            ProductFullRow row = productService.getFullistContainerOfProduction(recIdentif);
                            productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.DETAILS, productService, mainWindow);
                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct ||
                            actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiHis)
                        {
                            ProductQualityPart row = productService.getPartContainerOfChosenProductions(recIdentif);
                            productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.DETAILS, productService, mainWindow);
                        }
                    }
                    catch (ErrorServiceProd w)
                    {
                        errorHandle(w.Message);
                    }
                    catch (Exception w)
                    {
                        errorHandle("Ismeretlen hiba történt (ContrMainGrid) " + w.Message);
                    }
                }
            };
        }

        private void setTheNewBtn6ProdEvents()
        {
            removeClickEvent((Button)btn6);
            btn6.Click += (e, a) => {

                if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct) //it switches to qualDel
                {
                    actServiceForSubEvents = FormMainServiceMode.PRODUCTSMANQualiHis;
                    loadAppropriateProductonGridView();
                    loadAppropiateProductionCommandLineView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiHis) //it swhitches to strippAct
                {
                    actServiceForSubEvents = FormMainServiceMode.PRODUCTSMANStripAct;
                    loadAppropriateProductonGridView();
                    loadAppropiateProductionCommandLineView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct) //it switches to strippDel
                {
                    actServiceForSubEvents = FormMainServiceMode.PRODUCTSMANStripHis;
                    loadAppropriateProductonGridView();
                    loadAppropiateProductionCommandLineView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripHis) //it switches to qualtAct
                {
                    actServiceForSubEvents = FormMainServiceMode.PRODUCTSMANQualiAct;
                    loadAppropriateProductonGridView();
                    loadAppropiateProductionCommandLineView();
                }

            };
        }
    }
}
