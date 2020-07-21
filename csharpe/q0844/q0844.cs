using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q844
    {
        public bool BackspaceCompare(string S, string T)
        {
            string str1 = convertString(S);
            string str2 = convertString(T);

            if (str1 == str2)
                return true;

            return false;
        }

        private string convertString(string Str)
        {
            char[] characters = Str.ToCharArray();
            Stack<char> stack=new Stack<char>();

            for (int i = 0; i < characters.Length; i++)
            {
                stack.Push(characters[i]);
            }

            int throwawayCount=0;
            Stack<char> stack2 = new Stack<char>();
            while (stack.Count > 0)
            {
                char c = stack.Pop();

                if (c == '#')
                    throwawayCount++;
                else
                {
                    if (throwawayCount == 0)
                        stack2.Push(c);
                    else
                        throwawayCount--;
                }
            }

            StringBuilder builder = new StringBuilder();
            while (stack2.Count > 0)
            {
                builder.Append(stack2.Pop());
            }
            return builder.ToString();
        }
    }
}
