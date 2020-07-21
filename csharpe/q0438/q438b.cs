using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q438b
    {
        HashSet<string> set;
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> indexes = new List<int>();
            set = new HashSet<string>();

            List<string> permutations = generatePermutation(p);
            foreach (var perm in permutations)
            {
                if (!set.Contains(perm))
                {
                    set.Add(perm);

                    int start = 0;
                    while (start <= (s.Length - 1))
                    {
                        int temp = s.IndexOf(perm, start);
                        if (temp != -1)
                        {
                            indexes.Add(temp);
                        }

                        start = temp + 1;
                    }
                }
            }

            return indexes;
        }

        private List<string> generatePermutation(string p)
        {
            List<string> result = new List<string>();

            if (p.Length > 1)
            {
                char c = p[0];
                List<string> list = generatePermutation(p.Substring(1));

                for (int i = 0; i < list.Count; i++)
                {
                    string s = list[i];
                    for (int j = 0; j <= list[0].Length; j++)
                    {
                        result.Add(s.Insert(j, c.ToString()));
                    }
                }
            }
            else
            {
                result.Add(p);
            }

            return result;
        }
    }
}
