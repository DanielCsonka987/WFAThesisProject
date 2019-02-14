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

        private void mCbBxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (requestController != null) //it is needed, comboboxes are adjusted, when contrl declaration is not complite
                requestController.executeSelectedProductionEvent();
        }

        private void mCbBxStrippings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mCbBxProducts.SelectedIndex != -1 && requestController != null)//it is needed, comboboxes are adjusted, when contrl declaration is not complite
                requestController.executeSelectedStrippingEvent();
        }

        private void mTileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
