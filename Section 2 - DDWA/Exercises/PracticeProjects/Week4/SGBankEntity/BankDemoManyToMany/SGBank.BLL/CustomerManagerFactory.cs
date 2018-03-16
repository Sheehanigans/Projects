using SGBank.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public static class CustomerManagerFactory
    {
        public static CustomerManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "EFRepo":
                    return new CustomerManager(new EFCustomerRepo());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
