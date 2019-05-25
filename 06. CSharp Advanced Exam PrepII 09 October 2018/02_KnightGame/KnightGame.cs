using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());

            char[][] board = new char[boardSize][];

            for (int i = 0; i < board.Length; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();
            }

            int biggestConflict = 0;
            int row = 0;
            int col = 0;
            bool anyConflicts = true;
            int knightsRemoved = 0;

            while (anyConflicts)
            {
                for (int i = 0; i < board.Length; i++)
                {
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        int currentConflict = 0;

                        if (board[i][j] == 'K')
                        {
                            ConflictCheck(i, j, board, ref currentConflict); //find all possible conflicts for this knight
                        }
                        if (currentConflict>biggestConflict) // check if currentconflict > biggestConflict; if so, change row and col to the current knight
                        {
                            row = i;
                            col = j;
                            biggestConflict = currentConflict;
                        }
                    }
                }

                if (biggestConflict>0) //check if biggest conflict>0 -> if != 0 -> remove knight with most conflicts, ELSE anyConflicts = 0
                {
                    board[row][col] = '0';
                    knightsRemoved++;
                    biggestConflict = 0;
                }
                else
                {
                    anyConflicts = false;
                }
            }
            Console.WriteLine(knightsRemoved);
        }

        private static void ConflictCheck(int knightRow, int knightCol, char[][] board, ref int currentConflict)
        {
            if ((knightRow - 1 >= 0 && knightCol - 2 >= 0) && board[knightRow - 1][knightCol - 2]=='K')
            {
                currentConflict++;
            }
            if ((knightRow - 2 >= 0 && knightCol - 1 >= 0) && board[knightRow - 2][knightCol - 1] == 'K')
            {
                currentConflict++;
            }
            if ((knightRow - 2 >= 0 && knightCol + 1 < board.Length) && board[knightRow - 2][knightCol + 1] == 'K')
            {
                currentConflict++;
            }
            if ((knightRow - 1 >= 0 && knightCol + 2 < board.Length) && board[knightRow - 1][knightCol + 2] == 'K')
            {
                currentConflict++;
            }
            if ((knightRow + 1 < board.Length && knightCol + 2 < board.Length) && board[knightRow + 1][knightCol + 2] == 'K')
            {
                currentConflict++;
            }
            if ((knightRow + 2 < board.Length && knightCol + 1 < board.Length) && board[knightRow + 2][knightCol + 1] == 'K')
            {
                currentConflict++;
            }
            if ((knightRow + 2 < board.Length && knightCol - 1 >= 0) && board[knightRow + 2][knightCol - 1] == 'K')
            {
                currentConflict++;
            }
            if ((knightRow + 1 < board.Length && knightCol - 2 >= 0) && board[knightRow + 1][knightCol - 2] == 'K')
            {
                currentConflict++;
            }
        }
    }
}
