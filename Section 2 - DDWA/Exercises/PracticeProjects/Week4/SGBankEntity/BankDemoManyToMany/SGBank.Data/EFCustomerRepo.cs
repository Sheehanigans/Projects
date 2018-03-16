using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.Data
{
    public class EFCustomerRepo : ICustomerRepository
    {
        public Customer LoadCustomer(int ID)
        {
            using (var context = new SGBankEntities())
            {
                return context.Customers.SingleOrDefault(c => c.ID == ID);
            }
        }
    }
}
