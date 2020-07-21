using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q033
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;
            return searchinbound(nums, 0, nums.Length - 1, target);
        }

        /// <summary>
        /// Recursive method
        /// Commenting out the uncessary code saved 4ms
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int searchinbound(int[] nums, int left, int right, int target)
        {

            bool tryfronthalf = true;

            if (target == nums[left])
                return left;
            if (target == nums[right])
                return right;

            //need this line to stop the recursion when the search will fail
            if ((right - left) < 2)
                return -1;

            int middle = (int)(left + right) / 2;

            //if ((target > nums[left]) && (target < nums[middle]))
            //    tryfronthalf = true;

            if ((target < nums[left]) && (target > nums[middle]))
                tryfronthalf = false;

            if ((target > nums[left]) && (target > nums[middle]))
            {
                if ((nums[left] < nums[middle]))
                    tryfronthalf = false;
                //else
                //    tryfronthalf = true;
            }

            if ((target < nums[left]) && (target < nums[middle]))
            {
                if ((nums[left] < nums[middle]))
                    tryfronthalf = false;
                //else
                //    tryfronthalf = true;
            }

            if (tryfronthalf)
            {
                return searchinbound(nums, left, middle, target);
            }
            else
            {
                return searchinbound(nums, middle, right, target);
            }


        }
    }
}
