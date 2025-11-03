public class MedianFinder {
    MaxHeap leftHeap;
    MinHeap rightHeap;
    

    public MedianFinder() {
        leftHeap = new MaxHeap(100000);
        rightHeap = new MinHeap(100000);
        
    }
    
    public void AddNum(int num) {

        if(leftHeap.Size>0)//keep left size>right size
        {
            int temp = (int)leftHeap.Peek();
            if(temp<num)
            {
                rightHeap.Add(num);
            }
            else
            {
                leftHeap.Add(num);
            }
        }
        else //left size empty, ad First #
        {
            leftHeap.Add(num);
        }
        
        if(leftHeap.Size>(rightHeap.Size+1))
        {
            int temp3 = (int)leftHeap.Peek();
            leftHeap.Poll();
            rightHeap.Add(temp3);
        }
        
        if(rightHeap.Size>leftHeap.Size)
        {
            int temp4 = (int)rightHeap.Peek();
            rightHeap.Poll();
            leftHeap.Add(temp4);
        }
    }
    
    public double FindMedian() {
        if(leftHeap.Size > rightHeap.Size)
        {
            return (double)leftHeap.Peek();
        }
        else
        {
            double v1 = (double)leftHeap.Peek();
            double v2 = (double)rightHeap.Peek();
            return (v1+v2)/2;
        }
    }
}

    public class MaxHeap
    {
        private int capacity;
        private int size = 0;
        private int[] heap;

        public MaxHeap(int capacity)
        {
            this.capacity = capacity;
            this.heap = new int[capacity];
        }

        public int Size // read-only property
        {
            get { return size; }
            // set { size = value; }
        }

        private int getLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int getRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private int getParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private bool hasLeftChild(int index)
        {
            return getLeftChildIndex(index) < size;
        }

        private bool hasRightChild(int index)
        {
            return getRightChildIndex(index) < size;
        }

        private bool hasParent(int index)
        {
            return getParentIndex(index) >= 0;
        }

        private int leftChild(int parentIndex)
        {
            return heap[getLeftChildIndex(parentIndex)];
        }

        private int rightChild(int parentIndex)
        {
            return heap[getRightChildIndex(parentIndex)];
        }

        private int parent(int childIndex)
        {
            return heap[getParentIndex(childIndex)];
        }

        private void swap(int index1, int index2)
        {
            int element = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = element;
        }

        // Time Complexity : O( Log n)
        public void Add(int item)
        {
            ////ensureCapacity();
            if (size == capacity)
            {
                if (item >= heap[0])
                    return;
                else //item < heap[0]
                {
                    Poll();
                }
            }

            heap[size] = item;
            size++;
            heapifyUp();
        }


        // Time Complexity : O(1)
        public int? Peek()
        {
            if (size == 0)
            {
                return null;
            }
            return heap[0];
        }

        // Time Complexity : O( Log n)
        //remove the first element
        public void Poll()
        {
            if (size == 0)
            {
                return ;
            }

            int element = heap[0];

            heap[0] = heap[size - 1];
            size--;
            heapifyDown();
        }

        private void heapifyDown()
        {
            int index = 0;

            while (hasLeftChild(index))
            {
                /// When HeapifyDown for MaxHeap
                /// We compare to the bigger/larger Child
                int biggerChildIndex = getLeftChildIndex(index);

                if (hasRightChild(index) && (rightChild(index) > leftChild(index)))
                {
                    biggerChildIndex = getRightChildIndex(index);
                }
                /// Then swap if necessary
                if (heap[index] < heap[biggerChildIndex])
                {
                    swap(index, biggerChildIndex);
                }
                else
                {
                    break;
                }
                index = biggerChildIndex;
            }
        }

        private void heapifyUp()
        {
            int index = size - 1;

            while (hasParent(index) && parent(index) < heap[index])
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }
    }

    public class MinHeap
    {
        private int capacity;
        private int size = 0;
        private int[] heap;

        public MinHeap(int capacity)
        {
            this.capacity = capacity;
            this.heap = new int[capacity];
        }

        public int Size // read-only property
        {
            get { return size; }
            // set { size = value; }
        }

        private int getLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int getRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private int getParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private bool hasLeftChild(int index)
        {
            return getLeftChildIndex(index) < size;
        }

        private bool hasRightChild(int index)
        {
            return getRightChildIndex(index) < size;
        }

        private bool hasParent(int index)
        {
            return getParentIndex(index) >= 0;
        }

        private int leftChild(int parentIndex)
        {
            return heap[getLeftChildIndex(parentIndex)];
        }

        private int rightChild(int parentIndex)
        {
            return heap[getRightChildIndex(parentIndex)];
        }

        private int parent(int childIndex)
        {
            return heap[getParentIndex(childIndex)];
        }

        private void swap(int index1, int index2)
        {
            int element = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = element;
        }

        // Time Complexity : O( Log n)
        public void Add(int item)
        {
            ////ensureCapacity();
            if (size == capacity)
            {
                if (item >= heap[0])
                    return;
                else //item < heap[0]
                {
                    Poll();
                }
            }

            heap[size] = item;
            size++;
            heapifyUp();
        }

        // Time Complexity : O(1)
        public int? Peek()
        {
            if (size == 0)
            {
                return null;
            }
            return heap[0];
        }

        // Time Complexity : O( Log n)
        //remove the first element
        public void Poll()
        {
            if (size == 0)
            {
                return ;
            }

            int element = heap[0];

            heap[0] = heap[size - 1];
            size--;
            heapifyDown();
        }

        private void heapifyDown()
        {
            int index = 0;

            while (hasLeftChild(index))
            {
                /// When HeapifyDown for MinHeap
                /// We compare to the smaller/lesser Child
                int smallerChildIndex = getLeftChildIndex(index);

                if (hasRightChild(index) && (rightChild(index) < leftChild(index)))
                {
                    smallerChildIndex = getRightChildIndex(index);
                }
                /// Then swap if necessary
                if (heap[index] > heap[smallerChildIndex])
                {
                    swap(index, smallerChildIndex);
                }
                else
                {
                    break;
                }
                index = smallerChildIndex;
            }
        }

        private void heapifyUp()
        {
            int index = size - 1;

            while (hasParent(index) && parent(index) > heap[index])
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }
    }

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */