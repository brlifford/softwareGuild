using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using static BattleShip.UI.ConsoleInput;

namespace BattleShip.UI
{
    public class ConsoleOutput
    {

        public static void SplashScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("Press any key to start your battle!");
            Console.ReadKey();
        }

        ConsoleInput _input = new ConsoleInput();


        public static int WhoGoesFirst()
        {
            Random _rng = new Random();
            int playerNum = _rng.Next(1, 3);


            string p1 = Player1Name;
            string p2 = Player2Name;

            string firstShooter;

            if (playerNum == 1)
            {
                firstShooter = p1;
            }
            else
            {
                firstShooter = p2;
            }


            Console.WriteLine($"{firstShooter} gets to shoot first, prepare for battle!");
            return playerNum;
        }


        public void PrintBoard(Board target)
        {
            string firstLine = "  1  2  3  4  5  6  7  8  9  10 ";
            Console.WriteLine(firstLine);

            for (int i = 0; i < 10; i++)
            {
                int numCharASCII = i + 65;
                string charASCII = Char.ConvertFromUtf32(numCharASCII);
                Console.Write(charASCII);

                for (int j = 1; j <= 10; j++)
                {
                    Coordinate coord = new Coordinate(i + 1, j);
                    ShotHistory result = target.CheckCoordinate(coord);
                    if (result == ShotHistory.Miss)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" M ");
                        Console.ResetColor();
                    }
                    else if (result == ShotHistory.Hit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" H ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" - ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

