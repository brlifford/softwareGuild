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
    public class DirectorRepositoryADO : IDirectorRepository
    {
        public List<Director> GetAll()
        {
            List<Director> directors = new List<Director>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DirectorsSelectAll");
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        Director row = new Director();
                        row.DirectorId = (int)dr["DirectorId"];
                        row.DirectorName = dr["DirectorName"].ToString();

                        directors.Add(row);
                    }
                }
            }
            return directors;
        }

        Director IDirectorRepository.GetById(int directorId)
        {
            var director = new Director();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DirectorsSelectById");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DirectorId", directorId);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    if (dr.Read())
                    {
                        
                        director.DirectorId = (int)dr["DirectorId"];
                        director.DirectorName = dr["DirectorName"].ToString();
                    }
                }
            }
            return director;
        }

        Director IDirectorRepository.GetByName(string directorName)
        {
            var director = new Director();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DirectorsSelectByName");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DirectorName", directorName);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    if (dr.Read())
                    {

                        director.DirectorId = (int)dr["DirectorId"];
                        director.DirectorName = dr["DirectorName"].ToString();
                    }
                }
            }
            return director;
        }
    }
}
