namespace Days;

[Day(2024, 5)]
internal partial class Day5 : Day<string[]>
{
    public override string[] ParseInput(string rawInput)
    {
        return rawInput.Split("\n");
    }


    public override object ExecutePart1()
    {
        var rules = Input.Where(x => x.Contains('|')).ToHashSet();

        var updates = Input.Where(x => x.Contains(','))
            .Select(x => x.Split(',').Select(y => int.Parse(y)).ToArray()).ToArray();

        var result = 0;
        foreach (var update in updates)
        {
            var correct = true;
            for (var i = 0; i < update.Length; i++)
            {
                var key = update[i];

                for (var j = i + 1; j < update.Length; j++)
                {
                    if (!rules.Contains($"{key}|{update[j]}"))
                    {
                        correct = false;
                        break;
                    }
                }
            }
            if (correct)
            {
                // get middle value from update
                result += update[update.Length / 2];
            }
        }

        return result;
    }


    public override object ExecutePart2()
    {
        var rules = Input.Where(x => x.Contains('|')).ToHashSet();

        var updates = Input.Where(x => x.Contains(','))
            .Select(x => x.Split(',').Select(y => int.Parse(y)).ToArray()).ToArray();

        var result = 0;
        foreach (var update in updates)
        {
            var correct = true;
            for (var i = 0; i < update.Length; i++)
            {
                var key = update[i];

                for (var j = i + 1; j < update.Length; j++)
                {
                    if (!rules.Contains($"{key}|{update[j]}"))
                    {
                        correct = false;
                        break;
                    }
                }
            }
            if (!correct)
            {
                for (var i = 0; i < update.Length - 1; i++)
                {
                    var current = update[i];
                    var next = update[i + 1];
                    var key = $"{current}|{next}";
                    rules.TryGetValue(key, out var value);
                    if (value == null)
                    {
                        // swap
                        update[i] = next;
                        update[i + 1] = current;
                        i = -1;

                    }
                }
                result += update[update.Length / 2];
            }
        }

        return result;
    }
}
