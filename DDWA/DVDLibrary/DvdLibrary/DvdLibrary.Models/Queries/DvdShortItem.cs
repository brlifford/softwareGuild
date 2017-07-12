using DvdLibrary.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Models.Queries
{
    public class DvdShortItem
    {
        public int? DvdId { get; set; }
        public string Title { get; set; }
        public string RealeaseYear { get; set; }
        public int? DirectorId { get; set; }
        public string DirectorName { get; set; }
        public int? RatingId { get; set; }
        public string RatingName { get; set; }
    }
}
