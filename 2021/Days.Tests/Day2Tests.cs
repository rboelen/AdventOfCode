using FluentAssertions;
using NUnit.Framework;

namespace Days.Tests;

public class Day2Tests
{
    [Test]
    public void Part1_Sample_Returns_150()
    {
        // arrange
        var input = new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };
        var target = new Day2 {  Input = input};

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(150);
    }

    [Test]
    public void Part1_Subs_Dont_Fly()
    {
        // arrange
        var input = new[] { "forward 5", "up 1" };
        var target = new Day2 { Input = input };

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
    public void Part2_Sample_Returns_900()
    {
        // arrange
        var input = new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };
        var target = new Day2 { Input = input };

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(900);
    }

    [Test]
    public void Part2_Subs_Dont_Fly()
    {
        // arrange
        var input = new[] { "up 1", "forward 5" };
        var target = new Day2 { Input = input };

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(0);
    }

    [Test]
    public void Part2_Subs_Forward5()
    {
        // arrange
        var input = new[] { "forward 5" };
        var target = new Day2 { Input = input };

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(0);
    }

    [Test]
    public void Part2_Subs_ForwardDown5()
    {
        // arrange
        var input = new[] { "forward 5", "down 5" };
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