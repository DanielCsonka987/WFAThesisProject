using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.ServOrdering;
using WFAThesisProject.UserNamePasswordManage;

namespace WFAThesisProject
{
    public partial class FormServiceOrderingWindow : MetroFramework.Forms.MetroForm
    {
        private ServiceOrderingWinController controllerOrd;
        private Form parentMain;

        public FormServiceOrderingWindow(SetOfUserDetails soud, OrderingWindowPurpose mode, Form parentMain, ServiceOrdering servOrd)
        {
            InitializeComponent();
            controllerOrd = new ServiceOrderingWinController(soud, mode, servOrd, this);
            this.parentMain = parentMain;
            this.Show();
            parentMain.Hide();
        }
        public FormServiceOrderingWindow(OrderingCancelled rec, OrderingWindowPurpose mode, Form parentMain, ServiceOrdering servOrd)
        {
            InitializeComponent();
            controllerOrd = new ServiceOrderingWinController(rec, mode, servOrd, this);
            this.parentMain = parentMain;
            this.Show();
            parentMain.Hide();
        }
        public FormServiceOrderingWindow(OrderingNoted rec, OrderingWindowPurpose mode, Form parentMain, ServiceOrdering servOrd)
        {
            InitializeComponent();
            controllerOrd = new ServiceOrderingWinController(rec, mode, servOrd, this);
            this.parentMain = parentMain;
            this.Show();
            parentMain.Hide();
        }
        public FormServiceOrderingWindow(OrderingBooked rec, OrderingWindowPurpose mode, Form parentMain, ServiceOrdering servOrd)
        {
            InitializeComponent();
            controllerOrd = new ServiceOrderingWinController(rec, mode, servOrd, this);
            this.parentMain = parentMain;
            this.Show();
            parentMain.Hide();
        }
        public FormServiceOrderingWindow(OrderingArrived rec, OrderingWindowPurpose mode, Form parentMain, ServiceOrdering servOrd)
        {
            InitializeComponent();
            controllerOrd = new ServiceOrderingWinController(rec, mode, servOrd, this);
            this.parentMain = parentMain;
            this.Show();
            parentMain.Hide();
        }
        public FormServiceOrderingWindow(OrderingMissing rec, OrderingWindowPurpose mode, Form parentMain, ServiceOrdering servOrd)
        {
            InitializeComponent();
            controllerOrd = new ServiceOrderingWinController(rec, mode, servOrd, this);
            this.parentMain = parentMain;
            this.Show();
            parentMain.Hide();
        }
        public FormServiceOrderingWindow(OrderingFailed rec, OrderingWindowPurpose mode, Form parentMain, ServiceOrdering servOrd)
        {
            InitializeComponent();
            controllerOrd = new ServiceOrderingWinController(rec, mode, servOrd, this);
            this.parentMain = parentMain;
            this.Show();
            parentMain.Hide();
        }
        private void mTileOk_Click(object sender, EventArgs e)
        {
            controllerOrd.executeTheCommand();
        }

        private void mTileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mCmbxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controllerOrd != null && mChckBoxNewProdAdj.Checked == true)
                controllerOrd.executeProductChooseEvents();
        }

        private void mCmbxStripping_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controllerOrd != null && mChckBoxNewProdAdj.Checked == true)
                controllerOrd.executeStrippingChooseEvents();
        }

        private void mChckBoxNewProdAdj_CheckedChanged(object sender, EventArgs e)
        {
            if (controllerOrd != null)
                controllerOrd.executeChooseModifyEvent();
        }


        private void reviseTheDatasOfFields()
        {
            errorProviderDataMistake.Clear();
            
        }

        private void FormServiceOrderingWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentMain.Show();
        }
    }
}
