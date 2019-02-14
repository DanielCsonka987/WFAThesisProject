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
    public partial class FormServicePersonalWindow : MetroFramework.Forms.MetroForm
    {
        private ServicePersonalWinController personalController;

        private Form parentMainWindow;
        private UserConnDetails dbci;
        private SetOfUserDetails usod;
        private AnalyzePassword controlAnalizePwdContent;

        public FormServicePersonalWindow(SetOfUserDetails usod, UserConnDetails dbci, Form parentMain)
        {
            InitializeComponent();
            this.parentMainWindow = parentMain;
            this.dbci = dbci;
            this.usod = usod;
            personalController = new ServicePersonalWinController(usod, dbci, this);
        }

        /// <summary>
        /// event of click on the change pwd button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileReconfRwd_Click(object sender, EventArgs e)
        {
            personalController.opensFieldsToChangePwd();
        }

        /// <summary>
        /// event of click on the change some personal details button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileReconfDatas_Click(object sender, EventArgs e)
        {
            personalController.opensFieldsToChangePersDetails();
        }
        /// <summary>
        /// event of click on the show persinal healt-form PDF button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileShowHealth_Click(object sender, EventArgs e)
        {
            personalController.collectsDatasAndCreatesHealthDetailsPDF();
        }
        /// <summary>
        /// event of click on the exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mTileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// event when the window is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormServicePersonalManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentMainWindow.Show();
        }
        /// <summary>
        /// event of click on the save changed personal datas button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnSaveDatas_Click(object sender, EventArgs e)
        {
            if (testsPersDataValidity())
                personalController.savesTheNewPersDetails();   
        }

        private void mBtnCancelDet_Click(object sender, EventArgs e)
        {
            personalController.setTheNormalViewOfWindow();
        }
        /// <summary>
        /// event of click on the save changes password button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnSaveNewPwd_Click(object sender, EventArgs e)
        {
            if (testsNewPwdValidity())
                personalController.saveTheNewPwd();
        }


        private void mBtnCancelPwd_Click(object sender, EventArgs e)
        {
            personalController.setTheNormalViewOfWindow();
        }

        #region testers
        private bool testsPersDataValidity()
        {
            errorProviderFail.Clear();
            if (mTxtBxLastName.Text != "" && mTxtBxFirstName.Text != null && mTxtBxTaj.Text != null)
            {
                foreach (char c in mTxtBxLastName.Text)
                {
                    if (char.IsDigit(c))
                    {
                        errorProviderFail.SetError(mTxtBxLastName, "Kérem ebbe a mezőbe számot ne írjon");
                        return false;
                    }
                }
                foreach (char c in mTxtBxFirstName.Text)
                {
                    if (char.IsDigit(c))
                    {
                        errorProviderFail.SetError(mTxtBxFirstName, "Kérem ebbe a mezőbe számot ne írjon");
                        return false;
                    }
                }
                if (!personalController.analyzeTajInDetails())
                {
                   errorProviderFail.SetError(mTxtBxTaj, "Ebben a mezőben 9 egész-számnak kell szerepelnie, " +
                        "kötőjelekkel elválasztva, pl. 123-456-789");
                    return false;
                }
                else
                    return true;
            }
            else
            {
                errorProviderFail.SetError(mBtnSaveDatas, "Kérem ne hagyjon üres mezőt");
                return false;
            }

        }

        private bool testsNewPwdValidity()
        {
            errorProviderFail.Clear();
            if (mTxtBxPwdOld.Text != "")
            {
                if (mTxtBxPwdNew.Text != "" && mTxtBxPwdNewConf.Text != "")
                {
                    if (mTxtBxPwdNew.Text != mTxtBxPwdNewConf.Text)
                    {
                        errorProviderFail.SetError(mTxtBxPwdNewConf, "A jelszó megerősítése nem megfelelő");
                        return false;
                    }
                    else
                    {   //it tests the lenght, contains digit, Uppercase-lowecase letters and spec character
                        if (!personalController.analyzePassword())
                        {
                            errorProviderFail.SetError(mTxtBxPwdNew, "A jelszó nem elég bonyolult");
                            return false;
                        }
                        else
                            return true;
                    }
                }
                else
                {
                    errorProviderFail.SetError(mBtnSaveNewPwd, "Kérem ne hagyja üresen az új jelszó mezőket");
                    return false;
                }
            }
            else
            {
                errorProviderFail.SetError(mTxtBxPwdOld, "Kérem írja be régi jelszavát");
                return false;
            }
        }

        #endregion

    }
}
