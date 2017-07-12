using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.EF
{
    public class Dvd
    {
        public int DvdId { get; set; }
        public string Title { get; set; }
        public int DirectorId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RatingId { get; set; }
        public string DvdNotes { get; set; }

        public virtual Director Director { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
