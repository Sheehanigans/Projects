using System;
using System.Collections.Generic;
using System.Text;

namespace RyanSheehanPowerball
{
    public interface IPickRepository
    {
        // my current concrete repo has different methods that directlty write to the file.
        // There could be an extra layer below it that writes to the file and the repo could handle managing those calls
        // ... this is a template: 

        //Pick Create(Pick pick); //create pick, return pick and id

        //Pick FindById(int identifier); //return pick with id, null if nonexistant 

        //IEnumerable<Pick> FindBestMatches(Pick draw); //draw

        List<Pick> List();

        void Add(Pick pick);


    }

}
