using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03_TicketTrouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string input = Console.ReadLine();

            Regex regex = new Regex(@"{[^{\]}]*?\[([A-Z]{3}\s[A-Z]{2})\][^{\]}]*?\[([A-Z][0-9]{1,2})\][^\[{\]]*?}|\[[^\[\]}]*?{([A-Z]{3}\s[A-Z]{2})}[^\[\]}]*?{([A-Z][0-9]{1,2})}[^\[{}]*?\]");
            MatchCollection matches = regex.Matches(input);

            List<string> ticketNumbers = new List<string>();

            foreach (Match match in matches)
            {
                if (match.Groups[1].Value!="")
                {
                    if (match.Groups[1].Value == destination) // check if destination is correct
                    {
                        ticketNumbers.Add(match.Groups[2].Value); // add the ticket number to the list
                    }
                }
                else
                {
                    if (match.Groups[3].Value == destination) // check if destination is correct
                    {
                        ticketNumbers.Add(match.Groups[4].Value); // add the ticket number to the list
                    }
                }
            }

            if (ticketNumbers.Count==2)
            {
                Console.WriteLine($"You are traveling to {destination} on seats {ticketNumbers[0]} and {ticketNumbers[1]}.");
            }
            else
            {
                for (int i = 0; i < ticketNumbers.Count; i++)
                {
                    for (int j = i+1; j < ticketNumbers.Count; j++)
                    {
                        if (ticketNumbers[i].Substring(1) == ticketNumbers[j].Substring(1)) // check if the row is the same, seats a/b/c/d/etc. are irrelevant
                        {
                            Console.WriteLine($"You are traveling to {destination} on seats {ticketNumbers[i]} and {ticketNumbers[j]}.");
                            return;
                        }
                    }
                }
            }

            /* TESTS WHICH MADE IT NECESSARY TO MODIFY THE REGEX
             * POT AT
dsgbvcmv,[123aadsd{POT AT}Oasdasdadwgd{D12}zxcwqc}12dzsdaads2[sd23rf{POT AT}O|ghv,/jkm,.n{A18}mbn,bxcvxcuhyj ergd]asdwreragfRS[werg3 54safdatz {POT AT}O|C 3ZSR VG{F12}dg 4a 34 zgdsgf]g45agdqadsggdhndnafspotato?h45sv9tA uv
             POT AT
dsgbvcmv,[123aadsd{POT AT}Oasdasdadwgd{D481}zxcwqc]12dzsdaads2[asd23rf{POT AT}O|ghv,/jkm,.n{F35}mbn,bxcvxcuhyj ergd]asdwreragfRS[werg3 54safdatz {POT AT}O|C 3ZSR VG{A1}dg 4a 34 zgdsgf]g45agdqad
             */
        }
    }
}
