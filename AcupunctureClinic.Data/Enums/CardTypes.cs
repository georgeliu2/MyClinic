using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcupunctureClinic.Data.Enums
{
        using System.ComponentModel;
        /// <summary>
        /// Enumerator for occupation
        /// </summary>
        public enum CardTypes
        {
            /// <summary>
            /// Occupation - None
            /// </summary>
            [Description("None")]
            None = 0,

            /// <summary>
            /// Master
            /// </summary>
            [Description("Master")]
            Master,

            /// <summary>
            /// Visa
            /// </summary>
            [Description("Visa")]
            Visa,

            /// <summary>
            /// Discover
            /// </summary>
            [Description("Discover")]
            Discover,

            /// <summary>
            /// AmExpr
            /// </summary>
            [Description("AmExpr")]
            AmExpr
        }
}
