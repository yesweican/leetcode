using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Not Good enough Method
    /// </summary>
    public class q438a
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> result = new List<int>();
            for(int i=0; i<(s.Length-p.Length+1); i++)
            {
                string s0 = s.Substring(i, p.Length);
                if (IsAnagram(s0, p))
                    result.Add(i);
            }
            return result;
        }

        private bool IsAnagram(string s, string t)
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
