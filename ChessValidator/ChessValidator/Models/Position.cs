namespace ChessValidator.Models
{
    public class Position
    {
        public int row { private set; get; }
        public int col { private set; get; }
        public string name { private set; get; }
        public Position(string pos)
        {
            name = pos.Trim();
            if (name.Length == 2 && name[0] >= 'a' && name[0] <= 'h' && name[1] >= '1' && name[1] <= '8')
            {
                row = name[1] - '1';
                col = name[0] - 'a';
            }
            else throw new Exception("Invalid Input");
        }
        public Position(int row, int col)
        {
            if(row>=0 && row<=7 && col>=0 && col <= 7)
            {
                this.col = col;
                this.row = row;
                name = "";
                name += (col + 'a');
                name += (row + '1');
            }else throw new Exception("Invalid Input");
        }
        // Copy constructor
        public Position(Position other)
        {
            row = other.row;
            col = other.col;
            name = other.name;
        }
    }
}

