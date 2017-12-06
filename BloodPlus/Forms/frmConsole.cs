using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BloodPlus
{
    public partial class frmConsole : Form
    {
        public frmConsole()
        {
            InitializeComponent();
        }

        internal void ClearLogs()
        {
            pbStatus.Value = 0;
        }

        internal void SetValue(int setVal)
        {
            pbStatus.Maximum = setVal;
        }

        internal void AddtoList()
        {
            pbStatus.Value += 1;
        }
    }
}
