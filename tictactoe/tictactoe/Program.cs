﻿// See https://aka.ms/new-console-template for more information

using tictactoe.controllers;
using tictactoe.models;

GameController gameController = new GameController();

List<Player> players = new List<Player>();
players.Add(new Player("Rajat", MarkEnumeration.X));
players.Add(new Player("Bot", MarkEnumeration.O));
Game game = gameController.getGame(3,players,true, true, true);

gameController.printBoard(game);

while (gameController.getGameStatus(game) == GameStatusEnumeration.RUNNING)
{
    string nextPlayerUName = gameController.nextMovePlayer(game);
    MarkEnumeration nextPlayerMark = gameController.nextMovePlayerMark(game);
    System.Console.WriteLine(nextPlayerUName + "'s turn, Please give x, y co-ordinate Or to stop game enter -1");
    int x = Convert.ToInt32(Console.ReadLine());
    if(x==-1)
    {
        gameController.endGame(game);
        break;
    }
    int y = Convert.ToInt32(Console.ReadLine());
    gameController.makeNextMove(game, new Tuple<int, int>(x, y));
    gameController.checkForWiner(game, nextPlayerMark);
    gameController.printBoard(game);
}
System.Console.WriteLine("Winner is: " + gameController.getWinner(game));
System.Console.ReadKey();