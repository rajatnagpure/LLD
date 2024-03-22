using ChessValidator.Enumerations;

namespace ChessValidator.Models
{
    public class Piece
    {
        public PieceTypeEnum pieceType { private set; get; }
        public PieceColorEnum pieceColor { private set; get; }
        public string name { private set; get; }

        // Default constructor
        public Piece(PieceTypeEnum pieceType, PieceColorEnum pieceColor)
        {
            this.pieceType = pieceType;
            this.pieceColor = pieceColor;
            UpdateName();
        }

        // Copy constructor
        public Piece(Piece other)
        {
            pieceType = other.pieceType;
            pieceColor = other.pieceColor;
            UpdateName();
        }

        // Update piece name based on type and color
        private void UpdateName()
        {
            string color = pieceColor == PieceColorEnum.WHITE ? "W" : "B";
            string type = "";
            switch (pieceType)
            {
                case PieceTypeEnum.PAWN: type = "P"; break;
                case PieceTypeEnum.ROOK: type = "R"; break;
                case PieceTypeEnum.KNIGHT: type = "N"; break;
                case PieceTypeEnum.BISHOP: type = "B"; break;
                case PieceTypeEnum.QUEEN: type = "Q"; break;
                case PieceTypeEnum.KING: type = "K"; break;
            }
            name = color + type;
        }
    }
}
