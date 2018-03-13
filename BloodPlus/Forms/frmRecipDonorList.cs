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
    public partial class frmRecipDonorList : Form
    {
        public frmRecipDonorList()
        {
            InitializeComponent();
        }

        private void frmRecipDonorList_Load(object sender, EventArgs e)
        {

        }

        private void LoadDonor(string str = "")
        {
            string mysql;
            string clean_str = str;
            clean_str = Security.CleanMyHeart(clean_str);
            string[] strWords = clean_str.Split(new char[] { ' ' });
            string name = null;
            if (str == "")
            {
                mysql = "Select D.id, D.RefNum, D.BloodType, R.Firstname, R.Middlename, R.Lastname, R.Gender, R.dob, D.DocDate, D.Status ";
                mysql += " From tblDonor D ";
                mysql += " Inner Join tblPersonInfo R On R.ID = D.DonorID Order By DocDate Desc, ID Desc Limit 50";
            }
            else
            {
                mysql = "Select D.id, D.RefNum, D.BloodType, R.Firstname, R.Middlename, R.Lastname, R.Gender, R.dob, D.DocDate, D.Status ";
                mysql += " From tblDonor D ";
                mysql += " Inner Join tblPersonInfo R On R.ID = D.DonorID ";
                mysql += " Where ";

                foreach (string name_loopVariable in strWords)
                {
                    name = name_loopVariable;
                    mysql += " CONCAT(FIRSTNAME, ',', LASTNAME) LIKE UPPER('%" + name + "%') and ";
                    if (object.ReferenceEquals(name, strWords.Last()))
                    {
                        mysql += " CONCAT(FIRSTNAME, ',', LASTNAME) LIKE UPPER('%" + name + "%') ";
                        break;
                    }
                }
                mysql += " Order By DocDate Desc, ID Desc ";
            }
            DataSet ds = Database.LoadSQL(mysql);
            string tmpGender;
            lvRecipDonor.Items.Clear();
            lvRecipDonor.Columns[0].Width = 173;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListViewItem lv = lvRecipDonor.Items.Add(dr["RefNum"].ToString());
                lv.SubItems.Add(dr["BloodType"].ToString());
                lv.SubItems.Add(dr["FirstName"].ToString() + " " + dr["Middlename"].ToString() + " " + dr["Lastname"].ToString());
                if (Convert.ToString(dr["Gender"]) == "F")
                {
                    tmpGender = "Female";
                }
                else
                {
                    tmpGender = "Male";
                }

                lv.SubItems.Add(tmpGender);
                lv.SubItems.Add(Convert.ToDateTime(dr["DocDate"].ToString()).ToString("yyyy/MM/dd"));

            }

        }

        private void LoadRecipient(string str = "")
        {
            string mysql;
            string clean_str = str;
            clean_str = Security.CleanMyHeart(clean_str);
            string[] strWords = clean_str.Split(new char[] { ' ' });
            string name = null;
            if (str == "")
            {
                mysql = "Select R.ID, R.RefNum, R.DocDate, R.BloodType, P.Firstname, P.Middlename, P.Lastname, P.Gender ";
                mysql += "From tblRecipient R ";
                mysql += "Inner Join tblPersonInfo P On P.ID = R.RecipientID Order By DocDate Desc, ID Desc Limit 50";
            }
            else
            {
                mysql = "Select R.ID, R.RefNum, R.DocDate, R.BloodType, P.Firstname, P.Middlename, P.Lastname, P.Gender ";
                mysql += "From tblRecipient R ";
                mysql += "Inner Join tblPersonInfo P On P.ID = R.RecipientID ";
                mysql += "Where ";

                foreach (string name_loopVariable in strWords)
                {
                    name = name_loopVariable;
                    mysql += " CONCAT(P.FIRSTNAME, ',', P.LASTNAME) LIKE UPPER('%" + name + "%') and ";
                    if (object.ReferenceEquals(name, strWords.Last()))
                    {
                        mysql += " CONCAT(P.FIRSTNAME, ',', P.LASTNAME) LIKE UPPER('%" + name + "%') ";
                        break;
                    }
                }

                mysql += " Order By DocDate Desc, ID Desc ";
            }

            DataSet ds = Database.LoadSQL(mysql);

            lvRecipDonor.Items.Clear();
            string tmpGender;
            //lvRecipDonor.Columns[0].Width = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListViewItem lv = lvRecipDonor.Items.Add(dr["RefNum"].ToString());
                lv.SubItems.Add(dr["BloodType"].ToString());
                lv.SubItems.Add(dr["FirstName"].ToString() + " " + dr["Middlename"].ToString() + " " + dr["Lastname"].ToString());
                if (Convert.ToString(dr["Gender"]) == "F")
                {
                    tmpGender = "Female";
                }
                else
                {
                    tmpGender = "Male";
                }

                lv.SubItems.Add(tmpGender);
                lv.SubItems.Add(Convert.ToDateTime(dr["DocDate"].ToString()).ToString("yyyy/MM/dd"));
                lv.Tag = Convert.ToInt16(dr["ID"]);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRecipDonor"] != null)
            {
                (Application.OpenForms["frmRecipDonor"] as frmRecipDonor).isNewTransaction = true;
                (Application.OpenForms["frmRecipDonor"] as frmRecipDonor).Show();
               
            }
            else
            {
                frmRecipDonor frm = new frmRecipDonor();
                frm.isNewTransaction = true;
                frm.Show();
              
            }
        }

        private void btnCurrent_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRecipDonor"] != null)
            {
                (Application.OpenForms["frmRecipDonor"] as frmRecipDonor).isNewTransaction = false;
                (Application.OpenForms["frmRecipDonor"] as frmRecipDonor).Show();
                
            }
            else
            {
                frmRecipDonor frm = new frmRecipDonor();
                frm.isNewTransaction = false;
                frm.Show();
               
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rbDonor.Checked == true)
            {
                LoadDonor(txtSearch.Text);
            }
            else
            {
                LoadRecipient(txtSearch.Text);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) { btnSearch.PerformClick(); }
        }
    }
}
