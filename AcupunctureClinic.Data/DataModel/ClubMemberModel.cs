// -----------------------------------------------------------------------
// <copyright file="CustomerModel.cs" company="John">
// Socia Member club Demo ©2013
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.DataModel
{
    using System;
    using AcupunctureClinic.Data.Enum;

    /// <summary>
    /// Member model
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Gets or sets member name
        /// </summary>
        public string Fname { get; set; }

        /// <summary>
        /// Gets or sets member name
        /// </summary>
        public string Lname { get; set; }

        /// <summary>
        /// Gets or sets Sex status
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Gets or sets date of birth
        /// </summary>
        public DateTime DoB { get; set; }

        /// <summary>
        /// Gets or sets marital status
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }


        /// <summary>
        /// Gets or sets occupation
        /// </summary>
        public Occupation Occupation { get; set; }
            

        /// <summary>
        /// Gets or sets Employer
        /// </summary>
        public string Employer { get; set; }

        /// <summary>
        /// Gets or sets SSN
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// Gets or sets DLN
        /// </summary>
        public string DLN { get; set; }
    }
}
