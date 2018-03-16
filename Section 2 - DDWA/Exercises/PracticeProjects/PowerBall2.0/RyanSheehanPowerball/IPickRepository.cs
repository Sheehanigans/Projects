using System;
using System.Collections.Generic;
using System.Text;

namespace RyanSheehanPowerball
{
    public interface IPickRepository
    {
        Pick Create(Pick pick); //create pick, return pick and id

        Pick FindById(int identifier); //return pick with id, null if nonexistant 

        IEnumerable<Pick> FindBestMatches(Pick draw); //draw
    }
}
