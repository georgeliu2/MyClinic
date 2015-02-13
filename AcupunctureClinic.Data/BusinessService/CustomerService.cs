// -----------------------------------------------------------------------
// <copyright file="CustomerService.cs" company="John">
// Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.BusinessService
{
    using System.Data;
    using AcupunctureClinic.Data.DataAccess;
    using AcupunctureClinic.Data.DataModel;

    /// <summary>
    /// class to query the DataAccess, implements ICusomerService interface
    /// </summary>
    public class CustomerService : ICusomerService
    {
        /// <summary>
        /// interface of CustomerAccess
        /// </summary>
        private ICustomerAccess memberAccess;

        /// <summary>
        /// Initializes a new instance of the CustomerService class
        /// </summary>
        public CustomerService()
        {
            this.memberAccess = new CustomerAccess();
        }

        /// <summary>
        /// Service method to get club member by Id
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>Data row</returns>
        public DataRow GetCustomerById(int id)
        {
            return this.memberAccess.GetCustomerById(id);
        }

        /// <summary>
        /// Service method to get all club members
        /// </summary>
        /// <returns>Data table</returns>
        public DataTable GetAllCustomers()
        {            
            return this.memberAccess.GetAllCustomers();
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
            return this.memberAccess.SearchCustomers(id, LName, operand);
        }        

        /// <summary>
        /// Service method to create new member
        /// </summary>
        /// <param name="customer">club member model</param>
        /// <returns>true or false</returns>
        public bool RegisterCustomer(CustomerModel customer)
        {
            return this.memberAccess.AddCustomer(customer);
        }

        /// <summary>
        /// Service method to update club member
        /// </summary>
        /// <param name="customer">club member</param>
        /// <returns>true / false</returns>
        public bool UpdateCustomer(CustomerModel customer)
        {
            return this.memberAccess.UpdateCustomer(customer);
        }

        /// <summary>
        /// Method to delete a club member
        /// </summary>
        /// <param name="id">member id</param>
        /// <returns>true / false</returns>
        public bool DeleteCustomer(int id)
        {
            return this.memberAccess.DeleteCustomer(id);
        }
    }
}
