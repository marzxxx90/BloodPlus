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
        public frmPersonInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (! isValid()) { return; }
            PersonInfo Reg = new PersonInfo();
            Reg.Firstname = txtFirstname.Text;
            Reg.Middlename = txtMiddlename.Text;
            Reg.Lastname = txtLastname.Text;
            Reg.Gender = cboGender.Text;
            Reg.DateofBirth = Convert.ToDateTime(dtpDob.Text);
            Reg.SaveRecepient();

            MessageBox.Show("Successfully Saved!","Information");
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
        }

        private void frmPersonInfo_Load(object sender, EventArgs e)
        {
            ClearText();
        }
    }
}
