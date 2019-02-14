namespace WFAThesisProject
{
    partial class FormServicePersonalWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServicePersonalWindow));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.mTileExit = new MetroFramework.Controls.MetroTile();
            this.mTileShowHealth = new MetroFramework.Controls.MetroTile();
            this.mTileReconfRwd = new MetroFramework.Controls.MetroTile();
            this.mTileReconfDatas = new MetroFramework.Controls.MetroTile();
            this.mTxtBxLastName = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxUserName = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxWorkArea = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxPwdOld = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxPosition = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxFirstName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxTaj = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxPwdNew = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxPwdNewConf = new MetroFramework.Controls.MetroTextBox();
            this.mLabelPwdNew2 = new MetroFramework.Controls.MetroLabel();
            this.mLabelPwdNew1 = new MetroFramework.Controls.MetroLabel();
            this.mLabelPwdOld = new MetroFramework.Controls.MetroLabel();
            this.mBtnSaveDatas = new MetroFramework.Controls.MetroButton();
            this.mBtnSaveNewPwd = new MetroFramework.Controls.MetroButton();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.mLabelMainTitle = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxUserGroup = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.errorProviderFail = new System.Windows.Forms.ErrorProvider(this.components);
            this.mBtnCancelDet = new MetroFramework.Controls.MetroButton();
            this.mBtnCancelPwd = new MetroFramework.Controls.MetroButton();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFail)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroPanel1.BackgroundImage")));
            this.metroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroPanel1.Controls.Add(this.mTileExit);
            this.metroPanel1.Controls.Add(this.mTileShowHealth);
            this.metroPanel1.Controls.Add(this.mTileReconfRwd);
            this.metroPanel1.Controls.Add(this.mTileReconfDatas);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 5);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(200, 449);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // mTileExit
            // 
            this.mTileExit.ActiveControl = null;
            this.mTileExit.Location = new System.Drawing.Point(23, 374);
            this.mTileExit.Name = "mTileExit";
            this.mTileExit.Size = new System.Drawing.Size(150, 40);
            this.mTileExit.Style = MetroFramework.MetroColorStyle.Silver;
            this.mTileExit.TabIndex = 6;
            this.mTileExit.Text = "Kilépés";
            this.mTileExit.UseSelectable = true;
            this.mTileExit.Click += new System.EventHandler(this.mTileExit_Click);
            // 
            // mTileShowHealth
            // 
            this.mTileShowHealth.ActiveControl = null;
            this.mTileShowHealth.Location = new System.Drawing.Point(23, 314);
            this.mTileShowHealth.Name = "mTileShowHealth";
            this.mTileShowHealth.Size = new System.Drawing.Size(150, 40);
            this.mTileShowHealth.Style = MetroFramework.MetroColorStyle.Red;
            this.mTileShowHealth.TabIndex = 6;
            this.mTileShowHealth.Text = "Egészségügyi PDF";
            this.mTileShowHealth.UseSelectable = true;
            this.mTileShowHealth.Click += new System.EventHandler(this.mTileShowHealth_Click);
            // 
            // mTileReconfRwd
            // 
            this.mTileReconfRwd.ActiveControl = null;
            this.mTileReconfRwd.Location = new System.Drawing.Point(23, 189);
            this.mTileReconfRwd.Name = "mTileReconfRwd";
            this.mTileReconfRwd.Size = new System.Drawing.Size(150, 40);
            this.mTileReconfRwd.Style = MetroFramework.MetroColorStyle.Red;
            this.mTileReconfRwd.TabIndex = 6;
            this.mTileReconfRwd.Text = "Jelszavam módosítása";
            this.mTileReconfRwd.UseSelectable = true;
            this.mTileReconfRwd.Click += new System.EventHandler(this.mTileReconfRwd_Click);
            // 
            // mTileReconfDatas
            // 
            this.mTileReconfDatas.ActiveControl = null;
            this.mTileReconfDatas.Location = new System.Drawing.Point(23, 249);
            this.mTileReconfDatas.Name = "mTileReconfDatas";
            this.mTileReconfDatas.Size = new System.Drawing.Size(150, 40);
            this.mTileReconfDatas.Style = MetroFramework.MetroColorStyle.Red;
            this.mTileReconfDatas.TabIndex = 6;
            this.mTileReconfDatas.Text = "Adataim módosítása";
            this.mTileReconfDatas.UseSelectable = true;
            this.mTileReconfDatas.Click += new System.EventHandler(this.mTileReconfDatas_Click);
            // 
            // mTxtBxLastName
            // 
            // 
            // 
            // 
            this.mTxtBxLastName.CustomButton.Image = null;
            this.mTxtBxLastName.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.mTxtBxLastName.CustomButton.Name = "";
            this.mTxtBxLastName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxLastName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxLastName.CustomButton.TabIndex = 1;
            this.mTxtBxLastName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxLastName.CustomButton.UseSelectable = true;
            this.mTxtBxLastName.CustomButton.Visible = false;
            this.mTxtBxLastName.Lines = new string[0];
            this.mTxtBxLastName.Location = new System.Drawing.Point(214, 97);
            this.mTxtBxLastName.MaxLength = 32767;
            this.mTxtBxLastName.Name = "mTxtBxLastName";
            this.mTxtBxLastName.PasswordChar = '\0';
            this.mTxtBxLastName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxLastName.SelectedText = "";
            this.mTxtBxLastName.SelectionLength = 0;
            this.mTxtBxLastName.SelectionStart = 0;
            this.mTxtBxLastName.ShortcutsEnabled = true;
            this.mTxtBxLastName.Size = new System.Drawing.Size(175, 23);
            this.mTxtBxLastName.TabIndex = 1;
            this.mTxtBxLastName.UseSelectable = true;
            this.mTxtBxLastName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxLastName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxUserName
            // 
            // 
            // 
            // 
            this.mTxtBxUserName.CustomButton.Image = null;
            this.mTxtBxUserName.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.mTxtBxUserName.CustomButton.Name = "";
            this.mTxtBxUserName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxUserName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxUserName.CustomButton.TabIndex = 1;
            this.mTxtBxUserName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxUserName.CustomButton.UseSelectable = true;
            this.mTxtBxUserName.CustomButton.Visible = false;
            this.mTxtBxUserName.Lines = new string[0];
            this.mTxtBxUserName.Location = new System.Drawing.Point(214, 336);
            this.mTxtBxUserName.MaxLength = 32767;
            this.mTxtBxUserName.Name = "mTxtBxUserName";
            this.mTxtBxUserName.PasswordChar = '\0';
            this.mTxtBxUserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxUserName.SelectedText = "";
            this.mTxtBxUserName.SelectionLength = 0;
            this.mTxtBxUserName.SelectionStart = 0;
            this.mTxtBxUserName.ShortcutsEnabled = true;
            this.mTxtBxUserName.Size = new System.Drawing.Size(175, 23);
            this.mTxtBxUserName.TabIndex = 1;
            this.mTxtBxUserName.UseSelectable = true;
            this.mTxtBxUserName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxUserName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxWorkArea
            // 
            // 
            // 
            // 
            this.mTxtBxWorkArea.CustomButton.Image = null;
            this.mTxtBxWorkArea.CustomButton.Location = new System.Drawing.Point(155, 1);
            this.mTxtBxWorkArea.CustomButton.Name = "";
            this.mTxtBxWorkArea.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxWorkArea.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxWorkArea.CustomButton.TabIndex = 1;
            this.mTxtBxWorkArea.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxWorkArea.CustomButton.UseSelectable = true;
            this.mTxtBxWorkArea.CustomButton.Visible = false;
            this.mTxtBxWorkArea.Lines = new string[0];
            this.mTxtBxWorkArea.Location = new System.Drawing.Point(425, 394);
            this.mTxtBxWorkArea.MaxLength = 32767;
            this.mTxtBxWorkArea.Name = "mTxtBxWorkArea";
            this.mTxtBxWorkArea.PasswordChar = '\0';
            this.mTxtBxWorkArea.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxWorkArea.SelectedText = "";
            this.mTxtBxWorkArea.SelectionLength = 0;
            this.mTxtBxWorkArea.SelectionStart = 0;
            this.mTxtBxWorkArea.ShortcutsEnabled = true;
            this.mTxtBxWorkArea.Size = new System.Drawing.Size(177, 23);
            this.mTxtBxWorkArea.TabIndex = 1;
            this.mTxtBxWorkArea.UseSelectable = true;
            this.mTxtBxWorkArea.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxWorkArea.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxPwdOld
            // 
            // 
            // 
            // 
            this.mTxtBxPwdOld.CustomButton.Image = null;
            this.mTxtBxPwdOld.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.mTxtBxPwdOld.CustomButton.Name = "";
            this.mTxtBxPwdOld.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxPwdOld.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxPwdOld.CustomButton.TabIndex = 1;
            this.mTxtBxPwdOld.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxPwdOld.CustomButton.UseSelectable = true;
            this.mTxtBxPwdOld.CustomButton.Visible = false;
            this.mTxtBxPwdOld.Lines = new string[0];
            this.mTxtBxPwdOld.Location = new System.Drawing.Point(426, 97);
            this.mTxtBxPwdOld.MaxLength = 32767;
            this.mTxtBxPwdOld.Name = "mTxtBxPwdOld";
            this.mTxtBxPwdOld.PasswordChar = '\0';
            this.mTxtBxPwdOld.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxPwdOld.SelectedText = "";
            this.mTxtBxPwdOld.SelectionLength = 0;
            this.mTxtBxPwdOld.SelectionStart = 0;
            this.mTxtBxPwdOld.ShortcutsEnabled = true;
            this.mTxtBxPwdOld.Size = new System.Drawing.Size(175, 23);
            this.mTxtBxPwdOld.TabIndex = 1;
            this.mTxtBxPwdOld.UseSelectable = true;
            this.mTxtBxPwdOld.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxPwdOld.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxPosition
            // 
            // 
            // 
            // 
            this.mTxtBxPosition.CustomButton.Image = null;
            this.mTxtBxPosition.CustomButton.Location = new System.Drawing.Point(155, 1);
            this.mTxtBxPosition.CustomButton.Name = "";
            this.mTxtBxPosition.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxPosition.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxPosition.CustomButton.TabIndex = 1;
            this.mTxtBxPosition.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxPosition.CustomButton.UseSelectable = true;
            this.mTxtBxPosition.CustomButton.Visible = false;
            this.mTxtBxPosition.Lines = new string[0];
            this.mTxtBxPosition.Location = new System.Drawing.Point(425, 336);
            this.mTxtBxPosition.MaxLength = 32767;
            this.mTxtBxPosition.Name = "mTxtBxPosition";
            this.mTxtBxPosition.PasswordChar = '\0';
            this.mTxtBxPosition.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxPosition.SelectedText = "";
            this.mTxtBxPosition.SelectionLength = 0;
            this.mTxtBxPosition.SelectionStart = 0;
            this.mTxtBxPosition.ShortcutsEnabled = true;
            this.mTxtBxPosition.Size = new System.Drawing.Size(177, 23);
            this.mTxtBxPosition.TabIndex = 1;
            this.mTxtBxPosition.UseSelectable = true;
            this.mTxtBxPosition.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxPosition.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxFirstName
            // 
            // 
            // 
            // 
            this.mTxtBxFirstName.CustomButton.Image = null;
            this.mTxtBxFirstName.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.mTxtBxFirstName.CustomButton.Name = "";
            this.mTxtBxFirstName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxFirstName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxFirstName.CustomButton.TabIndex = 1;
            this.mTxtBxFirstName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxFirstName.CustomButton.UseSelectable = true;
            this.mTxtBxFirstName.CustomButton.Visible = false;
            this.mTxtBxFirstName.Lines = new string[0];
            this.mTxtBxFirstName.Location = new System.Drawing.Point(214, 153);
            this.mTxtBxFirstName.MaxLength = 32767;
            this.mTxtBxFirstName.Name = "mTxtBxFirstName";
            this.mTxtBxFirstName.PasswordChar = '\0';
            this.mTxtBxFirstName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxFirstName.SelectedText = "";
            this.mTxtBxFirstName.SelectionLength = 0;
            this.mTxtBxFirstName.SelectionStart = 0;
            this.mTxtBxFirstName.ShortcutsEnabled = true;
            this.mTxtBxFirstName.Size = new System.Drawing.Size(175, 23);
            this.mTxtBxFirstName.TabIndex = 1;
            this.mTxtBxFirstName.UseSelectable = true;
            this.mTxtBxFirstName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxFirstName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(214, 72);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(74, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Vezetéknév";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(214, 131);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(70, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Keresztnév";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(425, 314);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(59, 19);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Beosztás";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(214, 314);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(96, 19);
            this.metroLabel4.TabIndex = 2;
            this.metroLabel4.Text = "Felhasználónév";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(425, 372);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(85, 19);
            this.metroLabel5.TabIndex = 2;
            this.metroLabel5.Text = "Munkaterület";
            // 
            // mTxtBxTaj
            // 
            // 
            // 
            // 
            this.mTxtBxTaj.CustomButton.Image = null;
            this.mTxtBxTaj.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.mTxtBxTaj.CustomButton.Name = "";
            this.mTxtBxTaj.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxTaj.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxTaj.CustomButton.TabIndex = 1;
            this.mTxtBxTaj.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxTaj.CustomButton.UseSelectable = true;
            this.mTxtBxTaj.CustomButton.Visible = false;
            this.mTxtBxTaj.Lines = new string[0];
            this.mTxtBxTaj.Location = new System.Drawing.Point(214, 210);
            this.mTxtBxTaj.MaxLength = 32767;
            this.mTxtBxTaj.Name = "mTxtBxTaj";
            this.mTxtBxTaj.PasswordChar = '\0';
            this.mTxtBxTaj.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxTaj.SelectedText = "";
            this.mTxtBxTaj.SelectionLength = 0;
            this.mTxtBxTaj.SelectionStart = 0;
            this.mTxtBxTaj.ShortcutsEnabled = true;
            this.mTxtBxTaj.Size = new System.Drawing.Size(175, 23);
            this.mTxtBxTaj.TabIndex = 1;
            this.mTxtBxTaj.UseSelectable = true;
            this.mTxtBxTaj.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxTaj.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(214, 188);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(56, 19);
            this.metroLabel7.TabIndex = 2;
            this.metroLabel7.Text = "Tajszám";
            // 
            // mTxtBxPwdNew
            // 
            // 
            // 
            // 
            this.mTxtBxPwdNew.CustomButton.Image = null;
            this.mTxtBxPwdNew.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.mTxtBxPwdNew.CustomButton.Name = "";
            this.mTxtBxPwdNew.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxPwdNew.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxPwdNew.CustomButton.TabIndex = 1;
            this.mTxtBxPwdNew.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxPwdNew.CustomButton.UseSelectable = true;
            this.mTxtBxPwdNew.CustomButton.Visible = false;
            this.mTxtBxPwdNew.Lines = new string[0];
            this.mTxtBxPwdNew.Location = new System.Drawing.Point(427, 153);
            this.mTxtBxPwdNew.MaxLength = 32767;
            this.mTxtBxPwdNew.Name = "mTxtBxPwdNew";
            this.mTxtBxPwdNew.PasswordChar = '\0';
            this.mTxtBxPwdNew.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxPwdNew.SelectedText = "";
            this.mTxtBxPwdNew.SelectionLength = 0;
            this.mTxtBxPwdNew.SelectionStart = 0;
            this.mTxtBxPwdNew.ShortcutsEnabled = true;
            this.mTxtBxPwdNew.Size = new System.Drawing.Size(175, 23);
            this.mTxtBxPwdNew.TabIndex = 1;
            this.mTxtBxPwdNew.UseSelectable = true;
            this.mTxtBxPwdNew.Visible = false;
            this.mTxtBxPwdNew.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxPwdNew.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxPwdNewConf
            // 
            // 
            // 
            // 
            this.mTxtBxPwdNewConf.CustomButton.Image = null;
            this.mTxtBxPwdNewConf.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.mTxtBxPwdNewConf.CustomButton.Name = "";
            this.mTxtBxPwdNewConf.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxPwdNewConf.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxPwdNewConf.CustomButton.TabIndex = 1;
            this.mTxtBxPwdNewConf.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxPwdNewConf.CustomButton.UseSelectable = true;
            this.mTxtBxPwdNewConf.CustomButton.Visible = false;
            this.mTxtBxPwdNewConf.Lines = new string[0];
            this.mTxtBxPwdNewConf.Location = new System.Drawing.Point(427, 210);
            this.mTxtBxPwdNewConf.MaxLength = 32767;
            this.mTxtBxPwdNewConf.Name = "mTxtBxPwdNewConf";
            this.mTxtBxPwdNewConf.PasswordChar = '\0';
            this.mTxtBxPwdNewConf.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxPwdNewConf.SelectedText = "";
            this.mTxtBxPwdNewConf.SelectionLength = 0;
            this.mTxtBxPwdNewConf.SelectionStart = 0;
            this.mTxtBxPwdNewConf.ShortcutsEnabled = true;
            this.mTxtBxPwdNewConf.Size = new System.Drawing.Size(175, 23);
            this.mTxtBxPwdNewConf.TabIndex = 1;
            this.mTxtBxPwdNewConf.UseSelectable = true;
            this.mTxtBxPwdNewConf.Visible = false;
            this.mTxtBxPwdNewConf.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxPwdNewConf.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mLabelPwdNew2
            // 
            this.mLabelPwdNew2.AutoSize = true;
            this.mLabelPwdNew2.Location = new System.Drawing.Point(426, 188);
            this.mLabelPwdNew2.Name = "mLabelPwdNew2";
            this.mLabelPwdNew2.Size = new System.Drawing.Size(139, 19);
            this.mLabelPwdNew2.TabIndex = 2;
            this.mLabelPwdNew2.Text = "Új jelszó megerősítése";
            this.mLabelPwdNew2.Visible = false;
            // 
            // mLabelPwdNew1
            // 
            this.mLabelPwdNew1.AutoSize = true;
            this.mLabelPwdNew1.Location = new System.Drawing.Point(427, 131);
            this.mLabelPwdNew1.Name = "mLabelPwdNew1";
            this.mLabelPwdNew1.Size = new System.Drawing.Size(57, 19);
            this.mLabelPwdNew1.TabIndex = 2;
            this.mLabelPwdNew1.Text = "Új jelszó";
            this.mLabelPwdNew1.Visible = false;
            // 
            // mLabelPwdOld
            // 
            this.mLabelPwdOld.AutoSize = true;
            this.mLabelPwdOld.Location = new System.Drawing.Point(427, 75);
            this.mLabelPwdOld.Name = "mLabelPwdOld";
            this.mLabelPwdOld.Size = new System.Drawing.Size(71, 19);
            this.mLabelPwdOld.TabIndex = 2;
            this.mLabelPwdOld.Text = "Régi jelszó";
            // 
            // mBtnSaveDatas
            // 
            this.mBtnSaveDatas.Location = new System.Drawing.Point(228, 252);
            this.mBtnSaveDatas.Name = "mBtnSaveDatas";
            this.mBtnSaveDatas.Size = new System.Drawing.Size(140, 23);
            this.mBtnSaveDatas.TabIndex = 3;
            this.mBtnSaveDatas.Text = "Adataim mentése";
            this.mBtnSaveDatas.UseSelectable = true;
            this.mBtnSaveDatas.Visible = false;
            this.mBtnSaveDatas.Click += new System.EventHandler(this.mBtnSaveDatas_Click);
            // 
            // mBtnSaveNewPwd
            // 
            this.mBtnSaveNewPwd.Location = new System.Drawing.Point(441, 252);
            this.mBtnSaveNewPwd.Name = "mBtnSaveNewPwd";
            this.mBtnSaveNewPwd.Size = new System.Drawing.Size(140, 23);
            this.mBtnSaveNewPwd.TabIndex = 3;
            this.mBtnSaveNewPwd.Text = "Jeszó mentése";
            this.mBtnSaveNewPwd.UseSelectable = true;
            this.mBtnSaveNewPwd.Visible = false;
            this.mBtnSaveNewPwd.Click += new System.EventHandler(this.mBtnSaveNewPwd_Click);
            // 
            // metroPanel3
            // 
            this.metroPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroPanel3.BackgroundImage")));
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(0, 5);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(200, 100);
            this.metroPanel3.TabIndex = 8;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // mLabelMainTitle
            // 
            this.mLabelMainTitle.AutoSize = true;
            this.mLabelMainTitle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mLabelMainTitle.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mLabelMainTitle.Location = new System.Drawing.Point(214, 28);
            this.mLabelMainTitle.Name = "mLabelMainTitle";
            this.mLabelMainTitle.Size = new System.Drawing.Size(209, 25);
            this.mLabelMainTitle.TabIndex = 9;
            this.mLabelMainTitle.Text = "Saját profilom kezelése";
            // 
            // mTxtBxUserGroup
            // 
            // 
            // 
            // 
            this.mTxtBxUserGroup.CustomButton.Image = null;
            this.mTxtBxUserGroup.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.mTxtBxUserGroup.CustomButton.Name = "";
            this.mTxtBxUserGroup.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxUserGroup.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxUserGroup.CustomButton.TabIndex = 1;
            this.mTxtBxUserGroup.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxUserGroup.CustomButton.UseSelectable = true;
            this.mTxtBxUserGroup.CustomButton.Visible = false;
            this.mTxtBxUserGroup.Lines = new string[0];
            this.mTxtBxUserGroup.Location = new System.Drawing.Point(214, 394);
            this.mTxtBxUserGroup.MaxLength = 32767;
            this.mTxtBxUserGroup.Name = "mTxtBxUserGroup";
            this.mTxtBxUserGroup.PasswordChar = '\0';
            this.mTxtBxUserGroup.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxUserGroup.SelectedText = "";
            this.mTxtBxUserGroup.SelectionLength = 0;
            this.mTxtBxUserGroup.SelectionStart = 0;
            this.mTxtBxUserGroup.ShortcutsEnabled = true;
            this.mTxtBxUserGroup.Size = new System.Drawing.Size(175, 23);
            this.mTxtBxUserGroup.TabIndex = 1;
            this.mTxtBxUserGroup.UseSelectable = true;
            this.mTxtBxUserGroup.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxUserGroup.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(214, 372);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(128, 19);
            this.metroLabel6.TabIndex = 2;
            this.metroLabel6.Text = "Felhasználói jogköre";
            // 
            // errorProviderFail
            // 
            this.errorProviderFail.ContainerControl = this;
            // 
            // mBtnCancelDet
            // 
            this.mBtnCancelDet.Location = new System.Drawing.Point(228, 281);
            this.mBtnCancelDet.Name = "mBtnCancelDet";
            this.mBtnCancelDet.Size = new System.Drawing.Size(140, 23);
            this.mBtnCancelDet.TabIndex = 3;
            this.mBtnCancelDet.Text = "Mégse";
            this.mBtnCancelDet.UseSelectable = true;
            this.mBtnCancelDet.Visible = false;
            this.mBtnCancelDet.Click += new System.EventHandler(this.mBtnCancelDet_Click);
            // 
            // mBtnCancelPwd
            // 
            this.mBtnCancelPwd.Location = new System.Drawing.Point(441, 281);
            this.mBtnCancelPwd.Name = "mBtnCancelPwd";
            this.mBtnCancelPwd.Size = new System.Drawing.Size(140, 23);
            this.mBtnCancelPwd.TabIndex = 3;
            this.mBtnCancelPwd.Text = "Mégse";
            this.mBtnCancelPwd.UseSelectable = true;
            this.mBtnCancelPwd.Visible = false;
            this.mBtnCancelPwd.Click += new System.EventHandler(this.mBtnCancelPwd_Click);
            // 
            // FormServicePersonalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 450);
            this.Controls.Add(this.mLabelMainTitle);
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.mBtnSaveNewPwd);
            this.Controls.Add(this.mBtnCancelPwd);
            this.Controls.Add(this.mBtnCancelDet);
            this.Controls.Add(this.mBtnSaveDatas);
            this.Controls.Add(this.mLabelPwdOld);
            this.Controls.Add(this.mLabelPwdNew1);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.mLabelPwdNew2);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.mTxtBxPwdOld);
            this.Controls.Add(this.mTxtBxPwdNewConf);
            this.Controls.Add(this.mTxtBxPosition);
            this.Controls.Add(this.mTxtBxWorkArea);
            this.Controls.Add(this.mTxtBxPwdNew);
            this.Controls.Add(this.mTxtBxUserGroup);
            this.Controls.Add(this.mTxtBxUserName);
            this.Controls.Add(this.mTxtBxTaj);
            this.Controls.Add(this.mTxtBxFirstName);
            this.Controls.Add(this.mTxtBxLastName);
            this.Controls.Add(this.metroPanel1);
            this.Name = "FormServicePersonalWindow";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormServicePersonalManage_FormClosed);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox mTxtBxLastName;
        private MetroFramework.Controls.MetroTextBox mTxtBxUserName;
        private MetroFramework.Controls.MetroTextBox mTxtBxWorkArea;
        private MetroFramework.Controls.MetroTextBox mTxtBxPwdOld;
        private MetroFramework.Controls.MetroTextBox mTxtBxPosition;
        private MetroFramework.Controls.MetroTextBox mTxtBxFirstName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTile mTileReconfDatas;
        private MetroFramework.Controls.MetroTextBox mTxtBxTaj;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTile mTileReconfRwd;
        private MetroFramework.Controls.MetroTile mTileExit;
        private MetroFramework.Controls.MetroTextBox mTxtBxPwdNew;
        private MetroFramework.Controls.MetroTextBox mTxtBxPwdNewConf;
        private MetroFramework.Controls.MetroLabel mLabelPwdNew2;
        private MetroFramework.Controls.MetroLabel mLabelPwdNew1;
        private MetroFramework.Controls.MetroLabel mLabelPwdOld;
        private MetroFramework.Controls.MetroButton mBtnSaveDatas;
        private MetroFramework.Controls.MetroButton mBtnSaveNewPwd;
        private MetroFramework.Controls.MetroTile mTileShowHealth;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroLabel mLabelMainTitle;
        private MetroFramework.Controls.MetroTextBox mTxtBxUserGroup;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.ErrorProvider errorProviderFail;
        private MetroFramework.Controls.MetroButton mBtnCancelPwd;
        private MetroFramework.Controls.MetroButton mBtnCancelDet;
    }
}