using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RyanSheehanPowerball.UI.Attributes
{
    public class PowerballAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is int)
            {
                int numberToCheck = (int)value;

                if (numberToCheck < 27 && numberToCheck > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}