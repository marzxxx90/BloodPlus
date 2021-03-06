﻿using System;
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
            BloodRecipient = 1,
            Inventory = 2
            
        }
        public frmTransactionReport()
        {
            InitializeComponent();
        }
        internal BloodReport FormType = BloodReport.Inventory    ;
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
                case BloodReport.Inventory:
                    Inventory();
                    break;
            }
        }

        private void BloodDonor()
        {
            string mysql = "Select Main.*, (Select Count(D2.DonorID) From tblDonor D2 Where Main.DonorID = D2.DonorID) as TotalCount ";
            mysql += "From (Select D.ID, D.RefNum, D.BloodType, D.DonorID,";
            mysql += "CONCAT(P.FIRSTNAME, ' ', P.LASTNAME) AS DonorFullname, ";
            mysql += "D.DocDate, D.Status, CONCAT(U.FIRSTNAME, ' ', U.LASTNAME) AS Encoder, P.ContactNum ";
            mysql += "From tblDonor D ";
            mysql += "Inner Join tblPersonInfo P On P.ID = D.DonorID ";
            mysql += "Inner Join tblUser U On U.ID = D.EncodeBy ";
            mysql += "Where D.DocDate = '" + MonCalReport.SelectionStart.Date.ToString("yyyy-MM-dd") + "') as Main Order By Main.DocDate Desc";

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
            mysql += "From (Select Distinct(R.RecipientID)as RecipientID, R.ID, R.BloodType,  ";
            mysql += "CONCAT(P.FIRSTNAME, ' ', P.LASTNAME) AS Fullname, "; 
            mysql += "R.DocDate, R.Status, CONCAT(U.FIRSTNAME, ' ', U.LASTNAME) AS Encoder "; 
            mysql += "From tblRecipient R  ";
            mysql += "Inner Join tblPersonInfo P On P.ID = R.RecipientID  ";
            mysql += "Inner Join tblUser U On U.ID = R.EncodeBy ";
            mysql += "Where R.DocDate = '" + MonCalReport.SelectionStart.Date.ToString("yyyy-MM-dd") + "' " ;
            mysql += "Group by R.RecipientID, R.BloodType, R.DocDate ) as Main ";

            Dictionary<string, string> rptPara = new Dictionary<string, string>();
            rptPara.Add("txtDate", "Date: " + MonCalReport.SelectionStart.Date.ToString("yyyy-MM-dd"));

            frmReport frm = new frmReport();
            frm.ReportInit(mysql, "dsRecipient", @"Reports\rpt_RecipientReport.rdlc", rptPara);
            frm.Show();
        }

        private void Inventory()
        {
            string mysql = "";
            //if (rbMonthly.Checked == true)
            //{
            mysql = "Select tbl.BloodType, Sum(tbl.BloodCount) as BloodCount, Sum(tbl.D1)as DonorCount, Sum(tbl.R1)as RecipCount,  ";
                mysql += "Case Month(tbl.DocDate) ";
                mysql += "When 1 then 'Jan' ";
                mysql += "When 2 then 'Feb' ";
                mysql += "When 3 then 'Mar' ";
                mysql += "When 4 then 'Apr' ";
                mysql += "When 5 then 'May' ";
                mysql += "When 6 then 'Jun' ";
                mysql += "When 7 then 'Jul' ";
                mysql += "When 8 then 'Aug' ";
                mysql += "When 9 then 'Sep' ";
                mysql += "When 10 then 'Oct' ";
                mysql += "When 11 then 'Nov' ";
                mysql += "When 12 then 'Dec' else 'None' End as DocDate, Year(tbl.DocDate) as DocYear ";
                mysql += "From ( ";
                mysql += "Select D.BloodType ,Count(D.BloodType) as BloodCount, D.DocDate, Count(D.BloodType) as D1, '0' as R1  "; 
                mysql += " From tblDonor D ";
                mysql += "Where D.DocDate = '" + MonCalReport.SelectionStart.Date.ToString("yyyy-MM-dd") + "' ";
                mysql += "Group By D.BloodType, D.DocDate ";
                mysql += "Union ";
                mysql += "Select R.BloodType, (Count(R.BloodType) * -1) as BloodCount, R.DocDate, '0' as D1, Count(R.BloodType)as R1  "; 
                mysql +=" From tblRecipient R ";
                mysql += "Where R.DocDate = '" + MonCalReport.SelectionStart.Date.ToString("yyyy-MM-dd") + "' ";
                mysql += "Group By R.BloodType, R.DocDate ";
                mysql += ")as tbl ";
                mysql += "Group By tbl.BloodType, tbl.DocDate ";
                mysql += "Order By Month(tbl.DocDate), Year(tbl.DocDate)";
            //}
            //else
            //{
            //    mysql = "Select tbl.BloodType, Sum(tbl.BloodCount) as BloodCount, ";
            //    mysql += "tbl.DocDate, Year(tbl.DocDate) as DocYear ";
            //    mysql += "From ( ";
            //    mysql += "Select D.BloodType ,Count(D.BloodType) as BloodCount, D.DocDate From tblDonor D ";
            //    mysql += "Where D.DocDate = '" + MonCalReport.SelectionStart.Date.ToString("yyyy-MM-dd") + "' ";
            //    mysql += "Group By D.BloodType, D.DocDate ";
            //    mysql += "Union ";
            //    mysql += "Select R.BloodType, (Count(R.BloodType) * -1) as BloodCount, R.DocDate From tblRecipient R ";
            //    mysql += "Where R.DocDate = '" + MonCalReport.SelectionStart.Date.ToString("yyyy-MM-dd") + "' ";
            //    mysql += "Group By R.BloodType, R.DocDate ";
            //    mysql += ")as tbl ";
            //    mysql += "Left Join tblStock S On S.BloodType = tbl.BloodType ";
            //    mysql += "Group By tbl.BloodType, tbl.DocDate ";
            //    mysql += "Order By Month(tbl.DocDate), Year(tbl.DocDate)";
            //}


            Dictionary<string, string> rptPara = new Dictionary<string, string>();
            rptPara.Add("txtDate", "Date: " + MonCalReport.SelectionStart.Date.ToString("yyyy-MM-dd"));

            frmReport frm = new frmReport();
            frm.ReportInit(mysql, "dsStock", @"Reports\rpt_BloodInventory.rdlc", rptPara);
            frm.Show();
        }
    }
}
