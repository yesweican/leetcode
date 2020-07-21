using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q169
    {
        public int MajorityElement(int[] nums)
        {

            if (nums.Length == 1)
                return nums[0];

            Dictionary<int, int> dict = new Dictionary<int, int>();
            int temp = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], 1);
                }
                else
                {
                    temp = dict[nums[i]];
                    temp++;
                    if (temp > (nums.Length - 1) / 2)
                        return nums[i];
                    dict[nums[i]] = temp;
                }
            }

            return -1;

        }
    }
}
