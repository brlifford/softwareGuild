using RPS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.BLL

{
    public class AlwaysScissors : IChoiceGetter
    {
        public Choice GetChoice()
        {
            return Choice.Scissors;
        }
    }
}
