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
    public class frmHMCodePickup : frmCodePickup
    {
        public frmHMCodePickup(Manage _manage, ListBox _codes) :
            base(_manage, _codes)
        {
            this.Text = "Health /Medicine Code Editor";
            this.lblSelectedCodeList.Text = "Selected H/M Codes:";
            this.lblCodeList.Text = "H/M Code List";
        }


        protected override void LoadProcedureCodeList()
        {
            DataTable hmCodes = manage.CustomerServiceObj.LoadHMCodes();
            if (hmCodes == null || hmCodes.Rows.Count == 0)
                return;
            //Fill out dtgvhmCodes
            DtgvCodes.RowHeadersVisible = true;

            if (hmCodes != null)
            {
                DtgvCodes.DataSource = null;
                DtgvCodes.Rows.Clear();
                int columns = 3;
                DtgvCodes.ColumnCount = columns;
                DtgvCodes.Columns[0].HeaderCell.Value = "H/M Code";
                DtgvCodes.Columns[1].HeaderCell.Value = "Description";
                DtgvCodes.Columns[2].HeaderCell.Value = "Price";

                foreach (DataRow row in hmCodes.Rows)
                {
                    DtgvCodes.Rows.Add(row[0].ToString(), row[1].ToString(), "$ " + row[2].ToString());
                }
            }

            DataGridViewColumn sortingColumn = DtgvCodes.Columns[0];
            ListSortDirection direction = ListSortDirection.Ascending;
            DtgvCodes.Sort(sortingColumn, direction);
        }

        protected override void initialSelectedList()
        {
            DtgvSelectedCodes.DataSource = null;
            DtgvSelectedCodes.Rows.Clear();
            int columns = 3;
            DtgvSelectedCodes.ColumnCount = columns;
            DtgvSelectedCodes.Columns[0].HeaderCell.Value = "H/M Code";
            DtgvSelectedCodes.Columns[1].HeaderCell.Value = "Description";
            DtgvSelectedCodes.Columns[2].HeaderCell.Value = "Price";
        }
    }
}
