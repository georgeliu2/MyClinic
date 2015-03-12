// -----------------------------------------------------------------------
// <copyright file="Occupation.cs" company="John">
// Acupuncture Clinic Record Management System 2015
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// Enumerator for occupation
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Occupation - None
        /// </summary>
        [Description("None")]
        None = 0,

        /// <summary>
        /// Occupation - Doctor
        /// </summary>
        [Description("TX")]
        TX,

        /// <summary>
        /// Occupation - Engineer
        /// </summary>
        [Description("MA")]
        MA,

        /// <summary>
        /// Occupation - Professor
        /// </summary>
        [Description("WA")]
        WA,

        /// <summary>
        /// Occupation - Cat
        /// </summary>
        [Description("CA")]
        CA
    }
}
