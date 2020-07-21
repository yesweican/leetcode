using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q064
    {
        public int MinPathSum(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int[][] dp = new int[rows][];
            
            for(int i=0; i<rows; i++)
            {
                dp[i]=new int[cols];
                dp[i][0] = (i == 0) ? grid[0][0] : (dp[i - 1][0] + grid[i][0]);
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (i == 0)
                        dp[0][j] = dp[0][j - 1] + grid[0][j];
                    else
                        dp[i][j] = Math.Min(dp[i][j - 1] + grid[i][j], dp[i - 1][j] + grid[i][j]);
                }
            }

            return dp[rows - 1][cols - 1];
        }
        
    }
}
