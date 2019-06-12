using System;
using System.Collections.Generic;
using Xunit;

namespace RockPaperScissors.Test
{
    public class UnitTest1
    {
        [Fact]
        public void RpsGameWinner_ShouldRaiseExceptionWhenPlayerNumbersNotEqualTwo()
        {
            var round1 = new Round
            {
                Game1 = new Game()
                {
                    PlayerName = "Dave",
                    Strategy = "S"
                }
            };
            
            var ex1 = Assert.Throws<WrongNumberOfPlayersErrorException>(() => RpsGameWinner(round1));

            var round2 = new Round
            {
                Game2 = new Game()
                {
                    PlayerName = "Dave",
                    Strategy = "S"
                }
            };

            var ex2 = Assert.Throws<WrongNumberOfPlayersErrorException>(() => RpsGameWinner(round2));
        }

        private object RpsGameWinner(Round round)
        {
            if ((round.Game1 == null) || (round.Game2 == null))
            {
                throw new WrongNumberOfPlayersErrorException();
            }

            throw new NotImplementedException();
        }
    }
}
