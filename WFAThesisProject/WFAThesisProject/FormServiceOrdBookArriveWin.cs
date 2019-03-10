using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.Rendering;
using MigraDoc.Rendering.Printing;
using MigraDoc.Rendering.Forms;
using MigraDoc.RtfRendering;
using WFAThesisProject.ServOrdering;
using WFAThesisProject.UserNamePasswordManage;

namespace WFAThesisProject
{
    public partial class FormServiceOrdBookArriveWin : MetroFramework.Forms.MetroForm
    {
        private ServiceOrdBookArriveWinController controllOrdBookArrive;
        private Form parentMain;

        public FormServiceOrdBookArriveWin(List<OrderingNoted> listNoted, Form parentMain, ServiceOrdering servOrd,
            SetOfUserDetails soud)
        {
            InitializeComponent();
            controllOrdBookArrive = new ServiceOrdBookArriveWinController(listNoted, this, servOrd, soud);
            this.Show();
            this.parentMain = parentMain;
            parentMain.Hide();
        }

        public FormServiceOrdBookArriveWin(List<OrderingBooked> listNoted, Form parentMain, ServiceOrdering servOrd)
        {
            InitializeComponent();
            controllOrdBookArrive = new ServiceOrdBookArriveWinController(listNoted, this, servOrd);
            this.Show();
            this.parentMain = parentMain;
            parentMain.Hide();
        }

        private void mTileOk_Click(object sender, EventArgs e)
        {
            controllOrdBookArrive.executeDBModify();
        }

        private void mTileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormServiceOrdBookArriveWin_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentMain.Show();
        }

        private void mGrid_DoubleClick(object sender, EventArgs e)
        {
            controllOrdBookArrive.executeRemoveTheSelectedOne();
        }

        private void mTileRenew_Click(object sender, EventArgs e)
        {
            controllOrdBookArrive.executeLoadInAllTheRecords();
        }
    }
}
