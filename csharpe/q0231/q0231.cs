using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q231
    {
        public bool IsPowerOfTwo(int n)
        {

            if (n <= 0)
                return false;
            if (n == 1)
                return true;
            int temp = n;

            while (temp > 1)
            {
                if (temp % 2 == 1)
                    return false;
                else
                    temp = temp / 2;
            }

            return true;

        }

        /// <summary>
        /// leetcode question 326
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfThree(int n)
        {
            if (n <= 0)
                return false;
            if (n == 1)
                return true;
            int temp = n;

            while (temp > 1)
            {
                if (temp % 3 > 0)
                    return false;
                else
                    temp = temp / 3;
            }

            return true;
        }
    }
}
