using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q771
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="J"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public int NumJewelsInStones(string J, string S)
        {
            char[] jewels = J.ToCharArray();
            char[] stones = S.ToCharArray();
            int result = 0;

            for (int i = 0; i < stones.Length; i++)
            {
                //this seems to be faster than J.contains(*)
                if (jewels.Contains<char>(stones[i]))
                {
                    result++;
                }
            }
            return result;
        }
    }
}
