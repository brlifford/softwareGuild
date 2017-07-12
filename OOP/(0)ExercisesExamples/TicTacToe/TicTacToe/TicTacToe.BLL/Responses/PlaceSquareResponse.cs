using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL.Responses
{
    public enum PlaceSquareResponse
    {
        InvalidCoordinate,
        InvalidMark,
        Duplicate,
        InvalidTurn,
        Success,
        Victory,
        Draw
    }
}
