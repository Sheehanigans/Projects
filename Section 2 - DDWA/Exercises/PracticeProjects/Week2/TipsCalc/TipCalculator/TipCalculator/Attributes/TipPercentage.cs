using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TipCalculator.Attributes
{
    public class TipPercentage : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is decimal)
            {
                decimal checkTipPercentage = (decimal)value;

                if (checkTipPercentage > 50 || checkTipPercentage < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}