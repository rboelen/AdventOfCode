using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021, 9)]
    internal class Day9 : Day.NewLineSplitParsed<string>
    {
        static int maxX;
        static int maxY;
        static int MAX_HEIGHT = 9;

        static int[] dx = { 0, 1, 0, -1 };
        static int[] dy = { 1, 0, -1, 0 };

        public override object ExecutePart1()
        {
            var sample = new string[] {
            "2199943210","3987894921","9856789892","8767896789","9899965678"
            };

           // Input = sample;

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

            // run trough all vertices
            int sum = 0;
            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
                {
                    var lowest = true;

                    for (int k = 0; k < 4; k++)
                    {
                        int ny = i + dy[k];
                        int nx = j + dx[k];
                        if (ny >= 0 && ny < H.GetLength(0) && nx >= 0 && nx < H.GetLength(1))
                        {
                            if(H[i,j] >= H[ny, nx])
                            {
                                lowest = false;
                            }
                        }
                    }
                    if (lowest)
                    {
                        sum += 1 + H[i, j];
                    }
                }
            }
      
            return sum;
        }

        public override object ExecutePart2()
        {
            var sample = new string[] {
            "2199943210","3987894921","9856789892","8767896789","9899965678"
            };

           // Input = sample;

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

            // run trough all vertices
            List<int> basins = new List<int>();

            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
                {
                    var lowest = true;

                    for (int k = 0; k < 4; k++)
                    {
                        int ny = i + dy[k];
                        int nx = j + dx[k];
                        if (ny >= 0 && ny < H.GetLength(0) && nx >= 0 && nx < H.GetLength(1))
                        {
                            if (H[i, j] >= H[ny, nx])
                            {
                                lowest = false;
                            }
                        }
                    }
                    if (lowest)
                    {
                        basins.Add(GetFlow(H, (i, j), new List<(int, int)>()));
                    }
                }
            }

            var r = basins.OrderByDescending(x => x).Take(3).Aggregate((a, b) => a * b);
            return r;
        }

        private int GetFlow(int[,] H, (int , int ) v, List<(int, int)> visited)
        {
            int flow = 0;

            if(visited.Any(x => x == v))
            {
                return flow;
            }

            visited.Add(v);
            if (H[v.Item1, v.Item2] < MAX_HEIGHT)
            {
                flow++;
            }
            for (int k = 0; k < 4; k++)
            {
                int ny = v.Item1 + dy[k];
                int nx = v.Item2 + dx[k];
                if (ny >= 0 && ny < H.GetLength(0) && nx >= 0 && nx < H.GetLength(1))
                {
                    if (H[ny, nx] > H[v.Item1, v.Item2] && H[ny, nx] < MAX_HEIGHT)
                    {
                        flow += GetFlow(H, (ny, nx), visited);
                    }
                }
            }
            return flow;
        }

    }
}

