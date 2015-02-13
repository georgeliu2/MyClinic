// -----------------------------------------------------------------------
// <copyright file="CustomerAccess.cs" company="John">
// Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.DataAccess
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using AcupunctureClinic.Data.DataModel;
    using AcupunctureClinic.Data.Sql;

    /// <summary>
    /// Data access class for Customer table
    /// </summary>
    public class CustomerAccess : ConnectionAccess, ICustomerAccess
    {
        /// <summary>
        /// Method to get all club members
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllCustomers()
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                oleDbDataAdapter.SelectCommand = new OleDbCommand();
                oleDbDataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                oleDbDataAdapter.SelectCommand.CommandText = Scripts.SqlGetAllCustomers;

                // Fill the datatable from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;            
        }

        /// <summary>
        /// Method to get club member by Id
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>Data row</returns>
        public DataRow GetCustomerById(int id)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
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
        /// Method to search club members by multiple parameters
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
                oleDbDataAdapter.SelectCommand.Connection = new OleDbConnection(this.ConnectionString);
                oleDbDataAdapter.SelectCommand.CommandType = CommandType.Text;

                // Assign the SQL to the command object
                oleDbDataAdapter.SelectCommand.CommandText = string.Format(Scripts.SqlSearchCustomers, operand);

                // Add the input parameters to the parameter collection
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", id == null || id =="" ||id == " " ? "0" : id);
                oleDbDataAdapter.SelectCommand.Parameters.AddWithValue("@Lname", lname == null || lname=="" ? " " : lname);

                // Fill the table from adapter
                oleDbDataAdapter.Fill(dataTable);
            }

            return dataTable;
        }        

        /// <summary>
        /// Method to add new member
        /// </summary>
        /// <param name="customer">club member model</param>
        /// <returns>true or false</returns>
        public bool AddCustomer(CustomerModel customer)
        {
            using (OleDbCommand oleDbCommand = new OleDbCommand())
            {
                // Set the command object properties
                oleDbCommand.Connection = new OleDbConnection(this.ConnectionString);
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
        /// Method to update club member
        /// </summary>
        /// <param name="customer">club member</param>
        /// <returns>true / false</returns>
        public bool UpdateCustomer(CustomerModel customer)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.ConnectionString);
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
        /// Method to delete a club member
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>true / false</returns>
        public bool DeleteCustomer(int id)
        {
            using (OleDbCommand dbCommand = new OleDbCommand())
            {
                // Set the command object properties
                dbCommand.Connection = new OleDbConnection(this.ConnectionString);
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
    }
}
