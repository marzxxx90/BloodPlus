using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace BloodPlus
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (  mod_system.bloodUser.UserName == null)
            {
                NotYetLogin(false);
            }
            else
            {
                NotYetLogin();
            }
           
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logoutToolStripMenuItem.Text == "&Login")
            {
                frmLogin  frm = new frmLogin();
                frm.Show();
            }
            else
            {
                DialogResult ans = MessageBox.Show("Do you want to LOGOUT?", "Logout", MessageBoxButtons.YesNo); 

                if (ans == System.Windows.Forms.DialogResult.No)
                    return;

                mod_system.bloodUser = null;
                List<string> formNames = new List<string>();
                System.Windows.Forms.Form tmpForm;
                foreach (System.Windows.Forms.Form Form_loopVariable in Application.OpenForms)
                {
                    tmpForm = Form_loopVariable;
                    if (tmpForm.Name != "frmMain" | !(tmpForm.Name != "frmLogin"))
                    {
                        formNames.Add(tmpForm.Name);
                    }
                }
                foreach (string currentFormName in formNames)
                {
                    Application.OpenForms[currentFormName].Close();
                }
                Interaction.MsgBox("Thank you!", MsgBoxStyle.Information);
        
                frmLogin frm = new frmLogin();
                frm.Show();
            }
        }

        internal  void NotYetLogin(bool st = true)
        {
            TransactionToolStripMenuItem.Enabled = st;
            reportToolStripMenuItem.Enabled = st;
            maintenanceToolStripMenuItem.Enabled = st;
           
            if (st == true)
            {
                logoutToolStripMenuItem.Text = "&Logout";
            }
            else
            {
                logoutToolStripMenuItem.Text = "&Login";
            }
        }

        private void bloodDonorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmDonorList"] != null)
            {
                (Application.OpenForms["frmDonorList"] as frmDonorList).Show();
            }
            else
            {
                frmDonorList frm = new frmDonorList();
                frm.Show();
            }
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserManagement frm = new frmUserManagement();
            frm.Show();
        }

        private void importBloodDonorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmImport"] != null)
            {
                (Application.OpenForms["frmImport"] as frmImport).Show();
            }
            else
            {
                frmImport frm = new frmImport();
                frm.Show();
            }
        }

        private void bloodRecepientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRecepientList"] != null)
            {
                (Application.OpenForms["frmRecepientList"] as frmRecepientList).Show();
            }
            else
            {
                frmRecepientList frm = new frmRecepientList();
                frm.Show();
            }
        }

        private void bloodCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmBloodList"] != null)
            {
                (Application.OpenForms["frmBloodList"] as frmBloodList).Show();
            }
            else
            {
                frmBloodList frm = new frmBloodList();
                frm.Show();
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor  = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Control.DefaultBackColor;
        }

    }
}
