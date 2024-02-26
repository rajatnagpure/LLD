using System;
using snakeLadder.models;
using snakeLadder.exceptions;

namespace snakeLadder.controllers
{
    public class GameController
    {
        public Game getGame(int MaxDiceNumber)
        {
            return new Game(MaxDiceNumber);
        }

        public void addPlayer(Game game, Player player)
        {
            try
            {
                game.addPlayer(player);
            }catch(Exception ex)
            {
                System.Console.WriteLine("Exception " + ex.Message);
            }
            
        }
        public void addSnake(Game game, int startNum, int endNum)
        {
            game.addSnake(startNum, endNum);
        }
        public void addLadder(Game game, int startNum, int endNum)
        {
            game.addLadder(startNum, endNum);
        }
        public void startGame(Game game)
        {
            game.startGame();
        }
        public int makeMove(Game game)
        {
            try
            {
                return game.makeMove();
            }catch(Exception ex)
            {
                System.Console.WriteLine("Exception " + ex.Message);
            }
            return -1;
        }
        public void endGame(Game game)
        {
            game.endGame();
        }
        public GameState getState(Game game)
        {
            return game.state;
        }
        public string checkForWinner(Game game)
        {
            return game.checkForWinner() != null ? game.checkForWinner().UName : "No Winner";
        }
        public string getPlayerPositions(Game game)
        {
            string ret = "";
            foreach(Player player in game.players)
            {
                ret += player.UName + " : " + game.board.Cells[player.Position.Item1, player.Position.Item2].Num+"\n";
            }
            return ret;
        }
    }
}

