using DvdLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models.Queries;
using DvdLibrary.Models.Tables;
using System.Data.SqlClient;
using System.Data;

namespace DvdLibrary.Data.ADO
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void Delete(int dvdId)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdDelete");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public Dvd GetById(int dvdId)
        {
            Dvd dvd = new Dvd();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectById");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);
                cmd.Connection = conn;
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if(dr.Read())
                    {
                        
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.DirectorId = (int)dr["DirectorId"];
                        dvd.DirectorName = dr["DirectorName"].ToString();
                        dvd.ReleaseDate = (DateTime)dr["ReleaseDate"];
                        dvd.RatingId = (int)dr["RatingId"];
                        dvd.RatingName = dr["RatingName"].ToString();
                    }
                }
            }
            return dvd;
        }

        public List<Dvd> GetAll()
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdsSelectAll");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    
                    while(dr.Read())
                    {
                        Dvd row = new Dvd();
                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.DirectorId = (int)dr["DirectorId"];
                        row.DirectorName = dr["DirectorName"].ToString();
                        row.ReleaseDate = (DateTime)dr["ReleaseDate"];
                        row.RatingId = (int)dr["RatingId"];
                        row.RatingName = dr["RatingName"].ToString();

                        if (dr["DvdNotes"] != DBNull.Value)
                            row.DvdNotes = dr["DvdNotes"].ToString();

                        dvds.Add(row);
                    }
                }
            }
                return dvds;
        }

        public Dvd Insert(string title, DateTime date, string directorName, string ratingName, string dvdNotes)
        {
            Dvd dvd = null;
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdInsert");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                SqlParameter paramDvdId = new SqlParameter("@DvdId", SqlDbType.Int);
                paramDvdId.Direction = ParameterDirection.Output;

                SqlParameter paramDirectorId = new SqlParameter("@DirectorId", SqlDbType.Int);
                paramDirectorId.Direction = ParameterDirection.Output;

                SqlParameter paramRatingId = new SqlParameter("@RatingId", SqlDbType.Int);
                paramRatingId.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(paramDvdId);
                cmd.Parameters.Add(paramDirectorId);
                cmd.Parameters.Add(paramRatingId);

                cmd.Parameters.AddWithValue("@Title", title);
                
                cmd.Parameters.AddWithValue("@DirectorName", directorName);
                cmd.Parameters.AddWithValue("@ReleaseDate", date);
                
                cmd.Parameters.AddWithValue("@RatingName", ratingName);
                cmd.Parameters.AddWithValue("@DvdNotes", dvdNotes);


                conn.Open();

                cmd.ExecuteNonQuery();

                dvd.DvdId = (int)paramDvdId.Value;
                dvd.DirectorId = (int)paramDirectorId.Value;
                dvd.RatingId = (int)paramRatingId.Value;

                dvd.DirectorName = directorName;
                dvd.RatingName = ratingName;
                dvd.ReleaseDate = date;
                dvd.Title = title;
                dvd.DvdNotes = dvdNotes;
            }
            return dvd;
        }

        public void Update(Dvd dvd)
        {

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdUpdate");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@DirectorId", dvd.DirectorId);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);
                cmd.Parameters.AddWithValue("@ReleaseDate", dvd.ReleaseDate);
                cmd.Parameters.AddWithValue("@RatingId", dvd.RatingId);
                cmd.Parameters.AddWithValue("@RatingName", dvd.RatingId);
                cmd.Parameters.AddWithValue("@DvdNotes", dvd.DvdNotes);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Dvd> GetByTitle(string title)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectByTitle");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@Title", title);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();
                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.DirectorId = (int)dr["DirectorId"];
                        row.DirectorName = dr["DirectorName"].ToString();
                        row.ReleaseDate = (DateTime)dr["ReleaseDate"];
                        row.RatingId = (int)dr["RatingId"];
                        row.RatingName = dr["RatingName"].ToString();

                        if (dr["DvdNotes"] != DBNull.Value)
                            row.DvdNotes = dr["DvdNotes"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetByReleaseDate(DateTime date)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectByDate");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@ReleaseDate", date);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();
                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.DirectorId = (int)dr["DirectorId"];
                        row.DirectorName = dr["DirectorName"].ToString();
                        row.ReleaseDate = (DateTime)dr["ReleaseDate"];
                        row.RatingId = (int)dr["RatingId"];
                        row.RatingName = dr["RatingName"].ToString();

                        if (dr["DvdNotes"] != DBNull.Value)
                            row.DvdNotes = dr["DvdNotes"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetByDirector(string directorName)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectByDirector");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@DirectorName", directorName);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();
                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.DirectorId = (int)dr["DirectorId"];
                        row.DirectorName = dr["DirectorName"].ToString();
                        row.ReleaseDate = (DateTime)dr["ReleaseDate"];
                        row.RatingId = (int)dr["RatingId"];
                        row.RatingName = dr["RatingName"].ToString();

                        if (dr["DvdNotes"] != DBNull.Value)
                            row.DvdNotes = dr["DvdNotes"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetByRating(string ratingName)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectByRating");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@RatingName", ratingName);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd row = new Dvd();
                        row.DvdId = (int)dr["DvdId"];
                        row.Title = dr["Title"].ToString();
                        row.DirectorId = (int)dr["DirectorId"];
                        row.DirectorName = dr["DirectorName"].ToString();
                        row.ReleaseDate = (DateTime)dr["ReleaseDate"];
                        row.RatingId = (int)dr["RatingId"];
                        row.RatingName = dr["RatingName"].ToString();

                        if (dr["DvdNotes"] != DBNull.Value)
                            row.DvdNotes = dr["DvdNotes"].ToString();

                        dvds.Add(row);
                    }
                }
            }
            return dvds;
        }

        public void Insert(DvdShortItem model)
        {
            throw new NotImplementedException();
        }

        public DvdShortItem GetDetails(int dvdId)
        {
            throw new NotImplementedException();
        }
    }
}
