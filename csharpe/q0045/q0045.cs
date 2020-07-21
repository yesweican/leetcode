using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q045
    {
        ////////
        ///Jump Game II
        ////// 

        public int Jump(int[] nums)
        {
            int jump_count = 0;
            int last_reachable = 0;
            int reachable = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > reachable)
                    return -1;//if there is unclosable gap
                if (i > last_reachable)
                {
                    //the last index we could reach without additional jump
                    last_reachable = reachable;
                    jump_count += 1;

                }
                reachable = Math.Max(i + nums[i], reachable);
            }

            return jump_count;
        }
    }
}
