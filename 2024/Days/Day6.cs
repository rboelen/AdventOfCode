namespace Days;

[Day(2024, 6)]
internal partial class Day6 : Day<char[][]>
{
    public override char[][] ParseInput(string rawInput)
    {
        return rawInput.Split("\n").Select(x => x.ToArray()).ToArray();
    }

    static (int, int)[] directions = [(-1, 0), (0, 1), (1, 0), (0, -1)];
    static int dirindex = 0;
    static HashSet<(int, int)> locations = new();

    public override object ExecutePart1()
    {
        var result = 0;

        var pos = FindGuard();
        var dir = directions[dirindex];

        Move(pos, dir);

        result = locations.Count;
        return result;

    }

    private void Move((int, int) pos, (int, int) dir)
    {
        // if pos outsode Input bounds, return true
        if (CheckBounds(pos))
        {
            // mark current position as visited
            Input[pos.Item1][pos.Item2] = 'X';

            // save location to dictionary
            if (!locations.Contains(pos))
            {
                locations.Add(pos);
            }

            var nextpos = (pos.Item1 + dir.Item1, pos.Item2 + dir.Item2);

            if (CheckBounds(nextpos) && Input[nextpos.Item1][nextpos.Item2] == '#')
            {
                dirindex = (dirindex + 1) % 4;
                dir = directions[dirindex];
            }
            else
            {
                pos = (pos.Item1 + dir.Item1, pos.Item2 + dir.Item2);
            }

            Move(pos, dir);
        }

    }

    private bool CheckBounds((int, int) pos)
    {
        return pos.Item1 >= 0 && pos.Item1 < Input.Length && pos.Item2 >= 0 && pos.Item2 < Input[0].Length;
    }

    private (int, int) FindGuard()
    {
        // find the index of the ^ character in Input
        var x = 0;
        var y = 0;
        for (var i = 0; i < Input.Length; i++)
        {
            for (var j = 0; j < Input[i].Length; j++)
            {
                if (Input[i][j] == '^')
                {
                    x = i;
                    y = j;
                    break;
                }
            }
        }
        return (x, y);
    }

    public override object ExecutePart2()
    {
        var result = 0;
        return result;
    }
}
