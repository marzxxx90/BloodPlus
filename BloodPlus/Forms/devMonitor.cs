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
    public partial class devMonitor : Form
    {
        public devMonitor()
        {
            InitializeComponent();
        }

        private void dev_Load(object sender, EventArgs e)
        {
            LoadInfoDonor();
        }

        private void LoadInfoDonor()
        {
            string mysql = "Select Month(DocDate)as DocNum, case Month(DocDate) ";
            mysql += "When 1 then 'Jan'  ";
            mysql += "When 2 then 'Feb'  ";
            mysql += "When 3 then 'Mar'  ";
            mysql += "When 4 then 'Apr'  ";
            mysql += "When 5 then 'May'  ";
            mysql += "When 6 then 'Jun'  ";
            mysql += "When 7 then 'Jul'  ";
            mysql += "When '8' then 'Aug' ";
            mysql += "When '9' then 'Sep'  ";
            mysql += "When '10' then 'Oct'  ";
            mysql += "When '11' then 'Nov'  ";
            mysql += "When '12' then 'Dec' else 'None' End as DocMonth, BloodType, Count(BloodType)as BloodCount , DocDate, Year(DocDate)as DocYear ";
            mysql += "From tblDonor Where BloodType = 'A' ";
            mysql += "Group By Month(DocDate), BloodType ";
            mysql += "Order By DocDate ";
            DataSet ds = Database.LoadSQL(mysql, "tblDonor");

            var mySeries = new SortedList<string, double>();
            int i = 0;

            foreach (DataRow dr in ds.Tables[0].Rows)
	            {
                    i +=1;
                    mySeries.Add(dr["DocMonth"].ToString(), Convert.ToDouble(dr["BloodCount"]));

                    ListViewItem lv = lvDev.Items.Add(Convert.ToString(dr["DocMonth"]));
                    lv.SubItems.Add(dr["DocYear"].ToString());
                    lv.SubItems.Add(dr["BloodCount"].ToString());
                    if (i >= 3) { lv.SubItems.Add(Convert.ToString( MovingAverage2(mySeries, 3))); }
                  
	            }

            var avg = MovingAverage(mySeries, 3);
            foreach (var item in avg)
            {
                Console.WriteLine("{0} {1}", item.Key, item.Value);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mysql = "Select case Month(DocDate) ";
            mysql +="When 1 then 'Jan'  ";
            mysql +="When 2 then 'Feb'  ";
            mysql +="When 3 then 'Mar'  ";
            mysql +="When 4 then 'Apr'  ";
            mysql +="When 5 then 'May'  ";
            mysql +="When 6 then 'Jun'  ";
            mysql +="When 7 then 'Jul'  ";
            mysql +="When '8' then 'Aug' ";
             mysql +="When '9' then 'Sep'  ";
            mysql +="When '10' then 'Oct'  ";
            mysql +="When '11' then 'Nov'  ";
            mysql +="When '12' then 'Dec' else 'None' End as DocMonth, BloodType, DocDate, Year(DocDate)as DocYear ";
            mysql +="From tblDonor ";
 

            Dictionary<string, string> addParameters = new Dictionary<string, string>();

            ReportInit(mysql, "dsMonitor", @"Reports\rpt_Graph.rdlc",addParameters );
        }

        public SortedList<string, double> MovingAverage(SortedList<string, double> series, int period)
        {
            var result = new SortedList<string, double>();

            for (int i = 0; i < series.Count(); i++)
            {
                if (i >= period - 1)
                {
                    double total = 0;
                    for (int x = i; x > (i - period); x--)
                        total += series.Values[x];
                    double average = total / period;
                    result.Add(series.Keys[i], average);
                }

            }
            return result;
        }

        public double MovingAverage2(SortedList<string, double> series, int period)
        {
            double average;

            for (int i = 0; i < series.Count(); i++)
            {
                if (i >= period - 1)
                {
                    double total = 0;
                    for (int x = i; x > (i - period); x--)
                        total += series.Values[x];
                    average = total / period;
                    return average;
                   // result.Add(series.Keys[i], average);
                }

            }
            return 0;
        }
        internal void ReportInit(string mySql, string dsName, string rptUrl, Dictionary<string, string> addPara = null, bool hasUser = true)
        {
            try
            {
                DataSet ds = Database.LoadSQL(mySql, dsName);
                if (ds == null)
                    return;
                var _with2 = rvSample ;
                _with2.ProcessingMode = ProcessingMode.Local;
                _with2.LocalReport.ReportPath = rptUrl;
                _with2.LocalReport.DataSources.Clear();

                _with2.LocalReport.DataSources.Add(new ReportDataSource(dsName, ds.Tables[dsName]));

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
    }
}
