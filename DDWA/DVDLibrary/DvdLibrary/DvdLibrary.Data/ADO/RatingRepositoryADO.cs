using DvdLibrary.Data.Interfaces;
using DvdLibrary.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.ADO
{
    public class RatingRepositoryADO : IRatingRepository
    {
        public List<Rating> GetAll()
        {
            List<Rating> ratings = new List<Rating>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("RatingsSelectAll");
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        Rating row = new Rating();
                        row.RatingId = (int)dr["RatingId"];
                        row.RatingName = dr["RatingName"].ToString();

                        ratings.Add(row);
                    }
                }
            }
            return ratings;
        }

        
        public Rating GetById(int ratingId)
        {
            var rating = new Rating();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("RatingSelectById");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RatingId", ratingId);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    if (dr.Read())
                    {

                        rating.RatingId = (int)dr["RatingId"];
                        rating.RatingName = dr["RatingName"].ToString();
                    }
                }
            }
            return rating;
        }

        public Rating GetByName(string ratingName)
        {
            var rating = new Rating();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("RatingSelectByName");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RatingName", ratingName);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    if (dr.Read())
                    {

                        rating.RatingId = (int)dr["RatingId"];
                        rating.RatingName = dr["RatingName"].ToString();
                    }
                }
            }
            return rating;
        }
    }
}
