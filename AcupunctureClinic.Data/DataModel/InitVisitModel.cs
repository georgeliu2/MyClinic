using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcupunctureClinic.Data.DataModel
{

    /// <summary>
    /// Member model
    /// </summary>
    public class InitVisitModel
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
        /// Gets or sets InitialDate
        /// </summary>
        public DateTime InitialDate { get; set; }

        /// <summary>
        /// Gets or sets Medications
        /// </summary>
        public string Medications { get; set; }

        /// <summary>
        /// Gets or sets ChiefComplaint
        /// </summary>
        public string ChiefComplaint { get; set; }

        /// <summary>
        /// Gets or sets HistoryOfPresentIllness
        /// </summary>
        public string HistoryOfPresentIllness { get; set; }

        /// <summary>
        /// Gets or sets BP
        /// </summary>
        public string BP { get; set; }

        /// <summary>
        /// Gets or sets Pulse
        /// </summary>
        public string Pulse { get; set; }

        /// <summary>
        /// Gets or sets Cranial
        /// </summary>
        public string Cranial { get; set; }


        /// <summary>
        /// Gets or sets Cerbellar
        /// </summary>
        public string Cerbellar { get; set; }

        /// <summary>
        /// Gets or sets DeepTendonRef
        /// </summary>
        public string DeepTendonRef { get; set; }

        /// <summary>
        /// Gets or sets Sensory
        /// </summary>
        public string Sensory { get; set; }

        /// <summary>
        /// Gets or sets Impression
        /// </summary>
        public string Impression { get; set; }
    }
}
