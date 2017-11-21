using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel ;

namespace BloodPlus
{
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdImport.ShowDialog();
            lblPath.Text = ofdImport.FileName;
            string strFilename = ofdImport.FileName;

            if (strFilename == "") { return; }
    
//         Load Excel
            Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook oWB;
            Microsoft.Office.Interop.Excel.Worksheet oSheet; 

            oWB = oXL.Workbooks.Open(strFilename);
            oSheet = oWB.Worksheets[1];

            int MaxColumn = oSheet.Cells[1, oSheet.Columns.Count].End(Microsoft.Office.Interop.Excel.XlDirection.xlToLeft).column;
            int MaxEntries = oSheet.Cells[oSheet.Rows.Count, 1].End(Microsoft.Office.Interop.Excel.XlDirection.xlUp).row;

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


            for (int cnt = 2; cnt <= MaxEntries; cnt++)
            {
                AddItems(oSheet, cnt);
            }

        //Memory Unload
        oSheet = null;
        oWB = null;
        oXL.Quit();
        oXL = null;

        MessageBox.Show("Data Loaded", "System Info", MessageBoxButtons.OK, MessageBoxIcon.Information ); strFilename = ""; lblPath.Text = "";
        }

        private void AddItems(Microsoft.Office.Interop.Excel.Worksheet tmpoSheet, int tmpCnt)
        {
            ListViewItem lv = lvImport.Items.Add(Convert.ToString(tmpoSheet.Cells[tmpCnt, 1].value));
            lv.SubItems.Add(Convert.ToString(tmpoSheet.Cells[tmpCnt, 2].value));
            lv.SubItems.Add(Convert.ToString(tmpoSheet.Cells[tmpCnt, 3].value));

            if (tmpoSheet.Cells[tmpCnt, 4].value != null)
            {
                lv.SubItems.Add(Convert.ToString(tmpoSheet.Cells[tmpCnt, 4].value));
            }
            else
            {
                lv.SubItems.Add("");
            }
            lv.SubItems.Add(Convert.ToString(tmpoSheet.Cells[tmpCnt, 5].value));
            lv.SubItems.Add(Convert.ToString(tmpoSheet.Cells[tmpCnt, 6].value));
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (lvImport.Items.Count == 0) { return; }

            foreach (ListViewItem  lv in lvImport.Items)
            {
                BloodDonor Donate = new BloodDonor();
                Donate.CardNum = lv.Text;
                Donate.BloodType = lv.SubItems[1].Text.ToString();
                Donate.FirstName = lv.SubItems[2].Text.ToString();
                Donate.MiddleName = lv.SubItems[3].Text.ToString();
                Donate.LastName = lv.SubItems[4].Text.ToString();
                Donate.Gender = lv.SubItems[5].Text.ToString();
                Donate.DocDate = DateTime.Now;
                Donate.SaveBloodDonor();

                Donate.AddInv(lv.SubItems[1].Text.ToString());
            }
            MessageBox.Show("Successfuly Imported", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void frmImport_Load(object sender, EventArgs e)
        {

        }
    }
}
