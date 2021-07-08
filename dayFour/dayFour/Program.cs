using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace dayFour
{
    class Program
    {
        static void Main(string[] args)
        {
            var validPassports = File.ReadAllText(@"./input.txt")
                .Split("\r\n\r\n")
                .Where(
                    x => x.Contains("byr")
                    && x.Contains("iyr")
                    && x.Contains("eyr")
                    && x.Contains("hgt")
                    && x.Contains("hcl")
                    && x.Contains("ecl")
                    && x.Contains("pid"))
                .Select(x => x.Replace("\r\n", " ").Split(' ')).ToList(); ;

            Console.WriteLine(checkPassportCridentials(validPassports));
            Console.ReadLine();
        }

        public static int checkPassportCridentials(List<string[]> passportCridentials)
        {

            return passportCridentials.Where(x =>
                 int.TryParse(x.FirstOrDefault(x => x.Contains("byr")).Replace("byr:", ""), out int byr) && byr >= 1920 && byr <= 2002
                 && int.TryParse(x.FirstOrDefault(x => x.Contains("iyr")).Replace("iyr:", ""), out int iyr) && iyr >= 2010 && iyr <= 2020
                 && int.TryParse(x.FirstOrDefault(x => x.Contains("eyr")).Replace("eyr:", ""), out int eyr) && eyr >= 2020 && eyr <= 2030
                 && IsValidHight(x.FirstOrDefault(x => x.Contains("hgt")))
                 && IsValidHailColor(x.FirstOrDefault(x => x.Contains("hcl")))
                 && IsValidEyeColor(x.FirstOrDefault(x => x.Contains("ecl")))
                 && IsValidPassportId(x.FirstOrDefault(x => x.Contains("pid"))))
                .Count();
        }

        public static bool IsValidPassportId(string pid)
        {
            var value = pid.Split(':')[1];
            return value.Length == 9 && Regex.IsMatch(value, @"\A\b[0-9]+\b\Z");
        }

        public static bool IsValidEyeColor(string ecl)
        {
            var validColor = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            return validColor.Contains(ecl.Split(':')[1]);
        }

        public static bool IsValidHailColor(string hcl)
        {
            var value = hcl.Split(':')[1];
            return value.Length != 7 || value.First() != '#' || !Regex.IsMatch(value.Replace("#", ""), @"\A\b[0-9a-fA-F]+\b\Z")
                ? false
                : true;
        }

        public static bool IsValidHight(string hgt)
        {
            var value = hgt.Split(':')[1];

            if (value.Length < 4)
                return false;

            var heightType = value.Substring(value.Length - 2, 2);

            if (!int.TryParse(value.Replace(heightType, ""), out int hight))
                return false;

            if (heightType == "cm" && hight <= 193 && hight >= 150)
                return true;

            if (heightType == "in" && hight <= 76 && hight >= 59)
                return true;

            return false;
        }

    }
}

