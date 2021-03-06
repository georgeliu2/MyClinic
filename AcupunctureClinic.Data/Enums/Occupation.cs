﻿// -----------------------------------------------------------------------
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
    public enum Occupation
    {
        /// <summary>
        /// Occupation - None
        /// </summary>
        [Description("None")]
        None = 0,

        /// <summary>
        /// Occupation - Doctor
        /// </summary>
        [Description("Doctor")]
        Doctor,

        /// <summary>
        /// Occupation - Engineer
        /// </summary>
        [Description("Engineer")]
        Engineer,

        /// <summary>
        /// Occupation - Professor
        /// </summary>
        [Description("Professor")]
        Professor,

        /// <summary>
        /// Occupation - Cat
        /// </summary>
        [Description("Cat")]
        Cat
    }
}
