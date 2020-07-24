using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    public class q528
    {
        int[] bounds;
        int UBound;
        System.Random r;
        public q528(int[] w)
        {

            bounds = new int[w.Length];

            int w0 = 0;
            for (int i = 0; i < w.Length; i++)
            {
                int w1 = w0 + w[i];
                bounds[i] = w1;
                w0 = w1;
            }

            UBound = w0;

            r = new System.Random();
        }

        public int PickIndex()
        {
            double temp = r.NextDouble() * UBound;

            int left = 0; int right = bounds.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (temp <= bounds[mid])
                    right = mid;
                else
                    left = mid + 1;

            }

            return left;
        }
    }
}
