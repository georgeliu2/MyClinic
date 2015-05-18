// -----------------------------------------------------------------------
// <copyright file="ICusomerService.cs" company="John">
// Acupuncture Clinic Record Management System 2015
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.BusinessService
{
    using System.Data;
    using AcupunctureClinic.Data.DataModel;
    using Excel = Microsoft.Office.Interop.Excel;

    /// <summary>
    /// Interface ICusomerService
    /// </summary>
    public interface ICusomerService
    {
        /// <summary>
        /// Method to get all  customers
        /// </summary>
        /// <returns>Data table</returns>
        DataRow GetCustomerById(long Id);

        /// <summary>
        /// Service method to get all  customers
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllCustomers();

        /// <summary>
        /// Service method to search records by multiple parameters
        /// </summary>
        /// <param name="customer ID">CustomerID value</param>
        /// <param name="last name">lname</param>
        /// <param name="operand">AND OR operand</param>
        /// <returns>Data table</returns>
        DataTable SearchCustomers(string customerid, string lname, string operand);

        /// <summary>
        /// Service method to create new customer
        /// </summary>
        /// <param name="Customer"> customer model</param>
        /// <returns>true or false</returns>
        bool RegisterCustomer(CustomerModel Customer);

        /// <summary>
        /// Method to update  customer details
        /// </summary>
        /// <param name="Customer"> customer</param>
        /// <returns></returns>
        bool UpdateCustomer(CustomerModel Customer);

        /// <summary>
        /// Method to delete a  customer
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>true / false</returns>
        bool DeleteCustomer(long id);

        /// <summary>
        /// Service method to search records by multiple parameters
        /// </summary>
        /// <param name="CustomerID">CustomerID value</param>
        /// <returns>A DataRow of the Contact table</returns>
        DataRow SearchContactById(long customerid);

        /// <summary>
        /// Method to update customer contact details
        /// </summary>
        /// <param name="Contact">contact</param>
        /// <returns></returns>
        bool UpdateContact(ContactModel contact);

        /// <summary>
        /// Method to delete customer contact details
        /// </summary>
        /// <param name="Contact">contact</param>
        /// <returns></returns>
        bool DeleteContact(ContactModel contact);


        /// <summary>
        /// Method to insert customer contact details
        /// </summary>
        /// <param name="Contact">contact</param>
        /// <returns></returns>
        bool InsertContact(ContactModel contact);

        /// <summary>
        /// Service method to select records by multiple parameters
        /// </summary>
        /// <param name="CustomerID">CustomerID value</param>
        /// <returns>A DataRow of the Contact table</returns>
        DataRow SelectAccountById(long customerId);



        /// <summary>
        /// Method select HealthInfor by customer id
        /// </summary>
        /// <param name="CustomerID">CustomerID</param>
        /// <returns></returns>
        DataRow SelectHealthInforById(long customerId);

        /// <summary>
        /// Method add HealthInfor to database
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
        DataTable SelectInitVisitById(long customerID);

        /// <summary>
        /// Method Select Follow Up Visiting record from database
        /// </summary>
        /// <param name="CustomerID">customerID</param>
        /// <returns></returns>
        DataTable SelectFollowupVisitById(long customerID);


        ///Initial Visit Infor Page Methods
        ///
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
        /// Method AddInitVisit to database
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

        /// Procedure Code Methds
        /// <summary>
        /// LoadProcedureCodes
        /// </summary>
        /// <returns>void</returns>
        DataTable LoadProcedureCodes();

        /// <summary>
        /// AddProcedureCode
        /// </summary>
        /// <returns>ProcedureCodeModel</returns>
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
        /// <returns>Follow up No.</returns>
        int CreateFollowupNo(long customerID, int initialNo);


        /// Diagnostics Code Methds
        /// <summary>
        /// LoadDiagCodes
        /// </summary>
        /// <returns>void</returns>
        DataTable LoadDiagCodes();    
    
        


        /// <summary>
        /// AddDiagCode
        /// </summary>
        /// <returns>true or false</returns>
        bool AddDiagCode(DataCodeModel diagCodeModel);
        
        /// <summary>
        /// DeleteDiagCode
        /// </summary>
        /// <returns>true or false</returns>
        bool DeleteDiagCode(string diagCode);
        
        /// <summary>
        /// UpdateDiagCode
        /// </summary>
        /// <returns>bool</returns>
        bool UpdateDiagCode(DataCodeModel diagCodeModel);



    }
}
