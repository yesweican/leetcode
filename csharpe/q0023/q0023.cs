using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
         public class ListNode 
         {
             public int val;
             public ListNode next;
             public ListNode(int x) { val = x; }
         }

    public class q023
    {
         public ListNode MergeKLists(ListNode[] lists)
         {             
             //starting with a empty list and merge each list into it!!!!
             ListNode l0 = null;

             foreach (var node in lists)
             {
                 l0 = MergeTwoLists(l0, node);
             }

             return l0;
         }

        //reuse code from q021
         private ListNode MergeTwoLists(ListNode l1, ListNode l2)
         {
             ListNode tail = new ListNode(-1);
             ListNode head = tail;

             while (l1 != null && l2 != null)
             {
                 if (l1.val < l2.val)
                 {
                     tail.next = l1;
                     l1 = l1.next;
                     //tail=tail.next;
                 }
                 else
                 {
                     tail.next = l2;
                     l2 = l2.next;
                     //tail=tail.next;
                 }
                 tail = tail.next;

             }//end of while

             if (l1 != null)
             {
                 tail.next = l1;
             }
             else
             {
                 tail.next = l2;
             }

             return head.next;

         }
    }
}
