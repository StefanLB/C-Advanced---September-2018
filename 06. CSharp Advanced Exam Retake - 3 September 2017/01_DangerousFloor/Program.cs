using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] board = new string[8][];

            for (int i = 0; i < board.Length; i++)
            {
                string[] currentRow = Console.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                board[i] = currentRow;
            }

            string command = null;
            List<string> figures = new List<string>() { "K", "R", "B", "Q", "P" };

            while ((command = Console.ReadLine()) != "END")
            {
                string figure = command[0].ToString();
                int figureRow = int.Parse(command[1].ToString());
                int figureCol = int.Parse(command[2].ToString());
                int targetRow = int.Parse(command[4].ToString());
                int targetCol = int.Parse(command[5].ToString());

                //if (!figures.Contains(figure))
                //{
                //    Console.WriteLine("There is no such a piece!");
                //    continue;
                //}
                if (board[figureRow][figureCol]!=figure)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
                if (!MoveIsValid(figure,figureRow,figureCol,targetRow,targetCol))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }
                if (!ValidCoordinates(targetRow,targetCol))
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                board[figureRow][figureCol] = "x";
                board[targetRow][targetCol] = figure;
            }
        }

        static bool ValidCoordinates(int targetRow, int targetCol)
        {
            if (targetRow<0||targetRow>7||targetCol<0||targetCol>7)
            {
                return false;
            }
            return true;
        }

        static bool MoveIsValid(string figure, int figureRow, int figureCol, int targetRow, int targetCol)
        {
            switch (figure)
            {
                case "K":
                    if (Math.Abs(figureRow-targetRow)>1 || Math.Abs(figureCol-targetCol)>1)
                    {
                        return false;
                    }
                    break;
                case "R":
                    if (figureRow!=targetRow && figureCol!=targetCol)
                    {
                        return false;
                    }
                    break;
                case "B":
                    if (Math.Abs(figureRow-targetRow)!=Math.Abs(figureCol-targetCol))
                    {
                        return false;
                    }
                    break;
                case "Q":
                    if (figureRow != targetRow && figureCol != targetCol)
                    {
                        if (Math.Abs(figureRow - targetRow) != Math.Abs(figureCol - targetCol))
                        {
                            return false;
                        }
                    }
                    break;
                case "P":
                    if ((figureRow-1)!=targetRow)
                    {
                        return false;
                    }
                    break;
                default:
                    break;
            }

            return true;
        }
    }
}
