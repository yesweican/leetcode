using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q042
    {
        /// <summary>
        /// This approach is borrowing from the same idea of 
        /// question q238:  "Product of Array Except Self"
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            int l = height.Length;
            int[] a = new int[l];
            int[] b = new int[l];

            int max = 0;
            for (int i = 0; i < l; i++)
            {
                if (i > 0)
                {
                    if (max < height[i - 1])
                        max = height[i - 1];
                    a[i] = max;
                }
                else
                {
                    a[i] = max;//0
                }
            }

            max = 0;
            for (int j = l-1; j >=0; j--)
            {
                if (j <(l-1))
                {
                    if (max < height[j + 1])
                        max = height[j + 1];
                    a[j] = max;
                }
                else
                {
                    a[j] = max;//0
                }
            }

            int total=0;
            for (int i = 0; i < l; i++)
            {
                int temp = Math.Min(a[i], b[i]);
                total += (height[i] < temp) ? temp - height[i] : 0;
            }

            return total;
        }

        public int TrapBetter(int[] height)
        {
            if (height == null || height.Length == 0)
                return 0;

            int l = height.Length;
            int total = 0;
            int maxLeft = height[0];
            int maxRight = height[l - 1];

            int i = 0; int j = l - 1;

            while (i < j)
            {
                if (height[i] < height[j])
                {
                    i++;
                    if (maxLeft < height[i])
                        maxLeft = height[i];
                    else
                        total += (maxLeft - height[i]);
                }
                else
                {
                    j--;
                    if (maxRight < height[j])
                        maxRight = height[j];
                    else
                        total += maxRight - height[j];
                }
            }

            return total;
        }
    }
}
