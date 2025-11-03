using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q338
    {
        public int[] CountBits(int num)
        {
            int i = 0; int b = 1;
            int[] dp = new int[num + 1];

            while (b <= num)
            {
                //second part of the condition is for the top bit
                while (i < b && (i + b) <= num)
                {
                    //num i+b has ONE more bit than i on the b th bit
                    //like  d=2:3=>1, 2=>0; d=4:4=>0, 5=>1
                    dp[i + b] = dp[i] + 1;
                    i++;
                }
                i = 0; b <<= 1;
            }

            return dp;
        }
    }
}
