using System;
using tictactoe.models;

namespace tictactoe.strategies
{
    public interface WinningStretegyInterface
    {
        public bool checkForWinningSequence(Cell[,] cells, MarkEnumeration mark);
    }
}

