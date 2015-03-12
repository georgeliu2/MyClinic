// -----------------------------------------------------------------------
// <copyright file="MaritalStatus.cs" company="John">
// Acupuncture Clinic Record Management System 2015
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// Enumerator for Marital status
    /// </summary>
    public enum MaritalStatus
    {
        /// <summary>
        /// MaritalStatus - Married
        /// </summary>
        [Description("Married")]
        Married = 0,

        /// <summary>
        /// MaritalStatus - Single
        /// </summary>
        [Description("Single")]
        Single
    }
}
