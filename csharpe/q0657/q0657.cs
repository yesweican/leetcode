using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q657
    {
        public bool JudgeCircle(string moves)
        {
            char[] characters = moves.ToCharArray();

            int x = 0, y = 0;
            for (int i = 0; i < characters.Length; i++)
            {
                switch (characters[i])
                {
                    case 'U': y++; break;
                    case 'D': y--; break;
                    case 'L': x--; break;
                    case 'R': x++; break;
                }
            }
            if ((x == 0) && (y == 0))
                return true;

            return false;
        }
    }
}
