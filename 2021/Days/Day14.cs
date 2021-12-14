using System.Text.RegularExpressions;
using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021, 14)]
    internal class Day14 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            var line = Input[0];
            var freq = new Dictionary<char, int>();

            List<(string pair, char value)> template = Input.Where(s => s.Contains(" -> ")).Select(s =>
            {
                var p = s.Split(" -> ");
                return (p[0], p[1][0]);
            }).ToList();

            freq = template.Select(s => s.value).Distinct().Select(x => x).ToDictionary(x => x, x => 0);

            for(int i = 0; i < line.Length - 1; i++)
            {
                var pair = line.Skip(i).Take(2).ToArray();
                
                freq[pair[0]]++;
                freq[pair[1]]++;

                ApplyTemplate(freq, template, pair, 0,10);

            }
            var mc = freq.Max(x => x.Value);
            var lc = freq.Min(x => x.Value);
            return mc - lc;
        }

        private async void ApplyTemplate(Dictionary<char, int> freq, List<(string pair, char value)> template, char[] pair, int step, int maxSteps)
        {
            step++;
            var insert = template.First(x => x.pair == new string(pair));
            freq[insert.value]++;

            if (step < maxSteps) { 
                ApplyTemplate(freq, template, new[] { pair[0], insert.value }, step, maxSteps);
                ApplyTemplate(freq, template, new[] { insert.value, pair[1] }, step, maxSteps);
            }
        }

        /// <summary>
        /// Not my own solution,....
        /// </summary>
        /// <returns></returns>
        public override object ExecutePart2()
        {
            var template = Input.First();

            var rules = Input.Skip(2)
                .Select(line => line.Split(" -> "))
                .ToDictionary(x => x[0], x => x[1][0]);

            var pairs = rules.ToDictionary(r => r.Key,r => new Regex(r.Key).Matches(template).LongCount());

            var chars = Enumerable.Range(0, 26).Select(i => (char)('A' + i))
                .ToDictionary(c => c, c => template.LongCount(t => t == c));

            for (int step = 0; step < 40; step++)
            {
                foreach (var rule in rules)
                {
                    chars[rule.Value] += pairs[rule.Key];
                }

                pairs = rules.ToDictionary(r => r.Key,
                    r => rules
                    .Where(x => x.Key.Insert(1, x.Value.ToString()).Contains(r.Key))
                    .Sum(x => pairs[x.Key]));
            }

            var elements = chars.Where(c => c.Value > 0).OrderBy(d => d.Value);
            return elements.Last().Value - elements.First().Value;
           
        }

    }
}

