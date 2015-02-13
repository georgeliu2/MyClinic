// -----------------------------------------------------------------------
// <copyright file="ICustomerAccess.cs" company="John">
// Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.DataAccess
{
    using System.Data;
    using AcupunctureClinic.Data.DataModel;

    /// <summary>
    /// Interface ICustomerAccess
    /// </summary>
    public interface ICustomerAccess
    {
        /// <summary>
        /// Method to get all club members
        /// </summary>
        /// <returns>Data table</returns>
        DataRow GetCustomerById(int Id);

        /// <summary>
        /// Method to get all club members
        /// </summary>
        /// <returns>Data table</returns>
        DataTable GetAllCustomers();

        /// <summary>
        /// Method to search club members by multiple parameters
        /// </summary>
        /// <param name="occupation">occupation value</param>
        /// <param name="maritalStatus">marital status</param>
        /// <param name="operand">AND OR operand</param>
        /// <returns>Data table</returns>
        DataTable SearchCustomers(string id, string lname, string operand);

        /// <summary>
        /// Method to create new member
        /// </summary>
        /// <param name="customer">club member model</param>
        /// <returns>true or false</returns>
        bool AddCustomer(CustomerModel customer);

        /// <summary>
        /// Method to update club member details
        /// </summary>
        /// <param name="customer">club member</param>
        /// <returns></returns>
        bool UpdateCustomer(CustomerModel customer);

        /// <summary>
        /// Method to delete a club member
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>true / false</returns>
        bool DeleteCustomer(int id);
    }
}
