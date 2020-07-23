using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Cheapest Flights Within K Stops - Bell Fordman
    /// </summary>
    public class q787
    {
        int[][] dp;
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            dp = new int[K + 2][];
            //initialize the dp matrix, and set 0 distance to src
            for (int i = 0; i < K + 2; i++)
            {
                dp[i] = new int[n];
                if (i == 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j == src)
                            dp[i][j] = 0;
                        else
                            dp[i][j] = Int32.MaxValue;
                    }
                }

            }


            for (int i = 1; i < K + 2; i++)
            {
                Array.Copy(dp[i - 1], dp[i], n);

                for (int j = 0; j < flights.Length; j++)
                {
                    int x0 = flights[j][0];
                    int x1 = flights[j][1];
                    int c = flights[j][2];

                    //if original distance wasn't set, no point relaxing
                    //AND ** we need this to avoid integer overflow
                    if (dp[i - 1][x0] == Int32.MaxValue)
                        continue;

                    if (dp[i][x1] > dp[i - 1][x0] + c)
                    {
                        dp[i][x1] = dp[i - 1][x0] + c;
                        // p[x1] = x0;
                    }
                }
            }

            return dp[K + 1][dst] == Int32.MaxValue ? -1 : dp[K + 1][dst];
        }
    }
}
