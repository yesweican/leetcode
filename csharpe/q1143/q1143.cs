using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q1143
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            char[] chararr1 = text1.ToCharArray();
            char[] chararr2 = text2.ToCharArray();

            int rows = chararr1.Length;
            int cols = chararr2.Length;
            //one extra row and column for the "" empty strings
            int[,] dp = new int[rows + 1, cols + 1];

            for (int i = 0; i < (cols + 1); i++)
            {
                dp[0, i] = 0;
            }
            for (int i = 1; i < (rows + 1); i++)
            {
                dp[i, 0] = 0;
            }

            for (int r = 1; r < (rows + 1); r++)
            {
                for (int c = 1; c < (cols + 1); c++)
                {
                    //pay attention to the indexes
                    if (chararr1[r-1] == chararr2[c-1])
                    {
                        dp[r, c] = dp[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        dp[r, c] = Math.Max(dp[r-1,c], dp[r, c-1]);
                    }
                }
            }

            return dp[rows, cols];

        }
    }
}
