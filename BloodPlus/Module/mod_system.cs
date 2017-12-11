using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

namespace BloodPlus
{
   class mod_system
  {
      #region "Global Variables"

    public static System.DateTime CurrentDate = DateAndTime.Now;

    public static ComputerUser bloodUser = new ComputerUser();
    public static int UserID = bloodUser.ID;
	
	static internal bool isAuthorized = false;

	static internal string DBVERSION = "";
      #endregion

      #region "Functions"
    static internal object DigitOnly(System.Windows.Forms.KeyPressEventArgs e, bool isWhole = false)
    {
        Console.WriteLine("char: " + e.KeyChar + " -" + char.IsDigit(e.KeyChar));
        if (e.KeyChar != ControlChars.Back)
        {
            if (isWhole)
            {
                e.Handled = !(char.IsDigit(e.KeyChar));
            }
            else
            {
                e.Handled = !(char.IsDigit(e.KeyChar));
            }

        }

        return !(char.IsDigit(e.KeyChar));
    }

    static internal bool checkNumeric(TextBox txt)
    {
        if (Information.IsNumeric(txt.Text))
        {
            return true;
        }

        return false;
    }

    static internal string DreadKnight(string str, string special = null)
    {
        str = str.Replace("'", "''");
        str = str.Replace("\"", "\"\"");

        if (special != null)
        {
            str = str.Replace(special, "");
        }

        return str;
    }

    static internal bool isEnter(KeyPressEventArgs e)
    {
        if (Strings.Asc(e.KeyChar) == 13)
        {
            return true;
        }
        return false;
    }

    static internal int GetCurrentAge(System.DateTime dob)
    {
        int age = 0;
        age = DateAndTime.Today.Year - dob.Year;
        if ((dob > DateAndTime.Today.AddYears(-age)))
            age -= 1;
        return age;
    }
      #endregion
  }
}
