using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableExample
{
    public class MovieRating : IComparable<MovieRating>
    {
        public string Title { get; set; }
        public int Rating { get; set; }

        public int CompareTo(MovieRating other)
        {
            // Not common
            if (other == null)
            {
                return 1; // This exists so it's greater.
            }

            // Compare base on the Rating only.
            return this.Rating.CompareTo(other.Rating);
        }
    }
}
