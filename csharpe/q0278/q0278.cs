using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q278
    {

        private bool IsBadVersion(int n)
        {
            return true;
        }
        public int FirstBadVersion(int n)
        {
            int lower = 1;
            int top = n;
            int lastbad = n;

            if (IsBadVersion(1))
                return 1;

            while (lower <= top)
            {
                int middle = lower + (top - lower) / 2;
                if (IsBadVersion(middle))
                {
                    lastbad = middle;
                    top = middle - 1;
                }
                else
                    lower = middle + 1;

            }

            return lastbad;
        }
    }
}
