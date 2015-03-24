using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AcupunctureClinic.Desktop.Properties;

namespace AcupunctureClinic.Desktop.Forms
{
    using AcupunctureClinic.Desktop.Forms.Membership;
    using AcupunctureClinic.Data.DataModel;

    public partial class frmCodeEditor : Form
    {
        protected Manage manage;
        public frmCodeEditor(Manage _manage) 
        {
            manage = _manage;
            InitializeComponent();
            LoadDataCodes();
        }

        /// tab page Procedure Code  Methods
        /// <summary>
        /// Initializes data grid view dtgvCodeList style
        /// </summary>
        protected void InitilizedtgvProcedureCodeListStyle()
        {
            // Setting the style of the DataGridView control
            dtgvCodeList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dtgvCodeList.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dtgvCodeList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dtgvCodeList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvCodeList.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dtgvCodeList.DefaultCellStyle.BackColor = Color.Empty;
            dtgvCodeList.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            dtgvCodeList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dtgvCodeList.GridColor = SystemColors.ControlDarkDark;
            dtgvCodeList.ColumnCount = 3;
            dtgvCodeList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        //Load all procedure codes
        protected virtual bool LoadDataCodes()
        {
            try
            {
                DataTable procedureCodes = manage.CustomerServiceObj.LoadProcedureCodes();
                // DataTable followupVisits = this.customerService.SelectFollowupVisitById(CustomerID);
                if (procedureCodes != null)
                {
                    this.dtgvCodeList.RowHeadersVisible = true;

                    dtgvCodeList.DataSource = null;
                    dtgvCodeList.Rows.Clear();


                    dtgvCodeList.Columns[0].HeaderCell.Value = "Procedure Code";
                    dtgvCodeList.Columns[1].HeaderCell.Value = "Procedure Name";
                    dtgvCodeList.Columns[2].HeaderCell.Value = "Price.";

                    string procedureCode = txtCode.Text.Trim();
                    int currentRowIndex = -1;

                    for (int i = 0; i < procedureCodes.Rows.Count; i++)
                    {
                        dtgvCodeList.Rows.Add(procedureCodes.Rows[i][0].ToString(), procedureCodes.Rows[i][1].ToString(), "$ " + procedureCodes.Rows[i][2].ToString());
                        if (i == 0 || (procedureCode != "" && procedureCode == procedureCodes.Rows[i][0].ToString()))
                        {
                            txtCode.Text = procedureCodes.Rows[i][0].ToString();
                            txtName.Text = procedureCodes.Rows[i][1].ToString();
                            txtPrice.Text = "$ " + procedureCodes.Rows[i][2].ToString();
                            currentRowIndex = i;
                        }

                    }

                    if (currentRowIndex >= 0)
                    {
                        dtgvCodeList.CurrentCell = dtgvCodeList.Rows[currentRowIndex].Cells[0];
                        // dtgvCodeList.Rows[0].Selected = false;
                        // dtgvCodeList.Rows[currentRowIndex].Selected = true;
                    }




                    return true;
                }
                else
                {
                    //ResetFollowUpVisitInfor();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Load Initial Visit Information error: " + e.ToString());
            }
            return false;
        }

        protected void dtgvCodeList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow currentRow = dtgvCodeList.CurrentRow;
            txtCode.Text = currentRow.Cells[0].Value.ToString();
            txtName.Text = currentRow.Cells[1].Value.ToString();
            txtPrice.Text = currentRow.Cells[2].Value.ToString();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string procedureCode = txtCode.Text.Trim();
            LoadDataCodes();
            if (procedureCode != txtCode.Text.Trim())
            {
                //Not find the record
                txtCode.Text = procedureCode;
                txtName.Text = "";
                txtPrice.Text = "";
                MessageBox.Show("Not find the procedure code record!");
            }
        }

        protected virtual void btnAdd_Click(object sender, EventArgs e)
        {
            // Check if the validation passes
            if (true) //this.FollowUpVisitModel())
            {
                // Assign the values to the model
                DataCodeModel procedureCodeModel = new DataCodeModel()
                {
                    DataCode = this.txtCode.Text.Trim(),
                    DataName = this.txtName.Text.Trim(),
                    DataPrice = (long)(float.Parse(this.txtPrice.Text.Replace('$', ' ').Trim()) * 100)
                };

                // Call the service method and assign the return status to variable
                try
                {
                    var success = manage.CustomerServiceObj.AddProcedureCode(procedureCodeModel);

                    // if status of success variable is true then display a information else display the error message
                    if (success)
                    {
                        //Update customer information
                        LoadDataCodes();
                        // display the message box
                        MessageBox.Show(
                            Resources.Registration_Successful_Message,
                            Resources.Registration_Successful_Message_Title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        // display the error messge
                        MessageBox.Show(
                            Resources.Registration_Error_Message,
                            Resources.Registration_Error_Message_Title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    /*else
                    {
                        // Display the validation failed message
                        MessageBox.Show(
                            this.errorMessage,
                            Resources.Registration_Error_Message_Title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }*/
                }
                catch (Exception ex)
                {
                    manage.ShowErrorMessage(ex);
                }
            }

        }

        protected virtual void btnDelete_Click(object sender, EventArgs e)
        {
            string procedureCode = this.txtCode.Text.Trim();
            if (procedureCode == "")
                return;
            try
            {
                var flag = manage.CustomerServiceObj.DeleteProcedureCode(procedureCode);

                if (flag)
                {
                    txtCode.Text = "";
                    LoadDataCodes();

                    MessageBox.Show(
                        Resources.Delete_Successful_Message,
                        Resources.Delete_Successful_Message_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                manage.ShowErrorMessage(ex);
            }
        }

        protected virtual void btnUpdate_Click(object sender, EventArgs e)
        {
            // Assign the values to the model
            // Check if the validation passes
            if (true) //this.FollowUpVisitModel())
            {
                // Assign the values to the model
                DataCodeModel procedureCodeModel = new DataCodeModel()
                {
                    DataCode = this.txtCode.Text.Trim(),
                    DataName = this.txtName.Text.Trim(),
                    DataPrice = (long)(float.Parse(this.txtPrice.Text.Replace('$', ' ').Trim()) * 100)
                };




                var flag = manage.CustomerServiceObj.UpdateProcedureCode(procedureCodeModel);

                if (flag)
                {
                    LoadDataCodes();
                    // display the message box
                    MessageBox.Show(
                        Resources.Registration_Successful_Message,
                        Resources.Registration_Successful_Message_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    // display the error messge
                    MessageBox.Show(
                        Resources.Registration_Error_Message,
                        Resources.Registration_Error_Message_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        protected void dtgvCodeList_RowHeaderMouseDoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dtgvCodeList.CurrentRow;
            this.LoadDataCode(currentRow);
        }

        protected void LoadDataCode(DataGridViewRow currentRow)
        {
            if (currentRow == null)
                return;
            this.txtCode.Text = currentRow.Cells[1].Value.ToString();
            this.txtName.Text = currentRow.Cells[2].Value.ToString();
            this.txtPrice.Text = currentRow.Cells[3].Value.ToString();
        }
        protected void btnQuite_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        //Form frmCodeEditor Closing event handler 
        protected void frmCodeEditor_FormClosing(object sender, FormClosingEventArgs e) //CancelEventArgs e)
        {
            manage.Show();
            manage.BringToFront();
        }
    }
}
