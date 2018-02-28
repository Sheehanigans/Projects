using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TipCalculator.Attributes;

namespace TipCalculator
{
    public class Bill
    {
        [BillAmount (ErrorMessage = "Amount must be greater that 0 and less than 1000")]
        public decimal BillAmount { get; set; }

        [TipPercentage(ErrorMessage ="Tip amount must be greater than 0% or less than 50%")]
        public decimal TipPercentage { get; set; }
        public decimal TipAmount { get { return (BillAmount * (TipPercentage / 100)); } }
    }
}
