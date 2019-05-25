using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Task3
{
    class Miner
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string moveCommands = Console.ReadLine();
            long collectedCoal = 0;
            long totalCoal = 0; // da se napulni pri pulnene na matricata

            string[][] field = new string[fieldSize][];

            int row = 0;
            int col = 0;
            int exitRow = 0;
            int exitCol = 0;

            for (int i = 0; i < fieldSize; i++)
            {
                string fieldLineString = Console.ReadLine();
                string[] fieldLine = fieldLineString.Split();
                field[i] = fieldLine;

                if (field[i].Contains("s"))
                {
                    row = i;
                    col = Array.IndexOf(field[i], "s");
                }
                if (field[i].Contains("e"))
                {
                    exitRow = i;
                    exitCol = Array.IndexOf(field[i], "e");
                }

                totalCoal += fieldLineString.Split('c').Length - 1;
            }

            string[] commands = moveCommands.Split();

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];
                int moveRows = 0;
                int moveCols = 0;

                CheckMovement(currentCommand, ref moveRows, ref moveCols);

                bool movementPossible = true;
                CheckMovementPossibility(row, col, moveRows, moveCols, fieldSize, ref movementPossible);

                if (movementPossible)
                {
                    MoveMiner(ref row, ref col, moveRows, moveCols, field, ref collectedCoal, totalCoal);
                }
            }

            long coalsLeft = totalCoal - collectedCoal;
            Console.WriteLine($"{coalsLeft} coals left. ({row}, {col})");
        }

        private static void MoveMiner(ref int row, ref int col, int moveRows, int moveCols, string[][] field, ref long collectedCoal, long totalCoal)
        {
            //the movement wont be out of boundry
            field[row][col] = "*";
            row = row + moveRows;
            col = col + moveCols;

            if (field[row][col]=="*")
            {
                field[row][col] = "s";
                return;
            }
            else if(field[row][col]=="c")
            {
                collectedCoal++;
                if (collectedCoal==totalCoal)
                {
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    Environment.Exit(0);
                }
            }
            else if (field[row][col] == "e")
            {
                Console.WriteLine($"Game over! ({row}, {col})");
                Environment.Exit(0);
            }
        }

        static void CheckMovementPossibility(int row, int col, int moveRows, int moveCols, int fieldSize, ref bool movementPossible)
        {
            if (row+moveRows<0 || row + moveRows >=fieldSize)
            {
                movementPossible = false;
                return;
            }
            else if ((col + moveCols < 0 || col + moveCols>= fieldSize))
            {
                movementPossible = false;
                return;
            }
        }

        static void CheckMovement(string currentCommand, ref int moveRows, ref int moveCols)
        {
            switch (currentCommand)
            {
                case "up":
                    moveRows = -1;
                    break;
                case "down":
                    moveRows = 1;
                    break;
                case "left":
                    moveCols = -1;
                    break;
                case "right":
                    moveCols = 1;
                    break;
                default:
                    break;
            }
        }
    }
}
