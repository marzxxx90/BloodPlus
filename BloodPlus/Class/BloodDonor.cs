using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Data;
namespace BloodPlus
{
    class BloodDonor
    {
        const string INTEGRITY_CHECK = "zVo1e+bBFcJICtuJl1vJuqalkFk9hvJq0pZO0TEaDEmBH/CqXHMGUefTsK8JRNYVAKWhaCpMB9fwfUNqHDNhj2aX2T5tuE6g";

        #region "Properties"

        private int _id;
        public virtual int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _cardnum;
        public virtual string CardNum
        {
            get { return _cardnum; }
            set { _cardnum = value; }
        }

        private string _bloodType;
        public virtual string BloodType
        {
            get { return _bloodType; }
            set { _bloodType = value; }
        }

        private string _firstName;
        public virtual string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
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

        private string _gender;
        public virtual string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        #endregion

        #region "Procedures"
        internal  void SaveBloodDonor()
        {
            string mysql = "Select * From tbldonor Limit 0";
            DataSet ds = Database.LoadSQL(mysql, "tbldonor");

            DataRow dsnewRow = null;
            dsnewRow = ds.Tables[0].NewRow();
            var with = dsnewRow;

            with["cardnum"] = _cardnum;
            with["bloodtype"] = _bloodType;
            with["firstname"] = _firstName;
            with["middlename"] = _middlename;
            with["lastname"] = _lastname;
            with["gender"] = _gender;

            ds.Tables[0].Rows.Add(dsnewRow);
            Database.SaveEntry(ds);
        }

        internal void LoadBloodDonor()
        {
            string mysql = "Select * From tblDonor Where ID = " + _id;
            DataSet ds = Database.LoadSQL(mysql, "tblDonor");

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                LoadbyRows(dr);
            }
        }

        private void LoadbyRows(DataRow dr)
        {
            _id = Convert.ToInt32(dr["ID"]);
            _cardnum = dr["cardnum"].ToString();
            _bloodType = dr["bloodtype"].ToString();
            _firstName = dr["firstname"].ToString();
            _middlename = dr["middlename"].ToString();
            _lastname = dr["lastname"].ToString();
            _gender = dr["gender"].ToString();
        }

        static internal bool TemplateIntegrityCheck(string[] headers)
        {
            string mergeHeaders = "";
            foreach (string head_loopVariable in headers)
            {
               string head = head_loopVariable;
                mergeHeaders += head;
            }
            if (Security.HashString(mergeHeaders) == INTEGRITY_CHECK)
                return true;
            return false;
        }

        #endregion
    }
}
