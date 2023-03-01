using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class WinEventArgs : EventArgs
    {
        public Mark WInner { get; private set; }
        public WinEventArgs(Mark winner) { WInner = winner; }
    }
}
