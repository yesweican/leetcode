using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q733
    {
        public class Solution
        {
            public int[][] FloodFill(int[][] image, int row, int col, int newColor)
            {
                if (image[row][col] == newColor)
                    return image;

                fill(image, row, col, image[row][col], newColor);
                return image;
            }

            /// <summary>
            /// Reference Type parameter passed in by Reference
            /// </summary>
            /// <param name="image"></param>
            /// <param name="i">row</param>
            /// <param name="j">column</param>
            /// <param name="originalColor"></param>
            /// <param name="newColor"></param>
            private void fill(int[][] image, int i, int j, int originalColor, int newColor)
            {
                if (i < 0 || i >= image.Length || j < 0 || j >= image[0].Length || image[i][j] != originalColor)
                {
                    return;
                }

                image[i][j] = newColor;
                fill(image, i + 1, j, originalColor, newColor);
                fill(image, i - 1, j, originalColor, newColor);
                fill(image, i , j + 1, originalColor, newColor);
                fill(image, i , j - 1, originalColor, newColor);
            }
        }
    }
}
