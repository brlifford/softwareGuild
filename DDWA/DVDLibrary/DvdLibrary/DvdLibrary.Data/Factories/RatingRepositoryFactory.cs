using DvdLibrary.Data.ADO;
using DvdLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.Factories
{
    public static class RatingRepositoryFactory
    {
        public static IRatingRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new RatingRepositoryADO();
                case "Mock":
                    throw new NotImplementedException();
                case "EF":
                    throw new NotImplementedException();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
