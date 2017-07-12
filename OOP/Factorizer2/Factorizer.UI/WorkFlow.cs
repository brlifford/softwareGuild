using Factorizor.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer.UI
{
    public class WorkFlow
    {
        FactorFinder _finder;

        public void FindFactors()
        {
            CreateFactorFinderInstance();
            ConsoleOutput.DisplayTitle();

            FactorMessage message;
            int numToFactor;

            do
            {
                numToFactor = ConsoleInput.NumToFactor();
                message = _finder.ProcessFactor(numToFactor);
            } while (numToFactor > 0);
        }

        private void CreateFactorFinderInstance()
        {
            int numToFactor = ConsoleInput.NumToFactor();
            _finder = new FactorFinder();
            _finder.FindFactors(numToFactor);
        }
    }
}
