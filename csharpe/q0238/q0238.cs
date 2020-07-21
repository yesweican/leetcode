using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q238
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int l = nums.Length;

            int[] frontvalues = new int[l];
            int[] backvalues = new int[l];

            frontvalues[0] = 1;
            for (int i = 1; i < l; i++)
            {
                frontvalues[i] = frontvalues[i - 1] * nums[i - 1];
            }

            backvalues[l - 1] = 1;
            for (int i = l - 2; i >= 0; i--)
            {
                backvalues[i] = backvalues[i + 1] * nums[i + 1];
            }

            int[] results = new int[l];
            for (int i = 0; i < l; i++)
            {
                results[i] = frontvalues[i] * backvalues[i];
            }

            return results;

        }
    }
}
