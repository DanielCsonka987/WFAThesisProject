namespace WFAThesisProject
{
    partial class FormAdjustConnectionWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdjustConnectionWindow));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.mTileBack = new MetroFramework.Controls.MetroTile();
            this.mTileSaveConData = new MetroFramework.Controls.MetroTile();
            this.mTxtBxHost = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxPort = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxDB = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxUser = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxPwd = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxPdfDest = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.mTxtBxUrl = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroPanel1.BackgroundImage")));
            this.metroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroPanel1.Controls.Add(this.metroPanel2);
            this.metroPanel1.Controls.Add(this.mTileBack);
            this.metroPanel1.Controls.Add(this.mTileSaveConData);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 5);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(200, 409);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // mTileBack
            // 
            this.mTileBack.ActiveControl = null;
            this.mTileBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mTileBack.Location = new System.Drawing.Point(23, 230);
            this.mTileBack.Name = "mTileBack";
            this.mTileBack.Size = new System.Drawing.Size(150, 40);
            this.mTileBack.Style = MetroFramework.MetroColorStyle.Red;
            this.mTileBack.TabIndex = 9;
            this.mTileBack.Text = "Vissza";
            this.mTileBack.UseSelectable = true;
            this.mTileBack.Click += new System.EventHandler(this.mTileBack_Click);
            // 
            // mTileSaveConData
            // 
            this.mTileSaveConData.ActiveControl = null;
            this.mTileSaveConData.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.mTileSaveConData.Location = new System.Drawing.Point(23, 170);
            this.mTileSaveConData.Name = "mTileSaveConData";
            this.mTileSaveConData.Size = new System.Drawing.Size(150, 40);
            this.mTileSaveConData.Style = MetroFramework.MetroColorStyle.Red;
            this.mTileSaveConData.TabIndex = 8;
            this.mTileSaveConData.Text = "Kapcsolat mentése";
            this.mTileSaveConData.UseSelectable = true;
            this.mTileSaveConData.Click += new System.EventHandler(this.mTileSaveConData_Click);
            // 
            // mTxtBxHost
            // 
            // 
            // 
            // 
            this.mTxtBxHost.CustomButton.Image = null;
            this.mTxtBxHost.CustomButton.Location = new System.Drawing.Point(158, 1);
            this.mTxtBxHost.CustomButton.Name = "";
            this.mTxtBxHost.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxHost.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxHost.CustomButton.TabIndex = 1;
            this.mTxtBxHost.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxHost.CustomButton.UseSelectable = true;
            this.mTxtBxHost.CustomButton.Visible = false;
            this.mTxtBxHost.Lines = new string[0];
            this.mTxtBxHost.Location = new System.Drawing.Point(233, 52);
            this.mTxtBxHost.MaxLength = 32767;
            this.mTxtBxHost.Name = "mTxtBxHost";
            this.mTxtBxHost.PasswordChar = '\0';
            this.mTxtBxHost.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxHost.SelectedText = "";
            this.mTxtBxHost.SelectionLength = 0;
            this.mTxtBxHost.SelectionStart = 0;
            this.mTxtBxHost.ShortcutsEnabled = true;
            this.mTxtBxHost.Size = new System.Drawing.Size(180, 23);
            this.mTxtBxHost.TabIndex = 1;
            this.mTxtBxHost.UseSelectable = true;
            this.mTxtBxHost.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxHost.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxPort
            // 
            // 
            // 
            // 
            this.mTxtBxPort.CustomButton.Image = null;
            this.mTxtBxPort.CustomButton.Location = new System.Drawing.Point(158, 1);
            this.mTxtBxPort.CustomButton.Name = "";
            this.mTxtBxPort.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxPort.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxPort.CustomButton.TabIndex = 1;
            this.mTxtBxPort.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxPort.CustomButton.UseSelectable = true;
            this.mTxtBxPort.CustomButton.Visible = false;
            this.mTxtBxPort.Lines = new string[0];
            this.mTxtBxPort.Location = new System.Drawing.Point(233, 102);
            this.mTxtBxPort.MaxLength = 32767;
            this.mTxtBxPort.Name = "mTxtBxPort";
            this.mTxtBxPort.PasswordChar = '\0';
            this.mTxtBxPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxPort.SelectedText = "";
            this.mTxtBxPort.SelectionLength = 0;
            this.mTxtBxPort.SelectionStart = 0;
            this.mTxtBxPort.ShortcutsEnabled = true;
            this.mTxtBxPort.Size = new System.Drawing.Size(180, 23);
            this.mTxtBxPort.TabIndex = 2;
            this.mTxtBxPort.UseSelectable = true;
            this.mTxtBxPort.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxPort.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxDB
            // 
            // 
            // 
            // 
            this.mTxtBxDB.CustomButton.Image = null;
            this.mTxtBxDB.CustomButton.Location = new System.Drawing.Point(158, 1);
            this.mTxtBxDB.CustomButton.Name = "";
            this.mTxtBxDB.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxDB.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxDB.CustomButton.TabIndex = 1;
            this.mTxtBxDB.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxDB.CustomButton.UseSelectable = true;
            this.mTxtBxDB.CustomButton.Visible = false;
            this.mTxtBxDB.Lines = new string[0];
            this.mTxtBxDB.Location = new System.Drawing.Point(233, 152);
            this.mTxtBxDB.MaxLength = 32767;
            this.mTxtBxDB.Name = "mTxtBxDB";
            this.mTxtBxDB.PasswordChar = '\0';
            this.mTxtBxDB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxDB.SelectedText = "";
            this.mTxtBxDB.SelectionLength = 0;
            this.mTxtBxDB.SelectionStart = 0;
            this.mTxtBxDB.ShortcutsEnabled = true;
            this.mTxtBxDB.Size = new System.Drawing.Size(180, 23);
            this.mTxtBxDB.TabIndex = 3;
            this.mTxtBxDB.UseSelectable = true;
            this.mTxtBxDB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxDB.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxUser
            // 
            // 
            // 
            // 
            this.mTxtBxUser.CustomButton.Image = null;
            this.mTxtBxUser.CustomButton.Location = new System.Drawing.Point(158, 1);
            this.mTxtBxUser.CustomButton.Name = "";
            this.mTxtBxUser.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxUser.CustomButton.TabIndex = 1;
            this.mTxtBxUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxUser.CustomButton.UseSelectable = true;
            this.mTxtBxUser.CustomButton.Visible = false;
            this.mTxtBxUser.Lines = new string[0];
            this.mTxtBxUser.Location = new System.Drawing.Point(233, 202);
            this.mTxtBxUser.MaxLength = 32767;
            this.mTxtBxUser.Name = "mTxtBxUser";
            this.mTxtBxUser.PasswordChar = '\0';
            this.mTxtBxUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxUser.SelectedText = "";
            this.mTxtBxUser.SelectionLength = 0;
            this.mTxtBxUser.SelectionStart = 0;
            this.mTxtBxUser.ShortcutsEnabled = true;
            this.mTxtBxUser.Size = new System.Drawing.Size(180, 23);
            this.mTxtBxUser.TabIndex = 4;
            this.mTxtBxUser.UseSelectable = true;
            this.mTxtBxUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mTxtBxPwd
            // 
            // 
            // 
            // 
            this.mTxtBxPwd.CustomButton.Image = null;
            this.mTxtBxPwd.CustomButton.Location = new System.Drawing.Point(158, 1);
            this.mTxtBxPwd.CustomButton.Name = "";
            this.mTxtBxPwd.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxPwd.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxPwd.CustomButton.TabIndex = 1;
            this.mTxtBxPwd.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxPwd.CustomButton.UseSelectable = true;
            this.mTxtBxPwd.CustomButton.Visible = false;
            this.mTxtBxPwd.Lines = new string[0];
            this.mTxtBxPwd.Location = new System.Drawing.Point(233, 254);
            this.mTxtBxPwd.MaxLength = 32767;
            this.mTxtBxPwd.Name = "mTxtBxPwd";
            this.mTxtBxPwd.PasswordChar = '\0';
            this.mTxtBxPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxPwd.SelectedText = "";
            this.mTxtBxPwd.SelectionLength = 0;
            this.mTxtBxPwd.SelectionStart = 0;
            this.mTxtBxPwd.ShortcutsEnabled = true;
            this.mTxtBxPwd.Size = new System.Drawing.Size(180, 23);
            this.mTxtBxPwd.TabIndex = 5;
            this.mTxtBxPwd.UseSelectable = true;
            this.mTxtBxPwd.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxPwd.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(233, 27);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(116, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Adatbázis címzése";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(233, 78);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(129, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Kommunikációs port";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(233, 130);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(97, 19);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Adatbázis neve";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(233, 178);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(140, 19);
            this.metroLabel4.TabIndex = 2;
            this.metroLabel4.Text = "DBMS felhasználói név";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(233, 230);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(152, 19);
            this.metroLabel5.TabIndex = 2;
            this.metroLabel5.Text = "DBMS felhasználói jelszó";
            // 
            // mTxtBxPdfDest
            // 
            // 
            // 
            // 
            this.mTxtBxPdfDest.CustomButton.Image = null;
            this.mTxtBxPdfDest.CustomButton.Location = new System.Drawing.Point(158, 1);
            this.mTxtBxPdfDest.CustomButton.Name = "";
            this.mTxtBxPdfDest.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxPdfDest.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxPdfDest.CustomButton.TabIndex = 1;
            this.mTxtBxPdfDest.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxPdfDest.CustomButton.UseSelectable = true;
            this.mTxtBxPdfDest.CustomButton.Visible = false;
            this.mTxtBxPdfDest.Lines = new string[0];
            this.mTxtBxPdfDest.Location = new System.Drawing.Point(233, 305);
            this.mTxtBxPdfDest.MaxLength = 32767;
            this.mTxtBxPdfDest.Name = "mTxtBxPdfDest";
            this.mTxtBxPdfDest.PasswordChar = '\0';
            this.mTxtBxPdfDest.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxPdfDest.SelectedText = "";
            this.mTxtBxPdfDest.SelectionLength = 0;
            this.mTxtBxPdfDest.SelectionStart = 0;
            this.mTxtBxPdfDest.ShortcutsEnabled = true;
            this.mTxtBxPdfDest.Size = new System.Drawing.Size(180, 23);
            this.mTxtBxPdfDest.TabIndex = 6;
            this.mTxtBxPdfDest.UseSelectable = true;
            this.mTxtBxPdfDest.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxPdfDest.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(233, 281);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(161, 19);
            this.metroLabel6.TabIndex = 2;
            this.metroLabel6.Text = "PDF-ek kimeneti mappája";
            // 
            // mTxtBxUrl
            // 
            // 
            // 
            // 
            this.mTxtBxUrl.CustomButton.Image = null;
            this.mTxtBxUrl.CustomButton.Location = new System.Drawing.Point(158, 1);
            this.mTxtBxUrl.CustomButton.Name = "";
            this.mTxtBxUrl.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxUrl.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxUrl.CustomButton.TabIndex = 1;
            this.mTxtBxUrl.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxUrl.CustomButton.UseSelectable = true;
            this.mTxtBxUrl.CustomButton.Visible = false;
            this.mTxtBxUrl.Lines = new string[0];
            this.mTxtBxUrl.Location = new System.Drawing.Point(233, 356);
            this.mTxtBxUrl.MaxLength = 32767;
            this.mTxtBxUrl.Name = "mTxtBxUrl";
            this.mTxtBxUrl.PasswordChar = '\0';
            this.mTxtBxUrl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxUrl.SelectedText = "";
            this.mTxtBxUrl.SelectionLength = 0;
            this.mTxtBxUrl.SelectionStart = 0;
            this.mTxtBxUrl.ShortcutsEnabled = true;
            this.mTxtBxUrl.Size = new System.Drawing.Size(180, 23);
            this.mTxtBxUrl.TabIndex = 7;
            this.mTxtBxUrl.UseSelectable = true;
            this.mTxtBxUrl.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxUrl.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(233, 332);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(168, 19);
            this.metroLabel7.TabIndex = 2;
            this.metroLabel7.Text = "Biztonsági adatlapok elérés";
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
            this.metroPanel2.TabIndex = 10;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // FormAdjustConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 414);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.mTxtBxUrl);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.mTxtBxPdfDest);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.mTxtBxPwd);
            this.Controls.Add(this.mTxtBxUser);
            this.Controls.Add(this.mTxtBxDB);
            this.Controls.Add(this.mTxtBxPort);
            this.Controls.Add(this.mTxtBxHost);
            this.Controls.Add(this.metroPanel1);
            this.Name = "FormAdjustConnection";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile mTileBack;
        private MetroFramework.Controls.MetroTile mTileSaveConData;
        private MetroFramework.Controls.MetroTextBox mTxtBxHost;
        private MetroFramework.Controls.MetroTextBox mTxtBxPort;
        private MetroFramework.Controls.MetroTextBox mTxtBxDB;
        private MetroFramework.Controls.MetroTextBox mTxtBxUser;
        private MetroFramework.Controls.MetroTextBox mTxtBxPwd;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox mTxtBxPdfDest;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox mTxtBxUrl;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroPanel metroPanel2;
    }
}