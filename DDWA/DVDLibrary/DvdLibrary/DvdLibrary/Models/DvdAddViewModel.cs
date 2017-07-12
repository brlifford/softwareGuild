using DvdLibrary.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrary.Models
{
    public class DvdAddViewModel
    {
        public Dvd Dvd { get; set; }
        public string Title { get; set; }
        public string RealeaseYear { get; set; }
        public string DirectorName { get; set; }
        public string Rating { get; set; }
    }
}