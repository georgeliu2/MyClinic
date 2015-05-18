using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using AcupunctureClinic.Data.Sql;

namespace AcupunctureClinic.Data.DataModel
{
    using AcupunctureClinic.Data.Enums;
    using AcupunctureClinic.Data.DataAccess;

    /// <summary>
    /// Invoice model
    /// </summary>
    public class InvoiceModel
    {
        InvoiceItemModel currentItem;
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
            /// Gets or sets amt  paid
            /// </summary>
            public long AmountPaid { get; set; }


            /// <summary>
            /// Gets or sets Total
            /// </summary>
            public long Total { get; set; }

            /// <summary>
            /// Gets or sets SelfModified
            /// </summary>
            public bool SelfModified { get; set; }

            /// <summary>
            /// Gets or sets ItemsModified
            /// </summary>
            public bool ItemsModified { get; set; }

            public InvoiceItemModel CurrentItem
            {
                get { return currentItem; }
                set { currentItem = value; }
            }
           
            /// <summary>
            /// Gets or sets invoice items
            /// </summary> 
            public List<InvoiceItemModel> InvoiceItems { get; set; }


            /// <summary>
            ///Constructor
            /// </summary>
            public InvoiceModel()
            {
                InvoiceItems = new List<InvoiceItemModel>();
                Reset();
            }


            public void Reset()
            {
                CustomerID = 0;
                InvNo = 0;
                InvDate = DateTime.Today;
                PaymentMethod = (PaymentMethods)0;
                CardType = (CardTypes)0;
                CardNo = "";
                ExpDate = DateTime.Today;
                SubTotal = 0;
                AmountPaid = 0;
                Total = 0;
                InvoiceItems.Clear();
                SelfModified = false;
                ItemsModified = false;
                currentItem = null;
            }

            public void SetInvoiceData(DataRow row)
            {
                //row is the Invoice table row
                if( row == null)
                    return;
                CustomerID = long.Parse(row[0].ToString());
                InvNo = long.Parse(row[1].ToString());
                InvDate = (DateTime)row[2];
                PaymentMethod = (PaymentMethods)(int.Parse(row[3].ToString()));
                CardType = (CardTypes)(int.Parse(row[3].ToString()));
                CardNo = row[5].ToString();
                string strExpDate = row[6].ToString();
                if (strExpDate != null && strExpDate != "")
                    ExpDate = DateTime.Parse(row[6].ToString());
                else
                    ExpDate = DateTime.Today;
                SubTotal = Convert.ToInt64(row[7]);
                AmountPaid = Convert.ToInt64(row[8]);
                Total = Convert.ToInt64(row[9]);                
                SelfModified = false;
            }

            public void SetInvoiceItemData(DataTable items)
            {
                //items are the table Invoice_Items elements
                if(items == null)
                {
                    InvoiceItems.Clear();
                    return;
                }

                InvoiceItems.Clear();
                InvoiceItemModel item;
                foreach(DataRow row in items.Rows)
                {
                    item = new InvoiceItemModel();
                    item.FilloutData(row);
                    InvoiceItems.Add(item);
                }

                currentItem = InvoiceItems[InvoiceItems.Count - 1];

                ItemsModified = false;
            }

            public void CalculateTotal()
            {
                SubTotal = 0;
                foreach(InvoiceItemModel item in InvoiceItems)
                {
                    SubTotal += item.LineTotal;
                }
                Total = SubTotal - AmountPaid;
            }

        public InvoiceModel Clone()
            {                                
                List<InvoiceItemModel> itemList = new List<InvoiceItemModel>();
                foreach(InvoiceItemModel item in this.InvoiceItems)
                {
                    itemList.Add(item.Clone());
                }
                InvoiceModel myClone = new InvoiceModel()
                {
                    CustomerID = this.CustomerID,
                    InvNo = this.InvNo,
                    InvDate = this.InvDate,
                    PaymentMethod = this.PaymentMethod,
                    CardType = this.CardType,
                    CardNo = this.CardNo,
                    ExpDate = this.ExpDate,
                    SubTotal = this.SubTotal,
                    AmountPaid = this.AmountPaid,
                    Total = this.Total,
                    SelfModified = this.SelfModified,
                    ItemsModified = this.ItemsModified
                };
                myClone.InvoiceItems = itemList;
                myClone.CurrentItem = this.CurrentItem;
                return myClone;
            }

        public bool AddItem(InvoiceItemModel item)
        {
            InvoiceItemModel foundItem = InvoiceItems.Find(x=> x.Equals(item) );
            if (foundItem != null)
                return false;
            else
            {
                InvoiceItems.Add(item);
                CurrentItem = item;
                CalculateTotal();
                return true;
            }
        }

        public bool RemoveItem(InvoiceItemModel item)
        {
            InvoiceItemModel foundItem = InvoiceItems.Find(x => x.Equals(item));
            if (foundItem == null)
                return true;
            else
            {
                InvoiceItems.Remove(item);
                CalculateTotal();
                return true;
            }
        }

        public bool SetCurrentItem(InvoiceItemModel item)
        {
            InvoiceItemModel foundItem = InvoiceItems.Find(x => x.Equals(item));
            if (foundItem == null)
                return false;
            else
            {

                CurrentItem = foundItem;
                return true;
            }
        }
            //public IInvoiceAccess InvoiceAccess { get; set; }

           /* public bool LoadInvoice(long invNo)
            {
                bool rtValue = InvoiceAccess.LoadInvoiceByInvNo(invNo);  //!!!
                SelfModified = ItemsModified = false;
                return rtValue;
            }


            public bool UpdateInvoiceSelf()
            {
                if (SelfModified == false) //Do not need to save
                    return true;
                //Modified
                bool rtValue = InvoiceAccess.UpdateInvoiceSelf(this);
                if(rtValue == true)
                {
                    SelfModified = false;
                }
                return rtValue;
            }

            public bool UpdateInvoice()
            {
                if (SelfModified == false && ItemsModified == false)
                    return true;
                bool rtValue = true;
                if (ItemsModified == false)
                {
                    rtValue = InvoiceAccess.UpdateInvoiceSelf(this);
                    if(rtValue == true )                    
                        SelfModified = false;
                    return rtValue;                                            
                }
                else
                {
                    rtValue = InvoiceAccess.UpdateInvoice(this);
                    if(rtValue == true )                    
                       SelfModified = ItemsModified = false;
                    return rtValue;
                }
            }*/
        }

}
