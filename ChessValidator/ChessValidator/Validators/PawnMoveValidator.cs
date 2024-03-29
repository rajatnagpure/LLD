using ChessValidator.Enumerations;
using ChessValidator.Models;

namespace ChessValidator.Validators
{
    public class PawnMoveValidator
    {
        public bool ValidateMove(Board board, Position startPos, Position endPos)
        {
            Piece pawn = board.cells[startPos.row, startPos.col].piece!;

            // Check if the end position is within the board bounds
            if (endPos.row < 0 || endPos.row >= 8 || endPos.col < 0 || endPos.col >= 8)
                return false;

            // Determine the direction of movement based on the piece color
            int direction = pawn.pieceColor == PieceColorEnum.WHITE ? 1 : -1;

            // Determine the number of rows the pawn can move in one turn
            int initialRow = pawn.pieceColor == PieceColorEnum.WHITE ? 1 : 6;
            int maxMoveRows = startPos.row == initialRow ? 2 : 1;

            // Check if the end position is reachable by the pawn based on its direction and maximum move rows
            if (endPos.row != startPos.row + direction && endPos.row != startPos.row + 2 * direction)
                return false;

            // Check if the end position is reachable within the maximum move rows
            if (endPos.row - startPos.row > maxMoveRows)
                return false;

            // Check if the pawn is moving diagonally to capture an opponent's piece
            if (endPos.col != startPos.col)
            {
                // Pawn can only move diagonally to capture an opponent's piece
                if (Math.Abs(endPos.col - startPos.col) != 1)
                    return false;

                // Check if there is an opponent's piece to capture at the end position
                if (board.cells[endPos.row, endPos.col].piece == null || board.cells[endPos.row, endPos.col].piece?.pieceColor == pawn.pieceColor)
                    return false;

                return true; // Valid pawn capture move
            }

            // Check if the end position is empty
            if (!board.cells[endPos.row, endPos.col].IsCellEmpty())
                return false;

            return true; // Valid pawn move
        }
    }
}

