using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AcupunctureClinic.Desktop.Properties;
using AcupunctureClinic.Data.Enums;
//using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel; 


namespace AcupunctureClinic.Desktop.Forms
{
    using AcupunctureClinic.Desktop.Forms.Membership;
    using AcupunctureClinic.Data.DataModel;
    using AcupunctureClinic.Data.BusinessService;

    public partial class frmInvoice :  Form, ICodePickup
    {
        private Manage manage;
        private long invoiceNo;
        private IInvoiceService invoiceService;
        private InvoiceModel invoiceModel;
        private int codePickuprStatus;   //0 -- None; 1 -- ProcedureCodePickup; 
                                    //2 -- H/M Code Pickup; 3 -- Diagnostic Code Pickup
        public frmInvoice(Manage _manage, long invNo = 0) 
        {
            InitializeComponent();
            InitilizedtgvInvoiceItemListStyle();
            manage = _manage;
            invoiceService = manage.InvoiceServiceObj;
            invoiceModel = new InvoiceModel();

            ResetInvoiceView();
            txtCustomerID.Text = manage.CustomerID.ToString();
            txtCustomerName.Text = manage.CustomerName;
            codePickuprStatus = 0;

            invoiceNo = invNo;                       
            if (invNo > 0)
                LoadInvoiceByInvNo(invoiceNo);
            else
                txtInvoiceNo.Text = "";
            
            //else 
            //Create a new invoice  

        }

        /// tab page Procedure Code  Methods
        /// <summary>
        /// Initializes data grid view dtgvItemList style
        /// </summary>
        protected virtual void InitilizedtgvInvoiceItemListStyle()
        {
            // Setting the style of the DataGridView control
            dtgvItemList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dtgvItemList.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dtgvItemList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dtgvItemList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvItemList.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dtgvItemList.DefaultCellStyle.BackColor = Color.Empty;
            dtgvItemList.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            dtgvItemList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dtgvItemList.GridColor = SystemColors.ControlDarkDark;
            dtgvItemList.ColumnCount = 5;
            dtgvItemList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            dtgvItemList.DataSource = null;
            dtgvItemList.Rows.Clear();
            dtgvItemList.Columns[0].HeaderCell.Value = "Procedure Code";
            dtgvItemList.Columns[1].HeaderCell.Value = "H/M Code";
            dtgvItemList.Columns[2].HeaderCell.Value = "Price";
            dtgvItemList.Columns[3].HeaderCell.Value = "Discount rate";
            dtgvItemList.Columns[4].HeaderCell.Value = "Line Total";
            
        }

        private void ResetInvoiceView()
        {
            txtCustomerID.Text = "";
            this.txtInvoiceNo.Text = "";
            this.dtpInvDate.Value = dtpInvDate.MinDate;
            this.lstPaymentMethod.SelectedIndex = 0;
            lstCardType.SelectedIndex = 0;
            this.txtCardNo.Text = "";
            dtpExpireDate.Value = dtpExpireDate.MinDate;
            txtSubTotal.Text = "";
            txtAmtPaid.Text = "";
            txtTotal.Text = "";

            dtgvItemList.Rows.Clear();
            txtItemProcedureCode.Text = "";
            txtItemHMCode.Text = "";
            txtItemDiscountrate.Text = "";
            txtItemPrice.Text = "";
            txtItemPrice.Text = "";
            txtItemTotal.Text = "";
            
        }

        private void ResetInvoiceModel()
        {
            invoiceModel.Reset();
        }

       

        public bool LoadInvoiceByInvNo(long invNo)
        {
            bool rtValue = true;
            if (invNo <= 0)
                return false;
            invoiceModel.InvNo = invNo;
            DataRow row = invoiceService.LoadInvoiceByInvNo(invNo);
            if (row != null)
            {
                invoiceModel.SetInvoiceData(row);
                DataTable items = invoiceService.LoadInvoiceItemsByInvNo(invNo);
                if (items != null && items.Rows.Count > 0)
                    invoiceModel.SetInvoiceItemData(items);
                else
                    invoiceModel.InvoiceItems.Clear();
            }
            else
            {
                invoiceModel.Reset();
                invoiceModel.CustomerID = utility.StrToLong(txtCustomerID.Text);
                invoiceModel.InvNo = (int)utility.StrToLong(txtInvoiceNo.Text);
                rtValue = false;
            }
            SetInvoiceData();
            //txtItemProcedureCode.ReadOnly = true;
            //txtItemHMCode.ReadOnly = true;
            //txtItemTotal.ReadOnly = true;
            btnItemAdd.Enabled = false;
            btnItemDelete.Enabled = true;
            btnItemUpdate.Enabled = true;
            btnItemClean.Enabled = true;
            return rtValue;
        }

        private void SetInvoiceData()
        {
            txtCustomerID.Text = invoiceModel.CustomerID.ToString();
            this.txtInvoiceNo.Text = invoiceModel.InvNo.ToString();
            this.dtpInvDate.Value = invoiceModel.InvDate <= dtpInvDate.MinDate ? dtpInvDate.MinDate : invoiceModel.InvDate;
            this.lstPaymentMethod.SelectedIndex = (int)invoiceModel.PaymentMethod;
            lstCardType.SelectedIndex = (int)invoiceModel.CardType;
            this.txtCardNo.Text = invoiceModel.CardNo;
            dtpExpireDate.Value = invoiceModel.ExpDate;
            txtSubTotal.Text = utility.DisplayCurrency(invoiceModel.SubTotal);
            txtAmtPaid.Text = utility.DisplayCurrency(invoiceModel.AmountPaid);
            txtTotal.Text = utility.DisplayCurrency(invoiceModel.Total);
            txtCustomerName.Text = manage.GetCustomerNameByID(invoiceModel.CustomerID);

            dtgvItemList.Rows.Clear();
            List<InvoiceItemModel> items = invoiceModel.InvoiceItems;
            if (items!= null && items.Count > 0)
            {
                AddItemsToView(items, null);
                int currentIndex = items.Count - 1;
                dtgvItemList.CurrentCell = dtgvItemList.Rows[currentIndex].Cells[0];
                txtItemProcedureCode.Text = items[currentIndex].ProcedureCode.ToString();
                txtItemHMCode.Text = items[currentIndex].HMCode.ToString();
                txtItemDiscountrate.Text = items[currentIndex].DiscountRate.ToString();
                txtItemPrice.Text = utility.DisplayCurrency(items[currentIndex].Price);
                txtItemTotal.Text = utility.DisplayCurrency(items[currentIndex].LineTotal);
                invoiceModel.CurrentItem = items[currentIndex];
                //txtItemProcedureCode.ReadOnly = true;
                //txtItemHMCode.ReadOnly = true;
                //txtItemTotal.ReadOnly = true;
            }
            else
            {
                dtgvItemList.Rows.Clear();
                txtItemProcedureCode.Text = "";
                txtItemHMCode.Text = "";
                txtItemDiscountrate.Text = "";
                txtItemPrice.Text = "";
                txtItemTotal.Text = "";

                //txtItemProcedureCode.ReadOnly = true;
                //txtItemHMCode.ReadOnly = true;
                //txtItemTotal.ReadOnly = true;
            }
            
        }

        //Load all procedure codes
      /*  protected virtual bool LoadInvoiceByCustomerID()
        {
            if ( invoiceNo <= 0)
            {
                if( manage.CustomerID > 0)
                {
                    txtCustomerID.Text = manage.CustomerID.ToString();
                }
                return true; //Do not need to load data
            }
            try
            {                
                DataRow invoice = manage.InvoiceServiceObj.LoadInvoiceByInvNo(invoiceNo);
                //Get invoice items
                DataTable invoiceItems = manage.InvoiceServiceObj.LoadInvoiceItemsByInvNo(invoiceNo);
                if (invoice != null)
                {
                    txtCustomerID.Text = invoice[0].ToString();
                    txtCustomerName.Text = manage.GetCustomerNameByID(long.Parse(txtCustomerID.Text));
                    dtpInvDate.Value = (DateTime)invoice[2];
                    this.dtgvItemList.RowHeadersVisible = true;
                    dtgvItemList.DataSource = null;
                    dtgvItemList.Rows.Clear();
                    //Calculate the size of the DataGridView for invlice items
                    int rowCount = invoiceItems.Rows.Count;
                    if (rowCount <= 0)
                        return true;
                    //Change this Form hight
                    int largedHight = rowCount * 50;
                    this.Height += largedHight;
                    Point p = this.pnlTotal.Location; //.Y += largedHight;
                    p.Y += largedHight;
                    this.pnlTotal.Location = p;

                    //string procedureCode = txtItemServiceCode.Text.Trim();

                    for (int i = 0; i < rowCount; i++)
                    {
                        string code = invoiceItems.Rows[i][1].ToString();
                        string desc = manage.CodeDescription(code);
                        dtgvItemList.Rows.Add(code, desc, "$ " + invoiceItems.Rows[i][2].ToString(), "$ " + invoiceItems.Rows[i][3].ToString(), "$ " + invoiceItems.Rows[i][4].ToString());
                    }

                    dtgvItemList.CurrentCell = dtgvItemList.Rows[rowCount-1].Cells[0];

                    //Populate Invoice
                    this.lstPaymentMethod.SelectedIndex =  (int)(PaymentMethods)Enum.Parse(typeof(PaymentMethods), invoice[3].ToString());
                    int cardType =  (int)(CardTypes)Enum.Parse(typeof(CardTypes), invoice[4].ToString());
                    lstCardType.SelectedIndex = cardType;
                    if(cardType > 0 )
                    {
                        txtCardNo.Text = invoice[5].ToString();
                        dtpExpireDate.Value = (DateTime)invoice[6];
                    }
                    
                    txtSubTotal.Text = invoice[7].ToString();
                    txtAmtPaid.Text = invoice[8].ToString();
                    txtTotal.Text = invoice[9].ToString();

                    //Fill out item detail
                    txtItemServiceCode.Text = invoiceItems.Rows[rowCount - 1][1].ToString();
                    txtItemDescription.Text = manage.CodeDescription(invoiceItems.Rows[rowCount - 1][1].ToString());
                    txtItemPrice.Text = invoiceItems.Rows[rowCount - 1][2].ToString();
                    txtItemDiscountrate.Text = invoiceItems.Rows[rowCount - 1][3].ToString();
                    txtItemTotal.Text = invoiceItems.Rows[rowCount - 1][4].ToString();

                  
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Load Invoice or Inoice Items error: " + e.ToString());
            }
            return false;
        } */

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text != "")
            {
                invoiceNo = long.Parse(txtInvoiceNo.Text);
                if(LoadInvoiceByInvNo(invoiceNo) ==false)
                {
                    txtCustomerName.Text = manage.GetCustomerNameByID(long.Parse(txtCustomerID.Text));
                    btnItemAdd.Enabled = true;
                    btnItemDelete.Enabled = false;
                    btnItemUpdate.Enabled = false;
                    btnItemClean.Enabled = false;
                }
                else
                {
                    btnItemAdd.Enabled = false;
                    btnItemDelete.Enabled = true;
                    btnItemUpdate.Enabled = true;
                    btnItemClean.Enabled = true;
                }
                
            }
            else
                return;
        }

        // Create a new invoice without invoice items.
        protected virtual void btnAdd_Click(object sender, EventArgs e)
        {
            invoiceModel.CustomerID = utility.StrToLong(txtCustomerID.Text);
            invoiceModel.InvDate = dtpInvDate.Value;
            InvoiceModel backup = this.invoiceModel.Clone();
            this.invoiceModel.Reset();
            this.invoiceModel.CustomerID = backup.CustomerID;
            this.invoiceModel.InvDate = backup.InvDate;
            
            if (invoiceService.AddInvoice(invoiceModel) == false)
            {
                MessageBox.Show("Add Invoice failed!");
                this.invoiceModel = backup;

                return;
            }
            else
            {                
                ResetInvoiceView();
                txtInvoiceNo.Text = invoiceModel.InvNo.ToString();
                txtCustomerID.Text = invoiceModel.CustomerID.ToString();
                txtCustomerName.Text = manage.GetCustomerNameByID(invoiceModel.CustomerID);
                dtpInvDate.Value = invoiceModel.InvDate;
                return;
            }
        }


        
        protected void LoadItemsToDataView(DataGridViewRow currentRow)
        {
            if (currentRow == null)
                return;
            InvoiceItemModel currentItem = new InvoiceItemModel();
            currentItem.InvNo = invoiceModel.InvNo;
            this.txtItemProcedureCode.Text = currentItem.ProcedureCode = currentRow.Cells[0].Value.ToString();
            this.txtItemHMCode.Text = currentItem.HMCode = currentRow.Cells[1].Value.ToString();
            txtItemPrice.Text = currentRow.Cells[2].Value.ToString();
            txtItemDiscountrate.Text = currentRow.Cells[3].Value.ToString();      
            this.txtItemTotal.Text = currentRow.Cells[4].Value.ToString();

            invoiceModel.SetCurrentItem(currentItem);
        }

        //Form frmInvoice Closing event handler 
        protected void frmInvoice_FormClosing(object sender, FormClosingEventArgs e) 
        {
           
            manage.Show();
            manage.BringToFront();
        }

        public void ActiveObj()
        {            
            ((Form)this).Show();
            this.BringToFront();
        }

        private void txtName_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void btn4PrintPreview_Click(object sender, System.EventArgs e)
        {


            // Assign the values to the model
            InvoiceModel invoiceModelClone = invoiceModel.Clone(); //CreateInvoiceModel();


            Excel.Worksheet invoiceReport = manage.InvoiceServiceObj.FilloutInvoiceReport(invoiceModelClone);

            if (invoiceReport != null)
            {               
                invoiceReport.PrintPreview(Type.Missing);

                /*ws.PrintOut(
     Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
     Type.Missing, Type.Missing, Type.Missing, Type.Missing);*/


            }

            //invoiceReport.Deactivate();
            //invoiceReport.Close(Type.Missing, Type.Missing, Type.Missing);
            this.manage.InvoiceServiceObj.CloseExcel();
        
        }

        /*
        private InvoiceModel CreateInvoiceModel()
        {
            InvoiceModel invoiceModel = new InvoiceModel()
            {
                CustomerID = long.Parse(txtCustomerID.Text.ToString()),
                InvNo = long.Parse(this.txtInvoiceNo.Text),
                InvDate = this.dtpInvDate.Value,
                PaymentMethod = (PaymentMethods)this.lstPaymentMethod.SelectedIndex,
                CardType = (CardTypes)lstCardType.SelectedIndex,
                CardNo = this.txtCardNo.Text.Trim(),
                ExpDate = dtpExpireDate.Value,
                SubTotal = utility.CurrencyToLong(txtSubTotal.Text.Trim()),
                AmountPaid = utility.CurrencyToLong(txtAmtPaid.Text.Trim()),
                Total = utility.CurrencyToLong(txtTotal.Text.Trim())
            };
            return invoiceModel;
        }*/

        private void btn4Print_Click(object sender, System.EventArgs e)
        {
            // Assign the values to the model
            InvoiceModel invoiceModelclone = invoiceModel.Clone();


            Excel.Worksheet invoiceReport = this.manage.InvoiceServiceObj.FilloutInvoiceReport(invoiceModelclone);

            if (invoiceReport != null)
            {
                invoiceReport.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                       Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                /*ws.PrintOut(
     Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
     Type.Missing, Type.Missing, Type.Missing, Type.Missing);*/

            }

            //invoiceReport.Deactivate();
            //invoiceReport.Close(Type.Missing, Type.Missing, Type.Missing);
            this.manage.InvoiceServiceObj.CloseExcel();
        }

        private void btnQuite_Click(object sender, EventArgs e)
        {
            this.Close(); //It calls frmInvoice_Closing
            //manage.Show();
            //manage.BringToFront();
        }

        public void frmInvoice_Closing(object sender, EventArgs e)
        {
            //MessageBox.Show("Closing");
            manage.LoadAccountAndInvoice();
            manage.Show();
            manage.BringToFront();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            InvoiceModel invoiceBackup = invoiceModel.Clone();
            UpdateInvoiceItem();
            //Update InvoiceModel
            UpdateInvoiceModelObj();
            invoiceModel.CalculateTotal();
            UpdateTotal();
            if (invoiceService.UpdateInvoice(invoiceModel) == false)
            {
                MessageBox.Show("Update Invoice failed!");

                RestoreInvoice(invoiceBackup);
            }

            return;
        }

        private void UpdateInvoiceModelObj()
        {
            //Update invoice itself
            invoiceModel.CustomerID = long.Parse(txtCustomerID.Text.Trim());
            invoiceModel.InvNo = (txtInvoiceNo.Text == null || txtInvoiceNo.Text=="") ? 0 : long.Parse(txtInvoiceNo.Text.Trim());
            invoiceModel.InvDate = dtpInvDate.Value;
            invoiceModel.PaymentMethod = (PaymentMethods)lstPaymentMethod.SelectedIndex;
            invoiceModel.CardType = (CardTypes)lstCardType.SelectedIndex;
            invoiceModel.CardNo = txtCardNo.Text;
            invoiceModel.SubTotal = utility.CurrencyToLong(txtSubTotal.Text);
            invoiceModel.AmountPaid = utility.CurrencyToLong(txtAmtPaid.Text);
            invoiceModel.Total = utility.CurrencyToLong(txtTotal.Text);
           /* invoiceModel.InvoiceItems.Clear();
            foreach(DataGridViewRow row in this.dtgvItemList.Rows)
            {
                InvoiceItemModel item = new InvoiceItemModel()
                {
                    InvNo = invoiceModel.InvNo,
                    ProcedureCode = row.Cells[0].Value.ToString(),
                    HMCode = row.Cells[1].Value.ToString(),
                    Price = utility.CurrencyToLong(row.Cells[2].Value.ToString()),
                    DiscountRate = (int)utility.CurrencyToLong(row.Cells[3].Value.ToString()),
                    LineTotal = utility.CurrencyToLong(row.Cells[4].Value.ToString())
                };

                invoiceModel.InvoiceItems.Add(item);
            }*/



        }

        private void RestoreInvoice(InvoiceModel backup)
        {
            //Restore invoice and items
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            invoiceModel.InvNo = long.Parse(txtInvoiceNo.Text);
            if (invoiceService.DeleteInvoice(invoiceModel.InvNo, invoiceModel.InvoiceItems.Count) == false)
            {
                MessageBox.Show("Delete Invoice " + txtInvoiceNo.Text + " failes!");
                return;
            }
            else
            {
                ResetInvoiceView();
                ResetInvoiceModel();
                btnQuite_Click(sender, e);
            }

        }

        private void dtgvItemList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dtgvItemList_RowHeaderMouseDoubleClick(sender, e);
        }

        private void dtgvItemList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow currentRow = dtgvItemList.CurrentRow;
            //MessageBox.Show(Convert.ToString(currentRow.Cells[0].Value));

            this.LoadItemsToDataView(currentRow);
            //txtItemProcedureCode.ReadOnly = true;
            //txtItemHMCode.ReadOnly = true;
            btnItemAdd.Enabled = false;
            btnItemDelete.Enabled = true;
            btnItemUpdate.Enabled = true;
            btnItemClean.Enabled = true;
        }

        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            
            //Validate data
            //The itme needs Procedure Code or HM Code, but not both
            long invNo = utility.StrToLong(txtInvoiceNo.Text);
            string procedureCode = txtItemProcedureCode.Text;
            string hmCode = txtItemHMCode.Text;
            if ((procedureCode=="" && hmCode == "" ) || procedureCode!="" && hmCode != "" )
            {
                MessageBox.Show("Invalide Procedure Code or H/M Code!");
                    return;
            }
            //Check if the invoice has invoice no.
            if (invNo == 0)
            {
                MessageBox.Show("Please create invoice first!");
                return;
            }
            
            //Need to check if the procedure code/HM code validate !!!
            //Need to check if the item is alrealdy in the invoice list
            //Update InvoiceModel
            //Update InvoiceModel
            invoiceModel.InvNo = invNo;
            InvoiceModel backupOne = this.invoiceModel.Clone();
            int rate = (int)utility.StrToLong(txtItemDiscountrate.Text);
            long price = utility.CurrencyToLong(txtItemPrice.Text);
            InvoiceItemModel item = new InvoiceItemModel()
            {
                InvNo = invoiceModel.InvNo,
                ProcedureCode = procedureCode,
                HMCode = hmCode,
                Price = price,
                DiscountRate = rate,
                LineTotal = price * (100 - rate) / 100
            };
            txtItemTotal.Text = utility.DisplayCurrency(item.LineTotal);
            //Add to InvoiceModel object
            if (invoiceModel.AddItem(item) == false)
            {
                MessageBox.Show(" Cannt add the invoice item. It is in the invoice.");
                return;
            }
            //Update InvoiceModel

            //invoiceModel.CalculateTotal();
            if (invoiceService.AddInvoiceItem(invoiceModel, item))
            {
                AddItemsToView(invoiceModel.InvoiceItems, invoiceModel.CurrentItem);
                //Update totals
                UpdateTotal();
                //txtItemProcedureCode.ReadOnly = true;
                //txtItemHMCode.ReadOnly = true;
                btnItemAdd.Enabled = false;
                btnItemDelete.Enabled = true;
                btnItemUpdate.Enabled = true;
                btnItemClean.Enabled = true;
            }
            else
            {
                invoiceModel = backupOne;
                MessageBox.Show("Add Invoice Item Failed!");
                //Need to rollback !!!
                //txtItemProcedureCode.ReadOnly = false;
                //txtItemHMCode.ReadOnly = false;
                btnItemAdd.Enabled = true;
                btnItemDelete.Enabled = false;
                btnItemUpdate.Enabled = false;
                btnItemClean.Enabled = true;
                return;
            }
            //This operation cannot change the procedure code or HM code
            //Otherwise, it needs to delete original item and add a new one.

            /*
            InvoiceModel backupOne = this.invoiceModel;
            InvoiceItemModel item = new InvoiceItemModel()
            {
                InvNo = invNo,
                ProcedureCode = procedureCode,
                HMCode = hmCode,
                Price = CurrencyToLong(txtItemPrice.Text),
                DiscountRate = int.Parse(txtItemDiscountrate.Text),
                LineTotal = CurrencyToLong(txtItemTotal.Text)
            };

            
                //Add to InvoiceModel object
               if( invoiceModel.AddItem(item) == false )
               {
                   MessageBox.Show(" Cannt add the invoice item. It is in the invoice.");
                       return;
               }

            
            if(invoiceService.AddInvoiceItem(invoiceModel, item) )
            {
                dtgvItemList.Rows.Add(item.ProcedureCode, item.HMCode, item.Price.ToString(), item.DiscountRate.ToString(), item.LineTotal.ToString());
                //Update totals
                UpdateTotal();
                txtItemProcedureCode.ReadOnly = true;
                txtItemHMCode.ReadOnly = true;
                btnItemAdd.Enabled = false;
                btnItemDelete.Enabled = true;
                btnItemUpdate.Enabled = true;
                btnItemClean.Enabled = true;
            }
            else
            {
                MessageBox.Show("Add Invoice Item Failed!");
                //Need to rollback !!!
                txtItemProcedureCode.ReadOnly = false;
                txtItemHMCode.ReadOnly = false;
                btnItemAdd.Enabled = true;
                btnItemDelete.Enabled = false;
                btnItemUpdate.Enabled = false;
                btnItemClean.Enabled = true;
                return;
            }
            */
        }

        private void UpdateTotal()
        {
            this.txtSubTotal.Text = utility.DisplayCurrency(invoiceModel.SubTotal);
            this.txtAmtPaid.Text = utility.DisplayCurrency(invoiceModel.AmountPaid);
            this.txtTotal.Text = utility.DisplayCurrency(invoiceModel.Total);
        }

        private void btnItemUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }
        /*
            InvoiceModel backupOne = this.invoiceModel;
            
            UpdateInvoiceItem();
            btnUpdate_Click(sender, e);
            //Validate data
            //Need to check if the procedure code/HM code validate !!!
            //Need to check if the item is alrealdy in the invoice list
            //Update InvoiceModel
           
           
                
            item.ProcedureCode = txtItemProcedureCode.Text;
            item.HMCode = txtItemHMCode.Text;
            item.Price = utility.CurrencyToLong(txtItemPrice.Text);
            item.DiscountRate = int.Parse(txtItemDiscountrate.Text);
            item.LineTotal = item.Price * (100 - item.DiscountRate) / 100; // CurrencyToLong(txtItemTotal.Text);
            txtItemTotal.Text = utility.DisplayCurrency(item.LineTotal);
            invoiceModel.CalculateTotal();
            if (invoiceService.UpDateInvoiceItem(invoiceModel, item))
            {
                AddItemsToView(invoiceModel.InvoiceItems, item);
                //Update totals
                UpdateTotal();
                txtItemProcedureCode.ReadOnly = true;
                txtItemHMCode.ReadOnly = true;
                btnItemAdd.Enabled = false;
                btnItemDelete.Enabled = true;
                btnItemUpdate.Enabled = true;
                btnItemClean.Enabled = true;
            }
            else
            {
                invoiceModel = backupOne;
                MessageBox.Show("Add Invoice Item Failed!");
                //Need to rollback !!!
                txtItemProcedureCode.ReadOnly = false;
                txtItemHMCode.ReadOnly = false;
                btnItemAdd.Enabled = true;
                btnItemDelete.Enabled = false;
                btnItemUpdate.Enabled = false;
                btnItemClean.Enabled = true;
                return;
            }
            //This operation cannot change the procedure code or HM code
            //Otherwise, it needs to delete original item and add a new one.
            
        }*/

        private void UpdateInvoiceItem()
        {
            InvoiceItemModel item = invoiceModel.CurrentItem;
            //Update InvoiceModel
            item.ProcedureCode = txtItemProcedureCode.Text;
            item.HMCode = txtItemHMCode.Text;
            item.Price = utility.CurrencyToLong(txtItemPrice.Text);
            item.DiscountRate = int.Parse(txtItemDiscountrate.Text);
            item.LineTotal = item.Price * (100 - item.DiscountRate) / 100; // CurrencyToLong(txtItemTotal.Text);
            txtItemTotal.Text = utility.DisplayCurrency(item.LineTotal);
            //invoiceModel.CalculateTotal();
            AddItemsToView(invoiceModel.InvoiceItems, item);
            //UpdateTotal();
        }

        private void ResetInvoiceItem()
        {
            //txtItemProcedureCode.ReadOnly = false;
           // txtItemHMCode.ReadOnly = false;
            txtItemProcedureCode.Text = "";
            txtItemHMCode.Text = "";
            txtItemDiscountrate.Text = "";
            txtItemPrice.Text = "";
            txtItemPrice.Text = "";
            txtItemTotal.Text = "";

            btnItemAdd.Enabled = true;
            btnItemDelete.Enabled = false;
            btnItemUpdate.Enabled = false;
            btnItemClean.Enabled = false;
            if(invoiceModel.CurrentItem != null )
                invoiceModel.CurrentItem.Reset();
        }

        private void btnItemClean_Click(object sender, EventArgs e)
        {
           ResetInvoiceItem();
        }


        private void btnItemDelete_Click(object sender, EventArgs e)
        {
            //Backup the invoice.
            InvoiceModel backupInvoice = invoiceModel.Clone();
            InvoiceItemModel item = new InvoiceItemModel()
            {
                InvNo = invoiceModel.InvNo,
                ProcedureCode = txtItemProcedureCode.Text,
                HMCode = txtItemHMCode.Text,
                Price = utility.CurrencyToLong(txtItemPrice.Text),
                DiscountRate = utility.StrToDisRate(txtItemDiscountrate.Text),
                LineTotal = utility.CurrencyToLong(txtItemTotal.Text)
            };


            invoiceModel.RemoveItem(item);
            


            if (invoiceService.DeleteInvoiceItem(invoiceModel, item))
            {
                AddItemsToView(invoiceModel.InvoiceItems, null);
                //Update totals
                UpdateTotal();
                ResetInvoiceItem();
                invoiceModel.SelfModified = false;
                invoiceModel.ItemsModified = false;
            }
            else
            {
                MessageBox.Show("Add Invoice Item Failed!");
                //Need to rollback !!!
                invoiceModel = backupInvoice;
                return;
            }
        }

        private void AddItemsToView(List<InvoiceItemModel> ilist, InvoiceItemModel currentItem)
        {           
            dtgvItemList.Rows.Clear();
            int itemCount = ilist.Count;
            if (itemCount > 0)
            {
                int currentIndex = itemCount-1;
                for (int i = 0; i < itemCount; i++) //InvoiceItemModel invoiceItem in ilist )
                {
                    InvoiceItemModel invoiceItem = ilist[i];
                    dtgvItemList.Rows.Add(invoiceItem.ProcedureCode, invoiceItem.HMCode,
                        utility.DisplayCurrency(invoiceItem.Price), invoiceItem.DiscountRate.ToString(),
                        utility.DisplayCurrency(invoiceItem.LineTotal));
                    if (currentItem!= null && !currentItem.isNone() && invoiceItem == currentItem)
                        currentIndex = i;
                }
               
               dtgvItemList.CurrentCell = dtgvItemList.Rows[currentIndex].Cells[0];
            }
            else
                dtgvItemList.Rows.Clear();
        }

       /* private void btn4UpdateInv_Click(object sender, EventArgs e)
        {
            // if (this.ValidateUpdate())
            // {
            // Assign the values to the model
            InvoiceModel invoiceModel = CreateInvoiceModel();


            var flag = this.customerService.UpdateInvoice(invoiceModel);

            if (flag)
            {
                //Update account        
                 DataTable customer = this.customerService.UpdateAccount(contactModel.CustomerID.ToString(), "", " Or");
                 if (customer != null && customer.Rows.Count > 0)
                 {
                     txt3Name.Text = customer.Rows[0][1].ToString() + " " + customer.Rows[0][1].ToString();
                 } 
                ;
            }
            else
            {
                MessageBox.Show(
               "Updated the invoice failed!",
               Resources.Registration_Error_Message_Title,
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            }
            else
            {
                MessageBox.Show(
                    this.errorMessage,
                    Resources.Registration_Error_Message_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        } */

        /*private InvoiceModel CreateInvoiceModel()
        {
            InvoiceModel invoiceModel = new InvoiceModel()
            {
                CustomerID = long.Parse(txt4CustomerID.Text.ToString()),
                InvNo = long.Parse(this.txt4InvNo.Text),
                InvDate = this.dtInvDate.Value,
                ProcedureCode = this.txt4ProcedureCode.Text.Trim(),
                HMCode = this.txt4HMCode.Text.Trim(),

                PaymentMethod = (PaymentMethods)cmb4PayMethod.SelectedIndex,

                CardType = (CardTypes)cmb4CardType.SelectedIndex,
                CardNo = this.txt4CardNo.Text.Trim(),
                ExpDate = dt4ExpDate.Value,
                SubTotal = long.Parse(txt4SubTotal.Text.Trim()),
                DiscountRate = long.Parse(txt4DiscRate.Text.Trim()),
                AmountPaid = long.Parse(txt4AmtPaid.Text.Trim()),
                Balance = long.Parse(txt4Balance.Text.Trim()),
                Total = long.Parse(txt4Total.Text.Trim())
            };
            return invoiceModel;
        } */

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {

            // Assign the values to the model           
            Excel.Worksheet invoiceReport = this.invoiceService.FilloutInvoiceReport(invoiceModel);

            if (invoiceReport != null)
            {
                invoiceReport.PrintPreview(Type.Missing);              
            }

            //invoiceReport.Deactivate();
            //invoiceReport.Close(Type.Missing, Type.Missing, Type.Missing);
            this.invoiceService.CloseExcel();

        }

        private void lstPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstPaymentMethod.SelectedIndex <=2 )
            {
                lstCardType.SelectedIndex = 0;
                lstCardType.Enabled = false;
                txtCardNo.Text = "";
                txtCardNo.ReadOnly = true;
                dtpExpireDate.Value = DateTime.Today;
                dtpExpireDate.Enabled = false;
            }
            else
            {
                lstCardType.Enabled = true;
                txtCardNo.Text = "";
                txtCardNo.ReadOnly = false;
                dtpExpireDate.Value = DateTime.Today;
                dtpExpireDate.Enabled = true;
            }
        }

        private void lblItemProcedureCode_Click(object sender, EventArgs e)
        {
            codePickuprStatus = 1; //Procedure Code Pickup
            var procedureCodeEditor = new frmCodePickup(this); //, lst62ProcedureCodes);
            //frmCodePickupEditor.Closing += frmCodePickup.frmCodePickup_Closing;
            procedureCodeEditor.Show();
            procedureCodeEditor.BringToFront();
        }

        /// <summary>
        /// Get List of code string
        /// </summary>
        /// <param name=""></param>
        /// <returns>A List of code string</returns>
        public DataTable GetCodeTable()
        {
            if( codePickuprStatus == 1 ) //Procedure Code
            {
                return manage.CustomerServiceObj.LoadProcedureCodes();
            }
            else if( codePickuprStatus == 2 ) //HM Code
                return  manage.CustomerServiceObj.LoadHMCodes();
            else
                return null;
        }


        /// <summary>
        /// Get List of selected code strings
        /// </summary>
        /// <param name=""></param>
        /// <returns>A List of code strings</returns>
        public List<string> GetSelectedCodes()
        {
            List<string> codeList = new List<string>();
            if (codePickuprStatus == 1)
                codeList.Add(txtItemProcedureCode.Text);
            else if (codePickuprStatus == 2)
                codeList.Add(txtItemHMCode.Text);
            return codeList;

        }

        /// <summary>
        /// Populate procedure or HM codes to the target object
        /// </summary>
        /// <param name=""></param>
        /// <returns>void</returns>
        public void PopulateCodes(DataGridView dataGrid)
        {
            if( codePickuprStatus == 1) //Procedure Code
            {
                if( dataGrid.Rows.Count >= 1 ) //Only one is allowed
                {
                    txtItemProcedureCode.Text = dataGrid.Rows[0].Cells[0].Value.ToString();
                    txtItemHMCode.Text = "";
                    txtItemPrice.Text = dataGrid.Rows[0].Cells[2].Value.ToString();
                }
                else 
                {
                    txtItemProcedureCode.Text = "";
                    txtItemHMCode.Text = "";
                    txtItemPrice.Text = "";
                }
            }
            else if( codePickuprStatus == 2 ) //H/M Code
            {
                if( dataGrid.Rows.Count >= 1 ) //Only one is allowed
                {
                    txtItemHMCode.Text = dataGrid.Rows[0].Cells[0].Value.ToString();
                    txtItemProcedureCode.Text = "";
                    txtItemPrice.Text = dataGrid.Rows[0].Cells[2].Value.ToString();
                }
                else 
                {
                    txtItemProcedureCode.Text = "";
                    txtItemHMCode.Text = "";
                    txtItemPrice.Text = "";
                }
            }
            else
            {
                 txtItemProcedureCode.Text = "";
                 txtItemHMCode.Text = "";
                 txtItemPrice.Text = "";
            }           
        }

        

        private void lblItemHMCode_Click(object sender, EventArgs e)
        {
            codePickuprStatus = 2; //H/M Code  Pickup
            var hmCodeEditor = new frmHMCodePickup(this); 
            hmCodeEditor.Show();
            hmCodeEditor.BringToFront();
        }        
        /*private void btn4Print_Click(object sender, EventArgs e)
        {
            // Assign the values to the model
            InvoiceModel invoiceModel = CreateInvoiceModel();


            Excel.Worksheet invoiceReport = this.customerService.FilloutInvoiceReport(invoiceModel);

            if (invoiceReport != null)
            {
                invoiceReport.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                       Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                ws.PrintOut(
     Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
     Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            }

            //invoiceReport.Deactivate();
            //invoiceReport.Close(Type.Missing, Type.Missing, Type.Missing);
            this.customerService.CloseExcel();
        } */
    }
}
