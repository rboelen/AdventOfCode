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
            var safe = CheckIsSafe(input[i], false);
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

        var safeCount = 0;

        for (int i = 0; i < input.Length; i++)
        {
            var safe = CheckIsSafe(input[i], false);
            if (!safe)
            {
                safe = CheckIsSafe(input[i], true);
            }

            if (safe)
            {
                safeCount++;
            }
        }

        return safeCount;
    }

    private static bool CheckIsSafe(int[] allInput, bool withSkip)
    {
        var skip = withSkip ? 0 : -1;

        while (skip < allInput.Length)
        {
            var safe = true;

            // not happy with this filter, so be all in one go
            var input = allInput.Where((_, index) => index != skip).ToArray();
            var dir = CalcDir(input[0], input[1]);

            for (int i = 0; i < input.Length - 1; i++)
            {
                safe = CheckIsSafe(dir, input[i], input[i + 1]);

                if (!safe)
                {
                    break;
                }
            }
            if (safe)
            {
                return safe;
            }
            if (!withSkip)
            {
                break;
            }
            skip++;
        }

        return false;
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
        return dir == currentDirection && value <= 3;
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
