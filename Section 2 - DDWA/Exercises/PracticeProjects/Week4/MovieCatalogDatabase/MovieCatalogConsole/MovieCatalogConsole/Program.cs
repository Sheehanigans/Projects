using MovieCatalogConsole.Models;
using MovieCatalogConsole.Repos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ratingRepo = new RatingRepo();

            //var ratingVeryBad = new Rating { RatingName = "Very bad" };
            //ratingRepo.Save(ratingVeryBad);


            ratingRepo.DeleteById(5);

            foreach (var rating in ratingRepo.All())
            {
                Console.WriteLine($"{rating.RatingId}: {rating.RatingName}");
            }


            Console.ReadKey();
        }

        private static void CreateUpdateGenreProc()
        {
            const string createProcSql = @"
            CREATE PROCEDURE UpdateGenre
            @GenreId int,
            @GenreType varchar(50)
            AS
            BEGIN
                UPDATE Genre SET
                    GenreType = @GenreType
                WHERE GenreId = @GenreId;
            END
            ";
            using (var connection = GetOpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = createProcSql; // ddl, not dml. will it work?
                var result = command.ExecuteNonQuery();
            }

        }

        private static void InsertGenre()
        {
            using (var connection = GetOpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "GenreInsert";
                command.CommandType = CommandType.StoredProcedure;

                var idParm = command.CreateParameter();
                idParm.ParameterName = "@GenreId";
                idParm.DbType = DbType.Int32;
                idParm.Direction = ParameterDirection.Output;

                command.Parameters.Add(idParm);
                command.Parameters.AddWithValue("@GenreType", "Suspense");

                var result = command.ExecuteNonQuery();

                Console.WriteLine(idParm.Value);

            }
        }

        private static SqlConnection GetOpenConnection()
        {
            const string connectionString = "server=.\\SQLEXPRESS;database=MovieCatalog;Integrated Security=SSPI;";

            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

    }
}
