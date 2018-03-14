using MovieCatalogConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace MovieCatalogConsole.Repos
{
    public class RatingRepo
    {
        //1. select one 
        public Rating GetById(int id)
        {
            using (var connection = Database.GetOpenConnection())
            {
                return connection.QuerySingleOrDefault<Rating>
                    (
                    "SELECT RatingId, RatingName FROM Rating WHERE RatingId = @RatingId",
                    new { Ratingid = id });
            }
        }

        //2. select all 

        public IEnumerable<Rating> All()
        {
            using (var connetion = Database.GetOpenConnection())
            {
                return connetion.Query<Rating>("SELECT RatingId, RatingName FROM Rating");
            }
        }
        //3. add
        //4. update 

        public Rating Save (Rating rating)
        {
            if (rating.RatingId > 0)
            {
                Update(rating);
            }
            else
            {
                rating = Insert(rating);
            }

            return rating;
        }

        public Rating Insert (Rating rating)
        {
            using (var connection = Database.GetOpenConnection())
            {
                connection.Execute(
                    "RatingInsert",
                    rating,
                    commandType: CommandType.StoredProcedure);
            }

            return rating;
        }

        public bool Update (Rating rating)
        {
            const string sql = "UPDATE Rating SET " +
                "RatingName = @RatingName" +
                "WHERE RatingId = @RatingId";

            using (var connection = Database.GetOpenConnection())
            {
                var rowsAffected = connection.Execute(sql, rating);
                return rowsAffected == 1;
            }
        }

        //5. delete

        public bool DeleteById(int id)
        {
            const string sql = "DELETE FROM Rating WHERE RatingId = @RatingId";
            using (var connection = Database.GetOpenConnection())
            {
                var rowsAffected = connection.Execute(sql, new { RatingId = id });
                return rowsAffected == 1;
            }
        }
    }
}
