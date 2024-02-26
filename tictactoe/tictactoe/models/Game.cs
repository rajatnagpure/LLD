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

        private Game() { }

        // Builder class
        public class Builder
        {
            private int dimension;
            private List<Player> players;
            private List<WinningStretegyInterface> winningStretegies;

            public Builder(int dimension)
            {
                this.dimension = dimension;
                this.players = new List<Player>();
                this.winningStretegies = new List<WinningStretegyInterface>();
            }

            public Builder AddPlayer(Player player)
            {
                if (players.Exists(x => x.uName == player.uName))
                    throw new Exception("Player with the same uName already exists!");

                if (players.Exists(x => x.mark == player.mark))
                    throw new Exception("This mark is already chosen by another player!");

                players.Add(player);
                return this;
            }

            public Builder AddRowWinningStrategy()
            {
                if (!winningStretegies.Contains(new RowWinningStrategy()))
                    winningStretegies.Add(new RowWinningStrategy());

                return this;
            }

            public Builder AddColWinningStrategy()
            {
                if (!winningStretegies.Contains(new ColWinningStrategy()))
                    winningStretegies.Add(new ColWinningStrategy());

                return this;
            }

            public Builder AddDiagonalWinningStrategy()
            {
                if (!winningStretegies.Contains(new DiagonalWinningStrategy()))
                    winningStretegies.Add(new DiagonalWinningStrategy());

                return this;
            }

            public Game Build()
            {
                if (dimension <= 0)
                    throw new InvalidOperationException("Dimension must be greater than zero!");

                if (players.Count < 2)
                    throw new InvalidOperationException("At least two players are required!");

                var game = new Game
                {
                    board = new Board(3),
                    moveCount = 0,
                    dimension = this.dimension,
                    players = this.players,
                    winningStretegies = this.winningStretegies,
                    gameStatus = GameStatusEnumeration.INITIALIZING
                };

                game.gameStatus = GameStatusEnumeration.RUNNING;
                return game;
            }
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

