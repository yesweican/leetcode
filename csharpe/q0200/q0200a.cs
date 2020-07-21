using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q200a
    {
        HashSet<string> visited = new HashSet<string>();

        public int NumIslands(char[][] grid)
        {
            visited = new HashSet<string>();
            int islands = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    string temp=i.ToString()+","+j.ToString();
                    if (!visited.Contains(temp) && (grid[i][j] == 1))
                    {
                        islands++;

                        visit(grid, i, j);
                    }
                }
            }

            return islands;
        }

        private void visit(char[][] grid, int i, int j)
        {

            if (i < 0 || i > (grid.Length - 1) || j < 0 || j > (grid[i].Length - 1))
                return;

            //Adding all connected pieces to visited
            string temp = i.ToString() + "," + j.ToString();
            if (visited.Contains(temp))
                return;

            if (grid[i][j] == '1')
            {
                //Adding all connected pieces to visited
                visited.Add(temp);

                visit(grid, i - 1, j);
                visit(grid, i + 1, j);
                visit(grid, i, j - 1);
                visit(grid, i, j + 1);
            }
        }
    }
}
