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
        private Button piecePosition;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Field_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int row = Grid.GetRow(clickedButton);
            int col = Grid.GetColumn(clickedButton);

            //clear
            if (clickedButton.Content != null && piece != null)
            {
                clickedButton.Content = null;
                piece = null;
                clickedButton = null;
                return;
            }

            // set piece
            if (clickedButton.Content == null && piece == null)
            {
                var selPieceName = ((ListBoxItem)lbPieces.SelectedValue).Content.ToString();
                clickedButton.Content = selPieceName;
                piece = PieceMaker.Make(selPieceName, col, row);
                piecePosition = clickedButton;
                return;
            }

            // move
            if (clickedButton.Content == null && piece.Move(col, row))
            {
                clickedButton.Content = piecePosition.Content.ToString();
                piecePosition.Content = null;
                piecePosition = clickedButton;
            }
        }
    }
}
