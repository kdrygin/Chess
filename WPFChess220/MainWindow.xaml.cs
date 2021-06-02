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
using ChessCore220;

namespace WPFChess220
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private List<string> piecesNames;
        private Piece piece;
        public MainWindow()
        {
            InitializeComponent();
            piecesNames = new List<string> { "King", "Queen", "Bishop", "Rook", "Knight" };
            lbPieces.ItemsSource = piecesNames;
        }

        private void Field_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int x = Grid.GetColumn(clickedButton);
            int y = Grid.GetRow(clickedButton);

            string selPieceName = piecesNames[lbPieces.SelectedIndex];

            // set
            if (clickedButton.Content.ToString() == "")
            {
                if (piece == null)
                {
                    piece = PieceMaker.Make(selPieceName, x, y);
                    piece.Parent = clickedButton;
                    clickedButton.Content = selPieceName;
                }
                else if (piece.Move(x, y))
                {
                    clickedButton.Content = selPieceName;
                    (piece.Parent as Button).Content = "";
                    piece.Parent = clickedButton;
                }
                return;
            }

            // clear
            if (clickedButton.Content.ToString() != "")
            {
                clickedButton.Content = "";
                piece = null;
                return;
            }
        }

        private void Field_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
