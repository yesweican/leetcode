using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// N Queens II problem
    /// </summary>
    public class q052
    {
        int SolutionCount = -1;
        int QueenCount = -1;
        public int TotalNQueens(int n)
        {
            QueenCount = n;
            SolutionCount = 0;
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];
            int[] arr3 = new int[n];

            dfs(arr1, arr2, arr3, 0);

            return SolutionCount;
        }

        private void dfs(int[] col_per_row, int[] xy_diff, int[] xy_sum, int cur_row)
        {
            //int cur_row = col_per_row.Count;
            if (cur_row == QueenCount)
            {
                List<int> temp = new List<int>();
                for (int i = 0; i < QueenCount; i++)
                {
                    var val = (int)col_per_row[i];
                    temp.Add(val);
                }
                SolutionCount++;
                return;
            }

            for (int col = 0; col < QueenCount; col++)
            {
                if ((!FindInArray(col_per_row, col, cur_row)) && (!FindInArray(xy_diff, cur_row - col, cur_row)) && (!FindInArray(xy_sum, cur_row + col, cur_row)))
                {
                    col_per_row[cur_row] = col;
                    xy_diff[cur_row] = cur_row - col;
                    xy_sum[cur_row] = cur_row + col;
                    dfs(col_per_row, xy_diff, xy_sum, cur_row + 1);
                }

            }
        }

        private bool FindInArray(int[] arr, int value, int cur_row)
        {
            if (cur_row == 0) return false;
            bool found = false;

            for (int i = 0; i < cur_row; i++)
            {
                if (arr[i] == value)
                {
                    found = true;
                    return found;
                }
            }
            return found;
        }
    }
}
