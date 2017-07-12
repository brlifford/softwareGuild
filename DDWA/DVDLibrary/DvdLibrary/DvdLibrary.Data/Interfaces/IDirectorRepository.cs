using DvdLibrary.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.Interfaces
{
    public interface IDirectorRepository
    {
        List<Director> GetAll();
        Director GetById(int directorId);
        Director GetByName(string directorName);
    }
}
