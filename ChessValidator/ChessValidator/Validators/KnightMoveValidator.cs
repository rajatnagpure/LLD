﻿using ChessValidator.Models;

namespace ChessValidator.Validators
{
    public class KnightMoveValidator
    {
        public bool ValidateMove(Board board, Position startPos, Position endPos)
        {
            // Knight moves in an L-shape pattern, so we need to check if the move is a valid L-shape
            int rowDiff = Math.Abs(endPos.row - startPos.row);
            int colDiff = Math.Abs(endPos.col - startPos.col);
            return (rowDiff == 2 && colDiff == 1) || (rowDiff == 1 && colDiff == 2);
        }
    }
}

