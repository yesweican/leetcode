using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    public class q1029
    {
        public int TwoCitySchedCost(int[][] costs)
        {
            int M = costs.Length;

            Array.Sort(costs, (x, y) => (x[0] - x[1]).CompareTo(y[0] - y[1]));

            int total1 = 0; int total2 = 0;
            for (int i = 0; i < M / 2; i++)
            {
                total1 += costs[i][0];
            }

            for (int i = M / 2; i < M; i++)
            {
                total2 += costs[i][1];
            }

            return total1 + total2;
        }
    }
}
