using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q186
    {
        public void ReverseWords(char[] s)
        {
            process(s, 0, s.Length - 1);

            int wordstart = 0; int cur = 0;
            int wordend = 0;
            while (cur < s.Length)
            {
                if (s[cur] == ' ')
                {
                    wordend = cur - 1;
                    process(s, wordstart, wordend);
                    wordstart = cur + 1; wordend = wordstart;
                }
                cur++;
            }
            if (wordstart < cur)
            {
                wordend = cur - 1;
                process(s, wordstart, wordend);
            }
        }

        private void process(char[] s, int start, int end)
        {
            while (start < end)
            {
                char tmp = s[start];
                s[start] = s[end];
                s[end] = tmp;
                start++;
                end--;
            }
        }
    }
}
