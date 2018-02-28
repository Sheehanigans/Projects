using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanSheehanPowerball._2.Data
{
    public class PickInMemoryRepo : IPickRepository
    {
        static List<Pick> memory = new List<Pick>(); //static so it is not re-created a bunch 

        public void Add(Pick pick)
        {

            throw new NotImplementedException();
        }

        public List<Pick> List()
        {
            throw new NotImplementedException();
        }

        //to list, return memory list 
        //to get pick by id, use LINQ memory.GetSingleOrDefault(t => t.PickID)
    }
}
