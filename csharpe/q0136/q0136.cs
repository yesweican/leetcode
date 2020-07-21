using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q136
    {
        /// <summary>
        /// Commutative vs Associative
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            int result = 0;
            foreach (var x in nums)
            {
                result = result ^ x;
            }

            return result;
        }
    }
}
