using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessCore
{
    // -------------------------------------------------------
    // Piece classes 

    abstract public class Piece
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Piece(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }
        public abstract bool TestMove(int newX, int newY);

        public bool Move(int newX, int newY)
        {
            if (TestMove(newX, newY))
            {
                X = newX;
                Y = newY;
                return true;
            }
            return false;
        }
    }

    public class King : Piece
    {
        public King(int newX, int newY) : base(newX, newY)
        { }

        public override bool TestMove(int newX, int newY)
        {
            return (Math.Abs(X - newX) <= 1 && Math.Abs(Y - newY) <= 1);
        }

    }

    public class Queen : Piece
    {
        public Queen(int newX, int newY) : base(newX, newY)
        { }

        public override bool TestMove(int newX, int newY)
        {
            return (X == newX || Y == newY || Math.Abs(X - newX) == Math.Abs(Y - newY));
        }
    }

    class Bishop : Piece
    {
        public Bishop(int newX, int newY) : base(newX, newY)
        { }

        public override bool TestMove(int newX, int newY)
        {
            return (Math.Abs(X - newX) == Math.Abs(Y - newY));
        }
    }

    public class Knight : Piece
    {
        public Knight(int newX, int newY) : base(newX, newY)
        { }

        public override bool TestMove(int newX, int newY)
        {
            return ((Math.Abs(X - newX) == 2 && Math.Abs(Y - newY) == 1) ||
                    (Math.Abs(X - newX) == 1 && Math.Abs(Y - newY) == 2));
        }
    }

    public class Rook : Piece
    {
        public Rook(int newX, int newY) : base(newX, newY)
        { }

        public override bool TestMove(int newX, int newY)
        {
            return (X == newX || Y == newY);
        }

    }

    public class Pawn : Piece
    {
        public Pawn(int newX, int newY) : base(newX, newY)
        { }

        public override bool TestMove(int newX, int newY)
        {
            return ((X == newX && Y == 2 && Y + 2 >= newY) ||
                    (X == newX && Y + 1 == newY));
        }

    }
}
