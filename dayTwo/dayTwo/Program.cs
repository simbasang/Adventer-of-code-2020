using System;
using System.Collections.Generic;
using System.IO;

namespace dayTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"D:\programmering\Adventer of code\dayTwo\dayTwo\input.txt");
            int counter = SecondHalf(input);
            Console.WriteLine(counter);
            Console.ReadLine();
        }

        private static int SecondHalf(IEnumerable<string> input)
        {
            int counter = 0;
            foreach (var item in input)
            {

                var times = item.Split(' ')[0];
                var firstIndex = int.Parse(times.Split('-')[0]) - 1;
                var secondIndex = int.Parse(times.Split('-')[1]) - 1;

                var theLetter = char.Parse(item.Split(' ')[1].Trim(':'));
                var password = item.Split(' ')[2];
                if ((password[firstIndex] == theLetter && password[secondIndex] != theLetter) || (password[firstIndex] != theLetter && password[secondIndex] == theLetter))
                {
                    counter++;
                }
            }

            return counter;
        }

        private static int FirstHalf(IEnumerable<string> input)
        {

            var counter = 0;
            foreach (var item in input)
            {
                var dic = new Dictionary<char, int>();
                var times = item.Split(' ')[0];
                var min = int.Parse(times.Split('-')[0]);
                var max = int.Parse(times.Split('-')[1]);

                var theLetter = char.Parse(item.Split(' ')[1].Trim(':'));
                var password = item.Split(' ')[2];
                foreach (var letter in password)
                {
                    if (!dic.ContainsKey(letter))
                    {
                        dic.Add(letter, 1);
                    }
                    else
                    {
                        dic[letter]++;
                    }
                }
                if (dic.ContainsKey(theLetter) && dic[theLetter] >= min && dic[theLetter] <= max)
                {

                    counter++;
                }

            }

            return counter;
        }
    }
}
