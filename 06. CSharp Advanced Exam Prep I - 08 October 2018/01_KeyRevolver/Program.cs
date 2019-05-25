using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] locksInput = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int intelligence = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>();
            Queue<int> locks = new Queue<int>();

            FillBullets(bulletsInput, bullets);
            FillLocks(locksInput, locks);

            int bulletsUsed = 0;

            while (true)
            {
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                CheckIfLockBreaks(currentBullet, currentLock, locks);

                bulletsUsed++;

                ReloadCheck(bulletsUsed, barrelSize, bullets);

                NoBulletsMoreLocksCheck(bullets, locks);
                NoLocksCheck(locks, intelligence, bulletsInput, bullets, bulletPrice);
            }
        }

        private static void NoLocksCheck(Queue<int> locks, int intelligence, int[] bulletsInput, Stack<int> bullets, int bulletPrice)
        {
            if (locks.Count == 0)
            {
                int moneyEarned = intelligence - (bulletsInput.Length - bullets.Count) * bulletPrice;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
                Environment.Exit(0);
            }
        }

        private static void NoBulletsMoreLocksCheck(Stack<int> bullets, Queue<int> locks)
        {
            if (bullets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                Environment.Exit(0);
            }
        }

        private static void ReloadCheck(int bulletsUsed, int barrelSize, Stack<int> bullets)
        {
            if (bulletsUsed % barrelSize == 0 && bullets.Count() > 0)
            {
                Console.WriteLine("Reloading!");
            }
        }

        private static void CheckIfLockBreaks(int currentBullet, int currentLock, Queue<int> locks)
        {
            if (currentBullet <= currentLock)
            {
                Console.WriteLine("Bang!");
                locks.Dequeue();
            }
            else
            {
                Console.WriteLine("Ping!");
            }
        }

        private static void FillLocks(int[] locksInput, Queue<int> locks)
        {
            for (int i = 0; i < locksInput.Length; i++)
            {
                locks.Enqueue(locksInput[i]);
            }
        }

        private static void FillBullets(int[] bulletsInput, Stack<int> bullets)
        {
            for (int i = 0; i < bulletsInput.Length; i++)
            {
                bullets.Push(bulletsInput[i]);
            }
        }
    }
}
