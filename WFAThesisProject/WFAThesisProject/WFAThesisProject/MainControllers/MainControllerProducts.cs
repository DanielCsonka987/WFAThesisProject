using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private void initProductsServBasicEvents(SetOfUserRights sour, Control tileProd)
        {
            tileProd.Click += (s, e) =>
            {
                actServiceForSubEvents = FormMainServiceMode.PRODUCTSMANStripAct;
                productService = new ServiceProducts(dbci, mainWindow, setOfUserDetails.userId);
                panelOfCommLine.Visible = false;
                if (sour.getuR7_ProductsMan() == RightLevels.READ)
                {
                    loadAppropiateProductonGridView();
                    initializeProdGridViewEvent();
                }
                else if (sour.getuR7_ProductsMan() == RightLevels.MODiFY)
                {
                    loadAppropiateProductonGridView();
                    initializeProdGridViewEvent();
                    initializeCommandLineEvents();
                    loadAppropiateProductionCommandLineView();
                }
            };
        }

        private void initializeCommandLineEvents()
        {
            setTheNewBtn1ProdEvents();
            setTheNewBtn2ProdEvents();
            setTheNewBtn3ProdEvents();
            setTheNewBtn4ProdEvents();
            setTheNewBtn5ProdEvents();
            setTheNewBtn6ProdEvents();
        }

        private void initializeProdGridViewEvent()
        {
            removeDoubleClickEvent(mgrid);
            mgrid.DoubleClick += (o, a) =>
            {
                if (mgrid.SelectedRows[0].Index != -1)
                {
                    if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct ||
                        actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripHis)
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        List<ProductFullRow> allList = productService.getFullListOfProductions();
                        ProductFullRow row = allList[index];
                        productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.DETAILS, productService, mainWindow);
                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct ||
                        actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiHis)
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        List<ProductQualityPart> partList = productService.getPartListOfProductions();
                        ProductQualityPart row = partList[index];
                        productsManageWindow = new FormServiceProductsWindow(row, ProductWindowPurpose.DETAILS, productService, mainWindow);
                    }
                }
            };
        }

    }
}
