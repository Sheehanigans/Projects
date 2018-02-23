using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Nasdaqreader
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. open the file 

            //string dir = Environment.GetFolderPath(Environment.SpecialFolder.);

            string dir = @"C:\Repos\ryan-sheehan-individual-work\Exercises\Nasdaqreader";
            FileInfo quoteFileInfo = new FileInfo(Path.Combine(dir, "HistoricalQuotes.csv")); //make sure to include the file type

            List<DailyQuote> allQuotes = new List<DailyQuote>();

            if (quoteFileInfo.Exists)
            {
                //do something - this is for validation that a file exists
                Console.WriteLine("File located");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("no file");
                Console.ReadLine();
            }

            //2. read all data into a list 

            TextReader quoteReader = quoteFileInfo.OpenText();

            quoteReader.ReadLine(); //advances cursor through the file so we do not write the column headers

            for (string line = quoteReader.ReadLine();
                line != null;
                line = quoteReader.ReadLine())
            {
                string[] cells = line.Replace("\"","").Split(','); // \" escapes the quotes. Want a string containing a quote character, replace string with empty string 

                DateTime date = DateTime.ParseExact(cells[0], @"yyyy/MM/dd",CultureInfo.CurrentCulture);//CultureInfo gives extra info for whichever part of the world 
                decimal close = decimal.Parse(cells[1]); //in real life, we would alway tryparse first 
                long volume = long.Parse(cells[2].Remove(cells[2].Length - 5)); //trim off the last 5 characters .0000
                decimal open = decimal.Parse(cells[3]);
                decimal high = decimal.Parse(cells[4]);
                decimal low = decimal.Parse(cells[5]);

                DailyQuote quote = new DailyQuote
                {
                    Date = date,
                    Close = close,
                    Volume = volume,
                    Open = open,
                    High = high,
                    Low = low
                };

                allQuotes.Add(quote);
            }

            //3. compute andn display the average close 

            decimal sum = 0.0M;

            //read each quote and add

            foreach (DailyQuote quote in allQuotes)
            {
                sum += quote.Close;
            }

            decimal average = sum / allQuotes.Count;

            Console.WriteLine("Average close is: " + average.ToString("c")); // 'c' 
            Console.ReadLine();
        }
    }
}
