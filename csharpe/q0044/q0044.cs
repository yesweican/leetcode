public class Solution {
    public bool IsMatch(string s, string p) {
            p=removeTrailings(p);
            int m = s.Length;
            int n = p.Length;

            bool[][] dp = new bool[m + 1][];
            for(int i=0; i<=m;i++)
            {
                dp[i] = new bool[n + 1];
                dp[i][0] = false;
            }

            for (int i = 1; i <= n; i++)
            {
                if(i==1 && p[i-1]=='*') //need this to succeed!
                    dp[0][i] = true;
                else
                    dp[0][i] = false;
            }

            dp[0][0] = true;

            for(int i=1; i<=m; i++)
            {
                for(int j=1; j<=n; j++)
                {
                    if(p[j-1]=='?')
                    {
                        dp[i][j] = dp[i - 1][j - 1];
                    }
                    else if(p[j-1]=='*')
                    {
                        dp[i][j] = dp[i - 1][j] || dp[i][j - 1];
                    }
                    else
                    {
                        if(s[i-1]==p[j-1])
                        {
                            dp[i][j] = dp[i - 1][j - 1];
                        }
                        /// else remain false;

                    }
                }
            }

            return dp[m][n];       
    }
    
    private string removeTrailings(string s)
    {
        StringBuilder builder = new StringBuilder(); 
        bool lastStar = false;
        
        for(int i=0; i<s.Length; i++)
        {
            if(s[i]=='*')
            {
                if(lastStar == false)
                {
                    builder.Append('*');
                    lastStar = true;
                }
            }
            else
            {
                builder.Append(s[i]);
                lastStar = false;
            }
        }
        
        return builder.ToString();
    }
}