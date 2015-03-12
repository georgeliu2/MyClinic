﻿// -----------------------------------------------------------------------
// <copyright file="Login.cs" company="John">
// Acupuncture Clinic Record Management System 2015
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Desktop
{
    using System;
    using System.Windows.Forms;
    using AcupunctureClinic.Desktop.Forms.Membership;
    using AcupunctureClinic.Desktop.Properties;

    /// <summary>
    /// Login form
    /// </summary>
    public partial class Login : Form
    {
        /// <summary>
        /// Initializes a new instance of the Login class
        /// </summary>
        public Login()
        {
            this.InitializeComponent();
            this.InitializeResourceString();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.TopMost = true;
        }

        /// <summary>
        /// Initializes resource strings
        /// </summary>
        private void InitializeResourceString()
        {
            lblUserName.Text = Resources.Login_Username_Label_Text;
            lblPassword.Text = Resources.Login_Password_Label_Text;
            btnLogin.Text = Resources.Login_Login_Button_Text;
        }

        /// <summary>
        /// Click event to handle the login process
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event data</param>
       
        private void Login_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void LoginProcess()
        {

            if (txtUsername.Text.Trim() == Settings.Default.Username && txtPassword.Text.Trim() == Settings.Default.Password)
            {
                var frmManage = new Manage();
                frmManage.Closing += Manage.Manage_Closing;
                frmManage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    Resources.Login_Validation_Message,
                    Resources.Login_Validation_Message_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void txtPassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)        
                LoginProcess();                     
        }
    }
}
