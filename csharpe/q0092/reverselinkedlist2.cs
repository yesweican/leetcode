/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode ReverseBetween(ListNode head, int m, int n) {
             ListNode newhead = null;
            ListNode LN1 = null, LN2 = null;
            ListNode LN3 = null, LN4 = null;

            ListNode current = head;
            int i=1;
            while (i <= (n + 1))
            {
                if (i == (m - 1))
                {
                    LN1 = current;
                }
                if (i == m)
                {
                    LN2 = current;
                }
                if (i == n)
                {
                    LN3 = current;
                }
                if (i == (n + 1))
                {
                    LN4 = current;
                    break;
                }

                if (current != null)
                {
                    current = current.next;
                    i++;
                }
                else
                    break;

            }

            ReverseStartEnd(LN2, LN3);

            if (LN1 != null)
            {
                LN1.next = LN3;
                LN2.next = LN4;
                newhead = head;
            }
            else
            {
                newhead = LN3;
                LN2.next = LN4;
            }

            return newhead;       
    }
    
        private void ReverseStartEnd(ListNode start, ListNode end)
        {
            ListNode current = start;
            ListNode lastNode = null, nextNode = null;

            while (current != end)
            {
                nextNode = current.next;
                current.next = lastNode;
                lastNode = current;
                current = nextNode;
            }

            end.next = lastNode;

        }    
}