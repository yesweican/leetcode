public class Solution {
    public int CoinChange(int[] coins, int amount) 
    {
            if (amount == 0)
                return 0;
            if (coins == null || coins.Length == 0)
                return -1;

            int[] dp = new int[amount + 1];
            for (int i = 1; i <= amount; i++)
            {
                int min = int.MaxValue;
                for (int j = 0; j < coins.Length; j++)
                {
                    if (i >= coins[j] && dp[i - coins[j]] != -1)
                        min = Math.Min(min, dp[i - coins[j]] + 1);
                }

                dp[i] = min == int.MaxValue ? -1 : min;
            }
            return dp[amount];
        } 
}