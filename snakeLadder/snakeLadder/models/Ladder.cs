using System;

namespace snakeLadder.models
{
    public class Ladder : Element
    {
        public Ladder(Tuple<int, int> startPoint, Tuple<int, int> endPoint) : base(startPoint, endPoint)
        {
        }
    }
}

