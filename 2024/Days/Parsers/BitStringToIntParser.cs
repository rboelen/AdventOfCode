namespace Days.Parsers;

public class BitStringToIntParser : IParser<int[]>
{
    public int[] Parse(string rawInput)
    {
        return rawInput.Split('\n').Select(i => Convert.ToInt32(i, 2)).ToArray();
    }
}

public class StringToIntArrayParser : IParser<int[][]>
{
    public int[][] Parse(string rawInput)
    {
        return rawInput.Split('\n')
            .Select(i => i.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(x => Convert.ToInt32(x)).ToArray()
        ).ToArray();
    }
}
