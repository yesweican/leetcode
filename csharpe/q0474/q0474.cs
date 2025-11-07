public class Solution {
    public int FindMaxForm(string[] strs, int m, int n) {
        int[,] dp = new int[m + 1, n + 1];
        foreach(var s in strs)
        {
            int zeros = 0;
            char[] buffer = s.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == '0')
                    zeros++;
            }
            int ones = s.Length - zeros;

            
            /// NOT sure why this needed to go backward!!!
            /// To avoid A=> B Increase, and B =>C Increase, so A=>C Increase!
            for (int i = m; i >= zeros; i--)
            {
                for (int j = n; j >= ones; j--)
                {
                    dp[i, j] = Math.Max(dp[i, j], dp[i - zeros, j - ones] + 1);
                }
            }
        }

        return dp[m, n];
    }
}