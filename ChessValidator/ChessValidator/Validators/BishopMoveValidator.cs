using ChessValidator.Models;

namespace ChessValidator.Validators
{
    public class BishopMoveValidator
    {
        public bool ValidateMove(Board board, Position startPos, Position endPos)
        {
            // Bishop can move diagonally, so we need to check if the move is along a diagonal path
            // Determine the row and column differences between the start and end positions
            int rowDiff = Math.Abs(endPos.row - startPos.row);
            int colDiff = Math.Abs(endPos.col - startPos.col);

            // Bishop move is valid if the row difference equals the column difference, indicating a diagonal move
            return rowDiff == colDiff && IsDiagonalPathClear(board, startPos, endPos);
        }
        private bool IsDiagonalPathClear(Board board, Position startPos, Position endPos)
        {
            // Check if the path between startPos and endPos is clear for a diagonal move
            int rowDirection = Math.Sign(endPos.row - startPos.row);
            int colDirection = Math.Sign(endPos.col - startPos.col);

            int currentRow = startPos.row + rowDirection;
            int currentCol = startPos.col + colDirection;

            while (currentRow != endPos.row && currentCol != endPos.col)
            {
                if (!board.cells[currentRow, currentCol].IsCellEmpty())
                    return false; // Path is not clear if any intermediate cell is occupied
                currentRow += rowDirection;
                currentCol += colDirection;
            }
            // Capturing same color is invalid
            if (!board.cells[endPos.row, endPos.col].IsCellEmpty()
                && board.cells[endPos.row, endPos.col].piece?.pieceColor
                == board.cells[startPos.row, startPos.col].piece?.pieceColor)
                return false;
            return true; // Path is clear
        }
    }
}

