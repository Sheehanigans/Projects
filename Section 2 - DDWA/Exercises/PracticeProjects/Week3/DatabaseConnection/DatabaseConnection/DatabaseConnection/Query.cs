using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseConnection
{
    public class Query
    {
        public static void ExecuteQuery()
        {
            string connectionString = "server=(local);database=Northwind;integrated Security=SSPI;";

            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT TOP 20 * FROM dbo.Customers ORDER BY CustomerID";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    DataTable customerTable = new DataTable("Top5Customers");

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    _dap.Fill(customerTable);

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        Console.WriteLine("{0} \t | {1} \t | {2} \t | {3} \t | {4}", "CustomerID", "Company Name", "Customer Name", "Position", "Address");

                        // while there is another record present
                        while (reader.Read())
                        {
                            // write the data on to the screen
                            Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4}",
                            // call the objects from their index
                            reader[0], reader[1], reader[2], reader[3], reader[4]));
                        }
                    }

                    Console.ReadLine();

                    _con.Close();
                }
            }
        }
    }
}
