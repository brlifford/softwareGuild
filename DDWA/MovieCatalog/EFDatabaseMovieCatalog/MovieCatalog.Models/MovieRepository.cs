using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCatalog.Data;

namespace MovieCatalog.Models
{
    public class MovieRepository
    {
        public IEnumerable<MovieListView> GetAllMovies()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
            }
        }
    }
}
