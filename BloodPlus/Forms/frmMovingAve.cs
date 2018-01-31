using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace BloodPlus
{
    public partial class frmMovingAve : Form
    {
        int iRows = 0;
        public frmMovingAve()
        {
            InitializeComponent();
        }

        private void frmMovingAve_Load(object sender, EventArgs e)
        {
            LoadBlood();
          
        }

        private void LoadBlood()
        {
            string mysql = "Select * From tblStock";
            DataSet ds = Database.LoadSQL(mysql, "tblStock");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cboBloodType.Items.Add(dr["BloodType"]);

            }

        }

        private void Generate()
        {
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpTo.CustomFormat = "yyyy-MM-dd";

            string mysql = "";
            if (rbDaily.Checked == true)
            {
                mysql = "Select Day(DocDate)as DocDay, Month(DocDate)as DocNum, case Month(DocDate) ";
                mysql += "When 1 then 'Jan'  ";
                mysql += "When 2 then 'Feb'  ";
                mysql += "When 3 then 'Mar'  ";
                mysql += "When 4 then 'Apr'  ";
                mysql += "When 5 then 'May'  ";
                mysql += "When 6 then 'Jun'  ";
                mysql += "When 7 then 'Jul'  ";
                mysql += "When 8 then 'Aug' ";
                mysql += "When 9 then 'Sep'  ";
                mysql += "When 10 then 'Oct'  ";
                mysql += "When 11 then 'Nov'  ";
                mysql += "When 12 then 'Dec' else 'None' End as DocMonth, BloodType, Count(BloodType)as BloodCount , DocDate, Year(DocDate)as DocYear ";
                mysql += "From tblDonor Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text + "' And '" + dtpTo.Text + "') ";
                mysql += "Group By Day(DocDate), BloodType ";
                mysql += "Order By DocDate ";
            }
            else if (rbMonthly.Checked == true)
            {
                mysql = "Select Month(DocDate)as DocDay, Month(DocDate)as DocNum, case Month(DocDate) ";
                mysql += "When 1 then 'Jan'  ";
                mysql += "When 2 then 'Feb'  ";
                mysql += "When 3 then 'Mar'  ";
                mysql += "When 4 then 'Apr'  ";
                mysql += "When 5 then 'May'  ";
                mysql += "When 6 then 'Jun'  ";
                mysql += "When 7 then 'Jul'  ";
                mysql += "When 8 then 'Aug' ";
                mysql += "When 9 then 'Sep'  ";
                mysql += "When 10 then 'Oct'  ";
                mysql += "When 11 then 'Nov'  ";
                mysql += "When 12 then 'Dec' else 'None' End as DocMonth, BloodType, Count(BloodType)as BloodCount , DocDate, Year(DocDate)as DocYear ";
                mysql += "From tblDonor Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text + "' And '" + dtpTo.Text + "') ";
                mysql += "Group By Month(DocDate), BloodType ";
                mysql += "Order By DocDate ";
            }
            else if (rbYearly.Checked == true)
            {
                mysql = "Select Year(DocDate)as DocDay, Year(DocDate)as DocNum, ";
                mysql += "Month(DocDate) as DocMonth, ";
                mysql += "BloodType, Count(BloodType)as BloodCount , DocDate, Year(DocDate)as DocYear  ";
                mysql += "From tblDonor  ";
                mysql += "Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text + "' And '" + dtpTo.Text + "') ";
                mysql += "Group By Year(DocDate), BloodType  ";
                mysql += "Order By DocDate ";
 
            }
            DataSet ds = Database.LoadSQL(mysql, "tblDonor");

            var mySeries = new SortedList<string, double>();
            int i = 0;

            lvDev.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
	            {
                    i +=1;
                if (rbDaily.Checked ==true)
                {
                    lvDev.Columns[0].Width = 69;
                    lvDev.Columns[1].Width = 84;
                }
                else if (rbMonthly.Checked == true )
                {
                    lvDev.Columns[0].Width = 0;
                    lvDev.Columns[1].Width = 84;
                }
                else if (rbYearly.Checked ==true) 
                {
                  lvDev.Columns[0].Width = 0;
                  lvDev.Columns[1].Width = 0;
                }
                ListViewItem lv = lvDev.Items.Add(Convert.ToString(dr["DocDay"]));
                lv.SubItems.Add(Convert.ToString(dr["DocMonth"]));
                lv.SubItems.Add(dr["DocYear"].ToString());
                lv.SubItems.Add(dr["BloodCount"].ToString());
                if (i >= 3) { lv.SubItems.Add(Convert.ToString(MovingAverage(ds, 3))); }
                  
	            }

            if (rbDaily.Checked == true )
            {
                mysql = "Select Day(DocDate)as DocNum, Day(DocDate) as DocMonth, BloodType , DocDate, Year(DocDate)as DocYear ";
                mysql += "From tblDonor Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text + "' And '" + dtpTo.Text + "') ";
                mysql += "Order By DocDate ";
            }
            else if (rbMonthly.Checked == true)
            {
                mysql = "Select Month(DocDate)as DocNum, case Month(DocDate) ";
                mysql += "When 1 then 'Jan'  ";
                mysql += "When 2 then 'Feb'  ";
                mysql += "When 3 then 'Mar'  ";
                mysql += "When 4 then 'Apr'  ";
                mysql += "When 5 then 'May'  ";
                mysql += "When 6 then 'Jun'  ";
                mysql += "When 7 then 'Jul'  ";
                mysql += "When 8 then 'Aug' ";
                mysql += "When 9 then 'Sep'  ";
                mysql += "When 10 then 'Oct'  ";
                mysql += "When 11 then 'Nov'  ";
                mysql += "When 12 then 'Dec' else 'None' End as DocMonth, BloodType , DocDate, Year(DocDate)as DocYear ";
                mysql += "From tblDonor Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text + "' And '" + dtpTo.Text + "') ";
                mysql += "Order By DocDate ";
            }
            else if (rbYearly.Checked == true)
            {
                mysql = "Select Year(DocDate)as DocNum, Year(DocDate) as DocMonth, BloodType , DocDate, Year(DocDate)as DocYear ";
                mysql += "From tblDonor Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text + "' And '" + dtpTo.Text + "') ";
                mysql += "Order By DocDate ";
 
            }
            ds = Database.LoadSQL(mysql,"tblDonor");

            ReportInit(ds, "dsMonitor", @"Reports\rpt_Graph.rdlc");
        }

        private void GenerateRecipient()
        {
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpTo.CustomFormat = "yyyy-MM-dd";
            string mysql = "";
            if (rbDaily.Checked ==true)
            {
                mysql = "Select Day(DocDate)as DocDay, Month(DocDate)as DocNum, Month(DocDate) as DocMonth, BloodType, Count(BloodType)as BloodCount , DocDate, Year(DocDate)as DocYear ";
                mysql += "From tblRecipient Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text + "' And '" + dtpTo.Text + "') ";
                mysql += "Group By Day(DocDate), BloodType ";
                mysql += "Order By DocDate ";
            }
            else if (rbMonthly.Checked == true)
            {
                mysql = "Select Month(DocDate)as DocDay, Month(DocDate)as DocNum, case Month(DocDate) ";
                mysql += "When 1 then 'Jan'  ";
                mysql += "When 2 then 'Feb'  ";
                mysql += "When 3 then 'Mar'  ";
                mysql += "When 4 then 'Apr'  ";
                mysql += "When 5 then 'May'  ";
                mysql += "When 6 then 'Jun'  ";
                mysql += "When 7 then 'Jul'  ";
                mysql += "When 8 then 'Aug' ";
                mysql += "When 9 then 'Sep'  ";
                mysql += "When 10 then 'Oct'  ";
                mysql += "When 11 then 'Nov'  ";
                mysql += "When 12 then 'Dec' else 'None' End as DocMonth, BloodType, Count(BloodType)as BloodCount , DocDate, Year(DocDate)as DocYear ";
                mysql += "From tblRecipient Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text + "' And '" + dtpTo.Text + "') ";
                mysql += "Group By Month(DocDate), BloodType ";
                mysql += "Order By DocDate ";
            }
            else if (rbYearly.Checked == true)
            {
                mysql = "Select Year(DocDate)as DocDay, Month(DocDate)as DocNum, Month(DocDate) as DocMonth, BloodType, Count(BloodType)as BloodCount , DocDate, Year(DocDate)as DocYear ";
                mysql += "From tblRecipient Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text + "' And '" + dtpTo.Text + "') ";
                mysql += "Group By Year(DocDate), BloodType ";
                mysql += "Order By DocDate ";
            }
            DataSet ds = Database.LoadSQL(mysql, "tblRecipient");

            var mySeries = new SortedList<string, double>();
            int i = 0;

            lvDev.Items.Clear();
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    i += 1;
            //    ListViewItem lv = lvDev.Items.Add(Convert.ToString(dr["DocMonth"]));
            //    lv.SubItems.Add(dr["DocYear"].ToString());
            //    lv.SubItems.Add(dr["BloodCount"].ToString());
            //    if (i >= 3) { lv.SubItems.Add(Convert.ToString(MovingAverage(ds, 3))); }

            //}

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                i += 1;
                if (rbDaily.Checked == true)
                {
                    lvDev.Columns[0].Width = 69;
                    lvDev.Columns[1].Width = 84;
                }
                else if (rbMonthly.Checked == true)
                {
                    lvDev.Columns[0].Width = 0;
                    lvDev.Columns[1].Width = 84;
                }
                else if (rbYearly.Checked == true)
                {
                    lvDev.Columns[0].Width = 0;
                    lvDev.Columns[1].Width = 0;
                }
                ListViewItem lv = lvDev.Items.Add(Convert.ToString(dr["DocDay"]));
                lv.SubItems.Add(Convert.ToString(dr["DocMonth"]));
                lv.SubItems.Add(dr["DocYear"].ToString());
                lv.SubItems.Add(dr["BloodCount"].ToString());
                if (i >= 3) { lv.SubItems.Add(Convert.ToString(MovingAverage(ds, 3))); }

            }

            if (rbDaily.Checked ==true)
            {
                mysql = "Select Day(DocDate)as DocNum, Day(DocDate) as DocMonth, BloodType , DocDate, Year(DocDate)as DocYear ";
                mysql += "From tblRecipient Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text + "' And '" + dtpTo.Text + "') ";
                mysql += "Order By DocDate ";
            }
            else if (rbMonthly.Checked == true)
            {
                mysql = "Select Month(DocDate)as DocNum, case Month(DocDate) ";
                mysql += "When 1 then 'Jan'  ";
                mysql += "When 2 then 'Feb'  ";
                mysql += "When 3 then 'Mar'  ";
                mysql += "When 4 then 'Apr'  ";
                mysql += "When 5 then 'May'  ";
                mysql += "When 6 then 'Jun'  ";
                mysql += "When 7 then 'Jul'  ";
                mysql += "When 8 then 'Aug' ";
                mysql += "When 9 then 'Sep'  ";
                mysql += "When 10 then 'Oct'  ";
                mysql += "When 11 then 'Nov'  ";
                mysql += "When 12 then 'Dec' else 'None' End as DocMonth, BloodType , DocDate, Year(DocDate)as DocYear ";
                mysql += "From tblRecipient Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text + "' And '" + dtpTo.Text + "') ";
                mysql += "Order By DocDate ";
            }
            else if (rbYearly.Checked == true)
            {
                mysql = "Select Year(DocDate)as DocNum, Year(DocDate) as DocMonth, BloodType , DocDate, Year(DocDate)as DocYear ";
                mysql += "From tblRecipient Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text + "' And '" + dtpTo.Text + "') ";
                mysql += "Order By DocDate ";
            }

            ds = Database.LoadSQL(mysql, "tblRecipient");

            ReportInit(ds, "dsMonitor", @"Reports\rpt_Graph.rdlc");
        }
        public double MovingAverage(DataSet ds, int period)
        {
            double average;
            //iRows ---> Kong asa sya magstart ug loop
            //ds.table[0].rows.count ---> count sa list kong pila

            //dri loop ang list kong pila ang count
            for (int i = iRows; i < ds.Tables[0].Rows.Count; i++)
            {
                //if ika 3 pataas na ang list magproced sya sa ug compute
                if (i >= period - 1)
                {
                    double total = 0;
                    //dri kay g loop ulit ang collection katong pang ika 3 
                    for (int x = i; x > (i - period); x--)
                    {
                        //dri g add tong mga g loop 
                        total += Convert.ToDouble(ds.Tables[0].Rows[x]["BloodCount"]);
                        Console.WriteLine("Month " + ds.Tables[0].Rows[x]["DocMonth"].ToString());
                        Console.WriteLine("Value " + ds.Tables[0].Rows[x]["BloodCount"].ToString());
                    }
                    //average --> mao ning total sa mga g loop
                        average = total / period;

                    //dri kong ang iRows value kay gamay sa period, eh add nya ang iRows ug perion para magproced sya sa ika 4
                        if (iRows < period)
                        {
                            iRows += period;
                        }
                            //dri addan nlng ug 1  
                        else { iRows += 1; }

                        return average;
                }
            }

            return 0;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            iRows = 0;
            if (cboBloodType.Text == "") { MessageBox.Show("Please Select Blood Type!","Information"); return; }
           // if (nudPeriod.Value < 1) { MessageBox.Show("Invalid Period"); return; }
            if (cboTransaction.Text == "") {MessageBox.Show("Please Select Transaction"); return;}
            switch (cboTransaction.Text)
            {
                case "Blood Donor":
                    Generate() ;
                    break;
                case "Blood Recipient":
                    GenerateRecipient();
                    break;
            }
           
        }

        private void ReportInit(DataSet ds, string dsName, string rptUrl, Dictionary<string, string> addPara = null, bool hasUser = true)
        {
            try
            {
                if (ds == null)
                    return;
                var _with2 = rv_display;
                _with2.ProcessingMode = ProcessingMode.Local;
                _with2.LocalReport.ReportPath = rptUrl;
                _with2.LocalReport.DataSources.Clear();

                _with2.LocalReport.DataSources.Add(new ReportDataSource(dsName, ds.Tables[0]));

                if (hasUser)
                {
                    ReportParameter myPara = new ReportParameter();
                    myPara.Name = "txtUsername";
                    if (mod_system.bloodUser.UserName == null)
                    {
                        mod_system.bloodUser.UserName = "Atcheche";
                    }
                    myPara.Values.Add(mod_system.bloodUser.UserName);
                    _with2.LocalReport.SetParameters(new ReportParameter[] { myPara });
                }

                if ((addPara != null))
                {
                    foreach (KeyValuePair<string, string> nPara_loopVariable in addPara)
                    {
                        var nPara = nPara_loopVariable;
                        ReportParameter tmpPara = new ReportParameter();
                        tmpPara.Name = nPara.Key;
                        tmpPara.Values.Add(nPara.Value);
                        _with2.LocalReport.SetParameters(new ReportParameter[] { tmpPara });
                    }
                }

                _with2.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void AddColumnHeader(string ColumnString)
        {
            ColumnHeader NewCh = new ColumnHeader();

            NewCh.Text = ColumnString;
            lvDev.Columns.Add(NewCh);
        }

        private void IniTmpTable()
        {
            DataColumn dtidx = new DataColumn("ID", Type.GetType("System.Int32"));
            DataColumn dtItemCode = new DataColumn("ItemCOde", Type.GetType("System.String"));
            DataColumn dtDescription = new DataColumn("Description", Type.GetType("System.String"));
            DataColumn dtItemGroup = new DataColumn("ItemGroup", Type.GetType("System.String"));
            DataColumn dtItemClass = new DataColumn("ItemClass", Type.GetType("System.String"));
            DataColumn dtQty = new DataColumn("Qty", Type.GetType("System.Double"));
            DataColumn dtUnitCost = new DataColumn("UnitCost", Type.GetType("System.Double"));
            DataColumn dtSellingPrice = new DataColumn("SellingPrice", Type.GetType("System.Double"));
            DataColumn dtGrams = new DataColumn("Grams", Type.GetType("System.Double"));
            DataColumn dtKarat = new DataColumn("Karat", Type.GetType("System.Int32"));
            DataColumn dtAmount = new DataColumn("Amount", Type.GetType("System.Double"));
            DataColumn dtBranchCode = new DataColumn("BranchCode", Type.GetType("System.String"));
            DataColumn dtdocDate = new DataColumn("DocDate", Type.GetType("System.DateTime"));
            DataColumn dtBracket = new DataColumn("Bracket", Type.GetType("System.Double"));
 
        }
    }
}
