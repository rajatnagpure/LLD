using System;
namespace tictactoe.models
{
    public class Board
    {
        public Cell[,] Cells { private set; get; }
        public int n;
        public Board(int n)
        {
            this.n = n;
            Cells = new Cell[n, n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }
        }
        public void Display()
        {
            for (int i = 0; i <= 4 * n + 1; i++)
            {
                System.Console.Write("-");
            }
            System.Console.Write("\n");
            for (int j = 0; j < n; j++)
            {
                System.Console.Write("|");
                for(int i = 0; i < n; i++)
                {
                    char mrk = ' ';
                    if (Cells[i, j].mark == MarkEnumeration.X) mrk = 'X';
                    else if(Cells[i, j].mark == MarkEnumeration.O) mrk = 'O';
                    System.Console.Write(" " + mrk + " ");
                    System.Console.Write("|");
                }
                System.Console.Write("\n");
                for (int i = 0; i <= 4*n + 1; i++)
                {
                    System.Console.Write("-");
                }
                System.Console.Write("\n");
            }
        }
        public bool isEmpty(Tuple<int,int> pos)
        {
            return Cells[pos.Item2, pos.Item1].mark == MarkEnumeration.EMPTY;
        }
        public bool fillCell(Tuple<int, int> pos, MarkEnumeration mark)
        {
            try
            {
                Cells[pos.Item2, pos.Item1].setMark(mark);
            }catch(Exception Ex)
            {
                System.Console.WriteLine("The Cell is not Empty");
                return false;
            }
            return true;
        }
        public bool checkIfBoardIsFull()
        {
            for(int j = 0; j < n; j++)
            {
                for(int i = 0; i < n; i++)
                {
                    if (Cells[i, j].mark == MarkEnumeration.EMPTY) return false;
                }
            }
            return true;
        }
    }
}

