using ChessValidator.Enumerations;

namespace ChessValidator.Models
{
    public class Game
    {
        public Board board { private set; get; }
        public PieceColorEnum nextMovePieceColor { private set; get; }
        private ValidatorMaster validatorMaster;
        public GameStateEnum gameState { private set; get; }
        public PieceColorEnum winnerPieceColor { private set; get; }
        public Game()
        {
            gameState = GameStateEnum.INITIALIZING;
            nextMovePieceColor = PieceColorEnum.WHITE;
            board = new Board();
            board.Initialize();
            validatorMaster = new ValidatorMaster();
        }
        public void StartGame()
        {
            if (gameState == GameStateEnum.INITIALIZING)
                gameState = GameStateEnum.STARTED;
            else throw new InvalidOperationException();
        }
        public void EndGame()
        {
            if (gameState == GameStateEnum.STARTED)
                gameState = GameStateEnum.ENDED;
            else throw new InvalidOperationException();
        }
        public void Display()
        {
            Console.Clear();
            board.Display();
        }
        private bool ValidateMove(Position startPos, Position endPos)
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
        public string MakeMove(Position startPos, Position endPos)
        {
            try
            {
                if (ValidateMove(startPos, endPos))
                {
                    board.MovePiece(startPos, endPos);
                    nextMovePieceColor = nextMovePieceColor == PieceColorEnum.WHITE ? PieceColorEnum.BLACK : PieceColorEnum.WHITE;

                    if (validatorMaster.IsCheck(board, nextMovePieceColor))
                    {
                        return "Color " + Enum.GetName(typeof(PieceColorEnum), nextMovePieceColor) + " is in Check!";
                    }

                    // Check if the opponent's king is in checkmate
                    if (validatorMaster.IsCheckMate(board, nextMovePieceColor))
                    {
                        winnerPieceColor = nextMovePieceColor == PieceColorEnum.WHITE ? PieceColorEnum.BLACK : PieceColorEnum.WHITE;
                        EndGame();
                        return "Color " + Enum.GetName(typeof(PieceColorEnum), nextMovePieceColor) + " is CheckMated!";
                    }
                }
                else
                {
                    return "Invalid Move";
                }
            }
            catch (Exception ex)
            {
                return ex.Message; // Return exception message if move is invalid
            }
            return "Move success";
        }
    }
}

