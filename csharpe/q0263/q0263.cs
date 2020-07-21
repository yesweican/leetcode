using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Ugly Number 1
    /// </summary>
    public class q263
    {
        public bool IsUgly(int num)
        {
            if (num <= 0) return false;
            if (num == 1) return true;

            while ((num % 2) == 0)
            {
                num = num / 2;
            }

            while ((num % 3) == 0)
            {
                num = num / 3;
            }

            while ((num % 5) == 0)
            {
                num = num / 5;
            }

            if (num == 1)
                return true;
            else
                return false;
        }
    }
}
}
