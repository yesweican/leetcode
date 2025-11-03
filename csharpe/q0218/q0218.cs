public class Solution {
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        List<IList<int>> answers = new List<IList<int>>();

        List<Event> events = new List<Event>();
        List<Building> buildingList = new List<Building>();

        for(int i=0; i<buildings.Length; i++)
        {
            int x = buildings[i][0];
            int y = buildings[i][1];
            int h = buildings[i][2];
            Event t1 = new Event() { Loc = x, Key = i, Type = 0, Height = h };
            events.Add(t1);
            Event t2 = new Event() { Loc = y, Key = i, Type = 1, Height = -h };
            events.Add(t2);

            Building b = new Building() { Key = i, Value = h };
            buildingList.Add(b);
        }

        var sortedEvents = events.OrderBy(x => x.Loc).ThenByDescending(x => x.Height);
        BuildingMaxHeap maxHeap = new BuildingMaxHeap(10001);

        foreach(var v in sortedEvents)
        {
            if(maxHeap.Size==0)
            {
                //could be end event? No?
                //Add Building to the Heap
                maxHeap.add(buildingList[v.Key]);
                //Add to the answers
                List<int> temp = new List<int>();
                temp.Add(v.Loc);
                temp.Add(v.Height);
                answers.Add((IList<int>)temp);
            }
            else
            {
                if(v.Type==0)
                {
                    //if the height is higher than the maxHeight
                    Building currentMax = maxHeap.peek();
                    //Add to the answer, 
                    if(v.Height>currentMax.Value)
                    {
                        List<int> temp = new List<int>();
                        temp.Add(v.Loc);
                        temp.Add(v.Height);
                        answers.Add((IList<int>)temp);
                    }
                    //adding to the Heap
                    maxHeap.add(buildingList[v.Key]);
                }
                else // v.Type==1, end events
                {
                    //is it the current highest building
                    Building currentMax = maxHeap.peek();

                    int height1 = currentMax.Value;
                    int height2 = 0;

                    if(buildingList[v.Key].Value < height1)
                    {
                        //IF not simply remove from the heap by the Key
                        maxHeap.RemoveByKey(v.Key);
                    }
                    else
                    {
                        //if removing the earlier highest
                        if (v.Key == currentMax.Value)
                        {
                            //remove from top
                            maxHeap.poll();
                        }
                        else
                        {
                            //IF not simply remove from the heap by the Key
                            maxHeap.RemoveByKey(v.Key);
                        }
                        if(maxHeap.Size>0)
                        {
                            Building secondMax = maxHeap.peek();
                            height2 = secondMax.Value;
                        }
                        //else
                        //IF the Heap Empty second height = 0;
                        //else get the new height as second height
                        //Add an entry for the answers
                        if(height2<height1)
                        {
                            List<int> temp = new List<int>();
                            temp.Add(v.Loc);
                            temp.Add(height2);
                            answers.Add((IList<int>)temp);
                        }
                    }
                }
            }
        }

        return answers;        
    }
}

public class Building:IComparable 
{
        public int Key { get; set; }
        //height
        public int Value { get; set; }

        public int CompareTo(object obj)
        {
            if(!(obj is Building))
                throw new NotImplementedException();
            Building temp = (Building)obj;
            if (this.Value > temp.Value)
                return 1;
            else
            {
                if (this.Value == temp.Value)
                    return 0;
                return -1;
            }
        }
}

public class Event
{
        public int Key { get; set; }
        public int Loc { get; set; }
        //positive or negative based on type
        public int Height { get; set; }
        public int Type { get; set;  }
}

public class BuildingMaxHeap
{
        private int capacity;
        private int size = 0;
        private Building[] heap;
        private int maxHeight = Int32.MaxValue;

        public BuildingMaxHeap(int capacity)
        {
            this.capacity = capacity;
            this.heap = new Building[capacity];
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

        private Building leftChild(int parentIndex)
        {
            return heap[getLeftChildIndex(parentIndex)];
        }

        private Building rightChild(int parentIndex)
        {
            return heap[getRightChildIndex(parentIndex)];
        }

        private Building parent(int childIndex)
        {
            return heap[getParentIndex(childIndex)];
        }

        private void swap(int index1, int index2)
        {
            Building element = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = element;
        }

        // Time Complexity : O( Log n)
        public void add(Building item)
        {
            ////ensureCapacity();
            if (size == capacity)
            {
                if (item.CompareTo(heap[0])>=0)
                    return;
                else //item < heap[0]
                {
                    poll();
                }
            }

            heap[size] = item;
            size++;
            heapifyUp(size-1);
        }

        //private void ensureCapacity()
        //{
        //    if (size == capacity)
        //    {
        //        int[] newHeap = new int[capacity * 2];

        //        Array.Copy(heap, newHeap, heap.Length);
        //        capacity = capacity * 2;
        //        heap = newHeap;
        //    }
        //}

        // Time Complexity : O(1)
        public Building peek()
        {
            if (size == 0)
            {
                throw new NotImplementedException();
            }
            return heap[0];
        }

        // Time Complexity : O( Log n)
        //remove the first element
        public void poll()
        {
            if (size == 0)
            {
                return ;
            }

            Building element = heap[0];

            heap[0] = heap[size - 1];
            size--;
            heapifyDown(0);
            Console.WriteLine("After Polling...");
            //printHeap();
        }

        private void heapifyDown(int index)
        {
            while (hasLeftChild(index))
            {
                /// When HeapifyDown for MaxHeap
                /// We compare to the bigger/larger Child
                int biggerChildIndex = getLeftChildIndex(index);

                if (hasRightChild(index) && (rightChild(index).CompareTo(leftChild(index))>0))
                {
                    biggerChildIndex = getRightChildIndex(index);
                }
                /// Then swap if necessary
                if (heap[index].CompareTo(heap[biggerChildIndex])<0)
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

        private void heapifyUp(int index)
        {
            //int index = size - 1;

            while (hasParent(index) && parent(index).CompareTo(heap[index])<0)
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }

        //public void printHeap()
        //{
        //    for (int i = 0; i < size; i++)
        //    {
        //        Console.Write(heap[i] + " ");
        //    }

        //    Console.WriteLine();
        //}

        /// <summary>
        /// Find by the Unique key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool RemoveByKey(int key)
        {
            bool found = false;
            int pos = -1;
            //Find Building by key - position/index inside the Heap
            for (int i = 0; i < size; i++)
            {
                if (heap[i].Key == key)
                {
                    found = true;
                    pos = i;
                    break;
                }
            }
            //Could you use BinarySearch here? NO
            if (found == false)
                return false;
            //Remove the found Building
            Building temp = heap[pos];
            int originalHeight = heap[pos].Value;
            heap[pos].Value = maxHeight;
            heapifyUp(pos);
            poll();
            temp.Value = originalHeight;
            return true;
        }
    }
