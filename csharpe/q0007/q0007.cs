using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q007
    {

        public int Reverse(int x)
        {

            bool bNegative = x < 0;
            if (bNegative) x = -x;

            List<int> list = new List<int>();

            int n = x;
            while (n != 0)
            {
                int d = n % 10;
                n = (n - d) / 10;
                list.Add(d);
            }

            //watch out edge cases here
            long temp = 0;
            for (int i = 0; i < list.Count; i++)
            {
                temp = temp * 10 + list[i];
            }

            temp = bNegative ? -temp : temp;
            //take care of edge cases
            if (temp > 2147483647 || temp < -2147483648) return 0;

            return (int)temp;


        }
    }
}
