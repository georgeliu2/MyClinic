using System.Text;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.OleDb;

using AcupunctureClinic.Data.Sql;
using Excel = Microsoft.Office.Interop.Excel;
using AcupunctureClinic.Data.Enums;

namespace AcupunctureClinic.Data.DataAccess
{
    using AcupunctureClinic.Data.DataModel;
    using AcupunctureClinic.Data.BusinessService;
    public class InvoiceAccess : ConnectionAccess, IInvoiceAccess
    {
        public Excel.Workbook InvoiceBook { get; set; }
        public Excel.Application ExcelApp { get; set; }
        public Excel.Worksheet InvoiceSheet { get; set; }


        public void ClearInvoice(Excel.Worksheet invoiceSheet)
        {
            for (int i = 15; i <= 27; i++)
            {
                invoiceSheet.Cells[i, 1] = "";
                invoiceSheet.Cells[i, 2] = "";
                invoiceSheet.Cells[i, 3] = "";
                invoiceSheet.Cells[i, 7] = "";
                invoiceSheet.Cells[i, 8] = "";
                invoiceSheet.Cells[i, 9] = "";
            }
            invoiceSheet.Cells[29, 2] = "";   //Payment method
            invoiceSheet.Cells[28, 9] = "";   //Subtotal
            invoiceSheet.Cells[29, 9] = "";     //Amount paid
            invoiceSheet.Cells[30, 9] = "";     //Total
        }
        /// <summary>
        /// Method FilloutInvoiceReport. It fill out Excel Invoice report
        /// </summary>
        /// <param name="InvoiceModel">invoiceModel</param>
        /// <returns>bool</returns>
        public Excel.Worksheet FilloutInvoiceReport(InvoiceModel invoiceModel)
        {
            try
            {
                //ExcelApp = new Excel.Application();
                ExcelApp = new Excel.ApplicationClass();

                //InvoiceBook = ExcelApp.Workbooks.Open(this.ExcelConnectionString);
                InvoiceBook = ExcelApp.Workbooks.Open(this.ExcelConnectionString,
                         Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing);

                InvoiceSheet = (Excel.Worksheet)InvoiceBook.Sheets[1]; // Explicit cast is not required here

                ClearInvoice(InvoiceSheet);

                //InvoiceSheet.Activate();
                InvoiceSheet.Cells[4, 9] = invoiceModel.InvDate;
                InvoiceSheet.Cells[5, 9] = invoiceModel.InvNo;
                InvoiceSheet.Cells[6, 9] = invoiceModel.CustomerID;
                InvoiceSheet.Cells[15, 7] = invoiceModel.SubTotal;
                InvoiceSheet.Cells[15, 9] = invoiceModel.Total;

                InvoiceSheet.Cells[29, 2] = Enum.GetName(typeof(PaymentMethods), invoiceModel.PaymentMethod);
                InvoiceSheet.Cells[28, 9] = utility.DisplayCurrency(invoiceModel.SubTotal);   //Subtotal
                InvoiceSheet.Cells[29, 9] = utility.DisplayCurrency(invoiceModel.AmountPaid);     //Amount paid
                InvoiceSheet.Cells[30, 9] = utility.DisplayCurrency(invoiceModel.Total);     //Total

                //Invoice items:  Max items = 14
                int FIRST_ROW_INDEX = 15;
                for(int i = 0; i< invoiceModel.InvoiceItems.Count; i++)
                {
                    InvoiceItemModel item = invoiceModel.InvoiceItems[i];
                    InvoiceSheet.Cells[FIRST_ROW_INDEX + i, 1] = item.ProcedureCode;
                    InvoiceSheet.Cells[FIRST_ROW_INDEX + i, 2] = item.HMCode;
                    InvoiceSheet.Cells[FIRST_ROW_INDEX + i, 7] =  utility.DisplayCurrency(item.Price);
                    InvoiceSheet.Cells[FIRST_ROW_INDEX + i, 8] = utility.IntToDisRate(item.DiscountRate);
                    InvoiceSheet.Cells[FIRST_ROW_INDEX + i, 9] = utility.DisplayCurrency(item.LineTotal);
                }
                ExcelApp.Visible = true;

                //InvoiceSheet.Activate(); 


            }
            catch (Exception)
            {
                ;
            }

            return InvoiceSheet;
        }


        /// <summary>
        /// Close connecting to Excel
        /// </summary>
        /// <returns>void</returns>
        public void CloseExcel()
        {
            if (InvoiceBook != null)
                InvoiceBook.Close(false, Type.Missing, Type.Missing);
            InvoiceSheet = null;
            ExcelApp.Quit();
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (System.Diagnostics.Process p in process)
            {
                if (!string.IsNullOrEmpty(p.ProcessName))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
            }
        }

        //*********************************************************************************************
        //      Invoice Related Methods
        //*********************************************************************************************     
        /// Invoice Methods
        /// <summary>
        /// LoadInvoiceByInvNo
        /// </summary>
        /// <returns>Datarow</returns>
        public DataRow LoadInvoiceByInvNo(long invoiceNo)
        {
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetInvoicesByInvNo;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@InvNo", invoiceNo);
                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);
                // Get the datarow from the table
                dataRow = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
                return dataRow;
            }
        }

        /// <summary>
        /// LoadInvoiceItemsByInvNo
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LoadInvoiceItemsByInvNo(long invoiceNo)
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlLoadInvoiceItemsByInvNo;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@InvNo", invoiceNo);
                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
        }

        /// <summary>
        /// Method to get invoice records  by id
        /// </summary>
        /// <param name="CustomerID">id value</param>
        /// <returns>Data Table</returns>
        public DataTable GetInvoicesById(long id)
        {
            DataTable dataTable = new DataTable();

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
            {
                // Create the command and set its properties
                dataAdapter.SelectCommand = new OleDbCommand();
                dataAdapter.SelectCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;
                dataAdapter.SelectCommand.CommandText = Scripts.sqlGetInvoicesById;

                // Add the parameter to the parameter collection
                dataAdapter.SelectCommand.Parameters.AddWithValue("@CustomerID", id);

                // Fill the datatable From adapter
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        /// <summary>
        /// Method to insert invoice and its items
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        public bool AddInvoice(InvoiceModel invoice)
        {
            bool rtValue = true;
            // Set the command object properties
            OleDbConnection conn = new OleDbConnection(this.DBConnectionString);
            conn.Open();
            OleDbTransaction trans = conn.BeginTransaction();
            OleDbCommand dbCommand = conn.CreateCommand();
            try
            {
                // Set the command object properties
                dbCommand.Transaction = trans;
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlInsertInvoiceSelf;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                dbCommand.Parameters.AddWithValue("@InvDate", invoice.InvDate); //ToShortDateString()); //invoice.InvDate.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@PaymentMethod", (int)invoice.PaymentMethod);
                dbCommand.Parameters.AddWithValue("@CardType", (int)invoice.CardType);
                dbCommand.Parameters.AddWithValue("@CardNo", invoice.CardNo);
                dbCommand.Parameters.AddWithValue("@ExpDate", invoice.ExpDate); //invoice.ExpDate.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
                dbCommand.Parameters.AddWithValue("@AmountPaid", invoice.AmountPaid);
                dbCommand.Parameters.AddWithValue("@Total", invoice.Total);

                var rowsAffected = dbCommand.ExecuteNonQuery();
                dbCommand.CommandText = "Select @@Identity";
                invoice.InvNo = (int)dbCommand.ExecuteScalar();

                rtValue =  rowsAffected > 0;
                
                ///////////////////////////////////////////////////////////////
                //      Add InvoiceItems
                ///////////////////////////////////////////////////////////////
                List<DataModel.InvoiceItemModel> items = invoice.InvoiceItems;
                if (items.Count > 0)
                {
                    //Add invoice items
                    dbCommand.CommandText = Scripts.sqlInsertInvoiceItem;
                    foreach (DataModel.InvoiceItemModel item in items)
                    {
                        // Add the input parameters to the parameter collection
                        dbCommand.Parameters.AddWithValue("@InvNo", item.InvNo);
                        dbCommand.Parameters.AddWithValue("@Procedure_Code", item.ProcedureCode);
                        dbCommand.Parameters.AddWithValue("@H_M_Code", item.HMCode);
                        dbCommand.Parameters.AddWithValue("@Price", item.Price);
                        dbCommand.Parameters.AddWithValue("@DiscountRate", item.DiscountRate);
                        dbCommand.Parameters.AddWithValue("@LineTotal", item.LineTotal);

                        // Open the connection, execute the query and close the connection
                        //dbCommand.Connection.Open();
                        rowsAffected = dbCommand.ExecuteNonQuery();
                        rtValue = rtValue && (rowsAffected > 0);
                    }
                }
                // Commit the transaction
                trans.Commit();
                conn.Close();
                return rtValue;
            }
            catch (Exception ex)
            {
                trans.Rollback(); // HERE IS THE PROBLEM!!!!!!!!!!!!!!!!!!1
                conn.Close();
                throw ex;
            }            
        }

        /// <summary>
        /// Method to update invoice details
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <returns></returns>
        public bool UpdateInvoiceSelf(InvoiceModel invoice)
        {
            // Set the command object properties
            OleDbConnection conn = new OleDbConnection(this.DBConnectionString);
            conn.Open();
            OleDbTransaction trans = conn.BeginTransaction();
            //Declare and instantiate command and string variables
            OleDbCommand dbCommand = conn.CreateCommand();
            try
            {
                //dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateInvoiceSelf;


                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                dbCommand.Parameters.AddWithValue("@InvDate", invoice.InvDate);
                dbCommand.Parameters.AddWithValue("@PaymentMethod", (int)invoice.PaymentMethod);
                dbCommand.Parameters.AddWithValue("@CardType", (int)invoice.CardType);
                dbCommand.Parameters.AddWithValue("@CardNo", invoice.CardNo);
                dbCommand.Parameters.AddWithValue("@ExpDate", invoice.ExpDate); //invoice.ExpDate.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
                dbCommand.Parameters.AddWithValue("@AmountPaid", invoice.AmountPaid);
                dbCommand.Parameters.AddWithValue("@Total", invoice.Total);
                dbCommand.Parameters.AddWithValue("@InvNo", invoice.InvNo);

                // Open the connection, execute the query and close the connection
                //dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                // Commit the transaction
                trans.Commit();
                conn.Close();
                return rowsAffected > 0;
            }
            catch (Exception )
            {
                trans.Rollback(); // HERE IS THE PROBLEM!!!!!!!!!!!!!!!!!!1
                conn.Close();
                return false;
            }
        }

        /// <summary>
        /// Method to delete invoice details
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <param name="itemCount">items to be deleted</param>
        /// <returns>bool</returns>
        public bool DeleteInvoice(long invNo, int itemCount)        
        {
            bool rtValue = true;
             // Set the command object properties
            OleDbConnection conn = new OleDbConnection(this.DBConnectionString);
            conn.Open();
            OleDbTransaction trans = conn.BeginTransaction();
            //Declare and instantiate command and string variables
            OleDbCommand dbCommand = conn.CreateCommand();
            try
            {
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlDeleteInvoice;
                dbCommand.Transaction = trans;

                // Add the input parameter to the parameter collection
                dbCommand.Parameters.AddWithValue("@InvNo", invNo);

                var rowsAffected = dbCommand.ExecuteNonQuery();
                rtValue = rowsAffected > 0;

                //Delete invoice items
                if (itemCount > 0)
                {
                    dbCommand.CommandText = Scripts.sqlDeleteInvoiceItems;

                    // Open the connection, execute the query and close the connection
                    //dbCommand.Connection.Open();
                    rowsAffected = dbCommand.ExecuteNonQuery();
                    rtValue = rtValue && (rowsAffected == itemCount);
                }
                // Commit the transaction
                trans.Commit();
                conn.Close();
                return rtValue;
             
            }
            catch (Exception ex)
            {
                trans.Rollback(); // HERE IS THE PROBLEM!!!!!!!!!!!!!!!!!!1
                conn.Close();
                throw ex;
            }
        }

        //**************************************************************************************************
        //      Invoice Item Related Methods
        //**************************************************************************************************
        /// <summary>
        /// Method to update invoice item
        /// </summary>
        /// <param name="invoiceItem">invoiceItem</param>
        /// <returns></returns>
        public bool UpdateInvoiceItem(InvoiceItemModel invoiceItem)
        {
            // Set the command object properties
            OleDbConnection conn = new OleDbConnection(this.DBConnectionString);
            conn.Open();
            OleDbTransaction trans = conn.BeginTransaction();
            //Declare and instantiate command and string variables
            OleDbCommand dbCommand = conn.CreateCommand();
            try
            {
                //dbCommand.Connection = new OleDbConnection(this.DBConnectionString);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateInvoiceItem;


                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@Price", invoiceItem.Price);
                dbCommand.Parameters.AddWithValue("@DiscountRate", invoiceItem.DiscountRate);
                dbCommand.Parameters.AddWithValue("@LineTotal", invoiceItem.LineTotal);
                dbCommand.Parameters.AddWithValue("@InvNo", invoiceItem.InvNo);
                dbCommand.Parameters.AddWithValue("@ProcedureCode", invoiceItem.ProcedureCode);
                dbCommand.Parameters.AddWithValue("@HMCodeCode", invoiceItem.HMCode);

                // Open the connection, execute the query and close the connection
                //dbCommand.Connection.Open();
                var rowsAffected = dbCommand.ExecuteNonQuery();
                // Commit the transaction
                trans.Commit();
                conn.Close();
                return rowsAffected > 0;
            }
            catch (Exception )
            {
                trans.Rollback(); // HERE IS THE PROBLEM!!!!!!!!!!!!!!!!!!1
                conn.Close();
                return false;
            }
        }

        //**************************************************************************************************
        //      Whole Invoice  Related Methods
        //**************************************************************************************************
        public bool UpdateInvoice(InvoiceModel invoice)
        {
            bool rtValue = true;
            // Set the command object properties
            OleDbConnection conn = new OleDbConnection(this.DBConnectionString);
            conn.Open();
            OleDbTransaction trans = conn.BeginTransaction();
            try 
            {
                //Declare and instantiate command and string variables
                OleDbCommand dbCommand = conn.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateInvoiceSelf;


                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                dbCommand.Parameters.AddWithValue("@InvDate", invoice.InvDate);
                dbCommand.Parameters.AddWithValue("@PaymentMethod", (int)invoice.PaymentMethod);
                dbCommand.Parameters.AddWithValue("@CardType", (int)invoice.CardType);
                dbCommand.Parameters.AddWithValue("@CardNo", invoice.CardNo);
                dbCommand.Parameters.AddWithValue("@ExpDate", invoice.ExpDate); //invoice.ExpDate.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
                dbCommand.Parameters.AddWithValue("@AmountPaid", invoice.AmountPaid);
                dbCommand.Parameters.AddWithValue("@Total", invoice.Total);
                dbCommand.Parameters.AddWithValue("@InvNo", invoice.InvNo);

                // Open the connection, execute the query and close the connection
                //dbCommand.Connection.Open();
                dbCommand.Transaction = trans;
                var rowsAffected = dbCommand.ExecuteNonQuery();
                rtValue = rtValue && (rowsAffected > 0);
                ///////////////////////////////////////////////////////////////
                //      Update Invoice Items
                ///////////////////////////////////////////////////////////////
                List<DataModel.InvoiceItemModel> items = invoice.InvoiceItems;
                if (items.Count > 0)
                {
                    //Update invoice items
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = Scripts.sqlUpdateInvoiceItem;
                    foreach (DataModel.InvoiceItemModel item in items)
                    {
                        dbCommand.Parameters.Clear();
                        // Add the input parameters to the parameter collection
                        dbCommand.Parameters.AddWithValue("@Price", item.Price);
                        dbCommand.Parameters.AddWithValue("@DiscountRate", item.DiscountRate);
                        dbCommand.Parameters.AddWithValue("@LineTotal", item.LineTotal);
                        dbCommand.Parameters.AddWithValue("@InvNo", item.InvNo);
                        dbCommand.Parameters.AddWithValue("@ProcedureCode", item.ProcedureCode);
                        dbCommand.Parameters.AddWithValue("@HMCodeCode", item.HMCode);

                        // Open the connection, execute the query and close the connection
                        //dbCommand.Connection.Open();
                        rowsAffected = dbCommand.ExecuteNonQuery();
                        rtValue = rtValue && (rowsAffected > 0);
                    }

                }
                // Commit the transaction
                trans.Commit();
                conn.Close();
                return rtValue;
            }
            catch (Exception ex)
            {
                
                trans.Rollback(); // HERE IS THE PROBLEM!!!!!!!!!!!!!!!!!!1
                conn.Close();
                throw ex;
            }

        }

        /// <summary>
        /// Method to add the item, and then update invoice to the database
        /// </summary>
        /// <param name="invoiceModel">invoiceModel</param>
        /// <param name="invoiceItemModel">invoiceItemModel</param>
        /// <returns></returns>
        public bool AddInvoiceItem(InvoiceModel invoice, InvoiceItemModel item)
        {
            bool rtValue = true;
            // Set the command object properties
            OleDbConnection conn = new OleDbConnection(this.DBConnectionString);
            conn.Open();
            OleDbTransaction trans = conn.BeginTransaction();
            try
            {
                //Declare and instantiate command and string variables
                OleDbCommand dbCommand = conn.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlInsertInvoiceItem;

                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@InvNo", item.InvNo);
                dbCommand.Parameters.AddWithValue("@Procedure_Code", item.ProcedureCode);
                dbCommand.Parameters.AddWithValue("@H_M_Code", item.HMCode);
                dbCommand.Parameters.AddWithValue("@Price", item.Price);
                dbCommand.Parameters.AddWithValue("@DiscountRate", item.DiscountRate);
                dbCommand.Parameters.AddWithValue("@LineTotal", item.LineTotal);
      
                dbCommand.Transaction = trans;
                var rowsAffected = dbCommand.ExecuteNonQuery();
                rtValue = rtValue && (rowsAffected > 0);

                //Update the invoice self
                dbCommand.CommandText = Scripts.sqlUpdateInvoiceSelf;
                dbCommand.Parameters.Clear();
                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                dbCommand.Parameters.AddWithValue("@InvDate", invoice.InvDate); 
                dbCommand.Parameters.AddWithValue("@PaymentMethod", (int)invoice.PaymentMethod);
                dbCommand.Parameters.AddWithValue("@CardType", (int)invoice.CardType);
                dbCommand.Parameters.AddWithValue("@CardNo", invoice.CardNo);
                dbCommand.Parameters.AddWithValue("@ExpDate", invoice.ExpDate); 
                dbCommand.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
                dbCommand.Parameters.AddWithValue("@AmountPaid", invoice.AmountPaid);
                dbCommand.Parameters.AddWithValue("@Total", invoice.Total);
                dbCommand.Parameters.AddWithValue("@InvNo", invoice.InvNo);

    

                rowsAffected = dbCommand.ExecuteNonQuery();
                rtValue = rtValue && (rowsAffected > 0);
               
                // Commit the transaction
                trans.Commit();
                conn.Close();
                return rtValue;
            }
            catch (Exception)
            {

                trans.Rollback(); // HERE IS THE PROBLEM!!!!!!!!!!!!!!!!!!1
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// Method to update the item, and then update invoice to the database
        /// </summary>
        /// <param name="invoiceModel">invoiceModel</param>
        /// <param name="invoiceItemModel">invoiceItemModel</param>
        /// <returns></returns>
        public bool UpDateInvoiceItem(InvoiceModel invoice, InvoiceItemModel item)
        {
            bool rtValue = true;
            // Set the command object properties
            OleDbConnection conn = new OleDbConnection(this.DBConnectionString);
            conn.Open();
            OleDbTransaction trans = conn.BeginTransaction();
            try
            {
                //Declare and instantiate command and string variables
                OleDbCommand dbCommand = conn.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlUpdateInvoiceItem;

                // Add the input parameters to the parameter collection                
                dbCommand.Parameters.AddWithValue("@Price", item.Price);
                dbCommand.Parameters.AddWithValue("@DiscountRate", item.DiscountRate);
                dbCommand.Parameters.AddWithValue("@LineTotal", item.LineTotal);
                dbCommand.Parameters.AddWithValue("@InvNo", item.InvNo);
                dbCommand.Parameters.AddWithValue("@Procedure_Code", item.ProcedureCode);
                dbCommand.Parameters.AddWithValue("@H_M_Code", item.HMCode);

                dbCommand.Transaction = trans;
                var rowsAffected = dbCommand.ExecuteNonQuery();
                rtValue = rtValue && (rowsAffected > 0);

                //Update the invoice self
                dbCommand.CommandText = Scripts.sqlUpdateInvoiceSelf;
                dbCommand.Parameters.Clear();
                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                dbCommand.Parameters.AddWithValue("@InvDate", invoice.InvDate);
                dbCommand.Parameters.AddWithValue("@PaymentMethod", (int)invoice.PaymentMethod);
                dbCommand.Parameters.AddWithValue("@CardType", (int)invoice.CardType);
                dbCommand.Parameters.AddWithValue("@CardNo", invoice.CardNo);
                dbCommand.Parameters.AddWithValue("@ExpDate", invoice.ExpDate);
                dbCommand.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
                dbCommand.Parameters.AddWithValue("@AmountPaid", invoice.AmountPaid);
                dbCommand.Parameters.AddWithValue("@Total", invoice.Total);
                dbCommand.Parameters.AddWithValue("@InvNo", invoice.InvNo);



                rowsAffected = dbCommand.ExecuteNonQuery();
                rtValue = rtValue && (rowsAffected > 0);

                // Commit the transaction
                trans.Commit();
                conn.Close();
                return rtValue;
            }
            catch (Exception ex)
            {

                trans.Rollback(); // HERE IS THE PROBLEM!!!!!!!!!!!!!!!!!!1
                conn.Close();
                throw ex;
            }
        }

        /// <summary>
        /// Method DeleteInvoiceItem 
        /// it needs to delete an item in the invoice, and update the invoice
        /// </summary>
        /// <param name="invoice">invoice</param>
        /// <param name="invoiceItem">invoiceItem</param>
        /// <returns>bool</returns>
        public  bool DeleteInvoiceItem(InvoiceModel invoice, InvoiceItemModel item)
        {
            bool rtValue = true;
            // Set the command object properties
            OleDbConnection conn = new OleDbConnection(this.DBConnectionString);
            conn.Open();
            OleDbTransaction trans = conn.BeginTransaction();
            try
            {
                //Declare and instantiate command and string variables
                OleDbCommand dbCommand = conn.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = Scripts.sqlDeleteInvoiceItem;


                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@InvNo", item.InvNo);
                dbCommand.Parameters.AddWithValue("@ProceDureCode", item.ProcedureCode);                
                dbCommand.Parameters.AddWithValue("@HMCode", item.HMCode);

                dbCommand.Transaction = trans;
                var rowsAffected = dbCommand.ExecuteNonQuery();
                //rtValue = rtValue && (rowsAffected > 0);
                //rowsAffected == 0 maybe not wrong, maybe the record has been removed before
                ///////////////////////////////////////////////////////////////
                //      Update Invoice 
                ///////////////////////////////////////////////////////////////
                dbCommand.CommandText = Scripts.sqlUpdateInvoiceSelf;

                dbCommand.Parameters.Clear();
                // Add the input parameters to the parameter collection
                dbCommand.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                dbCommand.Parameters.AddWithValue("@InvDate", invoice.InvDate);
                dbCommand.Parameters.AddWithValue("@PaymentMethod", (int)invoice.PaymentMethod);
                dbCommand.Parameters.AddWithValue("@CardType", (int)invoice.CardType);
                dbCommand.Parameters.AddWithValue("@CardNo", invoice.CardNo);
                dbCommand.Parameters.AddWithValue("@ExpDate", invoice.ExpDate); //invoice.ExpDate.ToShortDateString());
                dbCommand.Parameters.AddWithValue("@SubTotal", invoice.SubTotal);
                dbCommand.Parameters.AddWithValue("@AmountPaid", invoice.AmountPaid);
                dbCommand.Parameters.AddWithValue("@Total", invoice.Total);
                dbCommand.Parameters.AddWithValue("@InvNo", invoice.InvNo);

                rowsAffected = dbCommand.ExecuteNonQuery();
                rtValue = rtValue && (rowsAffected > 0);

                // Commit the transaction
                trans.Commit();
                conn.Close();
                return rtValue;
            }
            catch (Exception ex)
            {
                trans.Rollback(); // HERE IS THE PROBLEM!!!!!!!!!!!!!!!!!!1
                conn.Close();
                throw ex;
            }

        } 
    }
}
