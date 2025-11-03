public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        int m= obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        int [][] dp = new int[m][];
       for(int i=0; i<obstacleGrid.Length; i++)
       {
           dp[i] = new int[n];
       }
        
       dp[0][0]=1;
        
       for(int i=0; i<m; i++)
       {
           for(int j=0; j<n; j++)
           {
               int temp = 0;
               if(i>0 && obstacleGrid[i-1][j]==0)
                   temp += dp[i-1][j];
               if(j>0 && obstacleGrid[i][j-1]==0)
                   temp +=dp[i][j-1];
               if(obstacleGrid[i][j]==0)
                  dp[i][j] += temp;
               else
                  dp[i][j] = 0;
           }
       }
        
        return dp[m-1][n-1];
    }
}