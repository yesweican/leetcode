using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q452
    {
        Dictionary<char, int> map;
        public string FrequencySort(string s)
        {
            map = new Dictionary<char, int>();
            char[] characters = s.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                char c= characters[i];
                if (!map.Keys.Contains(c))
                {
                    map.Add(c, 1);
                }
                else
                {
                    map[c]++;
                }
            }

            var list = map.OrderBy(x => x.Value).Reverse().ToArray();

            StringBuilder builder = new StringBuilder();
            for(int i=0; i<list.Length; i++)
            {
                var item = list[i];
                for(int j=0; j<item.Value; j++)
                {
                    builder.Append(item.Key);
                }
            }

            return builder.ToString();
        }
    }
}
