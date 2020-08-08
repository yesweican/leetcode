using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge05
{
    public class q442
    {
        public IList<int> FindDuplicates(int[] nums)
        {
            List<int> result = new List<int>();

            HashSet<int> hset = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!hset.Contains(nums[i]))
                {
                    hset.Add(nums[i]);
                }
                else
                {
                    result.Add(nums[i]);
                }
            }

            return (IList<int>)result;
        }

    }
}
