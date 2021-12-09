using Tidy.AdventOfCode;

namespace Days
{
    [Day(2021, 8)]
    internal class Day8 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            return Solve();
        }

        public override object ExecutePart2()
        {
            return Solve2();
        }

        private int Solve()
        {
            var search = new[] { 2, 4, 3, 7 };
            var output = Input.Select(x => x.Split(" | ").ElementAt(1).Split(" ")).ToList();

            var sum = output.Sum(x => x.Count(x => search.Contains(x.Length)));

            return sum;
            
        }


        private int Solve2()
        {
            var search = new[] { 2, 4, 3, 7 };
         //   var samples = new[] { "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf" };
            var lines = Input.Select(x => {
                var p = x.Split(" | ");
                return new
                {
                    Original = x,
                    Input = p[0].Split(" ").ToList(),
                    Decoded = new string[10],
                    Output = p[1].Split(" ").ToArray(),
                    Value = 0
                };
            }).ToList();

            int sum = 0;
            foreach(var line in lines)
            {

                for (int i = 0; i < line.Input.Count(); i++)
                {
                    var l = line.Input[i].Length;
                    switch (l)
                    {
                        case 2:
                            line.Decoded[1] = line.Input[i];
                            break;
                        case 3:
                            line.Decoded[7] = line.Input[i];
                            break;
                        case 4:
                            line.Decoded[4] = line.Input[i];
                            break;
                        case 7:
                            line.Decoded[8] = line.Input[i];
                            break;
                    }
                }

                for (int i = 0; i < line.Input.Count(); i++)
                {
                    var l = line.Input[i].Length;
                    switch (l)
                    {
                        case 6:
                            // can be 0, 6 or 9 
                            var diff2 = line.Input[i].Except(line.Decoded[1]).Count();
                            if (diff2 == 5)
                            {
                                line.Decoded[6] = line.Input[i];
                            }
                            else {
                                if (line.Decoded[4].All(c => line.Input[i].Contains(c)))
                                {
                                    line.Decoded[9] = line.Input[i];
                                }
                                else
                                {
                                    line.Decoded[0] = line.Input[i];
                                }
                            }
                            break;
                    }
                }
                for (int i = 0; i < line.Input.Count(); i++)
                {
                    var l = line.Input[i].Length;
                    switch (l)
                    {
                        case 5:
                            // can be 2 or 3, 5 
                            //if len(set(d).difference(mapn.get(4))) == 3:
                            //    mapn.update({ 2: set(d) })  #! 2
                            //else:
                            //    if set(d).issuperset(mapn.get(1)):
                            //        mapn.update({ 3: set(d) })  #! 3
                            //    else: 
                            //        mapn.update({ 5: set(d) }) #! 5
                            var diff1 = line.Input[i].Except(line.Decoded[4]).Count();
                            if (diff1 == 3)
                            {
                                line.Decoded[2] = line.Input[i];
                            }
                            else
                            {
                                if (line.Decoded[1].All(c => line.Input[i].Contains(c)))
                                {
                                    line.Decoded[3] = line.Input[i];
                                }
                                else
                                {
                                    line.Decoded[5] = line.Input[i];
                                }
                            }
                            break;
                    }
                }

                sum += Convert.ToInt32(string.Join("", line.Output.Select(x => Find(line.Decoded.ToList(), x)).ToList()));
               // var add = Convert.ToInt32(string.Join("", line.Output.Select(x => line.Decoded[Find(line.Input,x)].ToString())));
               // sum += add;
               
            }

            return sum;

        }

        int Find(List<string> input, string output)
        {
            var s = new String(output.ToArray());
            var r = input.FindIndex(x => x.Length == output.Length && output.All(c => x.Contains(c)));
            return r;
        }
    }
}

