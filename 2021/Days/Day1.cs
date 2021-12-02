using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021,1)]
    internal class Day1 : Day.NewLineSplitParsed<int>
    {
        public override object ExecutePart1()
        {
            return SolvePart1(Input);
        }

        public override object ExecutePart2()
        {
            return SolvePart2(Input);
        }

        public int SolvePart1(int[] input)
        {
            int count = 0;
            if (input == null || input.Length < 2) {
                return count;
            }

            for (int i = 1; i < input.Length; i++)
            {
                count += input[i] > input[i - 1] ? 1 : 0;
            }

            return count;
        }

        public int SolvePart2(int[] input)
        {
            int count = 0;
            if (input == null || input.Length < 2)
            {
                return count;
            }

            for (int i = 1; i < input.Length-2; i++)
            {
                count += input.Skip(i).Take(3).Sum() > input.Skip(i - 1).Take(3).Sum() ? 1 : 0;
            }

            return count;
        }
    }
}
