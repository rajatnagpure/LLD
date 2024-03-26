using ChessValidator.Enumerations;
using ChessValidator.Models;

namespace ChessValidator.Validators
{
    public class ValidatorMaster
    {
        private PawnMoveValidator pawnMoveValidator;
        private BishopMoveValidator bishopMoveValidator;
        private RookMoveValidator rookMoveValidator;
        private KnightMoveValidator knightMoveValidator;
        private KingMoveValidator kingMoveValidator;
        private QueenMoveValidator queenMoveValidator;
        private CheckValidator checkValidator;
        private CheckMateValidator checkMateValidator;

        public ValidatorMaster()
        {
            pawnMoveValidator = new PawnMoveValidator();
            bishopMoveValidator = new BishopMoveValidator();
            rookMoveValidator = new RookMoveValidator();
            knightMoveValidator = new KnightMoveValidator();
            kingMoveValidator = new KingMoveValidator();
            queenMoveValidator = new QueenMoveValidator();
            checkValidator = new CheckValidator(this);
            checkMateValidator = new CheckMateValidator(this, checkValidator);
        }

        public bool ValidateMove(Board board, Position startPos, Position endPos)
        {
            // Get the piece at the start position
            Piece? piece = board.cells[startPos.row, startPos.col].piece;
            if (piece == null)
            {
                Console.WriteLine("No piece found at the start position.");
                return false;
            }

            // Determine the color of the piece
            PieceColorEnum pieceColor = piece.pieceColor;

            // Validate move based on the piece type
            switch (piece.pieceType)
            {
                case PieceTypeEnum.BISHOP:
                    return bishopMoveValidator.ValidateMove(board, startPos, endPos);
                case PieceTypeEnum.ROOK:
                    return rookMoveValidator.ValidateMove(board, startPos, endPos);
                case PieceTypeEnum.KNIGHT:
                    return knightMoveValidator.ValidateMove(board, startPos, endPos);
                case PieceTypeEnum.KING:
                    return kingMoveValidator.ValidateMove(board, startPos, endPos);
                case PieceTypeEnum.QUEEN:
                    return queenMoveValidator.ValidateMove(board, startPos, endPos);
                case PieceTypeEnum.PAWN:
                    return pawnMoveValidator.ValidateMove(board, startPos, endPos);
            }

            return false;
        }

        public bool IsCheck(Board board, PieceColorEnum kingColor)
        {
            return checkValidator.IsInCheck(board, kingColor);
        }

        public bool IsCheckMate(Board board, PieceColorEnum kingColor)
        {
            return checkMateValidator.IsCheckMate(board, kingColor);
        }
    }
}
