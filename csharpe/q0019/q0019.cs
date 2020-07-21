using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q019
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ///adding an additional head to facilite removing the head;
            ListNode head2 = new ListNode(-1);
            head2.next = head;

            ListNode frontpointer = head2;
            for (int i = 0; i <= n; i++)
            {
                frontpointer = frontpointer.next;
            }

            ListNode trailingpointer = head2;
            while (frontpointer != null)
            {
                frontpointer = frontpointer.next;
                trailingpointer = trailingpointer.next;
            }

            if (trailingpointer.next == head)
            {
                trailingpointer.next = trailingpointer.next.next;
                return head2.next;
            }
            else
            {
                trailingpointer.next = trailingpointer.next.next;
                return head;
            }
        }
    }
}
