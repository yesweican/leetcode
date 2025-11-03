public class NumMatrix {
    int[][] dp;

    public NumMatrix(int[][] matrix) {
        int N = matrix.Length;
        int M = matrix[0].Length;
        dp = new int[N][];
        for(int i=0; i<N; i++)
        {
            dp[i] = new int[M];
        }
        
        for(int i=0; i<N; i++)
        {
            for(int j=0; j<M; j++ )
            {
                if(i==0 && j==0)
                {
                    dp[0][0] = matrix[0][0];
                }
                else
                {
                    if(i==0)
                    {
                        dp[i][j] = dp[i][j-1]+matrix[i][j];
                    }
                    
                    if(j==0)
                    {
                        dp[i][j]=dp[i-1][j]+matrix[i][j];
                    }
                    
                    if(i>0 && j>0)
                    {
                        dp[i][j] = dp[i][j-1]+dp[i-1][j] - dp[i-1][j-1] + matrix[i][j];
                    }
                }
            }
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        int n1 = (row1>0 && col1>0)?dp[row1-1][col1-1]:0;
        int n2 = (col1>0)?dp[row2][col1-1]:0;
        int n3 = (row1>0)?dp[row1-1][col2]:0;
        int n4 = dp[row2][col2];
        
        return (n4-n2-n3+n1);
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */