using Examples.DesignPatterns.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chess
{
    public class Board
    {
        public ChessPiece[] chessPieces = new ChessPiece[64];

        public Board()
        {
            chessPieces[0] = new Rook { Position = new Square(0, 0), IsWhite=false };
            chessPieces[1] = new Knight { Position = new Square(1, 0), IsWhite = false };
        }
    }
}
