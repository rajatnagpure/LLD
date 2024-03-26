using ChessValidator.Controllers;
using ChessValidator.Services;

namespace ChessValidator
{
    public class Startup
    {
        private static  GameController gameController;
        private static ValidatorService validatorService;
        private static GameService gameService;
        public static GameController Setup()
        {
            validatorService = new ValidatorService();
            gameService = new GameService(validatorService);
            gameController = new GameController(gameService);
            return gameController;
        }
    }
}

