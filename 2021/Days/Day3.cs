using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021, 3)]
    internal class Day3 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            if (Input == null || Input.Length < 1)
            {
                return 0;
            }

            var gamma = "";
            var epsilon = "";

            for (int pos = 0; pos < Input[0].Length; pos++)
            {
                var mc = CalcMostCommon(Input, pos);
                gamma += mc;
                epsilon += mc == '0' ? '1' : '0';
            }

            return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
        }

        public override object ExecutePart2()
        {
            if (Input == null || Input.Length < 1)
            {
                return 0;
            }

            var oxSamples = Input;
            var co2Samples = Input;

            for (int pos = 0; pos < Input[0].Length; pos++)
            {
                oxSamples = FilterSamples(oxSamples, pos, true);
                co2Samples = FilterSamples(co2Samples, pos, false);
            }

            return Convert.ToInt32(oxSamples[0], 2) * Convert.ToInt32(co2Samples[0], 2);
        }

        private static char CalcMostCommon(string[] samples, int pos)
        {
            decimal sum = samples.Count(s => s[pos] == '1');
            return sum / samples.Length >= 0.5m ? '1' : '0';
        }

        private static string[] FilterSamples(string[] samples, int pos, bool mostCommon)
        {
            if (samples.Length > 1)
            {
                var mc = CalcMostCommon(samples, pos);

                if (mostCommon)
                {
                    samples = samples.Where(s => s[pos] == mc).ToArray();
                }
                else
                {
                    samples = samples.Where(s => s[pos] != mc).ToArray();
                }

            }
            return samples;
        }

    }
}
