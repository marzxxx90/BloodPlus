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
    public partial class frmRecepientList : Form
    {
        bool fromOtherForm = false;
        FormChange.FormName frmOrig;
        public frmRecepientList()
        {
            InitializeComponent();
        }

        private void ClearText()
        {
            txtSearch.Clear();
            lvRecepient.Items.Clear();
        }

        private void frmRecepientList_Load(object sender, EventArgs e)
        {
            if (!fromOtherForm)
                ClearText();

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadRecepient();

            }

            if (!fromOtherForm)
            {
                txtSearch.Focus();
            }

            txtSearch.Text = (!string.IsNullOrEmpty(txtSearch.Text) ? txtSearch.Text : "");
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                btnSearch.PerformClick();
            }
        }

        internal  void LoadRecepient(string str = "")
        {
            string mysql;
            string clean_str = str;
            clean_str = Security.CleanMyHeart(clean_str );
            string[] strWords = clean_str.Split(new char[] { ' ' });
            string name = null;
            if (str == "")
            {
                mysql = "Select * From tblRecepient Limit 50";
            }
            else
            {
                mysql = "Select * From tblRecepient Where ";
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
                DataSet ds = Database.LoadSQL(mysql, "tblRecepient");
            string tmpGender;
            lvRecepient.Items.Clear();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ListViewItem lv = lvRecepient.Items.Add(dr["Firstname"].ToString() + " " + dr["Middlename"].ToString() + " " + dr["Lastname"].ToString());
                    if (Convert.ToString(dr["Gender"]) == "F")
                    {
                        tmpGender = "Female";
                    }
                    else
                    {
                        tmpGender = "Male";
                    }
                    lv.SubItems.Add(tmpGender );
                    lv.SubItems.Add(dr["dob"].ToString());
                    lv.Tag = dr["ID"];
                }
            
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lvRecepient.SelectedItems.Count == 0) { return; }

            int idx = Convert.ToInt16(lvRecepient.FocusedItem.Tag);
            Recepient rec = new Recepient();
            rec.ID = idx;
            rec.LoadRecepient();
            //if (Application.OpenForms["frmDonor"] != null)
            //{
            //    (Application.OpenForms["frmDonor"] as frmDonor).LoadRecepientInfo(rec);
            //}
            FormChange.ReloadFormFromItemList(frmOrig,rec);
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRecepient(txtSearch.Text);
        }

        private void lvRecepient_DoubleClick(object sender, EventArgs e)
        {
            btnSelect.PerformClick();
        }

        internal void SearchSelect(string src, FormChange.FormName frmOrigin)
        {
            fromOtherForm = true;
            btnSelect.Visible = true;
            txtSearch.Text = src;
            frmOrig = frmOrigin;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mod_system.isEnter(e)) { btnSearch.PerformClick(); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmRecepient"] != null)
            {
                (Application.OpenForms["frmRecepient"] as frmRecepient).Show();
            }
            else
            {
                frmRecepient frm = new frmRecepient();
                frm.Show();
            }
        }
    }
}
