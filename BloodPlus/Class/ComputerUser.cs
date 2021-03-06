﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BloodPlus
{
    class ComputerUser
    {
        #region "Properties"
        private int _id;
        public virtual int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _username;
        public virtual string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _userpassword;
        public virtual string UserPassword
        {
            get { return _userpassword; }
            set { _userpassword = value; }
        }

        private string _firstname;
        public virtual string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        private string _middlename;
        public virtual string MiddleName
        {
            get { return _middlename; }
            set { _middlename = value; }
        }

        private string _lastname;
        public virtual string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        private string _status;
        public virtual string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        //private string _role;
        //public virtual string Role
        //{
        //    get { return _role; }
        //    set { _status = value; }
        //}

        private string _tmpRole;
        public virtual string TmpRole
        {
            get { return _tmpRole; }
            set { _tmpRole = value; }
        }
        #endregion

        #region "Procedures"
        internal void SaveUser()
        {
            string mysql = "Select * From tblUser Limit 0";
            DataSet ds = Database.LoadSQL(mysql, "tblUser");

            DataRow dsNewRow = null;
            dsNewRow = ds.Tables[0].NewRow();
            var _with3 = dsNewRow;
            _with3["UserName"] = _username ;
            _with3["UserPassword"] = _userpassword ;
            _with3["Firstname"] = _firstname;
            _with3["Middlename"] = _middlename ;
            _with3["Lastname"] = _lastname ;
            _with3["Role"] = _tmpRole;
            _with3["Status"] = _status;
            ds.Tables["tblUser"].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
        }

        internal void UpdateUser()
        {
            string mysql = "Select * From tblUser Where id = " + _id ;
            DataSet ds = Database.LoadSQL(mysql, "tblUser");

            ds.Tables[0].Rows[0]["UserPassword"] = _userpassword;
            ds.Tables[0].Rows[0]["Role"] = _tmpRole;
            ds.Tables[0].Rows[0]["Status"] = _status;

            Database.SaveEntry(ds, false);
        }

        internal void LoadUser()
        {
            string mysql = "Select * From tblUser Where ID = " + _id ;
            DataSet ds = Database.LoadSQL(mysql, "tblUser");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadbyRows(dr);
            }
        }

        private void LoadbyRows(DataRow dr)
        {
            _id = Convert.ToInt32(dr["ID"]);
            _username = dr["UserName"].ToString();
            _userpassword = dr["UserPassword"].ToString();
            _firstname = dr["Firstname"].ToString();
            _middlename = dr["Middlename"].ToString();
            _lastname = dr["Lastname"].ToString();
            _tmpRole = dr["Role"].ToString();
            _status = dr["Status"].ToString();
        }

        public bool LoginUser(string user, string password)
        {
            string mySql = "SELECT ID, LOWER(Username) FROM tblUser ";
            mySql += string.Format(" WHERE LOWER(Username) = LOWER('{0}') AND UserPassword = '{1}' AND STATUS <> '0'", user, DeathCodez.Security.Encrypt(password));
            DataSet ds = null;

            ds = Database.LoadSQL(mySql);
            if (ds.Tables[0].Rows.Count == 0)
                return false;

            _id  = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
            LoadUser();

            return true;
        }
        #endregion
    }
}
