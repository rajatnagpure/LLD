using System;
namespace snakeLadder.exceptions
{
    public class PlayerAlreadyExistsException: Exception
    {
        public PlayerAlreadyExistsException() : base("Player with same UName Already present")
        {
        }
    }
}