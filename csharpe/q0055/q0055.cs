using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q055
    {
        /// <summary>
        /// Jump Game
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanJump(int[] nums)
        {
            int reachable = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > reachable)
                    return false;//if there is unclosable gap
                reachable = Math.Max(i + nums[i], reachable);
            }

            return reachable >= (nums.Length - 1);
        }
    }
}
