using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFAThesisProject.ServRequests;

namespace WFAThesisProject
{
    public partial class ServiceRequestsWinController
    {
        #region view of the Active records
        /// <summary>
        /// adjust the window-view on the window if active request is coming
        /// possible modes are - delete, details, giveout, modify
        /// </summary>
        /// <param name="rec">the record inf.container</param>
        /// <param name="mod">mode of the window</param>
        private void adjustActiveRecFields(RequestRecordActive rec)
        {
            fillUpActiveFields(rec);
            if (purposeOfTheWindow == RequestWindowPuropse.DetailsOfActive)
            {
                adjustReadOnlyCase();
                buttonOk.Visible = false;
            }
            else if (purposeOfTheWindow == RequestWindowPuropse.GivingOutTheActive)
            {
                adjustReadOnlyCase();
                buttonOk.Visible = true;
                buttonOk.Text = "Kiadás";

            }
            else if (purposeOfTheWindow == RequestWindowPuropse.MorifyTheActive)
            {
                adjustModfyCase();
                fillUpTheProductsField();
                buttonOk.Visible = true;
                buttonOk.Text = "Módosítás";
            }
            else if (purposeOfTheWindow == RequestWindowPuropse.DeleteTheActive)
            {
                adjustReadOnlyCase();
                buttonOk.Visible = true;
                buttonOk.Text = "Törlés";
            }
        }

        /// <summary>
        /// fill up the fields with text with active record content
        /// </summary>
        /// <param name="rec"></param>
        private void fillUpActiveFields(RequestRecordActive rec)
        {
            textBoxName.Text = rec.userKeroNev;
            textBoxArea.Text = rec.userTerulet;
            textBoxStartDate.Text = rec.keresDatum;
            textBoxAmount.Text = Convert.ToString(rec.keresMennyiseg);
            comboBoxProducts.Items.Add(rec.termekNev);
            comboBoxProducts.SelectedIndex = 0;
            comboBoxStrippings.Items.Add(rec.termekKiszerel);
            comboBoxStrippings.SelectedIndex = 0;
            textBoxPlacing.Text = rec.termekHely;
            textBoxSubcontr.Text = rec.termekBeszall;
            infoLabel.Text = "Aktív kérés\n";
            if(rec.keresModosNev != null)
            {
                infoLabel.Text += "Legutóbb módosította: " + rec.keresModosNev;
            }
            userIdOfRequester = rec.userId;     //all change case needs that
            oldStrippingID = rec.termekQuantId;    //for the case of the modifing the record content
        }
        /// <summary>
        /// in need it fill up the combobox of stripping
        /// </summary>
        private void fillUpTheStrippingsField(int chosenProductionID_DurringModify)
        {
            List<string> itemnames = serviceRequests.getThePoolOfStrippings(chosenProductionID_DurringModify);
            comboBoxStrippings.Items.Clear();
            foreach (string s in itemnames)
                comboBoxStrippings.Items.Add(s);
        }

        /// <summary>
        /// in need, it fills up the combobox of productions
        /// </summary>
        private void fillUpTheProductsField()
        {
            List<string> itemnames = serviceRequests.getThePoolOfProducts();
            labelOfProduct.Text += "Válassszon a " + comboBoxProducts.Text + " helyett!";
            comboBoxProducts.Items.Clear();
            foreach (string s in itemnames)
                comboBoxProducts.Items.Add(s);


        }

        #endregion

        #region view of the Given-out records
        /// <summary>
        /// adjust the window-view on the window if given-out record is comming
        /// possible modes are
        /// </summary>
        /// <param name="rec">givenout record</param>
        private void adjustGivenOutRecFields(RequestRecordGivenOut rec)
        {
            fillUpGivenOutFields(rec);
            if (purposeOfTheWindow == RequestWindowPuropse.DetailsOfGivenOut)
            {
                adjustReadOnlyCase();
                buttonOk.Visible = false;
            }
            else if (purposeOfTheWindow == RequestWindowPuropse.GetBackTheGivenOut)
            {
                adjustReadOnlyCase();
                buttonOk.Visible = true;
                buttonOk.Text = "Visszavétel";
            }
        }
        /// <summary>
        /// fills up the text of GivenOut records to the fields
        /// </summary>
        /// <param name="rec">givenout record</param>
        private void fillUpGivenOutFields(RequestRecordGivenOut rec)
        {
            textBoxName.Text = rec.userKeroNev;
            textBoxArea.Text = rec.userTerulet;
            textBoxStartDate.Text = rec.keresDatum;
            textBoxEndDate.Text = rec.teljesites;
            textBoxAmount.Text = Convert.ToString(rec.keresMennyiseg);
            comboBoxProducts.Items.Add(rec.termekNev);
            comboBoxProducts.SelectedIndex = 0;
            comboBoxStrippings.Items.Add(rec.termekKiszerel);
            comboBoxStrippings.SelectedIndex = 0;
            textBoxPlacing.Visible = false;
            textBoxSubcontr.Text = rec.termekBeszall;
            labelPlacing.Visible = false;
            infoLabel.Text = "Kiadott kérés\n";
            if (rec.keresModosNev != "")
            {
                infoLabel.Text += "Kiadta: " + rec.keresModosNev;
            }

            userIdOfRequester = rec.userId;
            oldStrippingID = rec.termekQuantId;
        }
        #endregion

        #region view of the Deleted records
        /// <summary>
        /// ajust the window-view on the window - case of deleted request is coming
        /// </summary>
        /// <param name="rec">deleted record</param>
        private void adjustDeletedRecFields(RequestRecordDeleted rec)
        {
            fillUpDeletedFields(rec);
            if (purposeOfTheWindow == RequestWindowPuropse.DetailsOfDeleted)
            {
                adjustReadOnlyCase();
                buttonOk.Visible = false;
            }
            else if (purposeOfTheWindow == RequestWindowPuropse.RenewTheDeleted)
            {
                adjustReadOnlyCase();
                buttonOk.Visible = true;
                buttonOk.Text = "Visszaállítás";
            }
        }
        /// <summary>
        /// fills up with the deleted recors informations
        /// </summary>
        /// <param name="rec">deleted record</param>
        private void fillUpDeletedFields(RequestRecordDeleted rec)
        {
            textBoxName.Text = rec.userKeroNev;
            textBoxArea.Text = rec.userTerulet;
            textBoxStartDate.Text = rec.keresDatum;
            textBoxAmount.Text = Convert.ToString(rec.keresMennyiseg);
            comboBoxProducts.Items.Add(rec.termekNev);
            comboBoxProducts.SelectedIndex = 0;
            comboBoxStrippings.Items.Add(rec.termekQuantId);
            comboBoxStrippings.SelectedIndex = 0;
            textBoxPlacing.Visible = false;
            labelPlacing.Visible = false;
            textBoxSubcontr.Text = rec.termekBeszall;
            infoLabel.Text = "Törölt kérés\n";
            infoLabel.Text += "Legutóbb módosította: " + rec.keresModosNev;

            userIdOfRequester = rec.userId;
            oldStrippingID = rec.termekQuantId;
        }
        #endregion

        #region view of the Cancelled records
        /// <summary>
        /// adjust the window-view of the window case of cancelled record is coming
        /// </summary>
        /// <param name="rec">cancelled record</param>
        private void adjustCancelledRecFields(RequestRecordCalledOff rec)
        {
            fillUpCancelledFields(rec);

        }
        /// <summary>
        /// fills up the content of the cancelled rccord
        /// </summary>
        /// <param name="rec">cancelled record</param>
        private void fillUpCancelledFields(RequestRecordCalledOff rec)
        {
            textBoxName.Text = rec.userKeroNev;
            textBoxArea.Text = rec.userTerulet;
            textBoxStartDate.Text = rec.keresDatum;
            textBoxAmount.Text = Convert.ToString(rec.keresMennyiseg);
            comboBoxProducts.Text = rec.termekNev;
            textBoxPlacing.Visible = false;
            labelPlacing.Visible = false;
            textBoxSubcontr.Text = rec.termekBeszall;
            infoLabel.Text = "Lemondott kérés";
        }
        #endregion

        #region general view adjusters
        /// <summary>
        /// defines which fields are needed for the user - case almost all
        /// </summary>
        private void adjustReadOnlyCase()
        {
            textBoxName.ReadOnly = true;
            textBoxStartDate.ReadOnly = true;
            textBoxEndDate.ReadOnly = true;
            textBoxArea.ReadOnly = true;
            textBoxAmount.ReadOnly = true;
            comboBoxProducts.Enabled = false;
            comboBoxStrippings.Enabled = false;
            textBoxPlacing.ReadOnly = true;
        }
        /// <summary>
        /// defines which fields are needed for the user - case only modify
        /// </summary>
        private void adjustModfyCase()
        {
            textBoxName.ReadOnly = true;
            textBoxStartDate.ReadOnly = true;
            textBoxEndDate.ReadOnly = true;
            textBoxArea.ReadOnly = true;
            textBoxAmount.ReadOnly = false;     //active
            comboBoxProducts.Enabled = true;    //active
            comboBoxStrippings.Enabled = true;  //active
            textBoxPlacing.ReadOnly = true;
        }
        #endregion
    }
}
