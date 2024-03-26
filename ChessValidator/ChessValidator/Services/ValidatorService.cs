using ChessValidator.Enumerations;
using ChessValidator.Models;
using ChessValidator.Validators;

namespace ChessValidator.Services
{
    public class ValidatorService
    {
        private ValidatorMaster validatorMaster;
        public ValidatorService()
        {
            this.validatorMaster = new ValidatorMaster();
        }
        public bool ValidateMove(Board board, PieceColorEnum nextMovePieceColor, Position startPos, Position endPos)
        {
            if (board.cells[startPos.row, startPos.col].piece == null)
                throw new Exception("Cell is Empty");
            if (nextMovePieceColor != board.cells[startPos.row, startPos.col].piece?.pieceColor)
                throw new Exception("Other Player's Turn");

            // Check if the move results in check
            Board tempBoard = new Board(board); // Create a copy of the board
            tempBoard.MovePiece(startPos, endPos); // Make the move on the temporary board
            if (validatorMaster.IsCheck(tempBoard, nextMovePieceColor))
                throw new Exception("Move puts the king in check");

            return validatorMaster.ValidateMove(board, startPos, endPos);
        }
        public bool IsCheck(Board board, PieceColorEnum kingColor)
        {
            return validatorMaster.IsCheck(board, kingColor);
        }

        public bool IsCheckMate(Board board, PieceColorEnum kingColor)
        {
            return validatorMaster.IsCheckMate(board, kingColor);
        }
    }
}

