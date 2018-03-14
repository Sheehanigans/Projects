using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MovieCatalogConsol.Repos;
using MovieCatalogConsol.Models;

namespace MovieCatalogConsol
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new GenreRepo();

            //to get a genre by id
            //var genre = repo.GetById(5);
            //genre.GenreType = "Rom/Com";
            //repo.Save(genre);



            var familyHorror = new Genre { GenreType = "Family Horror " };
            repo.Save(familyHorror);

            Console.WriteLine(familyHorror.GenreType);




            //repo.DeleteById(7);

            //foreach (var genre in repo.All())
            //{
            //    Console.WriteLine(genre.GenreType);
            //}



            //var familyHorror = new Genre { GenreType = "Family Horror " };
            //repo.Save(familyHorror);

            //foreach (var genre in repo.All())
            //{
            //    Console.WriteLine($"{genre.GenreId} - {genre.GenreType}");
            //}

            //Console.ReadLine();
        }

        private static void CreateUpdateGenreProc()
        {
            const string createProcSql = @"
            CREATE PROCEDURE UpdateGenre
	            @GenreId int,
	            @GenreType Varchar(50)
            AS 
            BEGIN 
                UPDATE Genre SET 
                    GenreType = @GenreType
                    WHERE GenreId = @GenreId;
            END";
            using (var connection = GetOpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = createProcSql;
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

                //basicall an output parameter
                var idParam = command.CreateParameter();
                idParam.ParameterName = "@GenreId";
                idParam.DbType = DbType.Int32;
                idParam.Direction = ParameterDirection.Output;

                command.Parameters.Add(idParam);
                command.Parameters.AddWithValue("@GenreType", "Suspense");

                var result = command.ExecuteNonQuery();

                Console.WriteLine(idParam.Value);

            }

            Console.ReadLine();
        }

        private static void GenreSelect()
        {
            using (var connection = GetOpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "GenreSelectAll";
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["GenreType"]);
                    }
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
        }

        private static SqlConnection GetOpenConnection()
        {
            const string connectionString = "server=(local);database=MovieCatalog;Integrated Security=SSPI;";

            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;               
        }
    }
}
