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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdImport.ShowDialog();
            lblPath.Text = ofdImport.FileName;
            string strFilename = ofdImport.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblPath.Text == "") { return; }

            button1.Enabled = false;
            //         Load Excel
            Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook oWB;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            oWB = oXL.Workbooks.Open(lblPath.Text );
            oSheet = oWB.Worksheets[1];

            int MaxColumn = oSheet.Cells[1, oSheet.Columns.Count].End(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft).column;
            int MaxEntries = oSheet.Cells[oSheet.Rows.Count, 1].End(Microsoft.Office.Interop.Excel.XlDirection.xlUp).row;

            pbStatus.Maximum = MaxEntries;

            string[] checkHeaders = new string[MaxColumn + 1];
            for (int cnt = 0; cnt <= MaxColumn - 1; cnt++)
            {
                checkHeaders[cnt] = oSheet.Cells[1, cnt + 1].value;
            }
            checkHeaders[MaxColumn] = oWB.Worksheets[1].name;

            if (!BloodDonor.TemplateIntegrityCheck(checkHeaders))
            {
                MessageBox.Show("Invalid Template", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pbStatus.Value += 1;
            for (int cnt = 2; cnt <= MaxEntries; cnt++)
            {
                BloodRecipient Recip = new BloodRecipient();
                PersonInfo Claimer = new PersonInfo();
                var r = Recip;
                r.BloodType = oSheet.Cells[cnt, 2].value;
                if (Claimer.isExist(oSheet.Cells[cnt, 3].value, oSheet.Cells[cnt, 5].value, oSheet.Cells[cnt, 4].value))
                {
                    r.RecipientInfo = Claimer;
                }
                else
                {
                    Claimer.Firstname = oSheet.Cells[cnt, 3].value; 
                    Claimer.Middlename = oSheet.Cells[cnt, 4].value; 
                    Claimer.Lastname = oSheet.Cells[cnt, 5].value;
                    Claimer.Gender = oSheet.Cells[cnt, 6].value;
                    Claimer.DateofBirth = Convert.ToDateTime(oSheet.Cells[cnt, 7].value);
                    Claimer.SaveImportRecepient();

                    r.RecipientInfo  = Claimer;
                }
                if (chkRandom.Checked == true)
                {
                    Random rnd = new Random();
                    //From 1 to 500 ang iyang random
                    int i = rnd.Next(1, 500);

                    if (i > 600) { i = i - 500; }
                    i = i - 500;
                    r.DocDate = DateTime.Now.AddDays(i);
                }
                else
                {
                    r.DocDate = DateTime.Now;
                }
                r.SaveRecipient();

                r.DeductInv(oSheet.Cells[cnt, 2].value);
                pbStatus.Value += 1;
                System.Windows.Forms.Application.DoEvents();
            }

            //Memory Unload
            oSheet = null;
            oWB = null;
            oXL.Quit();
            oXL = null;

            button1.Enabled = true;
            MessageBox.Show("Data Loaded", "System Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
