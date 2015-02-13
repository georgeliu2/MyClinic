// -----------------------------------------------------------------------
// <copyright file="Manage.cs" company="John">
//  Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Desktop.Forms.Membership
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;
    using AcupunctureClinic.Data.BusinessService;
    using AcupunctureClinic.Data.DataModel;
    using AcupunctureClinic.Data.Enum;
    using AcupunctureClinic.Desktop.Properties;

    /// <summary>
    /// Manage screen - To view, search, print, export club members information
    /// </summary>
    public partial class Manage : Form
    {
        /// <summary>
        /// Instance of DataGridViewPrinter
        /// </summary>
        private DataGridViewPrinter dataGridViewPrinter;
        
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ICusomerService customerService;

        /// <summary>
        /// Variable to store error message
        /// </summary>
        private string errorMessage;

        /// <summary>
        /// Member id
        /// </summary>
        private int CustomerID;
        
        /// <summary>
        /// Initializes a new instance of the Manage class
        /// </summary>
        public Manage()
        {
            this.InitializeComponent();
            this.InitializeResourceString();
            this.InitializeDropDownList();
            this.InitilizeDataGridViewStyle();
            this.customerService = new CustomerService();            
            this.ResetRegistration();
            this.ResetSearch();
        }

        /// <summary>
        /// Initializes resource strings
        /// </summary>
        private void InitializeResourceString()
        {
            // Registeration
            lblFname.Text = Resources.Registration_Name_Label_Text;
            lblDateOfBirth.Text = Resources.Registration_DateOfBirth_Label_Text;
            lblOccupation.Text = Resources.Registration_Occupation_Label_Text;
            lblMaritalStatus.Text = Resources.Registration_MaritalStatus_Label_Text;
            lblSex.Text = Resources.Registration_Sex_Label_Text;
            btnRegister.Text = Resources.Registration_Register_Button_Text;

            // Search, Print, Export, Update, Delete
            btnSearch.Text = Resources.Search_Search_Button_Text;
            btnRefresh.Text = Resources.Search_Refresh_Button_Text;
            btnPrintPreview.Text = Resources.Print_PrintPreview_Button_Text;
            btnPrint.Text = Resources.Print_Print_Button_Text;
            btnExport.Text = Resources.Export_Button_Text;
            btnUpdate.Text = Resources.Update_Button_Text;
            btnDelete.Text = Resources.Delete_Button_Text;
        }

        /// <summary>
        /// Initializes all dropdown controls
        /// </summary>
        private void InitializeDropDownList()
        {
            cmbOccupation.DataSource = Enum.GetValues(typeof(Occupation));
            cmbMaritalStatus.DataSource = Enum.GetValues(typeof(MaritalStatus));
            cmbSex.DataSource = Enum.GetValues(typeof(Sex));            

            //cmbSearchOccupation.DataSource = Enum.GetValues(typeof(Occupation));
            //cmbSearchMaritalStatus.DataSource = Enum.GetValues(typeof(MaritalStatus));
            txtSCustomerID.Text = "";
            txtSLname.Text = "";
            cmbOperand.SelectedIndex = 0;
        }

        /// <summary>
        /// Resets search criteria
        /// </summary>
        private void ResetSearch()
        {
            txtSCustomerID.Text = "";
            txtSLname.Text = "";
            cmbOperand.SelectedIndex = 0;
        }

        /// <summary>
        /// Resets the registration screen
        /// </summary>
        private void ResetRegistration()
        {
            txtFname.Text = string.Empty;
            txtEmployer.Text = string.Empty;
            txtSSN.Text = string.Empty;
            cmbOccupation.SelectedIndex = -1;
            cmbSex.SelectedIndex = -1;
            cmbMaritalStatus.SelectedIndex = -1;
            txtDLN.Text = string.Empty;
        }

        /// <summary>
        /// Initializes all dropdown controls in update section
        /// </summary>
        private void InitializeUpdate()
        {
            cmb2Occupation.DataSource = Enum.GetValues(typeof(Occupation));
            cmb2MaritalStatus.DataSource = Enum.GetValues(typeof(MaritalStatus));
            cmb2Sex.DataSource = Enum.GetValues(typeof(Sex));
        }

        /// <summary>
        /// Resets the update section of manage screen
        /// </summary>
        private void ResetUpdate()
        {
            txt2CustomerID.Text = string.Empty;
            txt2Name.Text = string.Empty;
            txt2SSN.Text = string.Empty;
            cmb2Occupation.SelectedIndex = -1;
            cmb2Sex.SelectedIndex = -1;
            cmb2MaritalStatus.SelectedIndex = -1;
        }

        /// <summary>
        /// Validates registration input
        /// </summary>
        /// <returns>true or false</returns>
        private bool ValidateRegistration()
        {            
            this.errorMessage = string.Empty;

            if (txtFname.Text.Trim() == string.Empty)
            {
                this.AddErrorMessage(Resources.Registration_Name_Required_Text);
            }

            if (cmbOccupation.SelectedIndex == -1)
            {
                this.AddErrorMessage(Resources.Registration_Occupation_Select_Text);
            }

            if (cmbMaritalStatus.SelectedIndex == -1)
            {
                this.AddErrorMessage(Resources.Registration_MaritalStatus_Select_Text);
            }

            if (cmbSex.SelectedIndex == -1)
            {
                this.AddErrorMessage(Resources.Registration_Sex_Select_Text);
            }

            return this.errorMessage != string.Empty ? false : true;
        }

        /// <summary>
        /// Validates update data
        /// </summary>
        /// <returns>true or false</returns>
        private bool ValidateUpdate()
        {
            this.errorMessage = string.Empty;

            if (txt2Name.Text.Trim() == string.Empty)
            {
                this.AddErrorMessage(Resources.Registration_Name_Required_Text);
            }

            if (cmb2Occupation.SelectedIndex == -1)
            {
                this.AddErrorMessage(Resources.Registration_Occupation_Select_Text);
            }

            if (cmb2MaritalStatus.SelectedIndex == -1)
            {
                this.AddErrorMessage(Resources.Registration_MaritalStatus_Select_Text);
            }

            if (cmb2Sex.SelectedIndex == -1)
            {
                this.AddErrorMessage(Resources.Registration_Sex_Select_Text);
            }

            return this.errorMessage != string.Empty ? false : true;
        }

        /// <summary>
        /// To generate the error message
        /// </summary>
        /// <param name="error">error message</param>
        private void AddErrorMessage(string error)
        {
            if (this.errorMessage == string.Empty)
            {
                this.errorMessage = Resources.Error_Message_Header + "\n\n";
            }

            this.errorMessage += error + "\n";
        }

        /// <summary>
        /// Method to show general error message on any system level exception
        /// </summary>
        private void ShowErrorMessage(Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                //Resources.System_Error_Message, 
                Resources.System_Error_Message_Title, 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// Initializes data grid view style
        /// </summary>
        private void InitilizeDataGridViewStyle()
        {
            // Setting the style of the DataGridView control
            dataGridViewMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewMembers.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dataGridViewMembers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewMembers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewMembers.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewMembers.DefaultCellStyle.BackColor = Color.Empty;
            dataGridViewMembers.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            dataGridViewMembers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewMembers.GridColor = SystemColors.ControlDarkDark;
        }

        /// <summary>
        /// Method to load data grid view
        /// </summary>
        /// <param name="data">data table</param>
        private void LoadDataGridView(DataTable data)
        {
            // Data grid view column setting            
            dataGridViewMembers.DataSource = data;
            dataGridViewMembers.DataMember = data.TableName;
            dataGridViewMembers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        /// <summary>
        /// Method to set up the printing
        /// </summary>
        /// <param name="isPrint">isPrint value</param>
        /// <returns>true or false</returns>
        private bool SetupPrinting(bool isPrint)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.AllowCurrentPage = false;
            printDialog.AllowPrintToFile = false;
            printDialog.AllowSelection = false;
            printDialog.AllowSomePages = false;
            printDialog.PrintToFile = false;
            printDialog.ShowHelp = false;
            printDialog.ShowNetwork = false;

            if (isPrint)
            {
                if (printDialog.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }
            }

            this.PrintReport.DocumentName = "MembersReport";
            this.PrintReport.PrinterSettings = printDialog.PrinterSettings;
            this.PrintReport.DefaultPageSettings = printDialog.PrinterSettings.DefaultPageSettings;
            this.PrintReport.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            this.dataGridViewPrinter = new DataGridViewPrinter(dataGridViewMembers, PrintReport, true, true, Resources.Report_Header, new Font("Tahoma", 13, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            return true;
        }

        /// <summary>
        /// Click event to handle registration
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void Register_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the validation passes
                if (this.ValidateRegistration())
                {
                    // Assign the values to the model
                    CustomerModel customerModel = new CustomerModel()
                    {
                        CustomerID = 0,
                        Fname = txtFname.Text.Trim(),
                        Lname = txtLname.Text.Trim(),
                        Sex = (Sex)cmbSex.SelectedValue,
                        DoB = dtDateOfBirth.Value,
                        MaritalStatus = (MaritalStatus)cmbMaritalStatus.SelectedValue,
                        Occupation = (Occupation)cmbOccupation.SelectedValue,
                        Employer = txtEmployer.Text.Trim(),
                        SSN = txtSSN.Text.Trim(), // == string.Empty ? 0 : Convert.ToDecimal(txtEmployer.Text),
                        DLN = txtDLN.Text.Trim() // == string.Empty ? 0 : Convert.ToInt16(txtSSN.Text)
                    };

                    // Call the service method and assign the return status to variable
                    var success = this.customerService.RegisterCustomer(customerModel);

                    // if status of success variable is true then display a information else display the error message
                    if (success)
                    {
                        // display the message box
                        MessageBox.Show(
                            Resources.Registration_Successful_Message,
                            Resources.Registration_Successful_Message_Title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Reset the screen
                        //this.ResetRegistration();
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
                else
                {
                    // Display the validation failed message
                    MessageBox.Show(
                        this.errorMessage, 
                        Resources.Registration_Error_Message_Title, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Key press Event to accept only numeric value
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">key press event data</param>
        private void Salary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Key press Event to accept only numeric value
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">event data</param>
        /*private void Children_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.
                    Handled = true;
            }
        }*/

        /// <summary>
        /// Event to handle tab selection
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (tab.SelectedIndex == 1)
                {
                    DataTable data = this.customerService.GetAllCustomers();
              //      this.InitializeUpdate();
                    this.LoadDataGridView(data);                    
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Event to handle the data formatting in data grid view
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        // ???
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    e.Value = Convert.ToInt16(e.Value) == 0 ? string.Empty : e.Value;
                }

                if (e.ColumnIndex == 3)
                {
                    e.Value = Enum.GetName(typeof(Sex), e.Value).ToString();
                }

                //Occupation occ_enum = (Occupation)Enum.Parse(typeof(Occupation), occ_str);
                if (e.ColumnIndex == 4)
                {
                    e.Value = string.Format("{0:dd/MM/yyyy}", (DateTime)e.Value);
                }


                if (e.ColumnIndex == 5)
                {
                    e.Value = Enum.GetName(typeof(MaritalStatus), e.Value).ToString();
                }


                if (e.ColumnIndex == 6)
                {
                    e.Value = Enum.GetName(typeof(Occupation), e.Value).ToString();
                }


              /*  if (e.ColumnIndex == 6)
                {
                    e.Value = Convert.ToDecimal(e.Value) == 0 ? string.Empty : e.Value;
                }*/

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }            
        }     

        /// <summary>
        /// Click event to handle search
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable data = this.customerService.SearchCustomers(txtSCustomerID.Text, txtSLname.Text.Trim(), cmbOperand.GetItemText(cmbOperand.SelectedItem));
                this.LoadDataGridView(data);
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }            
        }       

        /// <summary>
        /// Click event to handle the refresh
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">event data</param>
        private void Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.ResetSearch();
                DataTable data = this.customerService.GetAllCustomers();
                this.LoadDataGridView(data); 
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }            
        }

        /// <summary>
        /// Click event to handle print preview
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void PrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SetupPrinting(false))
                {
                    PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                    printPreviewDialog.Document = this.PrintReport;
                    printPreviewDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Click event to handle print
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SetupPrinting(true))
                {
                    this.PrintReport.Print();
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }           
        }

        /// <summary>
        /// Event to handle print page
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                bool hasMorePages = this.dataGridViewPrinter.DrawDataGridView(e.Graphics);

                if (hasMorePages == true)
                {
                    e.HasMorePages = true;
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }            
        }       

        /// <summary>
        /// Click event to handle the export to excel
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">event data</param>
        private void Export_Click(object sender, EventArgs e)
        {
            try
            {
                var table = (DataTable)dataGridViewMembers.DataSource;

                Microsoft.Office.Interop.Excel.ApplicationClass excel
                    = new Microsoft.Office.Interop.Excel.ApplicationClass();

                excel.Application.Workbooks.Add(true);

                int columnIndex = 0;

                foreach (DataColumn col in table.Columns)
                {
                    columnIndex++;
                    excel.Cells[1, columnIndex] = col.ColumnName;
                }

                int rowIndex = 0;

                foreach (DataRow row in table.Rows)
                {
                    rowIndex++;
                    columnIndex = 0;
                    foreach (DataColumn col in table.Columns)
                    {
                        columnIndex++;
                        if (columnIndex == 4 || columnIndex == 6 || columnIndex == 7)
                        {
                            if (columnIndex == 4)
                            {
                                excel.Cells[rowIndex + 1, columnIndex]
                                    = Enum.GetName(typeof(Sex), row[col.ColumnName]);
                            }

                            if (columnIndex == 6)
                            {
                                excel.Cells[rowIndex + 1, columnIndex]
                                    = Enum.GetName(typeof(MaritalStatus), row[col.ColumnName]);
                            }

                            if (columnIndex == 7)
                            {
                                excel.Cells[rowIndex + 1, columnIndex]
                                    = Enum.GetName(typeof(Occupation), row[col.ColumnName]);
                            }
                        }
                        else
                        {
                            excel.Cells[rowIndex + 1, columnIndex] = row[col.ColumnName].ToString();
                        }
                    }
                }

                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
                worksheet.Activate(); 
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }                          
        }

        private void dataGridViewMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = dataGridViewMembers.SelectedCells[0].RowIndex;
            MessageBox.Show("cell content click");
            try
            {
                string customerId = dataGridViewMembers[0, currentRow].Value.ToString();
                CustomerID = int.Parse(customerId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
            }
        }
       
        /// <summary>
        /// Click event to update the data
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateUpdate())
                {
                    CustomerModel customerModel = new CustomerModel()
                    {
                        CustomerID = int.Parse(txt2CustomerID.Text),
                        Fname = txt2Name.Text.Trim().Split(' ')[0],
                        Lname = txt2Name.Text.Trim().Split(' ')[1], 
                        DoB = dt2DateOfBirth.Value,
                        Occupation = (Occupation)cmb2Occupation.SelectedIndex,
                        Sex = (Sex)cmb2Sex.SelectedIndex,
                        MaritalStatus = (MaritalStatus)cmb2MaritalStatus.SelectedIndex,
                        Employer = txt2Employer.Text,
                        SSN = txt2SSN.Text.Trim(), // == string.Empty ? 0 : Convert.ToDecimal(txt2Salary.Text),
                        DLN = txt2DLN.Text.Trim()// == string.Empty ? 0 : Convert.ToInt16(txt2SSN.Text)
                    };

                    var flag = this.customerService.UpdateCustomer(customerModel);

                    if (flag)
                    {
                        DataTable data = this.customerService.GetAllCustomers();
                        this.LoadDataGridView(data);

                        MessageBox.Show(
                            Resources.Update_Successful_Message,
                            Resources.Update_Successful_Message_Title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);                        
                    }
                }
                else
                {
                    MessageBox.Show(
                        this.errorMessage,
                        Resources.Registration_Error_Message_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.CustomerID = int.Parse(txt2CustomerID.Text);
                var flag = this.customerService.DeleteCustomer(this.CustomerID);

                if (flag)
                {
                    DataTable data = this.customerService.GetAllCustomers();
                    this.LoadDataGridView(data);

                    MessageBox.Show(
                        Resources.Delete_Successful_Message,
                        Resources.Delete_Successful_Message_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {                
                this.ShowErrorMessage(ex);
            }
        }

        // ???
        private void dataGridViewMembers_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            try
            {
                if (dgv.SelectedRows.Count > 0)
                {                   
                    txt2CustomerID.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();
                    CustomerID = int.Parse(txt2CustomerID.Text);


                    DataRow dataRow = this.customerService.GetCustomerById(CustomerID);

                    txt2Name.Text = dataRow["Fname"].ToString() + " " + dataRow["Lname"].ToString();
                    dt2DateOfBirth.Value = Convert.ToDateTime(dataRow["DoB"]);
                    string occ_str = dataRow["Occupation"].ToString();
                    Occupation occ_enum = (Occupation)Enum.Parse(typeof(Occupation), occ_str);
                    int occ_int = (int)occ_enum;
                    cmb2Occupation.SelectedIndex = occ_int; // (int)(Occupation)Enum.Parse(typeof(Occupation), dataRow["Occupation"].ToString());
                    cmb2MaritalStatus.SelectedIndex = (int)(MaritalStatus)Enum.Parse(typeof(MaritalStatus), dataRow["MaritalStatus"].ToString());
                    cmb2Sex.SelectedIndex = (int)(Sex)Enum.Parse(typeof(Sex), dataRow["Sex"].ToString());
                    txt2Employer.Text = dataRow["Employer"].ToString(); // == "0.0000" ? string.Empty : dataRow["Salary"].ToString();
                    txt2SSN.Text = dataRow["SSN"].ToString();
                    txt2DLN.Text = dataRow["DLN"].ToString();
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }            
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("In Manage_Load");
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }


        public static void Manage_Closing(object sender, EventArgs e)
        {
            //MessageBox.Show("Closing");
            Application.Exit();
        }


    }
}
