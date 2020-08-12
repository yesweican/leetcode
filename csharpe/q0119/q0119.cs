using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge05
{
    public class q119
    {
        public IList<int> GetRow(int rowIndex)
        {
            List<int> result = new List<int>();
            result.Add(1);

            for (int i = 1; i <= rowIndex; i++)
            {
                result.Add(1);
                for (int j = i - 1; j > 0; j--)
                {
                    if (j > 0)
                        result[j] = result[j] + result[j - 1];
                }
            }
            return result;
        }
    }
}
