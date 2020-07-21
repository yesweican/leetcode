using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class q476
    {
        public int FindComplement(int num)
        {
            int num2 = num;
            Stack<int> stack = new Stack<int>();

            int temp = 1;
            while (num2>0)
            {
                if((num2 & 1)==1)
                {
                    stack.Push(0);

                }
                else
                {
                    stack.Push(temp);
                }

                num2 = num2 >> 1;

                temp = temp * 2;
            }

            int result=0;
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;

        }
    }
}
