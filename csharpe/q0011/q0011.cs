using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q011
    {
        /// <summary>
        /// Using the two Pointer Approach similar to Question 042
        /// By the way the q042 got two solutions(or more)
        /// The second one was having two dp array a[] and b[] filled in 
        /// from forward and backward directions
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            int result = 0;

            int left = 0; int right = height.Length - 1;

            while (left < right)
            {


                int temp = (right - left) * (height[left] < height[right] ? height[left] : height[right]);

                if (temp > result)
                    result = temp;

                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }

            return result;
        }
    }
}
