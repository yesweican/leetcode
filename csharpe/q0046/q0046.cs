using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q046
    {
        List<IList<int>> results;

        /// <summary>
        /// One Recursion based Permutation
        /// Alternative would be using the SWAP method!
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {

            List<int[]> temp = new List<int[]>();

            temp = generatePermutations(nums, 0, nums.Length - 1);

            for (int i = 0; i < temp.Count; i++)
            {
                List<int> inner = new List<int>();
                for (int j = 0; j < temp[i].Length; j++)
                {
                    inner.Add(temp[i][j]);
                }

                results.Add((IList<int>)inner);
            }

            return (IList<IList<int>>)results;   

        }

        public List<int[]> generatePermutations(int[] nums, int left, int right)
        {
            if (left == right)
            {
                int[] temp = new int[1];
                temp[0]=nums[left];

                List<int[]> outer = new List<int[]>();
                outer.Add(temp);
                return outer;

            }


            int c = nums[left];

            List<int[]> outer2 = new List<int[]>();

            //We have right-(left+1)+1 integer
            //So we have right-left+1 slot to insert the c
            foreach(var e in generatePermutations(nums, left+1, right))
            {
                for (int j = 0; j <= (right - left); j++)
                {
                    int[] temp2 = new int[right - left + 1];


                    for (int k = 0; k < j; k++)
                        temp2[k] = e[k];

                    temp2[j] = c;

                    for (int k = j + 1; k <= (right - left); k++)
                    {
                        temp2[k] = e[k - 1];
                    }

                    outer2.Add(temp2);
                }
            }
            return outer2;

        }
    }
}
