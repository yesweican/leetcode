using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q383
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> dictNote = new Dictionary<char, int>();
            Dictionary<char, int> dictMagazine = new Dictionary<char, int>();

            char[] charMagazine = magazine.ToCharArray();
            for (int i = 0; i < magazine.Length; i++)
            {
                char c = charMagazine[i];
                if (!dictMagazine.ContainsKey(c))
                {
                    dictMagazine.Add(c, 1);
                }
                else
                {
                    dictMagazine[c]++;
                }
            }

            char[] charNote = ransomNote.ToCharArray();
            for (int i = 0; i < charNote.Length; i++)
            {
                char c = charNote[i];
                if (!dictNote.ContainsKey(c))
                {
                    dictNote.Add(c, 1);
                }
                else
                {
                    dictNote[c]++;

                }

                if (!dictMagazine.ContainsKey(c) || dictMagazine[c] < dictNote[c])
                    return false;

            }

            return true;
        }
    }
}
