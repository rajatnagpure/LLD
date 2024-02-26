using System;

namespace snakeLadder.models
{
    public class Snake : Element
    {
        public Snake(Tuple<int, int> startPoint, Tuple<int, int> endPoint) : base(startPoint, endPoint)
        {
        }
    }
}

