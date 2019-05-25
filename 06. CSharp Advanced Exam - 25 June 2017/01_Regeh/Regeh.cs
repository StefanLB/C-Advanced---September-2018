using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01_Regeh
{
    class Regeh
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex pattern = new Regex(@"\[[A-Z&a-z]+<(?<nums1>[0-9]+)REGEH(?<nums2>[0-9]+)>[A-Z&a-z]+\]");

            int totalIndex = 0;

            MatchCollection matches = pattern.Matches(input);

            string output = null;

            foreach (Match match in matches)
            {
                totalIndex += int.Parse(match.Groups["nums1"].ToString());
                int charPosition = totalIndex % (input.Length);
                output += input[charPosition];

                totalIndex += int.Parse(match.Groups["nums2"].ToString());
                charPosition = totalIndex % (input.Length);
                output += input[charPosition];

            }

            Console.WriteLine(output);
        }
    }
}
