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
        const string INTEGRITY_CHECK = "zVo1e+bBFcJICtuJl1vJuqalkFk9hvJq0pZO0TEaDEmBH/CqXHMGUefTsK8JRNYVAKWhaCpMB9cu1IM3iE/2uwvatnU3hakx9B+hoKOBWwf59TkSKFU6dYctMUxpeDsWgRSUjH6XasE=";

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

        private int _donorID;
        public virtual int DonorID
        {
            get { return _donorID; }
            set { _donorID = value; }
        }

        private PersonInfo _recepient;
        public virtual PersonInfo Recepient
        {
            get { return _recepient; }
            set { _recepient = value; }
        }

        private DateTime _docDate;
        public virtual DateTime DocDate
        {
            get { return _docDate; }
            set { _docDate = value; }
        }

        private string _status;
        public virtual string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _encodeby;
        public virtual int EncodeBy
        {
            get { return _encodeby; }
            set { _encodeby = value; }
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

            with["refnum"] = _cardnum;
            with["bloodtype"] = _bloodType;
            with["DonorID"] = _recepient.ID;
            with["DocDate"] = _docDate;
            with["Status"] = 1;
            with["encodeby"] = _encodeby;
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
            _cardnum = dr["refnum"].ToString();
            _bloodType = dr["bloodtype"].ToString();
            //_firstName = dr["firstname"].ToString();
            //_middlename = dr["middlename"].ToString();
            //_lastname = dr["lastname"].ToString();
            //_gender = dr["gender"].ToString();
            _recepient = new PersonInfo();
            _recepient.ID = Convert.ToInt16(dr["DonorID"]);
            _recepient.LoadRecepient();
            _docDate = Convert.ToDateTime ( dr["DocDate"].ToString());
            _encodeby = Convert.ToInt16(dr["encodeby"].ToString());
            _status = dr["Status"].ToString();
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

        internal void AddInv(string type, int inv = 1)
        {
            string mysql = "Select * From tblStock Where bloodType = '"+ type +"'";
            DataSet ds = Database.LoadSQL(mysql,"tblStock");
            if (ds.Tables[0].Rows.Count == 0) { return; }
            int oldVal = Convert.ToInt16(Convert.ToInt16( ds.Tables[0].Rows[0]["Inv"].ToString()) + inv);
            ds.Tables[0].Rows[0]["Inv"] = oldVal;
            Database.SaveEntry(ds, false);
        }

        internal void DeductInv(string type, int inv = 1)
        {
            string mysql = "Select * From tblStock Where bloodType = '" + type + "'";
            DataSet ds = Database.LoadSQL(mysql, "tblStock");
            if (ds.Tables[0].Rows.Count == 0) { return; }
            int oldVal = Convert.ToInt16(Convert.ToInt16(ds.Tables[0].Rows[0]["Inv"].ToString()) - inv);
            ds.Tables[0].Rows[0]["Inv"] = oldVal;
            Database.SaveEntry(ds, false);
        }

        internal void UpdateStatus()
        {
            string mysql = "Select * From tblDonor Where ID = '"+ _id +"'";
            DataSet ds = Database.LoadSQL(mysql, "tblDonor");

            ds.Tables[0].Rows[0]["Status"] = 0;
            Database.SaveEntry(ds,false);
        }

        internal int loadLastID()
        {
            string mysql = "Select * From tblDonor Order by ID Desc Limit 1";
            DataSet ds = Database.LoadSQL(mysql, "tblDonor");

            return Convert.ToInt16(ds.Tables[0].Rows[0]["id"]);
        }

        #endregion
    }
}
