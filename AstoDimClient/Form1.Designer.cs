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
            components = new System.ComponentModel.Container();
            mskLicenseKey = new MaskedTextBox();
            label1 = new Label();
            label3 = new Label();
            lblLicenseKey = new Label();
            btnHideKey = new Button();
            lblRemaining = new Label();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            btnActivateLicense = new Button();
            btnInjectBot = new Button();
            SuspendLayout();
            // 
            // mskLicenseKey
            // 
            mskLicenseKey.BackColor = Color.Black;
            mskLicenseKey.BorderStyle = BorderStyle.None;
            mskLicenseKey.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mskLicenseKey.ForeColor = Color.FromArgb(162, 0, 0);
            mskLicenseKey.Location = new Point(555, 284);
            mskLicenseKey.Margin = new Padding(3, 4, 3, 4);
            mskLicenseKey.Mask = ">AAAAA-AAAAA-AAAAA-AAAAA-AAAAA";
            mskLicenseKey.Name = "mskLicenseKey";
            mskLicenseKey.Size = new Size(472, 34);
            mskLicenseKey.TabIndex = 2;
            mskLicenseKey.Enter += mskLicenseKey_Enter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(162, 0, 0);
            label1.Location = new Point(553, 244);
            label1.Name = "label1";
            label1.Size = new Size(187, 29);
            label1.TabIndex = 3;
            label1.Text = "Lisans Anahtari: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkRed;
            label3.Location = new Point(14, 755);
            label3.Name = "label3";
            label3.Size = new Size(126, 20);
            label3.TabIndex = 6;
            label3.Text = "Lisans Anahtari";
            // 
            // lblLicenseKey
            // 
            lblLicenseKey.AutoSize = true;
            lblLicenseKey.BackColor = Color.Transparent;
            lblLicenseKey.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLicenseKey.ForeColor = Color.DarkRed;
            lblLicenseKey.Location = new Point(14, 779);
            lblLicenseKey.Name = "lblLicenseKey";
            lblLicenseKey.Size = new Size(308, 20);
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
            btnHideKey.Location = new Point(291, 763);
            btnHideKey.Margin = new Padding(3, 4, 3, 4);
            btnHideKey.Name = "btnHideKey";
            btnHideKey.Size = new Size(34, 40);
            btnHideKey.TabIndex = 8;
            btnHideKey.UseVisualStyleBackColor = false;
            btnHideKey.Visible = false;
            btnHideKey.Click += btnHideKey_Click;
            // 
            // lblRemaining
            // 
            lblRemaining.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRemaining.ForeColor = Color.FromArgb(162, 0, 0);
            lblRemaining.Location = new Point(517, 540);
            lblRemaining.Name = "lblRemaining";
            lblRemaining.Size = new Size(538, 25);
            lblRemaining.TabIndex = 14;
            lblRemaining.Text = "Lisansin kalan süresi: 30 gün";
            lblRemaining.TextAlign = ContentAlignment.MiddleCenter;
            lblRemaining.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(162, 0, 0);
            label2.Location = new Point(555, 101);
            label2.Name = "label2";
            label2.Size = new Size(291, 60);
            label2.TabIndex = 16;
            label2.Text = "System Initialization Status: True\r\nCooler Systems: Active\r\nBypassing Security Firewall: Success";
            // 
            // timer1
            // 
            timer1.Interval = 180000;
            timer1.Tick += timer1_Tick;
            // 
            // btnActivateLicense
            // 
            btnActivateLicense.BackgroundImage = Properties.Resources.pipis;
            btnActivateLicense.BackgroundImageLayout = ImageLayout.Center;
            btnActivateLicense.FlatAppearance.BorderSize = 0;
            btnActivateLicense.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnActivateLicense.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnActivateLicense.FlatStyle = FlatStyle.Flat;
            btnActivateLicense.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActivateLicense.ForeColor = Color.FromArgb(192, 0, 0);
            btnActivateLicense.Location = new Point(832, 324);
            btnActivateLicense.Margin = new Padding(3, 4, 3, 4);
            btnActivateLicense.Name = "btnActivateLicense";
            btnActivateLicense.Size = new Size(195, 67);
            btnActivateLicense.TabIndex = 17;
            btnActivateLicense.Text = "Aktiflestir";
            btnActivateLicense.UseVisualStyleBackColor = true;
            btnActivateLicense.Click += btnActivateLicense_Click;
            btnActivateLicense.MouseEnter += btnActivateLicense_MouseEnter;
            btnActivateLicense.MouseLeave += btnActivateLicense_MouseLeave;
            // 
            // btnInjectBot
            // 
            btnInjectBot.BackgroundImage = Properties.Resources.popos1;
            btnInjectBot.BackgroundImageLayout = ImageLayout.Stretch;
            btnInjectBot.FlatAppearance.BorderSize = 0;
            btnInjectBot.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnInjectBot.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnInjectBot.FlatStyle = FlatStyle.Flat;
            btnInjectBot.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInjectBot.ForeColor = Color.Red;
            btnInjectBot.Location = new Point(591, 369);
            btnInjectBot.Margin = new Padding(3, 4, 3, 4);
            btnInjectBot.Name = "btnInjectBot";
            btnInjectBot.Size = new Size(383, 167);
            btnInjectBot.TabIndex = 18;
            btnInjectBot.Text = "Botu Enjekte Et";
            btnInjectBot.UseVisualStyleBackColor = true;
            btnInjectBot.Visible = false;
            btnInjectBot.Click += btnInjectBot_Click_1;
            btnInjectBot.MouseEnter += btnInjectBot_MouseEnter;
            btnInjectBot.MouseLeave += btnInjectBot_MouseLeave;
            // 
            // frmClientMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.ultrakill_red_black_machine_robot_hd_wallpaper_08962df850a0cc58b08cc10e58b2040a3;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1058, 809);
            Controls.Add(btnInjectBot);
            Controls.Add(btnActivateLicense);
            Controls.Add(label2);
            Controls.Add(lblRemaining);
            Controls.Add(btnHideKey);
            Controls.Add(lblLicenseKey);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(mskLicenseKey);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
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
        private Label lblRemaining;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Button btnActivateLicense;
        private Button btnInjectBot;
    }
}
