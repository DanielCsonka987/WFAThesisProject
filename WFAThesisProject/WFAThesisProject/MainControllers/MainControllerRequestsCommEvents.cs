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
                            int requId = 0;
                            try
                            {
                                int indexInGrid = mgrid.SelectedRows[0].Index;
                                requId = (int)mgrid.Rows[indexInGrid].Cells[0].Value;
                                if (requId != 0)
                                {
                                    serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenActiveRequest(requId),
                                    RequestWindowPuropse.MorifyTheActive, mainWindow, requestService);
                                }
                            }
                            catch (ErrorServiceRequests e)
                            {
                                errorHandle(e.Message);
                            }
                            catch (Exception e)
                            {
                                errorHandle("Ismeretlen hiba történt (MainContrBtn1) " + e.Message);
                            }
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
                    int requId = 0;
                    try
                    {
                        int indexInGrid = mgrid.SelectedRows[0].Index;
                        requId = (int)mgrid.Rows[indexInGrid].Cells[0].Value;
                        if (requId != 0)
                        {
                            if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANActive)
                            {
                                serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenActiveRequest(requId),
                                    RequestWindowPuropse.GivingOutTheActive, mainWindow, requestService);
                            }
                            else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANGivenOut) //maintain gets back method
                            {
                                serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenGivenOutRequest(requId),
                                    RequestWindowPuropse.GetBackTheGivenOut, mainWindow, requestService);
                            }
                        }
                    }
                    catch (ErrorServiceRequests e)
                    {
                        errorHandle(e.Message);
                    }
                    catch (Exception e)
                    {
                        errorHandle("Ismeretlen hiba történt (MainContrBtn2) " + e.Message);
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
                    int requId = 0;
                    try
                    {
                        int indexInGrid = mgrid.SelectedRows[0].Index;
                        requId = (int)mgrid.Rows[indexInGrid].Cells[0].Value;
                        if (requId != 0)
                        {
                            if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANActive)  //maintain the delete method on an active rec
                            {
                                serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenActiveRequest(requId),
                                    RequestWindowPuropse.DeleteTheActive, mainWindow, requestService);
                            }
                            else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANDeleted)   //maintain the renew method on deleted ones
                            {
                                serviceRequWindow = new FormServiceRequestsWindow(requestService.getChosenDeletedRequest(requId),
                                    RequestWindowPuropse.RenewTheDeleted, mainWindow, requestService);
                            }
                        }
                    }
                    catch (ErrorServiceRequests e)
                    {
                        errorHandle(e.Message);
                    }
                    catch (Exception e)
                    {
                        errorHandle("Ismeretlen hiba történt (MainContrBtn3) " + e.Message);
                    }
                }
            };
        }

        private void setTheNewRequEventBtn4()       
        {
            removeClickEvent((Button)btn4);
            btn4.Click += (h, r) =>
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

        private void setTheNewRequEventBtn5()
        {
            

        }
        /// <summary>
        /// defines tha view change of the service
        /// </summary>
        private void setTheNewRequEventBtn6()       //changes the view
        {
            removeClickEvent((Button)btn6);
            btn6.Click += (w, t) => 
            {
                if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANActive)
                {
                    actServiceForSubEvents = FormMainServiceMode.REQUESTSMANCalledOff;
                    loadAppropriateRequestGridView();
                    loadAppropiateRequestCommandLineView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANCalledOff)
                {
                    actServiceForSubEvents = FormMainServiceMode.REQUESTSMANDeleted;
                    loadAppropriateRequestGridView();
                    loadAppropiateRequestCommandLineView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANDeleted)
                {
                    actServiceForSubEvents = FormMainServiceMode.REQUESTSMANGivenOut;
                    loadAppropriateRequestGridView();
                    loadAppropiateRequestCommandLineView();
                }
                else if (actServiceForSubEvents == FormMainServiceMode.REQUESTSMANGivenOut)
                {
                    actServiceForSubEvents = FormMainServiceMode.REQUESTSMANActive;
                    loadAppropriateRequestGridView();
                    loadAppropiateRequestCommandLineView();
                }

            };
        }


    }
}
