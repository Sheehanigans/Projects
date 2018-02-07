using System;
using System.Collections.Generic;
using System.Text;

namespace RyanSheehanPowerball.Workflows
{
    public class AddPickWorkflow
    {
        private IPickRepository _creator;

        public AddPickWorkflow (IPickRepository concrete)
        {
            _creator = concrete;
        }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Add your picks!");
            Console.WriteLine();

            Pick pick = new Pick();

        }
        
    }
}
