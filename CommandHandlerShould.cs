using System.Linq;
using FluentAssertions;
using Xunit;

namespace MarsRoverKata
{
    public class CommandHandlerShould
    {
        [Theory]
        [InlineData("F")]
        [InlineData("BB")]
        [InlineData("FRLB")]
        public void Map_Letters_To_Commands(string commandLetters)
        {
            var sut = new CommandHandler();

            var commands = sut.Read(commandLetters);

            var actualLetters = string.Join("", commands.Select(x => x.Letter));
            actualLetters.Should().Be(commandLetters);
        }
    }
}