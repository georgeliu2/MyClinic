using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcupunctureClinic.Data.BusinessService
{
    public class  utility
    {
        /// Functions and tools for general programming
        //We change all currency to long inside. When display, we change it back
        public static string DisplayCurrency(long num)
        {
            return "$ " + (num / 100).ToString() + "." + (num % 100).ToString();
        }

        public static string DisplayCurrency(string strnum)
        {
            return DisplayCurrency(StrToLong(strnum));
        }

        public static long CurrencyToLong(string cur)
        {
            if (cur == null || cur == "")
                return 0;
            int dollar = cur.IndexOf('$');
            string fcur;
            if (dollar >= 0)
                fcur = cur.Remove(dollar, 1).Trim();
            else
                fcur = cur;
            //Validate cur
            bool good = true;
            foreach (char a in fcur)
            {
                good = good && ((a <= '9' && a >= '0') || a == '.');
            }
            if (good == false)
                return 0;
            else
                return (long)(float.Parse(fcur) * 100);
        }

        public static long StrToLong(string str)
        {
            if (str == null || str == "")
                return 0;
            //Validate cur
            bool good = true;
            foreach (char a in str)
            {
                good = good && ((a <= '9' && a >= '0'));
            }
            if (good == false)
                return 0;
            else
                return long.Parse(str);
        }

        public static int StrToDisRate(string rate)
        {
            return (int)StrToLong(rate);                
        }

        public static string IntToDisRate(int rate)
        {
            return rate.ToString() + "%";
        }
    }
}
