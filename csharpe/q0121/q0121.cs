using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q121
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;
            int min = int.MaxValue;
            int max = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < min)
                    min = prices[i];
                else
                    max = Math.Max(max, prices[i] - min);
            }

            return max;
        }
    }
}
