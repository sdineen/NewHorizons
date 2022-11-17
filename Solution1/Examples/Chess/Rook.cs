namespace Examples.Chess
{
    public class Rook : ChessPiece
    {
        public override Square[] PossibleMoves()
        {
            Square[] squares = new Square[5];
            squares[0] = new Square(Position.X + 1, Position.Y + 1);
            squares[1] = new Square(Position.X + 2, Position.Y + 2);
            return squares;
        }
    }
}