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
                u.Rule = cboRule.Text;
                u.Status = "1";
                u.SaveUser();

                MessageBox.Show("User " + u.UserName + " Successfully Saved!", "Information");
            }
            else {
                if (txtPassword.Text == "") { return; }
                if (txtRetype.Text != txtPassword.Text) { return; }
                if (cboRule.Text == "") { return; }

                tmpUser.UserPassword = Security.EncryptString(txtPassword.Text);
                tmpUser.Rule = cboRule.Text;
                tmpUser.UpdateUser();

                MessageBox.Show("User " + tmpUser.UserName + " Successfully Updated!", "Information");
            }


        }

        private bool isValid()
        {
            if (txtFirstname.Text == "") { txtFirstname.Focus(); return false; }
            if (txtMiddlename.Text == "") { txtMiddlename.Focus(); return false; }
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
            cboRule.Text = u.Rule;

            chkStatus.Enabled = true;
            btnSave.Text = "&Update";
        }

        
     
    }
}
