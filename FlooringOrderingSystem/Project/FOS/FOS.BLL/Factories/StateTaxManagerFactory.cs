using FOS.BLL.Managers;
using FOS.DATA;
using FOS.DATA.FileRepositories;
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
        public static StateTaxManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new StateTaxManager(new TestStateTaxRepository());
                case "Prod":
                    return new StateTaxManager(new FileStateTaxRepository());
                default:
                    throw new Exception("Mode value in app.config file is invalid");
            }
        }

    }
}
