using ChessValidator.Models;

namespace ChessValidator.Validators
{
    public class RookMoveValidator
    {
        public bool ValidateMove(Board board, Position startPos, Position endPos)
        {
            // Rook can move horizontally or vertically, so we need to check if the move is along a row or column
            if (startPos.row != endPos.row && startPos.col != endPos.col)
                return false; // Not a valid rook move if the start and end positions are not in the same row or column

            // Check if the path between startPos and endPos is clear
            if (!IsPathClear(board, startPos, endPos))
                return false;

            return true;
        }

        private bool IsPathClear(Board board, Position startPos, Position endPos)
        {
            // Check if the path between startPos and endPos is clear for a rook move
            if (startPos.row == endPos.row)
            {
                // Horizontal move
                int direction = Math.Sign(endPos.col - startPos.col);
                for (int col = startPos.col + direction; col != endPos.col; col += direction)
                {
                    if (!board.cells[startPos.row, col].IsCellEmpty())
                        return false; // Path is not clear if any intermediate cell is occupied
                }
            }
            else
            {
                // Vertical move
                int direction = Math.Sign(endPos.row - startPos.row);
                for (int row = startPos.row + direction; row != endPos.row; row += direction)
                {
                    if (!board.cells[row, startPos.col].IsCellEmpty())
                        return false; // Path is not clear if any intermediate cell is occupied
                }
            }

            return true; // Path is clear
        }
    }
}

