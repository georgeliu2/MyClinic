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
    public class ContactModel
    {
        /// <summary>
        /// Gets or sets Customer id
        /// </summary>
        public long CustomerID { get; set; }

        /// <summary>
        /// Gets or sets Street or Appartment
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets State
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// Gets or sets ZIP
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets Phone
        /// </summary>
        public string Phone { get; set; }


        /// <summary>
        /// Gets or sets CellPhone
        /// </summary>
        public string CellPhone { get; set; }


        /// <summary>
        /// Gets or sets Guardian
        /// </summary>
        public string Guardian { get; set; }

        /// <summary>
        /// Gets or sets GuardianPhone
        /// </summary>
        public string GuardianPhone { get; set; }

    }
    
}
