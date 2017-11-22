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
            this.lvDev = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dsReportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.rvSample = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lvDev
            // 
            this.lvDev.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvDev.FullRowSelect = true;
            this.lvDev.GridLines = true;
            this.lvDev.Location = new System.Drawing.Point(3, 12);
            this.lvDev.Name = "lvDev";
            this.lvDev.Size = new System.Drawing.Size(649, 157);
            this.lvDev.TabIndex = 0;
            this.lvDev.UseCompatibleStateImageBehavior = false;
            this.lvDev.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 74;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 259;
            // 
            // dsReportsBindingSource
            // 
            this.dsReportsBindingSource.DataMember = "MonthlySum";
            this.dsReportsBindingSource.DataSource = typeof(BloodPlus.Reports.dsReports);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(699, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 85);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rvSample
            // 
            this.rvSample.Location = new System.Drawing.Point(3, 175);
            this.rvSample.Name = "rvSample";
            this.rvSample.Size = new System.Drawing.Size(858, 318);
            this.rvSample.TabIndex = 3;
            // 
            // devMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 505);
            this.Controls.Add(this.rvSample);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvDev);
            this.Name = "devMonitor";
            this.Text = "dev";
            this.Load += new System.EventHandler(this.dev_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsReportsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvDev;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.BindingSource dsReportsBindingSource;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer rvSample;
    }
}