using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RyanSheehanPowerball
{
    public class PickRepository
    {
        private string _filePath;

        public PickRepository (string filePath)
        {
            filePath = _filePath;
        }

        public void Add(Pick pick)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                string line = CreateCSVForPick(pick);

                sw.WriteLine(line);
            }
        }

        private string CreateCSVForPick(Pick pick)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                pick.PickID, pick.FirstName, pick.LastName, pick.PickNumbers[0], pick.PickNumbers[1], pick.PickNumbers[2],
                pick.PickNumbers[3], pick.PickNumbers[4], pick.Powerball);
        }
    }
}
