using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q200
    {
        public int NumIslands(char[][] grid)
        {
            int islands = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        islands++;

                        sinking(grid, i, j);
                    }
                }
            }

            return islands;
        }

        private void sinking(char[][] grid, int i, int j)
        {
            if (i < 0 || i > (grid.Length - 1) || j < 0 || j > (grid[i].Length - 1))
                return;

            if (grid[i][j] == '1')
            {
                grid[i][j] = '0';

                sinking(grid, i - 1, j);
                sinking(grid, i + 1, j);
                sinking(grid, i, j - 1);
                sinking(grid, i, j + 1);
            }
        }
    }
}
