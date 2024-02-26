using System;
namespace snakeLadder.exceptions
{
    public class CannotMoveToPosException: Exception
    {
        public CannotMoveToPosException() :base("Cannot move to the given pos, Invalid Move")
        {
        }
    }
}

