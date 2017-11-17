﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace BloodPlus
{
    public partial class frmLogin : Form
    {
        int i;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "") { txtUserName.Focus(); }
            if (txtPassword.Text == "") { txtPassword.Focus(); }

            string username = txtUserName.Text;
            string userpass = mod_system.DreadKnight(txtPassword.Text);

            ComputerUser loginUser = new ComputerUser();
            if (!loginUser.LoginUser(username, userpass))
            {
                i++;
                if (i >= 3)
                {
                    Interaction.MsgBox("You have reached the MAXIMUM logins. This is a recording.", MsgBoxStyle.Critical);
                    System.Environment.Exit(0);
                }
                Interaction.MsgBox("Invalid Username and password", MsgBoxStyle.Critical);
                txtPassword.Clear(); txtPassword.Focus();
                return;


            }

            // Success!
            mod_system.bloodUser = loginUser;
            mod_system.UserID = mod_system.bloodUser.ID;
            Interaction.MsgBox("Welcome " + mod_system.bloodUser.FirstName  + " " + mod_system.bloodUser.LastName);

            frmMain frm = new frmMain();
            frm.Show();

            txtPassword.Clear();
            txtUserName.Clear();
            i = 0;
            this.Hide();
        }
    }
}
