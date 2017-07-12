using BattleShip.BLL.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ConsoleInput
    {
        public static string Player1Name { get; set; }
        public static string Player2Name { get; set; }

        
        public void SetPlayerNames()
        {
            Player1Name = GetRequiredStringFromUser("Enter Player 1 Name: ");
            Player2Name = GetRequiredStringFromUser("Enter Player 2 Name: ");
        }


        public int coordinateXValue;
        public int coordinateYValue;

        public Coordinate InputCoordinate(string newCoordinate)
        {
            string coordinateStringAlpha = newCoordinate.Substring(0, 1).ToUpper();
            char coordinateAlphaChar = coordinateStringAlpha[0];
            coordinateXValue = (coordinateAlphaChar - 64);
            string coordinateStringNum = newCoordinate.Substring(1);
            int coordNum = int.Parse(coordinateStringNum);
            coordinateYValue = coordNum;
            Coordinate parsedCoord = new Coordinate(coordinateXValue, coordinateYValue);
            

            while (true)
            {
                if (coordinateXValue > 0 && coordinateXValue < 11 ||
                    int.TryParse(coordinateStringNum, out coordinateYValue) &&
                    coordinateYValue > 0 && coordinateYValue < 11)
                {
                    return parsedCoord;
                }
                else
                {
                    Console.WriteLine("That's not a valid coordinate!");
                }
            } 
        }



        public ShipDirection InputDirection(string direction)
        {
            ShipDirection setDirection = new ShipDirection();
            string directionA = direction.Substring(0, 1).ToUpper();
            string directionB = direction.Substring(1).ToLower();
            string directionFinal = directionA + directionB;

           
                if (Enum.TryParse<ShipDirection>(directionFinal, out setDirection))
                {
                    
                }
                else
                {
                    Console.WriteLine("That's not a valid direction (up, down, left, right)!");
                }

            return setDirection;
        }


        public static string GetRequiredStringFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter valid text!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }
            }
        }


        public static string GetRequiredCoordinateFromUser(string prompt)
        {
            while(true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if(string.IsNullOrEmpty(input) || input.Length < 2)
                {
                    Console.WriteLine("You must enter a valid coordinate (ex: A6)!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }
            }
        }


        public static string GetRequiredDirectionFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || 
                    (input != "up" && input != "down" && input != "left" && input != "right"))
                {
                    Console.WriteLine("You must enter a valid direction (ex: up, down, left, right)!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }
            }
        }
    }
}
