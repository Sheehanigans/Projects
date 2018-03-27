using CarDealership.Data.Settings;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADORepositories
{
    public class SpecialRepository : ISpecialRepository
    {
        public List<Special> GetSpecials()
        {
            List<Special> specials = new List<Special>();

            using(var cn = new SqlConnection(ConnectionStrings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetSpecials", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special row = new Special();

                        row.SpecialId = (int)dr["SpecialId"];
                        row.SpecialTitle = dr["SpecialTitle"].ToString();
                        row.SpecialMessage = dr["SpecialMessage"].ToString();

                        specials.Add(row);
                    }
                }
            }

            return specials;
        }
    }
}
