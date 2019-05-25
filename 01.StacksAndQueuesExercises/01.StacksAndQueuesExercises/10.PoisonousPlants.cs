using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StacksAndQueuesExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPlants = int.Parse(Console.ReadLine());

            Queue<int[]> plants = new Queue<int[]>();

            int[] pesticidePerPlant = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < pesticidePerPlant.Length; i++)
            {
                int[] currentPlantInfo = new int[2];
                currentPlantInfo[0] = i;
                currentPlantInfo[1] = pesticidePerPlant[i];

                plants.Enqueue(currentPlantInfo);
            }

            int deadPlantsCounter = 1;
            int daysAfterNoPlantsDie = 0;

            while (deadPlantsCounter>0)
            {
                deadPlantsCounter = 0;
                int startingPlants = plants.Count();
                bool toKeepFirstPlantInQueue = true;

                for (int i = 0; i < startingPlants-1; i++)
                {
                    int[] leftPlant = plants.Dequeue();
                    int[] rightPlant = plants.Peek();

                    if (toKeepFirstPlantInQueue)
                    {
                        plants.Enqueue(leftPlant);
                    }

                    toKeepFirstPlantInQueue = true;

                    if (rightPlant[1] > leftPlant[1])
                    {
                        deadPlantsCounter++;
                        toKeepFirstPlantInQueue = false;
                    }

                }

                if (toKeepFirstPlantInQueue)
                {
                    plants.Enqueue(plants.Dequeue());
                }
                else
                {
                    plants.Dequeue();
                }

                if (deadPlantsCounter > 0)
                {
                    daysAfterNoPlantsDie++;
                }
            }

            Console.WriteLine(daysAfterNoPlantsDie);
        }
    }
}
