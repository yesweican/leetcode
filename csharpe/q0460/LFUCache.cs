public class LFUCache {

        private Dictionary<int, LFUCacheItem> _dict = new Dictionary<int, LFUCacheItem>();
        int _capacity = 0;
        int _currentCount = 0;

        LFUCacheItem _head = null;
        LFUCacheItem _tail = null;

        public LFUCache(int capacity)
        {
            _capacity = capacity;
            _currentCount = 0;
        }


        public int Get(int key)
        {
            if(_capacity<=0)
                return -1;
            
            if (_dict.ContainsKey(key))
            {
                //update freq etc
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
            if(_capacity<=0)
                return;
            
            if (_dict.ContainsKey(key))
            {
                //Set instead of insert
                _dict[key].value = value;

                //update freq etc
                Touch(key);
                return;
            }


            if (_currentCount < _capacity)
            {
                //add to the Doubly linked list
                LFUCacheItem newitem = new LFUCacheItem();
                newitem.key = key; 
                newitem.value = value;
                newitem.freq = 1;
                newitem.next = null; //by default
                newitem.previous = null;//by default

                _dict.Add(key, newitem);

                if (_head == null)
                {
                    //very very first item
                    _head = newitem;
                    _tail = newitem;
                }
                else
                {
                    //add to the back
                    _tail.next = newitem;
                    newitem.next = null;
                    newitem.previous = _tail;
                    _tail = newitem; 
                }

                _currentCount++;
                
                MoveUpByFrequency(newitem);
            }
            else
            {
                //Reached Capacity
                //find the least recent used item
                int tailkey = _tail.key;
                //remove it from Doubly Linked List
                LFUCacheItem prev = _tail.previous;
                if (_capacity>1)
                {
                    prev.next = null;
                    _tail = prev;
                }
                else
                {
                    //to handle 1 capacity 
                   _tail = null;
                   _head = null;
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

            LFUCacheItem item = _dict[key];
                 item.freq += 1;           

            if (item == _head)
            {
                //do nothing
            }
            else
            {

                MoveUpByFrequency(item);
            }
        }

        private void MoveUpByFrequency(LFUCacheItem item)
        {
            if (item == _head) return;

            if (item.previous == null)
                return;

            LFUCacheItem oldprev = item.previous;
            LFUCacheItem oldnex = item.next;

            LFUCacheItem temp = oldprev;
            while ((temp!=null) && (temp.freq <= item.freq))
            {
                temp = temp.previous;
            }

            if (temp == oldprev)
                return;

            oldprev.next = oldnex;
            if (oldnex != null)
            {
                oldnex.previous = oldprev;

            }
            else
            {
                _tail = oldprev;
            }

            if (temp == null)
            {
                //item would be inserted at the very front
                //////////////////////////////////////////
                item.next = _head;
                _head.previous = item;
                _head = item;
                item.previous = null;

            }
            else
            {
                //item will be inserted after temp
                //////////////////////////////////////////
                LFUCacheItem tempoldnext = temp.next;
                item.next = tempoldnext;
                tempoldnext.previous = item;
                temp.next = item;
                item.previous = temp;

            }
        }
}

    public class LFUCacheItem
    {
        public int key { get; set; }
        public int value { get; set; }
        public LFUCacheItem next { get; set; }
        public LFUCacheItem previous { get; set; }
        public int freq { get; set; } 
    }

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

