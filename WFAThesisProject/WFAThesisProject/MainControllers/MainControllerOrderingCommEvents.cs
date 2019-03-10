using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.ServOrdering;

namespace WFAThesisProject
{
    public partial class MainController
    {

        private void setTheNewBtn1OrderEvents()
        {
            btn1.Click += (q, x) =>
            {
                try
                {
                    if (actServiceForSubEvents == FormMainServiceMode.ORDERINGNoted)    //order
                    {
                        //collect all the record and start create PDF and overwrite validity field
                        List<OrderingNoted> listOrdNoted = new List<OrderingNoted>();
                        foreach(DataGridViewRow rec in mgrid.Rows)
                        {
                            if ((bool)rec.Cells["Rendelés"].Value)
                                listOrdNoted.Add(orderingService.getChosenNotedOrdering((int)rec.Cells[0].Value));
                        }
                        if (listOrdNoted.Count > 0)
                            orderingBookArriveWin = new FormServiceOrdBookArriveWin(listOrdNoted, mainWindow, 
                                orderingService, setOfUserDetails);
                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGBooked)  //arrived
                    {
                        //collect all the record and rewrite validity field

                        List<OrderingBooked> listOrdBooked = new List<OrderingBooked>();
                        foreach (DataGridViewRow rec in mgrid.Rows)
                        {
                            if ((bool)rec.Cells["Beérkezés"].Value)
                                listOrdBooked.Add(orderingService.getChosenBookedOrdering((int)rec.Cells[0].Value));
                        }
                        if (listOrdBooked.Count > 0)
                            orderingBookArriveWin = new FormServiceOrdBookArriveWin(listOrdBooked, mainWindow,
                                orderingService);
                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGMissing) //arrived
                    {
                        if (mgrid.SelectedRows[0].Index != -1)
                        {
                            int indexFromGrid = mgrid.SelectedRows[0].Index;
                            int recId = (int)mgrid.Rows[indexFromGrid].Cells[0].Value;
                            OrderingMissing rec = orderingService.getChosenMissingOrdering(recId);
                            orderingWindow = new FormServiceOrderingWindow(rec, OrderingWindowPurpose.MakeItPARTLYARRIVED,
                                mainWindow, orderingService);
                        }
                    }else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGCancelled)  //renew cancelled
                    {
                        int indexFromGrid = mgrid.SelectedRows[0].Index;
                        int recId = (int)mgrid.Rows[indexFromGrid].Cells[0].Value;
                        OrderingCancelled rec = orderingService.getChosenCancelledOrdering(recId);
                        orderingWindow = new FormServiceOrderingWindow(rec, OrderingWindowPurpose.RENEW,
                            mainWindow, orderingService);
                    }
                }
                catch (ErrorServiceOrdering w)
                {
                    errorHandle(w.Message);
                }
                catch (Exception w)
                {
                    errorHandle("Ismeretlen hiba történt (MainContrOrdBtn1) " + w.Message);
                }
            };
        }


        private void setTheNewBtn2OrderEvents()
        {
            btn2.Click += (r, e) => 
            {
                try
                {
                    if (mgrid.SelectedRows[0].Index != -1)
                    {
                        int indexFromGrid = mgrid.SelectedRows[0].Index;
                        int recId = (int)mgrid.Rows[indexFromGrid].Cells[0].Value;
                        if (actServiceForSubEvents == FormMainServiceMode.ORDERINGNoted)    //modify
                        {
                            OrderingNoted rec = orderingService.getChosenNotedOrdering(recId);
                            orderingWindow = new FormServiceOrderingWindow(rec, OrderingWindowPurpose.MODFIY,
                                mainWindow, orderingService);
                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGBooked)  //partly arrived
                        {
                            OrderingBooked rec = orderingService.getChosenBookedOrdering(recId);
                            orderingWindow = new FormServiceOrderingWindow(rec, OrderingWindowPurpose.MakeItPARTLYARRIVED,
                                mainWindow, orderingService);
                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGMissing) //partyl arrived
                        {
                            OrderingMissing rec = orderingService.getChosenMissingOrdering(recId);
                            orderingWindow = new FormServiceOrderingWindow(rec, OrderingWindowPurpose.MakeItPARTLYARRIVED,
                                mainWindow, orderingService);
                        }
                    }
                }
                catch (ErrorServiceOrdering w)
                {
                    errorHandle(w.Message);
                }
                catch (Exception w)
                {
                    errorHandle("Ismeretlen hiba történt (MainContrOrdBtn2) " + w.Message);
                }
            };
        }

        private void setTheNewBtn3OrderEvents()
        {
            btn3.Click += (f, g) => 
            {
                try
                {
                    if (mgrid.SelectedRows[0].Index != -1)
                    {
                        int indexFromGrid = mgrid.SelectedRows[0].Index;
                        int recId = (int)mgrid.Rows[indexFromGrid].Cells[0].Value;
                        if (actServiceForSubEvents == FormMainServiceMode.ORDERINGNoted)    //cancel
                        {
                            OrderingNoted rec = orderingService.getChosenNotedOrdering(recId);
                            orderingWindow = new FormServiceOrderingWindow(rec, OrderingWindowPurpose.CANCEL,
                                mainWindow, orderingService);
                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGBooked)  //fail
                        {
                            OrderingBooked rec = orderingService.getChosenBookedOrdering(recId);
                            orderingWindow = new FormServiceOrderingWindow(rec, OrderingWindowPurpose.MakeItFAILED,
                                mainWindow, orderingService);
                        }
                        else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGMissing) //fail
                        {
                            OrderingMissing rec = orderingService.getChosenMissingOrdering(recId);
                            orderingWindow = new FormServiceOrderingWindow(rec, OrderingWindowPurpose.MakeItFAILED,
                                mainWindow, orderingService);
                        }
                    }
                }
                catch (ErrorServiceOrdering w)
                {
                    errorHandle(w.Message);
                }
                catch (Exception w)
                {
                    errorHandle("Ismeretlen hiba történt (MainContrOrdBtn3) " + w.Message);
                }
            };
        }

        private void setTheNewBtn4OrderEvents()
        {
            btn4.Click += (s, y) =>
            {
                try
                {
                    if (actServiceForSubEvents == FormMainServiceMode.ORDERINGNoted)    //create new
                    {
                        orderingWindow = new FormServiceOrderingWindow(setOfUserDetails, OrderingWindowPurpose.NEW,
                            mainWindow, orderingService);
                    }

                }
                catch (Exception w)
                {
                    errorHandle("Ismeretlen hiba történt (MainContrOrdBtn4) " + w.Message);
                }
            };
        }

        private void setTheNewBtn5OrderEvents()
        {
            btn5.Click += (r, t) =>
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

        private void setTheNewBtn6OrderEvents()
        {
            btn6.Click += (e, a) =>
            {
                try
                {
                    if (actServiceForSubEvents == FormMainServiceMode.ORDERINGCancelled)
                    {
                        actServiceForSubEvents = FormMainServiceMode.ORDERINGNoted;
                        loadAppropriateOrderingGridView();
                        loadAppropiateOrderingCommandLineView();
                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGNoted)
                    {
                        actServiceForSubEvents = FormMainServiceMode.ORDERINGBooked;
                        loadAppropriateOrderingGridView();
                        loadAppropiateOrderingCommandLineView();
                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGBooked)
                    {
                        actServiceForSubEvents = FormMainServiceMode.ORDERINGArrived;
                        loadAppropriateOrderingGridView();
                        loadAppropiateOrderingCommandLineView();
                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGArrived)
                    {
                        actServiceForSubEvents = FormMainServiceMode.ORDERINGMissing;
                        loadAppropriateOrderingGridView();
                        loadAppropiateOrderingCommandLineView();
                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGMissing)
                    {
                        actServiceForSubEvents = FormMainServiceMode.ORDERINGFailed;
                        loadAppropriateOrderingGridView();
                        loadAppropiateOrderingCommandLineView();
                    }
                    else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGFailed)
                    {
                        actServiceForSubEvents = FormMainServiceMode.ORDERINGCancelled;
                        loadAppropriateOrderingGridView();
                        loadAppropiateOrderingCommandLineView();
                    }
                }
                catch (ErrorServiceOrdering w)
                {
                    errorHandle(w.Message);
                }
                catch (Exception w)
                {
                    errorHandle("Ismeretlen hiba történt (MainContrOrdGrid) " + w.Message);
                }
            };
        }
    }
}
