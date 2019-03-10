using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.ServProductions;
using WFAThesisProject.UserRightsManage;

namespace WFAThesisProject
{
    public partial class MainController
    {
        private FormServiceProductsWindow productsManageWindow;
        /// <summary>
        /// when this service is loaded in, defines the proper actions
        /// the special events are goint to be redefined
        /// </summary>
        /// <param name="sour">act. rights of the user</param>
        /// <param name="tileProd">the production tile itself</param>
        private void initProductsServBasicEvents(RightLevels rightToManageStore, Control tileProd)
        {
            tileProd.Click += (s, e) =>
            {
                removeDoubleClickEvent(mgrid);
                mgrid.Visible = true;
                actServiceForSubEvents = FormMainServiceMode.PRODUCTSMANStripAct;
                productService = new ServiceProducts(dbci, mainWindow, setOfUserDetails.userId);
                panelOfCommLine.Visible = false;
                if (rightToManageStore == RightLevels.READ)
                {
                    actServiceViewStandard = FromMainServiceViewStandard.READ;
                    loadAppropriateProductonGridView();
                    loadAppropiateProductionCommandLineView();
                    initializeProdAlternativeCommandLineEvent();
                    initializeProdGridViewEvent();
                }
                else if (rightToManageStore == RightLevels.MODiFY)
                {
                    actServiceViewStandard = FromMainServiceViewStandard.OTHER;
                    loadAppropriateProductonGridView();
                    loadAppropiateProductionCommandLineView();
                    initializeProdFullCommandLineEvents();
                }
            };
        }
        /// <summary>
        /// sets the commandLine events - in case of MODIFY permission
        /// </summary>
        private void initializeProdFullCommandLineEvents()
        {
            setTheNewBtn1ProdEvents();
            setTheNewBtn2ProdEvents();
            setTheNewBtn3ProdEvents();
            setTheNewBtn4ProdEvents();
            setTheNewBtn5ProdEvents();
            setTheNewBtn6ProdEvents();
        }
        /// <summary>
        /// sets the btn 6 event - in case of READ permission
        /// </summary>
        private void initializeProdAlternativeCommandLineEvent()
        {
            setTheNewBtn6ProdEvents();
        }
        /// <summary>
        /// sets the gridview event - in case of READ permission
        /// </summary>
        private void initializeProdGridViewEvent()
        {
            removeDoubleClickEvent(mgrid);
            mgrid.DoubleClick += (o, a) =>
            {
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

    }
}
