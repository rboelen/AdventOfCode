using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021, 5)]
    internal class Day5 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            var grid = new int[999, 999];
            var count = 0;
            for (int i = 0; i < Input.Length; i++)
            {
                var numbers = Input[i].Split(" -> ").SelectMany(x => x.Split(",").Select(n => Convert.ToInt32(n))).ToArray();
                var x1 = numbers[0];
                var y1 = numbers[1];
                var x2 = numbers[2];
                var y2 = numbers[3];

                var deltax = Math.Abs(x2 - x1);
                var deltay = Math.Abs(y2 - y1);
                var signx = Math.Sign(x2 - x1);
                var signy = Math.Sign(y2 - y1);

                if (deltay == 0)
                {
                    var range = signx < 0 ? Enumerable.Range(x2, deltax+1) : Enumerable.Range(x1, deltax+1);
                    foreach (var d in range)
                    {
                        grid[d, y1] += 1;
                        count += grid[d, y1] == 2 ? 1 : 0;
                    }
                }
                else if (deltax == 0)
                {
                    var range = signy < 0 ? Enumerable.Range(y2, deltay + 1) : Enumerable.Range(y1, deltay + 1);
                    foreach (var d in range)
                    {
                        grid[x1, d] += 1;
                        count += grid[x1, d] == 2 ? 1 : 0;
                    }
                }
            }

            return count;
        }

        public override object ExecutePart2()
        {
            var grid = new int[999, 999];
            var count = 0;
            for (int i = 0; i < Input.Length; i++)
            {
                var numbers = Input[i].Split(" -> ").SelectMany(x => x.Split(",").Select(n => Convert.ToInt32(n))).ToArray();
                var x1 = numbers[0];
                var y1 = numbers[1];
                var x2 = numbers[2];
                var y2 = numbers[3];

                var deltax = Math.Abs(x2 - x1);
                var deltay = Math.Abs(y2 - y1);
                var signx = Math.Sign(x2 - x1);
                var signy = Math.Sign(y2 - y1);

                var delta = deltax > deltay ? deltax : deltay;

                for (int d = 0; d <= delta; d++)
                {
                    grid[x1 + (signx * d), y1 + (signy * d)] += 1;
                    count += grid[x1 + (signx * d), y1 + (signy * d)] == 2 ? 1 : 0;
                }
            }

            return count;
        }


    }
}
