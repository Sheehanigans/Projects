using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RyanSheehanPowerball
{
    public class PickRepository
    {
        private string _filePath;

        public PickRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Pick> List()
        {
            List<Pick> picks = new List<Pick>();

            using (StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string line;

                while((line = sr.ReadLine()) != null)
                {
                    Pick newPick = new Pick();

                    string[] columns = line.Split(',');

                    newPick.PickID = int.Parse(columns[0]);
                    newPick.FirstName = columns[1];
                    newPick.LastName = columns[2];
                    newPick.PickNumbers[0] = int.Parse(columns[3]);
                    newPick.PickNumbers[1] = int.Parse(columns[4]);
                    newPick.PickNumbers[2] = int.Parse(columns[5]);
                    newPick.PickNumbers[3] = int.Parse(columns[6]);
                    newPick.PickNumbers[4] = int.Parse(columns[7]);
                    newPick.Powerball = int.Parse(columns[8]);

                    picks.Add(newPick);
                }

                return picks;
            }
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
                pick.PickID, pick.FirstName, pick.LastName, pick.PickNumbers[0], pick.PickNumbers[1], 
                pick.PickNumbers[2],pick.PickNumbers[3], pick.PickNumbers[4], pick.Powerball);
        }
    }
}
