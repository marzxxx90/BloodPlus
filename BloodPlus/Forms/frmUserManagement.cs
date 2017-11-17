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
        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            chkStatus.Enabled = false;
            ClearText();
        }

        private void ClearText()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtFirstname.Clear();
            txtMiddlename.Clear();
            txtLastname.Clear();
            txtRetype.Clear();
            txtRule.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isValid()) { MessageBox.Show("Please check the fields!","Warning. . ."); return; }

            ComputerUser tmpUser = new ComputerUser();
            var u = tmpUser;
            u.UserName = txtUserName.Text;
            u.UserPassword = Security.EncryptString(txtPassword.Text);
            u.FirstName = txtFirstname.Text;
            u.MiddleName = txtMiddlename.Text;
            u.LastName = txtLastname.Text;
            u.Rule = txtRule.Text;
            u.Status = "1";
            u.SaveUser();

            MessageBox.Show("User " + u.UserName + " Successfully Saved!", "Information");


        }

        private bool isValid()
        {
            if (txtFirstname.Text == "") { txtFirstname.Focus(); return false; }
            if (txtMiddlename.Text == "") { txtMiddlename.Focus(); return false; }
            if (txtLastname.Text == "") { txtLastname.Focus(); return false; }
            if (txtUserName.Text == "") { txtUserName.Focus(); return false; }
            if (txtPassword.Text == "") { txtPassword.Focus(); return false; }
            if (txtRetype.Text == "") { txtRetype.Focus(); return false; }
            if (txtRule.Text == "") { txtRule.Focus(); return false; }

            if (txtPassword.Text != txtRetype.Text) {return false;}
            return true;
        }
     
    }
}
