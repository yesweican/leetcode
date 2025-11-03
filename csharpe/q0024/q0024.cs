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
    public ListNode SwapPairs(ListNode head) {
        if(head==null)
            return null;
        
            ListNode dummy = new ListNode(-1);
            dummy.next = head;

            ListNode ref1 = dummy;
            ListNode ref2 = head;
            ListNode ref3 = head.next;

            while(ref2!=null)
            {
                ListNode temp;
                if(ref3!=null)
                    temp = ref3.next;
                else
                    break;

                ref2.next = temp;
                ref3.next = ref2;
                ref1.next = ref3;

                ref1 = ref2;
                ref2 = temp;
                if(temp!=null)
                    ref3 = temp.next;
            }

            return dummy.next;    
    }
}