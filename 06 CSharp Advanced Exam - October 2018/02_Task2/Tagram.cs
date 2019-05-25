using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Tagram
{
    class Tagram
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();

            while (input!="end")
            {
                if (input.Substring(0,3).ToString()=="ban")
                {
                    string userToBan = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];

                    if (users.ContainsKey(userToBan))
                    {
                        users.Remove(userToBan);
                    }
                }
                else
                {
                    string[] tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                    string currentUser = tokens[0];
                    string currentTag = tokens[1];
                    long currentLikes = long.Parse(tokens[2]);

                    if (!users.ContainsKey(currentUser))
                    {
                        users.Add(currentUser, new Dictionary<string, long>());
                    }

                    if (!users[currentUser].ContainsKey(currentTag))
                    {
                        users[currentUser].Add(currentTag, 0);
                    }

                    users[currentUser][currentTag] += currentLikes;
                }

                input = Console.ReadLine();
            }

            foreach (var user in users.OrderByDescending(x=>x.Value.Values.Sum()).ThenBy(x=>x.Value.Keys.Count))
            {
                Console.WriteLine(user.Key);

                foreach (var kvp in user.Value)
                {
                    Console.WriteLine($"- {kvp.Key}: {kvp.Value}");
                }
            }

            /*print the users, ordered by total likes in desecending order,
             * then ordered by the tags’ count in ascending order. Foreach player print their tag and likes.
             "{username}"
             "- {tag}: {likes}"
             */

        }
    }
}
