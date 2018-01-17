using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace BloodPlus
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            Maintenance set = new Maintenance();
            set.UpdateSettings("ParLevel", Convert.ToString((nudParLevel.Value)));

            MessageBox.Show("Successfully Set","Information");
            this.Close();
        }

        private void nudParLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) { btnSet.PerformClick(); }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            Maintenance getOption = new Maintenance();
            nudParLevel.Value = Convert.ToInt16(getOption.GetSettingsVal("ParLevel"));

            foreach (string tmpPrinterName in PrinterSettings.InstalledPrinters)
            {
                cboPrinter.Items.Add(tmpPrinterName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateOption("PrinterSetup",cboPrinter.Text);
            MessageBox.Show("Successfully Set!","Maintenance");
            this.Close();
        }

        internal void UpdateOption(string key, string val)
        {
            string mysql = "Select * From tblMaintenance Where M_Key = '" + key + "'";
            DataSet ds = Database.LoadSQL(mysql, "tblMaintenance");

            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow dsNewRow = null;
                dsNewRow = ds.Tables[0].NewRow();
                var with = dsNewRow;
                with["M_Key"] = key;
                with["M_Value"] = val;
                ds.Tables[0].Rows.Add(dsNewRow);
                Database.SaveEntry(ds, true);
            }
            else
            {
                var with = ds.Tables[0].Rows[0];
                with["M_Value"] = val;
                Database.SaveEntry(ds, false);
            }
        }
    }
}
