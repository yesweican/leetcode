using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q901a
    {

        Stack<int> mainStack;
        Stack<int> buffer;
        public q901a()
        {
            mainStack = new Stack<int>();
            buffer = new Stack<int>();
        }

        public int Next(int price)
        {
            int counter = 1;
            while ((mainStack.Count > 0) && (mainStack.Peek() <= price))
            {
                counter++;
                buffer.Push(mainStack.Pop());
            }
            while (buffer.Count > 0)
            {
                mainStack.Push(buffer.Pop());
            }
            mainStack.Push(price);
            return counter;
        }
    }
}
