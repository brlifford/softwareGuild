using Ninject;
using SGBank.Data;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public static class DIContainer
    {
        public static IKernel Kernel = new StandardKernel();

        static DIContainer()
        {
            string repoType = ConfigurationManager.AppSettings["Mode"].ToString();

            if(repoType == "FileRepo")
            {
                Kernel.Bind<IAccountRepository>().To<FileAccountRepository>();
            }

            else if (repoType == "BasicTest")
            {
                Kernel.Bind<IAccountRepository>().To<BasicAccountTestRepository>();
            }

            else if(repoType == "FreeTest")
            {
                Kernel.Bind<IAccountRepository>().To<FreeAccountTestRepository>();
            }

            else if(repoType == "PremiumTest")
            {
                Kernel.Bind<IAccountRepository>().To<PremiumAccountTestRepository>();
            }

            else
            {
                throw new Exception("Repo Type key in app.config is not set properly!");
            }
        }
    }
}
