namespace ChessValidator.Models
{
    public class Cell
    {
        public Position position { private set; get; }
        public Piece? piece { private set; get; }
        public Cell(Position position)
        {
            this.position = position;
        }
        // Copy constructor
        public Cell(Cell other)
        {
            position = new Position(other.position); 
            piece = other.piece != null ? new Piece(other.piece) : null; 
        }
        public void SetPiece(Piece? piece)
        {
            this.piece = piece;
        }
        public bool IsCellEmpty()
        {
            return piece == null;
        }
    }
}

