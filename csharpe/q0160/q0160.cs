using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Intersection of Linked Lists
    /// </summary>
    public class q160
    {

         //Definition for singly-linked list.
         public class ListNode {
             public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
         }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;

            Stack<ListNode> stack1 = new Stack<ListNode>();
            Stack<ListNode> stack2 = new Stack<ListNode>();
            ListNode current1 = headA; ListNode current2 = headB;
            while (current1 != null)
            {
                stack1.Push(current1);
                current1 = current1.next;
            }
            while (current2 != null)
            {
                stack2.Push(current2);
                current2 = current2.next;
            }

            ListNode dummy = new ListNode(-1);
            while (true)
            {
                ListNode temp1 = null;
                ListNode temp2 = null;

                if (stack1.Count > 0)
                    temp1 = stack1.Pop();
                else
                    break;
                if (stack2.Count > 0)
                    temp2 = stack2.Pop();
                else
                    break;

                if (temp1 != null && temp2 != null && temp1 == temp2)
                    dummy.next = temp1;
                else
                    break;
            }

            return dummy.next;

        }
    }
