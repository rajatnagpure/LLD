using System;
using tictactoe.models;

namespace tictactoe.controllers
{
    public class GameController
    {
        public Game getGame(int dimension)
        {
            return new Game(dimension);
        }
        public bool addPlayer(Game game, string uName, MarkEnumeration mark)
        {
            Player player = new Player(uName, mark);
            try
            {
                game.addPlayer(player);
            }catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public void addWinningStrategies(Game game, bool row, bool col, bool diagonal)
        {
            if (col) game.addColWinningStrategy();
            if (row) game.addRowWinningStrategy();
            if (diagonal) game.addDiagonalWinningStrategy();
        }
        public void startGame(Game game)
        {
            game.startGame();
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

