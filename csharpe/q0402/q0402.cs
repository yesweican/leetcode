using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q402
    {
        public string RemoveKdigits(string num, int k)
        {
            char[] origChars = num.ToCharArray();
            Stack<char> buffer = new Stack<char>();

            for (int i = 0; i < origChars.Length; i++)
            {
                char c = origChars[i];
                if ((buffer.Count == 0) || (buffer.Peek() <= c) || (k == 0))
                    buffer.Push(c);
                else
                {
                    while ((k > 0) && (buffer.Count > 0) && (buffer.Peek() > c))
                    {
                        buffer.Pop();
                        k--;
                    }

                    buffer.Push(c);
                }
            }

            while ((k > 0) && (buffer.Count > 0))
            {
                buffer.Pop();
                k--;//don't forget
            }

            if (buffer.Count == 0)
                return "0";

            //use second stack to reverse the string
            Stack<char> buffer2 = new Stack<char>();
            while (buffer.Count > 0)
            {
                buffer2.Push(buffer.Pop());
            }
            //remove the leading '0' if necessary
            while ((buffer2.Count > 0) && (buffer2.Peek() == '0'))
            {
                buffer2.Pop();
            }

            if (buffer2.Count == 0)
                return "0";

            StringBuilder builder = new StringBuilder();
            while (buffer2.Count > 0)
            {
                builder.Append(buffer2.Pop());
            }
            string temp = builder.ToString();
            return temp;
        }
    }
}
