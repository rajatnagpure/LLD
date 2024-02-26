using System;
using tictactoe.models;

namespace tictactoe.controllers
{
    public class GameController
    {
        public Game getGame(int dimension, List<Player> players, bool row, bool col, bool diagonal)
        {
            Game.Builder builder = new Game.Builder(dimension);
            foreach(var player in players)
            {
                builder.AddPlayer(player);
            }
            if (row) builder.AddRowWinningStrategy();
            if (col) builder.AddColWinningStrategy();
            if (diagonal) builder.AddDiagonalWinningStrategy();
            return builder.Build();
        }
        public void endGame(Game game)
        {
            game.stopGame();
        }
        public string nextMovePlayer(Game game)
        {
            return game.players[game.moveCount % game.players.Count].uName;
        }
        public MarkEnumeration nextMovePlayerMark(Game game)
        {
            return game.players[game.moveCount % game.players.Count].mark;
        }
        public void makeNextMove(Game game, Tuple<int,int> pos)
        {
            game.nextMove(pos);
        }
        public void printBoard(Game game)
        {
            game.board.Display();
        }
        public bool checkForWiner(Game game, MarkEnumeration mark)
        {
            return game.checkForWinner(mark);
        }
        public string getWinner(Game game)
        {
            return (game.winner!=null)?game.winner.uName:"No Winner";
        }
        public GameStatusEnumeration getGameStatus(Game game)
        {
            return game.gameStatus;
        }
    }
}

