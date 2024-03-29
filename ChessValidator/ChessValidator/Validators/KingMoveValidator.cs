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
            // Capturing same color is invalid
            if (!board.cells[endPos.row, endPos.col].IsCellEmpty()
                && board.cells[endPos.row, endPos.col].piece?.pieceColor
                == board.cells[startPos.row, startPos.col].piece?.pieceColor)
                return false;
            return rowDiff <= 1 && colDiff <= 1;
        }
    }
}

