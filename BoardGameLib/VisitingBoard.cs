using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGameLib
{
    public class VisitingBoard : IVisitingBoard
    {
        private readonly int[,] _board;
        private readonly int _boardSize;
        public static int Visited = 1;
        public static int NotVisited = 0;

        private VisitingBoard()
        {
        }

        public VisitingBoard(int size)
        {
            _board = new int[size, size];
            _boardSize = size;
        }

        public bool WasVisited(int x, int y)
        {
            if (x >= _boardSize || y >= _boardSize) throw new ArgumentOutOfRangeException("Index you are trying to set is outside boundaries");
            return _board[x, y].Equals(Visited);
        }

        public void SetVisited(int x, int y)
        {
            if (x >= _boardSize || y >= _boardSize) throw new ArgumentOutOfRangeException("Index you are trying to set is outside boundaries");
            _board[x, y] = Visited;
        }

        public void SetNotVisited(int x, int y)
        {
            if (x >= _boardSize || y >= _boardSize) throw new ArgumentOutOfRangeException("Index you are trying to set is outside boundaries");
            _board[x, y] = NotVisited;
        }
    }
}
