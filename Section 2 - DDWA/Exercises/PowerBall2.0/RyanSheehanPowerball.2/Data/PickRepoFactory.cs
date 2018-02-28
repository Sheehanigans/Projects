using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RyanSheehanPowerball._2.Data
{
    public static class PickRepoFactory
    {
        public static IPickRepository Create()
        {
            IPickRepository repo = null;

            //add descision logic here. Grab setting from file

            string repoType = ConfigurationManager.AppSettings["repoType"];

            //switch based on setting value 
            switch (repoType)
            {
                case "memory":
                    repo = new PickInMemoryRepo();
                    break;
                case "file":
                    repo = new PickRepository(Settings.FilePath);
                    break;
                default:
                    //select proper exception TODO
                    throw new Exception("unexpected setting for repo type");

                //case "another repo"
            }

            //instantiate correct repo 
            //return repo 

            repo = new PickRepository(Settings.FilePath);

            return repo;
        }
    }
}
