using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using WFAThesisProject.UserRightsManage;

namespace WFAThesisProject
{
    public partial class MainController
    {
        private FormServiceRequestsWindow serviceRequWindow;

        private void initRequestSercBasicEvents(SetOfUserRights setOfUserRights, Control tileRequest)
        {
            tileRequest.Click += (e, o) => 
            {
                actServiceForSubEvents = FormMainServiceMode.REQUESTSMANActive;
                requestService = new ServiceRequests(dbci, mainWindow, setOfUserDetails.userId);
                panelOfCommLine.Visible = false;
                if (setOfUserRights.getuR8_ReqMan() == RightLevels.READ)
                {
                    loadAppropiateRequestGridView();
                    initializeRequGridViewEvent();
                }
                else if (setOfUserRights.getuR8_ReqMan() == RightLevels.MODiFY)
                {
                    loadAppropiateRequestGridView();
                    initializeRequGridViewEvent();
                    loadAppropiateRequestCommandLineView();
                    initializeConnamdLineEvents();
                }
            };
        }


        private void initializeConnamdLineEvents()
        {
            setTheNewRequEventBtn1();
            setTheNewRequEventBtn2();
            setTheNewRequEventBtn3();
            setTheNewRequEventBtn4();
            setTheNewRequEventBtn5();
            setTheNewRequEventBtn6();
        }


        private void initializeRequGridViewEvent()
        {
            removeDoubleClickEvent(mgrid);
            mgrid.DoubleClick += (w, k) =>
            {
                if (mgrid.SelectedRows[0].Index != -1)
                {
                    if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANActive)
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenActiveRequest(index),
                            RequestWindowPuropse.DetailsOfActive, mainWindow, requestService);
                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANCalledOff)
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenCalledOffRequest(index),
                            RequestWindowPuropse.DetailsOfCancelled, mainWindow, requestService);
                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANDeleted)
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenDeletedRequest(index),
                            RequestWindowPuropse.DetailsOfDeleted, mainWindow, requestService);

                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANGivenOut)
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenGivenOutRequest(index),
                            RequestWindowPuropse.DetailsOfGivenOut, mainWindow, requestService);
                    }
                }
            };
        }


    }
}
