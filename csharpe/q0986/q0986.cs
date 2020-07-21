using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    /// <summary>
    /// Interval Intersection
    /// </summary>
    public class q986
    {
        List<int[]> result;
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            result = new List<int[]>();
            int APointer=0;
            int BPointer=0;

            while ((APointer<A.Length) && (BPointer<B.Length))
            {
                int lowerHigh = Math.Min(A[APointer][1], B[BPointer][1]);
                int higherLow = Math.Max(A[APointer][0], B[BPointer][0]);

                //If there is Overlap!
                if (higherLow <= lowerHigh)
                    result.Add(new int[] { higherLow, lowerHigh });

                if (A[APointer][1]>B[BPointer][1])
                {
                    BPointer++;
                }
                else
                {
                    if(A[APointer][1] < B[BPointer][1])
                    {
                        APointer++;
                    }
                    else //A[APointer][1] == B[BPointer][1]
                    {
                        APointer++;
                        BPointer++;
                    }
                }

            }

            return result.ToArray();

        }
    }
}
