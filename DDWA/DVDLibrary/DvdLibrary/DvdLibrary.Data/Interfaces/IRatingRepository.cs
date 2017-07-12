using DvdLibrary.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.Interfaces
{
    public interface IRatingRepository
    {
        List<Rating> GetAll();
        Rating GetById(int ratingId);
        Rating GetByName(string ratingName);
    }
}
