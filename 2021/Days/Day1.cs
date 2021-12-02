using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021,1)]
    internal class Day1 : Day.NewLineSplitParsed<int>
    {
        public override object ExecutePart1()
        {
            return SolvePartsLinq(Input,1);
        }

        public override object ExecutePart2()
        {
            return SolvePartsLinq(Input, 3);
        }

        /// <summary>
        /// Initial solution 
        /// </summary>
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

        /// <summary>
        /// Initial solution 
        /// </summary>
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

        /// <summary>
        /// Best solution after investigating Reddit
        /// </summary>
        public int SolvePartsLinq(int[] depths, int windowSize)
        {
            if (depths == null || depths.Length < 2)
            {
                return 0;
            }

            return depths
               .Where((d, i) => i >= windowSize && d > depths[i - windowSize])
               .Count();
        }
    }
}
