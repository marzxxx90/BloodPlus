using System;
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

        private string _rule;
        public virtual string Rule
        {
            get { return _rule; }
            set { _status = value; }
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
            _with3["Rule"] = _rule ;
            _with3["Status"] = _status;
            ds.Tables["tblUser"].Rows.Add(dsNewRow);
            Database.SaveEntry(ds);
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
            _rule =dr["Rule"].ToString();
            _status = dr["Status"].ToString();
        }
        #endregion
    }
}
