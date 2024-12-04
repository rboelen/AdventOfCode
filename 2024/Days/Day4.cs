namespace Days;

[Day(2024, 4)]
internal partial class Day4 : Day<char[][]>
{
    const string word = "XMAS";
    const string word2 = "MAS";

    public override char[][] ParseInput(string input)
    {
        return input
            .Split("\n")
            .Select(x => x.ToCharArray())
            .ToArray();
    }

    public override object ExecutePart1()
    {
        var result = 0;
        // iterate over each string row and find the word
        for (int i = 0; i < Input.Length; i++)
        {
            for (int j = 0; j < Input[i].Length; j++)
            {
                if (Input[i][j] == word[0])
                {
                    result += FindWords(i, j);
                }
            }
        }

        return result;
    }

    public int FindWords(int row, int col)
    {
        var result = 0;
        result += FindWord(row, col, (0, 1), 0) ? 1 : 0;
        result += FindWord(row, col, (1, 1), 0) ? 1 : 0;
        result += FindWord(row, col, (0, -1), 0) ? 1 : 0;
        result += FindWord(row, col, (-1, -1), 0) ? 1 : 0;
        result += FindWord(row, col, (1, 0), 0) ? 1 : 0;
        result += FindWord(row, col, (-1, 0), 0) ? 1 : 0;
        result += FindWord(row, col, (-1, 1), 0) ? 1 : 0;
        result += FindWord(row, col, (1, -1), 0) ? 1 : 0;
        return result;
    }

    public bool FindWord(int row, int col, (int, int) dir, int index)
    {
        if (index == word.Length)
        {
            return true;
        }
        if (row < 0 || row >= Input.Length || col < 0 || col >= Input[0].Length)
        {
            return false;
        }

        var visited = Input[row][col];
        if (visited != word[index])
        {
            return false;
        }

        if (
            FindWord(row + dir.Item1, col + dir.Item2, dir, index + 1))
        {
            return true;
        }

        return false;
    }

    private List<(int, int)> alocs = new List<(int, int)>();

    public override object ExecutePart2()
    {
        var result = 0;
        // iterate over each string row and find the word
        for (int i = 0; i < Input.Length; i++)
        {
            for (int j = 0; j < Input[i].Length; j++)
            {
                if (Input[i][j] == word2[0])
                {
                    FindWords2(i, j);
                }
            }
        }

        return alocs.GroupBy(x => x).Where(x => x.Count() == 2).Count();
    }

    public void FindWords2(int row, int col)
    {
        FindWord2(row, col, (1, 1), 0);
        FindWord2(row, col, (-1, -1), 0);
        FindWord2(row, col, (-1, 1), 0);
        FindWord2(row, col, (1, -1), 0);
    }

    public bool FindWord2(int row, int col, (int, int) dir, int index)
    {
        if (index == word2.Length)
        {

            return true;
        }
        if (row < 0 || row >= Input.Length || col < 0 || col >= Input[0].Length)
        {
            return false;
        }

        var visited = Input[row][col];
        if (visited != word2[index])
        {
            return false;
        }

        if (
            FindWord2(row + dir.Item1, col + dir.Item2, dir, index + 1))
        {
            if (visited == 'A')
            {
                alocs.Add((row, col));
            }
            return true;
        }

        return false;
    }
}
