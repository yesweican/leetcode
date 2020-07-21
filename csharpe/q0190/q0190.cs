using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Reverse Bits
    /// </summary>
    public class q190
    {
        public uint reverseBits(uint n)
        {
            uint result = 0;
            uint current = 1;

            current <<= 31;

            for (int i = 0; i < 32; i++)
            {
                uint temp = (n & 1);
                if (temp == 1)
                {
                    result = result + current;
                }

                current >>= 1;
                n >>= 1;
            }

            return result;

        }
    }
}
