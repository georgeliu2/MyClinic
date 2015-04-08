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
        protected DataGridView DtgvCodes
        { get { return dtgvCodes; } }

        protected DataGridView DtgvSelectedCodes
        { get { return dtgvSelectedCodes; } }

        public frmCodePickup(Manage _manage, ListBox _codes)
        {
            manage = _manage;
            codes = _codes;
            InitializeComponent();
            LoadProcedureCodeList();
            PopulateSelectedCodes();
        }

        protected virtual void initialSelectedList()
        {
            dtgvSelectedCodes.DataSource = null;
            dtgvSelectedCodes.Rows.Clear();
            int columns = 3;
            dtgvSelectedCodes.ColumnCount = columns;
            dtgvSelectedCodes.Columns[0].HeaderCell.Value = "Procedure Code";
            dtgvSelectedCodes.Columns[1].HeaderCell.Value = "Description";
            dtgvSelectedCodes.Columns[2].HeaderCell.Value = "Price";
        }

        private void PopulateSelectedCodes()
        {
            initialSelectedList();
            foreach (Object code in codes.Items)
            {
                DataGridViewRow row = PickupRow(dtgvCodes, code.ToString());
                if (row != null)
                {
                    AddRowValue(dtgvSelectedCodes, row);
                    dtgvCodes.Rows.Remove(row);
                }
            }

            DataGridViewColumn sortingColumn = dtgvSelectedCodes.Columns[0];
            ListSortDirection direction = ListSortDirection.Ascending;
            dtgvSelectedCodes.Sort(sortingColumn, direction);
        }

        private DataGridViewRow  PickupRow(DataGridView dtgvList, string code)
        {
            foreach (DataGridViewRow row in dtgvList.Rows)
            {
                if( (row.Cells[0].Value != null) &&
                        (row.Cells[0].Value.ToString().Trim() == code.Trim()) )
                    return row;
            }
            return null;
        }

        private void btn1Done_Click(object sender, EventArgs e)
        {
            codes.Items.Clear();
            foreach (DataGridViewRow row in dtgvSelectedCodes.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string code = row.Cells[0].Value.ToString().Trim();
                    if (code != "")
                        codes.Items.Add(code);
                }
            }
            this.Close();
        }

        protected virtual void LoadProcedureCodeList()
        {
            DataTable procedureCodes = manage.CustomerServiceObj.LoadProcedureCodes();
            if (procedureCodes == null || procedureCodes.Rows.Count == 0)
                return;

            //Fill out dtgvProcedureCodes
            dtgvCodes.RowHeadersVisible = true;

            if (procedureCodes != null)
            {
                dtgvCodes.DataSource = null;
                dtgvCodes.Rows.Clear();
                int columns = 3;
                dtgvCodes.ColumnCount = columns;
                dtgvCodes.Columns[0].HeaderCell.Value = "Procedure Code";
                dtgvCodes.Columns[1].HeaderCell.Value = "Description";
                dtgvCodes.Columns[2].HeaderCell.Value = "Price";
                int cl = procedureCodes.Columns.Count;
                for (int i = 0; i < procedureCodes.Rows.Count; i++)
                {
                    DataRow procedureCode = procedureCodes.Rows[i];
                    if (cl == 3)
                        AddRowValue(dtgvCodes, procedureCode[0].ToString(), procedureCode[1].ToString(), procedureCode[2].ToString());
                    else
                        AddRowValue(dtgvCodes, procedureCode[0].ToString(), procedureCode[1].ToString());

                }

            }

        }

        private void btn1Clear_Click(object sender, EventArgs e)
        {
            if (dtgvSelectedCodes.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgvSelectedCodes.Rows)
                {
                    AddRowValue(dtgvCodes, row);
                }
  
                dtgvCodes.Sort(dtgvCodes.Columns[0], ListSortDirection.Ascending);
                dtgvSelectedCodes.Rows.Clear();
            }            
        }

        private void btn1Quite_Click(object sender, EventArgs e)
        {
            manage.Show();
            this.Close();
            manage.BringToFront();
        }

        private void btn1Add_Click(object sender, EventArgs e)
        {
            if (dtgvCodes.SelectedRows == null)
                return;
            DataGridViewSelectedRowCollection rows = dtgvCodes.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                AddRowValue(dtgvSelectedCodes, row);                  
            }
            DataGridViewColumn sortingColumn = dtgvSelectedCodes.Columns[0];
            ListSortDirection direction = ListSortDirection.Ascending;
            dtgvSelectedCodes.Sort(sortingColumn, direction);
            foreach (DataGridViewRow row in rows)
                dtgvCodes.Rows.Remove(row);
        }

        private void btn1Remove_Click(object sender, EventArgs e)
        {
            if (dtgvSelectedCodes.SelectedRows == null || dtgvSelectedCodes.Rows.Count == 0)
                return;
            DataGridViewSelectedRowCollection rows = dtgvSelectedCodes.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                 AddRowValue(dtgvCodes, row);
            } 

            foreach (DataGridViewRow row in rows)
                dtgvSelectedCodes.Rows.Remove(row);
        }

        protected virtual void AddRowValue(DataGridView vlist, string v1, string v2, string v3 = null)
        {
            if(v1 != null && v1 != "")
                vlist.Rows.Add(v1, v1, "$ " + v3);
        }

        protected virtual void AddRowValue(DataGridView vlist, DataGridViewRow row)
        {
            if(row != null && row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                vlist.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value);
        }
    }
}
