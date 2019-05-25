using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Regex pattern = new Regex(@"((?<start>#)|!)[^#!]*?(?<![\da-zA-Z])(?<street>[a-zA-Z]{4})(?![\da-zA-Z])[^#!]*(?<!\d)(?<number>\d{3})-(?<pass>\d{4}|\d{6})(?!\d)[^#!]*(?(start)!|#)");
                                      //((?<start>#)|!)[^#!]*?(?<![\da-zA-Z])(?<street>[a-zA-Z]{4})(?![\da-zA-Z])[^#!]*(?<!\d)(?<number>\d{3})-(?<pass>\d{4}|\d{6})(?!\d)[^#!]*?(?(start)!|#)
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                MatchCollection matches = pattern.Matches(line);
                var takeIndex = matches.Count / 2;
                Match match = matches[takeIndex];

                Console.WriteLine($"Go to str. {match.Groups["street"]} {match.Groups["number"]}. " +
                    $"Secret pass: {match.Groups["pass"]}.");
            }
        }
    }
}
