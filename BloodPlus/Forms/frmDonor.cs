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
            BloodDonor donate = new BloodDonor();
            var d = donate;
            d.CardNum = txtCardNum.Text;
            d.BloodType = cboBloodType.Text;
            d.FirstName = txtFirstname.Text;
            d.MiddleName = txtMiddlename.Text;
            d.LastName = txtLastname.Text;
            d.Gender = cboGender.Text;
            d.DocDate = DateTime.Now;
            d.SaveBloodDonor();

            MessageBox.Show("Successfully Saved", "Information"); ClearText();
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

        private void frmDonor_Load(object sender, EventArgs e)
        {
            LoadBlood();
        }

        private void LoadBlood()
        {
            string mysql = "Select * From tblStock";
            DataSet ds = Database.LoadSQL(mysql, "tblStock");
            foreach (DataRow  dr in ds.Tables[0].Rows)
            {
                cboBloodType.Items.Add(dr["BloodType"]);
                
            }

        }

        private void ClearText()
        {
            txtCardNum.Clear();
            txtFirstname.Clear();
            txtMiddlename.Clear();
            txtLastname.Clear();
        }
        private void txtCardNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }
    }
}
