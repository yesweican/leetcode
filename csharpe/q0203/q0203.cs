using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    public class q203
    {
         //Definition for singly-linked list.
         public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                 this.val = val;
                 this.next = next;
            }
         }

        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode dummy = new ListNode(-1, null);
            dummy.next = head;

            ListNode previous = dummy;
            ListNode current = head;

            while (current != null)
            {
                if (current.val == val)
                {
                    previous.next = current.next;
                    current = current.next;
                }
                else
                {
                    previous = current;
                    current = current.next;
                }
            }

            return dummy.next;
        }
    }
}
