using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021, 10)]
    internal class Day10 : Day.NewLineSplitParsed<string>
    {

        public override object ExecutePart1()
        {
            var open = new[] { '{', '(', '[', '<' }.ToList();
            var close = new[] { '}', ')', ']', '>' }.ToList();
            var points = new[] { 1197, 3, 57, 25137 };
            var sum = 0;
            var sample = new[] { "{([(<{}[<>[]}>{[]{[(<()>" };
           // Input = sample;
            foreach (var line in Input)
            {
                var stack = new Stack<char>();
                for (int i = 0; i < line.Length; i++)
                {
                    var closeIndex = close.IndexOf(line[i]);
                    if (closeIndex > -1) {

                        if (stack.FirstOrDefault() == open[closeIndex])
                        {
                            stack.Pop();
                        }
                        else
                        {
                            // corrupt
                            sum += points[closeIndex];
                            break;
                        }
                    } else {
                        stack.Push(line[i]);
                    }
                }
 
            }
            return sum;

        }
        public override object ExecutePart2()
        {
            var open = new[] { '{', '(', '[', '<' }.ToList();
            var close = new[] { '}', ')', ']', '>' }.ToList();
            var points = new[] { 3,1, 2, 4 };
      
            var sample = new[] {

                "[({(<(())[]>[[{[]{<()<>>",
                "[(()[<>])]({[<{<<[]>>(",
                "(((({<>}<{<{<>}{[]{[]{}",
                "{<[[]]>}<{[{[{[]{()[[[]",
                "<{([{{}}[<[[[<>{}]]]>[]]"
            };
            //Input = sample;
            var scores = new List<double>();

            foreach (var line in Input.Where(x => !IsCorrupt(open, close, x)))
            {
                
                var stack = new Stack<char>();
                for (int i = 0; i < line.Length; i++)
                {
                    var closeIndex = close.IndexOf(line[i]);
                    if (closeIndex > -1)
                    {
                        if (stack.FirstOrDefault() == open[closeIndex])
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        stack.Push(line[i]);
                    }
                }

                double score = 0;
                foreach (var item in stack)
                {
                    var index = open.IndexOf(item);
                    score = (5 * score) + points[index];
                }

                scores.Add(score);
            }
            scores = scores.OrderBy(x => x).ToList();
            var r = scores.Skip(scores.Count / 2).First();
            
            return r;
        }

        private static bool IsCorrupt(List<char> open, List<char> close, string line)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < line.Length; i++)
            {
                var closeIndex = close.IndexOf(line[i]);
                if (closeIndex > -1)
                {

                    if (stack.FirstOrDefault() == open[closeIndex])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        // corrupt
                        return true;
                    }
                }
                else
                {
                    stack.Push(line[i]);
                }
            }

            return false;
        }
    }
}

