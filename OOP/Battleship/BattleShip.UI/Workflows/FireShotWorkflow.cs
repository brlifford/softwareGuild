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
    public class FireShotWorkflow
    {
        ConsoleInput _input = new ConsoleInput();
        Coordinate coord;
        Board targetBoard;
        ConsoleOutput _output = new ConsoleOutput();
        

        int endOfTurnPlayer;
        public int PlayerTurn { get; set; }
        public string PlayerName { get; set; }
        public bool IsVictory { get; set; }
        public string PlayAgain { get; set; }
        public Board Player1Board { get; set; }
        public Board Player2Board { get; set; }



        public void Execute()
        {
            PlayerTurn = GameFlow.playerTurn;
            IsVictory = false;
            while (!IsVictory)
            {
                //set target board based on playerTurn
                if (PlayerTurn == 1)
                {
                    PlayerName = ConsoleInput.Player1Name;
                    targetBoard = Player2Board;
                    endOfTurnPlayer = 2;

                }
                else
                {
                    PlayerName = ConsoleInput.Player2Name;
                    targetBoard = Player1Board;
                    endOfTurnPlayer = 1;
                }
                Console.Clear();

                Console.WriteLine($"{PlayerName}'s turn!");
                //print target board
                _output.PrintBoard(targetBoard);
                FireShotResponse result = null;
                do
                {
                    //get string for shot coordinate
                    string prompt = "Enter a shot coordinate (ex: B9): ";

                    //check if valid
                    string shotCoord = ConsoleInput.GetRequiredCoordinateFromUser(prompt);
                    //parse coordinate
                    coord = _input.InputCoordinate(shotCoord);

                    //get response (ex: miss, hit, victory)
                    result = FireShot(coord, targetBoard);

                } while (result.ShotStatus == ShotStatus.Duplicate ||
                    result.ShotStatus == ShotStatus.Invalid);

                //update print target board
                _output.PrintBoard(targetBoard);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                //update player turn
                PlayerTurn = endOfTurnPlayer;

            }
        }

        public FireShotResponse FireShot(Coordinate coord, Board target)
        {

            FireShotResponse shotResult = target.FireShot(coord);

            switch (shotResult.ShotStatus)
            {
                case ShotStatus.Duplicate:
                    Console.WriteLine("You already shot at that location! Press any key to continue...");
                    Console.ReadKey();

                    break;
                case ShotStatus.Miss:
                    Console.WriteLine("Miss!");
                    break;
                case ShotStatus.Hit:
                    Console.WriteLine("Hit!");
                    break;
                case ShotStatus.HitAndSunk:
                    Console.WriteLine($"Hit and sunk their {shotResult.ShipImpacted}!");
                    break;
                case ShotStatus.Victory:
                    IsVictory = true;
                    Console.Write($"{PlayerName} wins! Would you like to play again? (Y/N): ");
                    PlayAgain = Console.ReadLine().ToUpper();
                    break;
                default:
                    Console.WriteLine("That's not a valid coordinate! Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

            return shotResult;
        }
    }
}
