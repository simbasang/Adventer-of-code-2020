using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dayFive
{
    class Program
    {
        static void Main(string[] args)
        {
            var passports = File.ReadAllText(@"./input.txt").Split("\r\n").ToList();
            var highestNumbre = 0;
            //foreach (var passport in passports)
            //{
            //    var temp = Search(passport);
            //    highestNumbre = temp > highestNumbre
            //          ? temp
            //          : highestNumbre;
            //}
            Console.WriteLine(Search("BBFFBBFRLL"));
            Console.ReadLine();
        }

        public static int Search(string bordingPass)
        {
            var columnInput = bordingPass.Substring(bordingPass.Length - 3);
            var rowInput = bordingPass.Replace(columnInput, "");
            var row = GetRow(127, rowInput);
            var column = GetRow(7, columnInput);
            return row * 8 + column;
        }


       //denna funkar inte på en lista som är jämn
        public static int GetRow(int max, string input)
        {
            var min = 0;
            var mid = 0;
            foreach (var ch in input)
            {
                mid = (min + max) / 2;

                if (ch == 'F' || ch == 'L')
                    max = mid - 1;

                if (ch == 'B' || ch == 'R')
                    min = mid + 1;
            }
            return mid;//(int)Math.Round(mid, MidpointRounding.AwayFromZero);
        }

        public static int DoWork(List<string> input)
        {
            int highestNumber = 0;
            var result = 0;
            foreach (var item in input)
            {
                var row = 127;
                var column = 7;
                foreach (var ch in item)
                {
                    var mid = row / 2;
                    if (ch == 'F')
                    {
                        //lower

                    }
                    if (ch == 'B')
                    {
                        //higher
                    }

                }

                if (result > highestNumber)
                    highestNumber = result;
            }

            return highestNumber;
        }


    }
}
