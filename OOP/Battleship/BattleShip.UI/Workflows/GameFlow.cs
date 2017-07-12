using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;
using static BattleShip.UI.ConsoleInput;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using BattleShip.UI.Workflows;

namespace BattleShip.UI
{
    public class GameFlow
    {
        ConsoleOutput _output = new ConsoleOutput();

        public Board Player1Board { get; set; }
        public Board Player2Board { get; set; }
        //public static Board player1Board = new Board();
        //public static Board player2Board = new Board();

        ConsoleInput _input = new ConsoleInput();
        string playerName = Player1Name;
        FireShotWorkflow _fireShotWorkflow = new FireShotWorkflow();
        
        
        public static int playerTurn = 1;

        public void Start()
        {
            while (_fireShotWorkflow.PlayAgain == "Y")
            {
                ConsoleOutput.SplashScreen();

                _input.SetPlayerNames();


                //process player1 turn
                _output.PrintBoard(Player1Board);

                PlaceShipWorkflow placeShip = new PlaceShipWorkflow();
                placeShip.Execute(Player1Board);


                Console.Write($"Press any key to setup {Player2Name}'s board...");
                Console.ReadKey();

                //process player2 turn
                Console.Clear();

                Console.WriteLine($"{Player2Name}'s Board Setup\n\n");

                _output.PrintBoard(Player2Board);
                
                placeShip.Execute(Player2Board);

                Console.WriteLine();
                Console.Write("Press any key to begin the battle!");
                Console.ReadKey();

                Console.Clear();
                playerTurn = ConsoleOutput.WhoGoesFirst();

                _fireShotWorkflow.Execute();
            }
        }
    }
}
