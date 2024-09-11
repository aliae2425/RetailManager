﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.Helper
{
    public class ConfigHelper
    {

        public static double GetTaxRate()
        {
            double output = 0;

            string rate = System.Configuration.ConfigurationManager.AppSettings["taxRate"];

            if (string.IsNullOrWhiteSpace(rate) == false)
            {
                if (double.TryParse(rate, out output) == false)
                {
                    throw new ArgumentException("The tax rate in the configuration file is not a valid number.");
                }
            }

            return output;
        }
    }
}
