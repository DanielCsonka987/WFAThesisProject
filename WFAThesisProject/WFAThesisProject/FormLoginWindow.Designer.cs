namespace WFAThesisProject
{
    partial class FormLoginWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoginWindow));
            this.mTxtBxAccName = new MetroFramework.Controls.MetroTextBox();
            this.mTxtBxAccPwd = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.mTileExit = new MetroFramework.Controls.MetroTile();
            this.mTileLogin = new MetroFramework.Controls.MetroTile();
            this.errorProviderLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // mTxtBxAccName
            // 
            // 
            // 
            // 
            this.mTxtBxAccName.CustomButton.Image = null;
            this.mTxtBxAccName.CustomButton.Location = new System.Drawing.Point(118, 1);
            this.mTxtBxAccName.CustomButton.Name = "";
            this.mTxtBxAccName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxAccName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxAccName.CustomButton.TabIndex = 1;
            this.mTxtBxAccName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxAccName.CustomButton.UseSelectable = true;
            this.mTxtBxAccName.CustomButton.Visible = false;
            this.mTxtBxAccName.Lines = new string[0];
            this.mTxtBxAccName.Location = new System.Drawing.Point(242, 177);
            this.mTxtBxAccName.MaxLength = 32767;
            this.mTxtBxAccName.Name = "mTxtBxAccName";
            this.mTxtBxAccName.PasswordChar = '\0';
            this.mTxtBxAccName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxAccName.SelectedText = "";
            this.mTxtBxAccName.SelectionLength = 0;
            this.mTxtBxAccName.SelectionStart = 0;
            this.mTxtBxAccName.ShortcutsEnabled = true;
            this.mTxtBxAccName.Size = new System.Drawing.Size(140, 23);
            this.mTxtBxAccName.TabIndex = 0;
            this.mTxtBxAccName.UseSelectable = true;
            this.mTxtBxAccName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxAccName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mTxtBxAccName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mTxtBxAccName_KeyDown);
            // 
            // mTxtBxAccPwd
            // 
            // 
            // 
            // 
            this.mTxtBxAccPwd.CustomButton.Image = null;
            this.mTxtBxAccPwd.CustomButton.Location = new System.Drawing.Point(118, 1);
            this.mTxtBxAccPwd.CustomButton.Name = "";
            this.mTxtBxAccPwd.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mTxtBxAccPwd.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTxtBxAccPwd.CustomButton.TabIndex = 1;
            this.mTxtBxAccPwd.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTxtBxAccPwd.CustomButton.UseSelectable = true;
            this.mTxtBxAccPwd.CustomButton.Visible = false;
            this.mTxtBxAccPwd.Lines = new string[0];
            this.mTxtBxAccPwd.Location = new System.Drawing.Point(242, 241);
            this.mTxtBxAccPwd.MaxLength = 32767;
            this.mTxtBxAccPwd.Name = "mTxtBxAccPwd";
            this.mTxtBxAccPwd.PasswordChar = '*';
            this.mTxtBxAccPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTxtBxAccPwd.SelectedText = "";
            this.mTxtBxAccPwd.SelectionLength = 0;
            this.mTxtBxAccPwd.SelectionStart = 0;
            this.mTxtBxAccPwd.ShortcutsEnabled = true;
            this.mTxtBxAccPwd.Size = new System.Drawing.Size(140, 23);
            this.mTxtBxAccPwd.TabIndex = 1;
            this.mTxtBxAccPwd.UseSelectable = true;
            this.mTxtBxAccPwd.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTxtBxAccPwd.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mTxtBxAccPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mTxtBxAccPwd_KeyDown);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(242, 155);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(117, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Belépési azonosító";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(242, 219);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(93, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Belépési jelszó";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroPanel1.BackgroundImage")));
            this.metroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroPanel1.Controls.Add(this.metroPanel2);
            this.metroPanel1.Controls.Add(this.mTileExit);
            this.metroPanel1.Controls.Add(this.mTileLogin);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 5);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(200, 291);
            this.metroPanel1.TabIndex = 6;
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
            // mTileExit
            // 
            this.mTileExit.ActiveControl = null;
            this.mTileExit.Location = new System.Drawing.Point(23, 219);
            this.mTileExit.Name = "mTileExit";
            this.mTileExit.Size = new System.Drawing.Size(150, 40);
            this.mTileExit.Style = MetroFramework.MetroColorStyle.Silver;
            this.mTileExit.TabIndex = 3;
            this.mTileExit.Text = "Bezárás";
            this.mTileExit.UseSelectable = true;
            this.mTileExit.Click += new System.EventHandler(this.mTileExit_Click);
            // 
            // mTileLogin
            // 
            this.mTileLogin.ActiveControl = null;
            this.mTileLogin.Location = new System.Drawing.Point(23, 158);
            this.mTileLogin.Name = "mTileLogin";
            this.mTileLogin.Size = new System.Drawing.Size(150, 40);
            this.mTileLogin.Style = MetroFramework.MetroColorStyle.Red;
            this.mTileLogin.TabIndex = 2;
            this.mTileLogin.Text = "Belépés";
            this.mTileLogin.UseSelectable = true;
            this.mTileLogin.Click += new System.EventHandler(this.mTileLogin_Click);
            // 
            // errorProviderLogin
            // 
            this.errorProviderLogin.ContainerControl = this;
            // 
            // FormLoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 296);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.mTxtBxAccPwd);
            this.Controls.Add(this.mTxtBxAccName);
            this.Name = "FormLoginWindow";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.VisibleChanged += new System.EventHandler(this.FormLoginWindow_VisibleChanged);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox mTxtBxAccName;
        private MetroFramework.Controls.MetroTextBox mTxtBxAccPwd;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTile mTileExit;
        private MetroFramework.Controls.MetroTile mTileLogin;
        private System.Windows.Forms.ErrorProvider errorProviderLogin;
        private MetroFramework.Controls.MetroPanel metroPanel2;
    }
}