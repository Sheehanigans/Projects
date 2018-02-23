using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. open the files 

            string dir = @"C:\Repos\mpls-dotnet-jan-2018\FileInstructions";

            DirectoryInfo direct = new DirectoryInfo(dir);

            string[] paths = Directory.GetFiles(@"C:\Repos\mpls-dotnet-jan-2018\FileInstructions");

            foreach (string path in paths)
            {
                ProcessFile(path);
            }
        }

        private static void ProcessFile(string path)
        {
            //open file 
            //read all lines 

            string text = File.ReadAllText(path);

            //do action

            if (text.Contains("MOVE"))
            {
                File.Move(path, @"C:\Repos\mpls-dotnet-jan-2018\FileInstructions\MoveMe\Moved.txt");
            }
            else if (text.Contains("COPY"))
            {
                File.Copy(path, @"C:\Repos\mpls-dotnet-jan-2018\FileInstructions\File4.txt");
            }
            else if (text.Contains("DELETE"))
            {
                File.Delete(path);
            }
        }
    }
}
