using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q170
    {
        List<int>data;
        /** Initialize your data structure here. */
        public q170() {
             data=new List<int>();
        }
    
        /** Add the number to an internal data structure.. */
        public void Add(int number) {
             data.Add(number);
        }
    
        /** Find if there exists any pair of numbers which sum is equal to the value. */
        public bool Find(int value) 
        {
            data.Sort();

            int j=0, k=data.Count-1;
            while (j < k)
            {
                int temp = data[j] + data[k];

                if (temp == value)
                {
                        return true;
                    ////skipping to avoid duplicates
                    //while (((j + 1) < k) && (nums[j] == nums[j + 1]))
                    //    j++;
                    //j++;
                    //while ((j < (k-1)) && (nums[k] == nums[k- 1]))
                    //    k--;
                    //k--;

                }
                else
                {
                    if (temp < value)
                        j++;
                    else //temp>value
                        k--;
                }
            }//end of while 
    
            return false;
        }
    }
}
