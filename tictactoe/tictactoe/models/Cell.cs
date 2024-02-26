using System;
namespace tictactoe.models
{
    public class Cell
    {
        public MarkEnumeration mark { get; private set; }
        public Cell() { mark = MarkEnumeration.EMPTY; }
        public bool isEmpty()
        {
            return mark == MarkEnumeration.EMPTY;
        }
        public void setMark(MarkEnumeration mark)
        {
            if (this.mark != MarkEnumeration.EMPTY) throw new Exception("Cell is not Empty");
            this.mark = mark;
        }
    }
}

