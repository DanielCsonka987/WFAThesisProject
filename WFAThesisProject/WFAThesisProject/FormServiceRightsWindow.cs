using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAThesisProject.UserRightsManage;

namespace WFAThesisProject
{
    public partial class FormServiceRightsWindow : MetroFramework.Forms.MetroForm
    {
        private Form parentMainWindow;
        private ServiceRightsWinController rightsController;
        /// <summary>
        /// constructor of the rights manager window
        /// </summary>
        /// <param name="parent">address of the parent main</param>
        /// <param name="rightToModify">rights of read or modify</param>
        /// <param name="dbci">DB connection informations</param>
        public FormServiceRightsWindow(Form parent, bool rightToModify, UserConnDetails dbci)
        {
            InitializeComponent();
            rightsController = new ServiceRightsWinController(dbci, rightToModify, this);
            this.parentMainWindow = parent;
            this.Show();
            parentMainWindow.Hide();
            rightsController.fillUpMainComboBox();
        }
        /// <summary>
        /// mTileNew event - case the user wants a new user-group category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileNew_Click(object sender, EventArgs e)
        {
            rightsController.startToCreateNewGroupChategory();
        }
        /// <summary>
        /// mTileModify event - case the user wants modify a user-group right-parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileModify_Click(object sender, EventArgs e)
        {
            rightsController.startToModifyGroupChategory();
        }
        /// <summary>
        /// mTileDelete event - case the user wants remove a user-group chategory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileDelete_Click(object sender, EventArgs e)
        {
            rightsController.startToDeleteGroupChategory();
        }
        /// <summary>
        /// mTileExit event - case the user want to leave the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// evnet of tht closing the RightWindow, show up the MainWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormServiceRightsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentMainWindow.Show();
        }
        /// <summary>
        /// tbnSave event - in case the user want to finish and save the changes on a usergroup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnSave_Click(object sender, EventArgs e)
        {
            rightsController.saveModifies();
        }
        /// <summary>
        /// btnCancel event - in case the user don't want to save changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnCancel_Click(object sender, EventArgs e)
        {
            rightsController.cancelModifies();
        }
        /// <summary>
        /// comboboxAllGroups event - when the user chooses a user-group to see or mofify its parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mCmbBxAllGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            rightsController.loadInTheProperChategoryComboboxContent();
        }
        /// <summary>
        /// revise the side comboboxes to be filled up - case of new especially
        /// </summary>
        private void chechTheFieldsFilledIn()
        {

        }
    }
}
