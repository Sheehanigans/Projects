using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarDealership.Models.Attributes
{
    public class VINAttribute : ValidationAttribute
    {
        public override bool IsValid (object value)
        {
            if (value is string)
            {
                string vin = (string)value;

                Regex r = new Regex("^[0-9A-Z-[IOQ]]{17}$");

                if (r.IsMatch(vin))
                    return true;
                else
                    return false;
            }

            return false;
        }
    }
}
