using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcupunctureClinic.Data.BusinessService
{
    using System.Data;
    using AcupunctureClinic.Data.DataAccess;
    using AcupunctureClinic.Data.DataModel;
    using Excel = Microsoft.Office.Interop.Excel;

    /// <summary>
    /// class to query the DataAccess, implements ICusomerService interface
    /// </summary>
    public class InvoiceService : IInvoiceService
    {
        private IInvoiceAccess invoiceAccess;
        /// <summary>
        /// Initializes a new instance of the CustomerService class
        /// </summary>
        public InvoiceService()
        {
            this.invoiceAccess = new InvoiceAccess();
        }

        /// <summary>
        /// Service method to get invoices records by multiple parameters
        /// </summary>
        /// <param name="CustomerID">CustomerID value</param>
        /// <returns>A DataTable of the Invoice table</returns>
        public DataTable GetInvoicesByCustomerID(long customerId)
        {
            return this.invoiceAccess.GetInvoicesById(customerId);
        }

        /// <summary>
        /// Method to add invoice to the database
        /// </summary>
        /// <param name="invoiceModel">invoiceModel</param>
        /// <returns></returns>
        public bool AddInvoice(InvoiceModel invoiceModel)
        {
            return this.invoiceAccess.AddInvoice(invoiceModel);
        }

        /// <summary>
        /// Method to update invoice to the database
        /// </summary>
        /// <param name="invoiceModel">invoiceModel</param>
        /// <returns></returns>
        public bool UpdateInvoice(InvoiceModel invoiceModel)
        {
            return this.invoiceAccess.UpdateInvoice(invoiceModel);
        }

        /// <summary>
        /// Method to add the item, and then update invoice to the database
        /// </summary>
        /// <param name="invoiceModel">invoiceModel</param>
        /// <param name="invoiceItemModel">invoiceItemModel</param>
        /// <returns></returns>
        public bool AddInvoiceItem(InvoiceModel invoiceModel, InvoiceItemModel item)
        {
            return this.invoiceAccess.AddInvoiceItem(invoiceModel, item);
        }

        /// <summary>
        /// Method to update the item, and then update invoice to the database
        /// </summary>
        /// <param name="invoiceModel">invoiceModel</param>
        /// <param name="invoiceItemModel">invoiceItemModel</param>
        /// <returns></returns>
        public bool UpDateInvoiceItem(InvoiceModel invoiceModel, InvoiceItemModel item)
        {
            return this.invoiceAccess.UpDateInvoiceItem(invoiceModel, item);
        }

        /// <summary>
        /// Method to delete invoice details
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <param name="itemCount">items to be deleted</param>
        /// <returns>bool</returns>
        public bool DeleteInvoice(long invNo, int itemCount)     
        {
            return this.invoiceAccess.DeleteInvoice(invNo, itemCount);
        }

        /// <summary>
        /// Method to delete DeleteInvoiceItem 
        /// it needs to delete an item in the invoice, and update the invoice
        /// </summary>
        /// <param name="invoice">invoice, invoiceItem</param>
        /// <returns>bool</returns>
        public bool DeleteInvoiceItem(InvoiceModel invoice, InvoiceItemModel item)
        {
            return this.invoiceAccess.DeleteInvoiceItem(invoice, item); 
        }
        
        /// <summary>
        /// Method FilloutInvoiceReport
        /// </summary>
        /// <param name="InvoiceModel">invoiceModel</param>
        /// <returns>bool</returns>
        public Excel.Worksheet FilloutInvoiceReport(InvoiceModel invoiceModel)
        {
            return this.invoiceAccess.FilloutInvoiceReport(invoiceModel);
        }

        /// <summary>
        /// Close connecting to Excel
        /// </summary>
        /// <returns>void</returns>
        public void CloseExcel()
        {
            this.invoiceAccess.CloseExcel();
            return;
        }

        /// Invoice Methods
        /// <summary>
        /// LoadInvoiceByInvNo
        /// </summary>
        /// <returns>Datarow</returns>
        public DataRow LoadInvoiceByInvNo(long invoiceNo)
        {
            return this.invoiceAccess.LoadInvoiceByInvNo(invoiceNo);
        }

        /// <summary>
        /// LoadInvoiceItemsByInvNo
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LoadInvoiceItemsByInvNo(long invoiceNo)
        {
            return this.invoiceAccess.LoadInvoiceItemsByInvNo(invoiceNo);
        }
    }
}
