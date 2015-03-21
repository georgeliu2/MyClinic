namespace AcupunctureClinic.Desktop.Forms
{
    partial class frmProcedureCode
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn1Add = new System.Windows.Forms.Button();
            this.btn1Remove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn1Done = new System.Windows.Forms.Button();
            this.btn1Quite = new System.Windows.Forms.Button();
            this.lstbSelectedProcedureCodes = new System.Windows.Forms.ListBox();
            this.lstbProcedureCodes = new System.Windows.Forms.ListBox();
            this.btn1Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selected Procedure Codes:";
            // 
            // btn1Add
            // 
            this.btn1Add.Location = new System.Drawing.Point(261, 96);
            this.btn1Add.Name = "btn1Add";
            this.btn1Add.Size = new System.Drawing.Size(75, 23);
            this.btn1Add.TabIndex = 3;
            this.btn1Add.Text = "<- Add";
            this.btn1Add.UseVisualStyleBackColor = true;
            this.btn1Add.Click += new System.EventHandler(this.btn1Add_Click);
            // 
            // btn1Remove
            // 
            this.btn1Remove.Location = new System.Drawing.Point(252, 155);
            this.btn1Remove.Name = "btn1Remove";
            this.btn1Remove.Size = new System.Drawing.Size(95, 23);
            this.btn1Remove.TabIndex = 4;
            this.btn1Remove.Text = "Remove ->";
            this.btn1Remove.UseVisualStyleBackColor = true;
            this.btn1Remove.Click += new System.EventHandler(this.btn1Remove_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Procedure Codes:";
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
            this.btn1Quite.Location = new System.Drawing.Point(261, 368);
            this.btn1Quite.Name = "btn1Quite";
            this.btn1Quite.Size = new System.Drawing.Size(75, 23);
            this.btn1Quite.TabIndex = 7;
            this.btn1Quite.Text = "Quite";
            this.btn1Quite.UseVisualStyleBackColor = true;
            this.btn1Quite.Click += new System.EventHandler(this.btn1Quite_Click);
            // 
            // lstbSelectedProcedureCodes
            // 
            this.lstbSelectedProcedureCodes.FormattingEnabled = true;
            this.lstbSelectedProcedureCodes.ItemHeight = 16;
            this.lstbSelectedProcedureCodes.Location = new System.Drawing.Point(53, 81);
            this.lstbSelectedProcedureCodes.Name = "lstbSelectedProcedureCodes";
            this.lstbSelectedProcedureCodes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstbSelectedProcedureCodes.Size = new System.Drawing.Size(166, 100);
            this.lstbSelectedProcedureCodes.TabIndex = 8;
            // 
            // lstbProcedureCodes
            // 
            this.lstbProcedureCodes.FormattingEnabled = true;
            this.lstbProcedureCodes.ItemHeight = 16;
            this.lstbProcedureCodes.Location = new System.Drawing.Point(395, 81);
            this.lstbProcedureCodes.Name = "lstbProcedureCodes";
            this.lstbProcedureCodes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstbProcedureCodes.Size = new System.Drawing.Size(166, 356);
            this.lstbProcedureCodes.TabIndex = 9;
            // 
            // btn1Clear
            // 
            this.btn1Clear.Location = new System.Drawing.Point(165, 368);
            this.btn1Clear.Name = "btn1Clear";
            this.btn1Clear.Size = new System.Drawing.Size(75, 23);
            this.btn1Clear.TabIndex = 10;
            this.btn1Clear.Text = "Clear";
            this.btn1Clear.UseVisualStyleBackColor = true;
            this.btn1Clear.Click += new System.EventHandler(this.btn1Clear_Click);
            // 
            // frmProcedureCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 459);
            this.Controls.Add(this.btn1Clear);
            this.Controls.Add(this.lstbProcedureCodes);
            this.Controls.Add(this.lstbSelectedProcedureCodes);
            this.Controls.Add(this.btn1Quite);
            this.Controls.Add(this.btn1Done);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn1Remove);
            this.Controls.Add(this.btn1Add);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(400, 200);
            this.Name = "frmProcedureCode";
            this.Text = "Procedure Code List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn1Add;
        private System.Windows.Forms.Button btn1Remove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn1Done;
        private System.Windows.Forms.Button btn1Quite;
        private System.Windows.Forms.ListBox lstbSelectedProcedureCodes;
        private System.Windows.Forms.ListBox lstbProcedureCodes;
        private System.Windows.Forms.Button btn1Clear;
    }
}