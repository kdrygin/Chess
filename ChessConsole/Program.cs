using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessCore;

namespace ChessConsole
{
    class Program
    {
        static void Main()
        {

            string chess = Console.ReadLine();
            // int chess = Convert.ToInt32(.ReadLine());  K - 1, Q - 2, B - 3 ...
            int x1 = Convert.ToInt32(Console.ReadLine());
            int y1 = Convert.ToInt32(Console.ReadLine());
            int x2 = Convert.ToInt32(Console.ReadLine());
            int y2 = Convert.ToInt32(Console.ReadLine());

            try
            {
                Piece f = PieceMaker.Make(chess, x1, y1);
                Console.WriteLine(f.Move(x2, y2) ? "YES" : "NO");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


