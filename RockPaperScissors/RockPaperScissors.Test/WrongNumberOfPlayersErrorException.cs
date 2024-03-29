﻿using System;
using System.Runtime.Serialization;

namespace RockPaperScissors.Test
{
    public class WrongNumberOfPlayersErrorException : Exception
    {
        public WrongNumberOfPlayersErrorException()
        {
        }

        public WrongNumberOfPlayersErrorException(string message) : base(message)
        {
        }

        public WrongNumberOfPlayersErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongNumberOfPlayersErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
