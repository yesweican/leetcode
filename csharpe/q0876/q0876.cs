using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q876
    {
        //testing internal class!!!
         public class ListNode 
         {
             public int val;
             public ListNode next;
             public ListNode(int x) { val = x; }
        }

        public ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while ((fast != null) && (fast.next != null))
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;

        }
    }
}
