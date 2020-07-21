using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q1277
    {
        int[,] dp;
        int total;
        public int CountSquares(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            total = 0;

            dp = new int[rows, cols];

            int temp = 0;
            for(int col=0; col<cols; col++)
            {
                temp += matrix[0][col];
                dp[0, col] = temp;
            }

            temp = dp[0,0];
            for (int row = 1; row < rows; row++)
            {
                temp += matrix[row][0];
                dp[row, 0] = temp;
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    dp[row, col] = dp[row - 1, col] + dp[row, col - 1] - dp[row - 1, col - 1] + matrix[row][col];
                }
            }

            //Do following AFTER preparation of DP[,]

            for (int row = 0; row < rows; row++)
            {
                for(int col=0; col<cols; col++)
                {
                    int col0 = cols - col;
                    int row0 = rows - row;
                    int size0 = Math.Min(row0, col0);

                    if(matrix[row][col]==1)
                    {
                        for (int size = 1; size <= size0; size++)
                        {
                            int area0 = dp[row + size - 1, col + size - 1];

                            if (row > 0)
                                area0 -= dp[row - 1, col + size - 1];
                            if (col > 0)
                                area0 -= dp[row + size - 1, col - 1];
                            if ((row > 0) && (col > 0))
                                area0 += dp[row - 1, col - 1];

                            if (area0 == (size * size))
                                total++;
                            else
                                break;
                        }
                    }


                }
            }

            return total;

        }
    }
}
