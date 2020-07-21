using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q001
    {
        /// <summary>
        /// Improved TWO Sum solution
        /// {3, 2, 4}
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int,int> dict = new Dictionary<int,int>();
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(target - nums[i]))
                {
                    result[1] = i;
                    result[0] = dict[target - nums[i]];
                    break;
                }

                //put this lower down here to avoid reusing same element!
                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], i);
            }
            return result;
        }
    }
}
