using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q017
    {
        List<string> results;
        Dictionary<int, char[]> map;
        public IList<string> LetterCombinations(string digits)
        {
            map = new Dictionary<int, char[]>();
            map.Add(0, new char[]{ ' ' });
            map.Add(1, new char[] { });
            map.Add(2, new char[] { 'a','b', 'c' });
            map.Add(3, new char[] { 'd', 'e', 'f' });
            map.Add(4, new char[] { 'g', 'h', 'i' });
            map.Add(5, new char[] { 'j', 'k', 'l' });
            map.Add(6, new char[] { 'm', 'n', 'o' });
            map.Add(7, new char[] { 'p', 'q', 'r' , 's'});
            map.Add(8, new char[] { 't', 'u', 'v' });
            map.Add(9, new char[] { 'w', 'x', 'y', 'z' });

            results = new List<string>();

            if (digits.Length == 0)
                return results;

            dfs(digits, 0, "");
            return results;

        }

        private void dfs(string digits, int index, string prefix)
        {
            if (index >= digits.Length)
                return;

            int digit = digits[index] - '0';

            if (map[digit].Length > 0)
            {
                foreach(var v in map[digit])
                {
                    string temp = prefix + v.ToString();

                    if (index == (digits.Length - 1))
                        results.Add(temp);
                    else
                        dfs(digits, index + 1, temp);
                }
            }
            else
            {
                dfs(digits, index + 1, prefix);
            }

        }
    }
}
