using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chess
{
    public abstract class ChessPiece
    {
        public Square Position { get; set; }
        public bool IsOnWhiteSquare
        {
            get
            {
                return (Position.X + Position.Y) % 2 == 0;
            }
        }

        public bool IsWhite { get; set; }

        public abstract Square[] PossibleMoves();

    }
}
