using ChessValidator.Enumerations;

namespace ChessValidator.Models
{
    public class Board
    {
        public Cell[,] cells;
        public Board()
        {
            cells = new Cell[8, 8];
        }
        // Copy constructor
        public Board(Board other)
        {
            cells = new Cell[8, 8];

            // Copy each cell from the other board
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    cells[row, col] = new Cell(other.cells[row, col]);
                }
            }
        }
        public void Initialize()
        {
            Position position;
            for(int row = 0; row < 8; row++)
            {
                for(int col = 0; col < 8; col++)
                {
                    position = new Position(row, col);
                    cells[row, col] = new Cell(position);
                }
            }
            // Initialize Pawn
            for(int col = 0; col < 8; col++)
            {
                cells[1, col].SetPiece(new Piece(PieceTypeEnum.PAWN, PieceColorEnum.WHITE));
                cells[6, col].SetPiece(new Piece(PieceTypeEnum.PAWN, PieceColorEnum.BLACK));
            }
            // Initialize Remaining Piece
            cells[0, 0].SetPiece(new Piece(PieceTypeEnum.ROOK, PieceColorEnum.WHITE));
            cells[0, 1].SetPiece(new Piece(PieceTypeEnum.KNIGHT, PieceColorEnum.WHITE));
            cells[0, 2].SetPiece(new Piece(PieceTypeEnum.BISHOP, PieceColorEnum.WHITE));
            cells[0, 3].SetPiece(new Piece(PieceTypeEnum.QUEEN, PieceColorEnum.WHITE));
            cells[0, 4].SetPiece(new Piece(PieceTypeEnum.KING, PieceColorEnum.WHITE));
            cells[0, 5].SetPiece(new Piece(PieceTypeEnum.BISHOP, PieceColorEnum.WHITE));
            cells[0, 6].SetPiece(new Piece(PieceTypeEnum.KNIGHT, PieceColorEnum.WHITE));
            cells[0, 7].SetPiece(new Piece(PieceTypeEnum.ROOK, PieceColorEnum.WHITE));

            cells[7, 0].SetPiece(new Piece(PieceTypeEnum.ROOK, PieceColorEnum.BLACK));
            cells[7, 1].SetPiece(new Piece(PieceTypeEnum.KNIGHT, PieceColorEnum.BLACK));
            cells[7, 2].SetPiece(new Piece(PieceTypeEnum.BISHOP, PieceColorEnum.BLACK));
            cells[7, 3].SetPiece(new Piece(PieceTypeEnum.QUEEN, PieceColorEnum.BLACK));
            cells[7, 4].SetPiece(new Piece(PieceTypeEnum.KING, PieceColorEnum.BLACK));
            cells[7, 5].SetPiece(new Piece(PieceTypeEnum.BISHOP, PieceColorEnum.BLACK));
            cells[7, 6].SetPiece(new Piece(PieceTypeEnum.KNIGHT, PieceColorEnum.BLACK));
            cells[7, 7].SetPiece(new Piece(PieceTypeEnum.ROOK, PieceColorEnum.BLACK));
        }
        public void Display()
        {
            string final = "";
            string temp = "";
            for (int row = 0; row < 8; row++)
            {
                temp = "";
                for (int col = 0; col < 8; col++)
                {
                    if (cells[row, col].IsCellEmpty()) temp += ("--");
                    else temp += (cells[row, col].piece?.name);
                    temp += ("  ");
                }
                final = temp + ("\n\n") + final;
            }
            final += "\n\n";
            Console.Write(final);
        }
        public void MovePiece(Position startPos, Position endPos)
        {
            cells[endPos.row, endPos.col].SetPiece(cells[startPos.row, startPos.col].piece);
            cells[startPos.row, startPos.col].SetPiece(null);
        }
    }
}