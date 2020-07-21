using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q1046
    {
        /// <summary>
        /// A solution using the Array.Sort()
        /// --keep in mind that the default sorting is ascending not descending...
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public int LastStoneWeight(int[] stones)
        {
            if (stones == null || stones.Length == 0)
                return 0;
            if (stones.Length == 1)
                return stones[0];

            int l = stones.Length;

            Array.Sort(stones);
            while (stones[l - 2] > 0)
            {
                if (stones[l - 1] == stones[l - 2])
                {
                    stones[l - 1] = 0;
                    stones[l - 2] = 0;
                }
                else
                {
                    if (stones[l - 1] > stones[l - 2])
                    {
                        stones[l - 1] = stones[l - 1] - stones[l - 2];
                        stones[l - 2] = 0;
                    }
                    else
                    {
                        stones[l - 2] = stones[2 - 1] - stones[l - 1];
                        stones[l - 1] = 0;
                    }
                }
                Array.Sort(stones);
            }
            //Array.Reverse(stones);
            return stones[l - 1];

        }
    }
}
