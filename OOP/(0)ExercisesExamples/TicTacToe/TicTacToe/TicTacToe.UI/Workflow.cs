using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;
using TicTacToe.BLL.Requests;
using TicTacToe.BLL.Responses;

namespace TicTacToe.UI
{
    class Workflow
    {
        internal void Start()
        {
            Board gameBoard = new Board();

            while(!gameBoard.IsGameOver)
            {


                Coordinate location = Menu.GetLocation();
                //Square mark = Square.Blank;

                //if(gameBoard.IsPlayerXTurn)
                //{
                //    mark = Square.X;
                //}
                //else
                //{
                //    mark = Square.O;
                //}
                PlaceSquareRequest request = new PlaceSquareRequest(location, mark) ;
                PlaceSquareResponse response = gameBoard.PlaceSquare(request);
                Menu.DisplayResponse(response, gameBoard);
            }

            throw new NotImplementedException();
        }
    }
}
