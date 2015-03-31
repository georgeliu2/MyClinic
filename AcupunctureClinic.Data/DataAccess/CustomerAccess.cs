// -----------------------------------------------------------------------
// <copyright file="CustomerAccess.cs" company="John">
// Acupuncture Clinic Record Management System 2015
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.DataAccess
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using AcupunctureClinic.Data.DataModel;
    using AcupunctureClinic.Data.Sql;
    using Excel = Microsoft.Office.Interop.Excel;
    using AcupunctureClinic.Data.Enums;

    /// <summary>
    /// Data access class for Customer table
    /// </summary>
    public class CustomerAccess : ConnectionAccess, ICustomerAccess
    {
        public Excel.Workbook InvoiceBook { get; set; }
        public Excel.Application ExcelApp { get; set; }
        public Excel.Worksheet InvoiceSheet { get; set; }
        /// <summary>
        /// Method to get all  customers
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllCustomers()
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                oleDbDataAdapter.SelectCommand = new OleDbCommand();
                oleDbDataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                oleDbDataAdapter.SelectCommand.CommandText = Scripts.SqlGetAllCustomers;

                // Fill the datatable from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        /// <summary>
        /// Method to get  customer by Id
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>Data row</returns>
        public DataRow GetCustomerById(long id)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetCustomerById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Id", id);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow;
            }
        }

        /// <summary>
        /// Method to search  customers by multiple parameters
        /// </summary>
        /// <param name="occupation">occupation value</param>
        /// <param name="maritalStatus">marital status</param>
        /// <param name="operand">AND OR operand</param>
        /// <returns>Data table</returns>
        public DataTable SearchCustomers(string id, string lname, string operand)
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                oleDbDataAdapter.SelectCommand = new OleDbCommand();
                oleDbDataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                oleDbDataAdapter.SelectCommand.CommandText = string.Format(Scripts.SqlSearchCustomers, operand);

                // Add the input parameters to the parameter collection
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", id);
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@Lname", lname == null || lname == "" ? " " : lname);

                // Fill the table from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }


        /// <summary>
        /// Method to add new customer
        /// </summary>
        /// <param name="customer"> customer model</param>
        /// <returns>true or false</returns>
        public bool AddCustomer(CustomerModel customer)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                oleDbCommand.CommandType = CommandType.Text;
                oleDbCommand.CommandText = Scripts.SqlInsertCustomer;
                //" Customer(Fname, Lname, Sex, DoB, MaritalStatus, Occupation, Employer, SSI, ID)" +
                // Add the input parameters to the parameter collection
                oleDbCommand.Parameters.AddWithValue("@Fname", customer.Fname);
                oleDbCommand.Parameters.AddWithValue("@Lname", customer.Lname);
                oleDbCommand.Parameters.AddWithValue("@Sex", (int)customer.Sex);
                oleDbCommand.Parameters.AddWithValue("@DoB", customer.DoB.ToShortDateString());

                oleDbCommand.Parameters.AddWithValue("@MaritalStatus", (int)customer.MaritalStatus);
                oleDbCommand.Parameters.AddWithValue("@Occupation", (int)customer.Occupation);
                oleDbCommand.Parameters.AddWithValue("@Employer", customer.Employer);
                oleDbCommand.Parameters.AddWithValue("@SSN", customer.SSN);
                oleDbCommand.Parameters.AddWithValue("@DLN", customer.DLN);

                // Open the connection, execute the query and close the connection
                oleDbCommand.Connection.Open();
                var rowsAffected = oleDbCommand.ExecuteNonQuery();
                oleDbCommand.CommandText = "Select @@Identity";
                customer.CustomerID = (int)oleDbCommand.ExecuteScalar();
                oleDbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to update  customer
        /// </summary>
        /// <param name="customer"> customer</param>
        /// <returns>true / false</returns>
        public bool UpdateCustomer(CustomerModel customer)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateCustomer;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@Fname", customer.Fname);
                dbCommand.Parameters.AddWithValue("@Lname", customer.Lname);
                dbCommand.Parameters.AddWithValue("@Sex", (int)customer.Sex);
                dbCommand.Parameters.AddWithValue("@DoB", customer.DoB.ToShortDateString());

                dbCommand.Parameters.AddWithValue("@MaritalStatus", (int)customer.MaritalStatus);
                dbCommand.Parameters.AddWithValue("@Occupation", (int)customer.Occupation);
                dbCommand.Parameters.AddWithValue("@Employer", customer.Employer);
                dbCommand.Parameters.AddWithValue("@SSN", customer.SSN);
                dbCommand.Parameters.AddWithValue("@DLN", customer.DLN);
                dbCommand.Parameters.AddWithValue("@CustomerID", customer.CustomerID);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to delete a  customer
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>true / false</returns>
        public bool DeleteCustomer(long id)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlDeleteCustomer;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", id);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to search customer contact by id
        /// </summary>
        /// <param name="CustomerID">id value</param>
        /// <returns>Data Row</returns>
        public DataRow SearchContactById(long id)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetContactById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Id", id);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow;
            }
        }

        /// <summary>
        /// Method to update Contact customer
        /// </summary>
        /// <param name="Contact">contact</param>
        /// <returns>true / false</returns>
        public bool UpdateContact(ContactModel contact)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateContact;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@StreetOrApt", contact.Street);
                dbCommand.Parameters.AddWithValue("@City", contact.City);
                dbCommand.Parameters.AddWithValue("@State", (int)contact.State);
                dbCommand.Parameters.AddWithValue("@Zip", contact.Zip);
                dbCommand.Parameters.AddWithValue("@Phone", contact.Phone);
                dbCommand.Parameters.AddWithValue("@CellPhone", contact.CellPhone);
                dbCommand.Parameters.AddWithValue("@Guardian", contact.Guardian);
                dbCommand.Parameters.AddWithValue("@GuardianPhone", contact.GuardianPhone);
                dbCommand.Parameters.AddWithValue("@CustomerID", contact.CustomerID);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to delete customer contact details
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns></returns>
        public bool DeleteContact(long id)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlDeleteContact;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", id);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to insert customer contact details
        /// </summary>
        /// <param name="contact">contact</param>
        /// <returns></returns>
        public bool InsertContact(ContactModel contact)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlInsertContact;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", contact.CustomerID);
                dbCommand.Parameters.AddWithValue("@StreetOrApt", contact.Street);
                dbCommand.Parameters.AddWithValue("@City", contact.City);
                dbCommand.Parameters.AddWithValue("@State", (int)contact.State);
                dbCommand.Parameters.AddWithValue("@Zip", contact.Zip);
                dbCommand.Parameters.AddWithValue("@Phone", contact.Phone);
                dbCommand.Parameters.AddWithValue("@CellPhone", contact.CellPhone);
                dbCommand.Parameters.AddWithValue("@Guardian", contact.Guardian);
                dbCommand.Parameters.AddWithValue("@GuardianPhone", contact.GuardianPhone);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to select account  by id
        /// </summary>
        /// <param name="CustomerID">id value</param>
        /// <returns>Data Row</returns>
        public DataRow SelectAccountById(long id)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetAccountById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", id);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
                return dataRow;
            }
        }
        /*
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                oleDbDataAdapter.SelectCommand = new OleDbCommand();
                oleDbDataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                oleDbDataAdapter.SelectCommand.CommandText = string.Format(Scripts.SqlSearchCustomers, operand);

                // Add the input parameters to the parameter collection
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", id == null || id == "" || id == " " ? "0" : id);
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@Lname", lname == null || lname == "" ? " " : lname);

                // Fill the table from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }
        */

        /// <summary>
        /// Method to get invoice records  by id
        /// </summary>
        /// <param name="CustomerID">id value</param>
        /// <returns>Data Table</returns>
        public DataTable GetInvoicesById(long id)
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetInvoicesById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", id);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        /// <summary>
        /// Method to insert customer contact details
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        public bool AddInvoice(InvoiceModel invoice)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlAddInvoice;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                dbCommand.Parameters.AddWithValue("@InvDate", invoice.InvDate); //ToShortDateString()); //invoice.InvDate.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@ProcedureCode", invoice.ProcedureCode);
                dbCommand.Parameters.AddWithValue("@HMCode", invoice.HMCode);
                dbCommand.Parameters.AddWithValue("@DiscountRate", invoice.DiscountRate);
                dbCommand.Parameters.AddWithValue("@PaymentMethod", (int)invoice.PaymentMethod);
                dbCommand.Parameters.AddWithValue("@CardType", (int)invoice.CardType);
                dbCommand.Parameters.AddWithValue("@CardNo", invoice.CardNo);
                dbCommand.Parameters.AddWithValue("@ExpDate", invoice.ExpDate); //invoice.ExpDate.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
                dbCommand.Parameters.AddWithValue("@AmountPaid", invoice.AmountPaid);
                dbCommand.Parameters.AddWithValue("@Balance", invoice.Balance);
                dbCommand.Parameters.AddWithValue("@Total", invoice.Total);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.CommandText = "Select @@Identity";
                invoice.InvNo = (int)dbCommand.ExecuteScalar();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to update invoice details
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        public bool UpdateInvoice(InvoiceModel invoice)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateInvoice;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                dbCommand.Parameters.AddWithValue("@InvDate", invoice.InvDate);
                dbCommand.Parameters.AddWithValue("@ProcedureCode", invoice.ProcedureCode);
                dbCommand.Parameters.AddWithValue("@HMCode", invoice.HMCode);
                dbCommand.Parameters.AddWithValue("@DiscountRate", invoice.DiscountRate);
                dbCommand.Parameters.AddWithValue("@PaymentMethod", (int)invoice.PaymentMethod);
                dbCommand.Parameters.AddWithValue("@CardType", (int)invoice.CardType);
                dbCommand.Parameters.AddWithValue("@CardNo", invoice.CardNo);
                dbCommand.Parameters.AddWithValue("@ExpDate", invoice.ExpDate); //invoice.ExpDate.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
                dbCommand.Parameters.AddWithValue("@AmountPaid", invoice.AmountPaid);
                dbCommand.Parameters.AddWithValue("@Balance", invoice.Balance);
                dbCommand.Parameters.AddWithValue("@Total", invoice.Total);
                dbCommand.Parameters.AddWithValue("@InvNo", invoice.InvNo);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method to delete invoice details
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        public bool DeleteInvoice(long invNo)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlDeleteInvoice;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@InvNo", invNo);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method select HealthInfor by customer id
        /// </summary>
        /// <param name="CustomerID">CustomerID</param>
        /// <returns></returns>
        public DataRow SelectHealthInforById(long customerId)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlSelectHealthInforById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", customerId);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);
                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
                return dataRow;
            }
        }

        /// <summary>
        /// Method select HealthInfor by customer id
        /// </summary>
        /// <param name="HealthInforModel">HealthInforModel</param>
        /// <returns></returns>
        public bool AddHealthInfor(HealthInforModel healthInforModel)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlAddHealthInfor;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", healthInforModel.CustomerID);
                dbCommand.Parameters.AddWithValue("@Family_History", healthInforModel.FamilyHistory); //ToShortDateString()); //invoice.InvDate.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@Allergies", healthInforModel.Allergies);
                dbCommand.Parameters.AddWithValue("@Musculoskeletal", healthInforModel.Musculoskeletal);
                dbCommand.Parameters.AddWithValue("@Motor", healthInforModel.Motor);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method update HealthInfor to database
        /// </summary>
        /// <param name="HealthInforModel">HealthInforModel</param>
        /// <returns></returns>
        public bool UpdateHealthInfor(HealthInforModel healthInforModel)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateHealthInfor;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@Family_History", healthInforModel.FamilyHistory);
                dbCommand.Parameters.AddWithValue("@Allergies", healthInforModel.Allergies);
                dbCommand.Parameters.AddWithValue("@Musculoskeletal", healthInforModel.Musculoskeletal);
                dbCommand.Parameters.AddWithValue("@Motor", healthInforModel.Motor);
                dbCommand.Parameters.AddWithValue("@CustomerID", healthInforModel.CustomerID);


                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method Select Initial Visiting record from database
        /// </summary>
        /// <param name="CustomerID">CustomerID</param>
        /// <returns></returns>
        public DataTable SelectInitVisitById(long customerId)
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlSelectInitVisitById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", customerId);


                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        /// <summary>
        /// Method Select Follow Up Visiting record from database
        /// </summary>
        /// <param name="CustomerID">customerID</param>
        /// <returns></returns>
        public DataTable SelectFollowupVisitById(long customerId)
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlSelectFollowupVisitById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", customerId);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        /// <summary>
        /// Method Select Initial Visiting record from database
        /// </summary>
        /// <param name="CustomerID">CustomerID</param>
        /// <param name="initNo">initNo</param>
        /// <returns>DataRow</returns>
        public DataRow SelectInitVisitByInitNo(long customerID, int initNo)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                if (initNo == -1)
                {
                    dataAdapter.SelectCommand.CommandText = Scripts.sqlSelectInitVisitById;
                    // Add the parameter to the parameter collection
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
                }
                else
                {
                    dataAdapter.SelectCommand.CommandText = Scripts.sqlSelectInitVisitByInitNo;

                    // Add the parameter to the parameter collection
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@InitialNo", initNo);
                }

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);
                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[(dataTable.Rows.Count - 1)] : null;
                return dataRow;
            }
        }

        /// <summary>
        /// Method Select Follow up Visiting record from database
        /// </summary>
        /// <param name="CustomerID">CustomerID</param>
        /// <param name="initNo">initNo</param>
        /// <returns>DataRow</returns>
        public DataRow SelectFollowUpVisitByInitNo(long customerID, int initNo, int followupNo)
        {
            DataTable dataTable;
            DataRow dataRow;

            if (initNo == -1 && followupNo == -1)
            {
                dataTable = SelectFollowupVisitById(customerID);
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[(dataTable.Rows.Count - 1)] : null;
                return dataRow;
            }
            dataTable = new DataTable();

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;


                if (followupNo == -1)
                {
                    dataAdapter.SelectCommand.CommandText = Scripts.sqlSelectInitVisitByInitNoOnly;
                    // Add the parameter to the parameter collection
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@InitialNo", initNo);
                }
                else if (initNo == -1)
                {
                    dataAdapter.SelectCommand.CommandText = Scripts.sqlSelectInitVisitByFollowUpNoOnly;

                    // Add the parameter to the parameter collection
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@FollowUpNo", followupNo);
                }
                else
                {
                    dataAdapter.SelectCommand.CommandText = Scripts.sqlSelectFollowupVisitByInitNo;
                    // Add the parameter to the parameter collection
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@InitialNo", initNo);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@FollowUpNo", followupNo);
                }
                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[(dataTable.Rows.Count - 1)] : null;
                return dataRow;
            }
        }

        /// <summary>
        /// Method AddInitVisit to database
        /// </summary>
        /// <param name="InitVisitModel">initVisitModel</param>
        /// <returns>bool</returns>
        public bool AddInitVisit(InitVisitModel initVisitModel)
        {
            //Check if initial no is valid
            if (initVisitModel.InitialNo <= 0)
                return false;
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlAddInitVisit;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", initVisitModel.CustomerID);
                dbCommand.Parameters.AddWithValue("@InitialNo", initVisitModel.InitialNo);
                dbCommand.Parameters.AddWithValue("@InitialDate", initVisitModel.InitialDate);
                dbCommand.Parameters.AddWithValue("@Medications", initVisitModel.Medications);
                dbCommand.Parameters.AddWithValue("@ChiefComplaint", initVisitModel.ChiefComplaint);
                dbCommand.Parameters.AddWithValue("@HistoryOfPresentIllness", initVisitModel.HistoryOfPresentIllness);
                dbCommand.Parameters.AddWithValue("@BP", initVisitModel.BP);
                dbCommand.Parameters.AddWithValue("@Pulse", initVisitModel.Pulse);
                dbCommand.Parameters.AddWithValue("@Cranial", initVisitModel.Cranial);
                dbCommand.Parameters.AddWithValue("@Cerbellar", initVisitModel.Cerbellar);
                dbCommand.Parameters.AddWithValue("@DeepTendonRef", initVisitModel.DeepTendonRef);
                dbCommand.Parameters.AddWithValue("@Sensory", initVisitModel.Sensory);
                dbCommand.Parameters.AddWithValue("@Impression", initVisitModel.Impression);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method UpdateInitVisit to database
        /// </summary>
        /// <param name="InitVisitModel">initVisitModel</param>
        /// <returns>bool</returns>
        public bool UpdateInitVisit(InitVisitModel initVisitModel)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateInitVisit;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@InitialDate", initVisitModel.InitialDate);
                dbCommand.Parameters.AddWithValue("@Medications", initVisitModel.Medications);
                dbCommand.Parameters.AddWithValue("@ChiefComplaint", initVisitModel.ChiefComplaint);
                dbCommand.Parameters.AddWithValue("@HistoryOfPresentIllness", initVisitModel.HistoryOfPresentIllness);
                dbCommand.Parameters.AddWithValue("@BP", initVisitModel.BP);
                dbCommand.Parameters.AddWithValue("@Pulse", initVisitModel.Pulse);
                dbCommand.Parameters.AddWithValue("@Cranial", initVisitModel.Cranial);
                dbCommand.Parameters.AddWithValue("@Cerbellar", initVisitModel.Cerbellar);
                dbCommand.Parameters.AddWithValue("@DeepTendonRef", initVisitModel.DeepTendonRef);
                dbCommand.Parameters.AddWithValue("@Sensory", initVisitModel.Sensory);
                dbCommand.Parameters.AddWithValue("@Impression", initVisitModel.Impression);
                dbCommand.Parameters.AddWithValue("@CustomerID", initVisitModel.CustomerID);
                dbCommand.Parameters.AddWithValue("@InitialNo", initVisitModel.InitialNo);


                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method Add FollowUpVisit to database
        /// </summary>
        /// <param name="FollowUpVisitModel">followUpVisittModel</param>
        /// <returns>bool</returns>
        public bool AddFollowUpVisit(FollowUpVisitModel followUpVisittModel)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlAddFollowUpVisit;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", followUpVisittModel.CustomerID);
                dbCommand.Parameters.AddWithValue("@InitialNo", followUpVisittModel.InitialNo);
                dbCommand.Parameters.AddWithValue("@FollowUpNo", followUpVisittModel.FollowUpNo);
                dbCommand.Parameters.AddWithValue("@FollowUpDate", followUpVisittModel.FollowUpDate.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@Subjective", followUpVisittModel.Subjective);
                dbCommand.Parameters.AddWithValue("@Objective", followUpVisittModel.Objective);
                dbCommand.Parameters.AddWithValue("@DiagnosticsCode", followUpVisittModel.DiagCode);
                dbCommand.Parameters.AddWithValue("@ProcedureCode", followUpVisittModel.ProcedureCode);
                dbCommand.Parameters.AddWithValue("@HM_Code", followUpVisittModel.HM_Code);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Method Update FollowUpVisit to database
        /// </summary>
        /// <param name="FollowUpVisitModel">followUpVisittModel</param>
        /// <returns>bool</returns>
        public bool UpdateFollowUpVisit(FollowUpVisitModel followUpVisittModel)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateFollowUpVisit;

                // Add the input parameters to the parameter collection               
                dbCommand.Parameters.AddWithValue("@FollowUpDate", followUpVisittModel.FollowUpDate.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@Subjective", followUpVisittModel.Subjective);
                dbCommand.Parameters.AddWithValue("@Objective", followUpVisittModel.Objective);
                dbCommand.Parameters.AddWithValue("@DiagnosticsCode", followUpVisittModel.DiagCode);
                dbCommand.Parameters.AddWithValue("@ProcedureCode", followUpVisittModel.ProcedureCode);
                dbCommand.Parameters.AddWithValue("@HM_Code", followUpVisittModel.HM_Code);
                dbCommand.Parameters.AddWithValue("@CustomerID", followUpVisittModel.CustomerID);
                dbCommand.Parameters.AddWithValue("@InitialNo", followUpVisittModel.InitialNo);
                dbCommand.Parameters.AddWithValue("@FollowUpNo", followUpVisittModel.FollowUpNo);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        public void ClearInvoice(Excel.Worksheet invoiceSheet)
        {
            for (int i = 15; i <= 27; i++)
            {
                invoiceSheet.Cells[i, 1] = "";
                invoiceSheet.Cells[i, 2] = "";
                invoiceSheet.Cells[i, 3] = "";
                invoiceSheet.Cells[i, 7] = "";
                invoiceSheet.Cells[i, 8] = "";
                invoiceSheet.Cells[i, 9] = "";
            }
            invoiceSheet.Cells[29, 2] = "";   //Payment method
            invoiceSheet.Cells[28, 9] = "";   //Subtotal
            invoiceSheet.Cells[29, 9] = "";     //Amount paid
            invoiceSheet.Cells[30, 9] = "";     //Total
        }
        /// <summary>
        /// Method FilloutInvoiceReport. It fill out Excel Invoice report
        /// </summary>
        /// <param name="InvoiceModel">invoiceModel</param>
        /// <returns>bool</returns>
        public Excel.Worksheet FilloutInvoiceReport(InvoiceModel invoiceModel)
        {
            try
            {
                //ExcelApp = new Excel.Application();
                ExcelApp = new Excel.ApplicationClass();

                //InvoiceBook = ExcelApp.Workbooks.Open(this.ExcelConnectionString);
                InvoiceBook = ExcelApp.Workbooks.Open(this.ExcelConnectionString,
                         Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing);

                InvoiceSheet = (Excel.Worksheet)InvoiceBook.Sheets[1]; // Explicit cast is not required here

                ClearInvoice(InvoiceSheet);

                //InvoiceSheet.Activate();
                InvoiceSheet.Cells[4, 9] = invoiceModel.InvDate;
                InvoiceSheet.Cells[5, 9] = invoiceModel.InvNo;
                InvoiceSheet.Cells[6, 9] = invoiceModel.CustomerID;

                InvoiceSheet.Cells[15, 1] = invoiceModel.ProcedureCode;
                InvoiceSheet.Cells[15, 2] = invoiceModel.HMCode;
                InvoiceSheet.Cells[15, 7] = invoiceModel.SubTotal;
                InvoiceSheet.Cells[15, 8] = invoiceModel.DiscountRate / 100.0;
                InvoiceSheet.Cells[15, 9] = invoiceModel.Total;

                InvoiceSheet.Cells[29, 2] = Enum.GetName(typeof(PaymentMethods), invoiceModel.PaymentMethod);
                InvoiceSheet.Cells[28, 9] = invoiceModel.SubTotal;   //Subtotal
                InvoiceSheet.Cells[29, 9] = invoiceModel.AmountPaid;     //Amount paid
                InvoiceSheet.Cells[30, 9] = invoiceModel.Total;     //Total

                ExcelApp.Visible = true;

                //InvoiceSheet.Activate(); 


            }
            catch (Exception)
            {
                ;
            }

            return InvoiceSheet;
        }


        /// <summary>
        /// Close connecting to Excel
        /// </summary>
        /// <returns>void</returns>
        public void CloseExcel()
        {
            if (InvoiceBook != null)
                InvoiceBook.Close(false, Type.Missing, Type.Missing);
            InvoiceSheet = null;
            ExcelApp.Quit();
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process p in process)
            {
                if (!string.IsNullOrEmpty(p.ProcessName))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
            }
        }


        //Procedure Code Mathods
        /// <summary>
        /// LoadProcedureCodes
        /// </summary>
        /// <returns>void</returns>
        public DataTable LoadProcedureCodes()
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;

                dataAdapter.SelectCommand.CommandText = Scripts.sqlLoadProcedureCodes;


                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }

        /// <summary>
        /// AddProcedureCode
        /// </summary>
        /// <returns>DataCodeModel</returns>
        public bool AddProcedureCode(DataCodeModel procedureCodeModel)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlAddProcedureCode;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@ProcedureCode", procedureCodeModel.DataCode);
                dbCommand.Parameters.AddWithValue("@ProcedureName", procedureCodeModel.DataName);
                dbCommand.Parameters.AddWithValue("@Price", procedureCodeModel.DataPrice / 100.00);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// DeleteProcedureCode
        /// </summary>
        /// <returns>procedureCode</returns>
        public bool DeleteProcedureCode(string procedureCode)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlDeleteProcedureCode;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@ProcedureCode", procedureCode);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// UpdateProcedureCode
        /// </summary>
        /// <returns>DataCodeModel</returns>
        public bool UpdateProcedureCode(DataCodeModel procedureCodeModel)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateProcedureCode;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@ProcedureName", procedureCodeModel.DataName);
                dbCommand.Parameters.AddWithValue("@Price", procedureCodeModel.DataPrice / 100.00);
                dbCommand.Parameters.AddWithValue("@ProcedureCode", procedureCodeModel.DataCode);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }


        //H/M Code Mathods
        /// <summary>
        /// LoadHMCodes
        /// </summary>
        /// <returns>void</returns>
        public DataTable LoadHMCodes()
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;

                dataAdapter.SelectCommand.CommandText = Scripts.sqlLoadHMCodes;


                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }

        /// <summary>
        /// AddHMCode
        /// </summary>
        /// <returns>DataCodeModel</returns>
        public bool AddHMCode(DataCodeModel hmCodeModel)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlAddHMCode;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@HMCode", hmCodeModel.DataCode);
                dbCommand.Parameters.AddWithValue("@HMName", hmCodeModel.DataName);
                dbCommand.Parameters.AddWithValue("@Price", hmCodeModel.DataPrice / 100.00);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// DeleteHMCode
        /// </summary>
        /// <returns>hmCode</returns>
        public bool DeleteHMCode(string hmCode)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlDeleteHMCode;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@HMCode", hmCode);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// UpdateHMCode
        /// </summary>
        /// <returns>DataCodeModel</returns>
        public bool UpdateHMCode(DataCodeModel hmCodeModel)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateHMCode;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@HMName", hmCodeModel.DataName);
                dbCommand.Parameters.AddWithValue("@Price", hmCodeModel.DataPrice / 100.00);
                dbCommand.Parameters.AddWithValue("@HMCode", hmCodeModel.DataCode);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// CreateInitialNo
        /// </summary>
        /// <returns>initial No.</returns>
        public int CreateInitialNo(long customerID)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlCreateInitialNoByID;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow ==null? 0: int.Parse(dataRow[0].ToString());
            }
        }

        /// <summary>
        /// CreateFollowupNo
        /// </summary>
        /// <returns>follow up No No.</returns>
        public int CreateFollowupNo(long customerID, int initNo)       
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlCreateFollowupNoByID;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", customerID);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@InitialNo", initNo);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;

                return dataRow==null? 0 : (dataRow[0] == null? 0 : (dataRow[0].ToString() == "" ? 0 
                        :int.Parse(dataRow[0].ToString())));
            }
        }

        /// Diagnostics Code Methds
        /// <summary>
        /// LoadDiagCodes
        /// </summary>
        /// <returns>void</returns>
        public DataTable LoadDiagCodes()
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;

                dataAdapter.SelectCommand.CommandText = Scripts.sqlLoadDiagCodes;


                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }

        /// <summary>
        /// AddDiagCode
        /// </summary>
        /// <returns>true or false</returns>
        public bool AddDiagCode(DataCodeModel diagCodeModel)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlAddDiagCode;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@DiagnosticsCode", diagCodeModel.DataCode);
                dbCommand.Parameters.AddWithValue("@DiagnosticsCodeName", diagCodeModel.DataName);
                dbCommand.Parameters.AddWithValue("@Price", diagCodeModel.DataPrice / 100.00);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// DeleteDiagCode
        /// </summary>
        /// <returns>true or false</returns>
        public bool DeleteDiagCode(string diagCode)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlDeleteDiagCode;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@DiagnosticsCode", diagCode);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// UpdateDiagCode
        /// </summary>
        /// <returns>bool</returns>
        public bool UpdateDiagCode(DataCodeModel diagCodeModel)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateDiagCode;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@DiagnosticsCodeName", diagCodeModel.DataName);
                dbCommand.Parameters.AddWithValue("@Price", diagCodeModel.DataPrice / 100.00);
                dbCommand.Parameters.AddWithValue("@DiagnosticsCode", diagCodeModel.DataCode);

                // Open the connection, execute the query and close the connection
                dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.Connection.Close();
                return rowsAffected > 0;
            }
        }
    }
}
