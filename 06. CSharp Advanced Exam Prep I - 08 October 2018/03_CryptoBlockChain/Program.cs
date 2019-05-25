using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03_CryptoBlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            string entireBlockChain = "";

            for (int i = 0; i < lines; i++)
            {
                entireBlockChain += Console.ReadLine();
            }

            Regex regex = new Regex(@"{[^\[\]{0-9]*([0-9]*)[^\[\]{0-9]*}|\[[^\[}{0-9]*([0-9]*)[^\[}{0-9]*\]");
            MatchCollection matches = regex.Matches(entireBlockChain);

            List<string> stringNumMatches = new List<string>();
            List<int> cryptoBlockLength = new List<int>();

            foreach (Match match in matches)
            {
                if (match.Groups[1].Value != "" && match.Groups[1].Length % 3 == 0)
                {
                    stringNumMatches.Add(match.Groups[1].Value);
                    cryptoBlockLength.Add(match.Length);
                }
                if (match.Groups[2].Value != "" && match.Groups[2].Length % 3 == 0)
                {
                    stringNumMatches.Add(match.Groups[2].Value);
                    cryptoBlockLength.Add(match.Length);
                }
            }
            List<char> decryptedResult = new List<char>();

            for (int i = 0; i < stringNumMatches.Count; i++)
            {
                for (int j = 0; j < stringNumMatches[i].Length / 3; j++)
                {
                    int numBy3 = j * 3;
                    decryptedResult.Add((char)((int.Parse(stringNumMatches[i].Substring(numBy3, 3)) - cryptoBlockLength[i])));
                }
            }
            Console.WriteLine(string.Join("",decryptedResult));
        }
    }
}
