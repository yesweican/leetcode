using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q201
    {
        public int RangeBitwiseAnd(int m, int n)
        {
            List<int> masks = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();


            int seed=1;
            int temp=n;
            while (temp > 0)
            {
                masks.Add(seed);
                dict.Add(seed, 1);
                temp>>=1;
                seed<<=1;
            }

            for(int i=m; i<=n; i++)
            {
                for(int j=0;j<masks.Count; j++)
                {
                    if ((i & masks[j]) == 0)
                        dict[masks[j]] = 0;
                }
            }

            int result = 0;
            for (int j = 0; j < masks.Count; j++)
            {
                if (dict[masks[j]]==1)
                    result +=masks[j] ;
            }

            return result;
        }

        public int RangeBitwiseAndBetter(int m, int n)
        {
            if (m == 0)
                return 0;

            int seed = m;

            for (int i = m+1; i <= n; i++)
            {
                seed = seed & i;
            }

            return seed;
        }

        public int RangeBitwiseAndBest(int m, int n)
        {
            if (m == 0) return 0;
            if (m == n) return m;

            int m2 = m; int n2 = n;

            int counter = 0;
            while (m2 != n2)
            {
                m2 >>= 1;
                n2 >>= 1;
                counter++;
            }

            while (counter > 0)
            {
                m2 <<= 1;
            }

            return m2;
        }
    }
}
