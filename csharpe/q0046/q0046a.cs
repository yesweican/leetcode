using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q046a
    {
        /// <summary>
        /// Using SWAP approach used in 267
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// This method actually ended up slightly slower...
        List<IList<int>> Results;
        public IList<IList<int>> Permute(int[] nums)
        {
            Results=new List<IList<int>>();
            populate(nums, 0, nums.Length-1);

            return Results;
        }

        void populate(int[] a, int left, int right)
        {
            if (left == right)
            {
                List<int> inner=new List<int>();
                for(int i=0; i<a.Length;i++)
                {
                    inner[i]=a[i];
                }
                Results.Add((IList<int>) inner);
            }
            else
                for (int i = left; i <= right; i++)
                {
                    swap(a, left, i);
                    populate(a, left + 1, right);
                    swap(a, left, i);
                }
        }

        void swap(int[] a, int i, int x)
        {
            int t = a[i];
            a[i] = a[x];
            a[x] = t;
        }
    }
}
