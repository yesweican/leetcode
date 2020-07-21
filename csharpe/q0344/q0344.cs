using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// In-place reverse string
    /// </summary>
    public class q344
    {
        public void ReverseString(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;

            while(left<right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++; right--;
            }
        }

        public void ReverseString2(char[] s)
        {
            int l = s.Length;
            char c;

            for (int i = 0; i < l / 2; i++)
            {
                c = s[i];
                s[i] = s[l - i - 1];
                s[l - i - 1] = c;
            }
        }
    }
}
