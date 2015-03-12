using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcupunctureClinic.Data.Enums
{
    using System.ComponentModel;
    /// <summary>
    /// Enumerator for Visiting Type
    /// </summary>
    public enum VisitingType
    {
        /// <summary>
        /// VisitingType - Initial
        /// </summary>
        [Description("Initial")]
        Initial = 0,

        /// <summary>
        /// VisitingType - FollowUp
        /// </summary>
        [Description("FollowUp")]
        FollowUp = 1
    }
}
