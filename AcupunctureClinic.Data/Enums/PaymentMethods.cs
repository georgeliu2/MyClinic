using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcupunctureClinic.Data.Enums
{
    using System.ComponentModel;
    /// <summary>
    /// Enumerator for occupation
    /// 0 -- None
    /// Cash
    /// Check
    /// Debit
    /// Credit
    /// </summary>
    public enum PaymentMethods
    {
        /// <summary>
        /// Occupation - None
        /// </summary>
        [Description("None")]
        None = 0,

        /// <summary>
        /// Occupation - Cash
        /// </summary>
        [Description("Cash")]
        Cash,

        /// <summary>
        /// Occupation - Check
        /// </summary>
        [Description("Check")]
        Check,

        /// <summary>
        /// Occupation - Debit
        /// </summary>
        [Description("Debit")]
        Debit,

        /// <summary>
        /// Occupation - Credit
        /// </summary>
        [Description("Credit")]
        Credit
    }
}
