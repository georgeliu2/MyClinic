// -----------------------------------------------------------------------
// <copyright file="CustomerModel.cs" company="IntellAgent">
// First prototy version 2/2015
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.DataModel
{
    using System;
    using AcupunctureClinic.Data.Enums;

    /// <summary>
    /// Customer model
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// Gets or sets customer id
        /// </summary>
        public long CustomerID { get; set; }

        /// <summary>
        /// Gets or sets customer name
        /// </summary>
        public string Fname { get; set; }

        /// <summary>
        /// Gets or sets customer name
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
