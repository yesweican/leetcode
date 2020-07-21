using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Arranging Coins
    /// </summary>
    public class q441
    {
        public int ArrangeCoins(int n)
        {
            long l = (long)2 * n;

            int temp = (int) Math.Sqrt(l);
            return (temp * (temp + 1) <= 2 * n) ? temp : (temp - 1);
        }


    }
}
