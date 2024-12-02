using Days.Parsers;

namespace Days;

[Day(2024, 1)]
internal class Day1 : Day<int[][]>
{
    private readonly StringToIntArrayParser parser = new();

    public override int[][] ParseInput(string rawInput)
    {
        return parser.Parse(rawInput);
    }
    public override object ExecutePart1()
    {
        return SolvePartsLinq1(Input);
    }

    public override object ExecutePart2()
    {
        return SolvePartsLinq2(Input);
    }

    public static int SolvePartsLinq1(int[][] input)
    {
        if (input == null || input.Length == 0)
        {
            return 0;
        }

        var sortedX = Sort(input, 0);
        var sortedY = Sort(input, 1);

        int dist = 0;

        for (int i = 0; i < input.Length; i++)
        {
            dist += Math.Abs(sortedY[i] - sortedX[i]);
        }
        return dist;
    }

    public static int SolvePartsLinq2(int[][] input)
    {
        if (input == null || input.Length == 0)
        {
            return 0;
        }

        var right = ToDictionary(input);

        int simm = 0;

        for (int i = 0; i < input.Length; i++)
        {
            right.TryGetValue(input[i][0], out int value);
            simm += input[i][0] * value;
        }
        return simm;
    }
    public static int[] Sort(int[][] input, int index)
    {
        // Sort the array based on the index
        return input.OrderBy(x => x[index]).Select(x => x[index]).ToArray();
    }

    public static Dictionary<int, int> ToDictionary(int[][] input)
    {
        // Sort the array based on the index
        return input.OrderBy(x => x[1])
            .GroupBy(x => x[1]).ToDictionary(x => x.Key, x => x.Count());
    }

}
