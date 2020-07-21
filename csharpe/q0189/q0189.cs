using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class q189
    {
        /// <summary>
        /// Fail on "Time Limit Exceeded"
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            int tmp;
            int n = nums.Length;
            if (n == 1)
                return;
            for (int i=0; i<k; i++ )
            {
                tmp = nums[0];
                for(int j=nums.Length-1; j>=0; j--)
                {
                    nums[(j + 1) % n] = nums[j];
                }
                nums[1] = tmp;
            }
        }

        /// <summary>
        /// GCD + O(N) method
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate2(int[] nums, int k)
        {
            int tmp;
            int n = nums.Length;

            for (int i = 0; i <gcd(k, n); i++)
            {
                tmp = nums[i];
                int j0 = i;//the position to beoverwritten
                while(true)
                {
                    int j1 = ((n+j0 - k) % n + n)% n;//the value moving up - negative modular hack!!!

                    if (j1 == i)//when we need to use nums[i] to move up break out from loop
                        break;

                    nums[j0] = nums[j1];

                    j0 = j1;
                }
                nums[j0] = tmp;
            }

            string s = nums.ToString();
        }

        private int gcd(int x, int y)
        {
            int smaller; int larger;
            if(x<y)
            {
                smaller = x; larger = y;
            }
            else
            {
                smaller = y; larger = x;
            }
            while (smaller>0)
            {
                int temp = smaller;
                smaller = larger % smaller;
                larger = temp;
            }

            return larger;
        }
    }
}
