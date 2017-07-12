using DvdLibrary.Models.Queries;
using DvdLibrary.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.Interfaces
{
    public interface IDvdRepository
    {
        Dvd GetById(int dvdId);
        void Insert(DvdShortItem model);
        void Update(Dvd dvd);
        void Delete(int dvdId);
        DvdShortItem GetDetails(int dvdId);
        List<Dvd> GetAll();
        List<Dvd> GetByTitle(string title);
        List<Dvd> GetByRating(string ratingName);
        List<Dvd> GetByDirector(string directorName);
        List<Dvd> GetByReleaseDate(DateTime date);
    }
}
