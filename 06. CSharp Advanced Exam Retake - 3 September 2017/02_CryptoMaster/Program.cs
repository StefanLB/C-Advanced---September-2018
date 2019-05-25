using System;
using System.Linq;

namespace _02_CryptoMaster
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var highestSequence = 1;

            for (var step = 1; step < numbers.Length; step++)
            {
                for (var i = 0; i < numbers.Length; i++)
                {
                    var startingIndex = i;
                    var secondIndex = (i + step) % numbers.Length;
                    var currentSequence = 1;

                    while (numbers[secondIndex] > numbers[startingIndex])
                    {
                        currentSequence++;
                        startingIndex = secondIndex;
                        secondIndex = (startingIndex+step) % numbers.Length;
                    }
                    if (currentSequence > highestSequence)
                    {
                        highestSequence = currentSequence;
                    }
                }
            }
            Console.WriteLine(highestSequence);
        }
    }
}
