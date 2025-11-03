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
    public ListNode RotateRight(ListNode head, int k) {
        if(head == null)
            return null;
        
        int count = 0;
        
        ListNode current = head;
        while(current!=null)
        {
            count++;
            current = current.next;
        }
        
        int k0 = k % count;
        int k1 = count - k0;
        
        if(k0==0)
            return head;
        
        ListNode previous = null;
        current = head;
        int step = 0;
        while(k1>0)
        {
            previous = current;
            current = current.next;
            k1--;
        }
        
        if(previous!=null)
            previous.next = null;
        
        ListNode newHead = current;
        previous = null;
        while(k0>0)
        {
            previous = current;
            current = current.next;
            k0--;
        }
        
        if(previous!=null)
            previous.next = head;
        
        return newHead;
        
        
    }
}