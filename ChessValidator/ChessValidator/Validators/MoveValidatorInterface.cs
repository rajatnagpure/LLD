using ChessValidator.Models;

namespace ChessValidator.Validators
{
    public interface MoveValidatorInterface
    {
        public bool ValidateMove(Board board, Position startPos, Position endPos);
    }
}

