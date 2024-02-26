using System;
namespace snakeLadder.models
{
    public class Player
    {
        public String UName { private set; get; }
        public Tuple<int,int> Position { private set; get; }
        public Player(String uName)
        {
            UName = uName;
            Position = new Tuple<int, int>(0, 0);
        }

        public void setPosition(Tuple<int,int> pos) 
        {
            Position = pos;
        } 
    }
}

