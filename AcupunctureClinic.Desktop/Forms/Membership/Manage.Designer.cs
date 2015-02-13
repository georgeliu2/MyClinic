namespace AcupunctureClinic.Desktop.Forms.Membership
{
    partial class Manage
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
            this.tab = new System.Windows.Forms.TabControl();
            this.tabRegistration = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabRegister = new System.Windows.Forms.TabPage();
            this.lblFname = new System.Windows.Forms.Label();
            this.txtEmployer = new System.Windows.Forms.TextBox();
            this.lblSSN = new System.Windows.Forms.Label();
            this.lblEmployer = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLname = new System.Windows.Forms.Label();
            this.lblDLN = new System.Windows.Forms.Label();
            this.txtDLN = new System.Windows.Forms.TextBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblDOBRequired = new System.Windows.Forms.Label();
            this.lblNameRequired = new System.Windows.Forms.Label();
            this.txtSSN = new System.Windows.Forms.TextBox();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.dtDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.btnRegister = new System.Windows.Forms.Button();
            this.cmbMaritalStatus = new System.Windows.Forms.ComboBox();
            this.lblMaritalStatus = new System.Windows.Forms.Label();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.cmbOccupation = new System.Windows.Forms.ComboBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.tabSearchManage = new System.Windows.Forms.TabPage();
            this.txt2Employer = new System.Windows.Forms.TextBox();
            this.txt2CustomerID = new System.Windows.Forms.TextBox();
            this.lbl2CustomerID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl2DLN = new System.Windows.Forms.Label();
            this.txt2DLN = new System.Windows.Forms.TextBox();
            this.lbl2SSN = new System.Windows.Forms.Label();
            this.txt2SSN = new System.Windows.Forms.TextBox();
            this.cmb2Sex = new System.Windows.Forms.ComboBox();
            this.lbl2Employer = new System.Windows.Forms.Label();
            this.cmb2MaritalStatus = new System.Windows.Forms.ComboBox();
            this.lbl2MaritalStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl2Salary = new System.Windows.Forms.Label();
            this.dt2DateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lbl2Occupation = new System.Windows.Forms.Label();
            this.cmb2Occupation = new System.Windows.Forms.ComboBox();
            this.txt2Name = new System.Windows.Forms.TextBox();
            this.lbl2DateOfBirth = new System.Windows.Forms.Label();
            this.lbl2Name = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtSLname = new System.Windows.Forms.TextBox();
            this.txtSCustomerID = new System.Windows.Forms.TextBox();
            this.cmbOperand = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewMembers = new System.Windows.Forms.DataGridView();
            this.Header = new System.Windows.Forms.TextBox();
            this.PrintReport = new System.Drawing.Printing.PrintDocument();
            this.tab.SuspendLayout();
            this.tabRegistration.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabRegister.SuspendLayout();
            this.tabSearchManage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabRegistration);
            this.tab.Controls.Add(this.tabSearchManage);
            this.tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab.Location = new System.Drawing.Point(8, 43);
            this.tab.Margin = new System.Windows.Forms.Padding(4);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1380, 608);
            this.tab.TabIndex = 0;
            this.tab.SelectedIndexChanged += new System.EventHandler(this.Tab_SelectedIndexChanged);
            // 
            // tabRegistration
            // 
            this.tabRegistration.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabRegistration.Controls.Add(this.tabControl2);
            this.tabRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabRegistration.Location = new System.Drawing.Point(4, 27);
            this.tabRegistration.Margin = new System.Windows.Forms.Padding(4);
            this.tabRegistration.Name = "tabRegistration";
            this.tabRegistration.Padding = new System.Windows.Forms.Padding(4);
            this.tabRegistration.Size = new System.Drawing.Size(1372, 577);
            this.tabRegistration.TabIndex = 0;
            this.tabRegistration.Text = "New Customer";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabRegister);
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(11, 7);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(756, 295);
            this.tabControl2.TabIndex = 5;
            // 
            // tabRegister
            // 
            this.tabRegister.Controls.Add(this.lblFname);
            this.tabRegister.Controls.Add(this.txtEmployer);
            this.tabRegister.Controls.Add(this.lblSSN);
            this.tabRegister.Controls.Add(this.lblEmployer);
            this.tabRegister.Controls.Add(this.txtLname);
            this.tabRegister.Controls.Add(this.label7);
            this.tabRegister.Controls.Add(this.lblLname);
            this.tabRegister.Controls.Add(this.lblDLN);
            this.tabRegister.Controls.Add(this.txtDLN);
            this.tabRegister.Controls.Add(this.btnQuit);
            this.tabRegister.Controls.Add(this.lblDOBRequired);
            this.tabRegister.Controls.Add(this.lblNameRequired);
            this.tabRegister.Controls.Add(this.txtSSN);
            this.tabRegister.Controls.Add(this.cmbSex);
            this.tabRegister.Controls.Add(this.lblSex);
            this.tabRegister.Controls.Add(this.dtDateOfBirth);
            this.tabRegister.Controls.Add(this.btnRegister);
            this.tabRegister.Controls.Add(this.cmbMaritalStatus);
            this.tabRegister.Controls.Add(this.lblMaritalStatus);
            this.tabRegister.Controls.Add(this.lblOccupation);
            this.tabRegister.Controls.Add(this.cmbOccupation);
            this.tabRegister.Controls.Add(this.txtFname);
            this.tabRegister.Controls.Add(this.lblDateOfBirth);
            this.tabRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabRegister.Location = new System.Drawing.Point(4, 29);
            this.tabRegister.Margin = new System.Windows.Forms.Padding(4);
            this.tabRegister.Name = "tabRegister";
            this.tabRegister.Padding = new System.Windows.Forms.Padding(4);
            this.tabRegister.Size = new System.Drawing.Size(748, 262);
            this.tabRegister.TabIndex = 0;
            this.tabRegister.Text = "Member";
            this.tabRegister.UseVisualStyleBackColor = true;
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Location = new System.Drawing.Point(21, 20);
            this.lblFname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(81, 18);
            this.lblFname.TabIndex = 32;
            this.lblFname.Text = "First Name";
            // 
            // txtEmployer
            // 
            this.txtEmployer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployer.Location = new System.Drawing.Point(147, 153);
            this.txtEmployer.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmployer.MaxLength = 128;
            this.txtEmployer.Name = "txtEmployer";
            this.txtEmployer.Size = new System.Drawing.Size(202, 24);
            this.txtEmployer.TabIndex = 31;
            this.txtEmployer.Text = "None";
            // 
            // lblSSN
            // 
            this.lblSSN.AutoSize = true;
            this.lblSSN.Location = new System.Drawing.Point(381, 150);
            this.lblSSN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSSN.Name = "lblSSN";
            this.lblSSN.Size = new System.Drawing.Size(39, 18);
            this.lblSSN.TabIndex = 30;
            this.lblSSN.Text = "SSN";
            // 
            // lblEmployer
            // 
            this.lblEmployer.AutoSize = true;
            this.lblEmployer.Location = new System.Drawing.Point(21, 152);
            this.lblEmployer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployer.Name = "lblEmployer";
            this.lblEmployer.Size = new System.Drawing.Size(71, 18);
            this.lblEmployer.TabIndex = 29;
            this.lblEmployer.Text = "Employer";
            // 
            // txtLname
            // 
            this.txtLname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLname.Location = new System.Drawing.Point(503, 18);
            this.txtLname.Margin = new System.Windows.Forms.Padding(4);
            this.txtLname.MaxLength = 128;
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(202, 24);
            this.txtLname.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(460, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 29);
            this.label7.TabIndex = 27;
            this.label7.Text = "*";
            // 
            // lblLname
            // 
            this.lblLname.AutoSize = true;
            this.lblLname.Location = new System.Drawing.Point(380, 18);
            this.lblLname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(80, 18);
            this.lblLname.TabIndex = 26;
            this.lblLname.Text = "Last Name";
            // 
            // lblDLN
            // 
            this.lblDLN.AutoSize = true;
            this.lblDLN.Location = new System.Drawing.Point(568, 153);
            this.lblDLN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDLN.Name = "lblDLN";
            this.lblDLN.Size = new System.Drawing.Size(38, 18);
            this.lblDLN.TabIndex = 25;
            this.lblDLN.Text = "DLN";
            // 
            // txtDLN
            // 
            this.txtDLN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDLN.Location = new System.Drawing.Point(619, 148);
            this.txtDLN.Margin = new System.Windows.Forms.Padding(4);
            this.txtDLN.MaxLength = 10;
            this.txtDLN.Name = "txtDLN";
            this.txtDLN.Size = new System.Drawing.Size(93, 24);
            this.txtDLN.TabIndex = 24;
            this.txtDLN.Text = "12345678";
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(429, 218);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(153, 34);
            this.btnQuit.TabIndex = 23;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblDOBRequired
            // 
            this.lblDOBRequired.AutoSize = true;
            this.lblDOBRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOBRequired.ForeColor = System.Drawing.Color.Red;
            this.lblDOBRequired.Location = new System.Drawing.Point(119, 64);
            this.lblDOBRequired.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDOBRequired.Name = "lblDOBRequired";
            this.lblDOBRequired.Size = new System.Drawing.Size(24, 29);
            this.lblDOBRequired.TabIndex = 19;
            this.lblDOBRequired.Text = "*";
            // 
            // lblNameRequired
            // 
            this.lblNameRequired.AutoSize = true;
            this.lblNameRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameRequired.ForeColor = System.Drawing.Color.Red;
            this.lblNameRequired.Location = new System.Drawing.Point(112, 18);
            this.lblNameRequired.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameRequired.Name = "lblNameRequired";
            this.lblNameRequired.Size = new System.Drawing.Size(24, 29);
            this.lblNameRequired.TabIndex = 18;
            this.lblNameRequired.Text = "*";
            // 
            // txtSSN
            // 
            this.txtSSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSSN.Location = new System.Drawing.Point(429, 148);
            this.txtSSN.Margin = new System.Windows.Forms.Padding(4);
            this.txtSSN.MaxLength = 11;
            this.txtSSN.Name = "txtSSN";
            this.txtSSN.Size = new System.Drawing.Size(106, 24);
            this.txtSSN.TabIndex = 8;
            this.txtSSN.Text = "123-45-6789";
            // 
            // cmbSex
            // 
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.cmbSex.Location = new System.Drawing.Point(572, 55);
            this.cmbSex.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(108, 26);
            this.cmbSex.TabIndex = 7;
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(381, 59);
            this.lblSex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(33, 18);
            this.lblSex.TabIndex = 12;
            this.lblSex.Text = "Sex";
            // 
            // dtDateOfBirth
            // 
            this.dtDateOfBirth.AllowDrop = true;
            this.dtDateOfBirth.CustomFormat = "dd/MM/yyyy";
            this.dtDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfBirth.Location = new System.Drawing.Point(148, 57);
            this.dtDateOfBirth.Margin = new System.Windows.Forms.Padding(4);
            this.dtDateOfBirth.MaxDate = new System.DateTime(2012, 12, 25, 0, 0, 0, 0);
            this.dtDateOfBirth.MinDate = new System.DateTime(1910, 1, 1, 0, 0, 0, 0);
            this.dtDateOfBirth.Name = "dtDateOfBirth";
            this.dtDateOfBirth.Size = new System.Drawing.Size(152, 24);
            this.dtDateOfBirth.TabIndex = 3;
            this.dtDateOfBirth.Value = new System.DateTime(2012, 12, 25, 0, 0, 0, 0);
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(148, 218);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(153, 34);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.Register_Click);
            // 
            // cmbMaritalStatus
            // 
            this.cmbMaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaritalStatus.FormattingEnabled = true;
            this.cmbMaritalStatus.Items.AddRange(new object[] {
            "Married",
            "Single"});
            this.cmbMaritalStatus.Location = new System.Drawing.Point(572, 100);
            this.cmbMaritalStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMaritalStatus.Name = "cmbMaritalStatus";
            this.cmbMaritalStatus.Size = new System.Drawing.Size(108, 26);
            this.cmbMaritalStatus.TabIndex = 6;
            // 
            // lblMaritalStatus
            // 
            this.lblMaritalStatus.AutoSize = true;
            this.lblMaritalStatus.Location = new System.Drawing.Point(381, 103);
            this.lblMaritalStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaritalStatus.Name = "lblMaritalStatus";
            this.lblMaritalStatus.Size = new System.Drawing.Size(96, 18);
            this.lblMaritalStatus.TabIndex = 6;
            this.lblMaritalStatus.Text = "Marital status";
            // 
            // lblOccupation
            // 
            this.lblOccupation.AutoSize = true;
            this.lblOccupation.Location = new System.Drawing.Point(21, 106);
            this.lblOccupation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(84, 18);
            this.lblOccupation.TabIndex = 5;
            this.lblOccupation.Text = "Occupation";
            // 
            // cmbOccupation
            // 
            this.cmbOccupation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOccupation.FormattingEnabled = true;
            this.cmbOccupation.Items.AddRange(new object[] {
            "None",
            "Doctor",
            "Engineer",
            "Professor",
            "Cat"});
            this.cmbOccupation.Location = new System.Drawing.Point(148, 100);
            this.cmbOccupation.Margin = new System.Windows.Forms.Padding(4);
            this.cmbOccupation.Name = "cmbOccupation";
            this.cmbOccupation.Size = new System.Drawing.Size(201, 26);
            this.cmbOccupation.TabIndex = 4;
            // 
            // txtFname
            // 
            this.txtFname.AcceptsReturn = true;
            this.txtFname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFname.Location = new System.Drawing.Point(148, 18);
            this.txtFname.Margin = new System.Windows.Forms.Padding(4);
            this.txtFname.MaxLength = 128;
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(202, 24);
            this.txtFname.TabIndex = 2;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(21, 63);
            this.lblDateOfBirth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(90, 18);
            this.lblDateOfBirth.TabIndex = 1;
            this.lblDateOfBirth.Text = "Date of Birth";
            // 
            // tabSearchManage
            // 
            this.tabSearchManage.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabSearchManage.Controls.Add(this.txt2Employer);
            this.tabSearchManage.Controls.Add(this.txt2CustomerID);
            this.tabSearchManage.Controls.Add(this.lbl2CustomerID);
            this.tabSearchManage.Controls.Add(this.label1);
            this.tabSearchManage.Controls.Add(this.lbl2DLN);
            this.tabSearchManage.Controls.Add(this.txt2DLN);
            this.tabSearchManage.Controls.Add(this.lbl2SSN);
            this.tabSearchManage.Controls.Add(this.txt2SSN);
            this.tabSearchManage.Controls.Add(this.cmb2Sex);
            this.tabSearchManage.Controls.Add(this.lbl2Employer);
            this.tabSearchManage.Controls.Add(this.cmb2MaritalStatus);
            this.tabSearchManage.Controls.Add(this.lbl2MaritalStatus);
            this.tabSearchManage.Controls.Add(this.label2);
            this.tabSearchManage.Controls.Add(this.label5);
            this.tabSearchManage.Controls.Add(this.lbl2Salary);
            this.tabSearchManage.Controls.Add(this.dt2DateOfBirth);
            this.tabSearchManage.Controls.Add(this.lbl2Occupation);
            this.tabSearchManage.Controls.Add(this.cmb2Occupation);
            this.tabSearchManage.Controls.Add(this.txt2Name);
            this.tabSearchManage.Controls.Add(this.lbl2DateOfBirth);
            this.tabSearchManage.Controls.Add(this.lbl2Name);
            this.tabSearchManage.Controls.Add(this.btnUpdate);
            this.tabSearchManage.Controls.Add(this.btnDelete);
            this.tabSearchManage.Controls.Add(this.btnPrintPreview);
            this.tabSearchManage.Controls.Add(this.btnExport);
            this.tabSearchManage.Controls.Add(this.btnPrint);
            this.tabSearchManage.Controls.Add(this.tabControl1);
            this.tabSearchManage.Controls.Add(this.dataGridViewMembers);
            this.tabSearchManage.Location = new System.Drawing.Point(4, 27);
            this.tabSearchManage.Margin = new System.Windows.Forms.Padding(4);
            this.tabSearchManage.Name = "tabSearchManage";
            this.tabSearchManage.Padding = new System.Windows.Forms.Padding(4);
            this.tabSearchManage.Size = new System.Drawing.Size(1372, 577);
            this.tabSearchManage.TabIndex = 1;
            this.tabSearchManage.Text = "Search / Manage Customers";
            // 
            // txt2Employer
            // 
            this.txt2Employer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt2Employer.Location = new System.Drawing.Point(1124, 431);
            this.txt2Employer.Margin = new System.Windows.Forms.Padding(4);
            this.txt2Employer.Name = "txt2Employer";
            this.txt2Employer.Size = new System.Drawing.Size(202, 24);
            this.txt2Employer.TabIndex = 46;
            // 
            // txt2CustomerID
            // 
            this.txt2CustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt2CustomerID.Location = new System.Drawing.Point(1123, 224);
            this.txt2CustomerID.Margin = new System.Windows.Forms.Padding(4);
            this.txt2CustomerID.Name = "txt2CustomerID";
            this.txt2CustomerID.Size = new System.Drawing.Size(202, 24);
            this.txt2CustomerID.TabIndex = 45;
            // 
            // lbl2CustomerID
            // 
            this.lbl2CustomerID.AutoSize = true;
            this.lbl2CustomerID.Location = new System.Drawing.Point(968, 224);
            this.lbl2CustomerID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2CustomerID.Name = "lbl2CustomerID";
            this.lbl2CustomerID.Size = new System.Drawing.Size(92, 18);
            this.lbl2CustomerID.TabIndex = 44;
            this.lbl2CustomerID.Text = "Customer ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(1016, 263);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 29);
            this.label1.TabIndex = 43;
            this.label1.Text = "*";
            // 
            // lbl2DLN
            // 
            this.lbl2DLN.AutoSize = true;
            this.lbl2DLN.Location = new System.Drawing.Point(1168, 479);
            this.lbl2DLN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2DLN.Name = "lbl2DLN";
            this.lbl2DLN.Size = new System.Drawing.Size(39, 18);
            this.lbl2DLN.TabIndex = 42;
            this.lbl2DLN.Text = "SSN";
            // 
            // txt2DLN
            // 
            this.txt2DLN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt2DLN.Location = new System.Drawing.Point(1238, 475);
            this.txt2DLN.Margin = new System.Windows.Forms.Padding(4);
            this.txt2DLN.MaxLength = 10;
            this.txt2DLN.Name = "txt2DLN";
            this.txt2DLN.Size = new System.Drawing.Size(87, 24);
            this.txt2DLN.TabIndex = 41;
            this.txt2DLN.Text = "12345678";
            // 
            // lbl2SSN
            // 
            this.lbl2SSN.AutoSize = true;
            this.lbl2SSN.Location = new System.Drawing.Point(969, 475);
            this.lbl2SSN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2SSN.Name = "lbl2SSN";
            this.lbl2SSN.Size = new System.Drawing.Size(39, 18);
            this.lbl2SSN.TabIndex = 37;
            this.lbl2SSN.Text = "SSN";
            // 
            // txt2SSN
            // 
            this.txt2SSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt2SSN.Location = new System.Drawing.Point(1031, 473);
            this.txt2SSN.Margin = new System.Windows.Forms.Padding(4);
            this.txt2SSN.MaxLength = 11;
            this.txt2SSN.Name = "txt2SSN";
            this.txt2SSN.Size = new System.Drawing.Size(87, 24);
            this.txt2SSN.TabIndex = 35;
            this.txt2SSN.Text = "123-45-6789";
            // 
            // cmb2Sex
            // 
            this.cmb2Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb2Sex.FormattingEnabled = true;
            this.cmb2Sex.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.cmb2Sex.Location = new System.Drawing.Point(1010, 385);
            this.cmb2Sex.Margin = new System.Windows.Forms.Padding(4);
            this.cmb2Sex.Name = "cmb2Sex";
            this.cmb2Sex.Size = new System.Drawing.Size(73, 26);
            this.cmb2Sex.TabIndex = 34;
            // 
            // lbl2Employer
            // 
            this.lbl2Employer.AutoSize = true;
            this.lbl2Employer.Location = new System.Drawing.Point(969, 437);
            this.lbl2Employer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2Employer.Name = "lbl2Employer";
            this.lbl2Employer.Size = new System.Drawing.Size(71, 18);
            this.lbl2Employer.TabIndex = 36;
            this.lbl2Employer.Text = "Employer";
            // 
            // cmb2MaritalStatus
            // 
            this.cmb2MaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb2MaritalStatus.FormattingEnabled = true;
            this.cmb2MaritalStatus.Items.AddRange(new object[] {
            "Married",
            "Single"});
            this.cmb2MaritalStatus.Location = new System.Drawing.Point(1214, 388);
            this.cmb2MaritalStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmb2MaritalStatus.Name = "cmb2MaritalStatus";
            this.cmb2MaritalStatus.Size = new System.Drawing.Size(112, 26);
            this.cmb2MaritalStatus.TabIndex = 32;
            // 
            // lbl2MaritalStatus
            // 
            this.lbl2MaritalStatus.AutoSize = true;
            this.lbl2MaritalStatus.Location = new System.Drawing.Point(1100, 391);
            this.lbl2MaritalStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2MaritalStatus.Name = "lbl2MaritalStatus";
            this.lbl2MaritalStatus.Size = new System.Drawing.Size(96, 18);
            this.lbl2MaritalStatus.TabIndex = 33;
            this.lbl2MaritalStatus.Text = "Marital status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(1065, 310);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 29);
            this.label2.TabIndex = 30;
            this.label2.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(1017, 271);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 29);
            this.label5.TabIndex = 29;
            // 
            // lbl2Salary
            // 
            this.lbl2Salary.AutoSize = true;
            this.lbl2Salary.Location = new System.Drawing.Point(969, 393);
            this.lbl2Salary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2Salary.Name = "lbl2Salary";
            this.lbl2Salary.Size = new System.Drawing.Size(33, 18);
            this.lbl2Salary.TabIndex = 28;
            this.lbl2Salary.Text = "Sex";
            // 
            // dt2DateOfBirth
            // 
            this.dt2DateOfBirth.AllowDrop = true;
            this.dt2DateOfBirth.CustomFormat = "dd/MM/yyyy";
            this.dt2DateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt2DateOfBirth.Location = new System.Drawing.Point(1124, 303);
            this.dt2DateOfBirth.Margin = new System.Windows.Forms.Padding(4);
            this.dt2DateOfBirth.MaxDate = new System.DateTime(2012, 12, 25, 0, 0, 0, 0);
            this.dt2DateOfBirth.MinDate = new System.DateTime(1910, 1, 1, 0, 0, 0, 0);
            this.dt2DateOfBirth.Name = "dt2DateOfBirth";
            this.dt2DateOfBirth.Size = new System.Drawing.Size(151, 24);
            this.dt2DateOfBirth.TabIndex = 24;
            this.dt2DateOfBirth.Value = new System.DateTime(2012, 12, 25, 0, 0, 0, 0);
            // 
            // lbl2Occupation
            // 
            this.lbl2Occupation.AutoSize = true;
            this.lbl2Occupation.Location = new System.Drawing.Point(968, 350);
            this.lbl2Occupation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2Occupation.Name = "lbl2Occupation";
            this.lbl2Occupation.Size = new System.Drawing.Size(84, 18);
            this.lbl2Occupation.TabIndex = 27;
            this.lbl2Occupation.Text = "Occupation";
            // 
            // cmb2Occupation
            // 
            this.cmb2Occupation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb2Occupation.FormattingEnabled = true;
            this.cmb2Occupation.Items.AddRange(new object[] {
            "None",
            "Doctor",
            "Engineer",
            "Professor",
            "Cat"});
            this.cmb2Occupation.Location = new System.Drawing.Point(1124, 344);
            this.cmb2Occupation.Margin = new System.Windows.Forms.Padding(4);
            this.cmb2Occupation.Name = "cmb2Occupation";
            this.cmb2Occupation.Size = new System.Drawing.Size(201, 26);
            this.cmb2Occupation.TabIndex = 25;
            // 
            // txt2Name
            // 
            this.txt2Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt2Name.Location = new System.Drawing.Point(1124, 268);
            this.txt2Name.Margin = new System.Windows.Forms.Padding(4);
            this.txt2Name.Name = "txt2Name";
            this.txt2Name.Size = new System.Drawing.Size(202, 24);
            this.txt2Name.TabIndex = 23;
            // 
            // lbl2DateOfBirth
            // 
            this.lbl2DateOfBirth.AutoSize = true;
            this.lbl2DateOfBirth.Location = new System.Drawing.Point(968, 309);
            this.lbl2DateOfBirth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2DateOfBirth.Name = "lbl2DateOfBirth";
            this.lbl2DateOfBirth.Size = new System.Drawing.Size(90, 18);
            this.lbl2DateOfBirth.TabIndex = 22;
            this.lbl2DateOfBirth.Text = "Date of Birth";
            // 
            // lbl2Name
            // 
            this.lbl2Name.AutoSize = true;
            this.lbl2Name.Location = new System.Drawing.Point(969, 270);
            this.lbl2Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2Name.Name = "lbl2Name";
            this.lbl2Name.Size = new System.Drawing.Size(48, 18);
            this.lbl2Name.TabIndex = 21;
            this.lbl2Name.Text = "Name";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1031, 528);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(112, 33);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1222, 528);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(103, 33);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Location = new System.Drawing.Point(520, 155);
            this.btnPrintPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(133, 34);
            this.btnPrintPreview.TabIndex = 8;
            this.btnPrintPreview.Text = "Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.PrintPreview_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(803, 155);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(133, 34);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.Export_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(661, 155);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(133, 34);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.Print_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(9, 9);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1352, 129);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtSLname);
            this.tabPage3.Controls.Add(this.txtSCustomerID);
            this.tabPage3.Controls.Add(this.cmbOperand);
            this.tabPage3.Controls.Add(this.btnRefresh);
            this.tabPage3.Controls.Add(this.btnSearch);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1344, 98);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Search";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtSLname
            // 
            this.txtSLname.Location = new System.Drawing.Point(310, 43);
            this.txtSLname.Name = "txtSLname";
            this.txtSLname.Size = new System.Drawing.Size(159, 24);
            this.txtSLname.TabIndex = 12;
            // 
            // txtSCustomerID
            // 
            this.txtSCustomerID.Location = new System.Drawing.Point(42, 43);
            this.txtSCustomerID.Name = "txtSCustomerID";
            this.txtSCustomerID.Size = new System.Drawing.Size(159, 24);
            this.txtSCustomerID.TabIndex = 11;
            // 
            // cmbOperand
            // 
            this.cmbOperand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperand.Enabled = false;
            this.cmbOperand.FormattingEnabled = true;
            this.cmbOperand.Items.AddRange(new object[] {
            "OR"});
            this.cmbOperand.Location = new System.Drawing.Point(208, 41);
            this.cmbOperand.Margin = new System.Windows.Forms.Padding(4);
            this.cmbOperand.Name = "cmbOperand";
            this.cmbOperand.Size = new System.Drawing.Size(85, 26);
            this.cmbOperand.TabIndex = 10;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(639, 41);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(133, 34);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(485, 41);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(133, 34);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.Search_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "CustomerID";
            // 
            // dataGridViewMembers
            // 
            this.dataGridViewMembers.AllowUserToAddRows = false;
            this.dataGridViewMembers.AllowUserToOrderColumns = true;
            this.dataGridViewMembers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMembers.Location = new System.Drawing.Point(4, 204);
            this.dataGridViewMembers.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewMembers.Name = "dataGridViewMembers";
            this.dataGridViewMembers.ReadOnly = true;
            this.dataGridViewMembers.RowTemplate.Height = 24;
            this.dataGridViewMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMembers.Size = new System.Drawing.Size(932, 366);
            this.dataGridViewMembers.TabIndex = 3;
            this.dataGridViewMembers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridView_CellFormatting);
            this.dataGridViewMembers.SelectionChanged += new System.EventHandler(this.dataGridViewMembers_SelectionChanged);
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.SystemColors.Control;
            this.Header.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Header.Enabled = false;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.DimGray;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Margin = new System.Windows.Forms.Padding(4);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1400, 38);
            this.Header.TabIndex = 0;
            this.Header.Text = "Acupuncture Clinic";
            this.Header.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PrintReport
            // 
            this.PrintReport.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
            // 
            // Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1400, 661);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.tab);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Social Club - Membership Manager";
            this.Load += new System.EventHandler(this.Manage_Load);
            this.tab.ResumeLayout(false);
            this.tabRegistration.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabRegister.ResumeLayout(false);
            this.tabRegister.PerformLayout();
            this.tabSearchManage.ResumeLayout(false);
            this.tabSearchManage.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMembers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabRegistration;
        private System.Windows.Forms.TabPage tabSearchManage;
        private System.Windows.Forms.DataGridView dataGridViewMembers;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabRegister;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.ComboBox cmbMaritalStatus;
        private System.Windows.Forms.Label lblMaritalStatus;
        private System.Windows.Forms.Label lblOccupation;
        private System.Windows.Forms.ComboBox cmbOccupation;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtDateOfBirth;
        private System.Windows.Forms.TextBox txtSSN;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblDOBRequired;
        private System.Windows.Forms.Label lblNameRequired;
        private System.Windows.Forms.TextBox Header;
        private System.Windows.Forms.ComboBox cmbOperand;
        private System.Drawing.Printing.PrintDocument PrintReport;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl2Salary;
        private System.Windows.Forms.DateTimePicker dt2DateOfBirth;
        private System.Windows.Forms.Label lbl2Occupation;
        private System.Windows.Forms.ComboBox cmb2Occupation;
        private System.Windows.Forms.TextBox txt2Name;
        private System.Windows.Forms.Label lbl2DateOfBirth;
        private System.Windows.Forms.Label lbl2Name;
        private System.Windows.Forms.Label lbl2SSN;
        private System.Windows.Forms.TextBox txt2SSN;
        private System.Windows.Forms.ComboBox cmb2Sex;
        private System.Windows.Forms.Label lbl2Employer;
        private System.Windows.Forms.ComboBox cmb2MaritalStatus;
        private System.Windows.Forms.Label lbl2MaritalStatus;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblDLN;
        private System.Windows.Forms.TextBox txtDLN;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.Label lbl2DLN;
        private System.Windows.Forms.TextBox txt2DLN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt2CustomerID;
        private System.Windows.Forms.Label lbl2CustomerID;
        private System.Windows.Forms.TextBox txt2Employer;
        private System.Windows.Forms.Label lblSSN;
        private System.Windows.Forms.Label lblEmployer;
        private System.Windows.Forms.TextBox txtEmployer;
        private System.Windows.Forms.TextBox txtSLname;
        private System.Windows.Forms.TextBox txtSCustomerID;
        private System.Windows.Forms.Label lblFname;
    }
}