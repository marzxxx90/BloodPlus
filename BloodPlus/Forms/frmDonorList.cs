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
            if (str == "")
            {
                mysql = "Select * From tblDonor Limit 50";
            }
            else {
                mysql = "Select * From tblDonor Where";
            }
            DataSet ds = Database.LoadSQL(mysql, "tblDonor");
            string tmpGender;
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

        }
    }
}
