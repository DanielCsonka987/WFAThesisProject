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
        /// adjust the product service grid - depends on the mode of managing and rights
        /// </summary>
        private void loadAppropiateProductonGridView()
        {
            if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiAct)
            {
                mgrid.DataSource = productService.getTableOfProductsPartTable(true);
                mgrid.Columns[0].Width = 200;   //name column
                mgrid.Columns[4].Width = 400;   //decr column
                infoLabel.Text = "Raktári termékek\nJelenlegi termékpaletta";
            }
            else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiHis)
            {
                mgrid.DataSource = productService.getTableOfProductsPartTable(false);
                mgrid.Columns[0].Width = 200;
                mgrid.Columns[4].Width = 400;
                infoLabel.Text = "Raktári termékek\nTörölt termékpaletta";
            }
            else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)
            {
                mgrid.DataSource = productService.getTableOfProductsFullTable(true);
                mgrid.Columns[0].Width = 200;   //name column
                mgrid.Columns[3].Width = 70;    //danger column
                mgrid.Columns[6].Width = 70;    //quantity column
                infoLabel.Text = "Raktári termékek\nJelenlegi kiszerelések palettája";
            }
            else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripHis)
            {
                mgrid.DataSource = productService.getTableOfProductsFullTable(false);
                mgrid.Columns[0].Width = 200;
                mgrid.Columns[3].Width = 70;
                mgrid.Columns[6].Width = 70;
                infoLabel.Text = "Raktári termékek\nTörölt kiszerelések palettája";
            }
        }
        /// <summary>
        /// choose which command line view is needed by the actual mode of the main service
        /// </summary>
        private void loadAppropiateProductionCommandLineView()
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


        /// <summary>
        /// defins the product commands of active strore-stripping manage mode
        /// </summary>
        private void loadInProductManagingServicesStrippingsAct()    //active strippings
        {
            mgrid.Style = MetroFramework.MetroColorStyle.Lime;
            btn1.Text = "Kiszerelés rendelése";
            btn1.Enabled = true;
            btn1.Visible = true;
            ((MetroFramework.Controls.MetroTile)btn1).Style = MetroFramework.MetroColorStyle.Lime;
            btn1.Enabled = true;
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
            btn5.Text = "Törölt kiszerelések";
            ((MetroFramework.Controls.MetroTile)btn5).Style = MetroFramework.MetroColorStyle.Silver;
            btn5.Enabled = true;
            btn5.Visible = true;
            //btn6.Text = "";
            //((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Orange;
            //btn6.Enabled = true;
            btn6.Visible = false;
        }
        /// <summary>
        /// defins the product commands of passive strore-stripping manage mode
        /// </summary>
        private void loadInPrdouctManagingServiceStrippingsHis()  //deleted strippings
        {
            mgrid.Style = MetroFramework.MetroColorStyle.Lime;
            //btn1.Text = "Részletek";
            btn1.Enabled = false;
            //btn2.Text = "Új kiszerelés";
            ((MetroFramework.Controls.MetroTile)btn2).Style = MetroFramework.MetroColorStyle.Lime;
            btn2.Enabled = false;
            //btn3.Text = "Módosítás";
            ((MetroFramework.Controls.MetroTile)btn3).Style = MetroFramework.MetroColorStyle.Lime;
            btn3.Enabled = false;
            btn4.Text = "Aktiválás";
            ((MetroFramework.Controls.MetroTile)btn4).Style = MetroFramework.MetroColorStyle.Purple;
            btn4.Enabled = true;
            btn5.Text = "Aktív termékek";
            ((MetroFramework.Controls.MetroTile)btn5).Style = MetroFramework.MetroColorStyle.Silver;
            btn5.Enabled = true;
            //btn6.Text = "";
            //((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Orange;
            //btn6.Enabled = true;
        }
        /// <summary>
        /// defins the product commands of active strore-products manage mode
        /// </summary>
        private void loadInProductManagingSerciveQualityAct()   //active products
        {
            mgrid.Style = MetroFramework.MetroColorStyle.Orange;
            btn1.Text = "Kiszerelést létrehoz";
            ((MetroFramework.Controls.MetroTile)btn1).Style = MetroFramework.MetroColorStyle.Orange;
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
            btn5.Text = "Törölt termékek";
            ((MetroFramework.Controls.MetroTile)btn5).Style = MetroFramework.MetroColorStyle.Silver;
            btn5.Enabled = true;
            //btn6.Text = "";
            //((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Lime;
            //btn6.Enabled = true;
        }
        /// <summary>
        /// defins the product commands of passive strore-products manage mode
        /// </summary>
        private void loadInProductManagingSericeQualityHis()    //deleted products
        {
            mgrid.Style = MetroFramework.MetroColorStyle.Orange;
            btn1.Text = "Kiszerelést létrehoz";
            ((MetroFramework.Controls.MetroTile)btn1).Style = MetroFramework.MetroColorStyle.Orange;
            btn1.Enabled = false;
            btn2.Text = "Új termék";
            ((MetroFramework.Controls.MetroTile)btn2).Style = MetroFramework.MetroColorStyle.Orange;
            btn2.Enabled = false;
            btn3.Text = "Módosítása";
            ((MetroFramework.Controls.MetroTile)btn3).Style = MetroFramework.MetroColorStyle.Orange;
            btn3.Enabled = false;
            btn4.Text = "Aktiválás";
            ((MetroFramework.Controls.MetroTile)btn4).Style = MetroFramework.MetroColorStyle.Purple;
            btn4.Enabled = true;


            btn5.Text = "Aktív termékek";
            ((MetroFramework.Controls.MetroTile)btn5).Style = MetroFramework.MetroColorStyle.Silver;
            btn5.Enabled = true;
            //btn6.Text = "";
            //((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Lime;
            //btn6.Enabled = true;
        }
    }
}
