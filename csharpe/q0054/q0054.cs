using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q054
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            HashSet<int> set = new HashSet<int>();
            List<int> list = new List<int>();
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return list;

            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int[][] directions = new int[4][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

            int currentrow = 0;
            int currentcol = 0;
            int direction = 0;

            set.Add(matrix[currentrow][currentcol]);
            list.Add(matrix[currentrow][currentcol]);

            while (list.Count < (rows * cols))
            {

                int nextrow = currentrow + directions[direction][0];
                int nextcol = currentcol + directions[direction][1];

                while ((nextrow >= 0) && (nextrow < rows) && (nextcol >= 0) && (nextcol < cols) && (!set.Contains(matrix[nextrow][nextcol])))
                {
                    currentrow = nextrow; currentcol = nextcol;
                    set.Add(matrix[currentrow][currentcol]);
                    list.Add(matrix[currentrow][currentcol]);
                    nextrow = nextrow + directions[direction][0];
                    nextcol = nextcol + directions[direction][1];
                }

                direction = (direction + 1) % 4;
            }

            return list;
        }
    }
}
