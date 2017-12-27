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
        PersonInfo Donor;
        public frmDonor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isValid()) { MessageBox.Show("Please Check the Fields!", "Error"); return; }

            BloodDonor donate = new BloodDonor();
            var d = donate;
            d.CardNum = txtCardNum.Text;
            d.BloodType = cboBloodType.Text;
            //d.FirstName = txtFirstname.Text;
            //d.MiddleName = txtMiddlename.Text;
            //d.LastName = txtLastname.Text;
            //d.Gender = cboGender.Text;
            d.Recepient = Donor;
            d.DocDate = DateTime.Now;
            d.EncodeBy = mod_system.bloodUser.ID;
            d.SaveBloodDonor();

            d.AddInv(cboBloodType.Text);
            MessageBox.Show("Successfully Saved", "Information"); ClearText();
            this.Close();
        }

        private bool isValid()
        {
            if (txtCardNum.Text == "") { return false; }
            if (cboBloodType.Text == "") { return false; }
            //if (txtFirstname.Text == "") { return false; }
            //if (txtLastname.Text == "") { return false; }
            //if (cboGender.Text == "") { return false; }
            if (Donor == null) { return false; }

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
            txtGender.Clear();
            txtDob.Clear();
            txtSearchRecepient.Clear();
        }
        private void txtCardNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }

        private void btnSearchRecepient_Click(object sender, EventArgs e)
        {
            frmPersonList frm = new frmPersonList();
            frm.SearchSelect(txtSearchRecepient.Text, FormChange.FormName.DonorBlood);
            frm.Show();
        }

        internal void LoadRecepientInfo(PersonInfo info)
        {
            string tmpGender;
            txtFirstname.Text = info.Firstname;
            txtMiddlename.Text = info.Middlename;
            txtLastname.Text = info.Lastname;
            if (Convert.ToString(info.Gender) == "F")
            {
                tmpGender = "Female";
            }
            else 
            {
                tmpGender = "Male";
            }
            txtGender.Text = tmpGender ;
            txtDob.Text = Convert.ToString(info.DateofBirth.ToString("yyyy-mm-dd"));
            txtCardNum.Text = 
            Donor = info;
        }

        private void txtSearchRecepient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) { btnSearchRecepient.PerformClick(); }
        }
    }
}
