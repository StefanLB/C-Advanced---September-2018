using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int roomRows = int.Parse(Console.ReadLine());
            char[][] room = new char[roomRows][];
            int samRow = 0;
            int samCol = 0;

            FillRoomAndFindSam(roomRows, room, ref samRow, ref samCol);

            char[] moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                EnemiesMove(room);
                CheckIfSamDies(room, samRow, samCol);

                SamMoves(moves[i], room, ref samRow, ref samCol);
                CheckIfNikoladzeDies(room, samRow, samCol);
            }
        }

        private static void CheckIfNikoladzeDies(char[][] room, int samRow, int samCol)
        {
            if (Array.IndexOf(room[samRow], 'N') != -1)
            {
                int nikoladzeCol = Array.IndexOf(room[samRow], 'N');
                Console.WriteLine("Nikoladze killed!");
                room[samRow][nikoladzeCol] = 'X';
                PrintRoom(room);
                Environment.Exit(0);
            }
        }

        private static void SamMoves(char currentMove, char[][] room, ref int samRow, ref int samCol)
        {
            switch (currentMove)
            {
                case 'U': room[samRow][samCol] = '.'; samRow--; break;
                case 'D': room[samRow][samCol] = '.'; samRow++; break;
                case 'L': room[samRow][samCol] = '.'; samCol--; break;
                case 'R': room[samRow][samCol] = '.'; samCol++; break;
                default: break;
            }
            room[samRow][samCol] = 'S';
        }

        private static void CheckIfSamDies(char[][] room, int samRow, int samCol)
        {
            if ((Array.IndexOf(room[samRow], 'b') != -1 && Array.IndexOf(room[samRow], 'b') < samCol) ||
                (Array.IndexOf(room[samRow], 'd') != -1 && Array.IndexOf(room[samRow], 'd') > samCol))
            {
                room[samRow][samCol] = 'X';
                Console.WriteLine($"Sam died at {samRow}, {samCol}");
                PrintRoom(room);
                Environment.Exit(0);
            }
        }

        private static void EnemiesMove(char[][] room)
        {
            for (int j = 0; j < room.Length; j++)
            {
                if (Array.IndexOf(room[j], 'b') != -1)
                {
                    int indexOfB = Array.IndexOf(room[j], 'b');

                    if (indexOfB == room[j].Length - 1)
                    {
                        room[j][indexOfB] = 'd';
                    }
                    else
                    {
                        room[j][indexOfB] = '.';
                        room[j][indexOfB + 1] = 'b';
                    }
                }
                else if (Array.IndexOf(room[j], 'd') != -1)
                {
                    int indexOfD = Array.IndexOf(room[j], 'd');

                    if (indexOfD == 0)
                    {
                        room[j][indexOfD] = 'b';
                    }
                    else
                    {
                        room[j][indexOfD] = '.';
                        room[j][indexOfD - 1] = 'd';
                    }
                }
            }
        }

        private static void FillRoomAndFindSam(int roomRows, char[][] room, ref int samRow, ref int samCol)
        {
            for (int i = 0; i < roomRows; i++)
            {
                room[i] = Console.ReadLine().ToCharArray();

                if (Array.IndexOf(room[i], 'S') != -1)
                {
                    samRow = i;
                    samCol = Array.IndexOf(room[i], 'S');
                }
            }
        }

        private static void PrintRoom(char[][] room)
        {
            for (int i = 0; i < room.Length; i++)
            {
                Console.WriteLine(string.Join("", room[i]));
            }
        }
    }
}
