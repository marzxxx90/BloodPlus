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
    public partial class frmTransactionReport : Form
    {
        public enum BloodReport : int
        {
            BloodDonor = 0,
            BloodRecipient = 1
            
        }
        public frmTransactionReport()
        {
            InitializeComponent();
        }
        internal BloodReport FormType = BloodReport.BloodDonor   ;
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            switch (FormType)
            {
                case BloodReport.BloodDonor:
                    BloodDonor();
                    break;
                case BloodReport.BloodRecipient:
                    BloodRecipient();
                    break;
            }
        }

        private void BloodDonor()
        {
            string mysql = "Select Main.*, (Select Count(D2.DonorID) From tblDonor D2 Where Main.DonorID = D2.DonorID) as TotalCount ";
            mysql += "From (Select D.ID, D.CardNum, D.BloodType, D.DonorID,";
            mysql += "CONCAT(P.FIRSTNAME, ' ', P.LASTNAME) AS DonorFullname, ";
            mysql += "D.DocDate, D.Status, CONCAT(U.FIRSTNAME, ' ', U.LASTNAME) AS Encoder, P.ContactNum ";
            mysql += "From tblDonor D ";
            mysql += "Inner Join tblPersonInfo P On P.ID = D.DonorID ";
            mysql += "Inner Join tblUser U On U.ID = D.EncodeBy ";
            mysql += "Where D.DocDate = '" + MonCalReport.SelectionStart.Date.ToString("yyyy-MM-dd") + "') as Main";

            Dictionary<string, string> rptPara = new Dictionary<string, string>();
            rptPara.Add("txtDate", "Date: " + MonCalReport.SelectionStart.Date.ToString("yyyy-MM-dd"));

            frmReport frm = new frmReport();
            frm.ReportInit(mysql, "dsDonor", @"Reports\rpt_DonorReport.rdlc", rptPara);
            frm.Show();
        }

        private void BloodRecipient()
        {
            //string mysql = "Select R.ID, R.BloodType, CONCAT(P.FIRSTNAME, ' ', P.LASTNAME) AS Fullname, ";
            //mysql += "R.DocDate, R.Status, CONCAT(U.FIRSTNAME, ' ', U.LASTNAME) AS Encoder ";
            //mysql += "From tblRecipient R ";
            //mysql += "Inner Join tblPersonInfo P On P.ID = R.RecipientID ";
            //mysql += "Inner Join tblUser U On U.ID = R.EncodeBy  ";
            //mysql += "Where R.DocDate = '" + MonCalReport.SelectionStart.Date.ToString("yyyy-MM-dd") + "'";


            string mysql = "Select Main.*, ";
            mysql += "(Select Count(R2.RecipientID) From tblRecipient R2 Where Main.RecipientID = R2.RecipientiD) as TotalCount ";
            mysql += "From (Select R.ID, R.BloodType, R.RecipientID, ";
            mysql += "CONCAT(P.FIRSTNAME, ' ', P.LASTNAME) AS Fullname, "; 
            mysql += "R.DocDate, R.Status, CONCAT(U.FIRSTNAME, ' ', U.LASTNAME) AS Encoder "; 
            mysql += "From tblRecipient R  ";
            mysql += "Inner Join tblPersonInfo P On P.ID = R.RecipientID  ";
            mysql += "Inner Join tblUser U On U.ID = R.EncodeBy ";
            mysql += "Where R.DocDate = '" + MonCalReport.SelectionStart.Date.ToString("yyyy-MM-dd") + "') as Main ";

            Dictionary<string, string> rptPara = new Dictionary<string, string>();
            rptPara.Add("txtDate", "Date: " + MonCalReport.SelectionStart.Date.ToString("yyyy-MM-dd"));

            frmReport frm = new frmReport();
            frm.ReportInit(mysql, "dsRecipient", @"Reports\rpt_RecipientReport.rdlc", rptPara);
            frm.Show();
        }
    }
}
