using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RyanSheehanPowerball.UI.Attributes
{
    public class PickNumbersAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool isValid = false;
            int validNums = 0;

            List<int> numbers = value as List<int>;

            if(numbers != null)
            {
                foreach(int num in numbers)
                {
                    if (num < 70 && num > 0)
                    {
                        validNums++;
                    }
                }                
            }

            if(validNums == 5)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}