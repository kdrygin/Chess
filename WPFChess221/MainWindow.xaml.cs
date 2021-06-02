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
using ChessCore221;

namespace WPFChess221
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

            // set 
            if (clickedButton.Content.ToString() == "")
            {
                if (piece == null)
                {
                    string selPieceName = piecesNames[lbPieces.SelectedIndex];
                    clickedButton.Content = selPieceName;
                    piece = PieceMaker.Make(selPieceName, x, y);
                    piece.Parent = clickedButton;
                }
                else if (piece.Move(x, y))
                {
                    Button oldButton = (piece.Parent as Button);
                    clickedButton.Content = oldButton.Content;
                    piece.Parent = clickedButton;
                    oldButton.Content = "";
                }
            }
            //remove
            else
            {
                clickedButton.Content = "";
                piece = null;
            }
        }
    }
}
