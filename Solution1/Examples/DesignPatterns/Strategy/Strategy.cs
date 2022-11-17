using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Examples.DesignPatterns.Strategy
{
    public interface IMoveStrategy
    {
        ICollection<Point> Moves(Point position);
    }

    public class RookMoveStrategy : IMoveStrategy
    {
        public ICollection<Point> Moves(Point position)
        {
            throw new NotImplementedException();
        }
    }

    public class KnightMoveStrategy : IMoveStrategy
    {
        public ICollection<Point> Moves(Point position)
        {
            throw new NotImplementedException();
        }
    }

    public class ChessPiece
    {
        public ChessPiece(IMoveStrategy moveStrategy)
        {
            MoveStrategy = moveStrategy;
        }

        public IMoveStrategy MoveStrategy { get; set; }
        public Point Position { get; set; }

        public Point NextMove
        {
            get
            {
                ICollection<Point> moves = MoveStrategy.Moves(Position);
                return moves.First();
            }
        }
    }
}
