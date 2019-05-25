using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03_GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            long bagSize = long.Parse(Console.ReadLine());
            string itemQuantityPairs = Console.ReadLine();

            Regex regex = new Regex(@"Gold[\s]+?[0-9]+|\S+?[gG][eE][mM][\s]+?[0-9]+|\S{3}[\s]+?[0-9]+");
            MatchCollection matches = regex.Matches(itemQuantityPairs);

            var bagContents = new Dictionary<string, Dictionary<string, long>>();
            bagContents.Add("Gold", new Dictionary<string, long> ());
            bagContents.Add("Gem", new Dictionary<string, long>());
            bagContents.Add("Cash", new Dictionary<string, long>());

            long currentInBag = 0L;

            foreach (var match in matches)
            {
                string[] tokens = match.ToString().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);
                string item = tokens[0];
                long amount = long.Parse(tokens[1]);

                if ((currentInBag+amount)>bagSize)
                {
                    continue;
                }

                if (item.ToLower()=="gold")
                {
                    if (bagContents["Gold"].ContainsKey(item))
                    {
                        bagContents["Gold"][item] += amount;
                    }
                    else
                    {
                        bagContents["Gold"].Add(item, amount);
                    }
                    currentInBag += amount;
                }
                else if (item.Length==3)
                {
                    long cashAmount = bagContents["Cash"].Values.Sum();
                    long gemAmount = bagContents["Gem"].Values.Sum();

                    if ((cashAmount+amount)<=gemAmount)
                    {
                        if (bagContents["Cash"].ContainsKey(item))
                        {
                            bagContents["Cash"][item] += amount;
                        }
                        else
                        {
                            bagContents["Cash"].Add(item, amount);
                        }
                        currentInBag += amount;
                    }
                }
                else if (item.ToLower().EndsWith("gem"))
                {
                    long gemAmount = bagContents["Gem"].Values.Sum();
                    long goldAmount = bagContents["Gold"].Values.Sum();

                    if ((gemAmount+amount)<=goldAmount)
                    {
                        if (bagContents["Gem"].ContainsKey(item))
                        {
                            bagContents["Gem"][item] += amount;
                        }
                        else
                        {
                            bagContents["Gem"].Add(item, amount);
                        }
                        currentInBag += amount;
                    }
                }
            }

            bagContents = bagContents.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, y => y.Value);

            foreach (var type in bagContents)
            {
                if (type.Value.Keys.Count>0)
                {
                    string typeName = type.Key;
                    long typeSum = type.Value.Values.Sum();
                    Console.WriteLine($"<{typeName}> ${typeSum}");

                    Dictionary<string, long> orderedType = type.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

                    foreach (var itemValuePair in orderedType)
                    {
                        Console.WriteLine($"##{itemValuePair.Key} - {itemValuePair.Value}");
                    }
                }
            }
        }
    }
}
