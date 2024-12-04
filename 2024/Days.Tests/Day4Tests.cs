using FluentAssertions;
using NUnit.Framework;
using System.IO;

namespace Days.Tests;

public class Day4Tests
{
    [Test]
    public void Part1_Sample_Returns_18()
    {
        // arrange
        var input = "MMMSXXMASM\nMSAMXMSMSA\nAMXSXMAAMM\nMSAMASMSMX\nXMASAMXAMM\nXXAMMXXAMA\nSMSMSASXSS\nSAXAMASAAA\nMAMMMXMMMM\nMXMXAXMASX";
        var target = new Day4();
        target.Input = target.ParseInput(input);

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(18);
    }

    [Test]
    public void Part1_Input_Returns()
    {
        // arrange
        var input = File.ReadAllText("Resources/day4.txt");
        input = input.ReplaceLineEndings("\n");
        var target = new Day4();
        target.Input = target.ParseInput(input);

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(18);
    }

    [Test]
    public void Part2_Input_Returns()
    {
        // arrange
        var input = File.ReadAllText("Resources/day4.txt");
        input = input.ReplaceLineEndings("\n");
        var target = new Day4();
        target.Input = target.ParseInput(input);

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(9);
    }
}
