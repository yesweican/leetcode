using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q198
    {
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return nums[1] > nums[0] ? nums[1] : nums[0];
            if (nums.Length == 3)
                return (nums[2] + nums[0]) > nums[1] ? (nums[2] + nums[0]) : nums[1];


            int l = nums.Length;
            int[] dp = new int[l];
            dp[0] = nums[0];
            dp[1] = nums[1] > nums[0] ? nums[1] : nums[0];
            dp[2] = (nums[2] + nums[0]) > nums[1] ? (nums[2] + nums[0]) : nums[1];

            int i = 3;
            while (i < l)
            {
                //Use MAX could lower the performance!!!
                //dp[i]=Math.Max(dp[i-1],Math.Max((nums[i]+dp[i-2]),(nums[i]+dp[i-3])));
                dp[i] = dp[i - 1];
                if (dp[i] < (dp[i - 2] + nums[i]))
                    dp[i] = dp[i - 2] + nums[i];
                if (dp[i] < (dp[i - 3] + nums[i]))
                    dp[i] = dp[i - 3] + nums[i];
                i++;
            }

            return dp[l - 1];
        }
    }
}
