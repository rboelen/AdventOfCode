using FluentAssertions;
using NUnit.Framework;
using System.IO;

namespace Days.Tests;

public class Day2Tests
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

    [Test]
    public void Part2_Sample_Returns_4()
    {
        // arrange
        var input = new int[][] {
            [7, 6, 4, 2, 1],
            [1, 2, 7, 8, 9],
            [9, 7, 6, 2, 1],
            [1, 3, 2, 4, 5],
            [8, 6, 4, 4, 1],
            [1, 3, 6, 7, 9]
        };
        var target = new Day2 { Input = input };

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(4);
    }

    [Test]
    public void Part1_Input_Returns_202()
    {
        var file = File.ReadAllText("Resources/day2.txt");

        var target = new Day2();
        target.Input = target.ParseInput(file);

        // act
        var result = target.ExecutePart1();

        // assert
        result.Should().Be(202);
    }

    [Test]
    public void Part2_Input_Returns()
    {
        var file = File.ReadAllText("Resources/day2.txt");

        var target = new Day2();
        target.Input = target.ParseInput(file);

        // act
        var result = target.ExecutePart2();

        // assert
        result.Should().Be(271);
    }
}
