using FOS.DATA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.BLL.Factories
{
    public static class StateTaxManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new TestStateTaxRepository());
                case "Prod":
                //return new OrderManager(new ProdOrderRepository());
                default:
                    throw new Exception("Mode value in app.config file is invalid");
            }
        }

    }
}
