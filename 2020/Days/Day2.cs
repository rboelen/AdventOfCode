using Tidy.AdventOfCode;

namespace Days
{
    [Day(2020,2)]
    internal class Day2 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            var c = 0;
            foreach(var line in Input)
            {
                var parts = line.Split(' ');
                var minmax = parts[0].Split('-').Select(x => Convert.ToInt32(x)).ToList();
                var l = parts[1][0];
                var count = parts[2].Count(c => c == l);
                c += count >= minmax[0] && count <= minmax[1] ? 1 : 0;
            }
            return c;
        }

        public override object ExecutePart2()
        {
            var c = 0;
            foreach (var line in Input)
            {
                var parts = line.Split(' ');
                var minmax = parts[0].Split('-').Select(x => Convert.ToInt32(x)).ToList();
                var l = parts[1][0];
                var count = parts[2][minmax[0]-1] == l ? 1 : 0;
                count += parts[2][minmax[1]-1] == l ? 1 : 0;

                c += count == 1 ? 1 : 0;
            }
            return c;
        }

    }

}
