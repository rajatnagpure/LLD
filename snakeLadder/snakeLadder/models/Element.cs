using System;
namespace snakeLadder.models
{
    public class Element
    {
        public Tuple<int,int> StartPoint { get; private set; }
        public Tuple<int,int> EndPoint { get; private set; }
        public Element(Tuple<int, int> startPoint, Tuple<int, int> endPoint)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
        }
    }
}

