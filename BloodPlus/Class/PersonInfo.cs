using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace BloodPlus
{
    class PersonInfo
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

        private string _contactnum;
        public virtual string ContactNum
        {
            get { return _contactnum; }
            set { _contactnum  = value; }
        }

        private string _maritalStatus;
        public virtual string MaritalStatus
        {
            get { return _maritalStatus; }
            set { _maritalStatus = value; }
        }

        private string _presentStreet;
        public virtual string PresentStreet
        {
            get { return _presentStreet; }
            set { _presentStreet = value; }
        }

        private string _presentBarangay;
        public virtual string PresentBarangay
        {
            get { return _presentBarangay; }
            set { _presentBarangay = value; }
        }

        private string _presentCity;
        public virtual string PresentCity
        {
            get { return _presentCity; }
            set { _presentCity = value; }
        }

        private string _presentProvince;
        public virtual string PresentProvince
        {
            get { return _presentProvince; }
            set { _presentProvince = value; }
        }

        private string _presentZipcode;
        public virtual string PresentZipCode
        {
            get { return _presentZipcode; }
            set { _presentZipcode = value; }
        }

        private string _permanentStreet;
        public virtual string PermanentStreet
        {
            get { return _permanentStreet; }
            set { _permanentStreet = value; }
        }

        private string _permanentBarangay;
        public virtual string PermanentBarangay
        {
            get { return _permanentBarangay; }
            set { _permanentBarangay = value; }
        }

        private string _permanentCity;
        public virtual string PermanentCity
        {
            get { return _permanentCity; }
            set { _permanentCity = value; }
        }

        private string _permanentProvince;
        public virtual string PermanentProvince
        {
            get { return _permanentProvince; }
            set { _permanentProvince = value; }
        }

        private string _permanentZipcode;
        public virtual string PermanentZipcode
        {
            get { return _permanentZipcode; }
            set { _permanentZipcode = value; }
        }
        #endregion

        #region "Procedures"
        internal void SaveRecepient()
        {
            string mysql = "Select * From tblPersonInfo Where Upper(firstname) = Upper('"+ _firstname +"') ";
            mysql +="And Upper(middlename) = Upper('" + _middlename + "') And Upper(Lastname) = Upper('"+ _lastname +"')";
            DataSet ds = Database.LoadSQL(mysql, "tblPersonInfo");

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
                with["contactNum"] = _contactnum ;
                with["maritalStatus"] = _maritalStatus ;
                with["preStreet"] = _presentStreet ;
                with["preBarangay"] = _presentBarangay ;
                with["preCity"] = _presentCity ;
                with["preProvince"] = _presentProvince ;
                with["preZipcode"] = _presentZipcode ;
                with["perStreet"] = _permanentStreet ;
                with["perBarangay"] = _permanentBarangay ;
                with["perCity"] = _permanentCity ;
                with["perProvince"] = _permanentProvince ;
                with["perZipcode"] = _permanentZipcode ;
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
                dsR["contactNum"] = _contactnum;
                dsR["maritalStatus"] = _maritalStatus;
                dsR["preStreet"] = _presentStreet;
                dsR["preBarangay"] = _presentBarangay;
                dsR["preCity"] = _presentCity;
                dsR["preProvince"] = _presentProvince;
                dsR["preZipcode"] = _presentZipcode;
                dsR["perStreet"] = _permanentStreet;
                dsR["perBarangay"] = _permanentBarangay;
                dsR["perCity"] = _permanentCity;
                dsR["perProvince"] = _permanentProvince;
                dsR["perZipcode"] = _permanentZipcode;
                Database.SaveEntry(ds, false);
            }
        }

        internal void UpdatePersonInfo()
        {
            string mysql = "Select * From tblPersonInfo Where ID = " + _id ;
            DataSet ds = Database.LoadSQL(mysql, "tblPersonInfo");

            var dsR = ds.Tables[0].Rows[0];
            dsR["firstname"] = _firstname;
            dsR["middlename"] = _middlename;
            dsR["lastname"] = _lastname;
            dsR["gender"] = _gender;
            dsR["dob"] = _dob;
            dsR["contactNum"] = _contactnum;
            dsR["maritalStatus"] = _maritalStatus;
            dsR["preStreet"] = _presentStreet;
            dsR["preBarangay"] = _presentBarangay;
            dsR["preCity"] = _presentCity;
            dsR["preProvince"] = _presentProvince;
            dsR["preZipcode"] = _presentZipcode;
            dsR["perStreet"] = _permanentStreet;
            dsR["perBarangay"] = _permanentBarangay;
            dsR["perCity"] = _permanentCity;
            dsR["perProvince"] = _permanentProvince;
            dsR["perZipcode"] = _permanentZipcode;
            Database.SaveEntry(ds, false);
        }

        internal void LoadRecepient()
        {
            string mysql = "Select * From tblPersonInfo Where id = '" + _id + "'";
            DataSet ds = Database.LoadSQL(mysql, "tblPersonInfo");

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
            _contactnum = dr["ContactNum"].ToString();
            _maritalStatus = dr["maritalStatus"].ToString();
            _presentStreet = dr["preStreet"].ToString();
            _presentBarangay = dr["preBarangay"].ToString();
            _presentCity = dr["preCity"].ToString();
            _presentProvince = dr["preProvince"].ToString();
            _presentZipcode = dr["preZipcode"].ToString();
            _permanentStreet = dr["perStreet"].ToString();
            _permanentBarangay = dr["perBarangay"].ToString();
            _permanentCity = dr["perCity"].ToString();
            _permanentProvince = dr["perProvince"].ToString();
            _permanentZipcode = dr["perZipcode"].ToString();
        }

        internal bool isExist(string tmpfirstname, string tmplastname, string tmpmiddlename = "")
        {
            string mysql;
            if (tmpmiddlename == "" | tmpmiddlename == null)
            {
                mysql = "Select * From tblPersonInfo Where Upper(firstname) = Upper('" + tmpfirstname + "') And Upper(lastname) = Upper('" + tmplastname + "')";
            }
            else 
            {
                mysql = "Select * From tblPersonInfo Where Upper(firstname) = Upper('" + tmpfirstname + "') And Upper(lastname) = Upper('" + tmplastname + "') And Upper(middlename) = Upper('" + tmpmiddlename + "')";
            }
            DataSet ds = Database.LoadSQL(mysql, "tblPersonInfo");

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
            string mysql = "Select * From tblPersonInfo Limit 0";
            DataSet ds = Database.LoadSQL(mysql, "tblPersonInfo");

            DataRow dsnewRow = null;
            dsnewRow = ds.Tables[0].NewRow();
            var with = dsnewRow;

            with["firstname"] = _firstname;
            with["middlename"] = _middlename;
            with["lastname"] = _lastname;
            with["gender"] = _gender;
            with["dob"] = _dob;
            with["contactNum"] = _contactnum;
            with["maritalStatus"] = _maritalStatus;
            with["preStreet"] = _presentStreet;
            with["preBarangay"] = _presentBarangay;
            with["preCity"] = _presentCity;
            with["preProvince"] = _presentProvince;
            with["preZipcode"] = _presentZipcode;
            with["perStreet"] = _permanentStreet;
            with["perBarangay"] = _permanentBarangay;
            with["perCity"] = _permanentCity;
            with["perProvince"] = _permanentProvince;
            with["perZipcode"] = _permanentZipcode;
            ds.Tables[0].Rows.Add(dsnewRow);
            Database.SaveEntry(ds);

            loadLastID();
            LoadRecepient();
        }

        internal void loadLastID()
        {
            string mysql = "Select * From tblPersonInfo Order by ID Desc Limit 1";
            DataSet ds = Database.LoadSQL(mysql, "tblRecepient");

            _id = Convert.ToInt16(ds.Tables[0].Rows[0]["id"]);
        }
        #endregion
    }
}
