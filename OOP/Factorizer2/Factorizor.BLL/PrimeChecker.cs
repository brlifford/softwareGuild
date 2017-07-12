using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class PrimeChecker
    {
        public static bool IsPrimeNumber(int number)
        {
            int i;
            int isFactor = 0;
            for (i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    isFactor++;

                }

            }
            if (isFactor < 3)
            {
                return true;
            }
            else
                return false;
        }
    }
}
