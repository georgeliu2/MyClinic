using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AcupunctureClinic.Data.BusinessService
{
    using System.Data;
    public interface ICodePickup
    {
        /// <summary>
        /// Get List of code string
        /// </summary>
        /// <param name=""></param>
        /// <returns>A List of code string</returns>
        DataTable GetCodeTable();

        /// <summary>
        /// Get List of selected code strings
        /// </summary>
        /// <param name=""></param>
        /// <returns>A List of code strings</returns>
        List<string> GetSelectedCodes();

        /// <summary>
        /// Populate procedure codes to the target object
        /// </summary>
        /// <param name=""></param>
        /// <returns>void</returns>
        void PopulateCodes(DataGridView dataGrid);


        /// <summary>
        /// Active the form
        /// </summary>
        /// <param name=""></param>
        /// <returns>void</returns>
        void ActiveObj();
    }
}
