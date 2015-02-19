using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGameLib
{
    public class BoardFactory
    {
        public static IGamingBoard CreateRandomBoard(int boardSize, int colorsNumber)
        {
            IGamingBoard gameBoard = new GameBoard(boardSize, colorsNumber);
            Random rnd = new Random();
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    gameBoard.SetColor(i, j, rnd.Next(1, colorsNumber));
                }
            }

            return gameBoard;
        }

        public static  IVisitingBoard CreateNotVisitedBoard(int boardSize)
        {
            IVisitingBoard visitingBoard = new VisitingBoard(boardSize);
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    visitingBoard.SetNotVisited(i,j);
                }
            }
            return visitingBoard;
        }
    }
}
