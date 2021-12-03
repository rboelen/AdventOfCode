using FluentAssertions;
using NUnit.Framework;

namespace Days.Tests;

public class Day3Tests
{
    [Test]
    public void Part1_Simple_Success()
    {
        // arrange
        var input = new string[] { "00100", "11110" , "10110" , "10111" , "10101", "01111", "00111", "11100", "10000", "11001", "00010" , "01010" };
        var target = new Day3 { Input = input };

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(198);
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
        var input = new string[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
        var target = new Day3 { Input = input };

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(230);
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