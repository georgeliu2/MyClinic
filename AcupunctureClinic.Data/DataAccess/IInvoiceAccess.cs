using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcupunctureClinic.Data.DataAccess
{
    using System.Data;
    using AcupunctureClinic.Data.DataModel;
    using Excel = Microsoft.Office.Interop.Excel;
    public interface IInvoiceAccess
    {     
        /// <summary>
        /// Method to get invoice records  by id
        /// </summary>
        /// <param name="CustomerID">id value</param>
        /// <returns>Data Table</returns>
        DataTable GetInvoicesById(long id);

        /// <summary>
        /// Method to insert invoice details
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        bool AddInvoice(InvoiceModel invoice);

        /// <summary>
        /// Method to update invoice details
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        bool UpdateInvoice(InvoiceModel invoiceModel);

        /// <summary>
        /// Method to add the ite, and then update invoice to the database
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
        /// Method to delete invoice details
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <param name="itemCount">items to be deleted</param>
        /// <returns>bool</returns>
        bool DeleteInvoice(long invNo, int itemCount); 
                

        /// <summary>
        /// Method to update invoice self
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        bool UpdateInvoiceSelf(InvoiceModel invoice);

        /// <summary>
        /// Method to update invoice item
        /// </summary>
        /// <param name="invoiceItem">invoiceItem</param>
        /// <returns></returns>
        bool UpdateInvoiceItem(InvoiceItemModel invoiceItem); 
       
        /// <summary>
        /// Method DeleteInvoiceItem 
        /// it needs to delete an item in the invoice, and update the invoice
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <param name="invoiceItem">invoiceItem</param>
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
