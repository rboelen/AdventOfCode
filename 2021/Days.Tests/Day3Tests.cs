using FluentAssertions;
using NUnit.Framework;

namespace Days.Tests;

public class Day3Tests
{
    [Test]
    public void Part1_Sample_Success()
    {
        // arrange
        var input = new string[] {  };
        var target = new Day2 {  Input = input};

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(0);
    }

    [Test]
    public void Part1_Null_Returns_0()
    {
        // arrange
        var target = new Day2();

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(0);
    }

    [Test]
    public void Part1_NoItem_Returns_0()
    {
        // arrange
        var input = new string[] { };
        var target = new Day2 { Input = input };

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(0);
    }

    [Test]
    public void Part2_Sample_Success()
    {
        // arrange
        var input = new string[] { };
        var target = new Day2 { Input = input };

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(0);
    }

    [Test]
    public void Part2_Null_Returns_0()
    {
        // arrange
        var target = new Day2();

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(0);
    }

    [Test]
    public void Part2_NoItem_Returns_0()
    {
        // arrange
        var input = new string[] { };
        var target = new Day2 { Input = input };

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(0);
    }

}