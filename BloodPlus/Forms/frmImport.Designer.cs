namespace BloodPlus
{
    partial class frmImport
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
            this.ofdImport = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.lvImport = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnImport = new System.Windows.Forms.Button();
            this.chkRandom = new System.Windows.Forms.CheckBox();
            this.pbStatus = new System.Windows.Forms.ProgressBar();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ofdImport
            // 
            this.ofdImport.Filter = "Excel 2007|*.xlsx";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 34);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 29);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 18);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(35, 13);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "label1";
            // 
            // lvImport
            // 
            this.lvImport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvImport.FullRowSelect = true;
            this.lvImport.GridLines = true;
            this.lvImport.Location = new System.Drawing.Point(12, 69);
            this.lvImport.Name = "lvImport";
            this.lvImport.Size = new System.Drawing.Size(1032, 355);
            this.lvImport.TabIndex = 2;
            this.lvImport.UseCompatibleStateImageBehavior = false;
            this.lvImport.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Card Number";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Blood Type";
            this.columnHeader2.Width = 91;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "FirstName";
            this.columnHeader3.Width = 173;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "MiddleName";
            this.columnHeader4.Width = 137;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "LastName";
            this.columnHeader5.Width = 185;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Gender";
            this.columnHeader6.Width = 96;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Date of Birth";
            this.columnHeader7.Width = 120;
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(969, 430);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 29);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "&Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // chkRandom
            // 
            this.chkRandom.AutoSize = true;
            this.chkRandom.Location = new System.Drawing.Point(952, 41);
            this.chkRandom.Name = "chkRandom";
            this.chkRandom.Size = new System.Drawing.Size(92, 17);
            this.chkRandom.TabIndex = 4;
            this.chkRandom.Text = "Random Date";
            this.chkRandom.UseVisualStyleBackColor = true;
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(15, 432);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(948, 23);
            this.pbStatus.TabIndex = 5;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Contact No";
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Status";
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 465);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.chkRandom);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lvImport);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnBrowse);
            this.Name = "frmImport";
            this.Text = "Excel Importer";
            this.Load += new System.EventHandler(this.frmImport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdImport;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.ListView lvImport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.CheckBox chkRandom;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ProgressBar pbStatus;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}