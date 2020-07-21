using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    public class q078
    {
        IList<IList<int>> results = (IList<IList<int>>)new List<IList<int>>();
        public IList<IList<int>> Subsets(int[] nums)
        {
            processNums(nums, 0, new List<int>());
            return results;
        }
        public void processNums(int[] nums, int current, List<int> currentset)
        {
            if (current >= nums.Length)
            {
                results.Add((IList<int>)currentset);
            }
            else
            {
                //constructor with ienumerable

                //List<int> firstSet = new List<int>(currentset);
                processNums(nums, current + 1, currentset);

                List<int> secondSet = new List<int>(currentset);
                secondSet.Add(nums[current]);
                processNums(nums, current + 1, secondSet);
            }

        }
    }
}
