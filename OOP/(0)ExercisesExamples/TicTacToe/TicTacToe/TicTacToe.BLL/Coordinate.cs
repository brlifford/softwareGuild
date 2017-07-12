using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL
{
    public class Coordinate
    {
        public int X
        {
            get;
        }
        public int Y
        {
            get;
        }

        public Coordinate (int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsValid()
        {
            bool valid = true;

            valid = X < 3 && X >= 0 && Y < 3 && Y >= 0;

            return valid;
        }
    }
}
