using ChessValidator.Controllers;
using ChessValidator.Enumerations;
using ChessValidator.Models;

GameController gameController = ChessValidator.Startup.Setup();

Game game = gameController.CreateGame();
gameController.Display(game);
Console.WriteLine("Lets Start the Fun, Pick your sides");
gameController.StartGame(game);

while(game.gameState == GameStateEnum.STARTED)
{
    Console.WriteLine("Its " + Enum.GetName(typeof(PieceColorEnum), game.nextMovePieceColor) + "'s Turn! Go Ahead and put Start Pos and End Pos of you move. To end Just press x.");
    string? input = Console.ReadLine();
    if(input != null)
    {
        string moveOutput = "";
        if (input.Trim().ToLower() == "x") break;
        else
        {
            string[] positions = input.Trim().ToLower().Split();
            try
            {
                Position startPos = new Position(positions[0]);
                Position endPos = new Position(positions[1]);
                moveOutput = gameController.MakeNextMove(game, startPos, endPos);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        gameController.Display(game);
        Console.WriteLine(moveOutput);
    }
}
Console.WriteLine("Game Ended!");
if (game.winnerPieceColor == null) Console.WriteLine("No Winners!");
else Console.WriteLine("Winner is Player with color: " + Enum.GetName(typeof(PieceColorEnum), game.winnerPieceColor));
Console.ReadKey();