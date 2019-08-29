using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    public class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError() : base()
        {

        }

        public NoSuchStrategyError(string message) : base(message)
        {

        }
    }
}
