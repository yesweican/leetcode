public class LRUCache {
        private Dictionary<int, LRUCacheItem> _dict = new Dictionary<int, LRUCacheItem>();
        int _capacity = 0;
        int _currentCount = 0;

        LRUCacheItem _head = null;
        LRUCacheItem _tail = null;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _currentCount = 0;
        }


        public int Get(int key)
        {
            if (_dict.ContainsKey(key))
            {
                //call touch key
                Touch(key);
                return _dict[key].value;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if (_dict.ContainsKey(key))
            {
                //Set instead of insert
                _dict[key].value = value;

                Touch(key);
                return;
            }


            if (_currentCount < _capacity)
            {
                //add to the Doubly linked list
                LRUCacheItem item = new LRUCacheItem();
                item.key = key; 
                item.value = value;
                item.next = null; //by default
                item.previous = null;//by default

                _dict.Add(key, item);

                if (_head == null)
                {
                    //very very first item
                    _head = item;
                    _tail = item;
                }
                else
                {
                    //add to the front
                    item.next = _head;
                    _head.previous = item;
                    _head = item;
                }

                _currentCount++;
            }
            else
            {
                //Reached Capacity
                //find the least recent used item
                int tailkey = _tail.key;
                //remove it from Doubly Linked List
                LRUCacheItem prev = _tail.previous;
                if (prev != null)
                {
                    prev.next = null;
                    _tail = prev;
                }
                else
                {
                    //to handle 1 capacity 
                    _tail = null;
                }


                //remove it from dict
                _dict.Remove(tailkey);
                _currentCount--;

                //try again
                Put(key, value);

            }

        }


        private void Touch(int key)
        {

            LRUCacheItem item = _dict[key];

            if (item == _head)
            {
                //do nothing
            }
            else
            {
                LRUCacheItem prev = item.previous;
                LRUCacheItem nex = item.next;
                prev.next = nex;

                if (nex == null)
                    _tail = prev;
                else
                    nex.previous = prev;

                item.next = _head;
                item.previous = null;
                _head.previous = item;
                _head = item;
            }
        }
}

    public class LRUCacheItem
    {
        public int key { get; set; }
        public int value { get; set; }
        public LRUCacheItem next { get; set; }
        public LRUCacheItem previous { get; set; }
    }

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */