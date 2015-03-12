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
    public class HealthInforModel
    {
        /// <summary>
        /// Gets or sets Customer id
        /// </summary>
        public long CustomerID { get; set; }

        /// <summary>
        /// Gets or sets FamilyHistory
        /// </summary>
        public string FamilyHistory { get; set; }

        /// <summary>
        /// Gets or sets Allergies
        /// </summary>
        public string Allergies { get; set; }

        /// <summary>
        /// Gets or sets Musculoskeletal
        /// </summary>
        public string Musculoskeletal { get; set; }

        /// <summary>
        /// Gets or sets Motor
        /// </summary>
        public string Motor { get; set; }

    }
}
