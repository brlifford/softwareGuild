using DvdLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models.Queries;
using DvdLibrary.Models.Tables;

namespace DvdLibrary.Data.Mock
{
    public class DvdRepositoryMock : IDvdRepository
    {
        public void Delete(int dvdId)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetByDirector(string directorName)
        {
            throw new NotImplementedException();
        }

        public Dvd GetById(int dvdId)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetByRating(string ratingName)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetByReleaseDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public DvdShortItem GetDetails(int dvdId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public Dvd Insert(string title, DateTime date, string directorName, string ratingName, string dvdNotes)
        {
            throw new NotImplementedException();
        }

        public void Insert(DvdShortItem model)
        {
            throw new NotImplementedException();
        }

        public void Update(Dvd dvd)
        {
            throw new NotImplementedException();
        }
    }
}
