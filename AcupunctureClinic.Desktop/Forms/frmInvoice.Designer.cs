namespace AcupunctureClinic.Desktop.Forms
{
    partial class frmInvoice 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtItemPrice = new System.Windows.Forms.TextBox();
            this.txtItemHMCode = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtgvItemList = new System.Windows.Forms.DataGridView();
            this.ProcedureCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HMCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnItemClean = new System.Windows.Forms.Button();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpInvDate = new System.Windows.Forms.DateTimePicker();
            this.btnQuite = new System.Windows.Forms.Button();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btn4Print = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAmtPaid = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpExpireDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.lstCardType = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstPaymentMethod = new System.Windows.Forms.ListBox();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtItemProcedureCode = new System.Windows.Forms.TextBox();
            this.txtItemDiscountrate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtItemTotal = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnItemAdd = new System.Windows.Forms.Button();
            this.btnItemDelete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblItemHMCode = new System.Windows.Forms.Label();
            this.lblItemProcedureCode = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnItemUpdate = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvItemList)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtItemPrice
            // 
            this.txtItemPrice.Location = new System.Drawing.Point(193, 151);
            this.txtItemPrice.Name = "txtItemPrice";
            this.txtItemPrice.ReadOnly = true;
            this.txtItemPrice.Size = new System.Drawing.Size(130, 22);
            this.txtItemPrice.TabIndex = 131;
            // 
            // txtItemHMCode
            // 
            this.txtItemHMCode.Location = new System.Drawing.Point(193, 123);
            this.txtItemHMCode.Name = "txtItemHMCode";
            this.txtItemHMCode.ReadOnly = true;
            this.txtItemHMCode.Size = new System.Drawing.Size(130, 22);
            this.txtItemHMCode.TabIndex = 130;
            this.txtItemHMCode.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(156, 50);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(130, 22);
            this.txtCustomerName.TabIndex = 129;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(312, 174);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(73, 17);
            this.lblPrice.TabIndex = 128;
            this.lblPrice.Text = "Unit Price:";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(312, 48);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(81, 17);
            this.lblCode.TabIndex = 126;
            this.lblCode.Text = "Code Type:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(704, 45);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 26);
            this.btnDelete.TabIndex = 125;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(612, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 26);
            this.btnAdd.TabIndex = 124;
            this.btnAdd.Text = "New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(705, 81);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 27);
            this.btnUpdate.TabIndex = 123;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(612, 81);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 122;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtgvItemList
            // 
            this.dtgvItemList.AllowUserToAddRows = false;
            this.dtgvItemList.AllowUserToOrderColumns = true;
            this.dtgvItemList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcedureCode,
            this.HMCode,
            this.Price,
            this.DiscountRate,
            this.LineTotal});
            this.dtgvItemList.Location = new System.Drawing.Point(42, 203);
            this.dtgvItemList.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvItemList.Name = "dtgvItemList";
            this.dtgvItemList.ReadOnly = true;
            this.dtgvItemList.RowTemplate.Height = 24;
            this.dtgvItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvItemList.Size = new System.Drawing.Size(698, 176);
            this.dtgvItemList.TabIndex = 121;
            this.dtgvItemList.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgvItemList_RowHeaderMouseClick);
            this.dtgvItemList.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgvItemList_RowHeaderMouseDoubleClick);
            // 
            // ProcedureCode
            // 
            this.ProcedureCode.HeaderText = "Procedure Code";
            this.ProcedureCode.Name = "ProcedureCode";
            this.ProcedureCode.ReadOnly = true;
            // 
            // HMCode
            // 
            this.HMCode.HeaderText = "H/M Code";
            this.HMCode.Name = "HMCode";
            this.HMCode.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 120;
            // 
            // DiscountRate
            // 
            this.DiscountRate.HeaderText = "Discount Rate";
            this.DiscountRate.Name = "DiscountRate";
            this.DiscountRate.ReadOnly = true;
            // 
            // LineTotal
            // 
            this.LineTotal.HeaderText = "Line Total";
            this.LineTotal.Name = "LineTotal";
            this.LineTotal.ReadOnly = true;
            this.LineTotal.Width = 150;
            // 
            // btnItemClean
            // 
            this.btnItemClean.Location = new System.Drawing.Point(263, 256);
            this.btnItemClean.Name = "btnItemClean";
            this.btnItemClean.Size = new System.Drawing.Size(60, 26);
            this.btnItemClean.TabIndex = 132;
            this.btnItemClean.Text = "Clean";
            this.btnItemClean.UseVisualStyleBackColor = true;
            this.btnItemClean.Click += new System.EventHandler(this.btnItemClean_Click);
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListTitle.Location = new System.Drawing.Point(292, 168);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(117, 31);
            this.lblListTitle.TabIndex = 120;
            this.lblListTitle.Text = "Item List";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpInvDate);
            this.panel1.Controls.Add(this.btnQuite);
            this.panel1.Controls.Add(this.btnPrintPreview);
            this.panel1.Controls.Add(this.btn4Print);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtInvoiceNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCustomerID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtCustomerName);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Controls.Add(this.lblCode);
            this.panel1.Location = new System.Drawing.Point(36, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 135);
            this.panel1.TabIndex = 133;
            // 
            // dtpInvDate
            // 
            this.dtpInvDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvDate.Location = new System.Drawing.Point(440, 86);
            this.dtpInvDate.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.dtpInvDate.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpInvDate.Name = "dtpInvDate";
            this.dtpInvDate.Size = new System.Drawing.Size(130, 22);
            this.dtpInvDate.TabIndex = 152;
            this.dtpInvDate.Value = new System.DateTime(2015, 5, 4, 0, 0, 0, 0);
            // 
            // btnQuite
            // 
            this.btnQuite.Location = new System.Drawing.Point(808, 48);
            this.btnQuite.Name = "btnQuite";
            this.btnQuite.Size = new System.Drawing.Size(75, 26);
            this.btnQuite.TabIndex = 151;
            this.btnQuite.Text = "Quite";
            this.btnQuite.UseVisualStyleBackColor = true;
            this.btnQuite.Click += new System.EventHandler(this.btnQuite_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrintPreview.Location = new System.Drawing.Point(934, 44);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(100, 27);
            this.btnPrintPreview.TabIndex = 150;
            this.btnPrintPreview.Text = "Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btn4PrintPreview_Click);
            // 
            // btn4Print
            // 
            this.btn4Print.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn4Print.Location = new System.Drawing.Point(934, 81);
            this.btn4Print.Margin = new System.Windows.Forms.Padding(4);
            this.btn4Print.Name = "btn4Print";
            this.btn4Print.Size = new System.Drawing.Size(100, 27);
            this.btn4Print.TabIndex = 149;
            this.btn4Print.Text = "Print";
            this.btn4Print.UseVisualStyleBackColor = false;
            this.btn4Print.Click += new System.EventHandler(this.btn4Print_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 141;
            this.label5.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 139;
            this.label4.Text = "Invoice No:";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(156, 91);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(130, 22);
            this.txtInvoiceNo.TabIndex = 138;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 137;
            this.label3.Text = "Customer ID:";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(440, 48);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(130, 22);
            this.txtCustomerID.TabIndex = 136;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 135;
            this.label2.Text = "Customer Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(415, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 31);
            this.label1.TabIndex = 134;
            this.label1.Text = "Invoice  Editor";
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.txtTotal);
            this.pnlTotal.Controls.Add(this.label12);
            this.pnlTotal.Controls.Add(this.txtAmtPaid);
            this.pnlTotal.Controls.Add(this.label11);
            this.pnlTotal.Controls.Add(this.txtSubTotal);
            this.pnlTotal.Controls.Add(this.label10);
            this.pnlTotal.Controls.Add(this.label9);
            this.pnlTotal.Controls.Add(this.dtpExpireDate);
            this.pnlTotal.Controls.Add(this.label8);
            this.pnlTotal.Controls.Add(this.lstCardType);
            this.pnlTotal.Controls.Add(this.label7);
            this.pnlTotal.Controls.Add(this.lstPaymentMethod);
            this.pnlTotal.Controls.Add(this.txtCardNo);
            this.pnlTotal.Controls.Add(this.label6);
            this.pnlTotal.Location = new System.Drawing.Point(36, 387);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(704, 92);
            this.pnlTotal.TabIndex = 134;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(576, 65);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(122, 22);
            this.txtTotal.TabIndex = 144;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(525, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 17);
            this.label12.TabIndex = 143;
            this.label12.Text = "Total:";
            // 
            // txtAmtPaid
            // 
            this.txtAmtPaid.Location = new System.Drawing.Point(576, 37);
            this.txtAmtPaid.Name = "txtAmtPaid";
            this.txtAmtPaid.Size = new System.Drawing.Size(122, 22);
            this.txtAmtPaid.TabIndex = 142;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(478, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 17);
            this.label11.TabIndex = 141;
            this.label11.Text = "Amount Paid:";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(576, 10);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(122, 22);
            this.txtSubTotal.TabIndex = 140;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(497, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 139;
            this.label10.Text = "Sub Total:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(272, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 138;
            this.label9.Text = "Expire Date:";
            // 
            // dtpExpireDate
            // 
            this.dtpExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpireDate.Location = new System.Drawing.Point(272, 58);
            this.dtpExpireDate.MaxDate = new System.DateTime(2030, 1, 1, 0, 0, 0, 0);
            this.dtpExpireDate.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpExpireDate.Name = "dtpExpireDate";
            this.dtpExpireDate.Size = new System.Drawing.Size(128, 22);
            this.dtpExpireDate.TabIndex = 137;
            this.dtpExpireDate.Value = new System.DateTime(2015, 5, 4, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 136;
            this.label8.Text = "Card No:";
            // 
            // lstCardType
            // 
            this.lstCardType.FormattingEnabled = true;
            this.lstCardType.ItemHeight = 16;
            this.lstCardType.Items.AddRange(new object[] {
            "None",
            "Master",
            "Visa",
            "Discover",
            "AmExpr"});
            this.lstCardType.Location = new System.Drawing.Point(302, 13);
            this.lstCardType.Name = "lstCardType";
            this.lstCardType.Size = new System.Drawing.Size(71, 20);
            this.lstCardType.TabIndex = 135;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(218, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 134;
            this.label7.Text = "Card Type:";
            // 
            // lstPaymentMethod
            // 
            this.lstPaymentMethod.FormattingEnabled = true;
            this.lstPaymentMethod.ItemHeight = 16;
            this.lstPaymentMethod.Items.AddRange(new object[] {
            "None",
            "Cash",
            "Check",
            "Debit",
            "Credit"});
            this.lstPaymentMethod.Location = new System.Drawing.Point(122, 13);
            this.lstPaymentMethod.Name = "lstPaymentMethod";
            this.lstPaymentMethod.Size = new System.Drawing.Size(71, 20);
            this.lstPaymentMethod.TabIndex = 133;
            this.lstPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.lstPaymentMethod_SelectedIndexChanged);
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(6, 60);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(238, 22);
            this.txtCardNo.TabIndex = 132;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 17);
            this.label6.TabIndex = 131;
            this.label6.Text = "Payment Method:";
            // 
            // txtItemProcedureCode
            // 
            this.txtItemProcedureCode.Location = new System.Drawing.Point(193, 94);
            this.txtItemProcedureCode.Name = "txtItemProcedureCode";
            this.txtItemProcedureCode.ReadOnly = true;
            this.txtItemProcedureCode.Size = new System.Drawing.Size(130, 22);
            this.txtItemProcedureCode.TabIndex = 136;
            // 
            // txtItemDiscountrate
            // 
            this.txtItemDiscountrate.Location = new System.Drawing.Point(193, 175);
            this.txtItemDiscountrate.Name = "txtItemDiscountrate";
            this.txtItemDiscountrate.Size = new System.Drawing.Size(130, 22);
            this.txtItemDiscountrate.TabIndex = 141;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(48, 180);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 17);
            this.label15.TabIndex = 140;
            this.label15.Text = "Discount Rate:";
            // 
            // txtItemTotal
            // 
            this.txtItemTotal.Location = new System.Drawing.Point(193, 202);
            this.txtItemTotal.Name = "txtItemTotal";
            this.txtItemTotal.ReadOnly = true;
            this.txtItemTotal.Size = new System.Drawing.Size(130, 22);
            this.txtItemTotal.TabIndex = 143;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(48, 207);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 17);
            this.label16.TabIndex = 142;
            this.label16.Text = "Total:";
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Location = new System.Drawing.Point(39, 256);
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.Size = new System.Drawing.Size(60, 26);
            this.btnItemAdd.TabIndex = 144;
            this.btnItemAdd.Text = "Add";
            this.btnItemAdd.UseVisualStyleBackColor = true;
            this.btnItemAdd.Click += new System.EventHandler(this.btnItemAdd_Click);
            // 
            // btnItemDelete
            // 
            this.btnItemDelete.Location = new System.Drawing.Point(192, 256);
            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.Size = new System.Drawing.Size(60, 26);
            this.btnItemDelete.TabIndex = 145;
            this.btnItemDelete.Text = "Delete";
            this.btnItemDelete.UseVisualStyleBackColor = true;
            this.btnItemDelete.Click += new System.EventHandler(this.btnItemDelete_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblItemHMCode);
            this.panel2.Controls.Add(this.lblItemProcedureCode);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.btnItemUpdate);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.btnItemDelete);
            this.panel2.Controls.Add(this.btnItemAdd);
            this.panel2.Controls.Add(this.txtItemProcedureCode);
            this.panel2.Controls.Add(this.txtItemTotal);
            this.panel2.Controls.Add(this.txtItemHMCode);
            this.panel2.Controls.Add(this.txtItemDiscountrate);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txtItemPrice);
            this.panel2.Controls.Add(this.btnItemClean);
            this.panel2.Location = new System.Drawing.Point(747, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 326);
            this.panel2.TabIndex = 135;
            // 
            // lblItemHMCode
            // 
            this.lblItemHMCode.AutoSize = true;
            this.lblItemHMCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemHMCode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblItemHMCode.Location = new System.Drawing.Point(48, 127);
            this.lblItemHMCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemHMCode.Name = "lblItemHMCode";
            this.lblItemHMCode.Size = new System.Drawing.Size(76, 18);
            this.lblItemHMCode.TabIndex = 149;
            this.lblItemHMCode.Text = "H/M Code";
            this.lblItemHMCode.Click += new System.EventHandler(this.lblItemHMCode_Click);
            // 
            // lblItemProcedureCode
            // 
            this.lblItemProcedureCode.AutoSize = true;
            this.lblItemProcedureCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemProcedureCode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblItemProcedureCode.Location = new System.Drawing.Point(48, 98);
            this.lblItemProcedureCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemProcedureCode.Name = "lblItemProcedureCode";
            this.lblItemProcedureCode.Size = new System.Drawing.Size(117, 18);
            this.lblItemProcedureCode.TabIndex = 148;
            this.lblItemProcedureCode.Text = "Procedure Code";
            this.lblItemProcedureCode.Click += new System.EventHandler(this.lblItemProcedureCode_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(106, 33);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(144, 31);
            this.label21.TabIndex = 146;
            this.label21.Text = "Item Detail";
            // 
            // btnItemUpdate
            // 
            this.btnItemUpdate.Location = new System.Drawing.Point(112, 256);
            this.btnItemUpdate.Name = "btnItemUpdate";
            this.btnItemUpdate.Size = new System.Drawing.Size(60, 26);
            this.btnItemUpdate.TabIndex = 147;
            this.btnItemUpdate.Text = "Update";
            this.btnItemUpdate.UseVisualStyleBackColor = true;
            this.btnItemUpdate.Click += new System.EventHandler(this.btnItemUpdate_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(48, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 17);
            this.label13.TabIndex = 146;
            this.label13.Text = "Price:";
            // 
            // frmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 571);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtgvItemList);
            this.Controls.Add(this.lblListTitle);
            this.Name = "frmInvoice";
            this.Text = "Invoice Editor";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvItemList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox txtItemPrice;
        protected System.Windows.Forms.TextBox txtItemHMCode;
        protected System.Windows.Forms.TextBox txtCustomerName;
        protected System.Windows.Forms.Label lblPrice;
        protected System.Windows.Forms.Label lblCode;
        protected System.Windows.Forms.Button btnDelete;
        protected System.Windows.Forms.Button btnAdd;
        protected System.Windows.Forms.Button btnUpdate;
        protected System.Windows.Forms.Button btnSearch;
        protected System.Windows.Forms.DataGridView dtgvItemList;
        protected System.Windows.Forms.Button btnItemClean;
        protected System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox txtInvoiceNo;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox txtCustomerID;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTotal;
        protected System.Windows.Forms.TextBox txtTotal;
        protected System.Windows.Forms.Label label12;
        protected System.Windows.Forms.TextBox txtAmtPaid;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox txtSubTotal;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpExpireDate;
        protected System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstCardType;
        protected System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstPaymentMethod;
        protected System.Windows.Forms.TextBox txtCardNo;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.TextBox txtItemProcedureCode;
        protected System.Windows.Forms.TextBox txtItemDiscountrate;
        protected System.Windows.Forms.Label label15;
        protected System.Windows.Forms.TextBox txtItemTotal;
        protected System.Windows.Forms.Label label16;
        protected System.Windows.Forms.Button btnItemAdd;
        protected System.Windows.Forms.Button btnItemDelete;
        protected System.Windows.Forms.Button btnQuite;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btn4Print;
        private System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.Label label21;
        protected System.Windows.Forms.Button btnItemUpdate;
        private System.Windows.Forms.DateTimePicker dtpInvDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcedureCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn HMCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineTotal;
        private System.Windows.Forms.Label lblItemHMCode;
        private System.Windows.Forms.Label lblItemProcedureCode;
    }
}