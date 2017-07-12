using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Models.Tables
{
    public class Dvd
    {
        public int DvdId { get; set; }
        public string Title { get; set; }
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RatingId { get; set; }
        public string RatingName { get; set; }
        public object DvdNotes { get; set; }
    }
}
