using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q202
    {
        public bool IsHappy(int n)
        {
            if (n == 1) return true;
            while (n != 1)
            {
                int[] a = ConvertToDigits(n);
                int temp = 0;
                foreach (var d in a)
                {
                    temp += d * d;
                }
                n = temp;
                if (n == 4) return false;
            }

            return true;
        }

        private int[] ConvertToDigits(int n)
        {
            List<int> digits = new List<int>();
            while (n > 0)
            {
                int newdigit = n % 10;
                digits.Add(newdigit);
                n = (n - newdigit) / 10;
            }

            return digits.ToArray();
        }
    }
}
