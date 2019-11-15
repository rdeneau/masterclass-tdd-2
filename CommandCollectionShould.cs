using System.Linq;
using FluentAssertions;
using Xunit;

namespace MarsRoverKata
{
    public class CommandCollectionShould
    {
        [Theory]
        [InlineData("F")]
        [InlineData("BB")]
        [InlineData("FRLB")]
        public void Map_Letters_To_Commands(string commandLetters)
        {
            var sut = CommandCollection.Create(commandLetters);

            var actualLetters = string.Join("", sut.Commands.Select(x => x.Letter));
            actualLetters.Should().Be(commandLetters);
        }
    }
}