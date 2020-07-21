using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q905
    {
        public int[] SortArrayByParity(int[] A)
        {
            int nextEven = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    int temp = A[nextEven]; A[nextEven] = A[i];
                    A[i] = temp;
                    nextEven++;
                }
            }

            return A;
        }
    }
}
