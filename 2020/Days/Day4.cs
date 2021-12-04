using System.Text.RegularExpressions;
using Tidy.AdventOfCode;

namespace Days
{
    [Day(2020,4)]
    internal class Day4 : Day.NewLineSplitParsed<string>
    {
        public override object ExecutePart1()
        {
            var fields = new[] { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };
  
            var count = 0;
            string report = "";
            foreach(var line in Input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    count += fields.All(f => report.Contains(f)) ? 1 : 0;
                    report = "";
                }
                report += " " + line;
                
            }
            return count;
        }

        public override object ExecutePart2()
        {
            var fields = new[] { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };
       
            var count = 0;
            string report = "";
            foreach (var line in Input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if(fields.All(f => report.Contains(f))){
                        var parts = report.Trim().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                        var valid = true;
                        foreach (var part in parts)
                        {
                            var field = part.Split(":");
                         
                            switch (field[0])
                            {
                                case "byr":
                                    if (Convert.ToInt32(field[1]) < 1920 || Convert.ToInt32(field[1]) > 2002){
                                        valid = false;
                                    }
                                    break;
                                case "iyr":
                                    if (Convert.ToInt32(field[1]) < 2010 || Convert.ToInt32(field[1]) > 2020)
                                    {
                                        valid = false;
                                    }
                                    break;
                                case "eyr":
                                    if (Convert.ToInt32(field[1]) < 2020 || Convert.ToInt32(field[1]) > 2030)
                                    {
                                        valid = false;
                                    }
                                    break;
                                case "hgt":
                                    if (!field[1].EndsWith("cm") && !field[1].EndsWith("in"))
                                    {
                                        valid = false;
                                    }
                                    else
                                    {
                                        if (field[1].EndsWith("cm"))
                                        {
                                            field[1] = field[1].Replace("cm", "");
                                            if (Convert.ToInt32(field[1]) < 150 || Convert.ToInt32(field[1]) > 193)
                                            {
                                                valid = false;
                                            }
                                        }
                                        else if (field[1].EndsWith("in"))
                                        {
                                            field[1] = field[1].Replace("in", "");
                                            if (Convert.ToInt32(field[1]) < 59 || Convert.ToInt32(field[1]) > 76)
                                            {
                                                valid = false;
                                            }
                                        }
                                    }

                                     break;
                                case "hcl":
                                    var rghcl = new Regex("^.{0}[#]s*[0-9a-f]{6}");
                                    if (!rghcl.IsMatch(field[1]))
                                    {
                                        valid = false;
                                    }
                                    break;
                                case "ecl":
                                    var rgecl = new Regex("^amb|blu|brn|gry|grn|hzl|oth");
                                    if (!rgecl.IsMatch(field[1]))
                                    {
                                        valid = false;
                                    }
                                    break;
                                case "pid":
                                    var rgpid = new Regex(@"\b\d{9}\b");
                                    if (!rgpid.IsMatch(field[1]))
                                    {
                                        valid = false;
                                    }
                                    break;
                            }
                        }
                        if (valid)
                        {
                            count += 1;
                        }
                    }
                    report = "";
                }
                report += " " + line;

            }
            return count;
        }


    }

}
