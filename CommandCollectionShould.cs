using System.Linq;
using FluentAssertions;
using Moq;
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

        [Fact]
        public void Guide_Vehicle()
        {
            var sut = CommandCollection.Create("FFRLB");

            var vehicleMock = new Mock<IVehicle>();
            sut.Guide(vehicleMock.Object);

            vehicleMock.Verify(x => x.MoveForward(),  Times.Exactly(2));
            vehicleMock.Verify(x => x.MoveBackward(), Times.Once);
            vehicleMock.Verify(x => x.RotateLeft(),   Times.Once);
            vehicleMock.Verify(x => x.RotateRight(),  Times.Once);
        }
    }
}