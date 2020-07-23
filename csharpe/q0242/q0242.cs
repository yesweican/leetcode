using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Valid Anagram
    /// </summary>
    public class q242
    {
        public bool IsAnagram(string s, string t)
        {

            char[] characters1 = s.ToCharArray();
            char[] characters2 = t.ToCharArray();

            if (characters1.Length != characters2.Length)
                return false;

            Array.Sort<char>(characters1);
            string temp = new string(characters1);
            Array.Sort<char>(characters2);
            string temp2 = new string(characters2);

            if (temp == temp2)
                return true;

            return false;
        }
    }
}
