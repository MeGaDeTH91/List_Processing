using System;
using System.Collections.Generic;
using System.Linq;

namespace ListProcess
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] initial = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            Console.WriteLine($"{string.Join(" ", initial)}");
        }
    }
}
