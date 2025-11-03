public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
             List<int>results= new List<int>();  
            Deque<int>q = new Deque<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                while (q.Size() > 0 && nums[q.PeekRear()] < nums[i])
                    q.PopRear();
                q.PushRear(i);

                if (q.PeekFront() <= (i - k))
                    q.PopFront();

                if (i >= k - 1)
                    results.Add(nums[q.PeekFront()]);
            }
            return results.ToArray();       
    }
}

public class Deque<T>
{
    // ListItem of a doubly linked list
    class ListItem
    {
        public T data;
        public ListItem? prev, next;

        public ListItem(T input)
        {
            data = input;
            prev = null;
            next = null;
        }
    }

    ListItem? front, rear;
    int size; // Corrected the name to 'size'

    public Deque()
    {
        front = rear = null;
        size = 0;
    }

    // Operations on Deque
    public void PushFront(T data)
    {
        ListItem newListItem = new ListItem(data);

        if (front == null)
            rear = front = newListItem;
        else
        {
            newListItem.next = front;
            front.prev = newListItem;
            front = newListItem;
        }
        size++;
    }

    public void PushRear(T data)
    {
        ListItem newListItem = new ListItem(data);

        if (rear == null)
            front = rear = newListItem;
        else
        {
            newListItem.prev = rear;
            rear.next = newListItem;
            rear = newListItem;
        }
        size++;
    }

    public T PopFront()
    {
        if (IsEmpty())
        {
            Console.WriteLine("UnderFlow");
            throw new Exception("underflow");
        }

        else
        {
            ListItem temp = front;
            front = front.next;
            if (front == null)
                rear = null;
            else
                front.prev = null;
            size--;
            //Free(temp);
            return temp.data;
        }
    }

    public T PopRear()
    {
        if (IsEmpty())
        {
            Console.WriteLine("UnderFlow");
            throw new Exception("underflow");
        }
        else
        {
            ListItem temp = rear;
            rear = rear.prev;
            if (rear == null)
                front = null;
            else
                rear.next = null;
            size--;
            //Free(temp);
            return temp.data;
        }
    }
    
    public T PeekFront()
    {
        if (IsEmpty())
        {
            Console.WriteLine("UnderFlow");
            throw new Exception("underflow");
        }
        return front.data;
    }

    public T PeekRear()
    {
        if (IsEmpty())
        {
            Console.WriteLine("UnderFlow");
            throw new Exception("underflow");
        }
        return rear.data;
    }

    public int Size() // Corrected the name to 'Size'
    {
        return size;
    }

    public bool IsEmpty()
    {
        return (front == null);
    }

}