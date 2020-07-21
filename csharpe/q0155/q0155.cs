using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q155
    {
        /** initialize your data structure here. */
        Stack<int> data;
        Stack<int> mindata;
        int currentminimum;

        public q155()
        {
           data=new Stack<int>();
            mindata=new Stack<int>();
            currentminimum=int.MaxValue;
        }
    
        public void Push(int x) {
            data.Push(x);
            currentminimum=(x<currentminimum) ? x: currentminimum;
            mindata.Push(currentminimum);
        }
    
        public void Pop() {
            data.Pop();
            mindata.Pop();
            if(mindata.Count>0)
                currentminimum=mindata.Peek();
            else
                currentminimum=int.MaxValue;
        }
    
        public int Top() {
            return data.Peek();
        }
    
        public int GetMin() {
            return currentminimum;
        }

    }
}
