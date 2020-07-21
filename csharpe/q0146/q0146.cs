using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    class q146
    {
        private Dictionary<int, LRUCacheItem> _dict = new Dictionary<int, LRUCacheItem>();
        int _capacity = 0;
        int _currentCount = 0;

        LRUCacheItem _head = null;
        LRUCacheItem _tail = null;

        /// <summary>
        /// //LRUCache
        /// </summary>
        /// <param name="capacity"></param>
        public q146(int capacity)
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

            //make adjustment if reached capacity
            if (_currentCount >= _capacity)
            {
                //Reached Capacity
                //find the least recent used(LRU) item
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

                //remove it from dictionary as well
                _dict.Remove(tailkey);
                _currentCount--;
            }

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

    /// <summary>
    /// move the item to the front
    /// </summary>
    /// <param name="key"></param>
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
                //adjust tail if necessary
                if (nex == null)
                    _tail = prev;
                else
                    nex.previous = prev;
                //adjust head of linked list
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
}

public class LRUCache
{

}



/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */