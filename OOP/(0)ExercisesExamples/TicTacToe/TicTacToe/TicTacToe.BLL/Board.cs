using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL.Requests;
using TicTacToe.BLL.Responses;

namespace TicTacToe.BLL
{
    public class Board
    {
        public Square[,] Squares
        {
            get;
        } = new Square[3, 3];

        public bool IsPlayerXTurn
        {
            get;
            private set;
        } = true; //initialize outside of property

        public bool IsGameOver
        {
            get;
            private set;
        } = false;

        public Board()
        {

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Squares[x, y] = Square.Blank;
                }
            }
        }

        public PlaceSquareResponse PlaceSquare(PlaceSquareRequest request)
        {
            PlaceSquareResponse response = PlaceSquareResponse.InvalidCoordinate;

            if (!request.Location.IsValid())
            {
                return PlaceSquareResponse.InvalidCoordinate;
            }

            if (request.Mark == Square.Blank)
            {
                return PlaceSquareResponse.InvalidMark;
            }

            switch (request.Mark)
            {
                case Square.Blank:
                    return PlaceSquareResponse.InvalidMark;
                    break;
                case Square.O:
                    if (IsPlayerXTurn)
                    {
                        return PlaceSquareResponse.InvalidTurn;
                    }
                    break;
                case Square.X:
                    if (!IsPlayerXTurn)
                    {
                        return PlaceSquareResponse.InvalidTurn;
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }

            int x = request.Location.X;//aliasing
            int y = request.Location.Y;

            if (Squares[request.Location.X, request.Location.Y] != Square.Blank)
            {
                return PlaceSquareResponse.Duplicate;
            }

            Squares[x, y] = request.Mark;
            IsPlayerXTurn = !IsPlayerXTurn;

            response = PostMoveValidation();

            bool victory = false;

            for (int row = 0; !victory && row < 3; row++)
            {
                victory = (
                    Squares[0, row] == request.Mark &&
                    Squares[1, row] == request.Mark &&
                    Squares[2, row] == request.Mark);
            }

            for (int col = 0; !victory && col < 3; col++)
            {
                victory = (
                    Squares[col, 0] == request.Mark &&
                    Squares[col, 1] == request.Mark &&
                    Squares[col, 2] == request.Mark);
            }

            if( !victory)
            {
                victory = (
                    Squares[0, 0] == request.Mark &&
                    Squares[1, 1] == request.Mark &&
                    Squares[2, 2] == request.Mark);
            }

            if (!victory)
            {
                victory = (
                    Squares[0, 2] == request.Mark &&
                    Squares[1, 1] == request.Mark &&
                    Squares[2, 0] == request.Mark);
            }

            if(victory)
            {
                response = PlaceSquareResponse.Victory;
                IsGameOver = true;
            }

            else
            {
                if (InDrawState())
                {
                    response = PlaceSquareResponse.Draw;
                    IsGameOver = true;
                }
            }
            throw new NotImplementedException();

            return response;
        }

        private bool InDrawState()
        {
            bool drawed = false;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; drawed && y < 3; y++)
                {
                    if(Squares [x,y] == Square.Blank)
                    {
                        drawed = false;
                    }
                    throw new NotImplementedException();

                    return drawed;
        }

        private PlaceSquareResponse PostMoveValidation( PlaceSquareRequest request)
        {
            PlaceSquareResponse
            throw new NotImplementedException();

            return response;
        }
    }
}
