using FluentAssertions;
using NUnit.Framework;

namespace Days.Tests;

public class Day3Tests
{
    [Test]
    public void Part1_Sample_Returns_1()
    {
        // arrange
        var input = new int[][] { [7, 6, 4, 2, 1], [1, 3, 2, 4, 5] };
        var target = new Day2 { Input = input };

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(1);
    }

}
