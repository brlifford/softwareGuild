using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.UI;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameFlow game = new GameFlow();
            game.Start();
        }
    }
}
