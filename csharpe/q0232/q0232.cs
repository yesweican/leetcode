public class MyQueue {
        Stack<int> s1;//where we get data out
        Stack<int> s2;//buffer
        int queuesize;
    /** Initialize your data structure here. */
    public MyQueue() {
          s1=new Stack<int>();
          s2=new Stack<int>();

          queuesize = 0;        
    }
    
    /** Push element x to the back of queue. */
    public void Push(int x) {
            while (s1.Count > 0)
            {
                s2.Push(s1.Pop());
            }
            s1.Push(x);

            while (s2.Count>0)
            {
                s1.Push(s2.Pop());
            }

            queuesize++;        
    }
    
    /** Removes the element from in front of queue and returns that element. */
    public int Pop() {
            queuesize--;            
            return s1.Pop();        
    }
    
    /** Get the front element. */
    public int Peek() {
            return s1.Peek();        
    }
    
    /** Returns whether the queue is empty. */
    public bool Empty() {
            return queuesize == 0;        
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
