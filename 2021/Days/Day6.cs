using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021, 6)]
    internal class Day6 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            return Solve(80);
        }

        public override object ExecutePart2()
        {
            return Solve(256);
        }

        private object Solve(int days)
        {
            var fishesDays = Input[0].Split(',').Select(x => Convert.ToDouble(x)).ToArray();
            var fishes = new double[9];
            Array.Fill(fishes, 0);

            // frequency count;
            foreach (int d in fishesDays)
            {
                fishes[d]++;
            }

            for (int i = 0; i < days; i++)
            {
                double count = fishes[0];
                for (int j = 0; j < fishes.Count() - 1; j++)
                {
                    fishes[j] = fishes[j + 1];
                }

                fishes[fishes.Count() - 1] = count;
                fishes[6] += count;

            }

            double fishSum = 0;

            for (var j = 0; j < fishes.Count(); j++)
            {
                fishSum += fishes[j];
            }

            return fishSum;
        }
    }
}
