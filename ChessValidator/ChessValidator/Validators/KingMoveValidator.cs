using ChessValidator.Models;

namespace ChessValidator.Validators
{
    public class KingMoveValidator
    {
        public bool ValidateMove(Board board, Position startPos, Position endPos)
        {
            // King can move one square in any direction
            int rowDiff = Math.Abs(endPos.row - startPos.row);
            int colDiff = Math.Abs(endPos.col - startPos.col);
            return rowDiff <= 1 && colDiff <= 1;
        }
    }
}

