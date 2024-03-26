using ChessValidator.Enumerations;
using ChessValidator.Models;

namespace ChessValidator.Services
{
    public class GameService
    {
        private ValidatorService validatorService;
        public GameService(ValidatorService validatorService)
        {
            this.validatorService = validatorService;
        }
        public Game CreateGame()
        {
            return new Game();
        }
        public void StartGame(Game game)
        {
            if (game.gameState == GameStateEnum.INITIALIZING)
                game.SetState(GameStateEnum.STARTED);
            else throw new InvalidOperationException();
        }
        public void EndGame(Game game)
        {
            if (game.gameState == GameStateEnum.STARTED)
                game.SetState(GameStateEnum.ENDED);
            else throw new InvalidOperationException();
        }
        public void Display(Game game)
        {
            Console.Clear();
            game.board.Display();
        }

        public string MakeMove(Game game, Position startPos, Position endPos)
        {
            if (game.gameState == GameStateEnum.INITIALIZING) return "Game has not started yet";
            if (game.gameState == GameStateEnum.ENDED) return "Game has Ended";
            try
            {
                if (validatorService.ValidateMove(game.board, game.nextMovePieceColor, startPos, endPos))
                {
                    game.board.MovePiece(startPos, endPos);
                    game.ChangeNextMovePieceColor();

                    if (validatorService.IsCheck(game.board, game.nextMovePieceColor))
                    {
                        return "Color " + Enum.GetName(typeof(PieceColorEnum), game.nextMovePieceColor) + " is in Check!";
                    }

                    // Check if the opponent's king is in checkmate
                    if (validatorService.IsCheckMate(game.board, game.nextMovePieceColor))
                    {
                        game.SetWinnerPieceColor(game.nextMovePieceColor == PieceColorEnum.WHITE ? PieceColorEnum.BLACK : PieceColorEnum.WHITE);
                        EndGame(game);
                        return "Color " + Enum.GetName(typeof(PieceColorEnum), game.nextMovePieceColor) + " is CheckMated!";
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
            return "Move success!";
        }
    }
}

