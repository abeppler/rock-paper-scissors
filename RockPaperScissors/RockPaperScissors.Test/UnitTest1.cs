using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RockPaperScissors.Test
{
    public class UnitTest1
    {
        [Fact]
        public void RpsGameWinner_ShouldRaiseExceptionWhenPlayerNumbersNotEqualTwo()
        {
            //Arrange
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

            //Act & Assert
            var ex2 = Assert.Throws<WrongNumberOfPlayersErrorException>(() => RpsGameWinner(round2));
        }

        [Fact]
        public void RpsGameWinner_ShouldRaiseNoSuchStrategyErrorWhenStrategyDifferentRPS()
        {
            //Arrange
            var round = new Round
            {
                Game1 = new Game()
                {
                    PlayerName = "Dave",
                    Strategy = "T"
                },
                Game2 = new Game()
                {
                    PlayerName = "Dave",
                    Strategy = "V"
                }
            };

            //Act & Assert
            var ex = Assert.Throws<NoSuchStrategyErrorException>(() => RpsGameWinner(round));
        }


        [Fact]
        public void RpsGameWinner_PlayerOneShouldWinWhenBothPlayersPlaySameMove()
        {
            //Arrange
            var round = new Round
            {
                Game1 = new Game()
                {
                    PlayerName = "Player1",
                    Strategy = "R"
                },
                Game2 = new Game()
                {
                    PlayerName = "Player2",
                    Strategy = "R"
                }
            };

            //Act
            var winner = RpsGameWinner(round);

            //Assert
            winner.PlayerName.Should().Be("Player1");
        }

        [Fact]
        public void RpsGameWinner_RockShouldBeatScissor()
        {
            //Arrange
            var round1 = new Round
            {
                Game1 = new Game()
                {
                    PlayerName = "Player1",
                    Strategy = "R"
                },
                Game2 = new Game()
                {
                    PlayerName = "Player2",
                    Strategy = "S"
                }
            };

            var round2 = new Round
            {
                Game1 = new Game()
                {
                    PlayerName = "Player1",
                    Strategy = "S"
                },
                Game2 = new Game()
                {
                    PlayerName = "Player2",
                    Strategy = "R"
                }
            };

            //Act
            var winnerRound1 = RpsGameWinner(round1);
            var winnerRound2 = RpsGameWinner(round2);

            //Assert
            winnerRound1.PlayerName.Should().Be("Player1");
            winnerRound2.PlayerName.Should().Be("Player2");
        }


        private Game RpsGameWinner(Round round)
        {
            if ((round.Game1 == null) || (round.Game2 == null))
            {
                throw new WrongNumberOfPlayersErrorException();
            }

            var validStrategies = new string[] { "R", "P", "S" };

            if ((!validStrategies.Contains(round.Game1.Strategy.ToUpper())) || (!validStrategies.Contains(round.Game2.Strategy.ToUpper())))
            {
                throw new NoSuchStrategyErrorException();
            }

            if (round.Game1.Strategy.ToUpper() == round.Game2.Strategy.ToUpper())
            {
                return round.Game1;
            }

            if (round.Game1.Strategy == "R")
            {
                if (round.Game2.Strategy == "S")
                {
                    return round.Game1;
                }
            }

            if (round.Game2.Strategy == "R")
            {
                if (round.Game1.Strategy == "S")
                {
                    return round.Game2;
                }
            }

            throw new NotImplementedException();
        }
    }
}
