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
    public partial class frmRecipDonor : Form
    {
        PersonInfo Donor;
        PersonInfo Recipient;
        BloodRecipient BloodRecip;
        BloodDonor BloodDo;
        internal  bool isNewTransaction;
        public frmRecipDonor()
        {
            InitializeComponent();
        }

        private void rbDonor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDonor.Checked == true) { EnableRefNum(true); }
        }

        private void EnableRefNum(bool st)
        {
            txtCardNum.Enabled = st;
            if (st == false) { txtCardNum.Clear(); }
        }

        private void rbRecipient_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRecipient.Checked == true) { EnableRefNum(false); }
        }

        private void frmRecipDonor_Load(object sender, EventArgs e)
        {
            if (isNewTransaction == true)
            {
                gbSearch.Enabled = false;
            }
            else 
            {
                gbSearch.Enabled = true;
            }

            string mysql = "Select * From tblStock";
            DataSet ds = Database.LoadSQL(mysql, "tblStock");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                 cboBloodType.Items.Add(dr["BloodType"].ToString() );
            }
        }

        private void btnSearchRecepient_Click(object sender, EventArgs e)
        {
            frmPersonList frm = new frmPersonList();
            frm.SearchSelect(txtSearchRecepient.Text, FormChange.FormName.RecipDonor );
            frm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isNewTransaction == true)
            {
                if (!isValidPerson ()) { return; }
                PersonInfo Reg = new PersonInfo();

                if (Reg.isExist(txtFirstname.Text, txtLastname.Text, txtMiddlename.Text))
                {
                    Donor = Reg;
                    Recipient = Reg;
                }
                else
                {
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

                    Reg.loadLastID();
                    Reg.LoadRecepient();

                    Donor = new PersonInfo();
                    Recipient = new PersonInfo();

                    Donor = Reg;
                    Recipient = Reg;
                }
               
            }

            if (rbDonor.Checked == true)
            {
                if (!isValid()) { MessageBox.Show("Please Check the Fields!", "Error"); return; }
                if (!isValidDonor(Donor.ID)) { MessageBox.Show("Last Donate " + getLastDonate(Donor.ID) + " To Be Edit", "Error"); return; }
                if (Convert.ToInt16(mod_system.GetCurrentAge(Convert.ToDateTime(Donor.DateofBirth))) < 18) { MessageBox.Show("Donor must above 18", "Invalid!"); return; }
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
            }
            else
            {
                if (!isValidRecip ()) { MessageBox.Show("Please Check the Fields!", "Error"); return; }
                BloodRecipient rec = new BloodRecipient();
                rec.DocDate = DateTime.Now;
                rec.BloodType = cboBloodType.Text;
                rec.RecipientInfo = Recipient;
                rec.EncodeBy = mod_system.bloodUser.ID;
                rec.SaveRecipient();

                rec.DeductInv(cboBloodType.Text);

                MessageBox.Show("Successfully Save!", "Information");

                Maintenance GetOption = new Maintenance();

                if (rec.GetBloodInv(rec.BloodType) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
                {
                    MessageBox.Show("Please be inform Blood Type " + rec.BloodType + " only " + rec.GetBloodInv(rec.BloodType) + " remaining", "Warning . . .", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            string mysql = "Select * From tblTransaction Limit 0";
            DataSet ds = Database.LoadSQL(mysql, "tblTransaction");

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with3 = dsNewRow;
            BloodDo = new BloodDonor();
            BloodRecip = new BloodRecipient();
            _with3["TransDate"] = DateTime.Now;
           
            string transType;
            if (rbDonor.Checked == true)
            {
                _with3["TransID"] = Convert.ToInt32(BloodDo.loadLastID());
                transType = "Donor";
            }
            else
            {
                _with3["TransID"] = Convert.ToInt32(BloodRecip.loadLastID());
                transType = "Recipient";
            }
            _with3["TransType"] = transType;
            ds.Tables["tblTransaction"].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
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

        private bool isValidRecip()
        {
            if (Recipient == null) { return false; }
            if (cboBloodType.Text == "") { return false; }

            return true;
        }

        private bool isValidPerson()
        {
            if (txtFirstname.Text == "") { MessageBox.Show("Invalid Firstname", "Warning. . ."); txtFirstname.Focus(); return false; }
            if (txtLastname.Text == "") { MessageBox.Show("Invalid Lastname", "Warning. . ."); txtLastname.Focus(); return false; }
            if (cboGender.Text == "") { MessageBox.Show("Invalid Gender", "Warning. . ."); cboGender.Focus(); return false; }
            //if (dtpDob.Text )

            return true;
        }

        private bool isValidDonor(int idx)
        {
            string mysql = "Select * From tblDonor Where Status = '1' And DonorID = " + idx;
            mysql += " Order By DocDate Desc";
            DataSet ds = Database.LoadSQL(mysql, "tblDonor");

            //if (Convert.ToDateTime(ds.Tables[0].Rows[0]["DocDate"]).AddDays(90) ) { return false; }

            if (ds.Tables[0].Rows.Count == 0) { return true; }
            Console.WriteLine("Docdate " + Convert.ToDateTime(ds.Tables[0].Rows[0]["DocDate"]).AddDays(90));
            Console.WriteLine("NowDate " + DateTime.Now);

            if (Convert.ToDateTime(ds.Tables[0].Rows[0]["DocDate"]).AddDays(90) > DateTime.Now) { return false; }

            return true;
        }

        private string getLastDonate(int idx)
        {
            string mysql = "Select * From tblDonor Where Status = '1' And DonorID = " + idx;
            mysql += " Order By DocDate Desc";
            DataSet ds = Database.LoadSQL(mysql, "tblDonor");

            if (ds.Tables[0].Rows.Count == 0) { return ""; }

            return Convert.ToString(Convert.ToDateTime(ds.Tables[0].Rows[0]["DocDate"]).ToString("yyyy-MM-dd"));
        }

        private void ClearText()
        {
            txtCardNum.Clear();
            txtFirstname.Clear();
            txtMiddlename.Clear();
            txtLastname.Clear();
            //txtGender.Clear();
            //txtDob.Clear();
            txtSearchRecepient.Clear();
        }

        internal void LoadPersonInfo(PersonInfo info)
        {
            txtFirstname.Enabled = false;
            txtMiddlename.Enabled = false;
            txtLastname.Enabled = false;
            cboGender.Enabled = false;
            dtpDob.Enabled = false;
            cboMaritalStatus.Enabled = false;
            txtPreStreet.Enabled = false;
            cboPreBarangay.Enabled = false;
            cboPreCity.Enabled = false;
            cboPreProvince.Enabled = false;
            txtPreZipcode.Enabled = false;
            txtPerStreet.Enabled = false;
            cboPerBarangay.Enabled = false;
            cboPerCity.Enabled = false;
            cboPerProvince.Enabled = false;
            txtPerZipcode.Enabled = false;

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
            cboGender.Text = tmpGender;
            dtpDob.Text = Convert.ToString(info.DateofBirth.ToString("yyyy-MM-dd"));
            txtContactNum.Text = info.ContactNum;
            cboMaritalStatus.Text = info.MaritalStatus;

            //Address
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

            Donor = info;
            Recipient = info;
            txtSearchRecepient.Clear();
        }

        private void txtSearchRecepient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) { btnSearchName.PerformClick(); }
        }
    }
}
