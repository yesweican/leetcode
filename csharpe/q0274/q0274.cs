using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// H-Index Calculation
    /// </summary>
    public class q274
    {
        public int HIndex(int[] citations)
        {
            int result=0;
            ///First need to sort the array in descending order
            //////https://www.geeksforgeeks.org/different-ways-to-sort-an-array-in-descending-order-in-c-sharp/
            ///////////
            Array.Sort(citations);
            Array.Reverse(citations);
            //Could use bucket sort for improvement???
            //// https://en.wikipedia.org/wiki/Bucket_sort/

            for (int i=1; i<=citations.Length; i++)
            {
                if(citations[i-1]>=i)
                {
                    result = i;
                }
                else //citations[i - 1] < i
                {
                    break;
                }
            }

            return result;
        }

        public int HIndex2(int[] citations)
        {
            int result = 0;
            Array.Sort(citations);
            Array.Reverse(citations);


            //////Tried to improve performance by using Binary Search
            //////https://en.wikipedia.org/wiki/Binary_search_algorithm#:~:text=In%20computer%20science%2C%20binary%20search,middle%20element%20of%20the%20array.
            /////Performance improved but not by much - perhaps limited by the sorting part.
            int left = 1; int right = citations.Length;
            while(left<=right)
            {
                int mid = left + (right - left) / 2;

                if(citations[mid-1]>=mid)
                {
                    result = mid;
                    left = mid+1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }

    }
}
