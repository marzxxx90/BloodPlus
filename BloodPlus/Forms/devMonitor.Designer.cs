namespace BloodPlus
{
    partial class devMonitor
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
            this.dsReportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.ofdImport = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pbStatus = new System.Windows.Forms.ProgressBar();
            this.chkRandom = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dsReportsBindingSource
            // 
            this.dsReportsBindingSource.DataMember = "MonthlySum";
            this.dsReportsBindingSource.DataSource = typeof(BloodPlus.Reports.dsReports);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(498, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 85);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 22);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(35, 13);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "label1";
            // 
            // ofdImport
            // 
            this.ofdImport.Filter = "Excel 2007|*.xlsx";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(15, 38);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 29);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(3, 113);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(622, 23);
            this.pbStatus.TabIndex = 5;
            // 
            // chkRandom
            // 
            this.chkRandom.AutoSize = true;
            this.chkRandom.Location = new System.Drawing.Point(352, 31);
            this.chkRandom.Name = "chkRandom";
            this.chkRandom.Size = new System.Drawing.Size(80, 17);
            this.chkRandom.TabIndex = 6;
            this.chkRandom.Text = "checkBox1";
            this.chkRandom.UseVisualStyleBackColor = true;
            // 
            // devMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 139);
            this.Controls.Add(this.chkRandom);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.button1);
            this.Name = "devMonitor";
            this.Text = "dev";
            this.Load += new System.EventHandler(this.dev_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsReportsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dsReportsBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.OpenFileDialog ofdImport;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ProgressBar pbStatus;
        private System.Windows.Forms.CheckBox chkRandom;
    }
}