using System.Collections;
using System.Text.RegularExpressions;
using Tidy.AdventOfCode;

namespace Days
{
    [Day(2020,5)]
    internal class Day5 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            return Input.Max(x => CalcSeatId(x));
        }

        public override object ExecutePart2()
        {
            var seatIds = Input.Select(x => CalcSeatId(x)).ToList();
            int min = seatIds.Min(), max = seatIds.Max();
            return Enumerable.Range(min, max - min + 1).Except(seatIds).First();
        }

        private int CalcSeatId(string line)
        {
            var lineb = new string(line.Select(b => b == 'B' || b == 'R' ? '1' : '0').ToArray());
            return Convert.ToInt32(lineb, 2);
        }

    }
}
