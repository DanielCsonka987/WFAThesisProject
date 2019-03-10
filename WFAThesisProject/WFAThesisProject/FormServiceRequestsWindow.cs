using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.ServRequests;

namespace WFAThesisProject
{
    public partial class FormServiceRequestsWindow : MetroFramework.Forms.MetroForm
    {
        private Form parentMainWin;
        private ServiceRequestsWinController requestController;

        public FormServiceRequestsWindow(RequestRecordActive rec, RequestWindowPuropse mode, Form parMain, 
            ServiceRequests servRequ)
        {
            this.parentMainWin = parMain;
            InitializeComponent();
            requestController = new ServiceRequestsWinController(rec, mode, servRequ, this);
            this.Show();
            parentMainWin.Hide();
        }

        public FormServiceRequestsWindow(RequestRecordGivenOut rec, RequestWindowPuropse mode, Form parMain,
            ServiceRequests servRequ)
        {
            this.parentMainWin = parMain;
            InitializeComponent();
            requestController = new ServiceRequestsWinController(rec, mode, servRequ, this);
            this.Show();
            parentMainWin.Hide();
        }

        public FormServiceRequestsWindow(RequestRecordDeleted rec, RequestWindowPuropse mode, Form parMain,
            ServiceRequests servRequ)
        {
            this.parentMainWin = parMain;
            InitializeComponent();
            requestController = new ServiceRequestsWinController(rec, mode, servRequ, this);
            this.Show();
            parentMainWin.Hide();
        }

        public FormServiceRequestsWindow(RequestRecordCalledOff rec, RequestWindowPuropse mode, Form parMain,
            ServiceRequests servRequ)
        {
            this.parentMainWin = parMain;
            InitializeComponent();
            requestController = new ServiceRequestsWinController(rec, mode, servRequ, this);
            this.Show();
            parentMainWin.Hide();
        }

        private void mTileOk_Click(object sender, EventArgs e)
        {
            if (reviseTheContentOfTheImportantFields())
                requestController.executeTheProperEvent();
        }

        private bool reviseTheContentOfTheImportantFields()
        {
            errorProviderFail.Clear();
            if (!int.TryParse(mTxtBxAmount.Text, out int result))
            {
                errorProviderFail.SetError(mTxtBxAmount, "Kérem, ide csak egész számot írjon");
                return false;
            }
            if (mCbBxProducts.SelectedItem == null)
            {
                errorProviderFail.SetError(mCbBxProducts, "Kérem, válasszon terméket");
                return false;
            }
            if (mCbBxStrippings.SelectedItem == null)
            {
                errorProviderFail.SetError(mCbBxProducts, "Kérem, válasszon kiszerelést");
                return false;
            }
            return true;
        }

        private void FormServiceRequestsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentMainWin.Visible = true;
        }
        /// <summary>
        /// event of the new product checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mChckBxModifyWithDiffProd_CheckedChanged(object sender, EventArgs e)
        {
            if (requestController != null)
                requestController.executeModfyWithNewProductEvent();
        }
        /// <summary>
        /// event of the Product combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mCbBxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {        // it is needed, if comboboxes are adjusted, when contrl declaration is not complite
            if (requestController != null && mChckBxModifyDiffProd.Checked == true)
                requestController.executeSelectedNewProductionEvent_StrippingSubcontrAreaFilling();
        }
        /// <summary>
        /// event of the Stripping combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mCbBxStrippings_SelectedIndexChanged(object sender, EventArgs e)
        {         // it is needed, comboboxes are adjusted, when contrl declaration is not complite
            if (mCbBxProducts.SelectedIndex != -1 && requestController != null && mChckBxModifyDiffProd.Checked == true)
                requestController.executeSelectedStrippingEvent_GetTheCorrectStrippingID();
        }

        private void mTileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
