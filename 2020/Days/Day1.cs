using Tidy.AdventOfCode;

namespace Days
{
    [Day(2020,1)]
    internal class Day1 : Day.NewLineSplitParsed<int>
    {
        public override object ExecutePart1()
        {

            var combo = from n1 in Input
                        from n2 in Input
                        where n1 + n2 == 2020
                        select n1 * n2;

            return combo.First();
        }

        public override object ExecutePart2()
        {
            var combo = from n1 in Input
                        from n2 in Input
                        from n3 in Input
                        where n1 + n2 + n3 == 2020
                        select n1 * n2 * n3;

            return combo.First();
        }

    }

}
