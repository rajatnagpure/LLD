using ChessValidator.Enumerations;
using ChessValidator.Models;

namespace ChessValidator.Validators
{
    public class CheckMateValidator
    {
        private CheckValidator checkValidator;
        private ValidatorMaster validatorMaster;

        public CheckMateValidator(ValidatorMaster validatorMaster, CheckValidator checkValidator)
        {
            this.checkValidator = checkValidator;
            this.validatorMaster = validatorMaster;
        }

        public bool IsCheckMate(Board board, PieceColorEnum kingColor)
        {
            // Check if the king of the specified color is in check
            if (!checkValidator.IsInCheck(board, kingColor))
                return false;

            // If the king is in check, check if it has any legal moves to escape the check
            Position kingPosition = checkValidator.FindKingPosition(board, kingColor);
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (!board.cells[row, col].IsCellEmpty() && board.cells[row, col].piece!.pieceColor == kingColor)
                    {
                        Position startPos = new Position(row, col);
                        for (int destRow = 0; destRow < 8; destRow++)
                        {
                            for (int destCol = 0; destCol < 8; destCol++)
                            {
                                Position endPos = new Position(destRow, destCol);
                                if (board.cells[destRow, destCol].IsCellEmpty() || board.cells[destRow, destCol].piece!.pieceColor != kingColor)
                                {
                                    if (validatorMaster.ValidateMove(board, startPos, endPos))
                                    {
                                        // If the king can move to a position where it is not in check, it is not checkmate
                                        Board tempBoard = new Board(board); // Create a copy of the board
                                        tempBoard.MovePiece(startPos, endPos); // Simulate the move
                                        if (!checkValidator.IsInCheck(tempBoard, kingColor))
                                            return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // If the king has no legal moves to escape the check, it is checkmate
            return true;
        }
    }
}

