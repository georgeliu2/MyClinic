using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AcupunctureClinic.Desktop.Forms
{
    using AcupunctureClinic.Desktop.Forms.Membership;
    public class HMCodeEditor : frmProcedureCode
    {
        public HMCodeEditor(Manage _manage, ListBox _codes) :
            base(_manage, _codes)
        {
            this.Text = "Health /Medicine Code Editor";
            this.lblSelectedCodeList.Text = "Selected H/M Codes:";
            this.lblCodeList.Text = "H/M Code List";
        }

        protected override void LoadProcedureCodeList()
        {
            DataTable procedureCodes = manage.CustomerServiceObj.LoadHMCodes();
            if (procedureCodes == null || procedureCodes.Rows.Count == 0)
                return;
            lstbProcedureCodes.Items.Clear();
            foreach (DataRow row in procedureCodes.Rows)
            {
                lstbProcedureCodes.Items.Add(row[0].ToString());
            }
            lstbProcedureCodes.Sorted = true;
        }
    }
}
