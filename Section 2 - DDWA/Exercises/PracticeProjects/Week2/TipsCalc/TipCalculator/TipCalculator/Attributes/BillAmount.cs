using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TipCalculator.Attributes
{
    public class BillAmount : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is decimal)
            {
                decimal checkBillAmount = (decimal)value;

                if (checkBillAmount > 1001 || checkBillAmount < 0)
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