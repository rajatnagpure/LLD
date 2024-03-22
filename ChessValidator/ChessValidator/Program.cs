using ChessValidator.Models;

Game game = new Game();
game.Display();
game.MakeMove(new Position("a2"), new Position("a4"));
game.Display();
game.MakeMove(new Position("a7"), new Position("a5"));
game.Display();
game.MakeMove(new Position("a1"), new Position("a3"));
game.Display();
game.MakeMove(new Position("a8"), new Position("a6"));
game.Display();
game.MakeMove(new Position("b1"), new Position("c3"));
game.Display();

Console.ReadKey();