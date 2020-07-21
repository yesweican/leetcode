using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    /// <summary>
    /// This is a classic DP problem, O(N^5)=>O(N^3) improvement
    /// Special case of Leetcode 085 Rectangle
    /// And other similar classics include Leetcode 053 Max SubArray Sum
    /// </summary>
    public class q221
    {
        public int MaximalSquare(char[][] matrix)
        {
            int maxarea = 0;
            if (matrix == null)
                return 0;
            int rows = matrix.Length;
            if (rows == 0)
                return 0;
            int cols = matrix[0].Length;
            if (cols == 0)
                return 0;

            int[,] sums = new int[rows, cols];

            //preparation of the sums integer matrix
            sums[0, 0] = matrix[0][0] - '0';
            for (int i = 1; i < cols; i++)
            {
                sums[0, i] = sums[0, i - 1] + (matrix[0][i] - '0');
            }
            for (int i = 1; i < rows; i++)
            {
                sums[i, 0] = sums[i - 1, 0] + (matrix[i][0] - '0');
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    sums[i, j] = sums[i - 1, j] + sums[i, j - 1] - sums[i - 1, j - 1] + (matrix[i][j] - '0');
                }
            }

            //process the sums matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int temp = Math.Min(rows - i + 1, cols - j + 1);
                    for (int size = 1; size < temp; size++)
                    {
                        int area = 0;
                        if (size == 1)
                            area = matrix[i][j] - '0';
                        else
                        {
                            if (i == 0 && j == 0)
                                area = sums[size - 1, size - 1];
                            else
                            {

                                if (i > 0 && j > 0)
                                    area = sums[i + size - 1, j + size - 1] - sums[i - 1, j + size - 1] - sums[i + size - 1, j - 1] + sums[i - 1, j - 1];
                                else
                                {
                                    if (i == 0)
                                        area = sums[i + size - 1, j + size - 1] - sums[i + size - 1, j - 1];

                                    if (j == 0)
                                        area = sums[i + size - 1, j + size - 1] - sums[i - 1, j + size - 1];
                                }
                            }
                        }


                        if ((area == size * size) && (area > maxarea)) maxarea = area;
                    }
                }
            }

            return maxarea;    

        }
    }
}
