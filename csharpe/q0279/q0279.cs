public class Solution {
    public int NumSquares(int n) {
        int[] coins=new int[100];
        int[][] dp=new int[100][];
        
        for(int i=0; i<100; i++)
        {
            coins[i]=(i+1)*(i+1);
            dp[i] = new int[n+1];
        }
        
        for(int j=0; j<=n; j++)
        {
            dp[0][j] = j;
        }
        
        int maxrow = 0;
        for(int row=1; row<100 && coins[row]<=n; row++)
        {
            if(maxrow<row)
                maxrow = row;
            for(int column=0; column<=n; column++)
            {
                int min=dp[row-1][column];
                if((column - coins[row])>=0)
                {
                    int x1 = dp[row - 1][column - coins[row]] + 1;
                    if (min > x1)
                         min = x1;
                    int x2 = dp[row][column - coins[row]] + 1;
                    if (min > x2)
                        min = x2;
                }
                dp[row][column] = min;
            }
        }
        
        return dp[maxrow][n];
      
    }
}