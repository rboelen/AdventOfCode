using Days.Parsers;

namespace Days;

[Day(2024, 2)]
internal class Day3 : Day<int[][]>
{
    private readonly StringToIntArrayParser parser = new();

    public override int[][] ParseInput(string rawInput)
    {
        return parser.Parse(rawInput);
    }

    public override object ExecutePart1()
    {
        return SolvePart1(Input);
    }

    public override object ExecutePart2()
    {
        return SolvePart1(Input);
    }

    public static int SolvePart1(int[][] input)
    {
        if (input == null || input.Length == 0)
        {
            return 0;
        }
        return 0;
    }

}
