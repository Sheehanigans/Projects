using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanSheehanPowerball._2
{
    public class LottoManager 
    {
        IPickRepository _repo;

        public LottoManager(IPickRepository repo)
        {
            _repo = repo;
        }
    }
}
