using System.Collections;
using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021, 3)]
    internal class Day3 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            return SolvePart1(Input);
        }

        public override object ExecutePart2()
        {
            return SolvePart2(Input);
        }

        public int SolvePart1(string[] input)
        {
            if (Input == null || Input.Length < 1)
            {
                return 0;
            }

            var sampleLength = input.Length;
            var lineLength = input[0].Length;
            var gamma = new BitArray(lineLength);
            var epsilon = new BitArray(lineLength);
            var sum = new decimal[lineLength];

            for (int i = 0; i < sampleLength; i++)
            {
                for (int j = 0; j < lineLength; j++)
                {
                    sum[j] += input[i][j] == '1' ? 1 : 0;
                    gamma[lineLength - 1 - j] = sum[j] / (i + 1) >= 0.5m ? true : false;
                    epsilon[lineLength - 1 - j] = !gamma[lineLength - 1 - j];
                }
            }

            var result = new int[2];
            gamma.CopyTo(result, 0);
            epsilon.CopyTo(result, 1);

            return result[0] * result[1];
        }

        public int SolvePart2(string[] input)
        {
            if (Input == null || Input.Length < 1)
            {
                return 0;
            }

            var lineLength = input[0].Length;

            var oxSamples = input;
            var co2Samples = input;
            var ox = 0;
            var co2 = 0;

            for (int j = 0; j < lineLength; j++)
            {
                oxSamples = FilterSamples(oxSamples, j, true);
                if (oxSamples.Length == 1)
                {
                    ox = Convert.ToInt32(oxSamples[0], 2);
                }

                co2Samples = FilterSamples(co2Samples, j, false);
                if (co2Samples.Length == 1)
                {
                    co2 = Convert.ToInt32(co2Samples[0], 2);
                }
            }

            return ox * co2;
        }

        private static string[] FilterSamples(string[] samples, int pos, bool mostCommon)
        {
            if (samples.Length > 1)
            {
                var mc = '0';
                decimal sum = 0;

                for (int i = 0; i < samples.Length; i++)
                {
                    sum += samples[i][pos] == '1' ? 1 : 0;
                    mc = sum / (i + 1) >= 0.5m ? '1' : '0';
                }

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
