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

        }

        public bool isValidBoard(int[,] board)
        {
            Dictionary<int, bool> across = new Dictionary<int, bool>();
            Dictionary<int, bool> down = new Dictionary<int, bool>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    bool b_across =  across.ContainsKey(board[i, j]);
                    bool b_down = down.ContainsKey(board[j, i]);

                    if (!b_across & !b_down) // if a is not true
                    {
                        // by using two dictionaries I am able to check if a value is valid in both the across and down
                        // axis simultaniously with less processing time.
                        across.Add(board[i, j], true);
                        down.Add(board[j, i], true);
                    }
                }
            }



            return true;
        }
    }
}
