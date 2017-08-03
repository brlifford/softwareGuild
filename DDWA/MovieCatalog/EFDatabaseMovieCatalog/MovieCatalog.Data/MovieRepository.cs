using Dapper;
using MovieCatalog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.Data
{
    public class MovieRepository
    {
        public IEnumerable<MovieListView> GetAllMovies()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["MovieCatalog"]
                    .ConnectionString;

                return cn.Query<MovieListView>("MovieSelectAll",
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Movie GetMovieById(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["MovieCatalog"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@MovideId", id);

                return cn.Query<Movie>(
                    "MovieSelectById",
                    parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void MovieDelete(int id)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["MovieCatalog"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@MovieId", id);

                cn.Execute("MovieDelete",
                    parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void MovieInsert(Movie movie)
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["MovieCatalog"]
                    .ConnectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@MovieId",
                    dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Title", movie.Title);
                parameters.Add("@GenreId", movie.GenreId);
                parameters.Add("@RatingId", movie.RatingId);

                cn.Execute("MovieInsert",
                    parameters, commandType: CommandType.StoredProcedure);

                movie.MovieId = parameters.Get<int>("@MovieId");
            }
        }
    }
}
