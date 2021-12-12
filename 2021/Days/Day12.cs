using System.Collections.Immutable;
using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021, 12)]
    internal class Day12 : Day.NewLineSplitParsed<string>
    {
        static Dictionary<string, IEnumerable<string>> map;

        class Node
        {
            public string From { get; set; }
            public string To { get; set; }
        }

        public override object ExecutePart1()
        {
            map = Parse();
            
            var r = FindPart1("start", ImmutableHashSet.Create<string>("start"));
            return r;
        }


        public override object ExecutePart2()
        {
            map = Parse();

            var r = FindPart2("start", ImmutableHashSet.Create<string>("start"), false);
            return r;
        }

        public int FindPart1(string currentCave, ImmutableHashSet<string> visitedCaves)
        {
            if (currentCave == "end")
            {
                return 1;
            }
            var res = 0;

            foreach (var cave in map[currentCave])
            {
                var big = cave.ToUpper() == cave;
                var visited = visitedCaves.Contains(cave);

                if (!visited || big)
                {
                    res += FindPart1(cave, visitedCaves.Add(cave));
                }
            }
            return res;
        }

        public int FindPart2(string currentCave, ImmutableHashSet<string> visitedCaves, bool checkAgain)
        {
            if (currentCave == "end")
            {
                return 1;
            }
            var res = 0;

            foreach (var cave in map[currentCave])
            {
                var big = cave.ToUpper() == cave;
                var visited = visitedCaves.Contains(cave);

                if (!visited || big)
                {
                    res += FindPart2(cave, visitedCaves.Add(cave), checkAgain);
                }else if(!big && cave != "start" && !checkAgain)
                {
                    res += FindPart2(cave, visitedCaves.Add(cave), true);
                }
            }
            return res;
        }

        public Dictionary<string, IEnumerable<string>> Parse()
        {
            var map = Input.SelectMany(x =>
            {
                var parts = x.Split("-");
                return new[] {
                    new Node { From = parts[0], To = parts[1] },
                    new Node { From = parts[1], To = parts[0] }
                };
            });

            return map.GroupBy(n => n.From).ToDictionary(x => x.Key, v => v.Select(n => n.To));
        }
    }
}

