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
            settingsToolStripMenuItem.Enabled = st;
           
            if (st == true)
            {
                logoutToolStripMenuItem.Text = "&Logout";
                isExpire();
                tBloodStatus.Enabled = true;
                tBloodStatus.Start();
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

        private void clientListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmPersonList"] != null)
            {
                (Application.OpenForms["frmPersonList"] as frmPersonList).Show();
            }
            else
            {
                frmPersonList frm = new frmPersonList();
                frm.Show();
            }
        }

        private void bloodInventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mysql = "Select * From tblStock ";

            Dictionary<string, string> rptPara = new Dictionary<string, string>();
            rptPara.Add("txtDate", "Date: " + DateAndTime.Now.ToString("MMM dd, yyyy"));
           // rptPara.Add("IsDailyMonthly", "Daily Sales Report");

            frmReport frm = new frmReport();
            frm.ReportInit(mysql, "dsStock", @"Reports\rpt_BloodInventory.rdlc", rptPara);
            frm.Show();
           
        }

        private bool isExpire()
        {
            string mysql = "Select *, date_add(DocDate, Interval 60 Day) ";
            mysql += "From tblDonor ";
            mysql += "Where date_add(DocDate, Interval 60 Day) <= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' And Status = 1";
            DataSet ds = Database.LoadSQL(mysql, "tblDonor");
            if (ds.Tables[0].Rows.Count == 0) { return true; }

           

            foreach (DataRow  dr in ds.Tables[0].Rows )
            {
                if (Application.OpenForms["frmConsole"] != null)
                {
                    (Application.OpenForms["frmConsole"] as frmConsole).SetValue(ds.Tables[0].Rows.Count);
                    (Application.OpenForms["frmConsole"] as frmConsole).Show();
                    (Application.OpenForms["frmConsole"] as frmConsole).AddtoList();
                }
                else
                {
                    frmConsole frm = new frmConsole();
                    frm.Show();
                }

                BloodDonor Deduct = new BloodDonor();
                Deduct.ID = Convert.ToInt16(dr["id"]);
                Deduct.UpdateStatus();
                Deduct.DeductInv(dr["bloodtype"].ToString());

                System.Windows.Forms.Application.DoEvents();
            }

            (Application.OpenForms["frmConsole"] as frmConsole).ClearLogs();
            (Application.OpenForms["frmConsole"] as frmConsole).Close();
            return true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmSettings"] != null)
            {
                (Application.OpenForms["frmSettings"] as frmSettings).Show();
            }
            else
            {
                frmSettings frm = new frmSettings();
                frm.Show();
            }
        }

        private void BloodStatus()
        {
            ToolTip ttStock = new ToolTip();

            string mysql = "Select * From tblStock";
            DataSet ds = Database.LoadSQL(mysql,"tblStock");
            Maintenance GetOption = new Maintenance();
            foreach (DataRow dr in ds.Tables[0].Rows)
	            {
		             switch (dr["bloodType"].ToString())
                     {
                         case "A":
                             if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
                             {
                                 btnTypeA.BackColor = Color.Red;
                             }
                             else {
                                 btnTypeA.BackColor = Color.Blue;
                             }
                             ttStock.SetToolTip(btnTypeA, dr["Inv"].ToString() + " Stock remaining");     
                             break;

                         case "B":
                             if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
                             {
                                 btnTypeB.BackColor = Color.Red;
                             }
                             else
                             {
                                 btnTypeB.BackColor = Color.Blue;
                             }
                             ttStock.SetToolTip(btnTypeB, dr["Inv"].ToString() + " Stock remaining");    
                             break;
                             
                         case "AB":
                             if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
                             {
                                 btnTypeAB.BackColor = Color.Red;
                             }
                             else
                             {
                                 btnTypeAB.BackColor = Color.Blue;
                             }
                             ttStock.SetToolTip(btnTypeAB, dr["Inv"].ToString() + " Stock remaining");    
                             break;

                         case "O":
                             if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
                             {
                                 btnTypeO.BackColor = Color.Red;
                             }
                             else
                             {
                                 btnTypeO.BackColor = Color.Blue;
                             }
                             ttStock.SetToolTip(btnTypeO, dr["Inv"].ToString() + " Stock remaining");    
                             break;
                     } 
	            }
            
        }

        private void tBloodStatus_Tick(object sender, EventArgs e)
        {
            BloodStatus();
        }

        private void bloodDonationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
