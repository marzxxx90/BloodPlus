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
    public partial class frmDonor : Form
    {
        public frmDonor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isValid()) { return; }


        }

        private bool isValid()
        {
            if (txtCardNum.Text == "") { return false; }
            if (cboBloodType.Text == "") { return false; }
            if (txtFirstname.Text == "") { return false; }
            if (txtLastname.Text == "") { return false; }
            if (cboGender.Text == "") { return false; }

            return true;
        }

    }
}
