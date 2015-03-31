// -----------------------------------------------------------------------
// <copyright file="ICustomerAccess.cs" company="John">
// Acupuncture Clinic Record Management System 2015
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.DataAccess
{
    using System.Data;
    using AcupunctureClinic.Data.DataModel;
    using Excel = Microsoft.Office.Interop.Excel;

    /// <summary>
    /// Interface ICustomerAccess
    /// </summary>
    public interface ICustomerAccess
    {
        /// <summary>
        /// Method to get all  customers
        /// </summary>
        /// <returns>Data table</returns>
        DataRow GetCustomerById(long Id);

        /// <summary>
        /// Method to get all  customers
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllCustomers();

        /// <summary>
        /// Method to search customers by multiple parameters
        /// </summary>
        /// <param name="customer id">customer id value</param>
        /// <param name="last name">lname</param>
        /// <param name="operand">AND OR operand</param>
        /// <returns>Data table</returns>
        DataTable SearchCustomers(string id, string lname, string operand);

        /// <summary>
        /// Method to search customer contact by id
        /// </summary>
        /// <param name="CustomerID">id value</param>
        /// <returns>Data Row</returns>
        DataRow SearchContactById(long id);


        /// <summary>
        /// Method to create new customer
        /// </summary>
        /// <param name="customer"> customer model</param>
        /// <returns>true or false</returns>
        bool AddCustomer(CustomerModel customer);

        /// <summary>
        /// Method to update  customer details
        /// </summary>
        /// <param name="customer"> customer</param>
        /// <returns></returns>
        bool UpdateCustomer(CustomerModel customer);

        /// <summary>
        /// Method to delete a  customer
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>true / false</returns>
        bool DeleteCustomer(long id);

        /// <summary>
        /// Method to update contact details
        /// </summary>
        /// <param name="ContactModel">contact</param>
        /// <returns></returns>
        bool UpdateContact(ContactModel contact);

        /// <summary>
        /// Method to delete customer contact details
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns></returns>
        bool DeleteContact(long id);

        /// <summary>
        /// Method to insert customer contact details
        /// </summary>
        /// <param name="contact">contact</param>
        /// <returns></returns>
        bool InsertContact(ContactModel contact);

        /// <summary>
        /// Method to select account  by id
        /// </summary>
        /// <param name="CustomerID">id value</param>
        /// <returns>Data Row</returns>
        DataRow SelectAccountById(long id);

        /// <summary>
        /// Method to get invoice records  by id
        /// </summary>
        /// <param name="CustomerID">id value</param>
        /// <returns>Data Table</returns>
        DataTable GetInvoicesById(long id);

        /// <summary>
        /// Method to insert invoice details
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        bool AddInvoice(InvoiceModel invoice);

        /// <summary>
        /// Method to update invoice details
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        bool UpdateInvoice(InvoiceModel invoiceModel);

        /// <summary>
        /// Method to delete invoice details
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        bool DeleteInvoice(long invNo);

        /// <summary>
        /// Method select HealthInfor by customer id
        /// </summary>
        /// <param name="CustomerID">CustomerID</param>
        /// <returns></returns>
        DataRow SelectHealthInforById(long customerId);

        /// <summary>
        /// Method select HealthInfor by customer id
        /// </summary>
        /// <param name="HealthInforModel">HealthInforModel</param>
        /// <returns></returns>
        bool AddHealthInfor(HealthInforModel healthInforModel);

        /// <summary>
        /// Method update HealthInfor to database
        /// </summary>
        /// <param name="HealthInforModel">HealthInforModel</param>
        /// <returns></returns>
        bool UpdateHealthInfor(HealthInforModel healthInforModel);

        /// <summary>
        /// Method Select Initial Visiting record from database
        /// </summary>
        /// <param name="CustomerID">CustomerID</param>
        /// <returns></returns>
        DataTable SelectInitVisitById(long CustomerID);

        /// <summary>
        /// Method Select Follow Up Visiting record from database
        /// </summary>
        /// <param name="CustomerID">customerID</param>
        /// <returns></returns>
        DataTable SelectFollowupVisitById(long customerID);

        /// <summary>
        /// Method Select Initial Visiting record from database
        /// </summary>
        /// <param name="CustomerID">CustomerID</param>
        /// <param name="initNo">initNo</param>
        /// <returns>DataRow</returns>
        DataRow SelectInitVisitByInitNo(long customerID, int initNo);

        /// <summary>
        /// Method Select Follow up Visiting record from database
        /// </summary>
        /// <param name="CustomerID">CustomerID</param>
        /// <param name="initNo">initNo</param>
        /// <returns>DataRow</returns>
        DataRow SelectFollowUpVisitByInitNo(long customerID, int initNo, int followupNo);

        /// <summary>
        /// Method AddInitVisit to database
        /// </summary>
        /// <param name="InitVisitModel">initVisitModel</param>
        /// <returns>bool</returns>
        bool AddInitVisit(InitVisitModel initVisitModel);

        /// <summary>
        /// Method UpdateInitVisit to database
        /// </summary>
        /// <param name="InitVisitModel">initVisitModel</param>
        /// <returns>bool</returns>
        bool UpdateInitVisit(InitVisitModel initVisitModel);

        /// <summary>
        /// Method Add FollowUpVisit to database
        /// </summary>
        /// <param name="FollowUpVisitModel">followUpVisittModel</param>
        /// <returns>bool</returns>
        bool AddFollowUpVisit(FollowUpVisitModel followUpVisittModel);

        /// <summary>
        /// Method Update FollowUpVisit to database
        /// </summary>
        /// <param name="FollowUpVisitModel">followUpVisittModel</param>
        /// <returns>bool</returns>
        bool UpdateFollowUpVisit(FollowUpVisitModel followUpVisittModel);

        /// <summary>
        /// Method FilloutInvoiceReport
        /// </summary>
        /// <param name="InvoiceModel">invoiceModel</param>
        /// <returns>bool</returns>
        Excel.Worksheet FilloutInvoiceReport(InvoiceModel invoiceModel);

        /// <summary>
        /// Close connecting to Excel
        /// </summary>
        /// <returns>void</returns>
        void CloseExcel();

        ///Procedure Code Methods
        /// <summary>
        /// LoadProcedureCodes
        /// </summary>
        /// <returns>void</returns>
        DataTable LoadProcedureCodes();

        /// <summary>
        /// AddProcedureCode
        /// </summary>
        /// <returns>DataCodeModel</returns>
        bool AddProcedureCode(DataCodeModel procedureCodeModel);

        /// <summary>
        /// DeleteProcedureCode
        /// </summary>
        /// <returns>procedureCode</returns>
        bool DeleteProcedureCode(string procedureCode);

        /// <summary>
        /// UpdateProcedureCode
        /// </summary>
        /// <returns>DataCodeModel</returns>
        bool UpdateProcedureCode(DataCodeModel procedureCodeModel);

        ///H/M Code Methods
        /// <summary>
        /// LoadHMCodes
        /// </summary>
        /// <returns>void</returns>
        DataTable LoadHMCodes();

        /// <summary>
        /// AddHMCode
        /// </summary>
        /// <returns>DataCodeModel</returns>
        bool AddHMCode(DataCodeModel hmCodeModel);

        /// <summary>
        /// DeleteHMCode
        /// </summary>
        /// <returns>hmCode</returns>
        bool DeleteHMCode(string hmCode);

        /// <summary>
        /// UpdateHMCode
        /// </summary>
        /// <returns>DataCodeModel</returns>
        bool UpdateHMCode(DataCodeModel hmCodeModel);

        /// <summary>
        /// CreateInitialNo
        /// </summary>
        /// <returns>initial No.</returns>
        int CreateInitialNo(long customerID);

        /// <summary>
        /// CreateFollowupNo
        /// </summary>
        /// <returns>follow up No No.</returns>
        int CreateFollowupNo(long customerID, int initNo);
    }              
}
