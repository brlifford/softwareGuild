using Factorizor.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer.UI
{
    public class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Better, Testable Factorizor!\n\n");
            Console.WriteLine("Press any key to start the game...");
            Console.ReadKey();
        }

        public static void DisplayFactorMessage(FactorMessage message)
        {
            switch(message)
            {
                case FactorMessage.Invalid:
                    DisplayInvalid();
                    break;
                case FactorMessage.OnlyFactors:
                    DisplayOnlyFactors();
                    break;
                case FactorMessage.Perfect:
                    DisplayPerfect();
                    break;
                case FactorMessage.Prime:
                    DisplayPrime();
                    break;
            }
        }

        private static void DisplayOnlyFactors()
        {
            Console.WriteLine("Your number returns factors.");
            Console.WriteLine("Press 'q' to quit. Press any key to continue...");
            Console.ReadKey();
        }

        private static void DisplayPrime()
        {
            Console.WriteLine("Your number is prime!");
            Console.WriteLine("Press 'q' to quit. Press any key to continue...");
            Console.ReadKey();
        }

        private static void DisplayPerfect()
        {
            Console.WriteLine("Your number is perfect!");
            Console.WriteLine("Press 'q' to quit. Press any key to continue...");
            Console.ReadKey();
        }

        private static void DisplayInvalid()
        {
            Console.WriteLine("Your number is invalid!");
            Console.WriteLine("Press 'q' to quit. Press any key to continue...");
            Console.ReadKey();
        }
    }
}
