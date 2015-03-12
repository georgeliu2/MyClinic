// -----------------------------------------------------------------------
// <copyright file="Sex.cs" company="John">
// Acupuncture Clinic Record Management System 2015
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// Enumerator for Sex status
    /// </summary>
    public enum Sex
    {
        /// <summary>
        /// Sex - Female
        /// </summary>
        [Description("Female")]
        Female = 0,

        /// <summary>
        /// Sex - Male
        /// </summary>
        [Description("Male")]
        Male
    }
}
