using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            long wastedLitres = 0;

            while (bottles.Count>0 && cups.Count>0)
            {
                int currentCup = cups.Peek();
                int currentBottle = bottles.Pop();

                if (currentBottle>=currentCup)
                {
                    cups.Dequeue();
                    wastedLitres += (currentBottle - currentCup);
                }
                else if (currentBottle<currentCup)
                {
                    currentCup -= currentBottle;

                    while (currentCup>0 && bottles.Count>0)
                    {
                        currentBottle = bottles.Pop();
                        currentCup -= currentBottle;

                        if (currentCup<=0)
                        {
                            wastedLitres +=Math.Abs(currentCup);
                            cups.Dequeue();
                        }
                    }
                }
            }

            if (cups.Count<=0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedLitres}");
            }
            else if (bottles.Count<=0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedLitres}");
            }

        }
    }
}
