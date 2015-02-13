// -----------------------------------------------------------------------
// <copyright file="ICusomerService.cs" company="John">
// Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.BusinessService
{
    using System.Data;
    using AcupunctureClinic.Data.DataModel;

    /// <summary>
    /// Interface ICusomerService
    /// </summary>
    public interface ICusomerService
    {
        /// <summary>
        /// Method to get all club members
        /// </summary>
        /// <returns>Data table</returns>
        DataRow GetCustomerById(int Id);

        /// <summary>
        /// Service method to get all club members
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllCustomers();

        /// <summary>
        /// Service method to search records by multiple parameters
        /// </summary>
        /// <param name="occupation">occupation value</param>
        /// <param name="maritalStatus">marital status</param>
        /// <param name="operand">AND OR operand</param>
        /// <returns>Data table</returns>
        DataTable SearchCustomers(string customerid, string lname, string operand);       

        /// <summary>
        /// Service method to create new member
        /// </summary>
        /// <param name="Customer">club member model</param>
        /// <returns>true or false</returns>
        bool RegisterCustomer(CustomerModel Customer);

        /// <summary>
        /// Method to update club member details
        /// </summary>
        /// <param name="Customer">club member</param>
        /// <returns></returns>
        bool UpdateCustomer(CustomerModel Customer);

        /// <summary>
        /// Method to delete a club member
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>true / false</returns>
        bool DeleteCustomer(int id);
    }
}
