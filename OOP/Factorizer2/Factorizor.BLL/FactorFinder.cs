using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class FactorFinder
    {
        private bool IsValidNum(int numToFactor)
        {
            if (numToFactor <= 0)
                return true;
            else
                return false;
        }

        public int[] FindFactors(int numToFactor)
        {
            int i;
            int[] factorArray = new int[numToFactor + 1];
            int numFactors = 0;
            for (i = 1; i <= numToFactor; i++)
            {
                if (numToFactor % i == 0)
                {
                    numFactors++;

                    factorArray[i] = i;
                }
            }
            return factorArray;
        }

        public FactorMessage ProcessFactor(int numToFactor)
        {
            if (!IsValidNum(numToFactor))
            {
                return FactorMessage.Invalid;
            }
            else if (PrimeChecker.IsPrimeNumber(numToFactor))
            {
                return FactorMessage.Prime;
            }
            else if (PerfectChecker.IsPerfectNumber(numToFactor))
            {
                return FactorMessage.Perfect;
            }
            else
                return FactorMessage.OnlyFactors;
        }
    }
}

