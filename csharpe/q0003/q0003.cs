using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q003
    {
        /// <summary>
        /// Better sliding Window solution.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            char[] characters = s.ToCharArray();
            int front = 0;
            int back = 0;
            HashSet<char> set = new HashSet<char>();
            int max = 0;

            int counter = 0;

            while (front <= (characters.Length - 1))
            {
                char c = characters[front];
                if (!set.Contains(c))
                {
                    set.Add(c);
                    counter++;
                    if (max < counter)
                        max = counter;
                }
                else
                {
                    //search for the prvious C
                    while (characters[back] != c)
                    {
                        char c2 = characters[back];
                        set.Remove(c2);
                        back++;
                        counter--;
                    }
                    back++;
                }

                front++;
            }

            return max;

        }
    }
}
