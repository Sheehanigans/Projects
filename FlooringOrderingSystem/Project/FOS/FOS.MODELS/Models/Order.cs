using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.MODELS
{
    public class Order
    {
        public string Date { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; } 
        public string ProductType { get; set; }
        public decimal Area { get; set; } 
        public decimal CostPerSquareFoot { get; set; } 
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost { get; set; } //calc
        public decimal LaberCost { get; set; } //calc
        public decimal Tax { get; set; } //calc
        public decimal Total { get; set; } //calc
    }
}
