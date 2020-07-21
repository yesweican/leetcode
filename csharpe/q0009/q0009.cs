using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q009
    {
        public bool IsPalindrome(int x)
        {
            string s = x.ToString();

            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);


            return s == new string(charArray);
        }

        public bool IsPalindrome2(int x)
        {
            //take care of edge cases!
            if (x < 0)
                return false;

            List<int> list = new List<int>();

            int n=x;
            while (n != 0)
            {
                int d = n % 10;
                n = (n - d) / 10;
                list.Add(d);
            }

            for (int i = 0, j = list.Count - 1; i < j; i++, j--)
            {
                if (list[i] != list[j])
                    return false;
            }

            return true;
        }


    }
}
