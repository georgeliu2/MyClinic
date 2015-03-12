using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcupunctureClinic.Data.DataModel
{
    using System;
    using AcupunctureClinic.Data.Enums;

    /// <summary>
    /// Member model
    /// </summary>
    public class AccountModel
    {
        /// <summary>
        /// Gets or sets customer id
        /// </summary>
        public long CustomerID { get; set; }

        /// <summary>
        /// Gets or sets invoice No.
        /// </summary>
        public string InvNo { get; set; }

        /// <summary>
        /// Gets or sets last visiting date
        /// </summary>
        public DateTime LastVisitDate { get; set; }

        /// <summary>
        /// Gets or sets balance
        /// </summary>
        public long Balance { get; set; }
    };


}
