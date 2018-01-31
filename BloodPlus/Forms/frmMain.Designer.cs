namespace BloodPlus
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodDonationReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodRecipientReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodInventoryReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodDonationReportToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodRecipientReportToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodInventoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodDonorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodRecepientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movingAverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTypeA = new System.Windows.Forms.Button();
            this.btnTypeB = new System.Windows.Forms.Button();
            this.btnTypeAB = new System.Windows.Forms.Button();
            this.btnTypeO = new System.Windows.Forms.Button();
            this.tBloodStatus = new System.Windows.Forms.Timer(this.components);
            this.tNotify = new System.Windows.Forms.Timer(this.components);
            this.btnTypeANeg = new System.Windows.Forms.Button();
            this.btnTypeBNeg = new System.Windows.Forms.Button();
            this.btnTypeABNeg = new System.Windows.Forms.Button();
            this.btnTypeONeg = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pButtons = new System.Windows.Forms.Panel();
            this.btnHide = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.msMenu.SuspendLayout();
            this.pButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.maintenanceToolStripMenuItem,
            this.TransactionToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1370, 29);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.logoutToolStripMenuItem.Text = "&Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyToolStripMenuItem,
            this.customToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(69, 25);
            this.reportToolStripMenuItem.Text = "&Report";
            // 
            // dailyToolStripMenuItem
            // 
            this.dailyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bloodDonationReportToolStripMenuItem1,
            this.bloodRecipientReportToolStripMenuItem1,
            this.bloodInventoryReportToolStripMenuItem1});
            this.dailyToolStripMenuItem.Name = "dailyToolStripMenuItem";
            this.dailyToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.dailyToolStripMenuItem.Text = "&Daily";
            // 
            // bloodDonationReportToolStripMenuItem1
            // 
            this.bloodDonationReportToolStripMenuItem1.Name = "bloodDonationReportToolStripMenuItem1";
            this.bloodDonationReportToolStripMenuItem1.Size = new System.Drawing.Size(241, 26);
            this.bloodDonationReportToolStripMenuItem1.Text = "Blood Donation Report";
            this.bloodDonationReportToolStripMenuItem1.Click += new System.EventHandler(this.bloodDonationReportToolStripMenuItem1_Click);
            // 
            // bloodRecipientReportToolStripMenuItem1
            // 
            this.bloodRecipientReportToolStripMenuItem1.Name = "bloodRecipientReportToolStripMenuItem1";
            this.bloodRecipientReportToolStripMenuItem1.Size = new System.Drawing.Size(241, 26);
            this.bloodRecipientReportToolStripMenuItem1.Text = "Blood Recipient Report";
            this.bloodRecipientReportToolStripMenuItem1.Click += new System.EventHandler(this.bloodRecipientReportToolStripMenuItem1_Click);
            // 
            // bloodInventoryReportToolStripMenuItem1
            // 
            this.bloodInventoryReportToolStripMenuItem1.Name = "bloodInventoryReportToolStripMenuItem1";
            this.bloodInventoryReportToolStripMenuItem1.Size = new System.Drawing.Size(241, 26);
            this.bloodInventoryReportToolStripMenuItem1.Text = "Blood Inventory Report";
            this.bloodInventoryReportToolStripMenuItem1.Click += new System.EventHandler(this.bloodInventoryReportToolStripMenuItem1_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bloodDonationReportToolStripMenuItem2,
            this.bloodRecipientReportToolStripMenuItem2,
            this.bloodInventoryReportToolStripMenuItem});
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.customToolStripMenuItem.Text = "&Custom";
            // 
            // bloodDonationReportToolStripMenuItem2
            // 
            this.bloodDonationReportToolStripMenuItem2.Name = "bloodDonationReportToolStripMenuItem2";
            this.bloodDonationReportToolStripMenuItem2.Size = new System.Drawing.Size(241, 26);
            this.bloodDonationReportToolStripMenuItem2.Text = "Blood Donation Report";
            this.bloodDonationReportToolStripMenuItem2.Click += new System.EventHandler(this.bloodDonationReportToolStripMenuItem2_Click);
            // 
            // bloodRecipientReportToolStripMenuItem2
            // 
            this.bloodRecipientReportToolStripMenuItem2.Name = "bloodRecipientReportToolStripMenuItem2";
            this.bloodRecipientReportToolStripMenuItem2.Size = new System.Drawing.Size(241, 26);
            this.bloodRecipientReportToolStripMenuItem2.Text = "Blood Recipient Report";
            this.bloodRecipientReportToolStripMenuItem2.Click += new System.EventHandler(this.bloodRecipientReportToolStripMenuItem2_Click);
            // 
            // bloodInventoryReportToolStripMenuItem
            // 
            this.bloodInventoryReportToolStripMenuItem.Name = "bloodInventoryReportToolStripMenuItem";
            this.bloodInventoryReportToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.bloodInventoryReportToolStripMenuItem.Text = "Blood Inventory Report";
            this.bloodInventoryReportToolStripMenuItem.Click += new System.EventHandler(this.bloodInventoryReportToolStripMenuItem_Click);
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManagementToolStripMenuItem});
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(111, 25);
            this.maintenanceToolStripMenuItem.Text = "&Maintenance";
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.userManagementToolStripMenuItem.Text = "&User Management";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // TransactionToolStripMenuItem
            // 
            this.TransactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bloodDonorToolStripMenuItem,
            this.bloodRecepientToolStripMenuItem,
            this.clientListToolStripMenuItem,
            this.movingAverageToolStripMenuItem});
            this.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem";
            this.TransactionToolStripMenuItem.Size = new System.Drawing.Size(102, 25);
            this.TransactionToolStripMenuItem.Text = "Transaction";
            // 
            // bloodDonorToolStripMenuItem
            // 
            this.bloodDonorToolStripMenuItem.Name = "bloodDonorToolStripMenuItem";
            this.bloodDonorToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.bloodDonorToolStripMenuItem.Text = "Blood Donor";
            this.bloodDonorToolStripMenuItem.Click += new System.EventHandler(this.bloodDonorToolStripMenuItem_Click);
            // 
            // bloodRecepientToolStripMenuItem
            // 
            this.bloodRecepientToolStripMenuItem.Name = "bloodRecepientToolStripMenuItem";
            this.bloodRecepientToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.bloodRecepientToolStripMenuItem.Text = "Blood Recipient";
            this.bloodRecepientToolStripMenuItem.Click += new System.EventHandler(this.bloodRecepientToolStripMenuItem_Click);
            // 
            // clientListToolStripMenuItem
            // 
            this.clientListToolStripMenuItem.Name = "clientListToolStripMenuItem";
            this.clientListToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.clientListToolStripMenuItem.Text = "Client List";
            this.clientListToolStripMenuItem.Click += new System.EventHandler(this.clientListToolStripMenuItem_Click);
            // 
            // movingAverageToolStripMenuItem
            // 
            this.movingAverageToolStripMenuItem.Name = "movingAverageToolStripMenuItem";
            this.movingAverageToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.movingAverageToolStripMenuItem.Text = "Moving Average";
            this.movingAverageToolStripMenuItem.Click += new System.EventHandler(this.movingAverageToolStripMenuItem_Click);
            // 
            // btnTypeA
            // 
            this.btnTypeA.BackColor = System.Drawing.SystemColors.Control;
            this.btnTypeA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeA.Location = new System.Drawing.Point(3, 3);
            this.btnTypeA.Name = "btnTypeA";
            this.btnTypeA.Size = new System.Drawing.Size(160, 105);
            this.btnTypeA.TabIndex = 1;
            this.btnTypeA.Text = "Type A";
            this.btnTypeA.UseVisualStyleBackColor = false;
            // 
            // btnTypeB
            // 
            this.btnTypeB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeB.Location = new System.Drawing.Point(192, 3);
            this.btnTypeB.Name = "btnTypeB";
            this.btnTypeB.Size = new System.Drawing.Size(160, 105);
            this.btnTypeB.TabIndex = 2;
            this.btnTypeB.Text = "Type B";
            this.btnTypeB.UseVisualStyleBackColor = true;
            // 
            // btnTypeAB
            // 
            this.btnTypeAB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeAB.Location = new System.Drawing.Point(381, 3);
            this.btnTypeAB.Name = "btnTypeAB";
            this.btnTypeAB.Size = new System.Drawing.Size(160, 105);
            this.btnTypeAB.TabIndex = 3;
            this.btnTypeAB.Text = "Type AB";
            this.btnTypeAB.UseVisualStyleBackColor = true;
            // 
            // btnTypeO
            // 
            this.btnTypeO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeO.Location = new System.Drawing.Point(570, 3);
            this.btnTypeO.Name = "btnTypeO";
            this.btnTypeO.Size = new System.Drawing.Size(160, 105);
            this.btnTypeO.TabIndex = 4;
            this.btnTypeO.Text = "Type O";
            this.btnTypeO.UseVisualStyleBackColor = true;
            // 
            // tBloodStatus
            // 
            this.tBloodStatus.Interval = 5000;
            this.tBloodStatus.Tick += new System.EventHandler(this.tBloodStatus_Tick);
            // 
            // tNotify
            // 
            this.tNotify.Interval = 60000;
            this.tNotify.Tick += new System.EventHandler(this.tNotify_Tick);
            // 
            // btnTypeANeg
            // 
            this.btnTypeANeg.BackColor = System.Drawing.SystemColors.Control;
            this.btnTypeANeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeANeg.Location = new System.Drawing.Point(3, 139);
            this.btnTypeANeg.Name = "btnTypeANeg";
            this.btnTypeANeg.Size = new System.Drawing.Size(160, 105);
            this.btnTypeANeg.TabIndex = 8;
            this.btnTypeANeg.Text = "Type A-";
            this.btnTypeANeg.UseVisualStyleBackColor = false;
            // 
            // btnTypeBNeg
            // 
            this.btnTypeBNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeBNeg.Location = new System.Drawing.Point(192, 139);
            this.btnTypeBNeg.Name = "btnTypeBNeg";
            this.btnTypeBNeg.Size = new System.Drawing.Size(160, 105);
            this.btnTypeBNeg.TabIndex = 9;
            this.btnTypeBNeg.Text = "Type B-";
            this.btnTypeBNeg.UseVisualStyleBackColor = true;
            // 
            // btnTypeABNeg
            // 
            this.btnTypeABNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeABNeg.Location = new System.Drawing.Point(381, 139);
            this.btnTypeABNeg.Name = "btnTypeABNeg";
            this.btnTypeABNeg.Size = new System.Drawing.Size(160, 105);
            this.btnTypeABNeg.TabIndex = 10;
            this.btnTypeABNeg.Text = "Type AB-";
            this.btnTypeABNeg.UseVisualStyleBackColor = true;
            // 
            // btnTypeONeg
            // 
            this.btnTypeONeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeONeg.Location = new System.Drawing.Point(570, 139);
            this.btnTypeONeg.Name = "btnTypeONeg";
            this.btnTypeONeg.Size = new System.Drawing.Size(160, 105);
            this.btnTypeONeg.TabIndex = 11;
            this.btnTypeONeg.Text = "Type O-";
            this.btnTypeONeg.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(564, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 54);
            this.label1.TabIndex = 12;
            this.label1.Text = "Blood Bank";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(468, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(472, 54);
            this.label2.TabIndex = 13;
            this.label2.Text = "Management System";
            // 
            // pButtons
            // 
            this.pButtons.BackColor = System.Drawing.Color.Transparent;
            this.pButtons.Controls.Add(this.btnRefresh);
            this.pButtons.Controls.Add(this.btnHide);
            this.pButtons.Controls.Add(this.btnTypeA);
            this.pButtons.Controls.Add(this.btnTypeB);
            this.pButtons.Controls.Add(this.btnTypeAB);
            this.pButtons.Controls.Add(this.btnTypeONeg);
            this.pButtons.Controls.Add(this.btnTypeO);
            this.pButtons.Controls.Add(this.btnTypeABNeg);
            this.pButtons.Controls.Add(this.btnTypeANeg);
            this.pButtons.Controls.Add(this.btnTypeBNeg);
            this.pButtons.Location = new System.Drawing.Point(-750, 406);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(796, 258);
            this.pButtons.TabIndex = 14;
            // 
            // btnHide
            // 
            this.btnHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.Location = new System.Drawing.Point(753, 3);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(33, 31);
            this.btnHide.TabIndex = 12;
            this.btnHide.Text = "=";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(621, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(753, 54);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(33, 31);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 672);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pButtons);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msMenu);
            this.MainMenuStrip = this.msMenu;
            this.Name = "frmMain";
            this.Text = "Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.pButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloodDonorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloodRecepientToolStripMenuItem;
        private System.Windows.Forms.Button btnTypeA;
        private System.Windows.Forms.ToolStripMenuItem clientListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button btnTypeB;
        private System.Windows.Forms.Button btnTypeAB;
        private System.Windows.Forms.Button btnTypeO;
        private System.Windows.Forms.Timer tBloodStatus;
        private System.Windows.Forms.Timer tNotify;
        private System.Windows.Forms.ToolStripMenuItem dailyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloodDonationReportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bloodRecipientReportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloodDonationReportToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bloodRecipientReportToolStripMenuItem2;
        private System.Windows.Forms.Button btnTypeANeg;
        private System.Windows.Forms.Button btnTypeBNeg;
        private System.Windows.Forms.Button btnTypeABNeg;
        private System.Windows.Forms.Button btnTypeONeg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem movingAverageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloodInventoryReportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bloodInventoryReportToolStripMenuItem;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnRefresh;
    }
}