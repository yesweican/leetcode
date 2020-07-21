using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class q1035
    {
        public int MaxUncrossedLines(int[] A, int[] B)
        {
            int[][] dp = new int[A.Length+1][];

            dp[0] = new int[B.Length+1];
            for (int i = 0; i <= B.Length; i++)
                dp[0][i] = 0;

            for(int i=1; i<=A.Length; i++)
            {
                dp[i] = new int[B.Length+1]; 
                dp[i][0] = 0;
                for(int j=1; j<=B.Length; j++)
                {
                    if (A[i - 1] == B[j - 1])
                    {
                        dp[i][j] = 1 + dp[i - 1][j - 1];
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j] > dp[i][j - 1] ? dp[i - 1][j] : dp[i][j - 1];
                    }
                }
            }

            return dp[A.Length][B.Length];
        }
    }
}
