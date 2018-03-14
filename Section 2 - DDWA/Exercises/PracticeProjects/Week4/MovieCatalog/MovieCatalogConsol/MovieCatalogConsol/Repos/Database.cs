using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogConsol.Repos
{
    public static class Database
    {
        public static SqlConnection GetOpenConnection()
        {
            const string connectionString = "server=(local);database=MovieCatalog;Integrated Security=SSPI;";

            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
