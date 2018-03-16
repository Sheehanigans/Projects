using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public class CustomerManager
    {
        private ICustomerRepository _customerRespoitory;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRespoitory = customerRepository;
        }

        public CustomerLookupResponse LookupCustomer(int customerId)
        {
            CustomerLookupResponse response = new CustomerLookupResponse();

            response.Customer = _customerRespoitory.LoadCustomer(customerId);

            if (response.Customer == null)
            {
                response.Success = false;
                response.Message = $"{customerId} is not a valid customer ID";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }
    }
}
