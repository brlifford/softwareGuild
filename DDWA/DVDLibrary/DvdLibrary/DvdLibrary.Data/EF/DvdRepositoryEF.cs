using DvdLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models.Queries;
using DvdLibrary.Models.Tables;

namespace DvdLibrary.Data.EF
{
    public class DvdRepositoryEF : IDvdRepository
    {
        public void Delete(int dvdId)
        {
            throw new NotImplementedException();
        }

        public List<Models.Tables.Dvd> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Models.Tables.Dvd> GetByDirector(string directorName)
        {
            throw new NotImplementedException();
        }

        public DvdRepositoryEF GetById(int dvdId)
        {
            throw new NotImplementedException();
        }

        public List<Models.Tables.Dvd> GetByRating(string ratingName)
        {
            throw new NotImplementedException();
        }

        public List<Models.Tables.Dvd> GetByReleaseDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Models.Tables.Dvd> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public DvdShortItem GetDetails(int dvdId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Models.Tables.Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public DvdRepositoryEF Insert(string title, DateTime date, string directorName, string ratingName, string dvdNotes)
        {
            throw new NotImplementedException();
        }

        public void Insert(DvdShortItem model)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.Tables.Dvd dvd)
        {
            throw new NotImplementedException();
        }

        Models.Tables.Dvd IDvdRepository.GetById(int dvdId)
        {
            throw new NotImplementedException();
        }
    }
}
