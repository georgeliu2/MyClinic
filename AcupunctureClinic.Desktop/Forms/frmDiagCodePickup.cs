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
    public class frmDiagCodePickup : frmCodePickup
    {
        public frmDiagCodePickup(Manage _manage, ListBox _codes) :
            base(_manage, _codes)
        {
            this.Text = "Diagnostics Code Editor";
            this.lblSelectedCodeList.Text = "Selected Diagnostics Codes:";
            this.lblCodeList.Text = "Diagnostics Code List";
        }

        protected override void LoadProcedureCodeList()
        {
            DataTable diagCodes = manage.CustomerServiceObj.LoadDiagCodes();
            if (diagCodes == null || diagCodes.Rows.Count == 0)
                return;

            //Fill out dtgvdiagCodes
            DtgvCodes.RowHeadersVisible = true;

            DtgvCodes.DataSource = null;
            DtgvCodes.Rows.Clear();
            int columns = 2;
            DtgvCodes.ColumnCount = columns;
            DtgvCodes.Columns[0].HeaderCell.Value = "Diagnostics Code";
            DtgvCodes.Columns[1].HeaderCell.Value = "Description";

            foreach (DataRow row in diagCodes.Rows)
            {
                AddRowValue(DtgvCodes, row[0].ToString(), row[1].ToString());
            }

            DataGridViewColumn sortingColumn = DtgvCodes.Columns[0];
            ListSortDirection direction = ListSortDirection.Ascending;
            DtgvCodes.Sort(sortingColumn, direction);
        }

        protected override void initialSelectedList()
        {
            DtgvSelectedCodes.DataSource = null;
            DtgvSelectedCodes.Rows.Clear();
            int columns = 2;
            DtgvSelectedCodes.ColumnCount = columns;
            DtgvSelectedCodes.Columns[0].HeaderCell.Value = "Diagnostics Code";
            DtgvSelectedCodes.Columns[1].HeaderCell.Value = "Description";
        }

        protected override void AddRowValue(DataGridView vlist, string v1, string v2, string v3 = null)
        {
            if (v1 != null && v1 != "")
                vlist.Rows.Add(v1, v1);
        }

        protected override void AddRowValue(DataGridView vlist, DataGridViewRow row)
        {
            if (row != null && row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                vlist.Rows.Add(row.Cells[0].Value, row.Cells[1].Value);
        }
    }
}

