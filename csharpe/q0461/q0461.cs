using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    public class q461
    {
        public int HammingDistance(int x, int y)
        {
            int count = 0;
            int temp = x ^ y;
            while(temp>0)
            {
                if ((temp & 1)==1)
                    count++;

                temp = (temp >> 1);

            }

            return count;
        }
    }
}
