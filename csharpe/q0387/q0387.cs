using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q387
    {
        /// <summary>
        /// Complexity is O(N)=2N
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> journal = new Dictionary<char, int>();
            char[] characters = s.ToCharArray();

            for (int i = 0; i < characters.Length; i++)
            {
                if (journal.ContainsKey(characters[i]))
                {
                    //second or more occurrence, set value to -1
                    journal[characters[i]] = -1;
                }
                else
                {
                    journal.Add(characters[i], i);
                }
            }

            int min = int.MaxValue;
            foreach (var k in journal.Keys)
            {
                if (journal[k] != -1)
                {
                    if (min > journal[k])
                        min = journal[k];
                }
            }

            return min == int.MaxValue ? -1 : min;
        }
    }
}
