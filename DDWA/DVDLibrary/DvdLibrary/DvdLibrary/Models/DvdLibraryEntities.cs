using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DvdLibrary.Models
{
    public class DvdLibraryEntities : DbContext
    {
        public DvdLibraryEntities() : base("DvdLibrary")
        {

        }

        public DbSet<Dvd> Dvds { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}