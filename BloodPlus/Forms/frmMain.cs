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
    }
}
