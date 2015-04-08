namespace AcupunctureClinic.Desktop.Forms
{
    partial class frmCodePickup
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
            this.lblSelectedCodeList = new System.Windows.Forms.Label();
            this.btn1Add = new System.Windows.Forms.Button();
            this.btn1Remove = new System.Windows.Forms.Button();
            this.lblCodeList = new System.Windows.Forms.Label();
            this.btn1Done = new System.Windows.Forms.Button();
            this.btn1Quite = new System.Windows.Forms.Button();
            this.btn1Clear = new System.Windows.Forms.Button();
            this.dtgvCodes = new System.Windows.Forms.DataGridView();
            this.dtgvSelectedCodes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSelectedCodes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelectedCodeList
            // 
            this.lblSelectedCodeList.AutoSize = true;
            this.lblSelectedCodeList.Location = new System.Drawing.Point(50, 24);
            this.lblSelectedCodeList.Name = "lblSelectedCodeList";
            this.lblSelectedCodeList.Size = new System.Drawing.Size(181, 17);
            this.lblSelectedCodeList.TabIndex = 1;
            this.lblSelectedCodeList.Text = "Selected Procedure Codes:";
            // 
            // btn1Add
            // 
            this.btn1Add.Location = new System.Drawing.Point(468, 107);
            this.btn1Add.Name = "btn1Add";
            this.btn1Add.Size = new System.Drawing.Size(75, 23);
            this.btn1Add.TabIndex = 3;
            this.btn1Add.Text = "<- Add";
            this.btn1Add.UseVisualStyleBackColor = true;
            this.btn1Add.Click += new System.EventHandler(this.btn1Add_Click);
            // 
            // btn1Remove
            // 
            this.btn1Remove.Location = new System.Drawing.Point(468, 167);
            this.btn1Remove.Name = "btn1Remove";
            this.btn1Remove.Size = new System.Drawing.Size(95, 23);
            this.btn1Remove.TabIndex = 4;
            this.btn1Remove.Text = "Remove ->";
            this.btn1Remove.UseVisualStyleBackColor = true;
            this.btn1Remove.Click += new System.EventHandler(this.btn1Remove_Click);
            // 
            // lblCodeList
            // 
            this.lblCodeList.AutoSize = true;
            this.lblCodeList.Location = new System.Drawing.Point(414, 24);
            this.lblCodeList.Name = "lblCodeList";
            this.lblCodeList.Size = new System.Drawing.Size(122, 17);
            this.lblCodeList.TabIndex = 5;
            this.lblCodeList.Text = "Procedure Codes:";
            // 
            // btn1Done
            // 
            this.btn1Done.Location = new System.Drawing.Point(64, 368);
            this.btn1Done.Name = "btn1Done";
            this.btn1Done.Size = new System.Drawing.Size(75, 23);
            this.btn1Done.TabIndex = 6;
            this.btn1Done.Text = "Done";
            this.btn1Done.UseVisualStyleBackColor = true;
            this.btn1Done.Click += new System.EventHandler(this.btn1Done_Click);
            // 
            // btn1Quite
            // 
            this.btn1Quite.Location = new System.Drawing.Point(336, 368);
            this.btn1Quite.Name = "btn1Quite";
            this.btn1Quite.Size = new System.Drawing.Size(75, 23);
            this.btn1Quite.TabIndex = 7;
            this.btn1Quite.Text = "Quite";
            this.btn1Quite.UseVisualStyleBackColor = true;
            this.btn1Quite.Click += new System.EventHandler(this.btn1Quite_Click);
            // 
            // btn1Clear
            // 
            this.btn1Clear.Location = new System.Drawing.Point(189, 368);
            this.btn1Clear.Name = "btn1Clear";
            this.btn1Clear.Size = new System.Drawing.Size(75, 23);
            this.btn1Clear.TabIndex = 10;
            this.btn1Clear.Text = "Clear";
            this.btn1Clear.UseVisualStyleBackColor = true;
            this.btn1Clear.Click += new System.EventHandler(this.btn1Clear_Click);
            // 
            // dtgvCodes
            // 
            this.dtgvCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCodes.Location = new System.Drawing.Point(602, 81);
            this.dtgvCodes.Name = "dtgvCodes";
            this.dtgvCodes.RowTemplate.Height = 24;
            this.dtgvCodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvCodes.Size = new System.Drawing.Size(347, 356);
            this.dtgvCodes.TabIndex = 11;
            // 
            // dtgvSelectedCodes
            // 
            this.dtgvSelectedCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvSelectedCodes.Location = new System.Drawing.Point(64, 81);
            this.dtgvSelectedCodes.Name = "dtgvSelectedCodes";
            this.dtgvSelectedCodes.RowTemplate.Height = 24;
            this.dtgvSelectedCodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvSelectedCodes.Size = new System.Drawing.Size(347, 152);
            this.dtgvSelectedCodes.TabIndex = 12;
            // 
            // frmCodePickup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 459);
            this.Controls.Add(this.dtgvSelectedCodes);
            this.Controls.Add(this.dtgvCodes);
            this.Controls.Add(this.btn1Clear);
            this.Controls.Add(this.btn1Quite);
            this.Controls.Add(this.btn1Done);
            this.Controls.Add(this.lblCodeList);
            this.Controls.Add(this.btn1Remove);
            this.Controls.Add(this.btn1Add);
            this.Controls.Add(this.lblSelectedCodeList);
            this.Location = new System.Drawing.Point(400, 200);
            this.Name = "frmCodePickup";
            this.Text = "Procedure Code Editor";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSelectedCodes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lblSelectedCodeList;
        private System.Windows.Forms.Button btn1Add;
        private System.Windows.Forms.Button btn1Remove;
        protected System.Windows.Forms.Label lblCodeList;
        private System.Windows.Forms.Button btn1Done;
        private System.Windows.Forms.Button btn1Quite;
        private System.Windows.Forms.Button btn1Clear;
        private System.Windows.Forms.DataGridView dtgvCodes;
        private System.Windows.Forms.DataGridView dtgvSelectedCodes;
    }
}