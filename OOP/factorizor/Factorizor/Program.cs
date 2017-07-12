using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumberFromUser();

            Calculator.PrintFactors(number);
            Calculator.IsPerfectNumber(number);
            Calculator.IsPrimeNumber(number);

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompt the user for an integer.  Make sure they enter a valid integer!
        /// 
        /// See the String Input lesson for TryParse() examples
        /// </summary>
        /// <returns>the user input as an integer</returns>

        static int GetNumberFromUser()

        {
            string input;
            int output;

            while (true)
            {
                Console.WriteLine("Please enter a positive integer: ");
                input = Console.ReadLine();

                if (int.TryParse(input, out output))
                {
                    if (output < 0)
                    {
                        Console.WriteLine("That's not a positive integer!");
                        continue;
                    }
                    else
                        break;
                }
                else
                    Console.WriteLine("That's not a number!");
            }
            return output;

            throw new NotImplementedException();
        }
    }

    class Calculator
    {
        /// <summary>
        /// Given a number, print the factors per the specification
        /// </summary>
        public static void PrintFactors(int number)

        {
            int i;
            for (i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    Console.Write($"{i } \n");
                }
            }
        }

        /// <summary>
        /// Given a number, print if it is perfect or not
        /// </summary>
        public static void IsPerfectNumber(int number)
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
                Console.WriteLine($"{number} is a perfect number.");
            }

        }

        /// <summary>
        /// Given a number, print if it is prime or not
        /// </summary>
        public static void IsPrimeNumber(int number)
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
                Console.WriteLine($"{number } is a prime number.");
            }
            else
            {
                Console.WriteLine($"{number } is not a prime number.");
            }
        }

    }
}