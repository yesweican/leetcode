using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q525
    {
        public int FindMaxLength(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int counter = 0, max = 0;
            //key here is add in an original counter 0 position
            dict.Add(0, -1);
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1) counter++;
                if (nums[i] == 0) counter--;

                if (dict.ContainsKey(counter))
                {
                    if (max < (i - dict[counter]))
                        max = i - dict[counter];
                }
                else
                {
                    dict.Add(counter, i);
                }
            }

            return max;
        }
    }
}
