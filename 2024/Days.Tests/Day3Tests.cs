using FluentAssertions;
using NUnit.Framework;
using System.IO;

namespace Days.Tests;

public class Day3Tests
{
    [Test]
    public void Part1_Sample_Returns_161()
    {
        // arrange
        var input = @"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        var target = new Day3();
        target.Input = input;

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(161);
    }

    [Test]
    public void Part1_Input_Returns()
    {
        // arrange
        var input = File.ReadAllText("Resources/day3.txt");

        var target = new Day3();
        target.Input = input;

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(167650499);
    }

    [Test]
    public void Part2_Sample_Returns_48()
    {
        // arrange
        var input = @"xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        var target = new Day3();
        target.Input = input;

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(48);
    }

    [Test]
    public void Part2_Input_Returns()
    {
        // arrange
        var input = File.ReadAllText("Resources/day3.txt");

        var target = new Day3();
        target.Input = input;

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(95846796);
    }

}
