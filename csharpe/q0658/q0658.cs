using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q658
    {
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            int l = arr.Length;
            int p1 = 0; int p2 = l - 1;

            if (k > l) return new List<int>(arr);

            int m = l - k;

            while (m > 0)
            {
                int n1=Math.Abs(arr[p1] - x);
                int n2=Math.Abs(arr[p2] - x);

                if (n1 > n2)
                {
                    p2--;
                }
                else
                {
                    if (n1 == n2)
                    {
                        //remove the bigger one if equal
                        p2--;
                    }
                    else
                    {
                        //p2 move forward, always
                        p2--;
                    }
                }
                //don't forget do this AFTER each loop
                m--;
            }

            List<int> results = new List<int>();
            for(int  j=p1; j<p2;j++)
            {
              results.Add(arr[j]);
            }

            return results;
        }

    }
}
