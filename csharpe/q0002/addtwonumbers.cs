/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            ListNode cur1 = l1;
            ListNode cur2 = l2;
            ListNode newHead = null, current=null;
            bool bFirst = true;
            int buffer=0, remainder=0;

            while ((cur1 != null) || (cur2 != null))
            {
                int temp = 0;

                if (cur1 != null)
                {
                    temp = temp + cur1.val; cur1 = cur1.next;
                }
                if (cur2 != null)
                {
                    temp = temp + cur2.val; cur2 = cur2.next;
                }


                if ((temp + buffer) >= 10)
                {
                    remainder = (temp + buffer) % 10; buffer = 1;
                }
                else
                {
                    remainder = temp + buffer;  buffer = 0;
                }

                if (bFirst)
                {
                    newHead = new ListNode(remainder);
                    current = newHead;
                    remainder = 0;
                    bFirst = false;
                }
                else
                {
                    current.next = new ListNode(remainder);
                    current = current.next;
                    remainder = 0;
                }
            }

            if (buffer > 0)
                current.next = new ListNode(1);

            return newHead;
    }
}