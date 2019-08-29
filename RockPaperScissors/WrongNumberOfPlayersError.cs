using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    public class WrongNumberOfPlayersError : Exception
    {
        public WrongNumberOfPlayersError() : base()
        {

        }

        public WrongNumberOfPlayersError(string message) : base(message)
        {

        }
    }
}
