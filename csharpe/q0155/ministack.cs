    public class SimpleStack
    {
        int[] data = new int[10000];
        private int currentTopIndex = -1;

        public void Push(int newitem)
        {
            if (currentTopIndex < 9999)
            {
                currentTopIndex++;
                data[currentTopIndex] = newitem;
                //return true;
            }
        }

        public void Pop()
        {

            if (currentTopIndex > -1)
                currentTopIndex--;

                return;
        }

        public bool IsEmpty()
        {
            return currentTopIndex < 0 ? true: false;
        }

        public int Top()
        {
            if (currentTopIndex > -1)
                return data[currentTopIndex];
            else
                return int.MinValue;
        }
    }

    public class MinStack
    {
        SimpleStack datastack = new SimpleStack();
        SimpleStack assiststack = new SimpleStack();

        public void Push(int newitem)
        {
            datastack.Push(newitem);
            if (assiststack.IsEmpty())
            {
                assiststack.Push(newitem);
            }
            else
            {
                int temp = assiststack.Top();
                if (temp < newitem)
                {
                    assiststack.Push(temp);
                }
                else
                {
                    assiststack.Push(newitem);
                }
            }
        }

        public void Pop()
        {
            datastack.Pop();
            assiststack.Pop();
        }

        public bool isEmpty()
        {
            return datastack.IsEmpty();
        }

        public int Top()
        {
            return datastack.Top();
        }

        public int Min()
        {
            return assiststack.Top();
        }

        public int GetMin()
        {
            int top = datastack.Top();
            int min = assiststack.Top();
            //Console.WriteLine("getting Min {0}:{1}", top, min);
            return min;
        }
    }