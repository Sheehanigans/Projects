using System.Data.SqlClient;

namespace MovieCatalogConsole.Repos
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
