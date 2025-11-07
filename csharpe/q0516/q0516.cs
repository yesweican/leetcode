public class Solution {
    int [][] dp;
    public int LongestPalindromeSubseq(string s) {
        char[] data = s.ToCharArray();
        int N = data.Length;
        dp = new int[N+1][];

        for(int i=0; i<(N+1); i++)
        {
            dp[i] = new int[N];
            if(i==1)
            {
                for (int j = 0; j < N; j++)
                    dp[1][j] = 1;
            }
        }

        for(int len = 2; len<=N; len++)
        {
            for(int start=0; start<=(N-len); start++)
            {
                int end = start + len - 1;

                if(data[start]==data[end])
                {
                    dp[len][start] = dp[len-2][start+1] + 2; 
                }
                else
                {
                    dp[len][start] = Math.Max(dp[len-1][start], dp[len-1][start+1]);//len>1=>(end>=1)=>(end-1)>=0
                }
            }
        }

        return dp[N][0];        
    }
}