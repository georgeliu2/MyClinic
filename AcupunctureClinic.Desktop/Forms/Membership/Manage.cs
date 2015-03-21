// -----------------------------------------------------------------------
// <copyright file="Manage.cs" company="John">
//  Acupuncture Clinic Record Management System 2015
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
    using AcupunctureClinic.Data.Enums;
    using AcupunctureClinic.Desktop.Properties;
    //using Microsoft.Office.Interop.Excel;
    using Excel = Microsoft.Office.Interop.Excel; 

    /// <summary>
    /// Manage screen - To view, search, print, export  customers information
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
        private long CustomerID;

        public ICusomerService CustomerServiceObj
        { get { return customerService; }   }

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
                }
                else if (tab.SelectedIndex == 6) //Tab Procedure Code
                {
                    Initilizedtgv7ProcedureCodeListStyle();
                    this.LoadProcedureCodes();
                }
                else if (tab.SelectedIndex == 7) //Tab H/M Code
                {
                    Initilizedtgv8HMCodeListStyle();
                    this.LoadHMCodes();
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
            Application.Exit();
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

        private void LoadAccountAndInvoice()
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
                    txt4SearchInvNo.Text = txt4InvNo.Text = account[1].ToString();
                    currentInvNo = long.Parse(account[1].ToString());
                    dt4LastVisit.Value = Convert.ToDateTime(account[2]);
                    txt4SearchBalance.Text = account[3].ToString();
                }

                //Load Customer Name
                DataTable customer = this.customerService.SearchCustomers(CustomerID.ToString(), "", " Or");
                if (customer != null && customer.Rows.Count > 0)
                {
                    txt4Name.Text = customer.Rows[0][1].ToString() + " " + customer.Rows[0][1].ToString();
                }
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
            DataTable invoices = this.customerService.GetInvoicesByCustomerID(customerId);

            if (invoices != null && invoices.Rows.Count > 0)
            {
                DataColumn[] keys = new DataColumn[1];
                keys[0] = invoices.Columns[1];
                this.LoadInvoicesForDataGridView(invoices);
                invoices.PrimaryKey = keys;
                DataRow invoice = invoices.Rows.Find(currentInvNo);
                if (invoice != null)
                {
                    dtInvDate.Value = Convert.ToDateTime(invoice[2]);
                    txt4ProcedureCode.Text = invoice[3].ToString();
                    txt4HMCode.Text = invoice[4].ToString();
                    cmb4PayMethod.SelectedIndex = (int)(PaymentMethods)Enum.Parse(typeof(PaymentMethods), invoice[6].ToString());
                    cmb4CardType.SelectedIndex = (int)(CardTypes)Enum.Parse(typeof(CardTypes), invoice[7].ToString());
                    txt4CardNo.Text = invoice[8].ToString();
                    if (invoice[9] != null && invoice[9].ToString().Trim() != "")
                        dt4ExpDate.Value = Convert.ToDateTime(invoice[9]);
                    txt4SubTotal.Text = invoice[10].ToString();
                    txt4Balance.Text = invoice[12].ToString();
                    txt4AmtPaid.Text = invoice[11].ToString();
                    txt4Total.Text = invoice[13].ToString();
                    txt4DiscRate.Text = invoice[5].ToString();
                }
            }
            //else
            //if cannot get the name, just ignore it
        }

        private void LoadInvoice(DataGridViewRow row)
        {
            //CustomerID = this.txt4CustomerID.Text.Trim() == "" ? CustomerID : long.Parse(txt4CustomerID.Text.Trim());
            //long invNo = (long)row.Cells[1].Value;

            txt4InvNo.Text = row.Cells[1].Value.ToString();
            dtInvDate.Value = Convert.ToDateTime(row.Cells[2].Value);
            txt4ProcedureCode.Text = row.Cells[3].Value.ToString();
            txt4HMCode.Text = row.Cells[4].Value.ToString();
            txt4DiscRate.Text = row.Cells[5].Value.ToString();
            cmb4PayMethod.SelectedValue = row.Cells[6].Value;
            //cmb4PayMethod.SelectedIndex = (int)(PaymentMethods)Enum.Parse(typeof(PaymentMethods), row.Cells[6].Value.ToString())
            cmb4CardType.SelectedValue = row.Cells[7].Value;
            txt4CardNo.Text = row.Cells[8].Value.ToString();
            dt4ExpDate.Value = row.Cells[9].Value.ToString() == "" ? dt4ExpDate.MinDate : Convert.ToDateTime(row.Cells[9].Value);
            txt4SubTotal.Text = row.Cells[10].Value.ToString();
            txt4AmtPaid.Text = row.Cells[11].Value.ToString();
            txt4Balance.Text = row.Cells[12].Value.ToString();
            txt4Total.Text = row.Cells[13].Value.ToString();
           
        }

        private void dataGridView4Invoices_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow currentRow = dataGridView4Invoices.CurrentRow;
            //MessageBox.Show(Convert.ToString(currentRow.Cells[0].Value));

            this.LoadInvoice(currentRow);
        }

        /// <summary>
        /// Initializes data grid view style
        /// </summary>
        private void InitilizeDataGridView4InvoicesStyle()
        {
            // Setting the style of the DataGridView control
            dataGridView4Invoices.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dataGridView4Invoices.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dataGridView4Invoices.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView4Invoices.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView4Invoices.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dataGridView4Invoices.DefaultCellStyle.BackColor = Color.Empty;
            dataGridView4Invoices.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            dataGridView4Invoices.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView4Invoices.GridColor = SystemColors.ControlDarkDark;
        }

        private void LoadInvoicesForDataGridView(System.Data.DataTable data)
        {
            // Data grid view column setting            
            this.dataGridView4Invoices.DataSource = data;
            this.dataGridView4Invoices.DataMember = data.TableName;
            this.dataGridView4Invoices.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void ResetAccount()
        {
            txt4CustomerID.Text = "";
            txt4Name.Text = "";
            dt4LastVisit.Value = dt4LastVisit.MinDate;
            txt4SearchInvNo.Text = "";
            txt4SearchBalance.Text = "";
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
            dataGridView4Invoices.DataSource = null;
            dataGridView4Invoices.Refresh();
        }

         private void ResetInvoice()
         {
            //Clear invoice detail panel
            dtInvDate.Value = dtInvDate.MinDate;
            txt4ProcedureCode.Text = "";
            txt4HMCode.Text = "";
            cmb4PayMethod.SelectedIndex = 0;
            cmb4CardType.SelectedIndex = 0;
            txt4CardNo.Text = "";
            dt4ExpDate.Value = dt4ExpDate.MinDate;
            txt4SubTotal.Text ="";
            txt4Balance.Text = "";
            txt4AmtPaid.Text = "";
            txt4Total.Text = "";
            txt4DiscRate.Text = "";
        }

        private void btn4AddInv_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the validation passes
                if (  true) //this.ValidateInvoice())
                {
                    // Assign the values to the model
                    InvoiceModel invoiceModel = CreateInvoiceModel();
                    

                    // Call the service method and assign the return status to variable
                    var success = this.customerService.AddInvoice(invoiceModel);

                    // if status of success variable is true then display a information else display the error message
                    if (success)
                    {
                        txt4InvNo.Text = invoiceModel.InvNo.ToString();
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
                         // Reset the screen
                        this.ResetInvoices();
                    }
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
                this.ShowErrorMessage(ex);
            }      
        }

        private void btn4UpdateInv_Click(object sender, EventArgs e)
        {
           // if (this.ValidateUpdate())
           // {
                // Assign the values to the model
                InvoiceModel invoiceModel =CreateInvoiceModel();
                

                var flag = this.customerService.UpdateInvoice(invoiceModel);

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
                   "Updated the invoice failed!",
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

        private void btn4DeleteInv_Click(object sender, EventArgs e)
        {           
           
            long invNo = long.Parse(this.txt4InvNo.Text);
            var flag = this.customerService.DeleteInvoice(invNo);
            if (flag)
                this.ResetInvoice();
            else
                MessageBox.Show("Delete invoice failed!");
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
            if (customerIdStr != null || customerIdStr != "")
                CustomerID = long.Parse(customerIdStr);
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

            int initNo = txt62InitNo.Text.Trim() =="" ? -1 : int.Parse(txt62InitNo.Text.Trim());
            int followupNo = txt62followUpNo.Text.Trim() == "" ? -1 : int.Parse(txt62followUpNo.Text.Trim());
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
                    this.txt62InitNo.Text = followupVisit[1].ToString();
                    this.dtp62VisitDate.Value = (DateTime)followupVisit[3];
                    this.txt62followUpNo.Text = followupVisit[2].ToString();
                    this.txt62Subject.Text = followupVisit[4].ToString();
                    this.txt62Object.Text = followupVisit[5].ToString();
                    this.txt62AddNotePlan.Text = followupVisit[6].ToString();
                    string procedureCode = followupVisit[7].ToString();
                    lst62ProcedureCodes.DataSource = procedureCodes;
                    lst62ProcedureCodes.DisplayMember = procedureCode;
                    string hmCode = followupVisit[8].ToString();
                    lst62HMCodes.DataSource = hmCodes;
                    lst62HMCodes.DisplayMember = hmCode;
                    
                    //this.lst62ProcedureCodes.Text = followupVisit[7].ToString();
                    //this.lst62HMCodes.Text = followupVisit[8].ToString();

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

            this.txt62InitNo.Text = "";
            this.dtp62VisitDate.Text = "";
            this.txt62followUpNo.Text = "";
            this.txt62Subject.Text = "";
            this.txt62Object.Text = "";
            this.txt62AddNotePlan.Text = "";
            this.lst62ProcedureCodes.Items.Clear();
            this.lst62ProcedureCodes.Text = "";
            this.lst62HMCodes.Items.Clear();
            this.lst62HMCodes.Text = "";

        }

        private void btn62Search_Click(object sender, EventArgs e)
        {
            this.LoadFollowUpVisitInfor();
        }

        private void btn61Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the validation passes
                if (true) //this.ValidateHealthInfor())
                {
                    // Assign the values to the model
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

                    // Call the service method and assign the return status to variable
                    var success = this.customerService.AddInitVisit(initVisitModel);

                    // if status of success variable is true then display a information else display the error message
                    if (success)
                    {
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
                 tabControlVisit.SelectedIndex = 0;
            }
            else
            {
                //Load Follow Up visit infor to FollowUp TabPage
                txt62InitNo.Text = currentRow.Cells[1].Value.ToString();
                txt62followUpNo.Text = currentRow.Cells[2].Value.ToString();
                tabControlVisit.SelectedIndex = 1;
            }
        }

        private void btn62Update_Click(object sender, EventArgs e)
        {
            // Assign the values to the model
            // Check if the validation passes
            if (true) //this.FollowUpVisitModel())
            {
                // Assign the values to the model
                FollowUpVisitModel followUpVisitModel = new FollowUpVisitModel()
                {
                    CustomerID = this.txt62CustomerID.Text.Trim() == "" ? this.CustomerID : long.Parse(this.txt62CustomerID.Text.Trim()),
                    InitialNo = this.txt62InitNo.Text.Trim() == "" ? -1 : int.Parse(txt62InitNo.Text.Trim()),
                    FollowUpNo = this.txt62followUpNo.Text.Trim() == "" ? -1 : int.Parse(txt62followUpNo.Text.Trim()),
                    FollowUpDate = this.dtp62VisitDate.Value,
                    Subjective = this.txt62Subject.Text.Trim(),
                    Objective = this.txt62Object.Text.Trim(),
                    AddNotePlan = this.txt62AddNotePlan.Text.Trim(),
                    ProcedureCode = this.lst62ProcedureCodes.Text.Trim(),
                    HM_Code = this.lst62HMCodes.Text.Trim()
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

        private void btn62Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the validation passes
                if (true) //this.FollowUpVisitModel())
                {
                    // Assign the values to the model
                    FollowUpVisitModel followUpVisitModel = new FollowUpVisitModel()
                    {
                        CustomerID = this.txt62CustomerID.Text.Trim() == "" ? this.CustomerID : long.Parse(this.txt62CustomerID.Text.Trim()),
                        InitialNo = this.txt62InitNo.Text.Trim() == "" ? -1 : int.Parse(txt62InitNo.Text.Trim()),
                        FollowUpNo = this.txt62followUpNo.Text.Trim() == "" ? -1 : int.Parse(txt62followUpNo.Text.Trim()),
                        FollowUpDate = this.dtp62VisitDate.Value,
                        Subjective = this.txt62Subject.Text.Trim(),
                        Objective = this.txt62Object.Text.Trim(),
                        AddNotePlan = this.txt62AddNotePlan.Text.Trim(),
                        ProcedureCode = this.lst62ProcedureCodes.Text.Trim(),
                        HM_Code = this.lst62HMCodes.Text.Trim()
                    };

                    // Call the service method and assign the return status to variable
                    var success = this.customerService.AddFollowUpVisit(followUpVisitModel);

                    // if status of success variable is true then display a information else display the error message
                    if (success)
                    {
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

        private InvoiceModel  CreateInvoiceModel()
        {
            InvoiceModel invoiceModel = new InvoiceModel()
            {
                CustomerID = long.Parse(txt4CustomerID.Text.ToString()),
                InvNo = long.Parse(this.txt4InvNo.Text),
                InvDate = this.dtInvDate.Value,
                ProcedureCode = this.txt4ProcedureCode.Text.Trim(),
                HMCode = this.txt4HMCode.Text.Trim(),

                PaymentMethod = (PaymentMethods)cmb4PayMethod.SelectedIndex,

                CardType = (CardTypes)cmb4CardType.SelectedIndex,
                CardNo = this.txt4CardNo.Text.Trim(),
                ExpDate = dt4ExpDate.Value,
                SubTotal = long.Parse(txt4SubTotal.Text.Trim()),
                DiscountRate = long.Parse(txt4DiscRate.Text.Trim()),
                AmountPaid = long.Parse(txt4AmtPaid.Text.Trim()),
                Balance = long.Parse(txt4Balance.Text.Trim()),
                Total = long.Parse(txt4Total.Text.Trim())
            };
            return invoiceModel;
        }


        private void btn4PrintPreview_Click(object sender, EventArgs e)
        {

            // Assign the values to the model
            InvoiceModel invoiceModel = CreateInvoiceModel();


            Excel.Worksheet invoiceReport = this.customerService.FilloutInvoiceReport(invoiceModel);

            if (invoiceReport != null)
            {
                ;
                invoiceReport.PrintPreview(Type.Missing); 
                
                   /*ws.PrintOut(
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
        Type.Missing, Type.Missing, Type.Missing, Type.Missing);*/


            }

            //invoiceReport.Deactivate();
            //invoiceReport.Close(Type.Missing, Type.Missing, Type.Missing);
            this.customerService.CloseExcel();
        
        }

        private void btn4Print_Click(object sender, EventArgs e)
        {
            // Assign the values to the model
            InvoiceModel invoiceModel = CreateInvoiceModel();


            Excel.Worksheet invoiceReport = this.customerService.FilloutInvoiceReport(invoiceModel);

            if (invoiceReport != null)
            {
                invoiceReport.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                                       Type.Missing,Type.Missing, Type.Missing, Type.Missing);
                /*ws.PrintOut(
     Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
     Type.Missing, Type.Missing, Type.Missing, Type.Missing);*/

            }

            //invoiceReport.Deactivate();
            //invoiceReport.Close(Type.Missing, Type.Missing, Type.Missing);
            this.customerService.CloseExcel();
        }

        /// tab page Procedure Code  Methods
        /// <summary>
        /// Initializes data grid view dtgv7ProcedureCodeList style
        /// </summary>
        private void Initilizedtgv7ProcedureCodeListStyle()
        {
            // Setting the style of the DataGridView control
            dtgv7ProcedureCodeList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dtgv7ProcedureCodeList.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dtgv7ProcedureCodeList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dtgv7ProcedureCodeList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgv7ProcedureCodeList.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dtgv7ProcedureCodeList.DefaultCellStyle.BackColor = Color.Empty;
            dtgv7ProcedureCodeList.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            dtgv7ProcedureCodeList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dtgv7ProcedureCodeList.GridColor = SystemColors.ControlDarkDark;
            dtgv7ProcedureCodeList.ColumnCount = 3;
            dtgv7ProcedureCodeList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        /*private void LoadInvoicesForDataGridView(System.Data.DataTable data)
        {
            // Data grid view column setting            
            this.dataGridView4Invoices.DataSource = data;
            this.dataGridView4Invoices.DataMember = data.TableName;
            this.dataGridView4Invoices.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }*/

        //Load all procedure codes
        private bool LoadProcedureCodes()
        {                     
            try
            {
                DataTable procedureCodes = this.customerService.LoadProcedureCodes();
                // DataTable followupVisits = this.customerService.SelectFollowupVisitById(CustomerID);
                if (procedureCodes != null)
                {
                      this.dtgv7ProcedureCodeList.RowHeadersVisible = true;

                      dtgv7ProcedureCodeList.DataSource = null;
                      dtgv7ProcedureCodeList.Rows.Clear();
                    
                    
                    dtgv7ProcedureCodeList.Columns[0].HeaderCell.Value = "Procedure Code";
                    dtgv7ProcedureCodeList.Columns[1].HeaderCell.Value = "Procedure Name";
                    dtgv7ProcedureCodeList.Columns[2].HeaderCell.Value = "Price.";

                    string procedureCode = txt7ProcedureCode.Text.Trim();   
                    int currentRowIndex = -1;

                    for (int i = 0; i < procedureCodes.Rows.Count; i++)
                    {
                        dtgv7ProcedureCodeList.Rows.Add(procedureCodes.Rows[i][0].ToString(), procedureCodes.Rows[i][1].ToString(), "$ " + procedureCodes.Rows[i][2].ToString());
                        if (i==0 ||(procedureCode != "" && procedureCode == procedureCodes.Rows[i][0].ToString()))
                        {
                            txt7ProcedureCode.Text = procedureCodes.Rows[i][0].ToString();
                            txt7ProcedureName.Text = procedureCodes.Rows[i][1].ToString();
                            txt7Price.Text = "$ " + procedureCodes.Rows[i][2].ToString();
                            currentRowIndex = i;
                        }

                    }

                    if(currentRowIndex >=0 )
                    {
                        dtgv7ProcedureCodeList.CurrentCell = dtgv7ProcedureCodeList.Rows[currentRowIndex].Cells[0];
                       // dtgv7ProcedureCodeList.Rows[0].Selected = false;
                       // dtgv7ProcedureCodeList.Rows[currentRowIndex].Selected = true;
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

        private void dtgv7ProcedureCodeList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow currentRow = dtgv7ProcedureCodeList.CurrentRow;
            txt7ProcedureCode.Text = currentRow.Cells[0].Value.ToString();
            txt7ProcedureName.Text = currentRow.Cells[1].Value.ToString();
            txt7Price.Text = currentRow.Cells[2].Value.ToString();
        }

        private void btn7Search_Click(object sender, EventArgs e)
        {
            string procedureCode = txt7ProcedureCode.Text.Trim();
            LoadProcedureCodes();
            if (procedureCode != txt7ProcedureCode.Text.Trim())
            {
                //Not find the record
                txt7ProcedureCode.Text = procedureCode;
                txt7ProcedureName.Text = "";
                txt7Price.Text = "";
                MessageBox.Show("Not find the procedure code record!");
            }
        }

        private void btn7Add_Click(object sender, EventArgs e)
        {
            // Check if the validation passes
            if (true) //this.FollowUpVisitModel())
            {
                // Assign the values to the model
                ProcedureCodeModel procedureCodeModel = new ProcedureCodeModel()
                {
                    ProcedureCode = this.txt7ProcedureCode.Text.Trim(),
                    ProcedureName = this.txt7ProcedureName.Text.Trim(),
                    Price = (long)(float.Parse(this.txt7Price.Text.Replace('$', ' ').Trim()) * 100)
                };

                // Call the service method and assign the return status to variable
                try
                {
                    var success = this.customerService.AddProcedureCode(procedureCodeModel);

                    // if status of success variable is true then display a information else display the error message
                    if (success)
                    {
                        //Update customer information
                        LoadProcedureCodes();
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
                    this.ShowErrorMessage(ex);
                }
            }
               
        }

        private void btn7Delete_Click(object sender, EventArgs e)
        {            
            string procedureCode = this.txt7ProcedureCode.Text.Trim();
            if (procedureCode == "")
                return;
            try
            {
                var flag = this.customerService.DeleteProcedureCode(procedureCode);

                if (flag)
                {
                    txt7ProcedureCode.Text = "";
                    LoadProcedureCodes();
                   
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

        private void btn7Update_Click(object sender, EventArgs e)
        {
            // Assign the values to the model
            // Check if the validation passes
            if (true) //this.FollowUpVisitModel())
            {
                // Assign the values to the model
                ProcedureCodeModel procedureCodeModel = new ProcedureCodeModel()
                {
                    ProcedureCode = this.txt7ProcedureCode.Text.Trim(),
                    ProcedureName = this.txt7ProcedureName.Text.Trim(),
                    Price = (long)(float.Parse(this.txt7Price.Text.Replace('$', ' ').Trim()) * 100)
                };




                var flag = this.customerService.UpdateProcedureCode(procedureCodeModel);

                if (flag)
                {
                        LoadHMCodes();
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


        ///tab page H/M Code Methods
        /// <summary>
        /// Initializes data grid view dtgv8HMCodeList style
        /// </summary>
        private void Initilizedtgv8HMCodeListStyle()
        {
            // Setting the style of the DataGridView control
            dtgv8HMCodeList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dtgv8HMCodeList.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dtgv8HMCodeList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dtgv8HMCodeList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgv8HMCodeList.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dtgv8HMCodeList.DefaultCellStyle.BackColor = Color.Empty;
            dtgv8HMCodeList.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            dtgv8HMCodeList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dtgv8HMCodeList.GridColor = SystemColors.ControlDarkDark;
            dtgv8HMCodeList.ColumnCount = 3;
            dtgv8HMCodeList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        //Load all H/M codes
        private bool LoadHMCodes()
        {
            try
            {
                DataTable hmCodes = this.customerService.LoadHMCodes();
                // DataTable followupVisits = this.customerService.SelectFollowupVisitById(CustomerID);
                if (hmCodes != null)
                {
                    this.dtgv8HMCodeList.RowHeadersVisible = true;

                    dtgv8HMCodeList.DataSource = null;
                    dtgv8HMCodeList.Rows.Clear();


                    dtgv8HMCodeList.Columns[0].HeaderCell.Value = "H/M Code";
                    dtgv8HMCodeList.Columns[1].HeaderCell.Value = "H/M Name";
                    dtgv8HMCodeList.Columns[2].HeaderCell.Value = "Price.";

                    string hmCode = txt8HMCode.Text.Trim();
                    int currentRowIndex = -1;

                    for (int i = 0; i < hmCodes.Rows.Count; i++)
                    {
                        dtgv8HMCodeList.Rows.Add(hmCodes.Rows[i][0].ToString(), hmCodes.Rows[i][1].ToString(), "$ " + hmCodes.Rows[i][2].ToString());
                        if (i == 0 || (hmCode != "" && hmCode == hmCodes.Rows[i][0].ToString()))
                        {
                            txt8HMCode.Text = hmCodes.Rows[i][0].ToString();
                            txt8HMName.Text = hmCodes.Rows[i][1].ToString();
                            txt8Price.Text = "$ " + hmCodes.Rows[i][2].ToString();
                            currentRowIndex = i;
                        }

                    }

                    if (currentRowIndex >= 0)
                    {
                        dtgv8HMCodeList.CurrentCell = dtgv8HMCodeList.Rows[currentRowIndex].Cells[0];
                        // dtgv8HMCodeList.Rows[0].Selected = false;
                        // dtgv8HMCodeList.Rows[currentRowIndex].Selected = true;
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
                MessageBox.Show("Load Initial H/M codes error: " + e.ToString());
            }
            return false;
        }

        private void dtgv8HMCodeList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow currentRow = dtgv8HMCodeList.CurrentRow;
            txt8HMCode.Text = currentRow.Cells[0].Value.ToString();
            txt8HMName.Text = currentRow.Cells[1].Value.ToString();
            txt8Price.Text = currentRow.Cells[2].Value.ToString();
        }


        private void btn8Search_Click(object sender, EventArgs e)
        {     
            string hmCode = txt8HMCode.Text.Trim();
            LoadHMCodes();
            if (hmCode != txt8HMCode.Text.Trim())
            {
                //Not find the record
                txt8HMCode.Text = hmCode;
                txt8HMName.Text = "";
                txt8Price.Text = "";
                MessageBox.Show("Not find the H/M code record!");
            }
        }

        private void btn8Add_Click(object sender, EventArgs e)
        {
            // Check if the validation passes
            if (true) //this.FollowUpVisitModel())
            {
                // Assign the values to the model
                HMCodeModel hmCodeModel = new HMCodeModel()
                {
                    HMCode = this.txt8HMCode.Text.Trim(),
                    HMName = this.txt8HMName.Text.Trim(),
                    Price = (long)(float.Parse(this.txt8Price.Text.Replace('$', ' ').Trim()) * 100)
                };

                // Call the service method and assign the return status to variable
                try
                {
                    var success = this.customerService.AddHMCode(hmCodeModel);

                    // if status of success variable is true then display a information else display the error message
                    if (success)
                    {
                        //Update customer information
                        LoadHMCodes();
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
                    this.ShowErrorMessage(ex);
                }
            }
        }

        private void btn8Delete_Click(object sender, EventArgs e)
        {
            string hmCodeModel = this.txt8HMCode.Text.Trim();
            if (hmCodeModel == "")
                return;
            try
            {
                var flag = this.customerService.DeleteHMCode(hmCodeModel);

                if (flag)
                {
                    txt8HMCode.Text = "";
                    LoadHMCodes();

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

        private void btn8Update_Click(object sender, EventArgs e)
        {
            // Assign the values to the model
            // Check if the validation passes
            if (true) //this.FollowUpVisitModel())
            {
                // Assign the values to the model
                HMCodeModel hmCodeModel = new HMCodeModel()
                {
                    HMCode = this.txt8HMCode.Text.Trim(),
                    HMName = this.txt8HMName.Text.Trim(),
                    Price = (long)(float.Parse(this.txt8Price.Text.Replace('$', ' ').Trim()) * 100)
                };




                var flag = this.customerService.UpdateHMCode(hmCodeModel);

                if (flag)
                {
                    LoadHMCodes();
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

        private void lbl62ProcedureCodes_Click(object sender, EventArgs e)
        {
            var procedureCodeEditor = new frmProcedureCode(this, lst62ProcedureCodes);
            //frmProcedureCodeEditor.Closing += frmProcedureCode.frmProcedureCode_Closing;
            procedureCodeEditor.Show();
            procedureCodeEditor.BringToFront();
            //this.Hide();
        }

        private void lbl62HMCodes_Click(object sender, EventArgs e)
        {
            var hmCodeEditor = new HMCodeEditor(this, lst62HMCodes);
            hmCodeEditor.Show();
            hmCodeEditor.BringToFront();

        }


    }     
}
