using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q540
    {
        public int SingleNonDuplicate(int[] nums)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if ((stack.Count == 0) || (nums[i] != stack.Peek()))
                    stack.Push(nums[i]);
                else
                    stack.Pop();
            }

            int temp = stack.Pop();
            return temp;
        }

    }
}
