using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanSheehanPowerball._2.Data
{
    public class PickID
    {
        internal static int GetPickID()
        {
            PickRepository repo = new PickRepository(Settings.FilePath);
            List<Pick> picks = repo.List();

            int id = picks.Count() + 1;

            return id;
        }
    }
}
