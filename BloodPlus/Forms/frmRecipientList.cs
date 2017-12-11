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
    public partial class frmRecipientList : Form
    {
        public frmRecipientList()
        {
            InitializeComponent();
        }

        private void frmRecipientList_Load(object sender, EventArgs e)
        {
            LoadRecipient();
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
                mysql = "Select R.ID, R.DocDate, R.BloodType, P.Firstname, P.Middlename, P.Lastname ";
                mysql += "From tblRecipient R ";
                mysql +="Inner Join tblPersonInfo P On P.ID = R.RecipientID Limit 50";
            }
            else 
            {
                mysql = "Select R.ID, R.DocDate, R.BloodType, P.Firstname, P.Middlename, P.Lastname ";
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
            }

            DataSet ds = Database.LoadSQL(mysql);

            lvRecipient.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows )
            {
                ListViewItem lv = lvRecipient.Items.Add(dr["DocDate"].ToString());
                lv.SubItems.Add(dr["BloodType"].ToString());
                lv.SubItems.Add(dr["FirstName"].ToString() + " " + dr["Middlename"].ToString() + " " + dr["Lastname"].ToString());
                lv.Tag = Convert.ToInt16(dr["ID"]);
            }
 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRecipient(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRecipient"] != null)
            {
                (Application.OpenForms["frmRecipient"] as frmRecipient).Show();
            }
            else
            {
                frmRecipient frm = new frmRecipient();
                frm.Show();
            }
        }
    }
}
