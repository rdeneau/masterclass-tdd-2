using FluentAssertions;
using Xunit;

namespace MarsRoverKata.Positioning
{
    public class CoordinateShould
    {
        [Fact]
        public void Increment_Within_Bound()
        {
            var sut = Coordinate.Create(10);
            sut.Increment();
            sut.Value.Should().Be(11);
        }

        [Fact]
        public void Decrement_Within_Bound()
        {
            var sut = Coordinate.Create(10);
            sut.Decrement();
            sut.Value.Should().Be(9);
        }

        [Theory]
        [InlineData(0, 5, 5, 0)]
        [InlineData(2, 10, 10, 2)]
        public void Increment_At_The_Max_Get_Back_To_Min(int min, int max, int value, int expected)
        {
            var sut = Coordinate.Create(value, max, min);
            sut.Increment();
            sut.Value.Should().Be(min);
        }

        [Fact]
        public void Decrement_At_The_Min_Get_Straight_To_Max()
        {
            var sut = Coordinate.Create(2, 10, 2);
            sut.Decrement();
            sut.Value.Should().Be(10);
        }
    }
}