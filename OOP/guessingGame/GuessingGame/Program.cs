using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer;
            int playerGuess;
            string playerName;
            string playerInput;
            int playerTries = 1;
            int maxBound = 21;
            string gameMode;


            Random r = new Random();
            

            //get player name
            Console.WriteLine("Please enter your name: ");
            playerName = Console.ReadLine();
            do
            {

                Console.WriteLine("Please select a game mode: ");
                Console.WriteLine(" 1. Easy Mode");
                Console.WriteLine(" 2. Normal Mode");
                Console.WriteLine(" 3. Hard Mode");
                gameMode = Console.ReadLine();
                if (gameMode == "1")
                {
                    maxBound = 5;
                }
                else if (gameMode == "2")
                {
                    maxBound = 20;
                }
                else if (gameMode == "3")
                {
                    maxBound = 50;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"That's an invalid selection {playerName}!");
                    Console.ResetColor();
                    gameMode = null;
                }
            }
            while (gameMode == null);

            theAnswer = r.Next(1, maxBound + 1);



            do
            {

                // get player input
                Console.Write($"Enter your guess {playerName} (1-{maxBound}): ");
                playerInput = Console.ReadLine();

                if (playerInput == "q")
                {
                    break;
                }

                //attempt to convert the string to a number
                if (int.TryParse(playerInput, out playerGuess))
                {
                    
                    if (playerGuess == theAnswer)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        if (playerTries == 1)
                        {
                            
                            Console.WriteLine($"{theAnswer} was the number.");
                            Console.WriteLine($"You guessed the answer on the first try {playerName}!");
                        }
                        else
                        {
                            Console.WriteLine($"{theAnswer} was the number.  You Win {playerName}!");
                            Console.WriteLine($"You guessed the answer in {playerTries} tries.");
                        }
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        if (playerGuess > theAnswer)
                        {
                            Console.WriteLine($"Your guess was too High {playerName}!");
                        }
                        else
                        {
                            Console.WriteLine($"Your guess was too low {playerName}!");
                        }
                        playerTries++;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"That wasn't a number {playerName}!");
                    Console.ResetColor();
                    playerTries++;
                }

            } while (true);

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
