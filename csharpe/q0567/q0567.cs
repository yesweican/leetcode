using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// This is a simpler version of the question 438
    /// also swapped the two parameters
    /// </summary>
    public class q567
    {
        Dictionary<char, int> map;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s1">Shorter String</param>
        /// <param name="s2">Longer String</param>
        /// <returns></returns>
        public bool CheckInclusion(string s1, string s2)
        {

            if (s1.Length > s2.Length)
                return false;

            map = new Dictionary<char, int>();
            char[] characters = s1.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                char c = characters[i];
                if (!map.Keys.Contains(c))
                    map.Add(c, 1);
                else
                    map[c] = map[c] + 1;
            }

            char[] characters2 = s2.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                char c = characters2[i];
                if (map.Keys.Contains(c))
                    map[c] = map[c] - 1;
            }

            if (IsAnagram(map))
                return true;

            int left = 0; int right = s1.Length - 1;
            while (left < (s2.Length - s1.Length))
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
                    return true;
            }

            return false;

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
