using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q049
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> results = new List<IList<string>>();
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            foreach (var s in strs)
            {
                char[] characters = s.ToCharArray();
                Array.Sort<char>(characters);
                string newstr = new string(characters);

                if (!dict.ContainsKey(newstr))
                {
                    dict.Add(newstr, new List<string>());
                }

                //succeeded without casting
                dict[newstr].Add(s);
            }

            foreach(var k in dict.Keys)
            {
                results.Add(dict[k]);
            }

            //succeeded without casting
            return results;
        }
    }
}
