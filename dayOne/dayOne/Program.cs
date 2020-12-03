using System;
using System.Collections.Generic;
using System.IO;

namespace dayOne
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = File.ReadAllLines(@"D:\programmering\Ny mapp\adventureOfCode\adventureOfCode\input.txt");
            var parsedInput = new List<int>();
            var result = 0;
            foreach (var item in input)
            {
                parsedInput.Add(int.Parse(item));
            }
            foreach (var item in parsedInput)
            {
                foreach (var innerItem in parsedInput)
                {
                    foreach (var innerInnerItem in parsedInput)
                    {

                    if ((innerItem + item + innerInnerItem) == 2020)
                    {
                        result = item * (innerItem*innerInnerItem);
                    }
                    }
                }

            }

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
