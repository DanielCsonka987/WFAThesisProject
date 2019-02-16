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
        private enum ModeOfRightsManage { VIEW, MODIFY, NEW, DELETE }
        private ServiceRights serviceRights;
        private Form parRightsWindow;
        private bool rightToModifyGroups;
        private ModeOfRightsManage actMode;

        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnCancel;

        private MetroFramework.Controls.MetroTile tileNew;
        private MetroFramework.Controls.MetroTile tileModify;
        private MetroFramework.Controls.MetroTile tileDelete;

        private MetroFramework.Controls.MetroComboBox comboboxAllGroups;
        private MetroFramework.Controls.MetroComboBox comboboxR4Users;
        private MetroFramework.Controls.MetroComboBox comboboxR6Accidents;
        private MetroFramework.Controls.MetroComboBox comboboxR5Rights;
        private MetroFramework.Controls.MetroComboBox comboboxR7Store;
        private MetroFramework.Controls.MetroComboBox comboboxR8Request;
        private MetroFramework.Controls.MetroComboBox comboboxR9Order;
        private MetroFramework.Controls.MetroComboBox comboboxR10Subcontr;

        private MetroFramework.Controls.MetroComboBox comboboxR2LocalAccid;
        private MetroFramework.Controls.MetroComboBox comboboxR3LocalUser;
        private MetroFramework.Controls.MetroComboBox comboboxR1LocalRequest;

        private MetroFramework.Controls.MetroTextBox textboxGroupName;
        private MetroFramework.Controls.MetroLabel labelGroupName;
        /// <summary>
        /// constructor of the RightsWindowController
        /// </summary>
        /// <param name="dbci">DB connection informations</param>
        /// <param name="rightToModify">RightLevel of the user</param>
        /// <param name="parentRightsWin">parent window</param>
        public ServiceRightsWinController(UserConnDetails dbci, bool rightToModify, Form parentRightsWin)
        {
            this.parRightsWindow = parentRightsWin;
            this.rightToModifyGroups = rightToModify;
            try
            {
                serviceRights = new ServiceRights(dbci, parentRightsWin);   //the list of RightGroups is build here
            }
            catch(ErrorServiceRights e)
            {
                errorHandleError(e.Message);
            }
            actMode = ModeOfRightsManage.VIEW;
            catchControllers();
            if (rightToModify)
            {
                enableModifyTiles();
            }
        }

        /// <summary>
        /// catches the controller of the RightsWindow
        /// </summary>
        private void catchControllers()
        {
            btnSave = (MetroFramework.Controls.MetroButton) parRightsWindow.Controls.Find("mBtnSave", true).First();
            btnCancel = (MetroFramework.Controls.MetroButton) parRightsWindow.Controls.Find("mBtnCancel", true).First();

            comboboxAllGroups = (MetroFramework.Controls.MetroComboBox)parRightsWindow.Controls.Find("mCmbBxAllGroups", true).First();
            textboxGroupName = (MetroFramework.Controls.MetroTextBox)parRightsWindow.Controls.Find("mTxtBxGroupName", true).First();
            labelGroupName = (MetroFramework.Controls.MetroLabel)parRightsWindow.Controls.Find("mLblGroup", true).First();

            comboboxR6Accidents = (MetroFramework.Controls.MetroComboBox)parRightsWindow.Controls.Find("mCmbBxAccidents", true).First();
            comboboxR4Users = (MetroFramework.Controls.MetroComboBox)parRightsWindow.Controls.Find("mCmbBxUsers", true).First();
            comboboxR5Rights = (MetroFramework.Controls.MetroComboBox)parRightsWindow.Controls.Find("mCmbBxRights", true).First();
            comboboxR7Store = (MetroFramework.Controls.MetroComboBox)parRightsWindow.Controls.Find("mCmbBxStore", true).First();
            comboboxR8Request = (MetroFramework.Controls.MetroComboBox)parRightsWindow.Controls.Find("mCmbBxRequest", true).First();
            comboboxR9Order = (MetroFramework.Controls.MetroComboBox)parRightsWindow.Controls.Find("mCmbBxOrder", true).First();
            comboboxR10Subcontr = (MetroFramework.Controls.MetroComboBox)parRightsWindow.Controls.Find("mCmbBxSubcontr", true).First();

            comboboxR2LocalAccid = (MetroFramework.Controls.MetroComboBox)parRightsWindow.Controls.Find("mCmbBxAccidLocal", true).First();
            comboboxR3LocalUser = (MetroFramework.Controls.MetroComboBox)parRightsWindow.Controls.Find("mCmbBxUsersLocal", true).First();
            comboboxR1LocalRequest = (MetroFramework.Controls.MetroComboBox)parRightsWindow.Controls.Find("mCmbBxRequestLocal", true).First();

            tileNew = (MetroFramework.Controls.MetroTile)parRightsWindow.Controls.Find("mTileNew", true).First();
            tileModify = (MetroFramework.Controls.MetroTile)parRightsWindow.Controls.Find("mTileModify", true).First();
            tileDelete = (MetroFramework.Controls.MetroTile)parRightsWindow.Controls.Find("mTileDelete", true).First();
        }

    }
}
