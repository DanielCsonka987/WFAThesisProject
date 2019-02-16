using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAThesisProject
{
    public partial class MainController
    {
        /// <summary>
        /// defines the modify the active request
        /// </summary>
        private void setTheNewRequEventBtn1()
        {
            removeClickEvent((Button)btn1);
            btn1.Click += (q, w) =>
            {
                if (mgrid.SelectedRows[0] != null)
                {
                    if (mgrid.SelectedRows[0].Index != -1)
                    {
                        if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANActive)
                        {
                            int index = mgrid.SelectedRows[0].Index;
                            serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenActiveRequest(index),
                                RequestWindowPuropse.MorifyTheActive, mainWindow, requestService);
                        }
                    }
                }
            };
        }

        private void setTheNewRequEventBtn2()
        {
            removeClickEvent((Button)btn2);
            btn2.Click += (f, g) =>
            {
                if (mgrid.SelectedRows[0].Index != -1)
                {
                    if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANActive)
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenActiveRequest(index),
                            RequestWindowPuropse.GivingOutTheActive, mainWindow, requestService);
                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANGivenOut) //maintain gets back method
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenGivenOutRequest(index),
                            RequestWindowPuropse.GetBackTheGivenOut, mainWindow, requestService);
                    }
                }
            };
        }
        /// <summary>
        /// defines the delet-renew functions on active-deleted requests
        /// </summary>
        private void setTheNewRequEventBtn3()
        {
            removeClickEvent((Button)btn3);
            btn3.Click += (d, f) =>
            {
                if (mgrid.SelectedRows[0].Index != -1)
                {
                    if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANActive)  //maintain the delete method on an active rec
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenActiveRequest(index),
                            RequestWindowPuropse.DeleteTheActive, mainWindow, requestService);
                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANDeleted)   //maintain the renew method on deleted ones
                    {
                        int index = mgrid.SelectedRows[0].Index;
                        serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenDeletedRequest(index),
                            RequestWindowPuropse.RenewTheDeleted, mainWindow, requestService);
                    }
                }
            };
        }
        /// <summary>
        /// defines tha view change of the service
        /// </summary>
        private void setTheNewRequEventBtn4()       //changes the view
        {
            removeClickEvent((Button)btn4);
            btn4.Click += (e, r) =>
            {
                if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANActive)
                {
                    actServiceForSubEvents = FormMainServiceMode.REQUESTSMANCalledOff;
                    loadAppropiateRequestGridView();
                    loadAppropiateRequestCommandLineView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANCalledOff)
                {
                    actServiceForSubEvents = FormMainServiceMode.REQUESTSMANDeleted;
                    loadAppropiateRequestGridView();
                    loadAppropiateRequestCommandLineView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANDeleted)
                {
                    actServiceForSubEvents = FormMainServiceMode.REQUESTSMANGivenOut;
                    loadAppropiateRequestGridView();
                    loadAppropiateRequestCommandLineView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANGivenOut)
                {
                    actServiceForSubEvents = FormMainServiceMode.REQUESTSMANActive;
                    loadAppropiateRequestGridView();
                    loadAppropiateRequestCommandLineView();
                }
            };
        }

        private void setTheNewRequEventBtn5()
        {
            removeClickEvent((Button)btn5);

        }

        private void setTheNewRequEventBtn6()
        {
            removeClickEvent((Button)btn6);

        }


    }
}
