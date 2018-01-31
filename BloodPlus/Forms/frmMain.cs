using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.Reporting.WinForms;
namespace BloodPlus
{
    public partial class frmMain : Form
    {
        int iTick = 0;
        bool isHide = false;
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

            ToolTip tFresh = new ToolTip();

            tFresh.SetToolTip(btnRefresh , "Click to Refresh");

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

                tNotify.Enabled = true;
                tNotify.Start();
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

        //private void bloodInventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string mysql = "Select * From tblStock ";

        //    Dictionary<string, string> rptPara = new Dictionary<string, string>();
        //    rptPara.Add("txtDate", "Date: " + DateAndTime.Now.ToString("MMM dd, yyyy"));
        //   // rptPara.Add("IsDailyMonthly", "Daily Sales Report");

        //    frmReport frm = new frmReport();
        //    frm.ReportInit(mysql, "dsStock", @"Reports\rpt_BloodInventory.rdlc", rptPara);
        //    frm.Show();
           
        //}

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
                             else{
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
                         case "A-":
                              if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
                             {
                                 btnTypeANeg.BackColor = Color.Red;
                             }
                             else
                             {
                                 btnTypeANeg.BackColor = Color.Blue;
                             }
                              ttStock.SetToolTip(btnTypeANeg, dr["Inv"].ToString() + " Stock remaining");   
                             break;
                         case "B-":
                              if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
                             {
                                 btnTypeBNeg.BackColor = Color.Red;
                             }
                             else
                             {
                                 btnTypeBNeg.BackColor = Color.Blue;
                             }
                              ttStock.SetToolTip(btnTypeBNeg, dr["Inv"].ToString() + " Stock remaining");
                             break;
                         case "AB-":
                              if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
                             {
                                 btnTypeABNeg.BackColor = Color.Red;
                             }
                             else
                             {
                                 btnTypeABNeg.BackColor = Color.Blue;
                             }
                              ttStock.SetToolTip(btnTypeABNeg, dr["Inv"].ToString() + " Stock remaining");
                             break;
                         case "O-":
                              if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
                             {
                                 btnTypeONeg.BackColor = Color.Red;
                             }
                             else
                             {
                                 btnTypeONeg.BackColor = Color.Blue;
                             }
                              ttStock.SetToolTip(btnTypeONeg, dr["Inv"].ToString() + " Stock remaining");
                             break;
                     } 
	            }
            
        }

        //private void BloodNotify()
        //{
        //    string mysql = "Select * From tblStock";
        //    DataSet ds = Database.LoadSQL(mysql, "tblStock");
        //    Maintenance GetOption = new Maintenance();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        switch (dr["bloodType"].ToString())
        //        {
        //            case "A":
        //                if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
        //                {
        //                    AddNotify("Please be inform Blood Type A only have " + dr["Inv"].ToString() + " remaining", "A");
        //                }
        //                break;

        //            case "B":
        //                if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
        //                {
        //                    AddNotify("Please be inform Blood Type B only have " + dr["Inv"].ToString() + " remaining", "B");
        //                }
        //                break;

        //            case "AB":
        //                if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
        //                {
        //                    AddNotify("Please be inform Blood Type AB only have " + dr["Inv"].ToString() + " remaining", "AB");
        //                }
        //                break;

        //            case "O":
        //                if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
        //                {
        //                    AddNotify("Please be inform Blood Type O only have " + dr["Inv"].ToString() + " remaining", "O");
        //                }
        //                break;
        //            case "A-":
        //                if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
        //                {
        //                    AddNotify("Please be inform Blood Type A- only have " + dr["Inv"].ToString() + " remaining", "A-");
        //                }
        //                break;
        //            case "B-":
        //                if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
        //                {
        //                    AddNotify("Please be inform Blood Type B- only have " + dr["Inv"].ToString() + " remaining", "B-");
        //                }
        //                break;
        //            case "AB-":
        //                if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
        //                {
        //                    AddNotify("Please be inform Blood Type AB- only have " + dr["Inv"].ToString() + " remaining", "AB-");
        //                }
        //                break;
        //            case "O-":
        //                if (Convert.ToInt16(dr["Inv"].ToString()) < Convert.ToInt16(GetOption.GetSettingsVal("ParLevel")))
        //                {
        //                    AddNotify("Please be inform Blood Type O- only have " + dr["Inv"].ToString() + " remaining", "O-");
        //                }
        //                break;
        //        }
        //    }
 
        //}

        private void tBloodStatus_Tick(object sender, EventArgs e)
        {
            BloodStatus();
            iTick += 1;
           // if (iTick == 1) { BloodNotify(); }

        }


        private void bloodRecepientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRecipientList"] != null)
            {
                (Application.OpenForms["frmRecipientList"] as frmRecipientList).Show();
            }
            else
            {
                frmRecipientList frm = new frmRecipientList();
                frm.Show();
            }
        }

        //private void AddNotify(string strNote, string type)
        //{
        //    bool isExist = false;
        //    if (lvNotify.Items.Count == 0)
        //    {
        //        ListViewItem lv = lvNotify.Items.Add(strNote);
        //        lv.Tag = type;
         
        //    }
        //    else 
        //    {
        //        foreach (ListViewItem lvitm in lvNotify.Items)
        //        {
        //            if (lvitm.Tag == type)
        //            {
        //                isExist = true ;
        //            }

        //        }

        //        if (isExist == false)
        //        {
        //            ListViewItem lv = lvNotify.Items.Add(strNote);
        //            lv.Tag = type;
        //        }
        //    }
            
           
        //}

        //private void btnClear_Click(object sender, EventArgs e)
        //{
        //    foreach (ListViewItem lv in lvNotify.CheckedItems)
        //    {
        //        lvNotify.Items.Remove(lv);
        //    }
        //}

        //private void chkAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    foreach (ListViewItem lv in lvNotify.Items)
        //    {
        //        lv.Checked = chkAll.Checked;
        //    }
        //}

        private void tNotify_Tick(object sender, EventArgs e)
        {
           // BloodNotify();
        }

        private void bloodDonationReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmTransactionReport"] != null)
            {
                (Application.OpenForms["frmTransactionReport"] as frmTransactionReport).FormType = frmTransactionReport.BloodReport.BloodDonor;
                (Application.OpenForms["frmTransactionReport"] as frmTransactionReport).Show();
            }
            else
            {
                frmTransactionReport frm = new frmTransactionReport();
                frm.FormType = frmTransactionReport.BloodReport.BloodDonor;
                frm.Show();
            }
        }

        private void bloodRecipientReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmTransactionReport"] != null)
            {
                (Application.OpenForms["frmTransactionReport"] as frmTransactionReport).FormType = frmTransactionReport.BloodReport.BloodRecipient ;
                (Application.OpenForms["frmTransactionReport"] as frmTransactionReport).Show();
            }
            else
            {
                frmTransactionReport frm = new frmTransactionReport();
                frm.FormType = frmTransactionReport.BloodReport.BloodRecipient;
                frm.Show();
            }
        }

        private void bloodDonationReportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCustomReport"] != null)
            {
                (Application.OpenForms["frmCustomReport"] as frmCustomReport).FormType = frmCustomReport.BloodReport.BloodDonor;
                (Application.OpenForms["frmCustomReport"] as frmCustomReport).Show();
            }
            else
            {
                frmCustomReport frm = new frmCustomReport();
                frm.FormType = frmCustomReport.BloodReport.BloodDonor;
                frm.Show();
            }
        }

        private void bloodRecipientReportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCustomReport"] != null)
            {
                (Application.OpenForms["frmCustomReport"] as frmCustomReport).FormType = frmCustomReport.BloodReport.BloodRecipient ;
                (Application.OpenForms["frmCustomReport"] as frmCustomReport).Show();
            }
            else
            {
                frmCustomReport frm = new frmCustomReport();
                frm.FormType = frmCustomReport.BloodReport.BloodRecipient ;
                frm.Show();
            }
        }

        private void movingAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmMovingAve"] != null)
            {
                (Application.OpenForms["frmMovingAve"] as frmMovingAve).Show();
            }
            else
            {
                frmMovingAve frm = new frmMovingAve();
                frm.Show();
            }
        }

        private void bloodInventoryReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmTransactionReport"] != null)
            {
                (Application.OpenForms["frmTransactionReport"] as frmTransactionReport).FormType = frmTransactionReport.BloodReport.Inventory ;
                (Application.OpenForms["frmTransactionReport"] as frmTransactionReport).Show();
            }
            else
            {
                frmTransactionReport frm = new frmTransactionReport();
                frm.FormType = frmTransactionReport.BloodReport.Inventory;
                frm.Show();
            }
        }

        private void isPrint()
        {
            Reporting AutoPrint = new Reporting();
            string printerName = ""; //tmpMain.GetValue("PrinterOrder");
            if (canPrint(printerName) == false) { return; }
            LocalReport report = new LocalReport();
            String dsName = "dsOrderPrint";

            string mysql = ""; //"Select OrderNum From tblQueue Where ID = '" + QueOrder.GetLastID() + "'";
            DataSet ds = Database.LoadSQL(mysql, "tblQueue");



            report.ReportPath = @"Report\rpt_OrderPrint.rdlc";
            report.DataSources.Clear();
            report.DataSources.Add(new ReportDataSource(dsName, ds.Tables[0]));

            Dictionary<string, string> addParameters = new Dictionary<string, string>();

            if ((addParameters != null))
            {
                foreach (KeyValuePair<string, string> nPara_loopVariable in addParameters)
                {
                    var nPara = nPara_loopVariable;
                    ReportParameter tmpPara = new ReportParameter();
                    tmpPara.Name = nPara.Key;
                    tmpPara.Values.Add(nPara.Value);
                    report.SetParameters(new ReportParameter[] { tmpPara });
                }
            }

            Dictionary<string, double> paperSize = new Dictionary<string, double>();
            paperSize.Add("width", 3.5);
            paperSize.Add("height", 2.5);


            try
            {
                AutoPrint.Export(report, paperSize);
                AutoPrint.m_currentPageIndex = 0;
                AutoPrint.Print(printerName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PRINT FAILED");
            }
        }

        private bool canPrint(string printerName)
        {
            try
            {
                System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                printDocument.PrinterSettings.PrinterName = printerName;
                return printDocument.PrinterSettings.IsValid;
            }
            catch
            { return false; }
        }

        private void bloodInventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmCustomReport"] != null)
            {
                (Application.OpenForms["frmCustomReport"] as frmCustomReport).FormType = frmCustomReport.BloodReport.Inventory ;
                (Application.OpenForms["frmCustomReport"] as frmCustomReport).Show();
            }
            else
            {
                frmCustomReport frm = new frmCustomReport();
                frm.FormType = frmCustomReport.BloodReport.Inventory;
                frm.Show();
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (isHide == true)
            {
                pButtons.Location = new Point(-750, 406);
                isHide = false;
            }
            else
            {
                pButtons.Location = new Point(250, 406);
                isHide = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BloodStatus();
        }

    }
}
