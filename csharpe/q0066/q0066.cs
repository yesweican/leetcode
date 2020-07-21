using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    public class q066
    {
        public int[] PlusOne(int[] digits)
        {
            List<int> newDigits = new List<int>();

            int carry = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int temp = (i == digits.Length - 1) ? (digits[i] + carry + 1) : (digits[i] + carry);
                if (temp > 9)
                {
                    newDigits.Add(temp - 10);
                    carry = 1;
                }
                else
                {
                    newDigits.Add(temp);
                    carry = 0;
                }

            }

            if (carry > 0)
                newDigits.Add(carry);

            newDigits.Reverse();
            return newDigits.ToArray();
        }

        public int[] PlusOne2(int[] digits)
        {
            int carry = 0;
            int[] result;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int temp = (i == digits.Length - 1) ? (digits[i] + carry + 1) : (digits[i] + carry);
                if (temp > 9)
                {
                    digits[i] = temp - 10;
                    carry = 1;
                }
                else
                {
                    digits[i]=temp;
                    carry = 0;
                    break;
                }

            }

            if (carry > 0)
            {
                result = new int[digits.Length + 1];
                result[0] = 1;

                Array.Copy(digits, 0, result, 1, digits.Length);
                return result;
            }
            else
                return digits;
        }
    }
}
