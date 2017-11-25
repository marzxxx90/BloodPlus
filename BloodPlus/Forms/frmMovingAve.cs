﻿using System;
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

        private void Generate ()
        {
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpTo.CustomFormat = "yyyy-MM-dd";

         string mysql = "Select Month(DocDate)as DocNum, case Month(DocDate) ";
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
            mysql += "From tblDonor Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text  + "' And '" + dtpTo.Text + "') ";
            mysql += "Group By Month(DocDate), BloodType ";
            mysql += "Order By DocDate ";
            DataSet ds = Database.LoadSQL(mysql, "tblDonor");

            var mySeries = new SortedList<string, double>();
            int i = 0;

            lvDev.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
	            {
                    i +=1;
                    ListViewItem lv = lvDev.Items.Add(Convert.ToString(dr["DocMonth"]));
                    lv.SubItems.Add(dr["DocYear"].ToString());
                    lv.SubItems.Add(dr["BloodCount"].ToString());
                    if (i >= Convert.ToInt16(nudPeriod.Value)) { lv.SubItems.Add(Convert.ToString(MovingAverage(ds, Convert.ToInt16(nudPeriod.Value)))); }
                  
	            }

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
            ds = Database.LoadSQL(mysql,"tblDonor");

            ReportInit(ds, "dsMonitor", @"Reports\rpt_Graph.rdlc");
        }

        public double MovingAverage(DataSet ds, int period)
        {
            double average;
            for (int i = iRows; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i >= period - 1)
                {
                    double total = 0;
                    for (int x = i; x > (i - period); x--)
                    {
                        total += Convert.ToDouble(ds.Tables[0].Rows[x]["BloodCount"]);
                        Console.WriteLine("Month " + ds.Tables[0].Rows[x]["DocMonth"].ToString());
                        Console.WriteLine("Value " + ds.Tables[0].Rows[x]["BloodCount"].ToString());
                    }
                        average = total / period;
                        if (iRows < period)
                        {
                            iRows += period;
                        }
                        else { iRows += 1; }

                        return average;
                    
                }
            }

            return 0;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cboBloodType.Text == "") { MessageBox.Show("Please Select Blood Type!","Information"); return; }
            if (nudPeriod.Value < 1) { MessageBox.Show("Invalid Period"); return; }
            Generate();
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
