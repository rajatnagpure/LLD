using ChessValidator.Models;

namespace ChessValidator.Validators
{
    public class QueenMoveValidator
    {
        public bool ValidateMove(Board board, Position startPos, Position endPos)
        {
            // Queen can move horizontally, vertically, or diagonally
            RookMoveValidator rookValidator = new RookMoveValidator();
            BishopMoveValidator bishopValidator = new BishopMoveValidator();
            return rookValidator.ValidateMove(board, startPos, endPos) || bishopValidator.ValidateMove(board, startPos, endPos);
        }
    }
}

