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
    public partial class frmPersonInfo : Form
    {
        PersonInfo PersonalInformation;
        public frmPersonInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "&Save")
            {
                if (!isValid()) { return; }
                PersonInfo Reg = new PersonInfo();
                Reg.Firstname = txtFirstname.Text;
                Reg.Middlename = txtMiddlename.Text;
                Reg.Lastname = txtLastname.Text;
                Reg.Gender = cboGender.Text;
                Reg.DateofBirth = Convert.ToDateTime(dtpDob.Text);
                Reg.MaritalStatus = cboMaritalStatus.Text;
                Reg.ContactNum = txtContactNum.Text;
                Reg.PresentStreet = txtPreStreet.Text;
                Reg.PresentBarangay = cboPreBarangay.Text;
                Reg.PresentCity = cboPreCity.Text;
                Reg.PresentProvince = cboPreProvince.Text;
                Reg.PresentZipCode = txtPreZipcode.Text;
                Reg.PermanentStreet = txtPerStreet.Text;
                Reg.PermanentBarangay = cboPerBarangay.Text;
                Reg.PermanentCity = cboPerCity.Text;
                Reg.PermanentProvince = cboPerProvince.Text;
                Reg.PermanentZipcode = txtPerZipcode.Text;
                Reg.SaveRecepient();

                MessageBox.Show("Successfully Saved!", "Information");
            }
            else
            {
                var Reg = PersonalInformation;
                Reg.Firstname = txtFirstname.Text;
                Reg.Middlename = txtMiddlename.Text;
                Reg.Lastname = txtLastname.Text;
                Reg.Gender = cboGender.Text;
                Reg.DateofBirth = Convert.ToDateTime(dtpDob.Text);
                Reg.MaritalStatus = cboMaritalStatus.Text;
                Reg.ContactNum = txtContactNum.Text;
                Reg.PresentStreet = txtPreStreet.Text;
                Reg.PresentBarangay = cboPreBarangay.Text;
                Reg.PresentCity = cboPreCity.Text;
                Reg.PresentProvince = cboPreProvince.Text;
                Reg.PresentZipCode = txtPreZipcode.Text;
                Reg.PermanentStreet = txtPerStreet.Text;
                Reg.PermanentBarangay = cboPerBarangay.Text;
                Reg.PermanentCity = cboPerCity.Text;
                Reg.PermanentProvince = cboPerProvince.Text;
                Reg.PermanentZipcode = txtPerZipcode.Text;
                Reg.UpdatePersonInfo ();

                MessageBox.Show("Successfully Updated!", "Information");
            }
            ClearText();
            this.Close();
        }

        private  bool isValid()
        {
            if (txtFirstname.Text == "") { MessageBox.Show("Invalid Firstname", "Warning. . ."); txtFirstname.Focus() ;return false; }
            if (txtLastname.Text == "") { MessageBox.Show("Invalid Lastname", "Warning. . ."); txtLastname.Focus() ; return false;}
            if (cboGender.Text == "") { MessageBox.Show("Invalid Gender", "Warning. . ."); cboGender.Focus(); return false; }
            //if (dtpDob.Text )
            
            return true;
        }

        private void ClearText()
        {
            txtFirstname.Clear();
            txtMiddlename.Clear();
            txtLastname.Clear();
            txtContactNum.Clear();
            txtPerStreet.Clear();
            txtPreStreet.Clear();
            txtPreZipcode.Clear();
            txtPerZipcode.Clear();
        }

        private void frmPersonInfo_Load(object sender, EventArgs e)
        {
            ClearText();
        }

        internal void LoadPersonInfo(PersonInfo info)
        {
            txtFirstname.Text = info.Firstname;
            txtMiddlename.Text = info.Middlename;
            txtLastname.Text = info.Lastname;
            if (info.Gender == "F")
            {
                cboGender.Text = "Female";
                txtFirstname.Enabled = false;
                txtMiddlename.Enabled = false;
               
            }
            else
            {
                cboGender.Text = "Male";
                txtFirstname.Enabled = false;
                txtMiddlename.Enabled = false;
                txtLastname.Enabled = false;
            }
            dtpDob.Value = info.DateofBirth;
            cboMaritalStatus.Text = info.MaritalStatus;
            txtContactNum.Text = info.ContactNum;
            txtPreStreet.Text = info.PresentStreet;
            cboPreBarangay.Text = info.PresentBarangay;
            cboPreCity.Text = info.PresentCity;
            cboPreProvince.Text = info.PresentProvince;
            txtPreZipcode.Text = info.PresentZipCode;
            txtPerStreet.Text = info.PermanentStreet;
            cboPerBarangay.Text = info.PermanentBarangay;
            cboPerCity.Text = info.PermanentCity;
            cboPerProvince.Text = info.PermanentProvince;
            txtPerZipcode.Text = info.PermanentZipcode;

            dtpDob.Enabled = false;
            btnSave.Text = "&Update";
            PersonalInformation = info;
        }

        private void txtContactNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }

        private void txtPreZipcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }

        private void txtPerZipcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            mod_system.DigitOnly(e);
        }

        private void chkAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAddress.Checked == true)
            {
                txtPerStreet.Text = txtPreStreet.Text;
                txtPerZipcode.Text = txtPreZipcode.Text;
                cboPerBarangay.Text = cboPreBarangay.Text;
                cboPerCity.Text = cboPreCity.Text;
                cboPerProvince.Text = cboPreProvince.Text;
            }
            else
            {
                txtPerStreet.Clear();
                txtPerZipcode.Clear();
            }
        }
    }
}
