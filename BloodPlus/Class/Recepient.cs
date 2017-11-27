using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace BloodPlus
{
    class Recepient
    {
        #region "Properties"
        private int _id;
        public virtual int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _firstname;
        public virtual string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        private string _middlename;
        public virtual string Middlename
        {
            get { return _middlename; }
            set { _middlename = value; }
        }

        private string _lastname;
        public virtual string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        private string _gender;
        public virtual string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private DateTime _dob;
        public virtual DateTime DateofBirth
        {
            get { return _dob; }
            set { _dob = value; }
        }

        #endregion

        #region "Procedures"
        internal void SaveRecepient()
        {
            string mysql = "Select * From tblRecepient Where Upper(firstname) = Upper('"+ _firstname +"') ";
            mysql +="And Upper(middlename) = Upper('" + _middlename + "') And Upper(Lastname) = Upper('"+ _lastname +"')";
            DataSet ds = Database.LoadSQL(mysql, "tblRecepient");

            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow dsnewRow = null;
                dsnewRow = ds.Tables[0].NewRow();
                var with = dsnewRow;

                with["firstname"] = _firstname;
                with["middlename"] = _middlename;
                with["lastname"] = _lastname;
                with["gender"] = _gender;
                with["dob"] = _dob;
                ds.Tables[0].Rows.Add(dsnewRow);
                Database.SaveEntry(ds);
            }
            else {
                var dsR = ds.Tables[0].Rows[0];
                dsR["firstname"] = _firstname;
                dsR["middlename"] = _middlename;
                dsR["lastname"] = _lastname;
                dsR["gender"] = _gender;
                dsR["dob"] = _dob;
                Database.SaveEntry(ds, false);
            }
        }

        internal void LoadRecepient()
        {
            string mysql = "Select * From tblRecepient Where id = '" + _id + "'";
            DataSet ds = Database.LoadSQL(mysql, "tblRecepient");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                LoadByRows(dr);
            }
        }

        private void LoadByRows(DataRow dr)
        {
            _id = Convert.ToInt16(dr["id"].ToString());
            _firstname = dr["Firstname"].ToString();
            _middlename = dr["Middlename"].ToString();
            _lastname = dr["Lastname"].ToString();
            _gender = dr["Gender"].ToString();
            _dob = Convert.ToDateTime(dr["dob"].ToString());
        }

        internal bool isExist(string tmpfirstname, string tmplastname, string tmpmiddlename = "")
        {
            string mysql;
            if (tmpmiddlename == "")
            {
                mysql = "Select * From tblRecepient Where Upper(firstname) = Upper('" + tmpfirstname + "') And Upper(lastname) = Upper('"+ tmplastname +"')";
            }
            else 
            {
                mysql = "Select * From tblRecepient Where Upper(firstname) = Upper('" + tmpfirstname + "') And Upper(lastname) = Upper('" + tmplastname + "') And Upper(middlename) = Upper('"+ tmpmiddlename +"')";
            }
            DataSet ds = Database.LoadSQL(mysql, "tblRecepient");

            if (ds.Tables[0].Rows.Count > 0) 
            {
                _id = Convert.ToInt16(ds.Tables[0].Rows[0]["id"]);
                LoadRecepient();
                return true;
            }
            return false;
        }

        internal void SaveImportRecepient()
        {
            string mysql = "Select * From tblRecepient Limit 0";
            DataSet ds = Database.LoadSQL(mysql, "tblRecepient");

            DataRow dsnewRow = null;
            dsnewRow = ds.Tables[0].NewRow();
            var with = dsnewRow;

            with["firstname"] = _firstname;
            with["middlename"] = _middlename;
            with["lastname"] = _lastname;
            with["gender"] = _gender;
            with["dob"] = _dob;
            ds.Tables[0].Rows.Add(dsnewRow);
            Database.SaveEntry(ds);

            loadLastID();
            LoadRecepient();
        }

        internal void loadLastID()
        {
            string mysql = "Select * From tblRecepient Order by ID Desc Limit 1";
            DataSet ds = Database.LoadSQL(mysql, "tblRecepient");

            _id = Convert.ToInt16(ds.Tables[0].Rows[0]["id"]);
        }
        #endregion
    }
}
