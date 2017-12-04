﻿namespace BloodPlus
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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodDonorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodRecepientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importBloodDonorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodReleaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnAB = new System.Windows.Forms.Button();
            this.btnO = new System.Windows.Forms.Button();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.maintenanceToolStripMenuItem,
            this.TransactionToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1063, 24);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "&Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "&Report";
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManagementToolStripMenuItem});
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.maintenanceToolStripMenuItem.Text = "&Maintenance";
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.userManagementToolStripMenuItem.Text = "&User Management";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // TransactionToolStripMenuItem
            // 
            this.TransactionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bloodDonorToolStripMenuItem,
            this.bloodCountToolStripMenuItem,
            this.bloodRecepientToolStripMenuItem,
            this.importBloodDonorToolStripMenuItem,
            this.bloodReleaseToolStripMenuItem});
            this.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem";
            this.TransactionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.TransactionToolStripMenuItem.Text = "Transaction";
            // 
            // bloodDonorToolStripMenuItem
            // 
            this.bloodDonorToolStripMenuItem.Name = "bloodDonorToolStripMenuItem";
            this.bloodDonorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bloodDonorToolStripMenuItem.Text = "Blood Donor";
            this.bloodDonorToolStripMenuItem.Click += new System.EventHandler(this.bloodDonorToolStripMenuItem_Click);
            // 
            // bloodCountToolStripMenuItem
            // 
            this.bloodCountToolStripMenuItem.Name = "bloodCountToolStripMenuItem";
            this.bloodCountToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bloodCountToolStripMenuItem.Text = "Blood Count";
            this.bloodCountToolStripMenuItem.Click += new System.EventHandler(this.bloodCountToolStripMenuItem_Click);
            // 
            // bloodRecepientToolStripMenuItem
            // 
            this.bloodRecepientToolStripMenuItem.Name = "bloodRecepientToolStripMenuItem";
            this.bloodRecepientToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bloodRecepientToolStripMenuItem.Text = "Blood Recepient";
            this.bloodRecepientToolStripMenuItem.Click += new System.EventHandler(this.bloodRecepientToolStripMenuItem_Click);
            // 
            // importBloodDonorToolStripMenuItem
            // 
            this.importBloodDonorToolStripMenuItem.Name = "importBloodDonorToolStripMenuItem";
            this.importBloodDonorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importBloodDonorToolStripMenuItem.Text = "Import Blood Donor";
            this.importBloodDonorToolStripMenuItem.Click += new System.EventHandler(this.importBloodDonorToolStripMenuItem_Click);
            // 
            // bloodReleaseToolStripMenuItem
            // 
            this.bloodReleaseToolStripMenuItem.Name = "bloodReleaseToolStripMenuItem";
            this.bloodReleaseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bloodReleaseToolStripMenuItem.Text = "Blood Release";
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(36, 64);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(161, 119);
            this.btnA.TabIndex = 2;
            this.btnA.Text = "Type A";
            this.btnA.UseVisualStyleBackColor = true;
            this.btnA.MouseHover += new System.EventHandler(this.button2_MouseHover);
            // 
            // btnB
            // 
            this.btnB.Location = new System.Drawing.Point(236, 64);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(161, 119);
            this.btnB.TabIndex = 3;
            this.btnB.Text = "Type B";
            this.btnB.UseVisualStyleBackColor = true;
            // 
            // btnAB
            // 
            this.btnAB.Location = new System.Drawing.Point(429, 64);
            this.btnAB.Name = "btnAB";
            this.btnAB.Size = new System.Drawing.Size(161, 119);
            this.btnAB.TabIndex = 4;
            this.btnAB.Text = "Type AB";
            this.btnAB.UseVisualStyleBackColor = true;
            // 
            // btnO
            // 
            this.btnO.Location = new System.Drawing.Point(614, 64);
            this.btnO.Name = "btnO";
            this.btnO.Size = new System.Drawing.Size(161, 119);
            this.btnO.TabIndex = 5;
            this.btnO.Text = "Type O";
            this.btnO.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 485);
            this.Controls.Add(this.btnO);
            this.Controls.Add(this.btnAB);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.msMenu);
            this.MainMenuStrip = this.msMenu;
            this.Name = "frmMain";
            this.Text = "Main Form";
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
        private System.Windows.Forms.ToolStripMenuItem bloodCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloodRecepientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importBloodDonorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloodReleaseToolStripMenuItem;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnAB;
        private System.Windows.Forms.Button btnO;
    }
}