using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021, 7)]
    internal class Day7 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            return Solve();
        }

        public override object ExecutePart2()
        {
            return Solve2();
        }

        private int Solve()
        {
            var crabs = Input[0].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
            var min = crabs.Min();
            var max = crabs.Max();
            var fuel = new int[max - min];

            for (int i = min; i < max; i++)
            {
                fuel[i] = crabs.Sum(c => Math.Abs(c - i));
            }

            return fuel.Min();
            
        }

        private int Solve2()
        {
            var crabs = Input[0].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
            var min = crabs.Min();
            var max = crabs.Max();
            var fuel = new int[max - min];

            for (int i = min; i < max; i++)
            {
                fuel[i] = crabs.Sum(c => Enumerable.Range(1, Math.Abs(c - i)).Sum());
            }

            return fuel.Min();

        }
    }
}
