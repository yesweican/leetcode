using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q244a
    {

        private readonly IDictionary<string, IList<int>> _dict;

        public q244a(string[] words)
        {
            _dict = new Dictionary<string, IList<int>>(words.Length);

            for (int i = 0; i < words.Length; i++)
            {
                if (!_dict.ContainsKey(words[i]))
                {
                    _dict[words[i]] = new List<int>();
                }
                _dict[words[i]].Add(i);
            }

        }

        public int Shortest(string word1, string word2)
        {
            var index1 = _dict[word1];
            var index2 = _dict[word2];
            int res = int.MaxValue;
            int l1 = 0;
            int l2 = 0;
            while (l1 < index1.Count && l2 < index2.Count)
            {
                res = Math.Min(res, Math.Abs(index1[l1] - index2[l2]));

                if (index1[l1] < index2[l2])
                {
                    l1++;
                }
                else
                {
                    l2++;
                }
            }
            return res;
        }

    }
}
