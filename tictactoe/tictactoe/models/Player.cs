using System;
namespace tictactoe.models
{
    public class Player
    {
        public string uName { private set; get; }
        public MarkEnumeration mark { private set; get; }
        public Player(string uName, MarkEnumeration mark)
        {
            this.uName = uName;
            this.mark = mark;
        }
    }
}

