namespace WFAThesisProject
{
    partial class FormServiceRightsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServiceRightsWindow));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.mTileExit = new MetroFramework.Controls.MetroTile();
            this.mTileNew = new MetroFramework.Controls.MetroTile();
            this.mTileModify = new MetroFramework.Controls.MetroTile();
            this.mTileDelete = new MetroFramework.Controls.MetroTile();
            this.mCmbBxAllGroups = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.mCmbBxSubcontr = new MetroFramework.Controls.MetroComboBox();
            this.mCmbBxRequest = new MetroFramework.Controls.MetroComboBox();
            this.mCmbBxOrder = new MetroFramework.Controls.MetroComboBox();
            this.mCmbBxStore = new MetroFramework.Controls.MetroComboBox();
            this.mCmbBxAccidents = new MetroFramework.Controls.MetroComboBox();
            this.mCmbBxUsers = new MetroFramework.Controls.MetroComboBox();
            this.mCmbBxRights = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxGroupName = new MetroFramework.Controls.MetroTextBox();
            this.mLblGroup = new MetroFramework.Controls.MetroLabel();
            this.mBtnSave = new MetroFramework.Controls.MetroButton();
            this.mBtnCancel = new MetroFramework.Controls.MetroButton();
            this.mLabelMainTitle = new MetroFramework.Controls.MetroLabel();
            this.errorProviderFail = new System.Windows.Forms.ErrorProvider(this.components);
            this.mCmbBxAccidLocal = new MetroFramework.Controls.MetroComboBox();
            this.mCmbBxUsersLocal = new MetroFramework.Controls.MetroComboBox();
            this.mCmbBxRequestLocal = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
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
            this.metroPanel1.Controls.Add(this.metroPanel2);
            this.metroPanel1.Controls.Add(this.mTileExit);
            this.metroPanel1.Controls.Add(this.mTileNew);
            this.metroPanel1.Controls.Add(this.mTileModify);
            this.metroPanel1.Controls.Add(this.mTileDelete);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 5);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(200, 480);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            this.metroPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroPanel2.BackgroundImage")));
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(200, 100);
            this.metroPanel2.TabIndex = 5;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // mTileExit
            // 
            this.mTileExit.ActiveControl = null;
            this.mTileExit.Location = new System.Drawing.Point(23, 404);
            this.mTileExit.Name = "mTileExit";
            this.mTileExit.Size = new System.Drawing.Size(150, 40);
            this.mTileExit.Style = MetroFramework.MetroColorStyle.Silver;
            this.mTileExit.TabIndex = 17;
            this.mTileExit.Text = "Vissza";
            this.mTileExit.UseSelectable = true;
            this.mTileExit.Click += new System.EventHandler(this.mTileExit_Click);
            // 
            // mTileNew
            // 
            this.mTileNew.ActiveControl = null;
            this.mTileNew.Location = new System.Drawing.Point(23, 224);
            this.mTileNew.Name = "mTileNew";
            this.mTileNew.Size = new System.Drawing.Size(150, 40);
            this.mTileNew.Style = MetroFramework.MetroColorStyle.Red;
            this.mTileNew.TabIndex = 14;
            this.mTileNew.Text = "Új csoport létrehozás";
            this.mTileNew.UseSelectable = true;
            this.mTileNew.Visible = false;
            this.mTileNew.Click += new System.EventHandler(this.mTileNew_Click);
            // 
            // mTileModify
            // 
            this.mTileModify.ActiveControl = null;
            this.mTileModify.Location = new System.Drawing.Point(23, 284);
            this.mTileModify.Name = "mTileModify";
            this.mTileModify.Size = new System.Drawing.Size(150, 40);
            this.mTileModify.Style = MetroFramework.MetroColorStyle.Red;
            this.mTileModify.TabIndex = 15;
            this.mTileModify.Text = "Csoport módosítása";
            this.mTileModify.UseSelectable = true;
            this.mTileModify.Visible = false;
            this.mTileModify.Click += new System.EventHandler(this.mTileModify_Click);
            // 
            // mTileDelete
            // 
            this.mTileDelete.ActiveControl = null;
            this.mTileDelete.Location = new System.Drawing.Point(23, 344);
            this.mTileDelete.Name = "mTileDelete";
            this.mTileDelete.Size = new System.Drawing.Size(150, 40);
            this.mTileDelete.Style = MetroFramework.MetroColorStyle.Red;
            this.mTileDelete.TabIndex = 16;
            this.mTileDelete.Text = "Csoport törlése";
            this.mTileDelete.UseSelectable = true;
            this.mTileDelete.Visible = false;
            this.mTileDelete.Click += new System.EventHandler(this.mTileDelete_Click);
            // 
            // mCmbBxAllGroups
            // 
            this.mCmbBxAllGroups.FormattingEnabled = true;
            this.mCmbBxAllGroups.ItemHeight = 23;
            this.mCmbBxAllGroups.Location = new System.Drawing.Point(232, 104);
            this.mCmbBxAllGroups.Name = "mCmbBxAllGroups";
            this.mCmbBxAllGroups.Size = new System.Drawing.Size(143, 29);
            this.mCmbBxAllGroups.TabIndex = 0;
            this.mCmbBxAllGroups.UseSelectable = true;
            this.mCmbBxAllGroups.SelectedIndexChanged += new System.EventHandler(this.mCmbBxAllGroups_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(231, 82);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(142, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Jogosultsági csoportok";
            // 
            // mCmbBxSubcontr
            // 
            this.mCmbBxSubcontr.Enabled = false;
            this.mCmbBxSubcontr.FormattingEnabled = true;
            this.mCmbBxSubcontr.ItemHeight = 23;
            this.mCmbBxSubcontr.Items.AddRange(new object[] {
            "Elérés tiltása",
            "Olvasási jog",
            "Módosítási jog"});
            this.mCmbBxSubcontr.Location = new System.Drawing.Point(410, 104);
            this.mCmbBxSubcontr.Name = "mCmbBxSubcontr";
            this.mCmbBxSubcontr.Size = new System.Drawing.Size(142, 29);
            this.mCmbBxSubcontr.TabIndex = 4;
            this.mCmbBxSubcontr.UseSelectable = true;
            // 
            // mCmbBxRequest
            // 
            this.mCmbBxRequest.Enabled = false;
            this.mCmbBxRequest.FormattingEnabled = true;
            this.mCmbBxRequest.ItemHeight = 23;
            this.mCmbBxRequest.Items.AddRange(new object[] {
            "Elérés tiltása",
            "Olvasási jog",
            "Módosítási jog"});
            this.mCmbBxRequest.Location = new System.Drawing.Point(410, 318);
            this.mCmbBxRequest.Name = "mCmbBxRequest";
            this.mCmbBxRequest.Size = new System.Drawing.Size(142, 29);
            this.mCmbBxRequest.TabIndex = 8;
            this.mCmbBxRequest.UseSelectable = true;
            // 
            // mCmbBxOrder
            // 
            this.mCmbBxOrder.Enabled = false;
            this.mCmbBxOrder.FormattingEnabled = true;
            this.mCmbBxOrder.ItemHeight = 23;
            this.mCmbBxOrder.Items.AddRange(new object[] {
            "Elérés tiltása",
            "Olvasási jog",
            "Módosítási jog"});
            this.mCmbBxOrder.Location = new System.Drawing.Point(409, 212);
            this.mCmbBxOrder.Name = "mCmbBxOrder";
            this.mCmbBxOrder.Size = new System.Drawing.Size(143, 29);
            this.mCmbBxOrder.TabIndex = 6;
            this.mCmbBxOrder.UseSelectable = true;
            // 
            // mCmbBxStore
            // 
            this.mCmbBxStore.Enabled = false;
            this.mCmbBxStore.FormattingEnabled = true;
            this.mCmbBxStore.ItemHeight = 23;
            this.mCmbBxStore.Items.AddRange(new object[] {
            "Elérés tiltása",
            "Olvasási jog",
            "Módosítási jog"});
            this.mCmbBxStore.Location = new System.Drawing.Point(409, 266);
            this.mCmbBxStore.Name = "mCmbBxStore";
            this.mCmbBxStore.Size = new System.Drawing.Size(142, 29);
            this.mCmbBxStore.TabIndex = 7;
            this.mCmbBxStore.UseSelectable = true;
            // 
            // mCmbBxAccidents
            // 
            this.mCmbBxAccidents.Enabled = false;
            this.mCmbBxAccidents.FormattingEnabled = true;
            this.mCmbBxAccidents.ItemHeight = 23;
            this.mCmbBxAccidents.Items.AddRange(new object[] {
            "Elérés tiltása",
            "Olvasási jog",
            "Módosítási jog"});
            this.mCmbBxAccidents.Location = new System.Drawing.Point(409, 428);
            this.mCmbBxAccidents.Name = "mCmbBxAccidents";
            this.mCmbBxAccidents.Size = new System.Drawing.Size(142, 29);
            this.mCmbBxAccidents.TabIndex = 10;
            this.mCmbBxAccidents.UseSelectable = true;
            // 
            // mCmbBxUsers
            // 
            this.mCmbBxUsers.Enabled = false;
            this.mCmbBxUsers.FormattingEnabled = true;
            this.mCmbBxUsers.ItemHeight = 23;
            this.mCmbBxUsers.Items.AddRange(new object[] {
            "Elérés tiltása",
            "Olvasási jog",
            "Módosítási jog"});
            this.mCmbBxUsers.Location = new System.Drawing.Point(409, 374);
            this.mCmbBxUsers.Name = "mCmbBxUsers";
            this.mCmbBxUsers.Size = new System.Drawing.Size(142, 29);
            this.mCmbBxUsers.TabIndex = 9;
            this.mCmbBxUsers.UseSelectable = true;
            // 
            // mCmbBxRights
            // 
            this.mCmbBxRights.Enabled = false;
            this.mCmbBxRights.FormattingEnabled = true;
            this.mCmbBxRights.ItemHeight = 23;
            this.mCmbBxRights.Items.AddRange(new object[] {
            "Elérés tiltása",
            "Olvasási jog",
            "Módosítási jog"});
            this.mCmbBxRights.Location = new System.Drawing.Point(410, 158);
            this.mCmbBxRights.Name = "mCmbBxRights";
            this.mCmbBxRights.Size = new System.Drawing.Size(142, 29);
            this.mCmbBxRights.TabIndex = 5;
            this.mCmbBxRights.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(410, 82);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(91, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Szállítókezelés";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(410, 296);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(81, 19);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Kéréskezelés";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(409, 190);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(102, 19);
            this.metroLabel4.TabIndex = 2;
            this.metroLabel4.Text = "Rendeléskezelés";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(409, 244);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(87, 19);
            this.metroLabel5.TabIndex = 2;
            this.metroLabel5.Text = "Raktárkezelés";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(410, 136);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(118, 19);
            this.metroLabel7.TabIndex = 2;
            this.metroLabel7.Text = "Jogosultságkezelés";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(410, 352);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(117, 19);
            this.metroLabel8.TabIndex = 2;
            this.metroLabel8.Text = "Felhasználókezelés";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(410, 406);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(91, 19);
            this.metroLabel9.TabIndex = 2;
            this.metroLabel9.Text = "Balesetkezelés";
            // 
            // mTxtBxGroupName
            // 
            // 
            // 
            // 
            this.mTxtBxGroupName.CustomButton.Image = null;
            this.mTxtBxGroupName.CustomButton.Location = new System.Drawing.Point(122, 1);
            this.mTxtBxGroupName.CustomButton.Name = "";
            this.mTxtBxGroupName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxGroupName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxGroupName.CustomButton.TabIndex = 1;
            this.mTxtBxGroupName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxGroupName.CustomButton.UseSelectable = true;
            this.mTxtBxGroupName.CustomButton.Visible = false;
            this.mTxtBxGroupName.Lines = new string[0];
            this.mTxtBxGroupName.Location = new System.Drawing.Point(231, 158);
            this.mTxtBxGroupName.MaxLength = 32767;
            this.mTxtBxGroupName.Name = "mTxtBxGroupName";
            this.mTxtBxGroupName.PasswordChar = '\0';
            this.mTxtBxGroupName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxGroupName.SelectedText = "";
            this.mTxtBxGroupName.SelectionLength = 0;
            this.mTxtBxGroupName.SelectionStart = 0;
            this.mTxtBxGroupName.ShortcutsEnabled = true;
            this.mTxtBxGroupName.Size = new System.Drawing.Size(144, 23);
            this.mTxtBxGroupName.TabIndex = 11;
            this.mTxtBxGroupName.UseSelectable = true;
            this.mTxtBxGroupName.Visible = false;
            this.mTxtBxGroupName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxGroupName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mLblGroup
            // 
            this.mLblGroup.AutoSize = true;
            this.mLblGroup.Location = new System.Drawing.Point(231, 136);
            this.mLblGroup.Name = "mLblGroup";
            this.mLblGroup.Size = new System.Drawing.Size(97, 19);
            this.mLblGroup.TabIndex = 7;
            this.mLblGroup.Text = "A csoport neve";
            this.mLblGroup.Visible = false;
            // 
            // mBtnSave
            // 
            this.mBtnSave.Location = new System.Drawing.Point(252, 212);
            this.mBtnSave.Name = "mBtnSave";
            this.mBtnSave.Size = new System.Drawing.Size(96, 29);
            this.mBtnSave.TabIndex = 12;
            this.mBtnSave.Text = "Mentés";
            this.mBtnSave.UseSelectable = true;
            this.mBtnSave.Visible = false;
            this.mBtnSave.Click += new System.EventHandler(this.mBtnSave_Click);
            // 
            // mBtnCancel
            // 
            this.mBtnCancel.Location = new System.Drawing.Point(252, 247);
            this.mBtnCancel.Name = "mBtnCancel";
            this.mBtnCancel.Size = new System.Drawing.Size(96, 29);
            this.mBtnCancel.TabIndex = 13;
            this.mBtnCancel.Text = "Mégse";
            this.mBtnCancel.UseSelectable = true;
            this.mBtnCancel.Visible = false;
            this.mBtnCancel.Click += new System.EventHandler(this.mBtnCancel_Click);
            // 
            // mLabelMainTitle
            // 
            this.mLabelMainTitle.AutoSize = true;
            this.mLabelMainTitle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mLabelMainTitle.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mLabelMainTitle.Location = new System.Drawing.Point(214, 28);
            this.mLabelMainTitle.Name = "mLabelMainTitle";
            this.mLabelMainTitle.Size = new System.Drawing.Size(175, 25);
            this.mLabelMainTitle.TabIndex = 10;
            this.mLabelMainTitle.Text = "Jogosultságkezelés";
            // 
            // errorProviderFail
            // 
            this.errorProviderFail.ContainerControl = this;
            // 
            // mCmbBxAccidLocal
            // 
            this.mCmbBxAccidLocal.Enabled = false;
            this.mCmbBxAccidLocal.FormattingEnabled = true;
            this.mCmbBxAccidLocal.ItemHeight = 23;
            this.mCmbBxAccidLocal.Items.AddRange(new object[] {
            "Elérés tiltása",
            "Olvasási jog",
            "Módosítási jog"});
            this.mCmbBxAccidLocal.Location = new System.Drawing.Point(231, 428);
            this.mCmbBxAccidLocal.Name = "mCmbBxAccidLocal";
            this.mCmbBxAccidLocal.Size = new System.Drawing.Size(143, 29);
            this.mCmbBxAccidLocal.TabIndex = 3;
            this.mCmbBxAccidLocal.UseSelectable = true;
            // 
            // mCmbBxUsersLocal
            // 
            this.mCmbBxUsersLocal.Enabled = false;
            this.mCmbBxUsersLocal.FormattingEnabled = true;
            this.mCmbBxUsersLocal.ItemHeight = 23;
            this.mCmbBxUsersLocal.Items.AddRange(new object[] {
            "Elérés tiltása",
            "Olvasási jog",
            "Módosítási jog"});
            this.mCmbBxUsersLocal.Location = new System.Drawing.Point(231, 374);
            this.mCmbBxUsersLocal.Name = "mCmbBxUsersLocal";
            this.mCmbBxUsersLocal.Size = new System.Drawing.Size(142, 29);
            this.mCmbBxUsersLocal.TabIndex = 2;
            this.mCmbBxUsersLocal.UseSelectable = true;
            // 
            // mCmbBxRequestLocal
            // 
            this.mCmbBxRequestLocal.Enabled = false;
            this.mCmbBxRequestLocal.FormattingEnabled = true;
            this.mCmbBxRequestLocal.ItemHeight = 23;
            this.mCmbBxRequestLocal.Items.AddRange(new object[] {
            "Elérés tiltása",
            "Olvasási jog",
            "Módosítási jog"});
            this.mCmbBxRequestLocal.Location = new System.Drawing.Point(231, 318);
            this.mCmbBxRequestLocal.Name = "mCmbBxRequestLocal";
            this.mCmbBxRequestLocal.Size = new System.Drawing.Size(142, 29);
            this.mCmbBxRequestLocal.TabIndex = 1;
            this.mCmbBxRequestLocal.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(231, 296);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(131, 19);
            this.metroLabel6.TabIndex = 12;
            this.metroLabel6.Text = "Csoport kéréskezelés";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(231, 406);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(142, 19);
            this.metroLabel10.TabIndex = 13;
            this.metroLabel10.Text = "Csoport balesetkezelés";
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(231, 352);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(165, 19);
            this.metroLabel11.TabIndex = 12;
            this.metroLabel11.Text = "Csoport felhasználókezelés";
            // 
            // FormServiceRightsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 485);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.mCmbBxRequestLocal);
            this.Controls.Add(this.mCmbBxUsersLocal);
            this.Controls.Add(this.mCmbBxAccidLocal);
            this.Controls.Add(this.mLabelMainTitle);
            this.Controls.Add(this.mBtnCancel);
            this.Controls.Add(this.mBtnSave);
            this.Controls.Add(this.mLblGroup);
            this.Controls.Add(this.mTxtBxGroupName);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.mCmbBxAllGroups);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.mCmbBxStore);
            this.Controls.Add(this.mCmbBxRights);
            this.Controls.Add(this.mCmbBxOrder);
            this.Controls.Add(this.mCmbBxUsers);
            this.Controls.Add(this.mCmbBxRequest);
            this.Controls.Add(this.mCmbBxAccidents);
            this.Controls.Add(this.mCmbBxSubcontr);
            this.Controls.Add(this.metroPanel1);
            this.Name = "FormServiceRightsWindow";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormServiceRightsWindow_FormClosed);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile mTileDelete;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox mCmbBxAllGroups;
        private MetroFramework.Controls.MetroTile mTileExit;
        private MetroFramework.Controls.MetroComboBox mCmbBxSubcontr;
        private MetroFramework.Controls.MetroComboBox mCmbBxRequest;
        private MetroFramework.Controls.MetroComboBox mCmbBxOrder;
        private MetroFramework.Controls.MetroComboBox mCmbBxStore;
        private MetroFramework.Controls.MetroComboBox mCmbBxAccidents;
        private MetroFramework.Controls.MetroComboBox mCmbBxUsers;
        private MetroFramework.Controls.MetroComboBox mCmbBxRights;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox mTxtBxGroupName;
        private MetroFramework.Controls.MetroLabel mLblGroup;
        private MetroFramework.Controls.MetroTile mTileNew;
        private MetroFramework.Controls.MetroTile mTileModify;
        private MetroFramework.Controls.MetroButton mBtnSave;
        private MetroFramework.Controls.MetroButton mBtnCancel;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel mLabelMainTitle;
        private System.Windows.Forms.ErrorProvider errorProviderFail;
        private MetroFramework.Controls.MetroComboBox mCmbBxUsersLocal;
        private MetroFramework.Controls.MetroComboBox mCmbBxAccidLocal;
        private MetroFramework.Controls.MetroComboBox mCmbBxRequestLocal;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel6;
    }
}