using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer.UI
{
    public class ConsoleInput
    {
        public static int NumToFactor()
        {
            Console.Clear();
            int output;
            string input = "";

            bool isValidInput = true;


            Console.Write("Enter a positive number to factor: ");
            input = Console.ReadLine();

            if (input == "q" || int.TryParse(input, out output))
            {
                isValidInput = true;
                if(output == int.Parse(input))
                {

                }
            }

            else
            {
                isValidInput = false;
                Console.WriteLine("That's not a valid number! Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
