using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderExercise
{
    class Order
    {
        public int ID { get; }
        public Customer OrderCustomer { get; }
        public decimal Total { get; }
        public string Notes { get; }
        public DateTime Date { get; }
    }
}
