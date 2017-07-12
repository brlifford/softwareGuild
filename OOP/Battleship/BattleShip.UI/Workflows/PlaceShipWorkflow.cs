using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI.Workflows
{
    public class PlaceShipWorkflow
    {
        ConsoleInput _input = new ConsoleInput();
        ConsoleOutput _output = new ConsoleOutput();
        string playerName = ConsoleInput.Player1Name;

        public void Execute(Board playerBoard)
        {
            Console.Clear();

            Console.WriteLine($"{playerName}'s Board Setup\n\n");

            _output.PrintBoard(playerBoard);

            for (ShipType ship = ShipType.Destroyer; ship <= ShipType.Carrier; ship++)
            {
                ShipPlacement placeOk;

                do
                {

                    placeOk = playerBoard.PlaceShip(ShipRequest(ship));

                } while (placeOk != ShipPlacement.Ok);

            }
            playerName = ConsoleInput.Player2Name;
            Console.WriteLine();
        }

        public PlaceShipRequest ShipRequest(ShipType sType)
        {
            Coordinate coord;
            PlaceShipRequest request;

            string shipCoord = ConsoleInput.GetRequiredCoordinateFromUser($"Enter coordinates for your {sType}: ");
            

            coord = _input.InputCoordinate(shipCoord);

            //check if valid
            ShipDirection direction;

            Console.Write($"Enter direction to place {sType} (up, down, left, right): ");
            string shipDirection = Console.ReadLine();
            direction = _input.InputDirection(shipDirection);

            request = new PlaceShipRequest()
            {
                Coordinate = coord,
                ShipType = sType,
                Direction = direction
            };

            return request;
        }
    }
}
