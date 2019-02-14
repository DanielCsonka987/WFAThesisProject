namespace WFAThesisProject
{
    partial class FormServiceProductsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServiceProductsWindow));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.mTileOk = new MetroFramework.Controls.MetroTile();
            this.mTileCancel = new MetroFramework.Controls.MetroTile();
            this.mLabelMainTitle = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxName = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxDescr = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxSheet = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxQuantUnit = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxQuantity = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.mLabelQuality = new MetroFramework.Controls.MetroLabel();
            this.mLabelStrip = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.mCmbBxSubcontr = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxDanger = new MetroFramework.Controls.MetroTextBox();
            this.mLabelStripping = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxPlaceing = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.mLabelInfos = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxBarcode = new MetroFramework.Controls.MetroTextBox();
            this.errorProvDataProb = new System.Windows.Forms.ErrorProvider(this.components);
            this.mTxtBxStripping = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvDataProb)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroPanel1.BackgroundImage")));
            this.metroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroPanel1.Controls.Add(this.metroPanel2);
            this.metroPanel1.Controls.Add(this.mTileOk);
            this.metroPanel1.Controls.Add(this.mTileCancel);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 5);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(200, 492);
            this.metroPanel1.TabIndex = 7;
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
            this.metroPanel2.TabIndex = 4;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // mTileOk
            // 
            this.mTileOk.ActiveControl = null;
            this.mTileOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.mTileOk.Location = new System.Drawing.Point(23, 320);
            this.mTileOk.Name = "mTileOk";
            this.mTileOk.Size = new System.Drawing.Size(150, 40);
            this.mTileOk.Style = MetroFramework.MetroColorStyle.Red;
            this.mTileOk.TabIndex = 11;
            this.mTileOk.Text = "Mentés";
            this.mTileOk.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.mTileOk.UseSelectable = true;
            this.mTileOk.Click += new System.EventHandler(this.mTileOk_Click);
            // 
            // mTileCancel
            // 
            this.mTileCancel.ActiveControl = null;
            this.mTileCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mTileCancel.Location = new System.Drawing.Point(23, 380);
            this.mTileCancel.Name = "mTileCancel";
            this.mTileCancel.Size = new System.Drawing.Size(150, 40);
            this.mTileCancel.Style = MetroFramework.MetroColorStyle.Silver;
            this.mTileCancel.TabIndex = 12;
            this.mTileCancel.Text = "Bezárás";
            this.mTileCancel.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.mTileCancel.UseSelectable = true;
            this.mTileCancel.Click += new System.EventHandler(this.mTileCancel_Click);
            // 
            // mLabelMainTitle
            // 
            this.mLabelMainTitle.AutoSize = true;
            this.mLabelMainTitle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mLabelMainTitle.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mLabelMainTitle.Location = new System.Drawing.Point(214, 28);
            this.mLabelMainTitle.Name = "mLabelMainTitle";
            this.mLabelMainTitle.Size = new System.Drawing.Size(130, 25);
            this.mLabelMainTitle.TabIndex = 5;
            this.mLabelMainTitle.Text = "Raktárkezelés";
            // 
            // mTxtBxName
            // 
            // 
            // 
            // 
            this.mTxtBxName.CustomButton.Image = null;
            this.mTxtBxName.CustomButton.Location = new System.Drawing.Point(183, 1);
            this.mTxtBxName.CustomButton.Name = "";
            this.mTxtBxName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxName.CustomButton.TabIndex = 1;
            this.mTxtBxName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxName.CustomButton.UseSelectable = true;
            this.mTxtBxName.CustomButton.Visible = false;
            this.mTxtBxName.Lines = new string[0];
            this.mTxtBxName.Location = new System.Drawing.Point(216, 104);
            this.mTxtBxName.MaxLength = 32767;
            this.mTxtBxName.Name = "mTxtBxName";
            this.mTxtBxName.PasswordChar = '\0';
            this.mTxtBxName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxName.SelectedText = "";
            this.mTxtBxName.SelectionLength = 0;
            this.mTxtBxName.SelectionStart = 0;
            this.mTxtBxName.ShortcutsEnabled = true;
            this.mTxtBxName.Size = new System.Drawing.Size(205, 23);
            this.mTxtBxName.TabIndex = 1;
            this.mTxtBxName.UseSelectable = true;
            this.mTxtBxName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxDescr
            // 
            this.mTxtBxDescr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.mTxtBxDescr.CustomButton.Image = null;
            this.mTxtBxDescr.CustomButton.Location = new System.Drawing.Point(345, 1);
            this.mTxtBxDescr.CustomButton.Name = "";
            this.mTxtBxDescr.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxDescr.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxDescr.CustomButton.TabIndex = 1;
            this.mTxtBxDescr.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxDescr.CustomButton.UseSelectable = true;
            this.mTxtBxDescr.CustomButton.Visible = false;
            this.mTxtBxDescr.Lines = new string[0];
            this.mTxtBxDescr.Location = new System.Drawing.Point(216, 200);
            this.mTxtBxDescr.MaxLength = 32767;
            this.mTxtBxDescr.Name = "mTxtBxDescr";
            this.mTxtBxDescr.PasswordChar = '\0';
            this.mTxtBxDescr.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxDescr.SelectedText = "";
            this.mTxtBxDescr.SelectionLength = 0;
            this.mTxtBxDescr.SelectionStart = 0;
            this.mTxtBxDescr.ShortcutsEnabled = true;
            this.mTxtBxDescr.Size = new System.Drawing.Size(367, 23);
            this.mTxtBxDescr.TabIndex = 4;
            this.mTxtBxDescr.UseSelectable = true;
            this.mTxtBxDescr.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxDescr.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxSheet
            // 
            // 
            // 
            // 
            this.mTxtBxSheet.CustomButton.Image = null;
            this.mTxtBxSheet.CustomButton.Location = new System.Drawing.Point(185, 1);
            this.mTxtBxSheet.CustomButton.Name = "";
            this.mTxtBxSheet.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxSheet.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxSheet.CustomButton.TabIndex = 1;
            this.mTxtBxSheet.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxSheet.CustomButton.UseSelectable = true;
            this.mTxtBxSheet.CustomButton.Visible = false;
            this.mTxtBxSheet.Lines = new string[0];
            this.mTxtBxSheet.Location = new System.Drawing.Point(216, 248);
            this.mTxtBxSheet.MaxLength = 32767;
            this.mTxtBxSheet.Name = "mTxtBxSheet";
            this.mTxtBxSheet.PasswordChar = '\0';
            this.mTxtBxSheet.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxSheet.SelectedText = "";
            this.mTxtBxSheet.SelectionLength = 0;
            this.mTxtBxSheet.SelectionStart = 0;
            this.mTxtBxSheet.ShortcutsEnabled = true;
            this.mTxtBxSheet.Size = new System.Drawing.Size(207, 23);
            this.mTxtBxSheet.TabIndex = 5;
            this.mTxtBxSheet.UseSelectable = true;
            this.mTxtBxSheet.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxSheet.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxQuantUnit
            // 
            // 
            // 
            // 
            this.mTxtBxQuantUnit.CustomButton.Image = null;
            this.mTxtBxQuantUnit.CustomButton.Location = new System.Drawing.Point(184, 1);
            this.mTxtBxQuantUnit.CustomButton.Name = "";
            this.mTxtBxQuantUnit.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxQuantUnit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxQuantUnit.CustomButton.TabIndex = 1;
            this.mTxtBxQuantUnit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxQuantUnit.CustomButton.UseSelectable = true;
            this.mTxtBxQuantUnit.CustomButton.Visible = false;
            this.mTxtBxQuantUnit.Lines = new string[0];
            this.mTxtBxQuantUnit.Location = new System.Drawing.Point(215, 152);
            this.mTxtBxQuantUnit.MaxLength = 32767;
            this.mTxtBxQuantUnit.Name = "mTxtBxQuantUnit";
            this.mTxtBxQuantUnit.PasswordChar = '\0';
            this.mTxtBxQuantUnit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxQuantUnit.SelectedText = "";
            this.mTxtBxQuantUnit.SelectionLength = 0;
            this.mTxtBxQuantUnit.SelectionStart = 0;
            this.mTxtBxQuantUnit.ShortcutsEnabled = true;
            this.mTxtBxQuantUnit.Size = new System.Drawing.Size(206, 23);
            this.mTxtBxQuantUnit.TabIndex = 3;
            this.mTxtBxQuantUnit.UseSelectable = true;
            this.mTxtBxQuantUnit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxQuantUnit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxQuantity
            // 
            // 
            // 
            // 
            this.mTxtBxQuantity.CustomButton.Image = null;
            this.mTxtBxQuantity.CustomButton.Location = new System.Drawing.Point(138, 1);
            this.mTxtBxQuantity.CustomButton.Name = "";
            this.mTxtBxQuantity.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxQuantity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxQuantity.CustomButton.TabIndex = 1;
            this.mTxtBxQuantity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxQuantity.CustomButton.UseSelectable = true;
            this.mTxtBxQuantity.CustomButton.Visible = false;
            this.mTxtBxQuantity.Lines = new string[0];
            this.mTxtBxQuantity.Location = new System.Drawing.Point(421, 347);
            this.mTxtBxQuantity.MaxLength = 32767;
            this.mTxtBxQuantity.Name = "mTxtBxQuantity";
            this.mTxtBxQuantity.PasswordChar = '\0';
            this.mTxtBxQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxQuantity.SelectedText = "";
            this.mTxtBxQuantity.SelectionLength = 0;
            this.mTxtBxQuantity.SelectionStart = 0;
            this.mTxtBxQuantity.ShortcutsEnabled = true;
            this.mTxtBxQuantity.Size = new System.Drawing.Size(160, 23);
            this.mTxtBxQuantity.TabIndex = 8;
            this.mTxtBxQuantity.UseSelectable = true;
            this.mTxtBxQuantity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxQuantity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(215, 178);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(86, 19);
            this.metroLabel2.TabIndex = 10;
            this.metroLabel2.Text = "Termékleírás:";
            // 
            // mLabelQuality
            // 
            this.mLabelQuality.AutoSize = true;
            this.mLabelQuality.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mLabelQuality.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.mLabelQuality.Location = new System.Drawing.Point(214, 54);
            this.mLabelQuality.Name = "mLabelQuality";
            this.mLabelQuality.Size = new System.Drawing.Size(189, 25);
            this.mLabelQuality.TabIndex = 11;
            this.mLabelQuality.Text = "Minőségi paraméterek";
            // 
            // mLabelStrip
            // 
            this.mLabelStrip.AutoSize = true;
            this.mLabelStrip.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mLabelStrip.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.mLabelStrip.Location = new System.Drawing.Point(213, 294);
            this.mLabelStrip.Name = "mLabelStrip";
            this.mLabelStrip.Size = new System.Drawing.Size(206, 25);
            this.mLabelStrip.TabIndex = 11;
            this.mLabelStrip.Text = "Mennyiségi paraméterek";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(215, 82);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(76, 19);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Terméknév:";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(460, 82);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(66, 19);
            this.metroLabel6.TabIndex = 12;
            this.metroLabel6.Text = "Beszállító:";
            // 
            // mCmbBxSubcontr
            // 
            this.mCmbBxSubcontr.FormattingEnabled = true;
            this.mCmbBxSubcontr.ItemHeight = 23;
            this.mCmbBxSubcontr.Location = new System.Drawing.Point(460, 104);
            this.mCmbBxSubcontr.Name = "mCmbBxSubcontr";
            this.mCmbBxSubcontr.Size = new System.Drawing.Size(121, 29);
            this.mCmbBxSubcontr.TabIndex = 2;
            this.mCmbBxSubcontr.UseSelectable = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(213, 130);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(135, 19);
            this.metroLabel7.TabIndex = 10;
            this.metroLabel7.Text = "Egységnyi mennyiség:";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(216, 226);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(129, 19);
            this.metroLabel8.TabIndex = 14;
            this.metroLabel8.Text = "Biztonsági adatlapja:";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(460, 226);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(93, 19);
            this.metroLabel9.TabIndex = 15;
            this.metroLabel9.Text = "Veszélyessége:";
            // 
            // mTxtBxDanger
            // 
            // 
            // 
            // 
            this.mTxtBxDanger.CustomButton.Image = null;
            this.mTxtBxDanger.CustomButton.Location = new System.Drawing.Point(99, 1);
            this.mTxtBxDanger.CustomButton.Name = "";
            this.mTxtBxDanger.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxDanger.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxDanger.CustomButton.TabIndex = 1;
            this.mTxtBxDanger.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxDanger.CustomButton.UseSelectable = true;
            this.mTxtBxDanger.CustomButton.Visible = false;
            this.mTxtBxDanger.Lines = new string[0];
            this.mTxtBxDanger.Location = new System.Drawing.Point(460, 248);
            this.mTxtBxDanger.MaxLength = 32767;
            this.mTxtBxDanger.Name = "mTxtBxDanger";
            this.mTxtBxDanger.PasswordChar = '\0';
            this.mTxtBxDanger.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxDanger.SelectedText = "";
            this.mTxtBxDanger.SelectionLength = 0;
            this.mTxtBxDanger.SelectionStart = 0;
            this.mTxtBxDanger.ShortcutsEnabled = true;
            this.mTxtBxDanger.Size = new System.Drawing.Size(121, 23);
            this.mTxtBxDanger.TabIndex = 6;
            this.mTxtBxDanger.UseSelectable = true;
            this.mTxtBxDanger.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxDanger.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mLabelStripping
            // 
            this.mLabelStripping.AutoSize = true;
            this.mLabelStripping.Location = new System.Drawing.Point(216, 325);
            this.mLabelStripping.Name = "mLabelStripping";
            this.mLabelStripping.Size = new System.Drawing.Size(74, 19);
            this.mLabelStripping.TabIndex = 18;
            this.mLabelStripping.Text = "Kiszerelése:";
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(421, 325);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(81, 19);
            this.metroLabel11.TabIndex = 19;
            this.metroLabel11.Text = "Mennyisége:";
            // 
            // mTxtBxPlaceing
            // 
            // 
            // 
            // 
            this.mTxtBxPlaceing.CustomButton.Image = null;
            this.mTxtBxPlaceing.CustomButton.Location = new System.Drawing.Point(138, 1);
            this.mTxtBxPlaceing.CustomButton.Name = "";
            this.mTxtBxPlaceing.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxPlaceing.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxPlaceing.CustomButton.TabIndex = 1;
            this.mTxtBxPlaceing.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxPlaceing.CustomButton.UseSelectable = true;
            this.mTxtBxPlaceing.CustomButton.Visible = false;
            this.mTxtBxPlaceing.Lines = new string[0];
            this.mTxtBxPlaceing.Location = new System.Drawing.Point(216, 395);
            this.mTxtBxPlaceing.MaxLength = 32767;
            this.mTxtBxPlaceing.Name = "mTxtBxPlaceing";
            this.mTxtBxPlaceing.PasswordChar = '\0';
            this.mTxtBxPlaceing.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxPlaceing.SelectedText = "";
            this.mTxtBxPlaceing.SelectionLength = 0;
            this.mTxtBxPlaceing.SelectionStart = 0;
            this.mTxtBxPlaceing.ShortcutsEnabled = true;
            this.mTxtBxPlaceing.Size = new System.Drawing.Size(160, 23);
            this.mTxtBxPlaceing.TabIndex = 9;
            this.mTxtBxPlaceing.UseSelectable = true;
            this.mTxtBxPlaceing.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxPlaceing.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(216, 373);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(77, 19);
            this.metroLabel12.TabIndex = 18;
            this.metroLabel12.Text = "Elhelyezése:";
            // 
            // mLabelInfos
            // 
            this.mLabelInfos.AutoSize = true;
            this.mLabelInfos.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.mLabelInfos.Location = new System.Drawing.Point(216, 429);
            this.mLabelInfos.Name = "mLabelInfos";
            this.mLabelInfos.Size = new System.Drawing.Size(0, 0);
            this.mLabelInfos.TabIndex = 21;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(421, 373);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(88, 19);
            this.metroLabel13.TabIndex = 18;
            this.metroLabel13.Text = "Termékkódja:";
            // 
            // mTxtBxBarcode
            // 
            // 
            // 
            // 
            this.mTxtBxBarcode.CustomButton.Image = null;
            this.mTxtBxBarcode.CustomButton.Location = new System.Drawing.Point(138, 1);
            this.mTxtBxBarcode.CustomButton.Name = "";
            this.mTxtBxBarcode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxBarcode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxBarcode.CustomButton.TabIndex = 1;
            this.mTxtBxBarcode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxBarcode.CustomButton.UseSelectable = true;
            this.mTxtBxBarcode.CustomButton.Visible = false;
            this.mTxtBxBarcode.Lines = new string[0];
            this.mTxtBxBarcode.Location = new System.Drawing.Point(421, 395);
            this.mTxtBxBarcode.MaxLength = 32767;
            this.mTxtBxBarcode.Name = "mTxtBxBarcode";
            this.mTxtBxBarcode.PasswordChar = '\0';
            this.mTxtBxBarcode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxBarcode.SelectedText = "";
            this.mTxtBxBarcode.SelectionLength = 0;
            this.mTxtBxBarcode.SelectionStart = 0;
            this.mTxtBxBarcode.ShortcutsEnabled = true;
            this.mTxtBxBarcode.Size = new System.Drawing.Size(160, 23);
            this.mTxtBxBarcode.TabIndex = 10;
            this.mTxtBxBarcode.UseSelectable = true;
            this.mTxtBxBarcode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxBarcode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // errorProvDataProb
            // 
            this.errorProvDataProb.ContainerControl = this;
            // 
            // mTxtBxStripping
            // 
            // 
            // 
            // 
            this.mTxtBxStripping.CustomButton.Image = null;
            this.mTxtBxStripping.CustomButton.Location = new System.Drawing.Point(138, 1);
            this.mTxtBxStripping.CustomButton.Name = "";
            this.mTxtBxStripping.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxStripping.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxStripping.CustomButton.TabIndex = 1;
            this.mTxtBxStripping.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxStripping.CustomButton.UseSelectable = true;
            this.mTxtBxStripping.CustomButton.Visible = false;
            this.mTxtBxStripping.Lines = new string[0];
            this.mTxtBxStripping.Location = new System.Drawing.Point(216, 347);
            this.mTxtBxStripping.MaxLength = 32767;
            this.mTxtBxStripping.Name = "mTxtBxStripping";
            this.mTxtBxStripping.PasswordChar = '\0';
            this.mTxtBxStripping.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxStripping.SelectedText = "";
            this.mTxtBxStripping.SelectionLength = 0;
            this.mTxtBxStripping.SelectionStart = 0;
            this.mTxtBxStripping.ShortcutsEnabled = true;
            this.mTxtBxStripping.Size = new System.Drawing.Size(160, 23);
            this.mTxtBxStripping.TabIndex = 7;
            this.mTxtBxStripping.UseSelectable = true;
            this.mTxtBxStripping.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxStripping.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // FormServiceProductsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 493);
            this.Controls.Add(this.mLabelInfos);
            this.Controls.Add(this.mTxtBxBarcode);
            this.Controls.Add(this.mTxtBxPlaceing);
            this.Controls.Add(this.metroLabel13);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.mLabelStripping);
            this.Controls.Add(this.mTxtBxDanger);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.mCmbBxSubcontr);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.mLabelStrip);
            this.Controls.Add(this.mLabelQuality);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.mTxtBxDescr);
            this.Controls.Add(this.mTxtBxStripping);
            this.Controls.Add(this.mTxtBxQuantity);
            this.Controls.Add(this.mTxtBxQuantUnit);
            this.Controls.Add(this.mTxtBxSheet);
            this.Controls.Add(this.mTxtBxName);
            this.Controls.Add(this.mLabelMainTitle);
            this.Controls.Add(this.metroPanel1);
            this.Name = "FormServiceProductsWindow";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormServiceProductsWindow_FormClosed);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvDataProb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroTile mTileCancel;
        private MetroFramework.Controls.MetroLabel mLabelMainTitle;
        private MetroFramework.Controls.MetroTextBox mTxtBxName;
        private MetroFramework.Controls.MetroTextBox mTxtBxDescr;
        private MetroFramework.Controls.MetroTextBox mTxtBxSheet;
        private MetroFramework.Controls.MetroTextBox mTxtBxQuantUnit;
        private MetroFramework.Controls.MetroTextBox mTxtBxQuantity;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel mLabelQuality;
        private MetroFramework.Controls.MetroLabel mLabelStrip;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox mCmbBxSubcontr;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox mTxtBxDanger;
        private MetroFramework.Controls.MetroLabel mLabelStripping;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTextBox mTxtBxPlaceing;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel mLabelInfos;
        private MetroFramework.Controls.MetroTile mTileOk;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTextBox mTxtBxBarcode;
        private System.Windows.Forms.ErrorProvider errorProvDataProb;
        private MetroFramework.Controls.MetroTextBox mTxtBxStripping;
    }
}