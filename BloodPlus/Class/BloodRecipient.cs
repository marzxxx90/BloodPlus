using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace BloodPlus
{
    class BloodRecipient
    {
        #region "Properties"

        private int _id;
        public virtual int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _docDate;
        public virtual DateTime DocDate
        {
            get { return _docDate; }
            set { _docDate = value; }
        }

        private string _bloodType;
        public virtual string BloodType
        {
            get { return _bloodType; }
            set { _bloodType = value; }

        }

        private PersonInfo _recipientInfo;
        public virtual PersonInfo RecipientInfo
        {
            get { return _recipientInfo; }
            set { _recipientInfo = value; }
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

        #region "Properties"
        internal void SaveRecipient()
        {
            string mysql = "Select * From tblRecipient Limit 0";
            DataSet ds = Database.LoadSQL(mysql, "tblRecipient");
            DataRow dsnewRow = null;
            dsnewRow = ds.Tables[0].NewRow();
            var with = dsnewRow;

            with["DocDate"] = _docDate ;
            with["bloodtype"] = _bloodType;
            with["RecipientID"] = _recipientInfo.ID;
            with["Status"] = 1;
            with["encodeby"] = _encodeby;
            ds.Tables[0].Rows.Add(dsnewRow);
            Database.SaveEntry(ds);
        }

        internal void LoadRecipient()
        {
            string mysql = "Select * From tblRecipient Where ID = " + _id ;
            DataSet ds = Database.LoadSQL(mysql, "tblRecipient");

            foreach (DataRow  dr in ds.Tables[0].Rows )
            {
                LoadByRows(dr);
            }
        }

        private void LoadByRows(DataRow dr)
        {
            _id = Convert.ToInt16(dr["ID"]);
            _docDate = Convert.ToDateTime(dr["DocDate"]);
            _bloodType = dr["BloodType"].ToString();

            _recipientInfo = new PersonInfo();
            _recipientInfo.ID = Convert.ToInt16(dr["RecipientID"]);
            _recipientInfo.LoadRecepient();

            _status = dr["Status"].ToString();
            _encodeby = Convert.ToInt16(dr["EncodeBy"]);
        }

        internal void AddInv(string type, int inv = 1)
        {
            string mysql = "Select * From tblStock Where bloodType = '" + type + "'";
            DataSet ds = Database.LoadSQL(mysql, "tblStock");

            int oldVal = Convert.ToInt16(Convert.ToInt16(ds.Tables[0].Rows[0]["Inv"].ToString()) + inv);
            ds.Tables[0].Rows[0]["Inv"] = oldVal;
            Database.SaveEntry(ds, false);
        }

        internal void DeductInv(string type, int inv = 1)
        {
            string mysql = "Select * From tblStock Where bloodType = '" + type + "'";
            DataSet ds = Database.LoadSQL(mysql, "tblStock");

            int oldVal = Convert.ToInt16(Convert.ToInt16(ds.Tables[0].Rows[0]["Inv"].ToString()) - inv);
            ds.Tables[0].Rows[0]["Inv"] = oldVal;
            Database.SaveEntry(ds, false);
        }

        internal int GetBloodInv(string type)
        {
            string mysql = "Select * From tblStock Where BloodType = '" + type + "'";
            DataSet ds = Database.LoadSQL(mysql, "tblStock");

            return Convert.ToInt32(ds.Tables[0].Rows[0]["Inv"].ToString()) ;
        }

        #endregion
    }
}
