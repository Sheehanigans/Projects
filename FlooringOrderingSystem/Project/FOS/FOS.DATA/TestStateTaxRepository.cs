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

        public StateTax GetState(string stateAbbr)
        {
            List<StateTax> stateTaxes = new List<StateTax>();

            stateTaxes.Add(_stateTax1);
            stateTaxes.Add(_stateTax2);

            StateTax state = null;

            foreach (StateTax st in stateTaxes)
            {
                if (stateAbbr == st.StateAbbreviation)
                {
                    state = st;
                }
            }

            return state;
        }
    }
}
