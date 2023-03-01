using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        public event EventHandler<WinEventArgs> Win;
        public event EventHandler<TurnEventsArgs> StartTurn;

        Mark turn = Mark.X;
        Mark Turn
        {
            get => turn;
            set
            {
                if (turn != value)
                {
                    turn = value;
                    StartTurn?.Invoke(this, new TurnEventsArgs(turn));
                }
            }
        }
        Mark winner = Mark.None;
        public Mark Winner { 
            get{return winner;}
            private set { 
                if(winner != value)
                {
                    winner = value;
                    Win?.Invoke(this, new WinEventArgs(winner));
                }
            } 
        }
        /// <summary>
        /// Constructs a new game board
        /// </summary>
        public Board()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Helper method that finds the winner (if any)
        /// </summary>
        private Mark CheckForWin()
        {
            // Get the marks for all squares in the board
            int i = 0;
            Mark[] squares = new Mark[9];
            foreach (var child in ticTacToeGrid.Children)
            {
                var square = child as Square;
                squares[i] = square.Mark;
                i++;
            }

            for (i = 0; i < 3; i++)
            {
                // check verticals
                if (squares[3 * i] != Mark.None &&
                    squares[3 * i] == squares[3 * i + 1] &&
                    squares[3 * i + 1] == squares[3 * i + 2])
                {
                    return squares[3 * i];
                }
                // check horizontals 
                if (squares[i] != Mark.None &&
                    squares[i] == squares[i + 3] &&
                    squares[i + 3] == squares[i + 6])
                {
                    return squares[i];
                }
            }

            // check diagonals 
            if (squares[0] != Mark.None &&
                squares[0] == squares[4] &&
                squares[4] == squares[8])
            {
                return squares[0];
            }
            // check diagonals 
            if (squares[2] != Mark.None &&
                squares[2] == squares[4] &&
                squares[4] == squares[6])
            {
                return squares[2];
            }

            // no winner yet 
            return Mark.None;
        }

        /// <summary>
        /// Resets the board to a new game state
        /// </summary>
        public void ResetBoard()
        {
            // iterate through all squares, clearing any marks
            foreach (var child in ticTacToeGrid.Children)
            {
                var square = child as Square;
                square.Mark = Mark.None;
            }
            Winner = Mark.None;
            Turn = Mark.X;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnSquarePicked(object sender, EventArgs e)
        {
            if(sender is Square square)
            {
                if(square.Mark == Mark.None && Winner == Mark.None)
                {
                    square.Mark = Turn;
                    Turn = (Turn == Mark.X) ? Mark.O : Mark.X;
                    Winner = CheckForWin();
                }
            }
        }
    }
}
