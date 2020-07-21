using GenericHeapApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    public class q023
    {
        public class ListNode
        {
             public int val;
             public ListNode next;
             public ListNode(int val = 0, ListNode next = null)
             {
                    this.val = val;
                    this.next = next;
             }
        }

        public class ListNodeComparer : Comparer<ListNode>
        {
            // Compares by val, need the override
            public override int Compare(ListNode x, ListNode y)
            {
                return x.val.CompareTo(y.val);
            }
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode dummy = new ListNode(-1);
            ListNode tail = dummy;
            int K = lists.Length;

            //Use delegate for an Comparer!!!
            MinHeap<ListNode> minheap = new MinHeap<ListNode>(new List<ListNode>(), Comparer<ListNode>.Create((x, y)=>(x.val>y.val?1:-1)));

            //Add a node of each list into minheap
            for(int i=0; i<K; i++)
            {
                if(lists[i]!=null)
                    minheap.Add(lists[i]);
            }

            while(minheap.Count>0)
            {
                //ListNode node = minheap.Peek();
                ListNode node = minheap.ExtractDominating();
                tail.next = node;

                //node pointing to the next node of the same list
                node= node.next;
                tail = tail.next;
                
                //put the next node of the same list to the heap until it is null
                if(node!=null)
                    minheap.Add(node);

            }

            return dummy.next;

        }

        /// <summary>
        /// SLIGHTLY slower!!!!
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists2(ListNode[] lists)
        {
            ListNode dummy = new ListNode(-1);
            ListNode tail = dummy;
            int K = lists.Length;

            //how to convert IComparer to Comparer???
            MinHeap<ListNode> minheap = new MinHeap<ListNode>(new List<ListNode>(), new ListNodeComparer());

            //Add a node of each list into minheap
            for (int i = 0; i < K; i++)
            {
                if (lists[i] != null)
                    minheap.Add(lists[i]);
            }

            while (minheap.Count > 0)
            {
                //ListNode node = minheap.Peek();
                ListNode node = minheap.ExtractDominating();
                tail.next = node;

                //node pointing to the next node of the same list
                node = node.next;
                tail = tail.next;

                //put the next node of the same list to the heap until it is null
                if (node != null)
                    minheap.Add(node);

            }

            return dummy.next;

        }
    }
}
