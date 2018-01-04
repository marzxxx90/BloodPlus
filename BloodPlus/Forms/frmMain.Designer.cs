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
            this.bloodInventoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodDonationReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodRecipientReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodDonationReportToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodRecipientReportToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodDonorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodRecepientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importBloodDonorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTypeA = new System.Windows.Forms.Button();
            this.btnTypeB = new System.Windows.Forms.Button();
            this.btnTypeAB = new System.Windows.Forms.Button();
            this.btnTypeO = new System.Windows.Forms.Button();
            this.tBloodStatus = new System.Windows.Forms.Timer(this.components);
            this.lvNotify = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClear = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.tNotify = new System.Windows.Forms.Timer(this.components);
            this.btnTypeANeg = new System.Windows.Forms.Button();
            this.btnTypeBNeg = new System.Windows.Forms.Button();
            this.btnTypeABNeg = new System.Windows.Forms.Button();
            this.btnTypeONeg = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.msMenu.SuspendLayout();
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
            this.bloodInventoryReportToolStripMenuItem,
            this.dailyToolStripMenuItem,
            this.customToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(69, 25);
            this.reportToolStripMenuItem.Text = "&Report";
            // 
            // bloodInventoryReportToolStripMenuItem
            // 
            this.bloodInventoryReportToolStripMenuItem.Name = "bloodInventoryReportToolStripMenuItem";
            this.bloodInventoryReportToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.bloodInventoryReportToolStripMenuItem.Text = "Blood Inventory Report";
            this.bloodInventoryReportToolStripMenuItem.Click += new System.EventHandler(this.bloodInventoryReportToolStripMenuItem_Click);
            // 
            // dailyToolStripMenuItem
            // 
            this.dailyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bloodDonationReportToolStripMenuItem1,
            this.bloodRecipientReportToolStripMenuItem1});
            this.dailyToolStripMenuItem.Name = "dailyToolStripMenuItem";
            this.dailyToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.dailyToolStripMenuItem.Text = "&Daily";
            // 
            // bloodDonationReportToolStripMenuItem1
            // 
            this.bloodDonationReportToolStripMenuItem1.Name = "bloodDonationReportToolStripMenuItem1";
            this.bloodDonationReportToolStripMenuItem1.Size = new System.Drawing.Size(239, 26);
            this.bloodDonationReportToolStripMenuItem1.Text = "Blood Donation Report";
            this.bloodDonationReportToolStripMenuItem1.Click += new System.EventHandler(this.bloodDonationReportToolStripMenuItem1_Click);
            // 
            // bloodRecipientReportToolStripMenuItem1
            // 
            this.bloodRecipientReportToolStripMenuItem1.Name = "bloodRecipientReportToolStripMenuItem1";
            this.bloodRecipientReportToolStripMenuItem1.Size = new System.Drawing.Size(239, 26);
            this.bloodRecipientReportToolStripMenuItem1.Text = "Blood Recipient Report";
            this.bloodRecipientReportToolStripMenuItem1.Click += new System.EventHandler(this.bloodRecipientReportToolStripMenuItem1_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bloodDonationReportToolStripMenuItem2,
            this.bloodRecipientReportToolStripMenuItem2});
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.customToolStripMenuItem.Text = "&Custom";
            // 
            // bloodDonationReportToolStripMenuItem2
            // 
            this.bloodDonationReportToolStripMenuItem2.Name = "bloodDonationReportToolStripMenuItem2";
            this.bloodDonationReportToolStripMenuItem2.Size = new System.Drawing.Size(239, 26);
            this.bloodDonationReportToolStripMenuItem2.Text = "Blood Donation Report";
            this.bloodDonationReportToolStripMenuItem2.Click += new System.EventHandler(this.bloodDonationReportToolStripMenuItem2_Click);
            // 
            // bloodRecipientReportToolStripMenuItem2
            // 
            this.bloodRecipientReportToolStripMenuItem2.Name = "bloodRecipientReportToolStripMenuItem2";
            this.bloodRecipientReportToolStripMenuItem2.Size = new System.Drawing.Size(239, 26);
            this.bloodRecipientReportToolStripMenuItem2.Text = "Blood Recipient Report";
            this.bloodRecipientReportToolStripMenuItem2.Click += new System.EventHandler(this.bloodRecipientReportToolStripMenuItem2_Click);
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
            this.importBloodDonorToolStripMenuItem,
            this.clientListToolStripMenuItem});
            this.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem";
            this.TransactionToolStripMenuItem.Size = new System.Drawing.Size(102, 25);
            this.TransactionToolStripMenuItem.Text = "Transaction";
            // 
            // bloodDonorToolStripMenuItem
            // 
            this.bloodDonorToolStripMenuItem.Name = "bloodDonorToolStripMenuItem";
            this.bloodDonorToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.bloodDonorToolStripMenuItem.Text = "Blood Donor";
            this.bloodDonorToolStripMenuItem.Click += new System.EventHandler(this.bloodDonorToolStripMenuItem_Click);
            // 
            // bloodRecepientToolStripMenuItem
            // 
            this.bloodRecepientToolStripMenuItem.Name = "bloodRecepientToolStripMenuItem";
            this.bloodRecepientToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.bloodRecepientToolStripMenuItem.Text = "Blood Recepient";
            this.bloodRecepientToolStripMenuItem.Click += new System.EventHandler(this.bloodRecepientToolStripMenuItem_Click);
            // 
            // importBloodDonorToolStripMenuItem
            // 
            this.importBloodDonorToolStripMenuItem.Name = "importBloodDonorToolStripMenuItem";
            this.importBloodDonorToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.importBloodDonorToolStripMenuItem.Text = "Import Blood Donor";
            this.importBloodDonorToolStripMenuItem.Click += new System.EventHandler(this.importBloodDonorToolStripMenuItem_Click);
            // 
            // clientListToolStripMenuItem
            // 
            this.clientListToolStripMenuItem.Name = "clientListToolStripMenuItem";
            this.clientListToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.clientListToolStripMenuItem.Text = "Client List";
            this.clientListToolStripMenuItem.Click += new System.EventHandler(this.clientListToolStripMenuItem_Click);
            // 
            // btnTypeA
            // 
            this.btnTypeA.BackColor = System.Drawing.SystemColors.Control;
            this.btnTypeA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeA.Location = new System.Drawing.Point(12, 390);
            this.btnTypeA.Name = "btnTypeA";
            this.btnTypeA.Size = new System.Drawing.Size(160, 105);
            this.btnTypeA.TabIndex = 1;
            this.btnTypeA.Text = "Type A";
            this.btnTypeA.UseVisualStyleBackColor = false;
            // 
            // btnTypeB
            // 
            this.btnTypeB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeB.Location = new System.Drawing.Point(215, 390);
            this.btnTypeB.Name = "btnTypeB";
            this.btnTypeB.Size = new System.Drawing.Size(160, 105);
            this.btnTypeB.TabIndex = 2;
            this.btnTypeB.Text = "Type B";
            this.btnTypeB.UseVisualStyleBackColor = true;
            // 
            // btnTypeAB
            // 
            this.btnTypeAB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeAB.Location = new System.Drawing.Point(421, 390);
            this.btnTypeAB.Name = "btnTypeAB";
            this.btnTypeAB.Size = new System.Drawing.Size(160, 105);
            this.btnTypeAB.TabIndex = 3;
            this.btnTypeAB.Text = "Type AB";
            this.btnTypeAB.UseVisualStyleBackColor = true;
            // 
            // btnTypeO
            // 
            this.btnTypeO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeO.Location = new System.Drawing.Point(632, 390);
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
            // lvNotify
            // 
            this.lvNotify.CheckBoxes = true;
            this.lvNotify.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvNotify.FullRowSelect = true;
            this.lvNotify.GridLines = true;
            this.lvNotify.Location = new System.Drawing.Point(894, 390);
            this.lvNotify.Name = "lvNotify";
            this.lvNotify.Size = new System.Drawing.Size(464, 241);
            this.lvNotify.TabIndex = 5;
            this.lvNotify.UseCompatibleStateImageBehavior = false;
            this.lvNotify.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Notification";
            this.columnHeader1.Width = 1344;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(938, 637);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(130, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "&Clear Notification";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(895, 641);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 7;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
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
            this.btnTypeANeg.Location = new System.Drawing.Point(12, 526);
            this.btnTypeANeg.Name = "btnTypeANeg";
            this.btnTypeANeg.Size = new System.Drawing.Size(160, 105);
            this.btnTypeANeg.TabIndex = 8;
            this.btnTypeANeg.Text = "Type A-";
            this.btnTypeANeg.UseVisualStyleBackColor = false;
            // 
            // btnTypeBNeg
            // 
            this.btnTypeBNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeBNeg.Location = new System.Drawing.Point(215, 526);
            this.btnTypeBNeg.Name = "btnTypeBNeg";
            this.btnTypeBNeg.Size = new System.Drawing.Size(160, 105);
            this.btnTypeBNeg.TabIndex = 9;
            this.btnTypeBNeg.Text = "Type B-";
            this.btnTypeBNeg.UseVisualStyleBackColor = true;
            // 
            // btnTypeABNeg
            // 
            this.btnTypeABNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeABNeg.Location = new System.Drawing.Point(421, 526);
            this.btnTypeABNeg.Name = "btnTypeABNeg";
            this.btnTypeABNeg.Size = new System.Drawing.Size(160, 105);
            this.btnTypeABNeg.TabIndex = 10;
            this.btnTypeABNeg.Text = "Type AB-";
            this.btnTypeABNeg.UseVisualStyleBackColor = true;
            // 
            // btnTypeONeg
            // 
            this.btnTypeONeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeONeg.Location = new System.Drawing.Point(632, 526);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(656, 146);
            this.label1.TabIndex = 12;
            this.label1.Text = "Blood Bank \r\nManagement System";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 672);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTypeONeg);
            this.Controls.Add(this.btnTypeABNeg);
            this.Controls.Add(this.btnTypeBNeg);
            this.Controls.Add(this.btnTypeANeg);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lvNotify);
            this.Controls.Add(this.btnTypeO);
            this.Controls.Add(this.btnTypeAB);
            this.Controls.Add(this.btnTypeB);
            this.Controls.Add(this.btnTypeA);
            this.Controls.Add(this.msMenu);
            this.MainMenuStrip = this.msMenu;
            this.Name = "frmMain";
            this.Text = "Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem importBloodDonorToolStripMenuItem;
        private System.Windows.Forms.Button btnTypeA;
        private System.Windows.Forms.ToolStripMenuItem clientListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloodInventoryReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button btnTypeB;
        private System.Windows.Forms.Button btnTypeAB;
        private System.Windows.Forms.Button btnTypeO;
        private System.Windows.Forms.Timer tBloodStatus;
        private System.Windows.Forms.ListView lvNotify;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkAll;
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
    }
}