using System;
namespace snakeLadder.models
{
    public class Cell
    {
        public int Num {private set; get; }
        public Element? StartElement { private set; get; }
        public Cell(int num)
        {
            Num = num;
            StartElement = null;
        }

        public bool setStartElement(Element element)
        {
            if(StartElement == null)
            {
                StartElement = element;
                return true;
            }
            return false;
        }
    }
}

