using FOS.MODELS.Models;
using FOS.MODELS.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.BLL.DataValidations
{
    public class StateTaxValidation
    {
        public static StateTax CreateStateTax(string stateAbbreviation)
        {
            OrderManager manager = OrderManagerFactory.Create();

            StateTaxResponse stResponse = manager.GetStateTax(stateAbbreviation);

            if (stResponse.Success)
            {
                return stResponse.State;
            }
            else
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(stResponse.Message);
            }
            //StateTax state = manager.GetStateTax(stateAbbreviation).State;

            return stResponse.State;
        }
    }
}
