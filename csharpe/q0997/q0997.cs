using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q997
    {
        public int FindJudge(int N, int[][] trust)
        {
            if ((trust.Length == 0) && (N == 1))
                return 1;

            if (trust.Length == 0)
                return -1;

            HashSet<int> EveryOneElse = new HashSet<int>();
            Dictionary<int, int> Trusted = new Dictionary<int, int>();

            for (int i = 0; i < trust.Length; i++)
            {
                if (!EveryOneElse.Contains(trust[i][0]))
                {
                    EveryOneElse.Add(trust[i][0]);
                }

                if (!Trusted.ContainsKey(trust[i][1]))
                {
                    Trusted.Add(trust[i][1], 1);
                }
                else
                {
                    Trusted[trust[i][1]]++;
                }

            }

            //if(Trusted.Count>1)
            //   return -1;


            foreach (var v in Trusted)
            {
                if ((v.Value == (N - 1)) && (!EveryOneElse.Contains(v.Key)))
                    return v.Key;

            }

            return -1;

        }
    }
}
