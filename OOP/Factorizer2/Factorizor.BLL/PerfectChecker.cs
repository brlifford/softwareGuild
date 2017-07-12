using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class PerfectChecker
    {
        public static bool IsPerfectNumber(int number)
        {
            int i;
            int result = 0;

            for (i = 1; i < number; i++)
            {

                if (number % i == 0)
                {
                    result += i;
                }
            }
            if (result == number)
            {
                return true;
            }
            else
                return false;
            //{
            //    Console.WriteLine($"{number} is a perfect number.");
            //}

        }
    }
}
