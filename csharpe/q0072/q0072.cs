using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Edit Distance using the recursive and DP methods
    /// </summary>
    public class q072
    {
        int[,] dp;
        public int MinDistance(string word1, string word2)
        {
            int l1 = word1.Length;
            int l2 = word2.Length;
            dp = new int[l1 + 1, l2 + 1];
            for(int i=0; i<=l1; i++)
                for(int j=0; j<=l2; j++)
                {
                    dp[i, j] = -1;
                }

            return minDistanceRecursive(word1, word2, l1, l2);
        }

        private int minDistanceRecursive(string word1, string word2, int l1, int l2)
        {
            if (l1 == 0) return l2;
            if (l2 == 0) return l1;

            int ans;

            if (dp[l1, l2] >= 0)
                return dp[l1, l2];

            if (word1[l1 - 1] == word2[l2 - 1])
                ans = minDistanceRecursive(word1, word2, l1 - 1, l2 - 1);
            else
                ans = Math.Min(minDistanceRecursive(word1, word2, l1 - 1, l2 - 1) //
                    , Math.Min(minDistanceRecursive(word1, word2, l1 - 1, l2)
                    , minDistanceRecursive(word1, word2, l1, l2 - 1))) + 1;

            dp[l1, l2]= ans;
            return ans;
        }

        public int MinDistanceDP(string word1, string word2)
        {
            int l1 = word1.Length;
            int l2 = word2.Length;

            for (int i = 0; i <= l1; i++)
                dp[i, 0] = i;

            for (int j = 0; j <= l2; j++)
                dp[0, j] = j;

            for (int i = 1; i <= l1; i++)
                for (int j = 1; j <= l2; j++)
                {
                    int ans;

                    if (word1[i - 1] == word2[j - 1])
                        ans = dp[i - 1, j - 1];
                    else
                        ans = Math.Min(dp[ i - 1, j - 1] //
                            , Math.Min(dp[i - 1, j]
                            , dp[i, j - 1])) + 1;

                    dp[i, j] = ans;
                }

            return dp[l1, l2];
        }

    }
}
