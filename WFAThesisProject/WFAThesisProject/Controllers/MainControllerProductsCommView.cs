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
                ((MetroFramework.Controls.MetroGrid)mgrid).DataSource = productService.getTableOfProductsPartTable(true);
                ((MetroFramework.Controls.MetroGrid)mgrid).Columns[0].Width = 200;   //name column
                ((MetroFramework.Controls.MetroGrid)mgrid).Columns[4].Width = 300;   //decr column
                infoLabel.Text = "Raktári termékek\nJelenlegi termékpaletta";
            }
            else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANQualiHis)
            {
                ((MetroFramework.Controls.MetroGrid)mgrid).DataSource = productService.getTableOfProductsPartTable(false);
                ((MetroFramework.Controls.MetroGrid)mgrid).Columns[0].Width = 200;
                ((MetroFramework.Controls.MetroGrid)mgrid).Columns[4].Width = 300;
                infoLabel.Text = "Raktári termékek\nTörölt termékpaletta";
            }
            else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripAct)
            {
                ((MetroFramework.Controls.MetroGrid)mgrid).DataSource = productService.getTableOfProductsFullTable(true);
                ((MetroFramework.Controls.MetroGrid)mgrid).Columns[0].Width = 200;   //name column
                ((MetroFramework.Controls.MetroGrid)mgrid).Columns[3].Width = 70;    //danger column
                ((MetroFramework.Controls.MetroGrid)mgrid).Columns[6].Width = 70;    //quantity column
                infoLabel.Text = "Raktári termékek\nJelenlegi kiszerelések palettája";
            }
            else if (actServiceForSubEvents == FormMainServiceMode.PRODUCTSMANStripHis)
            {
                ((MetroFramework.Controls.MetroGrid)mgrid).DataSource = productService.getTableOfProductsFullTable(false);
                ((MetroFramework.Controls.MetroGrid)mgrid).Columns[0].Width = 200;
                ((MetroFramework.Controls.MetroGrid)mgrid).Columns[3].Width = 70;
                ((MetroFramework.Controls.MetroGrid)mgrid).Columns[6].Width = 70;
                infoLabel.Text = "Raktári termékek\nTörölt kiszerelések palettája";
            }
        }

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
            ((MetroFramework.Controls.MetroGrid)mgrid).Style = MetroFramework.MetroColorStyle.Lime;
            btn1.Text = "Rendelés készítése";
            btn1.Enabled = true;
            ((MetroFramework.Controls.MetroTile)btn1).Style = MetroFramework.MetroColorStyle.Lime;
            btn1.Enabled = true;
            btn2.Text = "Új kiszerelés";
            ((MetroFramework.Controls.MetroTile)btn2).Style = MetroFramework.MetroColorStyle.Lime;
            btn2.Enabled = true;
            btn3.Text = "Módosítás";
            ((MetroFramework.Controls.MetroTile)btn3).Style = MetroFramework.MetroColorStyle.Lime;
            btn3.Enabled = true;
            btn4.Text = "Törlés";
            ((MetroFramework.Controls.MetroTile)btn4).Style = MetroFramework.MetroColorStyle.Red;
            btn4.Enabled = true;

            btn5.Text = "Törölt kiszerelések";
            ((MetroFramework.Controls.MetroTile)btn5).Style = MetroFramework.MetroColorStyle.Silver;
            btn5.Enabled = true;
            btn6.Text = "";
            ((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Orange;
            btn6.Enabled = true;
        }
        /// <summary>
        /// defins the product commands of passive strore-stripping manage mode
        /// </summary>
        private void loadInPrdouctManagingServiceStrippingsHis()  //deleted strippings
        {
            ((MetroFramework.Controls.MetroGrid)mgrid).Style = MetroFramework.MetroColorStyle.Lime;
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
            btn6.Text = "";
            ((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Orange;
            btn6.Enabled = true;
        }
        /// <summary>
        /// defins the product commands of active strore-products manage mode
        /// </summary>
        private void loadInProductManagingSerciveQualityAct()   //active products
        {
            ((MetroFramework.Controls.MetroGrid)mgrid).Style = MetroFramework.MetroColorStyle.Orange;
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
            btn6.Text = "";
            ((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Lime;
            btn6.Enabled = true;
        }
        /// <summary>
        /// defins the product commands of passive strore-products manage mode
        /// </summary>
        private void loadInProductManagingSericeQualityHis()    //deleted products
        {
            ((MetroFramework.Controls.MetroGrid)mgrid).Style = MetroFramework.MetroColorStyle.Orange;
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
            btn6.Text = "";
            ((MetroFramework.Controls.MetroTile)btn6).Style = MetroFramework.MetroColorStyle.Lime;
            btn6.Enabled = true;
        }
    }
}
