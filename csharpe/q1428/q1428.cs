using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Leftmost Column with ONE - O(M*N)=>O(M+N)
    /// The Matrix is sorted-but how...
    /// </summary>
    public class q1428
    {
        public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            /////Use the API interface #1
            List<int> x = (List<int>)binaryMatrix.Dimensions();

            //start from top & right
            int currentrow = x[0] - 1;
            int currentcol = x[1] - 1;

            int leftmost = -1;

            while (currentcol >= 0 && currentrow >= 0)
            {
                ////Use the API Interface #2
                int temp = binaryMatrix.Get(currentrow, currentcol);

                if (temp == 1) //Move left while it is ONE
                {
                    leftmost = currentcol;
                    currentcol--;
                }
                else //Move down if run into Zero
                {
                    currentrow--;
                }
            }

            if (currentcol == -1)//run out of the matrix from left side
                return 0;
            else    //run out of the matrix from bottom................
                return leftmost;
        }
    }
}
