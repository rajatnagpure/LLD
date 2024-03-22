using ChessValidator.Enumerations;
using ChessValidator.Models;

namespace ChessValidator.Validators
{
    public class CheckValidator
    {
        private ValidatorMaster validatorMaster;
        public CheckValidator(ValidatorMaster validatorMaster)
        {
            this.validatorMaster = validatorMaster;
        }
        public bool IsInCheck(Board board, PieceColorEnum kingColor)
        {
            // Check if the king of the specified color is under attack by any opponent piece
            Position kingPosition = FindKingPosition(board, kingColor);
            PieceColorEnum opponentColor = kingColor == PieceColorEnum.WHITE ? PieceColorEnum.BLACK : PieceColorEnum.WHITE;

            // Iterate through all cells on the board and check if any opponent piece can attack the king
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (!board.cells[row, col].IsCellEmpty() && board.cells[row, col].piece!.pieceColor == opponentColor)
                    {
                        // If the opponent piece can move to the king's position, the king is in check
                        if (validatorMaster.ValidateMove(board, new Position(row, col), kingPosition))
                            return true;
                    }
                }
            }
            return false;
        }

        public Position FindKingPosition(Board board, PieceColorEnum kingColor)
        {
            // Find the position of the king of the specified color on the board
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (!board.cells[row, col].IsCellEmpty() && board.cells[row, col].piece!.pieceType == PieceTypeEnum.KING &&
                        board.cells[row, col].piece?.pieceColor == kingColor)
                    {
                        return new Position(row, col);
                    }
                }
            }
            throw new InvalidOperationException($"King of color {kingColor} not found on the board.");
        }
    }
}

