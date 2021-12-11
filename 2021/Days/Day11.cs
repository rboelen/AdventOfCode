using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021, 11)]
    internal class Day11 : Day.NewLineSplitParsed<string>
    {
       
        static int maxY;
        static int maxX;

        static (int, int)[] d = { (-1,-1), (-1,0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };
        static int flashCount = 0;

        public override object ExecutePart1()
        {

            var sample = new string[] {
"5483143223",
"2745854711",
"5264556173",
"6141336146",
"6357385478",
"4167524645",
"2176841721",
"6882881134",
"4846848554",
"5283751526"
            };
            //Input = sample;

            flashCount = 0;
            maxY = Input.Length;
            maxX = Input[0].Length;

            // read map
            int[,] H = new int[maxY, maxX];

            for (int i = 0; i < Input.Length; i++)
            {
                var row = Input[i].Select(c => Convert.ToInt32(c.ToString())).ToArray();
                for (int j = 0; j < row.Length; j++)
                {
                    H[i, j] = row[j];
                }
            }

            var steps = 100;
            for (int s = 0; s < steps; s++)
            {
                // step 1
                for (int i = 0; i < maxY; i++)
                {
                    for (int j = 0; j < maxX; j++)
                    {
                        H[i, j] += 1;
                    }
                }

                // step 2
                for (int i = 0; i < maxY; i++)
                {
                    for (int j = 0; j < maxX; j++)
                    {
                        if (H[i, j] > 9)
                        {
                            Flash(H, (i, j));
                        }
                    }
                }

                // step 3
                for (int i = 0; i < maxY; i++)
                {
                    for (int j = 0; j < maxX; j++)
                    {
                        if (H[i, j] == 0)
                        {
                            flashCount++;
                        }
                    }
                }
            }

            return flashCount;

        }

        public override object ExecutePart2()
        {
            flashCount = 0;
            maxY = Input.Length;
            maxX = Input[0].Length;

            // read map
            int[,] H = new int[maxY, maxX];

            for (int i = 0; i < Input.Length; i++)
            {
                var row = Input[i].Select(c => Convert.ToInt32(c.ToString())).ToArray();
                for (int j = 0; j < row.Length; j++)
                {
                    H[i, j] = row[j];
                }
            }

            var s = 0;
            bool sync = false;
            while(!sync)
            {
                s++;
                // step 1
                for (int i = 0; i < maxY; i++)
                {
                    for (int j = 0; j < maxX; j++)
                    {
                        H[i, j] += 1;
                    }
                }

                // step 2
                for (int i = 0; i < maxY; i++)
                {
                    for (int j = 0; j < maxX; j++)
                    {
                        if (H[i, j] > 9)
                        {
                            Flash(H, (i, j));
                        }
                    }
                }

                // step 3
                sync = true;
                for (int i = 0; i < maxY; i++)
                {
                    for (int j = 0; j < maxX; j++)
                    {
                        if (H[i, j] != 0)
                        {
                            sync = false;
                        }
                    }
                }
            }

            return s;
        }

        private static void Flash(int[,] H, (int, int) v)
        {
            H[v.Item1, v.Item2] = 0;

            for (int i = 0; i < 8; i++)
            {
                int ny = v.Item1 + d[i].Item1;
                int nx = v.Item2 + d[i].Item2;
                if (ny >= 0 && ny < maxY && nx >= 0 && nx < maxX)
                {
                    if (H[ny, nx] > 0 && H[ny, nx] < 10)
                    {
                        H[ny, nx] += 1;
                        if (H[ny, nx] > 9)
                        {
                            Flash(H, (ny, nx));
                        }
                    }

                }
            }
        }
    }
}

