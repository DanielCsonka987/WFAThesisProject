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

        private void initRequestServBasicEvents(RightLevels rightToManageRequests, Control tileRequest)
        {
            tileRequest.Click += (e, o) => 
            {
                removeDoubleClickEvent(mgrid);
                mgrid.Visible = true;
                actServiceForSubEvents = FormMainServiceMode.REQUESTSMANActive;
                requestService = new ServiceRequests(dbci, mainWindow, setOfUserDetails.userId);
                panelOfCommLine.Visible = false;
                if (rightToManageRequests == RightLevels.READ)
                {
                    actServiceViewStandard = FromMainServiceViewStandard.READ;
                    loadAppropriateRequestGridView();
                    loadAppropiateRequestCommandLineView();
                    initializeInTheAlternativeRequCommandLineButton();
                    initializeRequGridViewEvent();
                }
                else if (rightToManageRequests == RightLevels.MODiFY)
                {
                    actServiceViewStandard = FromMainServiceViewStandard.OTHER;
                    loadAppropriateRequestGridView();
                    loadAppropiateRequestCommandLineView();
                    initializeRequConnamdLineEvents();
                }
            };
        }

        /// <summary>
        /// adjust the CommandLine buttons events - case of MODIFY persmission
        /// </summary>
        private void initializeRequConnamdLineEvents()
        {
            setTheNewRequEventBtn1();
            setTheNewRequEventBtn2();
            setTheNewRequEventBtn3();
            setTheNewRequEventBtn4();
            setTheNewRequEventBtn5();
            setTheNewRequEventBtn6();
        }
        /// <summary>
        /// adjust the alternative CommandLine button event - case of READ permission
        /// </summary>
        private void initializeInTheAlternativeRequCommandLineButton()
        {
            setTheNewRequEventBtn6();
        }
        /// <summary>
        /// adjust the GridView event - case of READ permission
        /// </summary>
        private void initializeRequGridViewEvent()
        {
            mgrid.DoubleClick += (w, k) =>
            {
                if (mgrid.SelectedRows[0].Index != -1)
                {
                    try
                    {
                        if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANActive)
                        {
                            int requId = 0;

                            int indexInGrid = mgrid.SelectedRows[0].Index;
                            requId = (int)mgrid.Rows[indexInGrid].Cells[0].Value;
                            if (requId != 0)
                            {
                                serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenActiveRequest(requId),
                                RequestWindowPuropse.DetailsOfActive, mainWindow, requestService);
                            }
                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANCalledOff)
                        {
                            int requId = 0;
                            int indexInGrid = mgrid.SelectedRows[0].Index;
                            requId = (int)mgrid.Rows[indexInGrid].Cells[0].Value;
                            if (requId != 0)
                            {
                                serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenCalledOffRequest(requId),
                                RequestWindowPuropse.DetailsOfCancelled, mainWindow, requestService);
                            }

                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANDeleted)
                        {
                            int requId = 0;
                            int indexInGrid = mgrid.SelectedRows[0].Index;
                            requId = (int)mgrid.Rows[indexInGrid].Cells[0].Value;
                            if (requId != 0)
                            {
                                serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenDeletedRequest(requId),
                                RequestWindowPuropse.DetailsOfDeleted, mainWindow, requestService);
                            }

                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANGivenOut)
                        {
                            int requId = 0;
                            int indexInGrid = mgrid.SelectedRows[0].Index;
                            requId = (int)mgrid.Rows[indexInGrid].Cells[0].Value;
                            if (requId != 0)
                            {
                                serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenGivenOutRequest(requId),
                                RequestWindowPuropse.DetailsOfGivenOut, mainWindow, requestService);
                            }
                        }

                    }
                    catch (ErrorServiceRequests e)
                    {
                        errorHandle(e.Message);
                    }
                    catch (Exception e)
                    {
                        errorHandle("Ismeretlen hiba történt (ContrMainGrid) " + e.Message);
                    }
                }
            };
        }


    }
}
