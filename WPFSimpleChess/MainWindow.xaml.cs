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
using ChessCore;

namespace WPFSimpleChess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Piece piece;
        private List<string> piecesNames;

        public MainWindow()
        {
            InitializeComponent();
            piecesNames = new List<string> { "King", "Queen", "Bishop", "Rook", "Knight" };
            lbPieces.ItemsSource = piecesNames;
        }

        private void Field_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int row = Grid.GetRow(clickedButton);
            int col = Grid.GetColumn(clickedButton);

            //clear
            if (clickedButton.Content.ToString() != "" && piece != null)
            {
                clickedButton.Content = "";
                piece = null;
                return;
            }

            // set piece
            if (clickedButton.Content.ToString() == "" && piece == null)
            {
                var selPieceName = piecesNames[lbPieces.SelectedIndex];
                clickedButton.Content = selPieceName;
                piece = PieceMaker.Make(selPieceName, col, row);
                return;
            }

            // move
            var currentButton = GetButton(piece.X, piece.Y);
            if (piece.Move(col, row))
            {
                clickedButton.Content = currentButton.Content.ToString();
                currentButton.Content = "";
            }
        }
        private Button GetButton(int column, int row)
        {
            foreach (Button child in grLayout.Children)
            {
                if (Grid.GetRow(child) == row && Grid.GetColumn(child) == column)
                {
                    return child;
                }
            }
            return null;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button selectedButton = (Button)sender;
            int row = Grid.GetRow(selectedButton);
            int col = Grid.GetColumn(selectedButton);
            if (piece != null && selectedButton.Content.ToString() == "" )
            { 
                selectedButton.Content = piece.TestMove(col, row) ? "YES" : "NO";
            }
        }
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button selectedButton = (Button)sender;
            string content = selectedButton.Content.ToString();
            if (content == "YES" || content == "NO")
            {
                selectedButton.Content = "";
            }
        }
    }
}
