using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q678
    {
        public bool CheckValidString(string s)
        {
            int l = s.Length;
            char[] characters = s.ToCharArray();

            int leftrestrict = 0;
            int leftloose = 0;

            for (int i = 0; i < l; i++)
            {
                if (characters[i] == '(')
                    leftrestrict++;
                else
                {
                    leftrestrict--;
                    if (leftrestrict < 0)
                        leftrestrict = 0;
                }


                if (characters[i] == '(' || characters[i] == '*')
                    leftloose++;
                else
                    leftloose--;

                if (leftloose < 0) return false;

            }

            return leftrestrict == 0;
        }
    }
}
