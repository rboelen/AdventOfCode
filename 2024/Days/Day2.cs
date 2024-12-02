using Days.Parsers;

namespace Days;

[Day(2024, 2)]
internal class Day2 : Day<int[][]>
{
    private readonly StringToIntArrayParser parser = new();

    public override int[][] ParseInput(string rawInput)
    {
        return parser.Parse(rawInput);
    }

    public override object ExecutePart1()
    {
        return SolvePartsLinq1(Input);
    }

    public override object ExecutePart2()
    {
        return SolvePartsLinq2(Input);
    }

    public static int SolvePartsLinq1(int[][] input)
    {
        if (input == null || input.Length == 0)
        {
            return 0;
        }

        var safeCount = 0;

        for (int i = 0; i < input.Length; i++)
        {
            var safe = true;
            var dir = CalcDir(input[i][0], input[i][1]);
            for (int j = 0; j < input[i].Length - 1; j++)
            {
                safe = CheckIsSafe(dir, input[i][j], input[i][j + 1]);

                if ((!safe))
                {
                    break;
                }
            }
            if (safe)
            {
                safeCount++;
            }
        }
        return safeCount;
    }

    public static int SolvePartsLinq2(int[][] input)
    {
        if (input == null || input.Length == 0)
        {
            return 0;
        }

        var unsafeItems = new List<int[]>();

        var safeCount = 0;

        for (int i = 0; i < input.Length; i++)
        {
            var safe = true;
            var dir = CalcDir(input[i][0], input[i][1]);
            for (int j = 0; j < input[i].Length - 1; j++)
            {
                safe = CheckIsSafe(dir, input[i][j], input[i][j + 1]);

                if ((!safe))
                {
                    unsafeItems.Add(input[i]);
                    break;
                }
            }
            if (safe)
            {
                safeCount++;
            }
        }


        // don't like the double loop here
        for (int i = 0; i < unsafeItems.Count; i++)
        {
            var skip = 0;

            // don't like checking all items again
            while (skip < unsafeItems[i].Length)
            {
                var safe = true;
                var items = unsafeItems[i].Where((_, index) => index != skip).ToArray();
                var dir = CalcDir(items[0], items[1]);
                for (int j = 0; j < items.Length - 1; j++)
                {
                    safe = CheckIsSafe(dir, items[j], items[j + 1]);
                    if ((!safe))
                    {
                        break;
                    }
                }

                if (safe)
                {
                    safeCount++;
                    break;
                }

                skip++;
            }
        }

        return safeCount;
    }

    private static bool CheckIsSafe(int currentDirection, int a, int b)
    {
        // check if diff between a and b is increasing or decreasing
        int dir = CalcDir(a, b);
        int diff = a - b;
        var value = Math.Abs(diff);

        if (dir == 0)
        {
            return false;
        }
        // return true if dir equals currentDirection and value is 1, 2 or 3
        return dir == currentDirection && (value == 1 || value == 2 || value == 3);
    }

    private static int CalcDir(int a, int b)
    {
        if (a == b)
        {
            return 0;
        }
        return a - b > 0 ? 1 : -1;
    }
}
