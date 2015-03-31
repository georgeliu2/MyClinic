using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcupunctureClinic.Data.DataModel
{
    /// <summary>
    /// Member model
    /// </summary>
    public class FollowUpVisitModel
    {
        /// <summary>
        /// Gets or sets Customer id
        /// </summary>
        public long CustomerID { get; set; }

        /// <summary>
        /// Gets or sets InitialNo
        /// </summary>
        public int InitialNo { get; set; }

        
        /// <summary>
        /// Gets or sets FollowUpNo
        /// </summary>
        public int FollowUpNo { get; set; }

        /// <summary>
        /// Gets or sets FollowUpDate
        /// </summary>
        public DateTime FollowUpDate { get; set; }

        /// <summary>
        /// Gets or sets Subjective
        /// </summary>
        public string Subjective { get; set; }

        /// <summary>
        /// Gets or sets Objective
        /// </summary>
        public string Objective { get; set; }

        /// <summary>
        /// Gets or sets DiagCode
        /// </summary>
        public string DiagCode { get; set; }

        /// <summary>
        /// Gets or sets ProcedureCode
        /// </summary>
        public string ProcedureCode { get; set; }

        /// <summary>
        /// Gets or sets HM_Code
        /// </summary>
        public string HM_Code { get; set; }
       
    }
}
