using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge05
{
    public class q365
    {
        public bool CanMeasureWater(int x, int y, int z)
        {
            if (z == 0)
                return true;
            if ((x + y) < z)
                return false;

            int temp = -1;
            if (x >= y)
                temp = GCD(x, y);
            else
                temp = GCD(y, x);

            //if x==0 && y==0
            if (temp == 0)
                return false;

            if ((z % temp) == 0)
                return true;
            else
                return false;
        }

        //assuming a > b
        private int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            if (b == 1)
                return 1;

            int temp = a % b;
            if (temp == 0)
                return b;
            else
                return GCD(b, temp);
        }
    }
}
