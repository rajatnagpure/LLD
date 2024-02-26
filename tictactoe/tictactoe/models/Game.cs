using System;
using System.Linq;
using tictactoe.strategies;

namespace tictactoe.models
{
    public class Game
    {
        public Board board { get; private set; }
        public List<Player> players { get; private set; }
        public List<WinningStretegyInterface> winningStretegies { get; private set; }
        public GameStatusEnumeration gameStatus { get; private set; }
        public Player? winner { private set; get; }
        public int moveCount { private set; get; }
        public int dimension { private set; get; }
        public Game(int dimension)
        {
            board = new Board(3);
            moveCount = 0;
            this.dimension = dimension;
            players = new List<Player>();
            winningStretegies = new List<WinningStretegyInterface>();
            gameStatus = GameStatusEnumeration.INITIALIZING;
        }
        public void addPlayer(Player player)
        {
            if (players.Exists(x => x.uName == player.uName))
                throw new Exception("Player with same uName already exists!");
            if (players.Exists(x => x.mark == player.mark))
                throw new Exception("This mark is already choosen by another player!");
            players.Add(player);
        }
        public void addRowWinningStrategy()
        {
            if (winningStretegies.Contains(new RowWinningStrategy())) return;
            winningStretegies.Add(new RowWinningStrategy());
        }
        public void addColWinningStrategy()
        {
            if (winningStretegies.Contains(new ColWinningStrategy())) return;
            winningStretegies.Add(new ColWinningStrategy());
        }
        public void addDiagonalWinningStrategy()
        {
            if (winningStretegies.Contains(new DiagonalWinningStrategy())) return;
            winningStretegies.Add(new DiagonalWinningStrategy());
        }
        public void startGame()
        {
            if (gameStatus == GameStatusEnumeration.OVER) return;
            gameStatus = GameStatusEnumeration.RUNNING;
        }
        public void stopGame()
        {
            gameStatus = GameStatusEnumeration.OVER;
        }
        public bool checkForWinner(MarkEnumeration mark)
        {
            foreach(WinningStretegyInterface strategies in winningStretegies)
            {
                if(strategies.checkForWinningSequence(board.Cells, mark))
                {
                    gameStatus = GameStatusEnumeration.OVER;
                    winner = players[moveCount % players.Count];
                    return true;
                }
            }
            return false;
        }
        public bool nextMove(Tuple<int,int> pos)
        {
            try
            {
                board.Cells[pos.Item2, pos.Item1].setMark(players[moveCount++ % players.Count].mark);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public void displayBoard()
        {
            board.Display();
        }
    }
}

