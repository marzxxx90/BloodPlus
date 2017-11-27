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
using DeathCodez;
using System.IO;
using System.Xml;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace BloodPlus
{
    class Security
    {
        static internal string HashString(string src)
        {
            return DeathCodez.Security.Encrypt(src);
        }

        static internal string EncryptString(string src)
        {
            return DeathCodez.Security.Encrypt(src);
        }

        static internal string DecryptString(string src)
        {
            return DeathCodez.Security.Decrypt(src);
        }

        static internal string CleanMyHeart(string str, string special = null)
        {
            str = str.Replace("'", "''");
            str = str.Replace("\"", "\"\"");

            if (special != null)
            {
                str = str.Replace(special, "");
            }

            return str;
        }
    }
}
