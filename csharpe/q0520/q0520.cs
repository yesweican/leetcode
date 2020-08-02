using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge05
{
    public class q520
    {
        public bool DetectCapitalUse(string word)
        {
            string word1 = word.ToUpper();
            string word2 = word.ToLower();
            string word3 = UppercaseFirst(word2);

            if ((word == word1) || (word == word2) || (word == word3))
                return true;

            return false;
        }

        private string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
