using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Stack with Queues
    /// </summary>
    public class q225
    {
        Queue<int> q1;//stack head;
        Queue<int> q2;//buffer;
        /** Initialize your data structure here. */
        int stacksize;
        /** Initialize your data structure here. */
        public q225()
        {
            q1 = new Queue<int>();
            q2 = new Queue<int>();

            stacksize = 0;
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            if (q1.Count == 0)
            {
                q1.Enqueue(x);
                stacksize++;
            }
            else
            {
                q2.Enqueue(x);
                while (q1.Count > 0)
                {
                    //assuming q1 order already reverse
                    q2.Enqueue(q1.Dequeue());
                }

                Queue<int> temp = q1;
                q1 = q2;
                q2 = temp;
                stacksize++;
            }
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            if (stacksize > 0)
            {
                stacksize--;
                return q1.Dequeue();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /** Get the top element. */
        public int Top()
        {
            return q1.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return (stacksize == 0);
        }
    }
}
