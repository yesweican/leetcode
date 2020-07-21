using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    //HashTable/Dictionary + Sliding Window Method!  
    public class q438
    {
        Dictionary<char, int> map;
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> result = new List<int>();
            if (s.Length < p.Length)
                return result;

            map = new Dictionary<char, int>();
            char[] characters = p.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                char c = characters[i];
                if (!map.Keys.Contains(c))
                    map.Add(c, 1);
                else
                    map[c] = map[c] + 1;
            }

            char[] characters2 = s.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                char c = characters2[i];
                if (map.Keys.Contains(c))
                    map[c] = map[c] - 1;
            }

            if (IsAnagram(map))
                result.Add(0);

            int left = 0; int right = p.Length - 1;
            while (left < (s.Length - p.Length))
            {
                char c1 = characters2[left];
                //needed character count increase!
                if (map.Keys.Contains(c1))
                    map[c1] = map[c1] + 1;
                char c2 = characters2[right + 1];
                //needed character count decrease!
                if (map.Keys.Contains(c2))
                    map[c2] = map[c2] - 1;

                left++;
                right++;

                if (IsAnagram(map))
                    result.Add(left);
            }

            return result;

        }

        private bool IsAnagram(Dictionary<char, int> map)
        {
            foreach (var v in map)
            {
                if (v.Value > 0)
                    return false;
            }

            return true;
        }
    }
}
