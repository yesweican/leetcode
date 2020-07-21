using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Add Binary
    /// </summary>
    public class q067
    {
        public string AddBinary(string a, string b)
        {
            int current;
            int carry = 0;
            List<string> buffer = new List<string>();

            StringBuilder builder = new StringBuilder();

            int l1 = a.Length - 1;
            int l2 = b.Length - 1;
            while (l1 >= 0 && l2 >= 0)
            {
                int i1 = a[l1] - '0';
                int i2 = b[l2] - '0';
                int temp = i1 + i2 + carry;

                if (temp >= 2)
                {
                    current = temp % 2;
                    carry = 1;
                }
                else
                {
                    current = temp;
                    carry = 0;
                }


                buffer.Add(current.ToString());
                l1--;
                l2--;
            }

            while (l1 >= 0)
            {
                int i1 = a[l1] - '0';
                int temp = i1 + carry;

                if (temp > 1)
                {
                    current = 0;
                    carry = 1;
                }
                else
                {
                    current = temp;
                    carry = 0;
                }


                buffer.Add(current.ToString());
                l1--;
            }

            while (l2 >= 0)
            {
                int i2 = b[l2] - '0';
                int temp = i2 + carry;

                if (temp > 1)
                {
                    current = 0;
                    carry = 1;
                }
                else
                {
                    current = temp;
                    carry = 0;
                }


                buffer.Add(current.ToString());
                l2--;
            }

            if (carry > 0)
                buffer.Add("1");

            int l = buffer.Count;
            for (int i = 0; i < buffer.Count; i++)
            {
                builder.Append(buffer[l - 1 - i]);
            }

            return builder.ToString();


        }
    }
}
