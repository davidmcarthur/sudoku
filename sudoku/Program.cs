using System;
using System.Collections.Generic;

namespace sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] validsudokuboard = new int[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 }, { 2, 1, 4, 3 }, { 3, 4, 1, 2 } };
            int[,] invalidsudokuboard = new int[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 }, { 2, 1, 4, 4 }, { 3, 1, 1, 2 } };

            isValidBoard(validsudokuboard);
            isValidBoard(invalidsudokuboard);
        }

        public static bool isValidBoard(int[,] board)
        {

            List<int> across = new List<int>();
            List<int> down = new List<int>();


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    bool b_across =  across.Contains(board[i, j]);
                    bool b_down = down.Contains(board[j, i]);

                    if (!b_across & !b_down) // if a is not true
                    {
                        // by using two dictionaries I am able to check if a value is valid in both the across and down
                        // axis simultaniously with less processing time.
                        across.Add(board[i, j]);
                        down.Add(board[j, i]);
                    }
                    else
                    {
                        Console.WriteLine("Board is invalid");
                        return false;
                    }                 
                }
                // once the for j loop ends it is necessary to clear the dictionary.
                // without doing this all boards will be invalid because the value in 
                // the next row or column will be present still and thus invalid.
                across.Clear();
                down.Clear();

            }
            // if the for loops get through without issue return true.                     
            Console.WriteLine("Board is valid");
            return true;
        }
    }
}
