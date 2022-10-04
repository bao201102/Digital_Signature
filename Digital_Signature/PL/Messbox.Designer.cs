namespace Digital_Signature.PL
{
    partial class Messbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Messbox));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.titlePanel = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnExit = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnConfirm = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.txtPrivateKey = new Bunifu.UI.WinForms.BunifuTextBox();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // titlePanel
            // 
            this.titlePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("titlePanel.BackgroundImage")));
            this.titlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.titlePanel.Controls.Add(this.btnClose);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(234)))));
            this.titlePanel.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(234)))));
            this.titlePanel.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(234)))));
            this.titlePanel.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(234)))));
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Quality = 10;
            this.titlePanel.Size = new System.Drawing.Size(343, 31);
            this.titlePanel.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = global::Digital_Signature.Properties.Resources.crossed;
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(310, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(21, 22);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExit
            // 
            this.btnExit.ActiveBorderThickness = 1;
            this.btnExit.ActiveCornerRadius = 20;
            this.btnExit.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnExit.ActiveForecolor = System.Drawing.Color.White;
            this.btnExit.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.ButtonText = "Hủy bỏ";
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Transparent;
            this.btnExit.IdleBorderThickness = 1;
            this.btnExit.IdleCornerRadius = 20;
            this.btnExit.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnExit.IdleForecolor = System.Drawing.Color.White;
            this.btnExit.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnExit.Location = new System.Drawing.Point(197, 143);
            this.btnExit.Margin = new System.Windows.Forms.Padding(5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 35);
            this.btnExit.TabIndex = 16;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConfirm
            // 
            this.btnConfirm.ActiveBorderThickness = 1;
            this.btnConfirm.ActiveCornerRadius = 20;
            this.btnConfirm.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(68)))), ((int)(((byte)(213)))), ((int)(((byte)(234)))));
            this.btnConfirm.ActiveForecolor = System.Drawing.Color.White;
            this.btnConfirm.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(68)))), ((int)(((byte)(213)))), ((int)(((byte)(234)))));
            this.btnConfirm.BackColor = System.Drawing.SystemColors.Control;
            this.btnConfirm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirm.BackgroundImage")));
            this.btnConfirm.ButtonText = "Xác nhận";
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.Font = new System.Drawing.Font("Leelawadee UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.Transparent;
            this.btnConfirm.IdleBorderThickness = 1;
            this.btnConfirm.IdleCornerRadius = 20;
            this.btnConfirm.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(234)))));
            this.btnConfirm.IdleForecolor = System.Drawing.Color.White;
            this.btnConfirm.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(213)))), ((int)(((byte)(234)))));
            this.btnConfirm.Location = new System.Drawing.Point(52, 143);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(5);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(79, 35);
            this.btnConfirm.TabIndex = 15;
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuLabel1.Location = new System.Drawing.Point(27, 77);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(95, 15);
            this.bunifuLabel1.TabIndex = 17;
            this.bunifuLabel1.Text = "Nhập khóa bí mật";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // txtPrivateKey
            // 
            this.txtPrivateKey.AcceptsReturn = false;
            this.txtPrivateKey.AcceptsTab = false;
            this.txtPrivateKey.AnimationSpeed = 200;
            this.txtPrivateKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPrivateKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPrivateKey.AutoSizeHeight = true;
            this.txtPrivateKey.BackColor = System.Drawing.Color.Transparent;
            this.txtPrivateKey.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtPrivateKey.BackgroundImage")));
            this.txtPrivateKey.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtPrivateKey.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtPrivateKey.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtPrivateKey.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtPrivateKey.BorderRadius = 1;
            this.txtPrivateKey.BorderThickness = 1;
            this.txtPrivateKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPrivateKey.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrivateKey.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.txtPrivateKey.DefaultText = "";
            this.txtPrivateKey.FillColor = System.Drawing.Color.White;
            this.txtPrivateKey.HideSelection = true;
            this.txtPrivateKey.IconLeft = null;
            this.txtPrivateKey.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrivateKey.IconPadding = 10;
            this.txtPrivateKey.IconRight = null;
            this.txtPrivateKey.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrivateKey.Lines = new string[0];
            this.txtPrivateKey.Location = new System.Drawing.Point(140, 68);
            this.txtPrivateKey.MaxLength = 32767;
            this.txtPrivateKey.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtPrivateKey.Modified = false;
            this.txtPrivateKey.Multiline = false;
            this.txtPrivateKey.Name = "txtPrivateKey";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtPrivateKey.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtPrivateKey.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtPrivateKey.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtPrivateKey.OnIdleState = stateProperties4;
            this.txtPrivateKey.Padding = new System.Windows.Forms.Padding(3);
            this.txtPrivateKey.PasswordChar = '\0';
            this.txtPrivateKey.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPrivateKey.PlaceholderText = "Enter text";
            this.txtPrivateKey.ReadOnly = false;
            this.txtPrivateKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrivateKey.SelectedText = "";
            this.txtPrivateKey.SelectionLength = 0;
            this.txtPrivateKey.SelectionStart = 0;
            this.txtPrivateKey.ShortcutsEnabled = true;
            this.txtPrivateKey.Size = new System.Drawing.Size(182, 37);
            this.txtPrivateKey.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtPrivateKey.TabIndex = 18;
            this.txtPrivateKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPrivateKey.TextMarginBottom = 0;
            this.txtPrivateKey.TextMarginLeft = 3;
            this.txtPrivateKey.TextMarginTop = 1;
            this.txtPrivateKey.TextPlaceholder = "Enter text";
            this.txtPrivateKey.UseSystemPasswordChar = false;
            this.txtPrivateKey.WordWrap = true;
            // 
            // Messbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 202);
            this.Controls.Add(this.txtPrivateKey);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.titlePanel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Messbox";
            this.Text = "Messbox";
            this.titlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel titlePanel;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Bunifu.Framework.UI.BunifuThinButton2 btnExit;
        private Bunifu.Framework.UI.BunifuThinButton2 btnConfirm;
        private Bunifu.UI.WinForms.BunifuTextBox txtPrivateKey;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
    }
}