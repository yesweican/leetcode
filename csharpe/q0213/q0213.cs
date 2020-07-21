using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q213
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
                return (nums[2] > nums[1]) ? (nums[2] > nums[0]? nums[2]: nums[0]) : (nums[1]>nums[0]? nums[1]:nums[0]);


            int l = nums.Length;
            int[] dp1 = new int[l - 1];
            int[] dp2 = new int[l - 1];
            dp1[0] = nums[0]; dp2[0] = 0;
            dp1[1] = nums[1] > nums[0] ? nums[1] : nums[0]; dp2[1] = nums[1];
            dp1[2] = (nums[2] + nums[0]) > nums[1] ? (nums[2] + nums[0]) : nums[1];
            dp2[2] = (nums[2] > nums[1]) ? nums[2] : nums[1];

            int i = 3;
            while (i < (l-1))
            {
                dp1[i] = dp1[i - 1];
                if (dp1[i] < (dp1[i - 2] + nums[i]))
                    dp1[i] = dp1[i - 2] + nums[i];
                if (dp1[i] < (dp1[i - 3] + nums[i]))
                    dp1[i] = dp1[i - 3] + nums[i];

                dp2[i] = dp2[i - 1];
                if (dp2[i] < (dp2[i - 2] + nums[i]))
                    dp2[i] = dp2[i - 2] + nums[i];
                if (dp2[i] < (dp2[i - 3] + nums[i]))
                    dp2[i] = dp2[i - 3] + nums[i];
                i++;
            }

            int temp = dp1[l - 2];
            if (temp < (dp2[l - 3] + nums[i]))
                temp = dp2[l - 3] + nums[i];
            if (temp < (dp2[l - 4] + nums[i]))
                temp = dp2[l - 4] + nums[i];

            return temp;
        }

    }
}
