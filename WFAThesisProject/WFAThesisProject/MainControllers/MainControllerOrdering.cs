using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.ServOrdering;
using WFAThesisProject.UserRightsManage;

namespace WFAThesisProject
{
    public partial class MainController
    {
        private FormServiceOrderingWindow orderingWindow;
        private FormServiceOrdBookArriveWin orderingBookArriveWin;

        private void initOrderingServBasicEvents(RightLevels rightToManageOrdering, Control tileOrdering)
        {
            tileOrdering.Click += (f,g) =>
            {
                removeDoubleClickEvent(mgrid);
                mgrid.Visible = true;
                actServiceForSubEvents = FormMainServiceMode.ORDERINGNoted;
                orderingService = new ServiceOrdering(dbci, mainWindow, setOfUserDetails.userId);
                panelOfCommLine.Visible = false;
                if (rightToManageOrdering == RightLevels.READ)
                {
                    actServiceViewStandard = FromMainServiceViewStandard.READ;
                    loadAppropriateOrderingGridView();
                    loadAppropiateOrderingCommandLineView();
                    initializeOrdGridViewDetailsEvent();
                    initializeOrdAlternativeComangLineEvent();
                }
                else if (rightToManageOrdering == RightLevels.MODiFY)
                {
                    actServiceViewStandard = FromMainServiceViewStandard.OTHER;
                    loadAppropriateOrderingGridView();
                    loadAppropiateOrderingCommandLineView();
                    initializeOrdFullCommandLineEvents();
                }
            };
        }
        /// <summary>
        /// sets the full command line events - in case MODIFY permission
        /// </summary>
        private void initializeOrdFullCommandLineEvents()
        {
            setTheNewBtn1OrderEvents();
            setTheNewBtn2OrderEvents();
            setTheNewBtn3OrderEvents();
            setTheNewBtn4OrderEvents();
            setTheNewBtn5OrderEvents();
            setTheNewBtn6OrderEvents();
        }
        /// <summary>
        /// sets the btn6 event - in case READ permission
        /// </summary>
        private void initializeOrdAlternativeComangLineEvent()
        {
            setTheNewBtn6OrderEvents();
        }

        /// <summary>
        /// sets the mgridview event - in case READ permission
        /// </summary>
        private void initializeOrdGridViewDetailsEvent()
        {
            mgrid.DoubleClick += (w, k) =>
            {
                try
                {
                    if (mgrid.SelectedRows[0].Index != -1)
                    {
                        int index = (int)mgrid.SelectedRows[0].Cells[0].Value;
                        if (actServiceForSubEvents == FormMainServiceMode.ORDERINGCancelled)
                        {
                            orderingWindow = new FormServiceOrderingWindow(orderingService.getChosenCancelledOrdering(index),
                                OrderingWindowPurpose.DETAILS, mainWindow, orderingService);
                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGNoted)
                        {
                            orderingWindow = new FormServiceOrderingWindow(orderingService.getChosenNotedOrdering(index),
                                OrderingWindowPurpose.DETAILS, mainWindow, orderingService);
                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGBooked)
                        {
                            orderingWindow = new FormServiceOrderingWindow(orderingService.getChosenBookedOrdering(index),
                                OrderingWindowPurpose.DETAILS, mainWindow, orderingService);

                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGArrived)
                        {
                            orderingWindow = new FormServiceOrderingWindow(orderingService.getChosenArrivedOrdering(index),
                                OrderingWindowPurpose.DETAILS, mainWindow, orderingService);
                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGMissing)
                        {
                            orderingWindow = new FormServiceOrderingWindow(orderingService.getChosenMissingOrdering(index),
                                OrderingWindowPurpose.DETAILS, mainWindow, orderingService);
                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGFailed)
                        {
                            orderingWindow = new FormServiceOrderingWindow(orderingService.getChosenFailedOrdering(index),
                                OrderingWindowPurpose.DETAILS, mainWindow, orderingService);
                        }
                    }
                }
                catch (ErrorServiceOrdering e)
                {
                    errorHandle(e.Message);
                }
                catch (Exception e)
                {
                    errorHandle("Ismertlen hiba történt (MainContrGridOrd) " + e.Message);
                }
            };
        }


    }
}
