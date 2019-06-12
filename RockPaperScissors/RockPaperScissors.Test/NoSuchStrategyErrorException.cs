using System;
using System.Runtime.Serialization;

namespace RockPaperScissors.Test
{
    public class NoSuchStrategyErrorException : Exception
    {
        public NoSuchStrategyErrorException()
        {
        }

        public NoSuchStrategyErrorException(string message) : base(message)
        {
        }

        public NoSuchStrategyErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoSuchStrategyErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
