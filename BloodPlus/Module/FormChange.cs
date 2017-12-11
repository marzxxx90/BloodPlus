﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BloodPlus
{
    class FormChange
    {
        internal enum FormName : int
        {
            DonorBlood = 0,
            RequestBlood = 1,
        }

        static internal void ReloadFormFromItemList(FormName gotoForm, PersonInfo Selected_Recepient)
        {
            switch (gotoForm)
            {
                case FormName.DonorBlood:
                    if (Application.OpenForms["frmDonor"] != null)
                    {
                        (Application.OpenForms["frmDonor"] as frmDonor).LoadRecepientInfo(Selected_Recepient);
                    }
                    break;

                case FormName.RequestBlood:
                    if (Application.OpenForms["frmRecipient"] != null)
                    {
                        (Application.OpenForms["frmRecipient"] as frmRecipient).LoadRecepientInfo(Selected_Recepient);
                    }
                    break;

            }
        }
    }
}
