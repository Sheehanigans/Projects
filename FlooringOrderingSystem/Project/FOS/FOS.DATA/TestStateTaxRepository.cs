using FOS.MODELS;
using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.DATA
{
    public class TestStateTaxRepository : IStateTaxRepository
    {
        private static StateTax _stateTax1 = new StateTax
        {
            StateAbbreviation = "OH",
            StateName = "Ohio",
            TaxRate = 6.00M
        };

        private static StateTax _stateTax2 = new StateTax
        {
            StateAbbreviation = "MI",
            StateName = "Michigan",
            TaxRate = 6.25M
        };

        public void Add(Order order)
        {
            throw new NotImplementedException();
        }

        public void Edit(Order order, string date)
        {
            throw new NotImplementedException();
        }

        public StateTax GetState(string stateAbbr)
        {
            throw new NotImplementedException();
        }

        public void Remove(Order order, string date)
        {
            throw new NotImplementedException();
        }
    }
}
