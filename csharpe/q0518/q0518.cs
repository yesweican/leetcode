using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Coin Change 2 - DP Solution
    /// </summary>
    public class q518
    {
        public int Change(int amount, int[] coins)
        {
            if (amount == 0) return 1;
            if (coins.Length == 0) return 0;//used to be -1

            int[] dp = new int[amount + 1];
            dp[0] = 1;

            for (int i = 0; i < coins.Length; i++)
            {
                //including each of the coins ONE by ONE
                int coin = coins[i];
                for (int j = coin; j < (amount + 1); j++)
                {
                    ///Total number of ways for making [j-coin] + ways of NOT using the [coin]
                    dp[j] += dp[j - coin];
                }
            }

            //Console.WriteLine("Total: {0}", dp[amount]);
            return dp[amount];
        }
    }
}
