using System;
namespace snakeLadder.models
{
    public class Board
    {
        public Cell[,] Cells { private set; get; }
        public List<Snake> Snakes { private set; get;}
        public List<Ladder> Ladders { private set; get; }
        public Board()
        {
            Cells = new Cell[10,10];
            Snakes = new List<Snake>();
            Ladders = new List<Ladder>();
            int num = 1;
            for(int y = 0; y < 10; y++)
            {
                for(int x = 0; x < 10; x++)
                {
                    if (y % 2 == 0) Cells[x, y] = new Cell(num);
                    else Cells[9 - x, y] = new Cell(num);
                    num++;

                }
            }
        }
        private void addElement(Element element)
        {
            int x = element.StartPoint.Item1;
            int y = element.StartPoint.Item2;
            if (Cells[x, y].StartElement != null)
            {
                throw new CannotUnloadAppDomainException();
            }
            Cells[x, y].setStartElement(element);
        }
        public void addSnake(Snake snake)
        {
            try
            {
                addElement(snake);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex.Message);
            }
            Snakes.Add(snake);
        }
        public void addLadder(Ladder ladder)
        {
            try
            {
                addElement(ladder);
            }catch(Exception ex)
            {
                System.Console.WriteLine("Exception: " + ex.Message);
            }
            Ladders.Add(ladder);
        }
        public void display()
        {
            // Big code
        }
    }
}

