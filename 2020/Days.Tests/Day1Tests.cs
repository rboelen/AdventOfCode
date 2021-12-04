using FluentAssertions;
using NUnit.Framework;

namespace Days.Tests
{
    public class Day1Tests
    {
        [Test]
        public void Part1_Sample()
        {
            // arrange
            var input = new[] { 1721,979,366,299,675,1456 };
            var target = new Day1 { Input = input };

            // act
            var result = target.ExecutePart1();

            // assert
            result.Should().Be(514579);
        }
    }
}