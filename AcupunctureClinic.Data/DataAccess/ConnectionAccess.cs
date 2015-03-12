// -----------------------------------------------------------------------
// <copyright file="ConnectionAccess.cs" company="John">
// Acupuncture Clinic Record Management System 2015
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.DataAccess
{
    using System.Configuration;

    /// <summary>
    /// ConnectionAccess class
    /// </summary>
    public abstract class ConnectionAccess
    {
        /// <summary>
        /// Gets connection string
        /// </summary>
        protected string DBConnectionString
        {
            get 
            { 
                return ConfigurationManager
                    .ConnectionStrings["DBConnection"]
                    .ToString(); 
            }
        }

        protected string ExcelConnectionString
        {
            get
            {
                return ConfigurationManager
                    .ConnectionStrings["RootDir"]
                    .ToString() +
                    ConfigurationManager
                    .ConnectionStrings["ExcelConnection"]
                    .ToString();
            }
        }
    }
}
