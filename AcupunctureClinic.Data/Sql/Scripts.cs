// -----------------------------------------------------------------------
// <copyright file="Scripts.cs" company="John">
// Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.Sql
{
    /// <summary>
    /// DBConstants static class contains sql string constants
    /// </summary>
    public static class Scripts
    {
        /// <summary>
        /// Sql to get a club member details by Id
        /// </summary>
        public static readonly string sqlGetCustomerById = "Select * From Customer Where CustomerID = @CustomerID";
        //    " Id, Name, DateOfBirth, Occupation, MaritalStatus, Sex, Salary, NumberOfChildren" +
        //    " From Customer Where Id = @Id";

        /// <summary>
        /// Sql to get all club members
        /// </summary>
        public static readonly string SqlGetAllCustomers = "Select * From Customer";
        //public static readonly string SqlGetAllCustomers = "Select" +
        //    " CustomerID, Fname, Lname, Sex, DoB, MaritalStatus, Occupation, Employer, SSI, ID" +
        //    " From Customer";

        /// <summary>
        /// sql to insert a club member details
        /// </summary>
        public static readonly string SqlInsertCustomer = "Insert Into" +
            " Customer(Fname, Lname, Sex, DoB, MaritalStatus, Occupation, Employer, SSN, DLN)" +
            " Values(@Fname, @Lname, @Sex, @DoB, @MaritalStatus, @Occupation, @Employer, @SSI, @DLN)";


 
        /// <summary>
        /// sql to search for club members
        /// </summary>
        public static readonly string SqlSearchCustomers = "Select " +
            " CustomerID, Fname, Lname, Sex, DoB, MaritalStatus, Occupation, Employer, SSN, DLN" +
            " From Customer Where (@CustomerID Is NULL OR @CustomerID = CustomerID) {0}" +
            " (@Lname Is NULL OR @Lname = Lname)";

        /// <summary>
        /// sql to update club member details
        /// </summary>
        public static readonly string sqlUpdateCustomer = "Update Customer " +
            " Set [Fname] = @Fname, [Lname] = @Lname,[Sex] = @Sex, [DoB] = @DoB, [MaritalStatus] = @MaritalStatus,"  +
            " [Occupation] = @Occupation, [Employer] = @Employer, " +
            "   [SSN] = @SSN,  [DLN] = @DLN Where ([CustomerID] = @CustomerID)";

        /// <summary>
        /// sql to delete a club member record
        /// </summary>
        public static readonly string sqlDeleteCustomer = "Delete From Customer Where (CustomerID = @CustomerID)";
    }
}
