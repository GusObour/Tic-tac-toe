using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Square.xaml
    /// </summary>
    public partial class Square : UserControl
    {
        public event EventHandler Pick;

        /// <summary>
        /// The mark to display
        /// </summary>
        private Mark mark = Mark.None;

        /// <summary>
        /// Gets or sets the mark of this square (an X or O)
        /// </summary>
        public Mark Mark
        {
            get { return mark; }
            set
            {
                mark = value;
                markTextBlock.Text = ((char)mark).ToString();
            }
        }

        /// <summary>
        /// Creates a new Square
        /// </summary>
        public Square()
        {
            InitializeComponent();
            this.MouseLeftButtonUp += OnMouseLeftButtonUp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            Pick?.Invoke(this, new EventArgs());
        }
    }
}
