using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProceeduresFunTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Insert insert = new Insert();
            insert.InsertData("server=(local);database=Northwind;integrated Security=SSPI;",);
        }
    }
}
