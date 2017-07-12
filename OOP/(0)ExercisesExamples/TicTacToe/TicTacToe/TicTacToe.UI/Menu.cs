using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.BLL;
using TicTacToe.BLL.Responses;

namespace TicTacToe.UI
{
    static class Menu
    {
        public static object currentGame { get; private set; }

        public static void SplashScreen()
        {
            Console.Clear();
            Console.WriteLine("Tic Tac Toe Time!");
            Thread.Sleep(1000);
        }

        internal static Coordinate GetLocation()
        {
            int x = -1;
            int y = -1;

            Console.WriteLine("Enter move coordinate: ");

            string attempt = Console.ReadLine();

            bool attempWorked = false; 

            while(!attempWorked)
            {
                string[] sides = attempt.Split(',');

                if(sides.Length == 2)
                {
                    if(int.TryParse(sides[0], out x) && int.TryParse(sides[1], out y))
                    {
                        attempWorked = true;
                    }
                }
            }
            Coordinate location = new Coordinate(x, y);
            return location;
        }

        internal static void DisplayResponse(PlaceSquareResponse response, bool isPlayerXTurn)
        {
            string msg = "";
            currentGame = null;
            switch (response)
            {
                
                case PlaceSquareResponse.Draw:
                    msg = "Cat's game!";
                    break;
                case PlaceSquareResponse.Duplicate:
                    msg = "Invalid. Not blank.";
                    break;
                case PlaceSquareResponse.InvalidCoordinate:
                    msg = "Please play on the board, dummy.";
                    break;
                case PlaceSquareResponse.InvalidMark:
                    msg = "SOMETHING TERRIBLE HAS HAPPENED";
                    break;
                case PlaceSquareResponse.InvalidTurn:
                    msg = "SOMETHING ELSE TERRIBLE HAS HAPPENED";
                    break;
                case PlaceSquareResponse.Success:
                    DisplayBoard(currentGame);
                    break;
                case PlaceSquareResponse.Victory:
                    DisplayBoard(currentGame);
                    if(!currentGame.IsPlayerXTurn) //turn already flipped
                    {
                        msg = "X";
                    }
                    else
                    {
                        msg = "O";
                    }
                    break;
            }

            Console.WriteLine(msg);
            throw new NotImplementedException();
        }

        private static void DisplayBoard(object currentGame)
        {
            for (int y = 0; y < 3; y++) //text prints rows first
            {
                for(int x = 0; x < 3; x++)
                {
                    switch (currentGame.Squares)
                }
            }
            throw new NotImplementedException();
        }
    }
}
