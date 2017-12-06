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
    public partial class frmDonorList : Form
    {
        public frmDonorList()
        {
            InitializeComponent();
        }

        private void frmDonorList_Load(object sender, EventArgs e)
        {
            LoadDonor();
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
                mysql = "Select D.id, D.CardNum, D.BloodType, R.Firstname, R.Middlename, R.Lastname, R.Gender, R.dob, D.DocDate, D.Status ";
                mysql +=" From tblDonor D " ;
                mysql += " Inner Join tblPersonInfo R On R.ID = D.DonorID Limit 50";
            }
            else {
                mysql = "Select D.id, D.CardNum, D.BloodType, R.Firstname, R.Middlename, R.Lastname, R.Gender, R.dob, D.DocDate, D.Status ";
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
            }
            DataSet ds = Database.LoadSQL(mysql);
            string tmpGender;
            lvDonor.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows )
            {
                ListViewItem lv = lvDonor.Items.Add(dr["CardNum"].ToString());
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
                     
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDonor(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmDonor"] != null)
            {
                (Application.OpenForms["frmDonor"] as frmDonor).Show();
            }
            else 
            {
                frmDonor frm = new frmDonor();
                frm.Show();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) {btnSearch.PerformClick();}
        }
    }
}
