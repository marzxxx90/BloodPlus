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
    public partial class frmBloodList : Form
    {
        public frmBloodList()
        {
            InitializeComponent();
        }

        private void frmBloodList_Load(object sender, EventArgs e)
        {
            LoadBlood();
        }

        private void LoadBlood(string bloodtype = "")
        {
            string mysql;
            if (bloodtype == "")
            {
                mysql = "Select * From tblStock";
            }
            else
            {
                mysql = "Select * From tblStock Where BloodType = '" + bloodtype + "'";
            }
            DataSet ds = Database.LoadSQL(mysql, "tblStock");

            foreach (DataRow dr in ds.Tables[0].Rows )
            {
                ListViewItem lv = lvBlood.Items.Add(dr["BloodType"].ToString());
                lv.SubItems.Add(dr["inv"].ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBlood(txtSearch.Text);
        }
    }
}
