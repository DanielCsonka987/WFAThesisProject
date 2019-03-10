using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFAThesisProject.ServOrdering;

namespace WFAThesisProject
{
    public partial class MainController
    {
        private void loadAppropriateOrderingGridView()
        {
            try
            {
                introPicture.Visible = false;
                mgrid.ReadOnly = false;
                if (actServiceForSubEvents == FormMainServiceMode.ORDERINGCancelled)
                {
                    infoLabel.Text = "Rendeléskezelés\nVisszavont rendelési tételek";
                    mgrid.DataSource = orderingService.getCancelledOrdersDataTable();
                    mgrid.Columns[0].Width = 50;
                    mgrid.Columns[1].Width = 200;
                    mgrid.Columns[3].Width = 80;
                    mgrid.Style = MetroFramework.MetroColorStyle.Blue;
                }
                else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGNoted)
                {
                    infoLabel.Text = "Rendeléskezelés\nBejegyzett rendelési tételek";
                    mgrid.DataSource = orderingService.getNotedOrdersDataTable();
                    mgrid.Columns[0].Width = 50;
                    mgrid.Columns[1].Width = 200;
                    mgrid.Columns[3].Width = 80;
                    mgrid.Columns[6].Width = 70;
                    mgrid.Style = MetroFramework.MetroColorStyle.Lime;
                    mgrid.Columns["Rendelés"].ReadOnly = false;
                }
                else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGBooked)
                {
                    infoLabel.Text = "Rendeléskezelés\nLeadott rendelési tételek";
                    mgrid.DataSource = orderingService.getBookedOrdersDataTable();
                    mgrid.Columns[0].Width = 50;
                    mgrid.Columns[1].Width = 200;
                    mgrid.Columns[3].Width = 80;
                    mgrid.Columns[7].Width = 70;
                    mgrid.Style = MetroFramework.MetroColorStyle.Lime;
                    mgrid.Columns["Beérkezés"].ReadOnly = false;
                }
                else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGArrived)
                {
                    infoLabel.Text = "Rendeléskezelés\nÁtvett rendelési tételek";
                    mgrid.DataSource = orderingService.getArrivedOrdersDataTable();
                    mgrid.Columns[0].Width = 50;
                    mgrid.Columns[1].Width = 200;
                    mgrid.Columns[3].Width = 80;
                    mgrid.Style = MetroFramework.MetroColorStyle.Green;
                }
                else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGMissing)
                {
                    infoLabel.Text = "Rendeléskezelés\nHátramaradt rendelési tételek";
                    mgrid.DataSource = orderingService.getMissingOrdersDataTable();
                    mgrid.Columns[0].Width = 50;
                    mgrid.Columns[1].Width = 200;
                    mgrid.Columns[3].Width = 80;
                    mgrid.Style = MetroFramework.MetroColorStyle.Orange;
                }
                else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGFailed)
                {
                    infoLabel.Text = "Rendeléskezelés\nMeghiúsult rendelési tételek";
                    mgrid.DataSource = orderingService.getFailedOrdersDataTable();
                    mgrid.Columns[0].Width = 50;
                    mgrid.Columns[1].Width = 200;
                    mgrid.Style = MetroFramework.MetroColorStyle.Red;
                }
            }
            catch (ErrorServiceOrdering e)
            {
                errorHandle(e.Message);
            }
            catch (Exception e)
            {
                errorHandle("Ismeretlen hiba történt (ContrMainOrdView) " + e.Message);
            }
        }

        /// <summary>
        /// manages which commandline vieww is needed at ordering manage
        /// </summary>
        private void loadAppropiateOrderingCommandLineView()
        {
            if(actServiceViewStandard == FromMainServiceViewStandard.OTHER)
            {
                panelOfCommLine.Visible = true;
                if (actServiceForSubEvents == FormMainServiceMode.ORDERINGCancelled)
                    loadInTheCancelledOrdCommandView();
                else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGNoted)
                    loadInTheNotedOrdCommandView();
                else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGBooked)
                    loadInTheBookedOrdCommandView();
                else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGArrived)
                    loadInTheArrivedOrdCommandView();
                else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGMissing)
                    loadIntHeMissingOrdCommandView();
                else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGFailed)
                    loadInTheFailedOrdCommandView();
            }
            else
            {
                panelOfCommLine.Visible = false;
                alternatLabel.Visible = true;
                loadInAlternativeCommandLine();
            }
        }
        /// <summary>
        /// adjust the commandline to fit the cancelled orderings
        /// </summary>
        private void loadInTheCancelledOrdCommandView()
        {
            btn1.Enabled = true;
            btn1.Text = "Visszaállít";
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            //btn5.Visible = false;

            //btn6.Visible = true;
            btn6.Text = "Bejegyzett rendelések";
        }
        /// <summary>
        /// adjust the commandline to fit the nodet orderings
        /// </summary>
        private void loadInTheNotedOrdCommandView()
        {
            btn1.Visible = true;
            btn1.Enabled = true;
            btn1.Text = "Rendel";
            ((MetroFramework.Controls.MetroTile)btn1).Style = MetroFramework.MetroColorStyle.Green;
            btn2.Visible = true;
            btn2.Enabled = true;
            btn2.Text = "Módosít";
            ((MetroFramework.Controls.MetroTile)btn2).Style = MetroFramework.MetroColorStyle.Lime;
            btn3.Visible = true;
            btn3.Enabled = true;
            btn3.Text = "Viszavon";
            ((MetroFramework.Controls.MetroTile)btn3).Style = MetroFramework.MetroColorStyle.Red;
            btn4.Visible = true;
            btn4.Enabled = true;
            btn4.Text = "Új rendelés";
            ((MetroFramework.Controls.MetroTile)btn4).Style = MetroFramework.MetroColorStyle.Lime;
            btn5.Visible = true;
            btn5.Enabled = true;
            btn5.Text = "Tulajdonságok";
            ((MetroFramework.Controls.MetroTile)btn5).Style = MetroFramework.MetroColorStyle.Teal;

            btn6.Visible = true;
            btn6.Enabled = true;
            btn6.Text = "Leadott rendelések";
            ((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Silver;
        }
        /// <summary>
        /// adjust the commandline to fit the booked orderings
        /// </summary>
        private void loadInTheBookedOrdCommandView()
        {
            btn1.Text = "Beérkezett";
            btn2.Text = "Részben jött";
            btn3.Text = "Meghíusult";
            btn4.Enabled = false;
            //btn5.Visible = true;

            //btn6.Visible = true;
            btn6.Text = "Átvett rendelések";
        }
        /// <summary>
        /// adjust the commandline to fit the arriced orderings
        /// </summary>
        private void loadInTheArrivedOrdCommandView()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            //btn5.Visible = true;

            //btn6.Visible = true;
            btn6.Text = "Hiányzó rendelések";
        }
        /// <summary>
        /// adjust the commandline to fit the missing orderings
        /// </summary>
        private void loadIntHeMissingOrdCommandView()
        {
            btn1.Enabled = true;
            btn1.Text = "Megérkezett";
            btn2.Enabled = true;
            btn2.Text = "Részben jött";
            btn3.Enabled = true;
            btn3.Text = "Meghíusult";
            btn4.Enabled = false;
            //btn5.Visible = true;

            //btn6.Visible = true;
            btn6.Text = "Lemondott rendelések";
        }
        /// <summary>
        /// adjust the commandline to fit the failed orderings 
        /// </summary>
        private void loadInTheFailedOrdCommandView()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            //btn5.Visible = true;

            //btn6.Visible = true;
            btn6.Text = "Visszavont rendelések";
        }
        /// <summary>
        /// adjust in details the alternative btn6 in view
        /// </summary>
        private void loadInAlternativeCommandLine()
        {
            if (actServiceForSubEvents == FormMainServiceMode.ORDERINGCancelled)
            {
                btn6.Text = "Bejegyzett rendelések";
            }
            else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGNoted)
            {
                btn6.Visible = true;
                btn6.Enabled = true;
                btn6.Text = "Leadott rendelések";
                ((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Silver;
            }
            else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGBooked)
            {
                btn6.Text = "Átvett rendelések";
            }
            else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGArrived)
            {
                btn6.Text = "Hiányzó rendelések";
            }
            else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGMissing)
            {
                btn6.Text = "Lemondott rendelések";
            }
            else if (actServiceForSubEvents == FormMainServiceMode.ORDERINGFailed)
            {
                btn6.Text = "Visszavont rendelések";
            }
        }
    }
}
