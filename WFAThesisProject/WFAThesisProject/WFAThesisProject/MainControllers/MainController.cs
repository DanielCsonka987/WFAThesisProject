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
        private ServiceProducts productService;
        private ServiceRequests requestService;

        private FormMainController05Ordering ordering;  //not implem
        private FormMainController02Accidents accidents;  //not implem
        private FormMainController06Subcontr subcontructors;  //not implem
        private FormMainController01UsersManage globalUsers;  //not implem

        private SetOfUserDetails setOfUserDetails;
        private Form mainWindow;
        private UserConnDetails dbci;
        private MetroFramework.Controls.MetroGrid mgrid;
        private Control btn1;
        private Control btn2;
        private Control btn3;
        private Control btn4;
        private Control btn5;
        private Control btn6;
        private Control infoLabel;
        private Control panelOfCommLine;
        private FormMainServiceMode actServiceForSubEvents;

        public MainController(SetOfUserDetails soud, SetOfUserRights sour, Form parentalMainWindow, UserConnDetails dbci)
        {
            this.mainWindow = parentalMainWindow;
            this.setOfUserDetails = soud;
            this.dbci = dbci;
            initializeMainWindowElementsByRightsOfUser(sour);
            catchTheControlsOfServices();
        }

        /// <summary>
        /// it handles the coming back from sidewindows -> re-read the content of gridTable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadInGridToShowProperContent()
        {
            if (mainWindow.Visible == true)
            {
                if (actServiceForSubEvents == FormMainServiceMode.USERSMAN)
                {

                }
                else if (actServiceForSubEvents == FormMainServiceMode.RIGHTSMAN)
                {

                }
                else if (actServiceForSubEvents == FormMainServiceMode.ACCIDENTSMAN)
                {

                }
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct ||
                    actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiHis ||
                    actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct ||
                    actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripHis)
                {
                    loadAppropiateProductonGridView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANActive ||
                    actServiceForSubEvents == FormMainServiceMode.REQUESTSMANCalledOff ||
                    actServiceForSubEvents == FormMainServiceMode.REQUESTSMANDeleted ||
                    actServiceForSubEvents == FormMainServiceMode.REQUESTSMANGivenOut)
                {
                    loadAppropiateRequestGridView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGMAN)
                {

                }
                else if (actServiceForSubEvents == FormMainServiceMode.SUBCONTRACTORSMAN)
                {

                }
                else if (actServiceForSubEvents == FormMainServiceMode.OPENING)
                {
                    //a picture is needed to switch on
                }
            }
        }

        private void catchTheControlsOfServices()
        {
            panelOfCommLine = mainWindow.Controls.Find("mPanelComm",true).First();
            mgrid = (MetroFramework.Controls.MetroGrid) mainWindow.Controls.Find("mGridMain", true).First();
            infoLabel = mainWindow.Controls.Find("mLabelModeShow", true).First();
            btn1 = mainWindow.Controls.Find("metroTile1",true).First();
            btn2 = mainWindow.Controls.Find("metroTile2",true).First();
            btn3 = mainWindow.Controls.Find("metroTile3", true).First();
            btn4 = mainWindow.Controls.Find("metroTile4",true).First();
            btn5 = mainWindow.Controls.Find("metroTile5",true).First();
            btn6 = mainWindow.Controls.Find("metroTile6", true).First();
        }
    }
}
