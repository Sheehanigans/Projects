using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TipCalculator.BLL
{
    public class OldBill
    {

        public decimal BillAmount { get; set; }
        public decimal TipPercentage { get; set; }
        public decimal TipAmount { get { return (BillAmount * (TipPercentage / 100)); } }
    }
}
