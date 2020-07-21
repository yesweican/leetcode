using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q142
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                 val = x;
                 next = null;
            }
        }
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null)
                return null;

            ListNode slow = head.next;
            ListNode fast = null;
            if (head.next != null)
                fast = head.next.next;

            while ((fast != null) && (slow != fast))
            {
                slow = slow.next;
                if (fast.next != null)
                    fast = fast.next.next;
                else
                    fast = null;
            }

            if (fast == null)
                return null;

            slow = head;
            while(slow!=fast)
            {
                slow = slow.next;
                fast = fast.next;
            }

            return slow;
        }
    }
}
