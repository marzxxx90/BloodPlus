using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace BloodPlus
{
    class Maintenance
    {
        internal void UpdateSettings(string key, string val)
        {
            string mysql = "Select * From tblMaintenance Where m_Key = '"+ key +"'";
            DataSet ds = Database.LoadSQL(mysql, "tblMaintenance");

            if (ds.Tables[0].Rows.Count == 0)
            {
                DataRow dsnewRow = null;
                dsnewRow = ds.Tables[0].NewRow();
                var with = dsnewRow;

                with["m_key"] = key;
                with["m_value"] = val;
                ds.Tables[0].Rows.Add(dsnewRow);
                Database.SaveEntry(ds);
            }
            else
            {
                ds.Tables[0].Rows[0]["m_value"] = val;
                Database.SaveEntry(ds, false);
            }
        }

        internal string GetSettingsVal(string Optkey)
        {
            string mysql ="Select * From tblMaintenance Where m_key = '" + Optkey +"'";
            DataSet ds = Database.LoadSQL(mysql,"tblMaintenance");

            if (ds.Tables[0].Rows.Count == 0) { return ""; }
            return Convert.ToString(ds.Tables[0].Rows[0]["m_value"]);
        }
    }
}
