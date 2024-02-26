using System;
using tictactoe.models;

namespace tictactoe.strategies
{
    public class DiagonalWinningStrategy : WinningStretegyInterface
    {
        private bool primaryDiagonalCheck(Cell[,] cells, MarkEnumeration mark)
        {
            int n = cells.GetLength(0);
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i == j)
                    {
                        if (cells[i, j].mark != mark)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private bool secondaryDiagonalCheck(Cell[,] cells, MarkEnumeration mark)
        {
            int n = cells.GetLength(0);
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i + j == n)
                    {
                        if (cells[i, j].mark != mark)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public bool checkForWinningSequence(Cell[,] cells, MarkEnumeration mark)
        {
            return primaryDiagonalCheck(cells, mark) || secondaryDiagonalCheck(cells, mark);
        }
    }
}

