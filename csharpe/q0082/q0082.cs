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
    public ListNode DeleteDuplicates(ListNode head) {
        Dictionary<int, int> dict = new Dictionary<int, int>(); 
        
        ListNode current = head;
        
        while(current!=null)
        {
            if(!dict.Keys.Contains(current.val))
            {
                dict.Add(current.val, 1);
            }
            else
            {
                dict[current.val]=-1;
            }
            current = current.next;
        }
        
        ListNode dummy = new ListNode(-1);
        ListNode dummyTail = dummy;
        
        current = head;
        while(current!=null)
        {
            while(current!=null && dict[current.val]==-1 )
            {
                current = current.next;
            }
            
            if(current!=null)
            {
                ListNode temp = current.next;
                dummyTail.next = current;
                dummyTail = dummyTail.next;
                dummyTail.next = null;
                
                current = temp;
            }
        }
        
        head = dummy.next;
        return head;
    }
}