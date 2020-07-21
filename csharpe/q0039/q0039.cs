using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Combination Sum
    /// </summary>
    public class q039
    {
        List<List<int>> results;
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            results = new List<List<int>>();

            CombinationSumRecursive(candidates, target, 0, new List<int>());

            return (IList<IList<int>>)results;

        }

        private void CombinationSumRecursive(int[] candidates, int target, int index, List<int> current)
        {
            if(candidates[index]==target)
            {
                List<int> temp = new List<int>(current);
                temp.Add(candidates[index]);
                results.Add(temp);
                //potentially we could choose NOT to use this candidate
                //return; //don't return here yet, like 4,2,8=>8
            }

            if (candidates[index] < target)
            {
                //use current number
                List<int> temp1 = new List<int>(current);
                temp1.Add(candidates[index]);
                CombinationSumRecursive(candidates, target - candidates[index], index, temp1);
            }

            //OR if not using current number
            if (index < (candidates.Length - 1))
                CombinationSumRecursive(candidates, target, index + 1, current);
        }
    }
}
