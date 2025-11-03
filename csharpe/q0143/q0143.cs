/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public void ReorderList(ListNode head) {
        if (head == null)
            return;
        ///First Step - find the length of the list and the Middle Point
        ListNode fast = head, slow = head;
        while(fast!=null && fast.next!=null)
        {
            slow = slow.next;
            fast = fast.next;
            if (fast != null)
                fast = fast.next;
        }

        ListNode middle = slow.next;slow.next = null;
        ///Second Step - Reverse the Second half of the List and 
        ListNode temp = ReverseList(middle);
        ///Braiding up the two Lists
        BraidList(head, temp);        
    }
    
    private ListNode ReverseList(ListNode head)
    {
        //copied from #q0206
        if (head == null)
            return null;

        ListNode newTail, newHead;
        ListNode current = head;
        newTail = head;
        newHead = newTail;

        while (current != null)
        {
            var next = current.next;

            if (current == head)
            {
                newTail.next = null;
            }
            else
            {
                current.next = newHead;
                newHead = current;
            }

            current = next;
        }

        return newHead;
    }

    private void BraidList(ListNode root1, ListNode root2)
    {
        ListNode current1 = root1;
        ListNode current2 = root2;

        while(current1!=null && current2!= null)
        {
            //saving the following nodes
            ListNode second1 = current1.next;
            ListNode second2 = current2.next;

            //reordering pointers
            current2.next = second1;
            current1.next = current2;

            //move forward;
            current1 = second1;
            current2 = second2;
        }

        return;
    }
}