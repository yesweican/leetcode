using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge05
{
    public class q342
    {
        public bool IsPowerOfFour(int num)
        {
            if (num == 0)
                return false;

            while(num>0)
            {
                int temp = num & 3;
                if (temp != 0)
                {
                    if (num != 1)
                        return false;
                    else
                        return true;
                }
                else
                {
                    num >>= 2;
                }
            }

            //either way should not get here
            return false;

        }


    }
}
