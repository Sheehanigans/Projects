using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace StoredProceeduresFunTime
{
    public class Insert
    {
        public bool InsertData (string connectionString, string tableName, Dictionary<string, string> colValPairs)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO";

                cmd.CommandText += " " + tableName + " ";

                foreach (var val in colValPairs)
                {
                    if 
                }
            }

            return true;
        }
    }
}
