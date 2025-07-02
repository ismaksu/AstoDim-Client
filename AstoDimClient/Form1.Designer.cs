namespace AstoDimClient
{
    partial class frmClientMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mskLicenseKey = new MaskedTextBox();
            label1 = new Label();
            label3 = new Label();
            lblLicenseKey = new Label();
            btnHideKey = new Button();
            btnActivateLicense = new ReaLTaiizor.Controls.CyberButton();
            lblRemaining = new Label();
            btnInjectBot = new ReaLTaiizor.Controls.CyberButton();
            label2 = new Label();
            SuspendLayout();
            // 
            // mskLicenseKey
            // 
            mskLicenseKey.BackColor = Color.Black;
            mskLicenseKey.BorderStyle = BorderStyle.None;
            mskLicenseKey.Font = new Font("VCR OSD Mono", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mskLicenseKey.ForeColor = Color.FromArgb(162, 0, 0);
            mskLicenseKey.Location = new Point(486, 213);
            mskLicenseKey.Mask = ">AAAAA-AAAAA-AAAAA-AAAAA-AAAAA";
            mskLicenseKey.Name = "mskLicenseKey";
            mskLicenseKey.Size = new Size(413, 24);
            mskLicenseKey.TabIndex = 2;
            mskLicenseKey.Enter += mskLicenseKey_Enter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("VCR OSD Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(162, 0, 0);
            label1.Location = new Point(484, 183);
            label1.Name = "label1";
            label1.Size = new Size(194, 19);
            label1.TabIndex = 3;
            label1.Text = "Lisans Anahtari: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("VCR OSD Mono", 9.75F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkRed;
            label3.Location = new Point(12, 566);
            label3.Name = "label3";
            label3.Size = new Size(125, 14);
            label3.TabIndex = 6;
            label3.Text = "Lisans Anahtari";
            // 
            // lblLicenseKey
            // 
            lblLicenseKey.AutoSize = true;
            lblLicenseKey.BackColor = Color.Transparent;
            lblLicenseKey.Font = new Font("VCR OSD Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLicenseKey.ForeColor = Color.DarkRed;
            lblLicenseKey.Location = new Point(12, 584);
            lblLicenseKey.Name = "lblLicenseKey";
            lblLicenseKey.Size = new Size(189, 14);
            lblLicenseKey.TabIndex = 7;
            lblLicenseKey.Text = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX";
            // 
            // btnHideKey
            // 
            btnHideKey.BackColor = Color.Transparent;
            btnHideKey.BackgroundImage = Properties.Resources.no_see_visible_hidde_icon_187886;
            btnHideKey.BackgroundImageLayout = ImageLayout.Stretch;
            btnHideKey.FlatAppearance.BorderSize = 0;
            btnHideKey.FlatStyle = FlatStyle.Flat;
            btnHideKey.ForeColor = Color.DarkRed;
            btnHideKey.Location = new Point(255, 572);
            btnHideKey.Name = "btnHideKey";
            btnHideKey.Size = new Size(30, 30);
            btnHideKey.TabIndex = 8;
            btnHideKey.UseVisualStyleBackColor = false;
            btnHideKey.Visible = false;
            btnHideKey.Click += btnHideKey_Click;
            // 
            // btnActivateLicense
            // 
            btnActivateLicense.Alpha = 20;
            btnActivateLicense.BackColor = Color.Transparent;
            btnActivateLicense.Background = true;
            btnActivateLicense.Background_WidthPen = 4F;
            btnActivateLicense.BackgroundPen = true;
            btnActivateLicense.ColorBackground = Color.Transparent;
            btnActivateLicense.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnActivateLicense.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnActivateLicense.ColorBackground_Pen = Color.FromArgb(162, 0, 0);
            btnActivateLicense.ColorLighting = Color.FromArgb(29, 200, 238);
            btnActivateLicense.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnActivateLicense.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnActivateLicense.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnActivateLicense.Effect_1 = true;
            btnActivateLicense.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnActivateLicense.Effect_1_Transparency = 25;
            btnActivateLicense.Effect_2 = true;
            btnActivateLicense.Effect_2_ColorBackground = Color.White;
            btnActivateLicense.Effect_2_Transparency = 20;
            btnActivateLicense.Font = new Font("VCR OSD Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActivateLicense.ForeColor = Color.FromArgb(202, 0, 0);
            btnActivateLicense.Lighting = false;
            btnActivateLicense.LinearGradient_Background = false;
            btnActivateLicense.LinearGradientPen = false;
            btnActivateLicense.Location = new Point(728, 252);
            btnActivateLicense.Name = "btnActivateLicense";
            btnActivateLicense.PenWidth = 15;
            btnActivateLicense.Rounding = true;
            btnActivateLicense.RoundingInt = 70;
            btnActivateLicense.Size = new Size(171, 50);
            btnActivateLicense.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnActivateLicense.TabIndex = 13;
            btnActivateLicense.Tag = "Cyber";
            btnActivateLicense.TextButton = "Aktiflestir";
            btnActivateLicense.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            btnActivateLicense.Timer_Effect_1 = 5;
            btnActivateLicense.Timer_RGB = 300;
            btnActivateLicense.Click += btnActivateLicense_Click_1;
            // 
            // lblRemaining
            // 
            lblRemaining.AutoSize = true;
            lblRemaining.Font = new Font("VCR OSD Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRemaining.ForeColor = Color.FromArgb(162, 0, 0);
            lblRemaining.Location = new Point(494, 407);
            lblRemaining.Name = "lblRemaining";
            lblRemaining.Size = new Size(390, 19);
            lblRemaining.TabIndex = 14;
            lblRemaining.Text = "Kalan Süre: 6 gün 22 saat 31 dakika";
            lblRemaining.Visible = false;
            // 
            // btnInjectBot
            // 
            btnInjectBot.Alpha = 20;
            btnInjectBot.BackColor = Color.Transparent;
            btnInjectBot.Background = true;
            btnInjectBot.Background_WidthPen = 4F;
            btnInjectBot.BackgroundPen = true;
            btnInjectBot.ColorBackground = Color.Transparent;
            btnInjectBot.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnInjectBot.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnInjectBot.ColorBackground_Pen = Color.FromArgb(162, 0, 0);
            btnInjectBot.ColorLighting = Color.FromArgb(29, 200, 238);
            btnInjectBot.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnInjectBot.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnInjectBot.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnInjectBot.Effect_1 = true;
            btnInjectBot.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnInjectBot.Effect_1_Transparency = 25;
            btnInjectBot.Effect_2 = true;
            btnInjectBot.Effect_2_ColorBackground = Color.White;
            btnInjectBot.Effect_2_Transparency = 20;
            btnInjectBot.Font = new Font("VCR OSD Mono", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInjectBot.ForeColor = Color.FromArgb(202, 0, 0);
            btnInjectBot.Lighting = false;
            btnInjectBot.LinearGradient_Background = false;
            btnInjectBot.LinearGradientPen = false;
            btnInjectBot.Location = new Point(517, 277);
            btnInjectBot.Name = "btnInjectBot";
            btnInjectBot.PenWidth = 15;
            btnInjectBot.Rounding = true;
            btnInjectBot.RoundingInt = 70;
            btnInjectBot.Size = new Size(335, 125);
            btnInjectBot.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnInjectBot.TabIndex = 15;
            btnInjectBot.Tag = "Cyber";
            btnInjectBot.TextButton = "BOTU ENJEKTE ET";
            btnInjectBot.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            btnInjectBot.Timer_Effect_1 = 5;
            btnInjectBot.Timer_RGB = 300;
            btnInjectBot.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("VCR OSD Mono", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(162, 0, 0);
            label2.Location = new Point(486, 76);
            label2.Name = "label2";
            label2.Size = new Size(289, 42);
            label2.TabIndex = 16;
            label2.Text = "System Initialization Status: True\r\nCooler Systems: Active\r\nBypassing Security Firewall: Success";
            // 
            // frmClientMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.ultrakill_red_black_machine_robot_hd_wallpaper_08962df850a0cc58b08cc10e58b2040a3;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(926, 607);
            Controls.Add(label2);
            Controls.Add(btnInjectBot);
            Controls.Add(lblRemaining);
            Controls.Add(btnActivateLicense);
            Controls.Add(btnHideKey);
            Controls.Add(lblLicenseKey);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(mskLicenseKey);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmClientMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AstoDim Client";
            Load += frmClientMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaskedTextBox mskLicenseKey;
        private Label label1;
        private Label label3;
        private Label lblLicenseKey;
        private Button btnHideKey;
        private ReaLTaiizor.Controls.CyberButton btnActivateLicense;
        private Label lblRemaining;
        private ReaLTaiizor.Controls.CyberButton btnInjectBot;
        private Label label2;
    }
}
