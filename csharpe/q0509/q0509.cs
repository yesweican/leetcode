using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge05
{
    /// <summary>
    /// Fibonacci Number
    /// </summary>
    public class q509
    {
        List<int> fibData;
        public int Fib(int N)
        {

            fibData = new List<int>();
            for(int i=0; i<=N; i++)
            {
                if (i == 0)
                    fibData.Add(0);

                if (i == 1)
                    fibData.Add(1);

                if (i > 1)
                    fibData.Add(fibData[i - 2] + fibData[i - 1]);

            }

            return fibData[N];

        }
    }
}
