// -----------------------------------------------------------------------
// <copyright file="Manage.cs" company="John">
//  Acupuncture Clinic Record Management System 2015
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Desktop.Forms.Membership
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;
    using AcupunctureClinic.Data.BusinessService;
    using AcupunctureClinic.Data.DataModel;   
    using AcupunctureClinic.Data.Enums;
    using AcupunctureClinic.Desktop.Properties;
    //using Microsoft.Office.Interop.Excel;
    using Excel = Microsoft.Office.Interop.Excel; 

    /// <summary>
    /// Manage screen - To view, search, print, export  customers information
    /// </summary>
    public partial class Manage : Form, ICodePickup
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
        /// Interface of IInvoiceService
        /// </summary>
        private AcupunctureClinic.Data.BusinessService.IInvoiceService invoiceService;

        /// <summary>
        /// Variable to store error message
        /// </summary>
        private string errorMessage;

        /// <summary>
        /// Member id
        /// </summary>
        private long customerID;
        private string customerName;

        private int codePickuprStatus;   //0 -- None; 1 -- ProcedureCodeEditor; 
                                    //2 -- H/M Code Editor; 3 -- Diagnostic Code Editor
        private DataTable procedureCodes;

        private DataTable hmCodes;

        public ICusomerService CustomerServiceObj
        { get { return customerService; }   }

        public AcupunctureClinic.Data.BusinessService.IInvoiceService InvoiceServiceObj
        { get { return invoiceService; } }

        public ListBox Lst62ProcedureCodes
        {
            get { return lst62ProcedureCodes;  }
            set { lst62ProcedureCodes = value; }
        }

        public ListBox Lst62HMCodes
        {
            get { return lst62HMCodes; }
            set { lst62HMCodes = value; }
        }

        public long CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public DataTable ProcedureCodes
        {
            get { return procedureCodes; }
            set { procedureCodes = value; }
        }

        public DataTable HMCodes
        {
            get { return hmCodes; }
            set { hmCodes = value; }
        }
        /// <summary>
        /// Initializes a new instance of the Manage class
        /// </summary>
        public Manage()
        {
            this.InitializeComponent();
            this.InitializeResourceString();
            this.InitializeDropDownList();
            this.InitilizeDataGridViewStyle();
            this.InitilizeDataGridView4InvoicesStyle();
            this.customerService = new CustomerService();            
            this.ResetRegistration();
            this.ResetSearch();
            this.invoiceService = new InvoiceService();
            codePickuprStatus = 0;
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
            CustomerID = -1;
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
            CustomerID = -1;
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
        public void ShowErrorMessage(Exception ex)
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
        private void LoadDataGridView(System.Data.DataTable data)
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
                        CustomerID = -1,
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
        // Whan Tab is clicked, this function is called.
        private void tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (tab.SelectedIndex == 1) // Tab Search Customer
                {
                    DataTable data = this.customerService.GetAllCustomers();
              //      this.InitializeUpdate();
                    this.LoadDataGridView(data);                    
                }
                else if (tab.SelectedIndex == 2) //Tab Contact
                {
                    this.LoadContact();
                }
                else if (tab.SelectedIndex == 3) //Tab Account /Invoice
                {
                    this.LoadAccountAndInvoice();
                }
                else if (tab.SelectedIndex == 4) //Tab Health Infor
                {
                    this.LoadHealthInfor();
                    this.LoadVisits();
                }
                /*else if (tab.SelectedIndex == 6) //Tab Procedure Code
                {
                    Initilizedtgv7ProcedureCodeListStyle();
                    this.LoadProcedureCodes();
                }
                else if (tab.SelectedIndex == 7) //Tab H/M Code
                {
                    Initilizedtgv8HMCodeListStyle();
                    this.LoadHMCodes();
                }*/
                else if(tab.SelectedIndex == 6) //Tab Setting Code)
                { ; }
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
                DataTable data = this.customerService.SearchCustomers(txtSCustomerID.Text.Trim(), txtSLname.Text.Trim(), cmbOperand.GetItemText(cmbOperand.SelectedItem));
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
                //worksheet.Activate(); 
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
                string customerIdstr = dataGridViewMembers[0, currentRow].Value.ToString();
                CustomerID = long.Parse(customerIdstr);
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
                        CustomerID = long.Parse(txt2CustomerID.Text),
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
                this.CustomerID = long.Parse(txt2CustomerID.Text.Trim());
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

        // 
        private void dataGridViewMembers_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            try
            {
                if (dgv.SelectedRows.Count > 0)
                {                   
                    txt2CustomerID.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();
                    CustomerID = long.Parse(txt2CustomerID.Text.Trim());


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
            //Application.Exit();
        }


        public static void Manage_Closing(object sender, EventArgs e)
        {
            //MessageBox.Show("Closing");
            Application.Exit();
        }

        private void tabpContact_Click(object sender, EventArgs e)
        {

        }

        private void btn3Search_Click(object sender, EventArgs e)
        {
            this.LoadContact();
        }

        private void LoadContact()
        {
            string customerIdStr = txt3CustomerID.Text.Trim()==""? txtSCustomerID.Text : txt3CustomerID.Text.Trim();
            if (customerIdStr == "")
            {
               // MessageBox.Show(" Please enter Customer ID!" );
                this.ResetContact();
                return;
            }

            try
            {
                this.CustomerID = long.Parse(customerIdStr);
                DataRow contact = this.customerService.SearchContactById(CustomerID);

                if (contact != null)
                {
                    txt3Street.Text = contact[1].ToString();
                    txt3City.Text = contact[2].ToString();
                    cmb3State.SelectedIndex = int.Parse(contact[3].ToString());
                    txt3Zip.Text = contact[4].ToString();
                    txt3Phone.Text = contact[5].ToString();
                    txt3CellPhone.Text = contact[6].ToString();
                    txt3Guardian.Text = contact[7].ToString();
                    txt3GuardianPhone.Text = contact[8].ToString();
                    //retrieve customer name from Customer               
                    DataTable customer = this.customerService.SearchCustomers(customerIdStr, "", " Or");
                    if (customer != null && customer.Rows.Count > 0)
                    {
                        txt3Name.Text = customer.Rows[0][1].ToString() + " " + customer.Rows[0][1].ToString();
                    }
                    //else
                    //if cannot get the name, just ignore it
                }
                else
                    this.ResetContact();
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
                return;
            }
        }

        private void btn3Update_Click(object sender, EventArgs e)
        {
            try
            {
               // if (this.ValidateUpdate())
               // {
                    ContactModel contactModel = new ContactModel()
                    {
                        CustomerID = long.Parse(this.txt3CustomerID.Text.Trim()),
                         Street = this.txt3Street.Text.Trim(),
                        City = this.txt3City.Text.Trim(),
                         State = (State)this.cmb3State.SelectedIndex,
                         Zip = this.txt3Zip.Text.Trim(),
                         Phone = this.txt3Phone.Text.Trim(),
                         CellPhone = this.txt3CellPhone.Text.Trim(),
                         Guardian = this.txt3Guardian.Text.Trim(),
                         GuardianPhone = this.txt3GuardianPhone.Text.Trim()
                    };

                    var flag = this.customerService.UpdateContact(contactModel);

                    if (flag)
                    {
                        //retrieve customer name from Customer            
                        DataTable customer = this.customerService.SearchCustomers(contactModel.CustomerID.ToString(), "", " Or");
                        if (customer != null && customer.Rows.Count > 0)
                        {
                            txt3Name.Text = customer.Rows[0][1].ToString() + " " + customer.Rows[0][1].ToString();
                        }    
                    }
                /*}
                else
                {
                    MessageBox.Show(
                        this.errorMessage,
                        Resources.Registration_Error_Message_Title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }*/
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
        private void btn3Refresh_Click(object sender, EventArgs e)
        {
                this.ResetContact();
        }

        private void ResetContact()
        {
            txt3CustomerID.Text = "";
            txt3Name.Text = "";
            txt3Street.Text = "";
            txt3City.Text = "";
            txt3Zip.Text = "";
            cmb3State.Text = "";
            txt3Phone.Text = "";
            txt3CellPhone.Text = "";
            txt3Guardian.Text = "";
            txt3GuardianPhone.Text = "";
            CustomerID = -1;
        }

        //Delete a contact
        private void btn3Delete_Click(object sender, EventArgs e)
        {
            ContactModel contactModel = new ContactModel()
            {
                CustomerID = long.Parse(this.txt3CustomerID.Text.Trim()),
                Street = this.txt3Street.Text.Trim(),
                City = this.txt3City.Text.Trim(),
                State = (State)this.cmb3State.SelectedIndex,
                Zip = this.txt3Zip.Text.Trim(),
                Phone = this.txt3Phone.Text.Trim(),
                CellPhone = this.txt3CellPhone.Text.Trim(),
                Guardian = this.txt3Guardian.Text.Trim(),
                GuardianPhone = this.txt3GuardianPhone.Text.Trim()
            };

            var flag = this.customerService.DeleteContact(contactModel);
            if (flag)
                this.ResetContact();
            else
                MessageBox.Show("Delete customer contact failed!");
        }

        private void btn3AddContact_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the validation passes
                //             if (this.ValidateContact())
                {
                    // Assign the values to the model                  
                    ContactModel contactModel = new ContactModel()
                    {
                        CustomerID = long.Parse(this.txt3CustomerID.Text.Trim()),
                        Street = this.txt3Street.Text.Trim(),
                        City = this.txt3City.Text.Trim(),
                        State = (State)this.cmb3State.SelectedIndex,
                        Zip = this.txt3Zip.Text.Trim(),
                        Phone = this.txt3Phone.Text.Trim(),
                        CellPhone = this.txt3CellPhone.Text.Trim(),
                        Guardian = this.txt3Guardian.Text.Trim(),
                        GuardianPhone = this.txt3GuardianPhone.Text.Trim()
                    };
                    // Call the service method and assign the return status to variable
                    var success = this.customerService.InsertContact(contactModel);

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
                /*   else
                   {
                       // Display the validation failed message
                       MessageBox.Show(
                           this.errorMessage,
                           Resources.Registration_Error_Message_Title,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                   } */
            }
            catch (Exception )
            {
                ;
            }
        }

        public void LoadAccountAndInvoice()
        {
            string customerIdStr = txt4CustomerID.Text.Trim() != "" ? txt4CustomerID.Text.Trim() :
                    txtSCustomerID.Text.Trim() != "" ? txtSCustomerID.Text.Trim() : txt3CustomerID.Text.Trim();
            if (customerIdStr == "")
            {
                // MessageBox.Show(" Please enter Customer ID!" );
                this.ResetAccount();
                return;
            }

            try
            {
                CustomerID = long.Parse(customerIdStr);
                DataRow account = this.customerService.SelectAccountById(CustomerID);
                long currentInvNo = 0;
                if (account != null)
                {
                    txt4CustomerID.Text = account[0].ToString();
                    //txt4SearchInvNo.Text = txt4InvNo.Text = account[1].ToString();
                    currentInvNo = long.Parse(account[1].ToString());
                    dt4LastVisit.Value = Convert.ToDateTime(account[2]);
                    txt4Balance.Text = utility.DisplayCurrency(utility.StrToLong(account[3].ToString()));
                }

                //Load Customer Name
               
                txt4Name.Text = CustomerName = GetCustomerNameByID(CustomerID);                
                    //retrieve account invoices  
                LoadInvoices(CustomerID, currentInvNo);                               
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
                return;
            }
        }

        private void LoadInvoices(long customerId, long currentInvNo)
        {
            //retrieve account invoices               
            DataTable invoices = this.invoiceService.GetInvoicesByCustomerID(customerId);

            if (invoices != null && invoices.Rows.Count > 0)
            {
                DataColumn[] keys = new DataColumn[1];
                keys[0] = invoices.Columns[1];
                this.LoadInvoicesForDataGridView(invoices);
                long balance = CalculateBalance(invoices);
                txt4Balance.Text = utility.DisplayCurrency(balance);
            }
            //else
            //if cannot get the name, just ignore it
        }

        private long CalculateBalance(DataTable invoices)
        {
            long balance = 0;
            if (invoices != null && invoices.Rows.Count > 0)
            {
                foreach (DataRow row in invoices.Rows)
                    balance += Convert.ToInt64(row[9]);
            }
            return balance;
        }


        private void dataGridView4Invoices_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow currentRow = dtgv4Invoices.CurrentRow;
            btnInvdetail_Click(sender, e);
            //MessageBox.Show(Convert.ToString(currentRow.Cells[0].Value));

            //this.LoadInvoice(currentRow);
        }

        /// <summary>
        /// Initializes data grid view style
        /// </summary>
        private void InitilizeDataGridView4InvoicesStyle()
        {
            // Setting the style of the DataGridView control
            dtgv4Invoices.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dtgv4Invoices.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dtgv4Invoices.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dtgv4Invoices.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgv4Invoices.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dtgv4Invoices.DefaultCellStyle.BackColor = Color.Empty;
            dtgv4Invoices.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            dtgv4Invoices.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dtgv4Invoices.GridColor = SystemColors.ControlDarkDark;

            dtgv4Invoices.DataSource = null;
            dtgv4Invoices.Rows.Clear();
            dtgv4Invoices.ColumnCount = 5;
            dtgv4Invoices.Columns[0].HeaderCell.Value = "Date";
            dtgv4Invoices.Columns[1].HeaderCell.Value = "Inv No";
            dtgv4Invoices.Columns[2].HeaderCell.Value = "Sub Total";
            dtgv4Invoices.Columns[3].HeaderCell.Value = "Amt Paid";
            dtgv4Invoices.Columns[4].HeaderCell.Value = "Total";
        }

        private void LoadInvoicesForDataGridView(System.Data.DataTable data)
        {
            // Data grid view column setting    
            this.dtgv4Invoices.Rows.Clear();            
            this.dtgv4Invoices.DataMember = data.TableName;
            foreach (DataRow row in data.Rows)
            {
                dtgv4Invoices.Rows.Add(row[2], row[1].ToString(), utility.DisplayCurrency(utility.StrToLong(row[7].ToString())), utility.DisplayCurrency(utility.StrToLong(row[8].ToString())), utility.DisplayCurrency(utility.StrToLong(row[9].ToString())));
                if (dt4LastVisit.Value < (DateTime)row[2])
                    dt4LastVisit.Value = (DateTime)row[2];
            }
            if(dtgv4Invoices.Rows.Count > 0)
            {
                dtgv4Invoices.CurrentCell = dtgv4Invoices.Rows[dtgv4Invoices.Rows.Count - 1].Cells[0];
                
            }
        }

        private void ResetAccount()
        {
            txt4CustomerID.Text = "";
            txt4Name.Text = "";
            dt4LastVisit.Value = dt4LastVisit.MinDate;
            txt4Balance.Text = "";
            CustomerID = -1;
        }


        private void btn4Search_Click(object sender, EventArgs e)
        {
            this.LoadAccountAndInvoice();
        }

        private void btn4Refresh_Click(object sender, EventArgs e)
        {
            this.ResetAccount();
            this.ResetInvoices();

        }

        private void ResetInvoices()
        {
            ResetInvoice();
            dtgv4Invoices.DataSource = null;
            dtgv4Invoices.Refresh();
        }

         private void ResetInvoice()
         {
            //Clear invoice detail panel
            dt4LastVisit.Value = dt4LastVisit.MinDate;
            txt4CustomerID.Text = "";
            txt4Name.Text = "";
            txt4Balance.Text = "";
      
        }
                                
        ///
        ///Tab Page HealthInfor mathods
        ///

        private void LoadHealthInfor()
        {
            string customerIdStr = txt5CuctomerID.Text.Trim();
            
            try
            {
                CustomerID = customerIdStr==""? CustomerID : long.Parse(customerIdStr);
                DataRow healthInfor  = this.customerService.SelectHealthInforById(CustomerID);
                if (healthInfor != null)
                {
                    txt5CuctomerID.Text = healthInfor[0].ToString();
                    txt5FamilyHistory.Text = healthInfor[1].ToString();
                    txt5Allergies.Text = healthInfor[2].ToString();
                    txt5Musculoskeletal.Text = healthInfor[3].ToString();
                    txt5Motor.Text = healthInfor[4].ToString();

                    //Load Customer Name
                    DataTable customer = this.customerService.SearchCustomers(CustomerID.ToString(), "", " Or");
                    if (customer != null && customer.Rows.Count > 0)
                    {
                        txt5Name.Text = customer.Rows[0][1].ToString() + " " + customer.Rows[0][2].ToString();
                        txt5DoB.Text = Convert.ToDateTime(customer.Rows[0][4]).ToShortDateString();
                        txt5Sex.Text = Enum.Parse(typeof(Sex), customer.Rows[0][3].ToString()).ToString();
                    }
                }
                else
                    ResetHealthInfor();

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
                return;
            }
        }

        private bool LoadVisits()
        {
            string customerIdStr = txt5CuctomerID.Text.Trim();
            if (customerIdStr != null && customerIdStr !="")
                CustomerID = long.Parse(customerIdStr);
            else
                return true;
            dtgv5VisitingHistory.RowHeadersVisible = true;
            try
            {                
                DataTable initVisits = this.customerService.SelectInitVisitById(CustomerID);
                DataTable followupVisits = this.customerService.SelectFollowupVisitById(CustomerID);
                if (initVisits != null)
                {
                    dtgv5VisitingHistory.DataSource = null;
                    dtgv5VisitingHistory.Rows.Clear();
                    int columns = 5;
                    dtgv5VisitingHistory.ColumnCount = columns;
                    dtgv5VisitingHistory.Columns[0].HeaderCell.Value = "Date";
                    dtgv5VisitingHistory.Columns[1].HeaderCell.Value = "Init Visit No.";
                    dtgv5VisitingHistory.Columns[2].HeaderCell.Value = "Follow Up No.";
                    dtgv5VisitingHistory.Columns[3].HeaderCell.Value = "Visiting Type";
                    dtgv5VisitingHistory.Columns[4].HeaderCell.Value = "H/M Code";
                    int lastTime = 0;

                    for (int i = 0; i < initVisits.Rows.Count; i++)
                    {
                        DataRow initVisit = initVisits.Rows[i];         //Convert.ToDateTime(customer.Rows[0][4]).ToShortDateString()
                        int initNo = int.Parse(initVisit[1].ToString());
                        dtgv5VisitingHistory.Rows.Add(((DateTime)initVisit[2]).ToShortDateString(), initVisit[1].ToString(), " ", VisitingType.Initial, "");
                        //dtgv5VisitingHistory.Rows[row].HeaderCell.Value = row.ToString();
                        //row++;
                         //dtgv5VisitingHistory.Rows[row].HeaderCell.RowIndex.
                        for (int j = lastTime; j < followupVisits.Rows.Count; j++)
                        {
                            DataRow followup = followupVisits.Rows[j];
                            int fInitNo = int.Parse(followup[1].ToString());
                            if (initNo == fInitNo)
                            {
                                dtgv5VisitingHistory.Rows.Add(((DateTime)followup[3]).ToShortDateString(), followup[1].ToString(), followup[2].ToString(), VisitingType.FollowUp, followup[8].ToString());
                                //dtgv5VisitingHistory.Rows[row].HeaderCell.Value = row.ToString();
                                //row++;
                            }
                            else
                            {
                                lastTime = j;
                                break;
                            }

                        }
                    }
                    foreach (DataGridViewRow row in dtgv5VisitingHistory.Rows)
                    {
                        row.HeaderCell.Value = (row.Index + 1).ToString();
                    }
                    


                    //Load Customer Name
                    DataTable customer = this.customerService.SearchCustomers(CustomerID.ToString(), "", " Or");
                    if (customer != null && customer.Rows.Count > 0)
                    {
                        txt5Name.Text = customer.Rows[0][1].ToString() + " " + customer.Rows[0][2].ToString();
                        txt5DoB.Text = Convert.ToDateTime(customer.Rows[0][4]).ToShortDateString();
                        txt5Sex.Text = Enum.Parse(typeof(Sex), customer.Rows[0][3].ToString()).ToString();
                    }
                    return true;
                }
                else
                {
                    ResetHealthInfor();
                    return true;
                }

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
                return false;
            }
        }

        private void ResetHealthInfor()
        {
            //txt5CuctomerID.Text = healthInfor[0].ToString();
            txt5FamilyHistory.Clear();
            txt5Allergies.Clear();
            txt5Musculoskeletal.Clear();
            txt5Motor.Clear();

            txt5Name.Clear();
            txt5Sex.Clear();
            txt5DoB.Clear();
            dtgv5VisitingHistory.DataSource = null;
            dtgv5VisitingHistory.Refresh();
        }

        //Add a customer Health Infor record
        private void btn5Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the validation passes
                if (true) //this.ValidateHealthInfor())
                {
                    // Assign the values to the model
                    HealthInforModel healthInforModel = new HealthInforModel()
                    {
                        CustomerID = this.txt5CuctomerID.Text.Trim() == "" ? CustomerID : long.Parse(this.txt5CuctomerID.Text.Trim()),
                        FamilyHistory = this.txt5FamilyHistory.Text.Trim(),
                        Allergies = this.txt5Allergies.Text.Trim(),
                        Musculoskeletal = this.txt5Musculoskeletal.Text.Trim(),
                        Motor = this.txt5Motor.Text.Trim()
                    };

                    // Call the service method and assign the return status to variable
                    var success = this.customerService.AddHealthInfor(healthInforModel);

                    // if status of success variable is true then display a information else display the error message
                    if (success)
                    {
                        //Update customer information
                        LoadHealthInfor();
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
               /* else
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
                this.ShowErrorMessage(ex);
            }      
        }

        private void btn5Search_Click(object sender, EventArgs e)
        {
            this.LoadHealthInfor();
            this.LoadVisits();

        }

        private void btn5Refresh_Click(object sender, EventArgs e)
        {
            ResetHealthInfor();
            txt5CuctomerID.Clear();
            CustomerID = -1;
        }

        private void btn5Update_Click(object sender, EventArgs e)
        {
                       // if (this.ValidateUpdate())
           // {
                // Assign the values to the model
                HealthInforModel healthInforModel = new HealthInforModel()
                {
                    CustomerID = this.txt5CuctomerID.Text.Trim() == "" ? CustomerID : long.Parse(this.txt5CuctomerID.Text.Trim()),
                    FamilyHistory = this.txt5FamilyHistory.Text.Trim(),
                    Allergies = this.txt5Allergies.Text.Trim(),
                    Musculoskeletal = this.txt5Musculoskeletal.Text.Trim(),
                    Motor = this.txt5Motor.Text.Trim()
                };


                var flag = this.customerService.UpdateHealthInfor(healthInforModel);

                if (flag)
                {
                    //Update account        
                    /* DataTable customer = this.customerService.UpdateAccount(contactModel.CustomerID.ToString(), "", " Or");
                     if (customer != null && customer.Rows.Count > 0)
                     {
                         txt3Name.Text = customer.Rows[0][1].ToString() + " " + customer.Rows[0][1].ToString();
                     }   */
                    ;
                }
                else
                {
                    MessageBox.Show(
                   "Updated the health infor failed!",
                   Resources.Registration_Error_Message_Title,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            /*}
            else
            {
                MessageBox.Show(
                    this.errorMessage,
                    Resources.Registration_Error_Message_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }*/
        }


        //Initial Visiting Page Methods        
        private bool LoadInitVisitInfor()
        {
            CustomerID = txt61CustomerID.Text.Trim() != ""? long.Parse(txt61CustomerID.Text.Trim()) : CustomerID;
            if (CustomerID == -1 )
            {
                this.ResetInitVisitInfor();
                return true;
            }

            int initNo = txt61InitNo.Text.Trim() =="" ? -1 : int.Parse(txt61InitNo.Text.Trim());

            try
            {
                DataRow initVisit = this.customerService.SelectInitVisitByInitNo(CustomerID, initNo);
                // DataTable followupVisits = this.customerService.SelectFollowupVisitById(CustomerID);
                if (initVisit != null)
                {
                    this.txt61InitNo.Text = initVisit[1].ToString();
                    this.dtp61InitDate.Value = (DateTime)initVisit[2];
                    this.txt61Medications.Text = initVisit[3].ToString();
                    this.txt61ChievComplaint.Text = initVisit[4].ToString();
                    this.txt61HistoryOfPresentIlliness.Text = initVisit[5].ToString();
                    this.txt61BP.Text = initVisit[6].ToString();
                    this.txt61Pulse.Text = initVisit[7].ToString();
                    this.txt61Cranial.Text = initVisit[8].ToString();
                    this.txt61Cerbellar.Text = initVisit[9].ToString();
                    this.txt61DeepTendonRef.Text = initVisit[10].ToString();
                    this.txt61Sensor.Text = initVisit[11].ToString();
                    this.txt61Impression.Text = initVisit[12].ToString();


                    //Load Customer Name
                    DataTable customer = this.customerService.SearchCustomers(CustomerID.ToString(), "", " Or");
                    if (customer != null && customer.Rows.Count > 0)
                    {
                        this.txt61Name.Text = customer.Rows[0][1].ToString() + " " + customer.Rows[0][2].ToString();
                        txt61DoB.Text = Convert.ToDateTime(customer.Rows[0][4]).ToShortDateString();
                        txt61Sex.Text = Enum.Parse(typeof(Sex), customer.Rows[0][3].ToString()).ToString();
                    }
                    return true;
                }
                else
                {
                    ResetInitVisitInfor();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Load Initial Visit Information error: " + e.ToString());
            }
            return false;
        }

        private void ResetInitVisitInfor()
        {
            this.txt61Name.Text = "";
            txt61DoB.Text = "";
            txt61Sex.Text = "";

            this.txt61InitNo.Text = "";
            this.dtp61InitDate.Text = "";
            this.txt61Medications.Text = "";
            this.txt61ChievComplaint.Text = "";
            this.txt61HistoryOfPresentIlliness.Text = "";
            this.txt61BP.Text = "";
            this.txt61Pulse.Text = "";
            this.txt61Cranial.Text = "";
            this.txt61Cerbellar.Text = "";
            this.txt61DeepTendonRef.Text = "";
            this.txt61Sensor.Text = "";
            this.txt61Impression.Text = "";

        }

        private void btn61Search_Click(object sender, EventArgs e)
        {
            this.LoadInitVisitInfor();
        }

        
        //Follow up Visiting Page Methods        
        private bool LoadFollowUpVisitInfor()
        {
            CustomerID = txt62CustomerID.Text.Trim() != ""? long.Parse(txt62CustomerID.Text.Trim()) : CustomerID;
            if (CustomerID == -1 )
            {
                this.ResetFollowUpVisitInfor();
                return true;
            }

            int[] splitedFollowupNo = SplitFollowupNoToInt(txt62followUpNo.Text.Trim());
            int initNo = splitedFollowupNo[0];
            int followupNo = splitedFollowupNo[1];


            try
            {
                DataRow followupVisit = this.customerService.SelectFollowUpVisitByInitNo(CustomerID, initNo, followupNo);
                // DataTable followupVisits = this.customerService.SelectFollowupVisitById(CustomerID);
                DataTable procedureCodeTable = this.customerService.LoadProcedureCodes();
                DataColumn procedureCodes = procedureCodeTable.Columns[0];
                DataTable hmCodeTable = this.customerService.LoadHMCodes();
                DataColumn hmCodes = hmCodeTable.Columns[0];

                if (followupVisit != null)
                {
                    this.txt62followUpNo.Text = AssembleFollowupNo(followupVisit[1].ToString(), followupVisit[2].ToString());
                    this.dtp62VisitDate.Value = (DateTime)followupVisit[3];                    
                    this.txt62Subject.Text = followupVisit[4].ToString();
                    this.txt62Object.Text = followupVisit[5].ToString();
                    string diagCodes = followupVisit[6].ToString();
                    lst62DiagCodes.Items.Clear();
                    foreach (string code in SplitCodes(diagCodes))
                        lst62DiagCodes.Items.Add(code);

                    string procedureCode = followupVisit[7].ToString();
                    lst62ProcedureCodes.Items.Clear();
                    foreach (string code in SplitCodes(procedureCode))
                        lst62ProcedureCodes.Items.Add(code);

                    string hmCode = followupVisit[8].ToString();
                    lst62HMCodes.Items.Clear();
                    foreach (string code in SplitCodes(hmCode))
                        lst62HMCodes.Items.Add(code);                    

                    //Load Customer Name
                    DataTable customer = this.customerService.SearchCustomers(CustomerID.ToString(), "", " Or");
                    if (customer != null && customer.Rows.Count > 0)
                    {
                        this.txt62Name.Text = customer.Rows[0][1].ToString() + " " + customer.Rows[0][2].ToString();
                        this.txt62DoB.Text = Convert.ToDateTime(customer.Rows[0][4]).ToShortDateString();
                        txt62Sex.Text = Enum.Parse(typeof(Sex), customer.Rows[0][3].ToString()).ToString();
                    }
                    return true;
                }
                else
                {
                    ResetFollowUpVisitInfor();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Load Initial Visit Information error: " + e.ToString());
            }
            return false;
        }


        private void ResetFollowUpVisitInfor()
        {
            this.txt62Name.Text = "";
            txt62DoB.Text = "";
            txt62Sex.Text = "";

            this.dtp62VisitDate.Text = "";
            this.txt62followUpNo.Text = "";
            this.txt62Subject.Text = "";
            this.txt62Object.Text = "";
            this.lst62DiagCodes.Items.Clear();
            this.lst62ProcedureCodes.Items.Clear();
            this.lst62ProcedureCodes.Text = "";
            this.lst62HMCodes.Items.Clear();
            this.lst62HMCodes.Text = "";

        }

        private void btn62Search_Click(object sender, EventArgs e)
        {
            this.LoadFollowUpVisitInfor();
        }

        //Add initial visiting record
        private void btn61Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the validation passes
                if (true) //this.ValidateHealthInfor())
                {
                    // Assign the values to the model`
                    InitVisitModel initVisitModel = new InitVisitModel()
                    {
                        CustomerID = this.txt61CustomerID.Text.Trim() == "" ? this.CustomerID : long.Parse(this.txt61CustomerID.Text.Trim()),
                        InitialNo = this.txt61InitNo.Text.Trim()==""? -1 : int.Parse(txt61InitNo.Text.Trim()),
                        InitialDate = this.dtp61InitDate.Value,
                        Medications = this.txt61Medications.Text.Trim(),
                        ChiefComplaint = this.txt61ChievComplaint.Text.Trim(),
                        HistoryOfPresentIllness = this.txt61HistoryOfPresentIlliness.Text.Trim(),
                        BP = this.txt61BP.Text.Trim(),
                        Pulse = this.txt61Pulse.Text.Trim(),
                        Cranial = txt61Cranial.Text.Trim(),
                        Cerbellar = txt61Cerbellar.Text.Trim(),
                        DeepTendonRef = txt61DeepTendonRef.Text.Trim(),
                        Sensory = txt61Sensor.Text.Trim(),
                        Impression = txt61Impression.Text.Trim()
                    };
                    //Get a new initial No.
                    initVisitModel.InitialNo = this.customerService.CreateInitialNo(initVisitModel.CustomerID);
                    // Call the service method and assign the return status to variable
                    var success = this.customerService.AddInitVisit(initVisitModel);

                    // if status of success variable is true then display a information else display the error message
                    if (success)
                    {
                        txt61InitNo.Text = initVisitModel.InitialNo.ToString();
                        //Update customer information
                        LoadInitVisitInfor();
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
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }      
        }

        private void btn61Update_Click(object sender, EventArgs e)
        {
            // Assign the values to the model
            InitVisitModel initVisitModel = new InitVisitModel()
            {
                CustomerID = this.txt61CustomerID.Text.Trim() == "" ? this.CustomerID : long.Parse(this.txt61CustomerID.Text.Trim()),
                InitialNo = this.txt61InitNo.Text.Trim() == "" ? -1 : int.Parse(txt61InitNo.Text.Trim()),
                InitialDate = this.dtp61InitDate.Value,
                Medications = this.txt61Medications.Text.Trim(),
                ChiefComplaint = this.txt61ChievComplaint.Text.Trim(),
                HistoryOfPresentIllness = this.txt61HistoryOfPresentIlliness.Text.Trim(),
                BP = this.txt61BP.Text.Trim(),
                Pulse = txt61BP.Text.Trim(),
                Cranial = txt61Cranial.Text.Trim(),
                Cerbellar = txt61Cerbellar.Text.Trim(),
                DeepTendonRef = txt61DeepTendonRef.Text.Trim(),
                Sensory = txt61Sensor.Text.Trim(),
                Impression = txt61Impression.Text.Trim()
            };


            var flag = this.customerService.UpdateInitVisit(initVisitModel);

            if (flag)
            {
                //Update account        
                /* DataTable customer = this.customerService.UpdateAccount(contactModel.CustomerID.ToString(), "", " Or");
                 if (customer != null && customer.Rows.Count > 0)
                 {
                     txt3Name.Text = customer.Rows[0][1].ToString() + " " + customer.Rows[0][1].ToString();
                 }   */
                ;
            }
            else
            {
                MessageBox.Show(
               "Updated the Initial Visit failed!",
               Resources.Registration_Error_Message_Title,
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }

        private void btn61Refresh_Click(object sender, EventArgs e)
        {
            ResetInitVisitInfor();
        }


        private void tabControlVisit_SelectedIndexChanged(Object sender, EventArgs e)
        {
            //MessageBox.Show("You are in the tabControlVisit_SelectedIndexChanged.SelectedIndexChanged event.");
            try
            {
                if (tabControlVisit.SelectedIndex == 0) // Tab Initial Visit
                {                    
                    this.LoadInitVisitInfor();
                }
                else if (tabControlVisit.SelectedIndex == 1) //Tab Follow Up Visit
                {
                    this.LoadFollowUpVisitInfor();
                }

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }

        }

        private void txt61CustomerID_TextChanged(object sender, EventArgs e)
        {
            this.CustomerID = txt61CustomerID.Text.Trim() == "" ? -1 : long.Parse(txt61CustomerID.Text.Trim());
        }

        private void txt62CustomerID_TextChanged(object sender, EventArgs e)
        {
            this.CustomerID = txt62CustomerID.Text.Trim() == "" ? -1 : long.Parse(txt62CustomerID.Text.Trim());
        }

        private void MyGrid_KeyDown(object sender, KeyEventArgs e)
        {
            ;
           /* if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                DataGridViewRow currentRow = MyGrid.CurrentRow;
                MessageBox.Show(Convert.ToString(currentRow.Cells[0].Value));
            } */
        }

        private void dtgv5VisitingHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ;
        }

        private void dtgv5VisitingHistory_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                DataGridViewRow currentRow = dtgv5VisitingHistory.CurrentRow;
                //MessageBox.Show(Convert.ToString(currentRow.Cells[0].Value));

            }
        }

        private void dtgv5VisitingHistory_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow currentRow = dtgv5VisitingHistory.CurrentRow;
           // MessageBox.Show(Convert.ToString(currentRow.Cells[0].Value));
        }

        private void dtgv5VisitingHistory_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow currentRow = dtgv5VisitingHistory.CurrentRow;
            //MessageBox.Show(Convert.ToString(currentRow.Cells[0].Value));
            LoadVisitInfor(currentRow);
        }

        private void LoadVisitInfor(DataGridViewRow currentRow)
        {
            txt61CustomerID.Text = txt62CustomerID.Text = txt5CuctomerID.Text;
            CustomerID = long.Parse(txt5CuctomerID.Text.Trim());
            tab.SelectedIndex = 5;
            
            if ((VisitingType)currentRow.Cells[3].Value == VisitingType.Initial)
            {
                //Load initial visit infor to InitVisit TabPage                
                txt61InitNo.Text = currentRow.Cells[1].Value.ToString();
                LoadInitVisitInfor();
                //Swatch to tabControlVisit tabpInitVisit
                if (tabControlVisit.SelectedIndex == 1)
                    tabControlVisit.SelectedIndex = 0;
                else
                    this.LoadInitVisitInfor();
            }
            else
            {
                //Load Follow Up visit infor to FollowUp TabPage
                txt62followUpNo.Text = AssembleFollowupNo(currentRow.Cells[1].Value.ToString(), currentRow.Cells[2].Value.ToString());
                if(tabControlVisit.SelectedIndex == 0)
                    tabControlVisit.SelectedIndex = 1;
                else
                    this.LoadFollowUpVisitInfor();
            }
        }

        private void btn62Update_Click(object sender, EventArgs e)
        {
            // Assign the values to the model
            // Check if the validation passes
            if (true) //this.FollowUpVisitModel())
            {
                // Assign the values to the model
                int[] splitedFollowupNo = SplitFollowupNoToInt(txt62followUpNo.Text.Trim());

                FollowUpVisitModel followUpVisitModel = new FollowUpVisitModel()
                {
                    CustomerID = this.txt62CustomerID.Text.Trim() == "" ? this.CustomerID : long.Parse(this.txt62CustomerID.Text.Trim()),
                    InitialNo = splitedFollowupNo[0],
                    FollowUpNo = splitedFollowupNo[1],
                    FollowUpDate = this.dtp62VisitDate.Value,
                    Subjective = this.txt62Subject.Text.Trim(),
                    Objective = this.txt62Object.Text.Trim(),
                    DiagCode = this.AssembleCodes(this.lst62DiagCodes),
                    ProcedureCode = this.AssembleCodes(this.lst62ProcedureCodes),
                    HM_Code = this.AssembleCodes(this.lst62HMCodes)
                };



                var flag = this.customerService.UpdateFollowUpVisit(followUpVisitModel);

                if (flag)
                {
                    //Update account        
                    /* DataTable customer = this.customerService.UpdateAccount(contactModel.CustomerID.ToString(), "", " Or");
                     if (customer != null && customer.Rows.Count > 0)
                     {
                         txt3Name.Text = customer.Rows[0][1].ToString() + " " + customer.Rows[0][1].ToString();
                     }   */
                    ;
                }
                else
                {
                    MessageBox.Show(
                   "Updated the Follow Up Visit failed!",
                   Resources.Registration_Error_Message_Title,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }

        }

        private void btn62Refresh_Click(object sender, EventArgs e)
        {

        }

        //Add follow up record
        private void btn62Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the validation passes
                if (true) //this.FollowUpVisitModel())
                {
                    // Assign the values to the model
                    int[] splitedFollowupNo = SplitFollowupNoToInt(this.txt62followUpNo.Text.Trim());
                    
                    FollowUpVisitModel followUpVisitModel = new FollowUpVisitModel()
                    {
                        CustomerID = this.txt62CustomerID.Text.Trim() == "" ? this.CustomerID : long.Parse(this.txt62CustomerID.Text.Trim()),
                        InitialNo = splitedFollowupNo[0],
                        FollowUpNo = splitedFollowupNo[1],
                        FollowUpDate = this.dtp62VisitDate.Value,
                        Subjective = this.txt62Subject.Text.Trim(),
                        Objective = this.txt62Object.Text.Trim(),
                        DiagCode = AssembleCodes(this.lst62DiagCodes),
                        ProcedureCode = AssembleCodes(lst62ProcedureCodes),
                        HM_Code = AssembleCodes(this.lst62HMCodes)
                    };

                    //Check if the initial no is OK
                    if (followUpVisitModel.InitialNo <= 0)
                    {
                        //No initial no.
                        // display the message box
                        MessageBox.Show(
                            "Cannot add pollow up record. Please create initial record first!");
                        return;
                    }

                    //Create follow up No.
                    followUpVisitModel.FollowUpNo = this.customerService.CreateFollowupNo(followUpVisitModel.CustomerID, followUpVisitModel.InitialNo);
                    // Call the service method and assign the return status to variable
                    var success = this.customerService.AddFollowUpVisit(followUpVisitModel);

                    // if status of success variable is true then display a information else display the error message
                    if (success)
                    {
                        txt62CustomerID.Text = followUpVisitModel.CustomerID.ToString();
                        txt62followUpNo.Text = AssembleFollowupNo(followUpVisitModel.InitialNo.ToString(), 
                                                                    followUpVisitModel.FollowUpNo.ToString());
                        //Update customer information
                        LoadFollowUpVisitInfor();
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
               /* else
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
                this.ShowErrorMessage(ex);
            }      
        }

        private bool validateFollowupNo(string followupNo)
        {
            if (followupNo == null || followupNo == "")
                return false;
            bool rv = true;
            foreach(char c in followupNo)
                rv = rv && (c=='-' ||(c>='0' && c<='9'));
            return rv && followupNo[0] != '-' && followupNo[followupNo.Length - 1] != '-';
         
        }
        //Dis-assemable follow up no
        private string[] SplitFollowupNo(string followupNo)
        {
            if (!validateFollowupNo(followupNo))
                return null;

            return followupNo.Trim().Split('-');
        }

        private int[] SplitFollowupNoToInt(string followupNo)
        {
            string[] splitedNo = SplitFollowupNo(followupNo);
            int[] nos = new int[2];   
            if(splitedNo== null)
            {
                nos[0] = -1;
                nos[1] = -1;
                return nos;
            }

            if (splitedNo.Length == 2)
            {
                nos[0] = int.Parse(splitedNo[0]);
                nos[1] = int.Parse(splitedNo[1]);
            }
            else if (splitedNo.Length == 1)
            {
                nos[0] = int.Parse(splitedNo[0]);
                nos[1] = -1;
            }

            return nos;
        }

        private string AssembleFollowupNo(string initNo, string followup)
        {
            if (initNo == null || initNo == "" || followup == null || followup == "")
                return null;
            return initNo.Trim() + "-" + followup.Trim();
        }




        /// <summary>
        /// Populate procedure codes or H/M code from CodePickup obj
        /// </summary>
        /// <param name=""></param>
        /// <returns>void</returns>
        public void PopulateCodes(DataGridView dataGrid)
        {
            if (codePickuprStatus == 1)  //Procedure Code
            {
                lst62ProcedureCodes.Items.Clear();
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string code = row.Cells[0].Value.ToString().Trim();
                        if (code != "")
                            lst62ProcedureCodes.Items.Add(code);
                    }
                }
            }
            else if( codePickuprStatus == 2) //H/M Code
            {
                lst62HMCodes.Items.Clear();
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string code = row.Cells[0].Value.ToString().Trim();
                        if (code != "")
                            lst62HMCodes.Items.Add(code);
                    }
                }
            } 
            else if ( codePickuprStatus == 3) //Diagonostic  code
            {
                lst62DiagCodes.Items.Clear();
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        string code = row.Cells[0].Value.ToString().Trim();
                        if (code != "")
                            lst62DiagCodes.Items.Add(code);
                    }
                }
            }
        }

      
        public void ActiveObj()
        {
      
            this.Show();
            this.BringToFront();
        }

        private void lbl62ProcedureCodes_Click(object sender, EventArgs e)
        {
            codePickuprStatus = 1; //ProcedureCode Pickup
            var procedureCodeEditor = new frmCodePickup(this);
            //frmCodePickupEditor.Closing += frmCodePickup.frmCodePickup_Closing;
            procedureCodeEditor.Show();
            procedureCodeEditor.BringToFront();          
        }


        private void lbl62HMCodes_Click(object sender, EventArgs e)
        {
            codePickuprStatus = 2; // H/M Code Pickup
            var hmCodeEditor = new frmHMCodePickup(this);
            hmCodeEditor.Show();
            hmCodeEditor.BringToFront();

        }

        private void lbl7SetProcedureCodes_Click(object sender, EventArgs e)
        {
            codePickuprStatus = 1;
            var procedureCodeEditor = new frmCodeEditor(this);
            procedureCodeEditor.Show();
            procedureCodeEditor.BringToFront();
            this.Hide();
        }

        private void lbl7SetHMCode_Click(object sender, EventArgs e)
        {
            codePickuprStatus = 2;
            var hmCodeEditor = new HMCodeEditor(this);
            hmCodeEditor.Show();
            hmCodeEditor.BringToFront();
            this.Hide();
        }



        private string AssembleCodes(ListBox lstPprocedureCodes)
        {
            if (lstPprocedureCodes == null || lstPprocedureCodes.Items.Count == 0 )
                return null;
            string procedureCodes = "";
            foreach (var item in lstPprocedureCodes.Items)
                procedureCodes += item.ToString() + ";";
            return procedureCodes;
        }

        private string[] SplitCodes(string procedureCodes)
        {
            if(procedureCodes==null || procedureCodes.Trim() == "")
                return null;
            string codes = procedureCodes.Trim(';');
            return procedureCodes.Split(';');
        }

        private void lbl62DiagnosticsCodes_Click(object sender, EventArgs e)
        {
            codePickuprStatus = 3;
            var diagCodeEditor = new frmDiagCodePickup(this);

            diagCodeEditor.Show();
            diagCodeEditor.BringToFront();
            //this.Hide();
        }

        private void lbl7SetDiagnosticsCodes_Click(object sender, EventArgs e)
        {
            codePickuprStatus = 3;
            var diagCodeEditor = new DiagCodeEditor(this);
            diagCodeEditor.Show();
            diagCodeEditor.BringToFront();
            this.Hide();
        }

        private void btn4AddInvoice_Click(object sender, EventArgs e)
        {
            var invoiceEditor = new frmInvoice(this);
            invoiceEditor.Closing += invoiceEditor.frmInvoice_Closing;
            invoiceEditor.Show();
            invoiceEditor.BringToFront();
            this.Hide();
        }

        public string CodeDescription ( string code)
        {
            if(ProcedureCodes == null )
            {
                ProcedureCodes = this.customerService.LoadProcedureCodes();
            }

            string desc = null;
            foreach(DataRow row in ProcedureCodes.Rows)
            {
                if( code.Trim() == row[0].ToString().Trim())
                {
                    desc = row[1].ToString();
                    break;
                }
            }

            if( desc == null )
            {
                if(HMCodes == null )
                    HMCodes = this.customerService.LoadHMCodes();

                foreach(DataRow row in HMCodes.Rows)
                {
                    if (code.Trim() == row[0].ToString())
                    {
                        desc = row[1].ToString();
                        break;
                    }
                }
            }

            return desc;

        }

        public string GetCustomerNameByID(long id)
        {
            DataRow row = customerService.GetCustomerById(id);
            if (row != null )
                return row[1].ToString() + " " + row[2].ToString();
            else
                return "";
        }

        private void btnInvdetail_Click(object sender, EventArgs e)
        {
            frmInvoice invoiceEditor = null;
            if (dtgv4Invoices.CurrentRow != null)
            {
                int invNo = int.Parse(dtgv4Invoices.CurrentRow.Cells[1].Value.ToString());
                invoiceEditor = new frmInvoice(this, invNo);
            }
            else
                invoiceEditor = new frmInvoice(this);
            invoiceEditor.Closing += invoiceEditor.frmInvoice_Closing;
            invoiceEditor.Show();
            invoiceEditor.BringToFront();
            this.Hide();
        }

        private void btn4Quit_Click(object sender, EventArgs e)
        {
            Manage_Closing(sender, e);
        }

        /// <summary>
        /// Get List of code string
        /// </summary>
        /// <param name=""></param>
        /// <returns>A List of code string</returns>
        public DataTable GetCodeTable()
        {
            if (codePickuprStatus == 1) //Procedure Code
            {
                return this.CustomerServiceObj.LoadProcedureCodes();
            }
            else if (codePickuprStatus == 2) //HM Code
                return this.CustomerServiceObj.LoadHMCodes();
            else if (codePickuprStatus == 3) //Diagonostic Code
                return this.CustomerServiceObj.LoadDiagCodes();
            else
                return null;
        }

        /// <summary>
        /// Get List of selected code strings
        /// </summary>
        /// <param name=""></param>
        /// <returns>A List of code strings</returns>
        public List<string> GetSelectedCodes()
        {
            ListBox codeSource = null;
            if( codePickuprStatus == 1)
                codeSource = lst62ProcedureCodes;
            else if( codePickuprStatus == 2  )
                codeSource = lst62HMCodes;
            else if( codePickuprStatus == 3  )
                codeSource = lst62DiagCodes;

            List<string> codeList = new List<string>();
            foreach( string code in codeSource.Items )
            {
                codeList.Add(code);
            }
            return codeList;
        }
    }     
}
