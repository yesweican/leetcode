using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    //Is Subsequence
    public class q392
    {
        public bool IsSubsequence(string s, string t)
        {
            if (s.Length == 0)
                return true;
            if (s.Length > t.Length)
                return false;

            return recursive(s, t,0, s.Length, 0, t.Length);
        }

        private bool recursive(string s, string t, int sleft, int sright, int tleft, int tright)
        {
            if (sright-sleft>0)
            {
                while (t[tleft] != s[sleft] && tleft<tright)
                    tleft++;
                while (t[tright] != s[sright] && tleft<tright)
                    tright--;

                if (tleft >= tright)
                    return false;

                //if last two matches
                if ((tright - tleft)==1 && (sright-sleft)==1)
                    return true;
                //tright-tleft>1
                return recursive(s, t, sleft + 1, sright - 1, tleft + 1, tright - 1);
            }
            else//sleft==sright
            {
                //search for the last character
                while (tleft <= tright)
                {
                    if (s[sleft] == t[tleft])
                        return true;

                    tleft++;
                }
            }

            return false;
        }
    }
}
