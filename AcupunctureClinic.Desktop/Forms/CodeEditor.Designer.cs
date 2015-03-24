namespace AcupunctureClinic.Desktop.Forms
{
    partial class frmCodeEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtgvCodeList = new System.Windows.Forms.DataGridView();
            this.Procedure_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Procedure_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.btnQuite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCodeList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(637, 233);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(130, 22);
            this.txtPrice.TabIndex = 118;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(637, 190);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(130, 22);
            this.txtName.TabIndex = 117;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(637, 151);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(130, 22);
            this.txtCode.TabIndex = 116;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(492, 236);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(110, 17);
            this.lblPrice.TabIndex = 115;
            this.lblPrice.Text = "Procedure Price";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(492, 197);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(115, 17);
            this.lblName.TabIndex = 114;
            this.lblName.Text = "Procedure Name";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(492, 156);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(111, 17);
            this.lblCode.TabIndex = 113;
            this.lblCode.Text = "Procedure Code";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(636, 32);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 26);
            this.btnDelete.TabIndex = 112;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(544, 69);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 26);
            this.btnAdd.TabIndex = 111;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(637, 68);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 27);
            this.btnUpdate.TabIndex = 110;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(btnUpdate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(544, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 109;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(btnSearch_Click);
            // 
            // dtgvCodeList
            // 
            this.dtgvCodeList.AllowUserToAddRows = false;
            this.dtgvCodeList.AllowUserToOrderColumns = true;
            this.dtgvCodeList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvCodeList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvCodeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCodeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Procedure_Code,
            this.Procedure_Name,
            this.Price});
            this.dtgvCodeList.Location = new System.Drawing.Point(56, 73);
            this.dtgvCodeList.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvCodeList.Name = "dtgvCodeList";
            this.dtgvCodeList.ReadOnly = true;
            this.dtgvCodeList.RowTemplate.Height = 24;
            this.dtgvCodeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvCodeList.Size = new System.Drawing.Size(402, 453);
            this.dtgvCodeList.TabIndex = 108;
            this.dtgvCodeList.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgvCodeList_RowHeaderMouseDoubleClick);
            // 
            // Procedure_Code
            // 
            this.Procedure_Code.HeaderText = "Procedure Code";
            this.Procedure_Code.Name = "Procedure_Code";
            this.Procedure_Code.ReadOnly = true;
            this.Procedure_Code.Width = 120;
            // 
            // Procedure_Name
            // 
            this.Procedure_Name.HeaderText = "Procedure Name";
            this.Procedure_Name.Name = "Procedure_Name";
            this.Procedure_Name.ReadOnly = true;
            this.Procedure_Name.Width = 120;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 120;
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListTitle.Location = new System.Drawing.Point(116, 13);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(261, 31);
            this.lblListTitle.TabIndex = 107;
            this.lblListTitle.Text = "Procedure Code List";
            // 
            // btnQuite
            // 
            this.btnQuite.Location = new System.Drawing.Point(600, 355);
            this.btnQuite.Name = "btnQuite";
            this.btnQuite.Size = new System.Drawing.Size(75, 26);
            this.btnQuite.TabIndex = 119;
            this.btnQuite.Text = "Quite";
            this.btnQuite.UseVisualStyleBackColor = true;
            this.btnQuite.Click += new System.EventHandler(this.btnQuite_Click);
            // 
            // frmCodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 538);
            this.Controls.Add(this.btnQuite);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtgvCodeList);
            this.Controls.Add(this.lblListTitle);
            this.Name = "frmCodeEditor";
            this.Text = "Code Setting";
            this.FormClosing += frmCodeEditor_FormClosing;
           // this.Exit += new System.EventHandler(this.frmCodeEditor_Closing);   //CancelEventHandler(frmCodeEditor_Closing);
            
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCodeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        protected System.Windows.Forms.TextBox txtPrice;
        protected System.Windows.Forms.TextBox txtName;
        protected System.Windows.Forms.TextBox txtCode;
        protected System.Windows.Forms.Label lblPrice;
        protected System.Windows.Forms.Label lblName;
        protected System.Windows.Forms.Label lblCode;
        protected System.Windows.Forms.Button btnDelete;
        protected System.Windows.Forms.Button btnAdd;
        protected System.Windows.Forms.Button btnUpdate;
        protected System.Windows.Forms.Button btnSearch;
        protected System.Windows.Forms.DataGridView dtgvCodeList;
        protected System.Windows.Forms.DataGridViewTextBoxColumn Procedure_Code;
        protected System.Windows.Forms.DataGridViewTextBoxColumn Procedure_Name;
        protected System.Windows.Forms.DataGridViewTextBoxColumn Price;
        protected System.Windows.Forms.Label lblListTitle;
        protected System.Windows.Forms.Button btnQuite;
    }
}