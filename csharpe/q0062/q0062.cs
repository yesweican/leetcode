using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Unique Paths
    /// </summary>
    public class q062
    {

        int[,] dp;

        public int UniquePaths(int m, int n)
        {

            dp = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[0, 0] = 1;
                    }
                    else
                    {
                        if (i == 0)
                            dp[0, j] = dp[0, j - 1];

                        if (j == 0)
                            dp[i, 0] = dp[i - 1, 0];

                        if (i > 0 && j > 0)
                            dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }
            }

            return dp[m - 1, n - 1];

        }
    }
}
