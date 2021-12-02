using FluentAssertions;
using NUnit.Framework;

namespace Days.Tests;

public class Day1Tests
{
    [Test]
    public void Part1_Sample_Returns_7()
    {
        // arrange
        var input = new[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
        var target = new Day1 {  Input = input};

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(7);
    }

    [Test]
    public void Part1_Null_Returns_0()
    {
        // arrange
        var target = new Day1();

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(0);
    }

    [Test]
    public void Part1_NoItem_Returns_0()
    {
        // arrange
        var input = new int[] { };
        var target = new Day1 { Input = input };

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(0);
    }

    [Test]
    public void Part1_OneItem_Returns_0()
    {
        // arrange
        var input = new[] { 199 };
        var target = new Day1 { Input = input };

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(0);
    }

    [Test]
    public void Part2_Sample_Returns_5()
    {
        // arrange
        var input = new[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
        var target = new Day1 { Input = input };

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(5);
    }

    [Test]
    public void Part2_Null_Returns_0()
    {
        // arrange
        var target = new Day1();

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(0);
    }

    [Test]
    public void Part2_NoItem_Returns_0()
    {
        // arrange
        var input = new int[] { };
        var target = new Day1 { Input = input };

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(0);
    }

    [Test]
    public void Part2_OneItem_Returns_0()
    {
        // arrange
        var input = new[] { 199 };
        var target = new Day1 { Input = input };

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(0);
    }

}