using FluentAssertions;
using NUnit.Framework;
using System.IO;

namespace Days.Tests;

public class Day5Tests
{
    private Day5 _target;

    public Day5Tests()
    {
        _target = new Day5();
    }

    [Test]
    public void Part1_Input_Returns()
    {
        // arrange
        var input = File.ReadAllText("Resources/day5-s.txt");
        input = input.ReplaceLineEndings("\n");

        _target.Input = _target.ParseInput(input);

        // act
        var result = _target.ExecutePart1();

        // assert
        result.Should().Be(143);
    }

    [Test]
    public void Part2_Input_Returns()
    {
        // arrange
        var input = File.ReadAllText("Resources/day5-s.txt");
        input = input.ReplaceLineEndings("\n");

        _target.Input = _target.ParseInput(input);

        // act
        var result = _target.ExecutePart2();

        // assert
        result.Should().Be(123);
    }
}
