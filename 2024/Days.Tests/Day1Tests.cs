using FluentAssertions;
using NUnit.Framework;

namespace Days.Tests;

public class Day1Tests
{
    [Test]
    public void Part1_Sample_Returns_11()
    {
        // arrange
        var input = new int[][] { [3, 4], [4, 3], [2, 5], [1, 3], [3, 9], [3, 3] };
        var target = new Day1 { Input = input };

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(11);
    }

    [Test]
    public void Part2_Sample_Returns_31()
    {
        // arrange
        var input = new int[][] { [3, 4], [4, 3], [2, 5], [1, 3], [3, 9], [3, 3] };
        var target = new Day1 { Input = input };

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(31);
    }
}
