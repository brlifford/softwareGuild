using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.SplashScreen();

            Workflow programDriver = new Workflow();

            programDriver.Start();

            Console.ReadKey();
        }
    }
}
