using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL.Requests
{
    public class PlaceSquareRequest
    {
        public Coordinate Location { get; }

        public Square Mark { get; }

        public PlaceSquareRequest( Coordinate location, Square mark)
        {
            Location = location;
            Mark = mark;
        }
    }

}
