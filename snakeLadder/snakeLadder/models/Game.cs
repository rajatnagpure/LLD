using System;
using System.Xml.Linq;
using snakeLadder.exceptions;

namespace snakeLadder.models
{
    public class Game
    {
        public List<Player> players { private set; get; }
        public Board board { private set; get; }
        public Dice dice { private set; get; }
        private int MoveCnt = 0;
        public GameState state { private set; get; }
        public Game(int maxNum)
        {
            players = new List<Player>();
            dice = new Dice(maxNum);
            board = new Board();
            state = GameState.SETTING;
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    System.Console.Write(board.Cells[i, j].Num + "  ");
                }
                System.Console.Write('\n');
            }
        }
        public void startGame()
        {
            state = GameState.RUNNING;
        }
        public void endGame()
        {
            state = GameState.OVER;
        }
        public void addPlayer(Player player)
        {
            if (GameState.SETTING != state) throw new CannotAddPlayerException();
            if(players.Find(x => x.UName.Equals(player.UName)) != null)
            {
                throw new PlayerAlreadyExistsException();
            }
            players.Add(player);
        }
        public void addSnake(int startNum, int endNum)
        {
            // start cell
            int sY = startNum / 10;
            int sX = 0;
            if (sY % 2 == 0) sX = (startNum%10)-1;
            else sX = 9 - (startNum%11);

            // end cell
            int eY = endNum / 10;
            int eX = 0;
            if (eY % 2 == 0) eX = (endNum%10)-1;
            else eX = 9 - (endNum%11);

            Snake snake = new Snake(new Tuple<int, int>(sX, sY), new Tuple<int, int>(eX, eY));
            try
            {
                board.addSnake(snake);
            }
            catch(Exception Ex)
            {
                System.Console.WriteLine("Ex : " + Ex.Message);
            }
        }
        public void addLadder(int startNum, int endNum)
        {
            // start cell
            int sY = startNum / 10;
            int sX = 0;
            if (sY % 2 == 0) sX = (startNum%10)-1;
            else sX = 9 - (startNum%11);

            // end cell
            int eY = endNum / 10;
            int eX = 0;
            if (eY % 2 == 0) eX = (endNum % 10) - 1;
            else eX = 9 - (endNum % 11);

            Ladder ladder = new Ladder(new Tuple<int, int>(sX, sY), new Tuple<int, int>(eX, eY));
            
            try
            {
                board.addLadder(ladder);
            }
            catch (Exception Ex)
            {
                System.Console.WriteLine("Ex : " + Ex.Message);
            }
        }
        public int makeMove()
        {
            Player movingPlayer = players[MoveCnt % players.Count()];
            MoveCnt++;
            int move = dice.getNextRandNo();
            int currNum = board.Cells[movingPlayer.Position.Item1, movingPlayer.Position.Item2].Num;
            int nextNum = currNum + move;
            if (nextNum > 100) throw new CannotMoveToPosException();
            int Y = nextNum / 10;
            int X = 0;
            if (Y % 2 == 0) X = (nextNum % 10) - 1;
            else X = 9 - (nextNum % 11);
            
            movingPlayer.setPosition(new Tuple<int,int>(X,Y));
            if (board.Cells[X,Y].StartElement != null)
            {
                movingPlayer.setPosition(board.Cells[X, Y].StartElement.EndPoint);
                System.Console.WriteLine("Moved by Snake or Ladder");
            }
            return move;
        }
        public Player? checkForWinner()
        {
            return players.Find(x => board.Cells[x.Position.Item1, x.Position.Item2].Num == 100);
        }
    }
}

