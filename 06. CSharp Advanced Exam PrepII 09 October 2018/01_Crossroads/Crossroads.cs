using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Crossroads
{
    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;

            while (command!="END")
            {
                if (command!="green")
                {
                    cars.Enqueue(command); // adding the current car to the line
                }
                else
                {
                    if (cars.Count>0)
                    {
                        int currentGreenLight = greenLightDuration;
                        string currentCar = "";

                        while (cars.Count>0 && currentGreenLight>0) // cars start to pass
                        {
                            currentCar = cars.Dequeue();
                            carsPassed++;
                            currentGreenLight -= currentCar.Length;
                        }

                        if (currentGreenLight<0 && ((currentGreenLight*-1)>freeWindowDuration)) //when green light is over and there isnt enough time for the car to pass
                        {
                            Console.WriteLine("A crash happened!");
                            char hitAt = currentCar[currentCar.Length - ((currentGreenLight * -1) - freeWindowDuration)];
                            Console.WriteLine($"{currentCar} was hit at {hitAt}.");
                            return;
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
