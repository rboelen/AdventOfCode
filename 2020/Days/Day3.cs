using Tidy.AdventOfCode;

namespace Days
{
    [Day(2020,3)]
    internal class Day3 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            return CalcTrees(3,1);
        }

        public override object ExecutePart2()
        {
            var input = new[] { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };
            var slopes = input.Select(i => CalcTrees(i.Item1, i.Item2));
            var r = slopes.Aggregate((a, b) => a * b);
            return r;
        }

        private int CalcTrees(int right, int down)
        {
            var x = 0;
            var trees = 0;
            for (var y = down; y < Input.Length; y+=down)
            {
                
                x += right;
                if (x >= Input[y].Length)
                {
                    x = x - Input[y].Length;
                }
                trees += Input[y][x] == '#' ? 1 : 0;
            }

            return trees;
        }

    }

}
