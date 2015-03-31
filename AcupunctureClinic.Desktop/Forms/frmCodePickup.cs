using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AcupunctureClinic.Desktop.Forms
{
    using AcupunctureClinic.Desktop.Forms.Membership;
    public partial class frmCodePickup : Form
    {
        protected Manage manage;
        protected ListBox codes;
        
        public ListBox SelectedProcedureCodes
        { get { return lstbSelectedProcedureCodes; } }

        public frmCodePickup(Manage _manage, ListBox _codes)
        {
            manage = _manage;
            codes = _codes;
            InitializeComponent();
            LoadProcedureCodeList();
            lstbSelectedProcedureCodes.Items.Clear();
            foreach (Object code in codes.Items)
                if(code.ToString().Trim() != "" )
                    lstbSelectedProcedureCodes.Items.Add(code);
            foreach (var item in lstbSelectedProcedureCodes.Items)
                lstbProcedureCodes.Items.Remove(item);
            lstbSelectedProcedureCodes.Sorted = true;
        }

        private void btn1Done_Click(object sender, EventArgs e)
        {
            codes.Items.Clear();
            foreach (Object code in lstbSelectedProcedureCodes.Items)
                if (code.ToString().Trim() != "")
                    codes.Items.Add(code);
            this.Close();
        }

        protected virtual void LoadProcedureCodeList()
        {
            DataTable procedureCodes = manage.CustomerServiceObj.LoadProcedureCodes();
            if (procedureCodes == null || procedureCodes.Rows.Count == 0)
                return;
            lstbProcedureCodes.Items.Clear();
            foreach (DataRow row in procedureCodes.Rows)
            {
                lstbProcedureCodes.Items.Add(row[0].ToString());
            }
            lstbProcedureCodes.Sorted = true;
        }

        private void btn1Clear_Click(object sender, EventArgs e)
        {
            if (lstbSelectedProcedureCodes.Items.Count > 0)
            {
                foreach (Object item in lstbSelectedProcedureCodes.Items)
                    lstbProcedureCodes.Items.Add(item);
                lstbProcedureCodes.Sorted = true;
            }
            lstbSelectedProcedureCodes.Items.Clear();

        }

        private void btn1Quite_Click(object sender, EventArgs e)
        {
            manage.Show();
            this.Close();
            manage.BringToFront();
        }

        private void btn1Add_Click(object sender, EventArgs e)
        {
            if (lstbProcedureCodes.SelectedItems == null)
                return;
            List<string> selectedItems = lstbProcedureCodes.SelectedItems.Cast<String>().ToList();
            foreach (var item in selectedItems)
                lstbSelectedProcedureCodes.Items.Add(item);
            foreach (Object item in selectedItems)
                lstbProcedureCodes.Items.Remove(item);
            lstbSelectedProcedureCodes.Sorted = true;
        }

        private void btn1Remove_Click(object sender, EventArgs e)
        {
            if (lstbSelectedProcedureCodes.Items.Count > 0)
            {
                List<string> selectedItems = this.lstbSelectedProcedureCodes.SelectedItems.Cast<String>().ToList();

                foreach (Object item in selectedItems)
                    lstbProcedureCodes.Items.Add(item);
                lstbProcedureCodes.Sorted = true;
                foreach (Object item in selectedItems)
                    lstbSelectedProcedureCodes.Items.Remove(item);
            }
        }
    }
}
