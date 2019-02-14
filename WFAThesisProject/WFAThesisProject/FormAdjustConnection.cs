using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAThesisProject
{
    public partial class FormAdjustConnection : MetroFramework.Forms.MetroForm
    {
        private Form parent;
        private UserConnDetails dbci;
        private ManageIOConnFileController controllerDBInfos;
        /// <summary>
        /// constructor in case of user wants to change the DB conn. informations
        /// </summary>
        /// <param name="dbci">the old connection datas</param>
        /// <param name="parent">the login window</param>
        public FormAdjustConnection(UserConnDetails dbci, Form parent)
        {
            InitializeComponent();
            this.dbci = dbci;
            this.parent = parent;
            parent.Hide();
            if (dbci == null)   //the case of missing xml or first run
            {
                dbci = new UserConnDetails();
                mTxtBxHost.Text = "";
                mTxtBxPort.Text = "";
                mTxtBxUser.Text = "";
                mTxtBxPwd.Text = "";
                mTxtBxDB.Text = "";
            }
            else
            {
                mTxtBxHost.Text = dbci.host;
                mTxtBxPort.Text = dbci.port;
                mTxtBxUser.Text = dbci.user;
                mTxtBxPwd.Text = dbci.pwd;
                mTxtBxDB.Text = dbci.db;
                mTxtBxPdfDest.Text = dbci.output;
                mTxtBxUrl.Text = dbci.input;
            }

        }
        /// <summary>
        /// saves and write to xmlfile the mTextboxes data for connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileSaveConData_Click(object sender, EventArgs e)
        {
            dbci = new UserConnDetails(mTxtBxHost.Text, mTxtBxPort.Text, mTxtBxDB.Text, mTxtBxUser.Text, 
                mTxtBxPwd.Text, mTxtBxPdfDest.Text, mTxtBxUrl.Text);
            controllerDBInfos = new ManageIOConnFileController(this);
            controllerDBInfos.setTheConnInfos(dbci,this);
            parent.Show();
            this.Close();
        }
        /// <summary>
        /// steping back without changing the connection details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileBack_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();
        }
    }
}
