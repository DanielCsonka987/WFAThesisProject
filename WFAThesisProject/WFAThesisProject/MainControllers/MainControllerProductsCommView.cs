using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.ServProductions;

namespace WFAThesisProject
{
    public partial class MainController
    {
        /// <summary>
        /// adjust the product service grid - depends on the mode of managing and rights
        /// </summary>
        private void loadAppropriateProductonGridView()
        {
            try
            {
                introPicture.Visible = false;
                mgrid.ReadOnly = true;
                if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct)
                {
                    mgrid.Style = MetroFramework.MetroColorStyle.Orange;
                    mgrid.DataSource = productService.getTableOfProductsPartTable(true);
                    mgrid.Columns[0].Width = 50;
                    mgrid.Columns[1].Width = 200;   //name column
                    mgrid.Columns[5].Width = 400;   //decr column
                    infoLabel.Text = "Raktári termékek\nJelenlegi termékpaletta";
                }
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiHis)
                {
                    mgrid.Style = MetroFramework.MetroColorStyle.Orange;
                    mgrid.DataSource = productService.getTableOfProductsPartTable(false);
                    mgrid.Columns[0].Width = 50;
                    mgrid.Columns[1].Width = 200;
                    mgrid.Columns[5].Width = 400;
                    infoLabel.Text = "Raktári termékek\nTörölt termékpaletta";
                }
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)
                {
                    mgrid.Style = MetroFramework.MetroColorStyle.Lime;
                    mgrid.DataSource = productService.getTableOfProductsFullTable(true);
                    mgrid.Columns[0].Width = 50;
                    mgrid.Columns[1].Width = 200;   //name column
                    mgrid.Columns[4].Width = 70;    //danger column
                    mgrid.Columns[7].Width = 70;    //quantity column
                    infoLabel.Text = "Raktári termékek\nJelenlegi kiszerelések palettája";
                }
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripHis)
                {
                    mgrid.Style = MetroFramework.MetroColorStyle.Lime;
                    mgrid.DataSource = productService.getTableOfProductsFullTable(false);
                    mgrid.Columns[0].Width = 50;
                    mgrid.Columns[1].Width = 200;
                    mgrid.Columns[3].Width = 70;
                    mgrid.Columns[7].Width = 70;
                    infoLabel.Text = "Raktári termékek\nTörölt kiszerelések palettája";
                }
            }
            catch (ErrorServiceProd k)
            {
                errorHandle(k.Message);
            }
            catch (Exception k)
            {
                errorHandle("Ismeretlen hiba történt (ContrMainProdView) " + k.Message);
            }
        }
        /// <summary>
        /// choose which command line view is needed by the actual mode of the main service
        /// </summary>
        private void loadAppropiateProductionCommandLineView()
        {
            if(actServiceViewStandard == FromMainServiceViewStandard.OTHER)
            {
                panelOfCommLine.Visible = true;
                if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct)
                    loadInProductManagingSerciveQualityAct();
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiHis)
                    loadInProductManagingSericeQualityHis();
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)
                    loadInProductManagingServicesStrippingsAct();
                else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripHis)
                    loadInPrdouctManagingServiceStrippingsHis();
            }
            else
            {
                panelOfCommLine.Visible = false;
                alternatLabel.Visible = true;
                loadInTheAlternativeProductsCommandView();
            }

        }


        /// <summary>
        /// defins the product commands of active strore-stripping manage mode
        /// </summary>
        private void loadInProductManagingServicesStrippingsAct()    //active strippings
        {
            btn1.Enabled = true;
            btn1.Visible = true;
            btn1.Text = "Kiszerelés rendelése";
            ((MetroFramework.Controls.MetroTile)btn1).Style = MetroFramework.MetroColorStyle.Green;
            btn2.Text = "Új kiszerelés";
            ((MetroFramework.Controls.MetroTile)btn2).Style = MetroFramework.MetroColorStyle.Lime;
            btn2.Enabled = true;
            btn2.Visible = true;
            btn3.Text = "Módosítás";
            ((MetroFramework.Controls.MetroTile)btn3).Style = MetroFramework.MetroColorStyle.Lime;
            btn3.Enabled = true;
            btn3.Visible = true;

            btn4.Text = "Törlés";
            ((MetroFramework.Controls.MetroTile)btn4).Style = MetroFramework.MetroColorStyle.Red;
            btn4.Enabled = true;
            btn4.Visible = true;

            btn5.Text = "Tulajdonságok";
            ((MetroFramework.Controls.MetroTile)btn5).Style = MetroFramework.MetroColorStyle.Teal;
            btn5.Enabled = true;
            btn5.Visible = true;

            btn6.Visible = true;
            btn6.Enabled = true;
            btn6.Text = "Törölt kiszerelések";
            ((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Silver;
        }
        /// <summary>
        /// defins the product commands of passive strore-stripping manage mode
        /// </summary>
        private void loadInPrdouctManagingServiceStrippingsHis()  //deleted strippings
        {
            //btn1.Text = "Kiszerelés rendelése";
            btn1.Enabled = false;
            //btn2.Text = "Új kiszerelés";
            btn2.Enabled = false;
            //btn3.Text = "Módosítás";
            btn3.Enabled = false;
            btn4.Text = "Aktiválás";
            ((MetroFramework.Controls.MetroTile)btn4).Style = MetroFramework.MetroColorStyle.Purple;
            //btn4.Enabled = true;

            btn5.Text = "Tulajdonságok";
            ((MetroFramework.Controls.MetroTile)btn5).Style = MetroFramework.MetroColorStyle.Teal;

            btn6.Text = "Aktív termékek";
            //((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Silver;
        }
        /// <summary>
        /// defins the product commands of active strore-products manage mode
        /// </summary>
        private void loadInProductManagingSerciveQualityAct()   //active products
        {
            btn1.Text = "Kiszerelést létrehoz";
            ((MetroFramework.Controls.MetroTile)btn1).Style = MetroFramework.MetroColorStyle.Brown;
            btn1.Enabled = true;
            btn2.Text = "Új termék";
            ((MetroFramework.Controls.MetroTile)btn2).Style = MetroFramework.MetroColorStyle.Orange;
            btn2.Enabled = true;
            btn3.Text = "Módosítás";
            ((MetroFramework.Controls.MetroTile)btn3).Style = MetroFramework.MetroColorStyle.Orange;
            btn3.Enabled = true;
            btn4.Text = "Törlés";
            ((MetroFramework.Controls.MetroTile)btn4).Style = MetroFramework.MetroColorStyle.Red;
            btn4.Enabled = true;

            btn5.Text = "Tulajdonságok";
            ((MetroFramework.Controls.MetroTile)btn5).Style = MetroFramework.MetroColorStyle.Teal;

            btn6.Text = "Aktív kiszerelések";
            //((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Silver;
        }
        /// <summary>
        /// defins the product commands of passive strore-products manage mode
        /// </summary>
        private void loadInProductManagingSericeQualityHis()    //deleted products
        {
            btn1.Text = "Kiszerelést létrehoz";
            //((MetroFramework.Controls.MetroTile)btn1).Style = MetroFramework.MetroColorStyle.Orange;
            btn1.Enabled = false;
            btn2.Text = "Új termék";
            //((MetroFramework.Controls.MetroTile)btn2).Style = MetroFramework.MetroColorStyle.Orange;
            btn2.Enabled = false;
            btn3.Text = "Módosítása";
            //((MetroFramework.Controls.MetroTile)btn3).Style = MetroFramework.MetroColorStyle.Orange;
            btn3.Enabled = false;
            btn4.Text = "Aktiválás";
            ((MetroFramework.Controls.MetroTile)btn4).Style = MetroFramework.MetroColorStyle.Purple;
            btn4.Enabled = true;

            btn5.Text = "Tulajdonságok";
            ((MetroFramework.Controls.MetroTile)btn5).Style = MetroFramework.MetroColorStyle.Teal;

            btn6.Text = "Aktív termékek";
            //((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Silver;
        }

        private void loadInTheAlternativeProductsCommandView()
        {
            if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct)
            {
                btn6.Text = "Törölt termékek";
            }
            else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiHis)
            {
                btn6.Text = "Aktív kiszerelések";
            }
            else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)
            {
                btn6.Visible = true;
                btn6.Enabled = true;
                btn6.Text = "Törölt kiszerelések";
                ((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Silver;
            }
            else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripHis)
            {
                btn6.Text = "Aktív termékek";
            }
        }
    }
}
