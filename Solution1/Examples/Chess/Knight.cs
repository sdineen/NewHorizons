using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Chess
{
    public class Knight : ChessPiece
    {
        public override Square[] PossibleMoves()
        {
            Square[] squares = new Square[5];
            squares[0] = new Square(Position.X + 1, Position.Y + 2);
            squares[1] = new Square(Position.X + 1, Position.Y - 2);
            return squares;
        }
    }
}
