using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q1119
    {
        public string RemoveVowels(string S)
        {
            char[] characters = S.ToCharArray();
            string vowels = "aeiou";
            StringBuilder builder = new StringBuilder();
            for (int i=0; i < characters.Length; i++)
            {
                if (!vowels.Contains(characters[i]))
                {
                    builder.Append(characters[i]);
                }
            }
            return builder.ToString();
        }
    }
}
