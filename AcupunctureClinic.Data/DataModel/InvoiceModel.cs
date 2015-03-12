using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcupunctureClinic.Data.DataModel
{
    using System;
    using AcupunctureClinic.Data.Enums;

    /// <summary>
    /// Invoice model
    /// </summary>
    public class InvoiceModel
    {
            /// <summary>
            /// Gets or sets customer id
            /// </summary>
            public long CustomerID { get; set; }

            /// <summary>
            /// Gets or sets invoice No.
            /// </summary>
            public long InvNo { get; set; }

            /// <summary>
            /// Gets or sets visiting date
            /// </summary>
            public DateTime InvDate { get; set; }

            /// <summary>
            /// Gets or sets procedure code
            /// </summary>
            public string ProcedureCode { get; set; }

            /// <summary>
            /// Gets or sets H/M code
            /// </summary>
            public string HMCode { get; set; }

            /// <summary>
            /// Gets or sets payment method
            /// </summary>
            public PaymentMethods PaymentMethod { get; set; }


            /// <summary>
            /// Gets or sets card type
            /// </summary>
            public CardTypes CardType { get; set; }

            /// <summary>
            /// Gets or sets Card No.
            /// </summary>
            public string CardNo { get; set; }

            /// <summary>
            /// Gets or sets DLN
            /// </summary>
            public DateTime ExpDate { get; set; }

            /// <summary>
            /// Gets or sets Sub Total
            /// </summary>
            public long SubTotal { get; set; }


            /// <summary>
            /// Gets or sets marital status
            /// </summary>
            public long DiscountRate { get; set; }

            /// <summary>
            /// Gets or sets amt  paid
            /// </summary>
            public long AmountPaid { get; set; }

            /// <summary>
            /// Gets or sets balance
            /// </summary>
            public long Balance { get; set; }

            /// <summary>
            /// Gets or sets Total
            /// </summary>
            public long Total { get; set; }
        }

}
