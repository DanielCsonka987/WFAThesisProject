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
        /// opens the field to create new userGroupChagergory
        /// </summary>
        public void startToCreateNewGroupChategory()
        {
            actMode = ModeOfRightsManage.NEW;
            enableTheFields();
            emptyFieldsToFillInTheNew();
        }
        /// <summary>
        /// opens the field modify selected userGroupChagergory
        /// </summary>
        public void startToModifyGroupChategory()
        {
            actMode = ModeOfRightsManage.MODIFY;
            enableTheFields();
        }
        /// <summary>
        /// deletes the actial userGroupChategory
        /// </summary>
        public void startToDeleteGroupChategory()
        {
            DialogResult res = errorHandleAsk("Biztos törli a felhasználói csoportot? (ContrRightsDel)");
            if (res == DialogResult.Yes)
            {
                try
                {
                    if (serviceRights.checkTheChosenGroupIsNotInUse(comboboxAllGroups.Text))
                        errorHandleWarn("A kategória használatban van, nem törölhető! (ContrRightsDel)");
                    else
                        serviceRights.deleteTheChosenRightGroup(comboboxAllGroups.Text);
                    fillUpMainComboBox();
                }
                catch (ErrorServiceRights e)
                {
                    errorHandleError(e.Message);
                }
            }
        }
        /// <summary>
        /// save the changes
        /// </summary>
        public void saveModifies()
        {
            try
            {
                if (actMode == ModeOfRightsManage.NEW)
                {
                    serviceRights.saveTheNewRightGroup(textboxGroupName.Text, collectDatasFromCombobox());
                }
                else if (actMode == ModeOfRightsManage.MODIFY)
                {
                    serviceRights.saveTheModifiedRightGroup(comboboxAllGroups.Text, collectDatasFromCombobox());
                }
            }
            catch (ErrorServiceRights e)
            {
                errorHandleError(e.Message);
            }
            actMode = ModeOfRightsManage.VIEW;
            disableTheFields();
            fillUpMainComboBox();
            loadInTheProperChategoryComboboxContent();
        }
        /// <summary>
        /// cancel all the changes
        /// </summary>
        public void cancelModifies()
        {
            actMode = ModeOfRightsManage.VIEW;
            disableTheFields();
            loadInTheProperChategoryComboboxContent();
        }
        /// <summary>
        /// adjust the proper content to the combobox chategories
        /// </summary>
        public void loadInTheProperChategoryComboboxContent()
        {
            try
            {
                if (actMode == ModeOfRightsManage.VIEW)
                {
                    SetOfUserRights groupInform = serviceRights.getTheChosenGroupChategRights(comboboxAllGroups.Text);
                    if (groupInform != null)
                    {
                        comboboxR6Accidents.SelectedIndex = (int)groupInform.getuR6_AccidGlobal();
                        comboboxR2LocalAccid.SelectedIndex = (int)groupInform.getuR2_AccidLocal();
                        comboboxR4Users.SelectedIndex = (int)groupInform.getuR4_UserGlobal();
                        comboboxR3LocalUser.SelectedIndex = (int)groupInform.getuR3_UserLocal();
                        comboboxR5Rights.SelectedIndex = (int)groupInform.getuR5_RightMan();
                        comboboxR9Order.SelectedIndex = (int)groupInform.getuR9_Order();
                        comboboxR8Request.SelectedIndex = (int)groupInform.getuR8_ReqMan();
                        comboboxR1LocalRequest.SelectedIndex = (int)groupInform.getuR1_Req();
                        comboboxR7Store.SelectedIndex = (int)groupInform.getuR7_ProductsMan();
                        comboboxR10Subcontr.SelectedIndex = (int)groupInform.getuR10_Subcontr();
                    }
                    else
                        errorHandleError("A jogosultsági részletek nem érhetőek el! (ContrRightsLoad)");
                }
            }
            catch (ErrorServiceRights e)
            {
                errorHandleError(e.Message);
            }
        }
        /// <summary>
        /// collects all the informations from side comboboxes
        /// </summary>
        /// <returns>string of rights 3NS</returns>
        private string collectDatasFromCombobox()
        {
            string rightContent = "";
            rightContent += comboboxR1LocalRequest.SelectedIndex.ToString();
            rightContent += comboboxR2LocalAccid.SelectedIndex.ToString();
            rightContent += comboboxR3LocalUser.SelectedIndex.ToString();
            rightContent += comboboxR4Users.SelectedIndex.ToString();
            rightContent += comboboxR5Rights.SelectedIndex.ToString();
            rightContent += comboboxR6Accidents.SelectedIndex.ToString();
            rightContent += comboboxR7Store.SelectedIndex.ToString();
            rightContent += comboboxR8Request.SelectedIndex.ToString();
            rightContent += comboboxR9Order.SelectedIndex.ToString();
            rightContent += comboboxR10Subcontr.SelectedIndex.ToString();
            return rightContent;
        }

    }
}
