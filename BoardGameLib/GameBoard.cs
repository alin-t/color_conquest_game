using System;
using System.Collections.Generic;
using System.Linq;


namespace BoardGameLib
{
    public class GameBoard : IGamingBoard
    {
        private readonly int _boardSize;
        private readonly int _colorsNumber;
        private readonly int[,] _board;

        public GameBoard(int boardSize, int colorsNumber)
        {
            this._boardSize = boardSize;
            this._colorsNumber = colorsNumber;
            _board = new int[boardSize, boardSize];
        }
        
        public int PickNextColor()
        {
            int originColor = _board[0, 0];
            Dictionary<int, int> neighboursColorsCounts = new Dictionary<int, int>();
            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    if (originColor == _board[i, j]) continue;

                    IVisitingBoard visitingBoard = BoardFactory.CreateNotVisitedBoard(_boardSize);
                    int neighboursCount = GetNeighbourForColorCount(i, j, 1, visitingBoard);
                    if (neighboursColorsCounts.ContainsKey(_board[i, j]))
                    {
                        if (neighboursCount > neighboursColorsCounts[_board[i, j]])
                        {
                            neighboursColorsCounts[_board[i, j]] = neighboursCount;
                        }
                    }
                    else
                    {
                        neighboursColorsCounts[_board[i, j]] = neighboursCount;
                    }
                    j = _boardSize;
                }
            }

            return neighboursColorsCounts.Where(neighbour => neighbour.Value == neighboursColorsCounts.Values.Max()).FirstOrDefault().Key;
        }

        public void MoveNext(int color)
        {
            int originColor = _board[0, 0];
            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    if (originColor == _board[i, j])
                    {
                        _board[i, j] = color;

                    }
                    else
                    {
                        j = _boardSize;
                    }

                }
            }
        }

        public bool IsGameOver()
        {
            int originColor = _board[0, 0];
            for (int i = 0; i < _boardSize; i++)
            {
                for (int j = 0; j < _boardSize; j++)
                {
                    if (originColor != _board[i, j]) return false;
                }
            }
            return true;
        }

        private int GetNeighbourForColorCount(int x, int y, int neighboursCount, IVisitingBoard visitingBoard)
        {
            visitingBoard.SetVisited(x, y);

            if (ShouldMoveToDirection(x, y, x - 1, y - 1, visitingBoard)) return GetNeighbourForColorCount(x - 1, y - 1, ++neighboursCount, visitingBoard);
            if (ShouldMoveToDirection(x, y, x - 1, y, visitingBoard)) return GetNeighbourForColorCount(x - 1, y, ++neighboursCount, visitingBoard);
            if (ShouldMoveToDirection(x, y, x - 1, y + 1, visitingBoard)) return GetNeighbourForColorCount(x - 1, y + 1, ++neighboursCount, visitingBoard);
            if (ShouldMoveToDirection(x, y, x, y - 1, visitingBoard)) return GetNeighbourForColorCount(x, y - 1, ++neighboursCount, visitingBoard);
            if (ShouldMoveToDirection(x, y, x, y + 1, visitingBoard)) return GetNeighbourForColorCount(x, y + 1, ++neighboursCount, visitingBoard);
            if (ShouldMoveToDirection(x, y, x + 1, y - 1, visitingBoard)) return GetNeighbourForColorCount(x + 1, y - 1, ++neighboursCount, visitingBoard);
            if (ShouldMoveToDirection(x, y, x + 1, y, visitingBoard)) return GetNeighbourForColorCount(x + 1, y, ++neighboursCount, visitingBoard);
            if (ShouldMoveToDirection(x, y, x + 1, y + 1, visitingBoard)) return GetNeighbourForColorCount(x + 1, y + 1, ++neighboursCount, visitingBoard);

            return neighboursCount;
        }

        private bool ShouldMoveToDirection(int x, int y, int nextX, int nextY, IVisitingBoard visitingBoard)
        {
            if (nextX >= 0 && nextX < _boardSize && nextY >= 0 && nextY < _boardSize &&
                _board[nextX, nextY] == _board[x, y] && !visitingBoard.WasVisited(nextX, nextY)) return true;

            return false;
        }

        public void SetColor(int x, int y, int color)
        {
            if (x >= _boardSize || y >= _boardSize) throw new ArgumentOutOfRangeException("Index you are trying to set is outside boundaries");
            _board[x, y] = color;
        }

        public int GetColor(int x, int y)
        {
            if (x >= _boardSize || y >= _boardSize) throw new ArgumentOutOfRangeException("Index you are trying to set is outside boundaries");
            return _board[x, y];
        }

        public int GetSize()
        {
            return _boardSize;
        }

        public int GetColorsNumber()
        {
            return _colorsNumber;
        }
    }
}
