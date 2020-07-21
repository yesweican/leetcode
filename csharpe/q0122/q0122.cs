using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q122
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;
            int total = 0;

            for (int i = 0; i < (prices.Length - 1); i++)
            {
                //if you are ignoring all the steps going down, 
                //all the upticks would be profit gains
                if (prices[i + 1] < prices[i])
                {
                    total += prices[i+1] - prices[i];
                }
            }

            return total;
        }

        public int MaxProfitSlow(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;
            int total = 0;

            int currentlow = prices[0];

            for (int i = 0; i < (prices.Length - 1); i++)
            {
                if (prices[i] < currentlow)
                    currentlow = prices[i];

                if (prices[i + 1] < prices[i])
                {
                    total += prices[i] - currentlow;
                    currentlow = prices[i + 1];
                }
            }

            total += prices[prices.Length - 1] - currentlow;

            return total;
        }
    }
}
