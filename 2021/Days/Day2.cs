using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021,2)]
    internal class Day2 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            if (Input == null || Input.Length < 1)
            {
                return 0;
            }

            var location = (0, 0);
            for (int i = 0; i < Input.Length; i++)
            {
                DoCommand(Input[i], ref location);
            }

            return location.Item1 * location.Item2;
        }

        public override object ExecutePart2()
        {
            if (Input == null || Input.Length < 1)
            {
                return 0;
            }

            var location = (0, 0, 0);
            for (int i = 0; i < Input.Length; i++)
            {
                DoCommandWithAim(Input[i], ref location);
            }

            return location.Item1 * location.Item2;
        }

        public void DoCommand(string command, ref (int,int) location)
        {
            var parts = command.Split(' ');
          
            if (parts.Length == 2)
            {
                var value = int.Parse(parts[1]);
                switch (parts[0])
                {
                    case "forward":
                        location = (location.Item1 + value, location.Item2);
                        break;
                    case "down":
                        location = (location.Item1, location.Item2 + value);
                        break;
                    case "up":
                        location = (location.Item1, value <= location.Item2 ? location.Item2 - value : 0);
                        break;
                }
            }
        }

        public void DoCommandWithAim(string command, ref (int, int, int) location)
        {
            var parts = command.Split(' ');

            if (parts.Length == 2)
            {
                var value = int.Parse(parts[1]);
                var depthdelta = (location.Item3 * value);

                switch (parts[0])
                {
                    case "forward":
                        location = (
                            location.Item1 + value,
                            location.Item2 + depthdelta > 0 ? location.Item2 + depthdelta : 0,
                            location.Item3
                        );
                        break;
                    case "down":
                        location = (location.Item1, location.Item2, location.Item3 + value);
                        break;
                    case "up":
                        location = (location.Item1, location.Item2, location.Item3 - value);
                        break;
                }
            }
        }
    }
}
