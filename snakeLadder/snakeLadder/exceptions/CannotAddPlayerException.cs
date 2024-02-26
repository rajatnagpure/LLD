using System;
namespace snakeLadder.exceptions
{
    public class CannotAddPlayerException: Exception
    {
        public CannotAddPlayerException() : base("New Player cannot be added while game is running or over")
        {
        }
    }
}

