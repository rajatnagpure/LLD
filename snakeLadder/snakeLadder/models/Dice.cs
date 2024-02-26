using System;
namespace snakeLadder.models
{
    public class Dice
    {
        private Random rnd;
        public int MaxNum { private set; get; }
        public Dice(int n)
        {
            rnd = new Random();
            MaxNum = n;
        }
        public int getNextRandNo()
        {
            return rnd.Next(1, MaxNum);
        }
    }
}

