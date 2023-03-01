using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TurnEventsArgs : EventArgs 
    {
        public Mark Turn { get; protected set; }
        public TurnEventsArgs(Mark turn) {
            Turn = turn;
        }
    }
}
