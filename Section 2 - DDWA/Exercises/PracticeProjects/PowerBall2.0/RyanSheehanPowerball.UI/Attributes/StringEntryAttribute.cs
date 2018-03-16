using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RyanSheehanPowerball.UI.Attributes
{
    public class StringEntryAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is string)
            {
                string checkStringEntry = (string)value;

                if (!string.IsNullOrEmpty(checkStringEntry))
                {
                    return true;
                }
            }
            return false;
        }
    }
}