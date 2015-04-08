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

    public partial class DiagCodeEditor : frmCodeEditor
    {
        public DiagCodeEditor(Manage _manage): base(_manage)
        {
            lblListTitle.Text = "Diagnostics Code List";
            lblCode.Text = "Diagnostics Code";
            lblName.Text = "Description";
            lblPrice.Hide();
            txtPrice.Hide();
            InitilizedtgvProcedureCodeListStyle();
            //lblPrice.Text = "Diagnostics Price";
            //LoadDataCodes();
        }

        protected override void InitilizedtgvProcedureCodeListStyle()
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
            dtgvCodeList.ColumnCount = 2;
            dtgvCodeList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        //Load all procedure codes
        protected  override bool LoadDataCodes()
        {
            try
            {
                DataTable diagCodes = manage.CustomerServiceObj.LoadDiagCodes();                
                if (diagCodes != null)
                {
                    this.dtgvCodeList.RowHeadersVisible = true;

                    dtgvCodeList.DataSource = null;
                    dtgvCodeList.Rows.Clear();


                    dtgvCodeList.Columns[0].HeaderCell.Value = "Diagnostics Code";
                    dtgvCodeList.Columns[1].HeaderCell.Value = "Description";
                    //dtgvCodeList.Columns[2].HeaderCell.Value = "Price.";

                    string diagCode = txtCode.Text.Trim();
                    int currentRowIndex = -1;

                    for (int i = 0; i < diagCodes.Rows.Count; i++)
                    {
                        dtgvCodeList.Rows.Add(diagCodes.Rows[i][0].ToString(), diagCodes.Rows[i][1].ToString());
                        if (i == 0 || (diagCode != "" && diagCode == diagCodes.Rows[i][0].ToString()))
                        {
                            txtCode.Text = diagCodes.Rows[i][0].ToString();
                            txtName.Text = diagCodes.Rows[i][1].ToString();
                            //txtPrice.Text = "$ " + diagCodes.Rows[i][2].ToString();
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
                MessageBox.Show("Load Diagnostics Code error: " + e.ToString());
            }
            return false;
        }


        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            // Check if the validation passes
            if (true) //this.FollowUpVisitModel())
            {
                // Assign the values to the model
                DataCodeModel diagCodeModel = new DataCodeModel()
                {
                    DataCode = this.txtCode.Text.Trim(),
                    DataName = this.txtName.Text.Trim(),
                    DataPrice = 0
                };

                // Call the service method and assign the return status to variable
                try
                {
                    var success = manage.CustomerServiceObj.AddDiagCode(diagCodeModel);

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
                }
                catch (Exception ex)
                {
                    manage.ShowErrorMessage(ex);
                }
            }

        }

        protected  override void btnDelete_Click(object sender, EventArgs e)
        {
            string diagCode = this.txtCode.Text.Trim();
            if (diagCode == "")
                return;
            try
            {
                var flag = manage.CustomerServiceObj.DeleteDiagCode(diagCode);

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

        protected override void btnUpdate_Click(object sender, EventArgs e)
        {
            // Assign the values to the model
            // Check if the validation passes
            if (true) //this.FollowUpVisitModel())
            {
                // Assign the values to the model
                DataCodeModel diagCodeModel = new DataCodeModel()
                {
                    DataCode = this.txtCode.Text.Trim(),
                    DataName = this.txtName.Text.Trim(),
                    DataPrice = 0
                };




                var flag = manage.CustomerServiceObj.UpdateDiagCode(diagCodeModel);

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

    }
}

