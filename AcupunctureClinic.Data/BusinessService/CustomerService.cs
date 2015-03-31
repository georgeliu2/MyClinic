// -----------------------------------------------------------------------
// <copyright file="CustomerService.cs" company="John">
// Acupuncture Clinic Record Management System 2015
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.BusinessService
{
    using System.Data;
    using AcupunctureClinic.Data.DataAccess;
    using AcupunctureClinic.Data.DataModel;
    using Excel = Microsoft.Office.Interop.Excel;

    /// <summary>
    /// class to query the DataAccess, implements ICusomerService interface
    /// </summary>
    public class CustomerService : ICusomerService
    {
        /// <summary>
        /// interface of CustomerAccess
        /// </summary>
        private ICustomerAccess customerAccess;

        /// <summary>
        /// Initializes a new instance of the CustomerService class
        /// </summary>
        public CustomerService()
        {
            this.customerAccess = new CustomerAccess();
        }

        /// <summary>
        /// Service method to get  customer by Id
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>Data row</returns>
        public DataRow GetCustomerById(long id)
        {
            return this.customerAccess.GetCustomerById(id);
        }

        /// <summary>
        /// Service method to get all  customers
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllCustomers()
        {            
            return this.customerAccess.GetAllCustomers();
        }

        /// <summary>
        /// Service method to search records by multiple parameters
        /// </summary>
        /// <param name="occupation">occupation value</param>
        /// <param name="maritalStatus">marital status</param>
        /// <param name="operand">AND OR operand</param>
        /// <returns>Data table</returns>
        public DataTable SearchCustomers(string id, string LName, string operand)
        {
            return this.customerAccess.SearchCustomers(id, LName, operand);
        }

        /// <summary>
        /// Service method to search records by multiple parameters
        /// </summary>
        /// <param name="CustomerID">CustomerID value</param>
        /// <returns>Data Row, Customer contact</returns>
        public DataRow SearchContactById(long customerid)
        {
            return this.customerAccess.SearchContactById(customerid);
        }

        /// <summary>
        /// Service method to create new customer
        /// </summary>
        /// <param name="customer"> customer model</param>
        /// <returns>true or false</returns>
        public bool RegisterCustomer(CustomerModel customer)
        {
            return this.customerAccess.AddCustomer(customer);
        }

        /// <summary>
        /// Service method to update  customer
        /// </summary>
        /// <param name="customer"> customer</param>
        /// <returns>true / false</returns>
        public bool UpdateCustomer(CustomerModel customer)
        {
            return this.customerAccess.UpdateCustomer(customer);
        }

        /// <summary>
        /// Method to delete a  customer
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>true / false</returns>
        public bool DeleteCustomer(long id)
        {
            return this.customerAccess.DeleteCustomer(id);
        }

        /// <summary>
        /// Method to update customer contact details
        /// </summary>
        /// <param name="Contact">contact</param>
        /// <returns></returns>
        public bool UpdateContact(ContactModel contact)
        {
            return this.customerAccess.UpdateContact(contact);
        }

        /// <summary>
        /// Method to delete customer contact details
        /// </summary>
        /// <param name="Contact">contact</param>
        /// <returns></returns>
        public bool DeleteContact(ContactModel contact)
        {
            return this.customerAccess.DeleteContact(contact.CustomerID);
        }

        /// <summary>
        /// Method to insert customer contact details
        /// </summary>
        /// <param name="Contact">contact</param>
        /// <returns></returns>
        public bool InsertContact(ContactModel contact)
        {
            return this.customerAccess.InsertContact(contact);
        }

        /// <summary>
        /// Service method to select records by multiple parameters
        /// </summary>
        /// <param name="CustomerID">CustomerID value</param>
        /// <returns>A DataRow of the Contact table</returns>
        public DataRow SelectAccountById(long customerId)
        {
            return this.customerAccess.SelectAccountById(customerId);
        }

        /// <summary>
        /// Service method to get invoices records by multiple parameters
        /// </summary>
        /// <param name="CustomerID">CustomerID value</param>
        /// <returns>A DataTable of the Invoice table</returns>
        public DataTable GetInvoicesByCustomerID(long customerId)
        {
            return this.customerAccess.GetInvoicesById(customerId);
        }

        /// <summary>
        /// Method to add invoice to the database
        /// </summary>
        /// <param name="invoiceModel">invoiceModel</param>
        /// <returns></returns>
        public bool AddInvoice(InvoiceModel invoiceModel)
        {
            return this.customerAccess.AddInvoice(invoiceModel);
        }

        /// <summary>
        /// Method to update invoice to the database
        /// </summary>
        /// <param name="invoiceModel">invoiceModel</param>
        /// <returns></returns>
        public bool UpdateInvoice(InvoiceModel invoiceModel)
        {
            return this.customerAccess.UpdateInvoice(invoiceModel);
        }

        /// <summary>
        /// Method to delete invoice details
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        public bool DeleteInvoice(long invNo)
        {
            return this.customerAccess.DeleteInvoice(invNo);
        }

        /// <summary>
        /// Method select HealthInfor by customer id
        /// </summary>
        /// <param name="CustomerID">CustomerID</param>
        /// <returns></returns>
        public DataRow SelectHealthInforById(long customerId)
        {
            return this.customerAccess.SelectHealthInforById(customerId);
        }


        /// <summary>
        /// Method add HealthInfor to database
        /// </summary>
        /// <param name="HealthInforModel">HealthInforModel</param>
        /// <returns></returns>
        public bool AddHealthInfor(HealthInforModel healthInforModel)
        {
            return this.customerAccess.AddHealthInfor(healthInforModel);
        }

        /// <summary>
        /// Method update HealthInfor to database
        /// </summary>
        /// <param name="HealthInforModel">HealthInforModel</param>
        /// <returns></returns>
        public bool UpdateHealthInfor(HealthInforModel healthInforModel)
        {
            return this.customerAccess.UpdateHealthInfor(healthInforModel);
        }

        /// <summary>
        /// Method Select Initial Visiting record from database
        /// </summary>
        /// <param name="CustomerID">CustomerID</param>
        /// <returns></returns>
        public DataTable SelectInitVisitById(long customerId)
        {
            return this.customerAccess.SelectInitVisitById(customerId);
        }

        /// <summary>
        /// Method Select Follow Up Visiting record from database
        /// </summary>
        /// <param name="CustomerID">customerID</param>
        /// <returns></returns>
        public DataTable SelectFollowupVisitById(long customerId)
        {
            return this.customerAccess.SelectFollowupVisitById(customerId);
        }

        /// <summary>
        /// Method Select Initial Visiting record from database
        /// </summary>
        /// <param name="CustomerID">CustomerID</param>
        /// <param name="initNo">initNo</param>
        /// <returns>DataRow</returns>
        public DataRow SelectInitVisitByInitNo(long customerID, int initNo)
        {
            return this.customerAccess.SelectInitVisitByInitNo(customerID, initNo);
        }

        /// <summary>
        /// Method Select Follow up Visiting record from database
        /// </summary>
        /// <param name="CustomerID">CustomerID</param>
        /// <param name="initNo">initNo</param>
        /// <returns>DataRow</returns>
        public DataRow SelectFollowUpVisitByInitNo(long customerID, int initNo, int followupNo)
        {
            return this.customerAccess.SelectFollowUpVisitByInitNo(customerID, initNo, followupNo);
        }

        /// <summary>
        /// Method AddInitVisit to database
        /// </summary>
        /// <param name="InitVisitModel">initVisitModel</param>
        /// <returns>bool</returns>
        public bool AddInitVisit(InitVisitModel initVisitModel)
        {
            return this.customerAccess.AddInitVisit(initVisitModel);
        }

        /// <summary>
        /// Method AddInitVisit to database
        /// </summary>
        /// <param name="InitVisitModel">initVisitModel</param>
        /// <returns>bool</returns>
        public bool UpdateInitVisit(InitVisitModel initVisitModel)
        {
            return this.customerAccess.UpdateInitVisit(initVisitModel);
        }

        /// <summary>
        /// Method Add FollowUpVisit to database
        /// </summary>
        /// <param name="FollowUpVisitModel">followUpVisittModel</param>
        /// <returns>bool</returns>
        public bool AddFollowUpVisit(FollowUpVisitModel followUpVisittModel)
        {
            return this.customerAccess.AddFollowUpVisit(followUpVisittModel);
        }

        /// <summary>
        /// Method Update FollowUpVisit to database
        /// </summary>
        /// <param name="FollowUpVisitModel">followUpVisittModel</param>
        /// <returns>bool</returns>
        public bool UpdateFollowUpVisit(FollowUpVisitModel followUpVisittModel)
        {
            return this.customerAccess.UpdateFollowUpVisit(followUpVisittModel);
        }

        /// <summary>
        /// Method FilloutInvoiceReport
        /// </summary>
        /// <param name="InvoiceModel">invoiceModel</param>
        /// <returns>bool</returns>
        public Excel.Worksheet FilloutInvoiceReport(InvoiceModel invoiceModel)
        {
            return this.customerAccess.FilloutInvoiceReport(invoiceModel);
        }

        /// <summary>
        /// Close connecting to Excel
        /// </summary>
        /// <returns>void</returns>
        public void CloseExcel()
        {
            this.customerAccess.CloseExcel();
        }

        ///Procedure Code Methods
        /// <summary>
        /// LoadProcedureCodes
        /// </summary>
        /// <returns>void</returns>
        public DataTable LoadProcedureCodes()
        {
            return this.customerAccess.LoadProcedureCodes();
        }

        /// <summary>
        /// AddProcedureCode
        /// </summary>
        /// <returns>DataCodeModel</returns>
        public bool AddProcedureCode(DataCodeModel procedureCodeModel)
        {
            return this.customerAccess.AddProcedureCode(procedureCodeModel);
        }

        /// <summary>
        /// DeleteProcedureCode
        /// </summary>
        /// <returns>procedureCode</returns>
        public bool DeleteProcedureCode(string procedureCode)
        {
            return this.customerAccess.DeleteProcedureCode(procedureCode);
        }


        /// <summary>
        /// UpdateProcedureCode
        /// </summary>
        /// <returns>DataCodeModel</returns>
        public bool UpdateProcedureCode(DataCodeModel procedureCodeModel)
        {
            return this.customerAccess.UpdateProcedureCode(procedureCodeModel);
        }


        ///H/M Code Methods
        /// <summary>
        /// LoadHMCodes
        /// </summary>
        /// <returns>void</returns>
        public DataTable LoadHMCodes()
        {
            return this.customerAccess.LoadHMCodes();
        }

        /// <summary>
        /// AddHMCode
        /// </summary>
        /// <returns>DataCodeModel</returns>
        public bool AddHMCode(DataCodeModel hmCodeModel)
        {
            return this.customerAccess.AddHMCode(hmCodeModel);
        }

        /// <summary>
        /// DeleteHMCode
        /// </summary>
        /// <returns>hmCode</returns>
        public bool DeleteHMCode(string hmCode)
        {
            return this.customerAccess.DeleteHMCode(hmCode);
        }


        /// <summary>
        /// UpdateHMCode
        /// </summary>
        /// <returns>DataCodeModel</returns>
        public bool UpdateHMCode(DataCodeModel hmCodeModel)
        {
            return this.customerAccess.UpdateHMCode(hmCodeModel);
        }

        /// <summary>
        /// CreateInitialNo
        /// </summary>
        /// <returns>initial No.</returns>
        public int CreateInitialNo(long customerID)
        {
            return this.customerAccess.CreateInitialNo(customerID)+1;
        }

        /// <summary>
        /// CreateFollowupNo
        /// </summary>
        /// <returns>follow up No.</returns>
        public int CreateFollowupNo(long customerID, int initNo)
        {
            return this.customerAccess.CreateFollowupNo(customerID, initNo )+1;
        }


        /// Diagnostics Code Methds
        /// <summary>
        /// LoadDiagCodes
        /// </summary>
        /// <returns>void</returns>
        public DataTable LoadDiagCodes()
        {
            return this.customerAccess.LoadDiagCodes();
        }

        /// <summary>
        /// AddDiagCode
        /// </summary>
        /// <returns>true or false</returns>
        public bool AddDiagCode(DataCodeModel diagCodeModel)
        {
            return this.customerAccess.AddDiagCode(diagCodeModel);
        }

        /// <summary>
        /// DeleteDiagCode
        /// </summary>
        /// <returns>true or false</returns>
        public bool DeleteDiagCode(string diagCode)
        {
            return this.customerAccess.DeleteDiagCode(diagCode);
        }

        /// <summary>
        /// UpdateDiagCode
        /// </summary>
        /// <returns>bool</returns>
        public bool UpdateDiagCode(DataCodeModel diagCodeModel)
        {
            return this.customerAccess.UpdateDiagCode(diagCodeModel);
        }
    }
}
