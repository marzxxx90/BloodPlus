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
    public partial class frmRecipient : Form
    {
        PersonInfo Recipient;
        public frmRecipient()
        {
            InitializeComponent();
        }

        private void frmRecipient_Load(object sender, EventArgs e)
        {
            loadBloodType();
            lblDate.Text = Convert.ToString(mod_system.CurrentDate.ToString("MM/dd/yyyy"));
        }

        private void loadBloodType()
        {
            string mysql = "Select * From tblStock";
            DataSet ds = Database.LoadSQL(mysql,"tblStock");

            foreach (DataRow  dr in ds.Tables[0].Rows )
            {
                cboBloodType.Items.Add(dr["BloodType"].ToString() );
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmPersonList frm = new frmPersonList();
            frm.SearchSelect(txtSearch.Text, FormChange.FormName.RequestBlood );
            frm.Show();
        }

        internal void LoadRecepientInfo(PersonInfo info)
        {
            txtName.Text = info.Firstname + " " + info.Lastname;
            txtGender.Text = info.Gender == "F" ? "Female" : "Male";
            txtAge.Text = Convert.ToString(mod_system.GetCurrentAge(info.DateofBirth));
            txtContact.Text = info.ContactNum;
            txtAddress.Text = info.PresentStreet + " " + info.PresentBarangay + " " + info.PresentCity;

            Recipient = info;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) { btnSearch.PerformClick(); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isValid()) { MessageBox.Show("Please Check the Fields!", "Error"); return; }
            BloodRecipient rec = new BloodRecipient();
            rec.DocDate = DateTime.Now;
            rec.BloodType = cboBloodType.Text;
            rec.RecipientInfo = Recipient;
            rec.EncodeBy = mod_system.bloodUser.ID;
            rec.SaveRecipient();

            rec.DeductInv(cboBloodType.Text);

            MessageBox.Show("Successfully Save!","Information");

            Maintenance GetOption = new Maintenance();

            if (rec.GetBloodInv(rec.BloodType ) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel"))) 
            {
                MessageBox.Show("Please be inform Blood Type " + rec.BloodType + " only " + rec.GetBloodInv(rec.BloodType ) + " remaining", "Warning . . .",MessageBoxButtons.OK,  MessageBoxIcon.Exclamation);
            }

            this.Close();
        }

        private bool isValid()
        {
            if (Recipient == null) { return false; }
            if (cboBloodType.Text == "") { return false; }

            return true;
        }
    }
}
