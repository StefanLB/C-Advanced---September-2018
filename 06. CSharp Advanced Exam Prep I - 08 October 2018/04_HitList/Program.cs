using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());

            var peopleIndex = new Dictionary<string, SortedDictionary<string, string>>();

            string currentInput = Console.ReadLine();

            while (currentInput != "end transmissions")
            {
                string personName = currentInput.Split(new string[] { "=" }, StringSplitOptions.None).ToArray()[0];
                string dataToken = currentInput.Split(new string[] { "=" }, StringSplitOptions.None).ToArray()[1];
                string[] personData = dataToken.Split(new string[] { ";" }, StringSplitOptions.None);

                if (!peopleIndex.ContainsKey(personName))
                {
                    peopleIndex.Add(personName, new SortedDictionary<string, string>());
                }

                for (int i = 0; i < personData.Length; i++)
                {
                    string subject = personData[i].Split(new string[] { ":" }, StringSplitOptions.None).ToArray()[0];
                    string details = personData[i].Split(new string[] { ":" }, StringSplitOptions.None).ToArray()[1];

                    if (!peopleIndex[personName].ContainsKey(subject))
                    {
                        peopleIndex[personName].Add(subject, details);
                    }
                    else if (peopleIndex[personName].ContainsKey(subject))
                    {
                        peopleIndex[personName][subject] = details;
                    }
                }
                currentInput = Console.ReadLine();
            }

            string killTarget = Console.ReadLine().Substring(5);

            Console.WriteLine($"Info on {killTarget}:");

            foreach (var entry in peopleIndex[killTarget])
            {
                Console.WriteLine($"---{entry.Key}: {entry.Value}");
            }

            int infoIndex = peopleIndex[killTarget].Sum(x => x.Key.Length) + peopleIndex[killTarget].Sum(x => x.Value.Length);

            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex>=targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex-infoIndex} more info.");
            }
        }
    }
}
