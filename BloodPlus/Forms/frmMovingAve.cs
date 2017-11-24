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
    public partial class frmMovingAve : Form
    {
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
            mysql += "When '8' then 'Aug' ";
            mysql += "When '9' then 'Sep'  ";
            mysql += "When '10' then 'Oct'  ";
            mysql += "When '11' then 'Nov'  ";
            mysql += "When '12' then 'Dec' else 'None' End as DocMonth, BloodType, Count(BloodType)as BloodCount , DocDate, Year(DocDate)as DocYear ";
            mysql += "From tblDonor Where BloodType = '" + cboBloodType.Text + "' And (DocDate Between '" + dtpFrom.Text  + "' And '" + dtpTo.Text + "') ";
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
                    if (i >= Convert.ToInt16(nudPeriod.Value)) { lv.SubItems.Add(Convert.ToString( MovingAverage2(mySeries, 3))); }
                  
	            }
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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cboBloodType.Text == "") { MessageBox.Show("Please Select Blood Type!","Information"); return; }
            if (nudPeriod.Value < 1) { MessageBox.Show("Invalid Period"); return; }
            Generate();
        }
    }
}
