using Tidy.AdventOfCode;

namespace Days.Parsers
{
    public class BitStringToIntParser : IParser<int[]>
    {
        public int[] Parse(string rawInput)
        {
            return rawInput.Split('\n').Select(i => Convert.ToInt32(i, 2)).ToArray();
        }
    }
}
