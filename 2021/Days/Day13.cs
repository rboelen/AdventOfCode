using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021, 13)]
    internal class Day13 : Day.NewLineSplitParsed<string>
    {
       

        public override object ExecutePart1()
        {
            List<(int x, int y)> map;
            List<(string axis, int value)> instructions;

            map = Input.Where(s => !string.IsNullOrEmpty(s) && !s.Contains("fold along "))
                .Select(s =>
                {
                    var parts = s.Split(",").Select(c => Convert.ToInt32(c)).ToArray();
                    return (parts[0], parts[1]);
                }).ToList();

            instructions = Input.Where(s => !string.IsNullOrEmpty(s) && s.Contains("fold along "))
                .Select(s =>
                {
                    var parts = s.Replace("fold along ","").Split("=");
                    return (parts[0], Convert.ToInt32(parts[1]));
                }).ToList();

            map = Fold(map.Take(1).ToList(), instructions.Take(1).ToList());
            return map.Count();
        }

        public override object ExecutePart2()
        {
            List<(int x, int y)> map;
            List<(string axis, int value)> instructions;

            map = Input.Where(s => !string.IsNullOrEmpty(s) && !s.Contains("fold along "))
                .Select(s =>
                {
                    var parts = s.Split(",").Select(c => Convert.ToInt32(c)).ToArray();
                    return (parts[0], parts[1]);
                }).ToList();

            instructions = Input.Where(s => !string.IsNullOrEmpty(s) && s.Contains("fold along "))
                .Select(s =>
                {
                    var parts = s.Replace("fold along ", "").Split("=");
                    return (parts[0], Convert.ToInt32(parts[1]));
                }).ToList();

            map = Fold(map, instructions);

            int maxX = map.Max(p => p.x);
            int maxY = map.Max(p => p.y);

            Console.Write(Environment.NewLine);
            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    var p = map.FirstOrDefault(p => p.x == x && p.y == y);
                    Console.Write(p == default ? " " : "#");
                }
                Console.Write(Environment.NewLine);
            }

            return map.Count();
        }

        public List<(int x, int y)>  Fold(List<(int x, int y)> map, List<(string axis, int value)>  instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.axis == "x")
                {

                    for (int i = 0; i < map.Count; i++)
                    {
                        if (map[i].x > instruction.value)
                        {
                            map[i] = (instruction.value - (map[i].x - instruction.value), map[i].y);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < map.Count; i++)
                    {
                        if (map[i].y > instruction.value)
                        {
                            map[i] = (map[i].x, instruction.value - (map[i].y - instruction.value));
                        }
                    }
                }
            }
            return map = map.Distinct().ToList();
        }
    }
}

