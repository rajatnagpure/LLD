using ChessValidator.Enumerations;
using ChessValidator.Models;
using ChessValidator.Services;

namespace ChessValidator.Controllers
{
    public class GameController
    {
        private const string SUCCESS = "Success!";
        private GameService gameService;
        public GameController(GameService gameService)
        {
            this.gameService = gameService;
        }
        public Game CreateGame()
        {
            return gameService.CreateGame();
        }
        public string StartGame(Game game)
        {
            try
            {
                gameService.StartGame(game);
            }catch(Exception ex)
            {
                return ex.Message;
            }
            return SUCCESS;
        }
        public string EndGame(Game game)
        {
            try
            {
                gameService.StartGame(game);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return SUCCESS;
        }
        public void Display(Game game)
        {
            gameService.Display(game);
        }
        public string MakeNextMove(Game game, Position startPos, Position endPos)
        {
            return gameService.MakeMove(game, startPos, endPos);
        }
    }
}

