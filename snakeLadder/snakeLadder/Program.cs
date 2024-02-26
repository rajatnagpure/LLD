using System;
using snakeLadder.controllers;
using snakeLadder.models;
using snakeLadder.exceptions;

namespace snakeLadder
{
    class Program
    {
        public static void Main(string[] args)
        {
            GameController gameController = new GameController();
            int MxDiceNum = 6;
            System.Console.WriteLine("Write the max dice number");
            MxDiceNum = Convert.ToInt32(System.Console.ReadLine());
            Game game = gameController.getGame(MxDiceNum);

            gameController.addPlayer(game, new Player("Rajat"));
            gameController.addPlayer(game, new Player("Robo"));

            gameController.addSnake(game, 99, 1);
            gameController.addSnake(game, 50, 11);
            gameController.addSnake(game, 30, 5);
            gameController.addSnake(game, 44, 33);

            gameController.addLadder(game, 2, 16);
            gameController.addLadder(game, 3, 16);
            gameController.addLadder(game, 4, 16);
            gameController.addLadder(game, 5, 16);
            gameController.addLadder(game, 6, 16);
            gameController.addLadder(game, 7, 16);
            gameController.addLadder(game, 23, 70);
            gameController.addLadder(game, 31, 40);
            gameController.addLadder(game, 61, 90);

            gameController.startGame(game);

            while(gameController.getState(game) == GameState.RUNNING)
            {
                System.Console.WriteLine("Press m to make next move else any other char key to end");
                char keyStroke = System.Console.ReadKey().KeyChar;
                if(keyStroke != 'm')
                {
                    gameController.endGame(game);
                    break;
                }
                System.Console.WriteLine("Dice gave : "+ gameController.makeMove(game));
                System.Console.Write(gameController.getPlayerPositions(game));
            }
            System.Console.WriteLine("The Winner is " + gameController.checkForWinner(game));
            System.Console.ReadKey();
        }
    }
}