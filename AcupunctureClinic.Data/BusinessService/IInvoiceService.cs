using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcupunctureClinic.Data.BusinessService
{
    using System.Data;
    using AcupunctureClinic.Data.DataModel;
    using Excel = Microsoft.Office.Interop.Excel;

    /// <summary>
    /// Interface IInvoiceService
    /// </summary>
    public interface IInvoiceService
    {
        /// <summary>
        /// Service method to get invoices records by multiple parameters
        /// </summary>
        /// <param name="CustomerID">CustomerID value</param>
        /// <returns>A DataTable of the Invoice table</returns>
        DataTable GetInvoicesByCustomerID(long customerId);
    
        /// <summary>
        /// Method to add invoice to the database
        /// </summary>
        /// <param name="invoiceModel">invoiceModel</param>
        /// <returns></returns>
        bool AddInvoice(InvoiceModel invoiceModel);

        /// <summary>
        /// Method to update invoice to the database
        /// </summary>
        /// <param name="invoiceModel">invoiceModel</param>
        /// <returns></returns>
        bool UpdateInvoice(InvoiceModel invoiceModel);

        /// <summary>
        /// Method to add the item, and then update invoice to the database
        /// </summary>
        /// <param name="invoiceModel">invoiceModel</param>
        /// <param name="invoiceItemModel">invoiceItemModel</param>
        /// <returns></returns>
        bool AddInvoiceItem(InvoiceModel invoiceModel, InvoiceItemModel item);

        
        /// <summary>
        /// Method to update the item, and then update invoice to the database
        /// </summary>
        /// <param name="invoiceModel">invoiceModel</param>
        /// <param name="invoiceItemModel">invoiceItemModel</param>
        /// <returns></returns>
        bool UpDateInvoiceItem(InvoiceModel invoiceModel, InvoiceItemModel item);

        /// <summary>
        /// Method to update invoice to the database
        /// </summary>
        /// <param name="InvNo">invoice number</param>
        /// <param name="itemCount">items to be deleted</param>
        /// <returns></returns>
        bool DeleteInvoice(long invNo, int itemCount);

        /// <summary>
        /// Method to delete DeleteInvoiceItem 
        /// it needs to delete an item in the invoice, and update the invoice
        /// </summary>
        /// <param name="invoice">invoice, invoiceItem</param>
        /// <returns>bool</returns>
        bool DeleteInvoiceItem(InvoiceModel invoice, InvoiceItemModel item);

        /// <summary>
        /// Method FilloutInvoiceReport
        /// </summary>
        /// <param name="InvoiceModel">invoiceModel</param>
        /// <returns>bool</returns>
        Excel.Worksheet FilloutInvoiceReport(InvoiceModel invoiceModel);

        /// <summary>
        /// Close connecting to Excel
        /// </summary>
        /// <returns>void</returns>
        void CloseExcel();

        /// Invoice Methods
        /// <summary>
        /// LoadInvoiceByInvNo
        /// </summary>
        /// <returns>Datarow</returns>
        DataRow LoadInvoiceByInvNo(long invoiceNo);

        /// <summary>
        /// LoadInvoiceItemsByInvNo
        /// </summary>
        /// <returns>DataTable</returns>
        DataTable LoadInvoiceItemsByInvNo(long invoiceNo);
    }
}
