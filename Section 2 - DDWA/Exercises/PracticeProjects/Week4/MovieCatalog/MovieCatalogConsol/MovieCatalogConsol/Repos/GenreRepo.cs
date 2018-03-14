using MovieCatalogConsol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace MovieCatalogConsol.Repos
{
    public class GenreRepo
    {
        //1. get 
        public Genre GetById (int id)
        {
            using (var connection = Database.GetOpenConnection())
            {
                return connection.QuerySingleOrDefault<Genre>(
                    "SELECT GenreId, GenreType FROM Genre WHERE GenreId = @GenreId",
                    new { GenreId = id });
            }
        }
        
        
        //2. get all
        public IEnumerable<Genre> All()
        {
            using (var connection = Database.GetOpenConnection())
            {
                return connection.Query<Genre>("SELECT GenreId, GenreType FROM Genre");
            }
        }


        //3. edit 
        public Genre Save (Genre genre)
        {
            if (genre.GenreId > 0)
            {
                Update(genre); //what happens if it dont work
            }
            else
            {
                genre = Insert(genre);
            }

            return genre;
        }

        private Genre Insert(Genre genre)
        {
            //const string sql = "INSERT INTO Genre (GenreType) VALUES (@GenreType); " +
            //    "SELECT SCOPE_IDENTITY();"; //scope identity give you the last identity value 
            //using (var connection = Database.GetOpenConnection())
            //{
            //    genre.GenreId = connection.QuerySingleOrDefault<int>(sql, genre);
            //}

            using (var connection = Database.GetOpenConnection())
            {
                connection.Execute("GenreInsert",
                    genre,
                    commandType: CommandType.StoredProcedure); //need to use system.data namespace
            }

            return genre;
        }
        //4. update 

        private bool Update(Genre genre)
        {
            const string sql = "UPDATE Genre SET " +
                "GenreType = @GenreType" +
                "WHERE GenreId = @GenreId";
            using (var connection = Database.GetOpenConnection())
            {
                var rowsAffected = connection.Execute(sql, genre);
                return rowsAffected > 0;
            }
        }

        //5. delete
        public bool DeleteById(int id)
        {
            const string sql = "DELETE FROM Genre WHERE GenreId = @GenreId";

            using (var connection = Database.GetOpenConnection())
            {
                var rowsAffected = connection.Execute(sql, new { GenreId = id });
                return rowsAffected == 0;
            }
        }
    }
}
