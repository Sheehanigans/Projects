using MovieCatalogConsole.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MovieCatalogConsole.Repos
{
    public class GenreRepo
    {
        // 1. read/get
        public Genre GetById(int id)
        {
            using (var connection = Database.GetOpenConnection())
            {
                return connection.QuerySingleOrDefault<Genre>(
                    "SELECT GenreId, GenreType FROM Genre WHERE GenreId = @GenreId",
                    new { GenreId = id });
            }
        }

        // 2. read/get all
        public IEnumerable<Genre> All()
        {
            using (var connection = Database.GetOpenConnection())
            {
                return connection.Query<Genre>("SELECT GenreId, GenreType FROM Genre");
            }
        }

        // 3. edit/update
        public Genre Save(Genre genre)
        {
            if (genre.GenreId > 0)
            {
                Update(genre); // TODO: what happens if it doesn't work?
            }
            else
            {
                genre = Insert(genre);
            }
            return genre;
        }

        private Genre Insert(Genre genre)
        {
            using (var connection = Database.GetOpenConnection())
            {
                connection.Execute(
                    "GenreInsert",
                    genre,
                    commandType: CommandType.StoredProcedure);
            }

            return genre;
        }

        private bool Update(Genre genre)
        {
            const string sql = "UPDATE Genre SET "
                + "GenreType = @GenreType "
                + "WHERE GenreId = @GenreId";

            using (var connection = Database.GetOpenConnection())
            {
                var rowsAffected = connection.Execute(sql, genre);
                return rowsAffected == 1;
            }
        }
        // 4. delete
        public bool DeleteById(int id)
        {
            const string sql = "DELETE FROM Genre WHERE GenreId = @GenreId";
            using (var connection = Database.GetOpenConnection())
            {
                var rowsAffected = connection.Execute(sql, new { GenreId = id });
                return rowsAffected == 1;
            }
        }
    }
}
