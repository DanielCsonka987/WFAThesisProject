using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.UserNamePasswordManage;
using WFAThesisProject.UserRightsManage;

namespace WFAThesisProject
{
    public partial class MainController
    {
        private ServiceProducts productService;
        private ServiceRequests requestService;
        private ServiceOrdering orderingService;

        private FormMainController02Accidents accidents;  //not implem
        private FormMainController06Subcontr subcontructors;  //not implem
        private FormMainController01UsersManage globalUsers;  //not implem

        private SetOfUserDetails setOfUserDetails;
        private Form mainWindow;
        private UserConnDetails dbci;
        private FormMainServiceMode actServiceForSubEvents;         //defined in the mainWindow class
        private FromMainServiceViewStandard actServiceViewStandard;       //defined in the mainWindow class

        private MetroFramework.Controls.MetroGrid mgrid;
        private MetroFramework.Controls.MetroPanel introPicture;
        private MetroFramework.Controls.MetroPanel logoArea;
        private Control btn1;
        private Control btn2;
        private Control btn3;
        private Control btn4;
        private Control btn5;
        private Control btn6;
        private Control infoLabel;
        private Control alternatLabel;
        private Control panelOfCommLine;

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
                else if (actServiceForSubEvents == FormMainServiceMode.OPENING)
                {
                    loadInTheInitialView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.ACCIDENTSMAN)
                {

                }
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct ||
                    actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiHis ||
                    actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct ||
                    actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripHis)
                {
                    loadAppropriateProductonGridView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANActive ||
                    actServiceForSubEvents == FormMainServiceMode.REQUESTSMANCalledOff ||
                    actServiceForSubEvents == FormMainServiceMode.REQUESTSMANDeleted ||
                    actServiceForSubEvents == FormMainServiceMode.REQUESTSMANGivenOut)
                {
                    loadAppropriateRequestGridView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGNoted ||
                    actServiceForSubEvents == FormMainServiceMode.ORDERINGCancelled ||
                    actServiceForSubEvents == FormMainServiceMode.ORDERINGBooked ||
                    actServiceForSubEvents == FormMainServiceMode.ORDERINGArrived ||
                    actServiceForSubEvents == FormMainServiceMode.ORDERINGMissing ||
                    actServiceForSubEvents == FormMainServiceMode.ORDERINGFailed)
                {
                    loadAppropriateOrderingGridView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.SUBCONTRACTORSMAN)
                {

                }
            }
        }


        public void loadInTheInitialView()
        {
            introPicture.Visible = true;
            actServiceForSubEvents = FormMainServiceMode.OPENING;
            mgrid.Visible = false;
            panelOfCommLine.Visible = false;
            btn6.Visible = false;
            infoLabel.Text = "Üdvözöljük!";
        }

        private void catchTheControlsOfServices()
        {
            panelOfCommLine = mainWindow.Controls.Find("mPanelComm",true).First();
            mgrid = (MetroFramework.Controls.MetroGrid) mainWindow.Controls.Find("mGridMain", true).First();
            introPicture = (MetroFramework.Controls.MetroPanel)mainWindow.Controls.Find("mPnlIntroPicture", true).First();
            infoLabel = mainWindow.Controls.Find("mLabelModeShow", true).First();
            alternatLabel = mainWindow.Controls.Find("mLblAlternativeCommline",true).First();
            logoArea = (MetroFramework.Controls.MetroPanel)mainWindow.Controls.Find("mPnlLogoArea", true).First(); 
            btn1 = mainWindow.Controls.Find("metroTile1",true).First();
            btn2 = mainWindow.Controls.Find("metroTile2",true).First();
            btn3 = mainWindow.Controls.Find("metroTile3", true).First();
            btn4 = mainWindow.Controls.Find("metroTile4",true).First();
            btn5 = mainWindow.Controls.Find("metroTile5",true).First();
            btn6 = mainWindow.Controls.Find("metroTile6", true).First();
        }

        private void errorHandle(string message)
        {
            MetroFramework.MetroMessageBox.Show(mainWindow, message, "Figyelmeztetés!", MessageBoxButtons.OK,
                MessageBoxIcon.Error, 200);
        }
    }
}
