using System.Text.RegularExpressions;

namespace Days;

[Day(2024, 3)]
internal partial class Day3 : Day
{
    [GeneratedRegex(@"mul\((\d+),(\d+)\)")]
    private static partial Regex FindMulRegex();

    [GeneratedRegex(@"mul\((\d+),(\d+)\)|do\(\)|don't\(\)")]
    private static partial Regex FindMulRegex2();

    public override object ExecutePart1()
    {

        var matches = FindMulRegex().Matches(Input);
        var result = 0;
        foreach (var groups in matches.Select(x => x.Groups))
        {
            var x = Convert.ToInt32(groups[1].Value);
            var y = Convert.ToInt32(groups[2].Value);
            result += x * y;
        }


        return result;
    }

    public override object ExecutePart2()
    {
        // create a regex that finds mul(x,y) and do() and don't()
        // sample input: xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))
        // sample output: mul(2,4), don;t(), mul(5,5), mul(11,8), do(), mul(8,5)

        var matches = FindMulRegex2().Matches(Input);
        var result = 0;
        var enabled = true;
        foreach (var groups in matches.Select(x => x.Groups))
        {
            if (groups[0].Value == "do()")
            {
                enabled = true;
                continue;
            }
            if (groups[0].Value == "don't()")
            {
                enabled = false;
                continue;
            }

            if (enabled)
            {
                var x = Convert.ToInt32(groups[1].Value);
                var y = Convert.ToInt32(groups[2].Value);
                result += x * y;
            }
        }

        return result;
    }

}
