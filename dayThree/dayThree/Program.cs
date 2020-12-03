using System;
using System.IO;

namespace dayThree
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@".\input.txt");
            long first = TreeCounter(input,1,1);
            long second = TreeCounter(input,3,1);
            long therd = TreeCounter(input,5,1);
            long fourth = TreeCounter(input,7,1);
            long fift  = TreeCounter(input,1, 2);
            
            Console.WriteLine(first * fift * second*therd*fourth);
            Console.ReadLine();
        }

        private static int TreeCounter(string[] test, int right, int down)
        {
            var indexCounter = 0;
            var count = 0;
            for (int i = 0; i < test.Length; i += down)
            {
                if (indexCounter >= test[i].Length)
                {
                    indexCounter = indexCounter % test[i].Length;
                }
                if (i == 0)
                {
                    indexCounter += right;
                }
                else
                {
                    if (test[i][indexCounter] == '#')
                    {
                        count++;
                    }
                    indexCounter += right;
                }
            }

            return count;
        }
    }
}
