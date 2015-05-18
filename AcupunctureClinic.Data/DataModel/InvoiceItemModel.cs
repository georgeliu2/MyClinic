using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AcupunctureClinic.Data.DataModel
{
    public class InvoiceItemModel : IEquatable<InvoiceItemModel>
    {
        /// <summary>
        /// Gets or sets Invoice No
        /// </summary>
        public long InvNo { get; set; }

        /// <summary>
        /// Gets or sets procedure code
        /// </summary>
        public string ProcedureCode { get; set; }

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string HMCode { get; set; }

        /// <summary>
        /// Gets or sets Price
        /// </summary>
        public long Price { get; set; }

        /// <summary>
        /// Gets or sets DiscountRate
        /// </summary>
        public int DiscountRate { get; set; }

        /// <summary>
        /// Gets or sets LineTotal
        /// </summary>
        public long LineTotal { get; set; }

        /// <summary>
        /// Equals
        /// </summary>
        public bool Equals(InvoiceItemModel other)
        {
            if (other == null) return false;
                return (this.InvNo == other.InvNo && 
                        this.ProcedureCode == other.ProcedureCode &&
                        this.HMCode == other.HMCode );
        }

        public void FilloutData(DataRow row)
        {
            if (row == null)
                return;
            InvNo = long.Parse(row[0].ToString());
            ProcedureCode = row[1].ToString();
            HMCode = row[2].ToString();
            Price = long.Parse(row[3].ToString());
            DiscountRate = int.Parse(row[4].ToString());
           
            LineTotal = Convert.ToInt64(row[5]);
            return;
        }

        public long ObjToLong( Object num)
        {
            if (num == null)
                return 0;

            float fnum;
            if (num is string)
                fnum = float.Parse((string)num);
            else if (num is float)
                fnum = (float)num;
            else
                return Convert.ToInt64(num);

            return Convert.ToInt64(fnum);

        }

        public InvoiceItemModel Clone()
        {
            InvoiceItemModel other = new InvoiceItemModel
            {
                InvNo = this.InvNo,
                ProcedureCode = this.ProcedureCode,
                HMCode = this.HMCode,
                Price = this.Price,
                DiscountRate = this.DiscountRate,
                LineTotal = this.LineTotal
            };
            return other;
        }

        public void Reset()
        {
             InvNo = 0;
             ProcedureCode = "";
             HMCode = "";
             Price = 0;
             DiscountRate = 0;
             LineTotal = 0;
        }

        public bool isNone()
        {
            return InvNo == 0;
        }
    }
}
