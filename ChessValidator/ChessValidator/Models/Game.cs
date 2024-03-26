using ChessValidator.Enumerations;

namespace ChessValidator.Models
{
    public class Game
    {
        public Board board { private set; get; }
        public PieceColorEnum nextMovePieceColor { private set; get; }
        public GameStateEnum gameState { private set; get; }
        public PieceColorEnum? winnerPieceColor { private set; get; }
        public Game()
        {
            gameState = GameStateEnum.INITIALIZING;
            nextMovePieceColor = PieceColorEnum.WHITE;
            board = new Board();
            board.Initialize();
            gameState = GameStateEnum.INITIALIZING;
        }

        public void SetState(GameStateEnum gameState)
        {
            this.gameState = gameState;
        }

        public void ChangeNextMovePieceColor()
        {
            nextMovePieceColor = nextMovePieceColor == PieceColorEnum.WHITE ? PieceColorEnum.BLACK : PieceColorEnum.WHITE;
        }

        public void SetWinnerPieceColor(PieceColorEnum winnerPieceColor)
        {
            this.winnerPieceColor = winnerPieceColor;
        }
    }
}

