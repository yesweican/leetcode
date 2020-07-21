using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q918
    {
        public int MaxSubarraySumCircularBasic(int[] A)
        {
            int l = A.Length;
            int[] bp = new int[l];

            bp[0] = A[0];
            int currentsum = A[0];
            int bestsum = A[0];

            for (int i = 1; i < l; i++)
            {
                bp[i] = bp[i - 1] + A[i];
                currentsum = Math.Max(A[i], currentsum + A[i]);
                bestsum = Math.Max(bestsum, currentsum);
            }

            int bestsum2 = Int32.MinValue;
            for (int i = 1; i < l; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int part1 = bp[l - 1] - bp[i - 1];
                    int part2 = bp[j];
                    bestsum2 = Math.Max(bestsum2, part1 + part2);
                }
            }

            return bestsum > bestsum2 ? bestsum : bestsum2;
        }


        public int MaxSubarraySumCircular(int[] A)
        {
            int l=A.Length;
            int total=0;

            int currentsum = A[0];
            int bestsum = A[0];

            //Kadane's algorithm
            for (int i=1; i<l; i++)
            {
                total = total + A[i];
                currentsum = Math.Max(A[i], currentsum + A[i]);
                bestsum = Math.Max(bestsum, currentsum);
            }

            if (l > 2)
            {
                //finding the largest NEGATIVE sum inside the array 
                int currentsum2 = A[1];
                int worstsum = A[1] < 0 ? A[1] : 0;
                for (int i = 2; i < l - 1; i++)
                {
                    currentsum2 = Math.Min(A[i], currentsum2 + A[i]);
                    worstsum = Math.Min(worstsum, currentsum2);
                }

                int bestsum2 = total - worstsum;
                return bestsum > bestsum2 ? bestsum : bestsum2;
            }
            else
                return bestsum;

        }

    }
}
