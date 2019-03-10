namespace WFAThesisProject
{
    partial class FormServiceRequestsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServiceRequestsWindow));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.mTileExit = new MetroFramework.Controls.MetroTile();
            this.mTileOk = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.mCbBxProducts = new MetroFramework.Controls.MetroComboBox();
            this.mCbBxStrippings = new MetroFramework.Controls.MetroComboBox();
            this.mTxtBxAmount = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxStartDate = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxEndDate = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxReqName = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxReqArea = new MetroFramework.Controls.MetroTextBox();
            this.mLblInfoTitle = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.mTxtBxPlaceCode = new MetroFramework.Controls.MetroTextBox();
            this.mLabelPlacing = new MetroFramework.Controls.MetroLabel();
            this.errorProviderFail = new System.Windows.Forms.ErrorProvider(this.components);
            this.mLabelOfProductCmb = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxBeszall = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.mChckBxModifyDiffProd = new MetroFramework.Controls.MetroCheckBox();
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
            this.metroPanel1.Controls.Add(this.mTileOk);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 11);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(200, 461);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // mTileExit
            // 
            this.mTileExit.ActiveControl = null;
            this.mTileExit.Location = new System.Drawing.Point(23, 349);
            this.mTileExit.Name = "mTileExit";
            this.mTileExit.Size = new System.Drawing.Size(150, 40);
            this.mTileExit.Style = MetroFramework.MetroColorStyle.Silver;
            this.mTileExit.TabIndex = 2;
            this.mTileExit.Text = "Vissza";
            this.mTileExit.UseSelectable = true;
            this.mTileExit.Click += new System.EventHandler(this.mTileExit_Click);
            // 
            // mTileOk
            // 
            this.mTileOk.ActiveControl = null;
            this.mTileOk.Location = new System.Drawing.Point(23, 303);
            this.mTileOk.Name = "mTileOk";
            this.mTileOk.Size = new System.Drawing.Size(150, 40);
            this.mTileOk.Style = MetroFramework.MetroColorStyle.Red;
            this.mTileOk.TabIndex = 2;
            this.mTileOk.Text = "Végrehajtás";
            this.mTileOk.UseSelectable = true;
            this.mTileOk.Click += new System.EventHandler(this.mTileOk_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(214, 28);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(121, 25);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Kéréskezelés";
            // 
            // mCbBxProducts
            // 
            this.mCbBxProducts.FormattingEnabled = true;
            this.mCbBxProducts.ItemHeight = 23;
            this.mCbBxProducts.Location = new System.Drawing.Point(217, 243);
            this.mCbBxProducts.Name = "mCbBxProducts";
            this.mCbBxProducts.Size = new System.Drawing.Size(288, 29);
            this.mCbBxProducts.TabIndex = 3;
            this.mCbBxProducts.UseSelectable = true;
            this.mCbBxProducts.SelectedIndexChanged += new System.EventHandler(this.mCbBxProducts_SelectedIndexChanged);
            // 
            // mCbBxStrippings
            // 
            this.mCbBxStrippings.FormattingEnabled = true;
            this.mCbBxStrippings.ItemHeight = 23;
            this.mCbBxStrippings.Location = new System.Drawing.Point(214, 331);
            this.mCbBxStrippings.Name = "mCbBxStrippings";
            this.mCbBxStrippings.Size = new System.Drawing.Size(158, 29);
            this.mCbBxStrippings.TabIndex = 4;
            this.mCbBxStrippings.UseSelectable = true;
            this.mCbBxStrippings.SelectedIndexChanged += new System.EventHandler(this.mCbBxStrippings_SelectedIndexChanged);
            // 
            // mTxtBxAmount
            // 
            // 
            // 
            // 
            this.mTxtBxAmount.CustomButton.Image = null;
            this.mTxtBxAmount.CustomButton.Location = new System.Drawing.Point(83, 1);
            this.mTxtBxAmount.CustomButton.Name = "";
            this.mTxtBxAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxAmount.CustomButton.TabIndex = 1;
            this.mTxtBxAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxAmount.CustomButton.UseSelectable = true;
            this.mTxtBxAmount.CustomButton.Visible = false;
            this.mTxtBxAmount.Lines = new string[0];
            this.mTxtBxAmount.Location = new System.Drawing.Point(400, 385);
            this.mTxtBxAmount.MaxLength = 32767;
            this.mTxtBxAmount.Name = "mTxtBxAmount";
            this.mTxtBxAmount.PasswordChar = '\0';
            this.mTxtBxAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxAmount.SelectedText = "";
            this.mTxtBxAmount.SelectionLength = 0;
            this.mTxtBxAmount.SelectionStart = 0;
            this.mTxtBxAmount.ShortcutsEnabled = true;
            this.mTxtBxAmount.Size = new System.Drawing.Size(105, 23);
            this.mTxtBxAmount.TabIndex = 5;
            this.mTxtBxAmount.UseSelectable = true;
            this.mTxtBxAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxStartDate
            // 
            // 
            // 
            // 
            this.mTxtBxStartDate.CustomButton.Image = null;
            this.mTxtBxStartDate.CustomButton.Location = new System.Drawing.Point(83, 1);
            this.mTxtBxStartDate.CustomButton.Name = "";
            this.mTxtBxStartDate.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxStartDate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxStartDate.CustomButton.TabIndex = 1;
            this.mTxtBxStartDate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxStartDate.CustomButton.UseSelectable = true;
            this.mTxtBxStartDate.CustomButton.Visible = false;
            this.mTxtBxStartDate.Lines = new string[0];
            this.mTxtBxStartDate.Location = new System.Drawing.Point(400, 125);
            this.mTxtBxStartDate.MaxLength = 32767;
            this.mTxtBxStartDate.Name = "mTxtBxStartDate";
            this.mTxtBxStartDate.PasswordChar = '\0';
            this.mTxtBxStartDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxStartDate.SelectedText = "";
            this.mTxtBxStartDate.SelectionLength = 0;
            this.mTxtBxStartDate.SelectionStart = 0;
            this.mTxtBxStartDate.ShortcutsEnabled = true;
            this.mTxtBxStartDate.Size = new System.Drawing.Size(105, 23);
            this.mTxtBxStartDate.TabIndex = 6;
            this.mTxtBxStartDate.UseSelectable = true;
            this.mTxtBxStartDate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxStartDate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxEndDate
            // 
            // 
            // 
            // 
            this.mTxtBxEndDate.CustomButton.Image = null;
            this.mTxtBxEndDate.CustomButton.Location = new System.Drawing.Point(83, 1);
            this.mTxtBxEndDate.CustomButton.Name = "";
            this.mTxtBxEndDate.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxEndDate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxEndDate.CustomButton.TabIndex = 1;
            this.mTxtBxEndDate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxEndDate.CustomButton.UseSelectable = true;
            this.mTxtBxEndDate.CustomButton.Visible = false;
            this.mTxtBxEndDate.Lines = new string[0];
            this.mTxtBxEndDate.Location = new System.Drawing.Point(400, 173);
            this.mTxtBxEndDate.MaxLength = 32767;
            this.mTxtBxEndDate.Name = "mTxtBxEndDate";
            this.mTxtBxEndDate.PasswordChar = '\0';
            this.mTxtBxEndDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxEndDate.SelectedText = "";
            this.mTxtBxEndDate.SelectionLength = 0;
            this.mTxtBxEndDate.SelectionStart = 0;
            this.mTxtBxEndDate.ShortcutsEnabled = true;
            this.mTxtBxEndDate.Size = new System.Drawing.Size(105, 23);
            this.mTxtBxEndDate.TabIndex = 7;
            this.mTxtBxEndDate.UseSelectable = true;
            this.mTxtBxEndDate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxEndDate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxReqName
            // 
            // 
            // 
            // 
            this.mTxtBxReqName.CustomButton.Image = null;
            this.mTxtBxReqName.CustomButton.Location = new System.Drawing.Point(135, 1);
            this.mTxtBxReqName.CustomButton.Name = "";
            this.mTxtBxReqName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxReqName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxReqName.CustomButton.TabIndex = 1;
            this.mTxtBxReqName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxReqName.CustomButton.UseSelectable = true;
            this.mTxtBxReqName.CustomButton.Visible = false;
            this.mTxtBxReqName.Lines = new string[0];
            this.mTxtBxReqName.Location = new System.Drawing.Point(216, 125);
            this.mTxtBxReqName.MaxLength = 32767;
            this.mTxtBxReqName.Name = "mTxtBxReqName";
            this.mTxtBxReqName.PasswordChar = '\0';
            this.mTxtBxReqName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxReqName.SelectedText = "";
            this.mTxtBxReqName.SelectionLength = 0;
            this.mTxtBxReqName.SelectionStart = 0;
            this.mTxtBxReqName.ShortcutsEnabled = true;
            this.mTxtBxReqName.Size = new System.Drawing.Size(157, 23);
            this.mTxtBxReqName.TabIndex = 8;
            this.mTxtBxReqName.UseSelectable = true;
            this.mTxtBxReqName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxReqName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxReqArea
            // 
            // 
            // 
            // 
            this.mTxtBxReqArea.CustomButton.Image = null;
            this.mTxtBxReqArea.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.mTxtBxReqArea.CustomButton.Name = "";
            this.mTxtBxReqArea.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxReqArea.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxReqArea.CustomButton.TabIndex = 1;
            this.mTxtBxReqArea.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxReqArea.CustomButton.UseSelectable = true;
            this.mTxtBxReqArea.CustomButton.Visible = false;
            this.mTxtBxReqArea.Lines = new string[0];
            this.mTxtBxReqArea.Location = new System.Drawing.Point(217, 173);
            this.mTxtBxReqArea.MaxLength = 32767;
            this.mTxtBxReqArea.Name = "mTxtBxReqArea";
            this.mTxtBxReqArea.PasswordChar = '\0';
            this.mTxtBxReqArea.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxReqArea.SelectedText = "";
            this.mTxtBxReqArea.SelectionLength = 0;
            this.mTxtBxReqArea.SelectionStart = 0;
            this.mTxtBxReqArea.ShortcutsEnabled = true;
            this.mTxtBxReqArea.Size = new System.Drawing.Size(156, 23);
            this.mTxtBxReqArea.TabIndex = 9;
            this.mTxtBxReqArea.UseSelectable = true;
            this.mTxtBxReqArea.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxReqArea.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mLblInfoTitle
            // 
            this.mLblInfoTitle.AutoSize = true;
            this.mLblInfoTitle.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.mLblInfoTitle.Location = new System.Drawing.Point(214, 54);
            this.mLblInfoTitle.Name = "mLblInfoTitle";
            this.mLblInfoTitle.Size = new System.Drawing.Size(86, 19);
            this.mLblInfoTitle.TabIndex = 10;
            this.mLblInfoTitle.Text = "metroLabel2";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(216, 103);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(105, 19);
            this.metroLabel2.TabIndex = 11;
            this.metroLabel2.Text = "Kérelmező neve:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(215, 151);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(122, 19);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Kérelmező területe:";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(217, 221);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(56, 19);
            this.metroLabel9.TabIndex = 13;
            this.metroLabel9.Text = "Termék:";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(214, 306);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(67, 19);
            this.metroLabel5.TabIndex = 14;
            this.metroLabel5.Text = "Kiszerelés:";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(398, 360);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(74, 19);
            this.metroLabel6.TabIndex = 15;
            this.metroLabel6.Text = "Mennyiség:";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(400, 103);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(92, 19);
            this.metroLabel7.TabIndex = 16;
            this.metroLabel7.Text = "Kérés dátuma:";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(400, 151);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(63, 19);
            this.metroLabel8.TabIndex = 17;
            this.metroLabel8.Text = "Teljesítés:";
            // 
            // metroPanel2
            // 
            this.metroPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroPanel2.BackgroundImage")));
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 5);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(200, 100);
            this.metroPanel2.TabIndex = 18;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // mTxtBxPlaceCode
            // 
            // 
            // 
            // 
            this.mTxtBxPlaceCode.CustomButton.Image = null;
            this.mTxtBxPlaceCode.CustomButton.Location = new System.Drawing.Point(136, 1);
            this.mTxtBxPlaceCode.CustomButton.Name = "";
            this.mTxtBxPlaceCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxPlaceCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxPlaceCode.CustomButton.TabIndex = 1;
            this.mTxtBxPlaceCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxPlaceCode.CustomButton.UseSelectable = true;
            this.mTxtBxPlaceCode.CustomButton.Visible = false;
            this.mTxtBxPlaceCode.Lines = new string[0];
            this.mTxtBxPlaceCode.Location = new System.Drawing.Point(214, 385);
            this.mTxtBxPlaceCode.MaxLength = 32767;
            this.mTxtBxPlaceCode.Name = "mTxtBxPlaceCode";
            this.mTxtBxPlaceCode.PasswordChar = '\0';
            this.mTxtBxPlaceCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxPlaceCode.SelectedText = "";
            this.mTxtBxPlaceCode.SelectionLength = 0;
            this.mTxtBxPlaceCode.SelectionStart = 0;
            this.mTxtBxPlaceCode.ShortcutsEnabled = true;
            this.mTxtBxPlaceCode.Size = new System.Drawing.Size(158, 23);
            this.mTxtBxPlaceCode.TabIndex = 19;
            this.mTxtBxPlaceCode.UseSelectable = true;
            this.mTxtBxPlaceCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxPlaceCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mLabelPlacing
            // 
            this.mLabelPlacing.AutoSize = true;
            this.mLabelPlacing.Location = new System.Drawing.Point(214, 363);
            this.mLabelPlacing.Name = "mLabelPlacing";
            this.mLabelPlacing.Size = new System.Drawing.Size(77, 19);
            this.mLabelPlacing.TabIndex = 20;
            this.mLabelPlacing.Text = "Elhelyezése:";
            // 
            // errorProviderFail
            // 
            this.errorProviderFail.ContainerControl = this;
            // 
            // mLabelOfProductCmb
            // 
            this.mLabelOfProductCmb.AutoSize = true;
            this.mLabelOfProductCmb.Location = new System.Drawing.Point(217, 199);
            this.mLabelOfProductCmb.Name = "mLabelOfProductCmb";
            this.mLabelOfProductCmb.Size = new System.Drawing.Size(0, 0);
            this.mLabelOfProductCmb.TabIndex = 21;
            // 
            // mTxtBxBeszall
            // 
            // 
            // 
            // 
            this.mTxtBxBeszall.CustomButton.Image = null;
            this.mTxtBxBeszall.CustomButton.Location = new System.Drawing.Point(83, 1);
            this.mTxtBxBeszall.CustomButton.Name = "";
            this.mTxtBxBeszall.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxBeszall.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxBeszall.CustomButton.TabIndex = 1;
            this.mTxtBxBeszall.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxBeszall.CustomButton.UseSelectable = true;
            this.mTxtBxBeszall.CustomButton.Visible = false;
            this.mTxtBxBeszall.Lines = new string[0];
            this.mTxtBxBeszall.Location = new System.Drawing.Point(400, 331);
            this.mTxtBxBeszall.MaxLength = 32767;
            this.mTxtBxBeszall.Name = "mTxtBxBeszall";
            this.mTxtBxBeszall.PasswordChar = '\0';
            this.mTxtBxBeszall.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxBeszall.SelectedText = "";
            this.mTxtBxBeszall.SelectionLength = 0;
            this.mTxtBxBeszall.SelectionStart = 0;
            this.mTxtBxBeszall.ShortcutsEnabled = true;
            this.mTxtBxBeszall.Size = new System.Drawing.Size(105, 23);
            this.mTxtBxBeszall.TabIndex = 22;
            this.mTxtBxBeszall.UseSelectable = true;
            this.mTxtBxBeszall.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxBeszall.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(400, 308);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(66, 19);
            this.metroLabel4.TabIndex = 23;
            this.metroLabel4.Text = "Beszállító:";
            // 
            // mChckBxModifyDiffProd
            // 
            this.mChckBxModifyDiffProd.AutoSize = true;
            this.mChckBxModifyDiffProd.Location = new System.Drawing.Point(214, 418);
            this.mChckBxModifyDiffProd.Name = "mChckBxModifyDiffProd";
            this.mChckBxModifyDiffProd.Size = new System.Drawing.Size(174, 15);
            this.mChckBxModifyDiffProd.TabIndex = 24;
            this.mChckBxModifyDiffProd.Text = "Új termék beállítások lesznek";
            this.mChckBxModifyDiffProd.UseSelectable = true;
            this.mChckBxModifyDiffProd.Visible = false;
            this.mChckBxModifyDiffProd.CheckedChanged += new System.EventHandler(this.mChckBxModifyWithDiffProd_CheckedChanged);
            // 
            // FormServiceRequestsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 456);
            this.Controls.Add(this.mChckBxModifyDiffProd);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.mTxtBxBeszall);
            this.Controls.Add(this.mLabelOfProductCmb);
            this.Controls.Add(this.mLabelPlacing);
            this.Controls.Add(this.mTxtBxPlaceCode);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.mLblInfoTitle);
            this.Controls.Add(this.mTxtBxReqArea);
            this.Controls.Add(this.mTxtBxReqName);
            this.Controls.Add(this.mTxtBxEndDate);
            this.Controls.Add(this.mTxtBxStartDate);
            this.Controls.Add(this.mTxtBxAmount);
            this.Controls.Add(this.mCbBxStrippings);
            this.Controls.Add(this.mCbBxProducts);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroPanel1);
            this.Name = "FormServiceRequestsWindow";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormServiceRequestsWindow_FormClosed);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile mTileExit;
        private MetroFramework.Controls.MetroTile mTileOk;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox mCbBxProducts;
        private MetroFramework.Controls.MetroComboBox mCbBxStrippings;
        private MetroFramework.Controls.MetroTextBox mTxtBxAmount;
        private MetroFramework.Controls.MetroTextBox mTxtBxStartDate;
        private MetroFramework.Controls.MetroTextBox mTxtBxEndDate;
        private MetroFramework.Controls.MetroTextBox mTxtBxReqName;
        private MetroFramework.Controls.MetroTextBox mTxtBxReqArea;
        private MetroFramework.Controls.MetroLabel mLblInfoTitle;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroTextBox mTxtBxPlaceCode;
        private MetroFramework.Controls.MetroLabel mLabelPlacing;
        private System.Windows.Forms.ErrorProvider errorProviderFail;
        private MetroFramework.Controls.MetroLabel mLabelOfProductCmb;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox mTxtBxBeszall;
        private MetroFramework.Controls.MetroCheckBox mChckBxModifyDiffProd;
    }
}