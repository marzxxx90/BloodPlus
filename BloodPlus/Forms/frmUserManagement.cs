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
    public partial class frmUserManagement : Form
    {
        ComputerUser tmpUser;
        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            chkStatus.Enabled = false;
            ClearText();
            LoadUser();
        }

        private void ClearText()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtFirstname.Clear();
            txtMiddlename.Clear();
            txtLastname.Clear();
            txtRetype.Clear();
            //cboRule.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (btnSave.Text == "&Save")
            {
                if (!isValid()) { MessageBox.Show("Please check the fields!", "Warning. . ."); return; }
                ComputerUser u = new ComputerUser();

                u.UserName = txtUserName.Text;
                u.UserPassword = Security.EncryptString(txtPassword.Text);
                u.FirstName = txtFirstname.Text;
                u.MiddleName = txtMiddlename.Text;
                u.LastName = txtLastname.Text;
                u.TmpRole = cboRule.Text;
                u.Status = "1";
                u.SaveUser();

                MessageBox.Show("User " + u.UserName + " Successfully Saved!", "Information");
            }
            else {
                if (txtPassword.Text == "") { MessageBox.Show("Please fill Password","Information"); return; }
                if (txtRetype.Text != txtPassword.Text) { MessageBox.Show("Password Not Match", "Warning. . ."); return; }
                if (cboRule.Text == "") { MessageBox.Show("Select Rule", "Information"); return; }

                var u = tmpUser;
                u.UserPassword = Security.EncryptString(txtPassword.Text);
                u.TmpRole = cboRule.Text;
                if (chkStatus.Checked == false) { u.Status = "0"; }
                u.UpdateUser();

                MessageBox.Show("User " + tmpUser.UserName + " Successfully Updated!", "Information");
            }
            LoadUser();
            ClearText();
            btnSave.Text = "&Save";
            chkStatus.Checked = true;
            isEnable();

        }

        private bool isValid()
        {
            if (txtFirstname.Text == "") { txtFirstname.Focus(); return false; }
            //if (txtMiddlename.Text == "") { txtMiddlename.Focus(); return false; }
            if (txtLastname.Text == "") { txtLastname.Focus(); return false; }
            if (txtUserName.Text == "") { txtUserName.Focus(); return false; }
            if (txtPassword.Text == "") { txtPassword.Focus(); return false; }
            if (txtRetype.Text == "") { txtRetype.Focus(); return false; }
            if (cboRule.Text == "") { cboRule.Focus(); return false; }

            if (txtPassword.Text != txtRetype.Text) {return false;}
            return true;
        }

        private void LoadUser()
        {
            string mysql = "Select * From tblUser";
            DataSet ds = Database.LoadSQL(mysql, "tblUser");

            lvUser.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListViewItem lv = lvUser.Items.Add(dr["UserName"].ToString());
                lv.SubItems.Add(dr["Role"].ToString());
                lv.Tag = dr["id"].ToString();
            }
           
        }

        private void lvUser_DoubleClick(object sender, EventArgs e)
        {
            if (lvUser.SelectedItems.Count == 0) { return; }

            int idx = Convert.ToInt16(lvUser.FocusedItem.Tag);
            ComputerUser u = new ComputerUser();
            u.ID = idx;
            u.LoadUser();
            tmpUser = u;
            txtFirstname.Text = u.FirstName;
            txtMiddlename.Text = u.MiddleName;
            txtLastname.Text = u.LastName;
            txtUserName.Text = u.UserName;
            cboRule.Text = u.TmpRole;
            if (u.Status == "1")
            {
                chkStatus.Checked = true;
            }
            else {
                chkStatus.Checked = false;
            }
            chkStatus.Enabled = true;
            btnSave.Text = "&Update";

            txtFirstname.Enabled = false;
            txtUserName.Enabled = false;
            txtMiddlename.Enabled = false;
            txtLastname.Enabled = false;
        }

        private void isEnable()
        {
            txtUserName.Enabled = true;
            txtPassword.Enabled = true;
            txtRetype.Enabled = true;
            txtFirstname.Enabled = true;
            txtMiddlename.Enabled = true;
            txtLastname.Enabled = true;

        }
     
    }
}
