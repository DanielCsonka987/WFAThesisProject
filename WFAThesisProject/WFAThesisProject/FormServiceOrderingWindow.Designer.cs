namespace WFAThesisProject
{
    partial class FormServiceOrderingWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServiceOrderingWindow));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.mTileExit = new MetroFramework.Controls.MetroTile();
            this.mTileOk = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxOrderStart = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxOrderFinal = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxAmount = new MetroFramework.Controls.MetroTextBox();
            this.mCmbxStripping = new MetroFramework.Controls.MetroComboBox();
            this.mCmbxProduct = new MetroFramework.Controls.MetroComboBox();
            this.mTxtBxSubcontr = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.mLblInfoTitle = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.mLblFinalDate = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxProdCode = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxPlacing = new MetroFramework.Controls.MetroTextBox();
            this.mLblPlacing = new MetroFramework.Controls.MetroLabel();
            this.mLblProductInfo = new MetroFramework.Controls.MetroLabel();
            this.mChckBoxNewProdAdj = new MetroFramework.Controls.MetroCheckBox();
            this.mLblModifierArea = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxModifUser = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxUserStart = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxAmountArriv = new MetroFramework.Controls.MetroTextBox();
            this.mLblAmountArriv = new MetroFramework.Controls.MetroLabel();
            this.errorProviderDataMistake = new System.Windows.Forms.ErrorProvider(this.components);
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDataMistake)).BeginInit();
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
            this.metroPanel1.Controls.Add(this.mTileOk);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 5);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(200, 475);
            this.metroPanel1.TabIndex = 2;
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
            this.metroPanel2.TabIndex = 19;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
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
            this.metroLabel1.Size = new System.Drawing.Size(164, 25);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Rendéskeskezelés";
            // 
            // mTxtBxOrderStart
            // 
            // 
            // 
            // 
            this.mTxtBxOrderStart.CustomButton.Image = null;
            this.mTxtBxOrderStart.CustomButton.Location = new System.Drawing.Point(107, 1);
            this.mTxtBxOrderStart.CustomButton.Name = "";
            this.mTxtBxOrderStart.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxOrderStart.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxOrderStart.CustomButton.TabIndex = 1;
            this.mTxtBxOrderStart.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxOrderStart.CustomButton.UseSelectable = true;
            this.mTxtBxOrderStart.CustomButton.Visible = false;
            this.mTxtBxOrderStart.Lines = new string[0];
            this.mTxtBxOrderStart.Location = new System.Drawing.Point(215, 112);
            this.mTxtBxOrderStart.MaxLength = 32767;
            this.mTxtBxOrderStart.Name = "mTxtBxOrderStart";
            this.mTxtBxOrderStart.PasswordChar = '\0';
            this.mTxtBxOrderStart.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxOrderStart.SelectedText = "";
            this.mTxtBxOrderStart.SelectionLength = 0;
            this.mTxtBxOrderStart.SelectionStart = 0;
            this.mTxtBxOrderStart.ShortcutsEnabled = true;
            this.mTxtBxOrderStart.Size = new System.Drawing.Size(129, 23);
            this.mTxtBxOrderStart.TabIndex = 4;
            this.mTxtBxOrderStart.UseSelectable = true;
            this.mTxtBxOrderStart.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxOrderStart.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxOrderFinal
            // 
            // 
            // 
            // 
            this.mTxtBxOrderFinal.CustomButton.Image = null;
            this.mTxtBxOrderFinal.CustomButton.Location = new System.Drawing.Point(107, 1);
            this.mTxtBxOrderFinal.CustomButton.Name = "";
            this.mTxtBxOrderFinal.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxOrderFinal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxOrderFinal.CustomButton.TabIndex = 1;
            this.mTxtBxOrderFinal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxOrderFinal.CustomButton.UseSelectable = true;
            this.mTxtBxOrderFinal.CustomButton.Visible = false;
            this.mTxtBxOrderFinal.Lines = new string[0];
            this.mTxtBxOrderFinal.Location = new System.Drawing.Point(376, 112);
            this.mTxtBxOrderFinal.MaxLength = 32767;
            this.mTxtBxOrderFinal.Name = "mTxtBxOrderFinal";
            this.mTxtBxOrderFinal.PasswordChar = '\0';
            this.mTxtBxOrderFinal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxOrderFinal.SelectedText = "";
            this.mTxtBxOrderFinal.SelectionLength = 0;
            this.mTxtBxOrderFinal.SelectionStart = 0;
            this.mTxtBxOrderFinal.ShortcutsEnabled = true;
            this.mTxtBxOrderFinal.Size = new System.Drawing.Size(129, 23);
            this.mTxtBxOrderFinal.TabIndex = 4;
            this.mTxtBxOrderFinal.UseSelectable = true;
            this.mTxtBxOrderFinal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxOrderFinal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxAmount
            // 
            // 
            // 
            // 
            this.mTxtBxAmount.CustomButton.Image = null;
            this.mTxtBxAmount.CustomButton.Location = new System.Drawing.Point(98, 1);
            this.mTxtBxAmount.CustomButton.Name = "";
            this.mTxtBxAmount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxAmount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxAmount.CustomButton.TabIndex = 1;
            this.mTxtBxAmount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxAmount.CustomButton.UseSelectable = true;
            this.mTxtBxAmount.CustomButton.Visible = false;
            this.mTxtBxAmount.Lines = new string[0];
            this.mTxtBxAmount.Location = new System.Drawing.Point(215, 353);
            this.mTxtBxAmount.MaxLength = 32767;
            this.mTxtBxAmount.Name = "mTxtBxAmount";
            this.mTxtBxAmount.PasswordChar = '\0';
            this.mTxtBxAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxAmount.SelectedText = "";
            this.mTxtBxAmount.SelectionLength = 0;
            this.mTxtBxAmount.SelectionStart = 0;
            this.mTxtBxAmount.ShortcutsEnabled = true;
            this.mTxtBxAmount.Size = new System.Drawing.Size(120, 23);
            this.mTxtBxAmount.TabIndex = 4;
            this.mTxtBxAmount.UseSelectable = true;
            this.mTxtBxAmount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxAmount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mCmbxStripping
            // 
            this.mCmbxStripping.FormattingEnabled = true;
            this.mCmbxStripping.ItemHeight = 23;
            this.mCmbxStripping.Location = new System.Drawing.Point(214, 296);
            this.mCmbxStripping.Name = "mCmbxStripping";
            this.mCmbxStripping.Size = new System.Drawing.Size(121, 29);
            this.mCmbxStripping.TabIndex = 5;
            this.mCmbxStripping.UseSelectable = true;
            this.mCmbxStripping.SelectedIndexChanged += new System.EventHandler(this.mCmbxStripping_SelectedIndexChanged);
            // 
            // mCmbxProduct
            // 
            this.mCmbxProduct.FormattingEnabled = true;
            this.mCmbxProduct.ItemHeight = 23;
            this.mCmbxProduct.Location = new System.Drawing.Point(215, 241);
            this.mCmbxProduct.Name = "mCmbxProduct";
            this.mCmbxProduct.Size = new System.Drawing.Size(290, 29);
            this.mCmbxProduct.TabIndex = 6;
            this.mCmbxProduct.UseSelectable = true;
            this.mCmbxProduct.SelectedIndexChanged += new System.EventHandler(this.mCmbxProduct_SelectedIndexChanged);
            // 
            // mTxtBxSubcontr
            // 
            // 
            // 
            // 
            this.mTxtBxSubcontr.CustomButton.Image = null;
            this.mTxtBxSubcontr.CustomButton.Location = new System.Drawing.Point(107, 1);
            this.mTxtBxSubcontr.CustomButton.Name = "";
            this.mTxtBxSubcontr.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxSubcontr.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxSubcontr.CustomButton.TabIndex = 1;
            this.mTxtBxSubcontr.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxSubcontr.CustomButton.UseSelectable = true;
            this.mTxtBxSubcontr.CustomButton.Visible = false;
            this.mTxtBxSubcontr.Lines = new string[0];
            this.mTxtBxSubcontr.Location = new System.Drawing.Point(375, 296);
            this.mTxtBxSubcontr.MaxLength = 32767;
            this.mTxtBxSubcontr.Name = "mTxtBxSubcontr";
            this.mTxtBxSubcontr.PasswordChar = '\0';
            this.mTxtBxSubcontr.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxSubcontr.SelectedText = "";
            this.mTxtBxSubcontr.SelectionLength = 0;
            this.mTxtBxSubcontr.SelectionStart = 0;
            this.mTxtBxSubcontr.ShortcutsEnabled = true;
            this.mTxtBxSubcontr.Size = new System.Drawing.Size(129, 23);
            this.mTxtBxSubcontr.TabIndex = 7;
            this.mTxtBxSubcontr.UseSelectable = true;
            this.mTxtBxSubcontr.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxSubcontr.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(215, 328);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(74, 19);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "Mennyiség:";
            // 
            // mLblInfoTitle
            // 
            this.mLblInfoTitle.AutoSize = true;
            this.mLblInfoTitle.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.mLblInfoTitle.Location = new System.Drawing.Point(214, 54);
            this.mLblInfoTitle.Name = "mLblInfoTitle";
            this.mLblInfoTitle.Size = new System.Drawing.Size(86, 19);
            this.mLblInfoTitle.TabIndex = 11;
            this.mLblInfoTitle.Text = "metroLabel2";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(215, 87);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(129, 19);
            this.metroLabel4.TabIndex = 12;
            this.metroLabel4.Text = "Rendelés bejegyzése";
            // 
            // mLblFinalDate
            // 
            this.mLblFinalDate.AutoSize = true;
            this.mLblFinalDate.Location = new System.Drawing.Point(376, 87);
            this.mLblFinalDate.Name = "mLblFinalDate";
            this.mLblFinalDate.Size = new System.Drawing.Size(61, 19);
            this.mLblFinalDate.TabIndex = 13;
            this.mLblFinalDate.Text = "Rendelés";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(215, 216);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 19);
            this.metroLabel3.TabIndex = 14;
            this.metroLabel3.Text = "Termék:";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(217, 274);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(67, 19);
            this.metroLabel5.TabIndex = 15;
            this.metroLabel5.Text = "Kiszerelés:";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(375, 274);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(66, 19);
            this.metroLabel6.TabIndex = 16;
            this.metroLabel6.Text = "Beszállító:";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(375, 328);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(78, 19);
            this.metroLabel7.TabIndex = 18;
            this.metroLabel7.Text = "Termékkód:";
            // 
            // mTxtBxProdCode
            // 
            // 
            // 
            // 
            this.mTxtBxProdCode.CustomButton.Image = null;
            this.mTxtBxProdCode.CustomButton.Location = new System.Drawing.Point(107, 1);
            this.mTxtBxProdCode.CustomButton.Name = "";
            this.mTxtBxProdCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxProdCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxProdCode.CustomButton.TabIndex = 1;
            this.mTxtBxProdCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxProdCode.CustomButton.UseSelectable = true;
            this.mTxtBxProdCode.CustomButton.Visible = false;
            this.mTxtBxProdCode.Lines = new string[0];
            this.mTxtBxProdCode.Location = new System.Drawing.Point(375, 353);
            this.mTxtBxProdCode.MaxLength = 32767;
            this.mTxtBxProdCode.Name = "mTxtBxProdCode";
            this.mTxtBxProdCode.PasswordChar = '\0';
            this.mTxtBxProdCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxProdCode.SelectedText = "";
            this.mTxtBxProdCode.SelectionLength = 0;
            this.mTxtBxProdCode.SelectionStart = 0;
            this.mTxtBxProdCode.ShortcutsEnabled = true;
            this.mTxtBxProdCode.Size = new System.Drawing.Size(129, 23);
            this.mTxtBxProdCode.TabIndex = 17;
            this.mTxtBxProdCode.UseSelectable = true;
            this.mTxtBxProdCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxProdCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxPlacing
            // 
            // 
            // 
            // 
            this.mTxtBxPlacing.CustomButton.Image = null;
            this.mTxtBxPlacing.CustomButton.Location = new System.Drawing.Point(108, 1);
            this.mTxtBxPlacing.CustomButton.Name = "";
            this.mTxtBxPlacing.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxPlacing.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxPlacing.CustomButton.TabIndex = 1;
            this.mTxtBxPlacing.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxPlacing.CustomButton.UseSelectable = true;
            this.mTxtBxPlacing.CustomButton.Visible = false;
            this.mTxtBxPlacing.Lines = new string[0];
            this.mTxtBxPlacing.Location = new System.Drawing.Point(375, 401);
            this.mTxtBxPlacing.MaxLength = 32767;
            this.mTxtBxPlacing.Name = "mTxtBxPlacing";
            this.mTxtBxPlacing.PasswordChar = '\0';
            this.mTxtBxPlacing.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxPlacing.SelectedText = "";
            this.mTxtBxPlacing.SelectionLength = 0;
            this.mTxtBxPlacing.SelectionStart = 0;
            this.mTxtBxPlacing.ShortcutsEnabled = true;
            this.mTxtBxPlacing.Size = new System.Drawing.Size(130, 23);
            this.mTxtBxPlacing.TabIndex = 19;
            this.mTxtBxPlacing.UseSelectable = true;
            this.mTxtBxPlacing.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxPlacing.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mLblPlacing
            // 
            this.mLblPlacing.AutoSize = true;
            this.mLblPlacing.Location = new System.Drawing.Point(376, 379);
            this.mLblPlacing.Name = "mLblPlacing";
            this.mLblPlacing.Size = new System.Drawing.Size(86, 19);
            this.mLblPlacing.TabIndex = 20;
            this.mLblPlacing.Text = "Raktári helye:";
            // 
            // mLblProductInfo
            // 
            this.mLblProductInfo.AutoSize = true;
            this.mLblProductInfo.Location = new System.Drawing.Point(215, 197);
            this.mLblProductInfo.Name = "mLblProductInfo";
            this.mLblProductInfo.Size = new System.Drawing.Size(83, 19);
            this.mLblProductInfo.TabIndex = 21;
            this.mLblProductInfo.Text = "metroLabel9";
            this.mLblProductInfo.Visible = false;
            // 
            // mChckBoxNewProdAdj
            // 
            this.mChckBoxNewProdAdj.AutoSize = true;
            this.mChckBoxNewProdAdj.Location = new System.Drawing.Point(215, 430);
            this.mChckBoxNewProdAdj.Name = "mChckBoxNewProdAdj";
            this.mChckBoxNewProdAdj.Size = new System.Drawing.Size(126, 15);
            this.mChckBoxNewProdAdj.TabIndex = 22;
            this.mChckBoxNewProdAdj.Text = "Új termék beállítása";
            this.mChckBoxNewProdAdj.UseSelectable = true;
            this.mChckBoxNewProdAdj.Visible = false;
            this.mChckBoxNewProdAdj.CheckedChanged += new System.EventHandler(this.mChckBoxNewProdAdj_CheckedChanged);
            // 
            // mLblModifierArea
            // 
            this.mLblModifierArea.AutoSize = true;
            this.mLblModifierArea.Location = new System.Drawing.Point(376, 146);
            this.mLblModifierArea.Name = "mLblModifierArea";
            this.mLblModifierArea.Size = new System.Drawing.Size(133, 19);
            this.mLblModifierArea.TabIndex = 26;
            this.mLblModifierArea.Text = "Utoljára módosította:";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(215, 146);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(108, 19);
            this.metroLabel10.TabIndex = 25;
            this.metroLabel10.Text = "Rendelést leadta:";
            // 
            // mTxtBxModifUser
            // 
            // 
            // 
            // 
            this.mTxtBxModifUser.CustomButton.Image = null;
            this.mTxtBxModifUser.CustomButton.Location = new System.Drawing.Point(107, 1);
            this.mTxtBxModifUser.CustomButton.Name = "";
            this.mTxtBxModifUser.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxModifUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxModifUser.CustomButton.TabIndex = 1;
            this.mTxtBxModifUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxModifUser.CustomButton.UseSelectable = true;
            this.mTxtBxModifUser.CustomButton.Visible = false;
            this.mTxtBxModifUser.Lines = new string[0];
            this.mTxtBxModifUser.Location = new System.Drawing.Point(376, 171);
            this.mTxtBxModifUser.MaxLength = 32767;
            this.mTxtBxModifUser.Name = "mTxtBxModifUser";
            this.mTxtBxModifUser.PasswordChar = '\0';
            this.mTxtBxModifUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxModifUser.SelectedText = "";
            this.mTxtBxModifUser.SelectionLength = 0;
            this.mTxtBxModifUser.SelectionStart = 0;
            this.mTxtBxModifUser.ShortcutsEnabled = true;
            this.mTxtBxModifUser.Size = new System.Drawing.Size(129, 23);
            this.mTxtBxModifUser.TabIndex = 23;
            this.mTxtBxModifUser.UseSelectable = true;
            this.mTxtBxModifUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxModifUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxUserStart
            // 
            // 
            // 
            // 
            this.mTxtBxUserStart.CustomButton.Image = null;
            this.mTxtBxUserStart.CustomButton.Location = new System.Drawing.Point(107, 1);
            this.mTxtBxUserStart.CustomButton.Name = "";
            this.mTxtBxUserStart.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxUserStart.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxUserStart.CustomButton.TabIndex = 1;
            this.mTxtBxUserStart.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxUserStart.CustomButton.UseSelectable = true;
            this.mTxtBxUserStart.CustomButton.Visible = false;
            this.mTxtBxUserStart.Lines = new string[0];
            this.mTxtBxUserStart.Location = new System.Drawing.Point(215, 171);
            this.mTxtBxUserStart.MaxLength = 32767;
            this.mTxtBxUserStart.Name = "mTxtBxUserStart";
            this.mTxtBxUserStart.PasswordChar = '\0';
            this.mTxtBxUserStart.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxUserStart.SelectedText = "";
            this.mTxtBxUserStart.SelectionLength = 0;
            this.mTxtBxUserStart.SelectionStart = 0;
            this.mTxtBxUserStart.ShortcutsEnabled = true;
            this.mTxtBxUserStart.Size = new System.Drawing.Size(129, 23);
            this.mTxtBxUserStart.TabIndex = 24;
            this.mTxtBxUserStart.UseSelectable = true;
            this.mTxtBxUserStart.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxUserStart.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxAmountArriv
            // 
            // 
            // 
            // 
            this.mTxtBxAmountArriv.CustomButton.Image = null;
            this.mTxtBxAmountArriv.CustomButton.Location = new System.Drawing.Point(98, 1);
            this.mTxtBxAmountArriv.CustomButton.Name = "";
            this.mTxtBxAmountArriv.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxAmountArriv.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxAmountArriv.CustomButton.TabIndex = 1;
            this.mTxtBxAmountArriv.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxAmountArriv.CustomButton.UseSelectable = true;
            this.mTxtBxAmountArriv.CustomButton.Visible = false;
            this.mTxtBxAmountArriv.Lines = new string[0];
            this.mTxtBxAmountArriv.Location = new System.Drawing.Point(215, 401);
            this.mTxtBxAmountArriv.MaxLength = 32767;
            this.mTxtBxAmountArriv.Name = "mTxtBxAmountArriv";
            this.mTxtBxAmountArriv.PasswordChar = '\0';
            this.mTxtBxAmountArriv.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxAmountArriv.SelectedText = "";
            this.mTxtBxAmountArriv.SelectionLength = 0;
            this.mTxtBxAmountArriv.SelectionStart = 0;
            this.mTxtBxAmountArriv.ShortcutsEnabled = true;
            this.mTxtBxAmountArriv.Size = new System.Drawing.Size(120, 23);
            this.mTxtBxAmountArriv.TabIndex = 27;
            this.mTxtBxAmountArriv.UseSelectable = true;
            this.mTxtBxAmountArriv.Visible = false;
            this.mTxtBxAmountArriv.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxAmountArriv.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mLblAmountArriv
            // 
            this.mLblAmountArriv.AutoSize = true;
            this.mLblAmountArriv.Location = new System.Drawing.Point(215, 379);
            this.mLblAmountArriv.Name = "mLblAmountArriv";
            this.mLblAmountArriv.Size = new System.Drawing.Size(124, 19);
            this.mLblAmountArriv.TabIndex = 28;
            this.mLblAmountArriv.Text = "Érkezett mennyiség:";
            this.mLblAmountArriv.Visible = false;
            // 
            // errorProviderDataMistake
            // 
            this.errorProviderDataMistake.ContainerControl = this;
            // 
            // FormServiceOrderingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 464);
            this.Controls.Add(this.mLblAmountArriv);
            this.Controls.Add(this.mTxtBxAmountArriv);
            this.Controls.Add(this.mLblModifierArea);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.mTxtBxModifUser);
            this.Controls.Add(this.mTxtBxUserStart);
            this.Controls.Add(this.mChckBoxNewProdAdj);
            this.Controls.Add(this.mLblProductInfo);
            this.Controls.Add(this.mLblPlacing);
            this.Controls.Add(this.mTxtBxPlacing);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.mTxtBxProdCode);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.mLblFinalDate);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.mLblInfoTitle);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.mTxtBxSubcontr);
            this.Controls.Add(this.mCmbxProduct);
            this.Controls.Add(this.mCmbxStripping);
            this.Controls.Add(this.mTxtBxAmount);
            this.Controls.Add(this.mTxtBxOrderFinal);
            this.Controls.Add(this.mTxtBxOrderStart);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroPanel1);
            this.Name = "FormServiceOrderingWindow";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormServiceOrderingWindow_FormClosed);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDataMistake)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile mTileExit;
        private MetroFramework.Controls.MetroTile mTileOk;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox mTxtBxOrderStart;
        private MetroFramework.Controls.MetroTextBox mTxtBxOrderFinal;
        private MetroFramework.Controls.MetroTextBox mTxtBxAmount;
        private MetroFramework.Controls.MetroComboBox mCmbxStripping;
        private MetroFramework.Controls.MetroComboBox mCmbxProduct;
        private MetroFramework.Controls.MetroTextBox mTxtBxSubcontr;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel mLblInfoTitle;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel mLblFinalDate;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox mTxtBxProdCode;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroTextBox mTxtBxPlacing;
        private MetroFramework.Controls.MetroLabel mLblPlacing;
        private MetroFramework.Controls.MetroLabel mLblProductInfo;
        private MetroFramework.Controls.MetroCheckBox mChckBoxNewProdAdj;
        private MetroFramework.Controls.MetroLabel mLblModifierArea;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox mTxtBxModifUser;
        private MetroFramework.Controls.MetroTextBox mTxtBxUserStart;
        private MetroFramework.Controls.MetroTextBox mTxtBxAmountArriv;
        private MetroFramework.Controls.MetroLabel mLblAmountArriv;
        private System.Windows.Forms.ErrorProvider errorProviderDataMistake;
    }
}