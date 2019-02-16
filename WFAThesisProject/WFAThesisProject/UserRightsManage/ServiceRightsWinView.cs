using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using WFAThesisProject.UserRightsManage;

namespace WFAThesisProject
{
    public partial class ServiceRightsWinController
    {
        /// <summary>
        /// makes the allgroups combobox full with the differnet usergoups
        /// </summary>
        public void fillUpMainComboBox()
        {
            try
            {
                //comboboxAllGroups.Items.Clear();
                comboboxAllGroups.DataSource = serviceRights.getTheListOfUserGroups();
                comboboxAllGroups.SelectedIndex = 0;
            }
            catch (ErrorServiceRights e)
            {
                errorHandleError(e.Message);
            }
        }
        /// <summary>
        /// switch on the sideTiles on the window that let users to manage
        /// </summary>
        private void enableModifyTiles()
        {
            tileNew.Visible = true;
            tileModify.Visible = true;
            tileDelete.Visible = true;
        }
        /// <summary>
        /// enables the chategory comboboxes in case of modofy or new
        /// </summary>
        private void enableTheFields()
        {
            comboboxR8Request.Enabled = true;
            comboboxR1LocalRequest.Enabled = true;
            comboboxR7Store.Enabled = true;
            comboboxR9Order.Enabled = true;
            comboboxR10Subcontr.Enabled = true;

            comboboxR6Accidents.Enabled = true;
            comboboxR2LocalAccid.Enabled = true;
            comboboxR5Rights.Enabled = true;
            comboboxR4Users.Enabled = true;
            comboboxR3LocalUser.Enabled = true;

            comboboxAllGroups.Enabled = false;
            if (actMode == ModeOfRightsManage.NEW)
            {
                labelGroupName.Visible = true;
                textboxGroupName.Visible = true;
            }
            btnSave.Visible = true;
            btnCancel.Visible = true;
        }
        /// <summary>
        /// disable the chategory comboboxes in case of delete or normal view
        /// </summary>
        private void disableTheFields()
        {
            comboboxR8Request.Enabled = false;
            comboboxR1LocalRequest.Enabled = false;
            comboboxR7Store.Enabled = false;
            comboboxR9Order.Enabled = false;
            comboboxR10Subcontr.Enabled = false;

            comboboxR6Accidents.Enabled = false;
            comboboxR2LocalAccid.Enabled = false;
            comboboxR5Rights.Enabled = false;
            comboboxR4Users.Enabled = false;
            comboboxR3LocalUser.Enabled = false;

            comboboxAllGroups.Enabled = true;
            labelGroupName.Visible = false;
            textboxGroupName.Visible = false;

            btnSave.Visible = false;
            btnCancel.Visible = false;
        }
        /// <summary>
        /// emptyes the side-comboboxes to fill the user with the new group-rights
        /// </summary>
        private void emptyFieldsToFillInTheNew()
        {
            comboboxR8Request.SelectedIndex = -1;
            comboboxR1LocalRequest.SelectedIndex = -1;
            comboboxR7Store.SelectedIndex = -1;
            comboboxR9Order.SelectedIndex = -1;
            comboboxR10Subcontr.SelectedIndex = -1;

            comboboxR6Accidents.SelectedIndex = -1;
            comboboxR2LocalAccid.SelectedIndex = -1;
            comboboxR5Rights.SelectedIndex = -1;
            comboboxR4Users.SelectedIndex = -1;
            comboboxR3LocalUser.SelectedIndex = -1;

            textboxGroupName.Text = "";
        }
        /// <summary>
        /// create errormessage - warning
        /// </summary>
        /// <param name="message">message</param>
        private void errorHandleWarn(string message)
        {
            MetroFramework.MetroMessageBox.Show(parRightsWindow, message, "Figyelmeztetés", MessageBoxButtons.OK,
                MessageBoxIcon.Warning, 150);
        }
        /// <summary>
        /// create errormessage - error
        /// </summary>
        /// <param name="message">message</param>
        private void errorHandleError(string message)
        {
            MetroFramework.MetroMessageBox.Show(parRightsWindow, message, "Figyelmeztetés", MessageBoxButtons.OK,
                MessageBoxIcon.Error, 150);
        }
        /// <summary>
        /// create errormessage - ask for permission from user
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private DialogResult errorHandleAsk(string message)
        {
            return MetroFramework.MetroMessageBox.Show(parRightsWindow, message, "figyelmeztetés", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, 150);
        }
    }
}
