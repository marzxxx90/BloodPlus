using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        }

        private void nudParLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) { btnSet.PerformClick(); }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            Maintenance getOption = new Maintenance();
            nudParLevel.Value = Convert.ToInt16(getOption.GetSettingsVal("ParLevel"));
        }
    }
}
