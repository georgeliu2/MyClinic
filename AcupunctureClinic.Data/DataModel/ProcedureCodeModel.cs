using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcupunctureClinic.Data.DataModel
{
    using System;

    /// <summary>
    /// Member model
    /// </summary>
    public class ProcedureCodeModel
    {
        /// <summary>
        /// Gets or sets Procedure Code
        /// </summary>
        public string ProcedureCode { get; set; }

        /// <summary>
        /// Gets or sets Procedure Name
        /// </summary>
        public string ProcedureName { get; set; }

        /// <summary>
        /// Gets or sets Price
        /// </summary>
        public long Price { get; set; }
     
    }

}
