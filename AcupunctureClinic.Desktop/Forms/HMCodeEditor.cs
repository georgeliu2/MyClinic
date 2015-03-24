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

    public partial class HMCodeEditor : frmCodeEditor
    {
        public HMCodeEditor(Manage _manage): base(_manage)
        {
            lblListTitle.Text = "Health / Medicine Code List";
            lblCode.Text = "H/M Code";
            lblName.Text = "H/M Name";
            lblPrice.Text = "H/M Price";
            LoadDataCodes();
        }

        //Load all procedure codes
        protected  override bool LoadDataCodes()
        {
            try
            {
                DataTable hmCodes = manage.CustomerServiceObj.LoadHMCodes();                
                if (hmCodes != null)
                {
                    this.dtgvCodeList.RowHeadersVisible = true;

                    dtgvCodeList.DataSource = null;
                    dtgvCodeList.Rows.Clear();


                    dtgvCodeList.Columns[0].HeaderCell.Value = "H/M Code";
                    dtgvCodeList.Columns[1].HeaderCell.Value = "H/M Name";
                    dtgvCodeList.Columns[2].HeaderCell.Value = "Price.";

                    string hmCode = txtCode.Text.Trim();
                    int currentRowIndex = -1;

                    for (int i = 0; i < hmCodes.Rows.Count; i++)
                    {
                        dtgvCodeList.Rows.Add(hmCodes.Rows[i][0].ToString(), hmCodes.Rows[i][1].ToString(), "$ " + hmCodes.Rows[i][2].ToString());
                        if (i == 0 || (hmCode != "" && hmCode == hmCodes.Rows[i][0].ToString()))
                        {
                            txtCode.Text = hmCodes.Rows[i][0].ToString();
                            txtName.Text = hmCodes.Rows[i][1].ToString();
                            txtPrice.Text = "$ " + hmCodes.Rows[i][2].ToString();
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
                MessageBox.Show("Load Health /Medicine Code error: " + e.ToString());
            }
            return false;
        }


        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            // Check if the validation passes
            if (true) //this.FollowUpVisitModel())
            {
                // Assign the values to the model
                DataCodeModel hmCodeModel = new DataCodeModel()
                {
                    DataCode = this.txtCode.Text.Trim(),
                    DataName = this.txtName.Text.Trim(),
                    DataPrice = (long)(float.Parse(this.txtPrice.Text.Replace('$', ' ').Trim()) * 100)
                };

                // Call the service method and assign the return status to variable
                try
                {
                    var success = manage.CustomerServiceObj.AddHMCode(hmCodeModel);

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
            string hmCode = this.txtCode.Text.Trim();
            if (hmCode == "")
                return;
            try
            {
                var flag = manage.CustomerServiceObj.DeleteHMCode(hmCode);

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
                DataCodeModel hmCodeModel = new DataCodeModel()
                {
                    DataCode = this.txtCode.Text.Trim(),
                    DataName = this.txtName.Text.Trim(),
                    DataPrice = (long)(float.Parse(this.txtPrice.Text.Replace('$', ' ').Trim()) * 100)
                };




                var flag = manage.CustomerServiceObj.UpdateHMCode(hmCodeModel);

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
