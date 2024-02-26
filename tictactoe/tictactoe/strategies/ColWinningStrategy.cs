﻿using System;
using tictactoe.models;

namespace tictactoe.strategies
{
    public class ColWinningStrategy: WinningStretegyInterface
    {
        public bool checkForWinningSequence(Cell[,] cells, MarkEnumeration mark)
        {
            int n = cells.GetLength(0);
            for (int j = 0; j < n; j++)
            {
                int i = 0;
                for (i = 0; i < n; i++)
                {
                    if (cells[i,j].mark != mark) break;
                }
                if (i == n) return true;
            }
            return false;
        }
    }
}

